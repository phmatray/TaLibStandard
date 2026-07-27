// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using TechnicalAnalysis.Samples.RealTime.Configuration;
using TechnicalAnalysis.Samples.RealTime.Contracts;
using TechnicalAnalysis.Samples.RealTime.Diagnostics;
using TechnicalAnalysis.Samples.RealTime.Hubs;
using TechnicalAnalysis.Samples.RealTime.Indicators;

namespace TechnicalAnalysis.Samples.RealTime.Streaming;

/// <summary>
/// The one place ticks become indicator snapshots: tick in, bar out, snapshot out, fanned to both transports.
/// </summary>
/// <remarks>
/// <para>
/// A single loop owns every aggregator and engine, so those types stay simple, single-threaded and free of
/// locks. The loop is a subscriber of the feed like any other, which means it is subject to the same
/// drop-oldest policy — if this loop ever fell behind the feed it would skip ticks rather than stall the
/// producer, and the skipped ticks would show up as thinner bars rather than as a hung server.
/// </para>
/// <para>
/// <strong>The tick loop never awaits a client.</strong> The pull transport is a
/// <see cref="BoundedFanout{T}"/> write that cannot block. The SignalR push transport can: a group send
/// completes only once every member connection's transport pipe has accepted the frame, so one subscriber
/// that stops draining would otherwise park this loop and starve <em>every</em> symbol on <em>every</em>
/// transport — exactly the outage the drop-oldest policy exists to prevent. The group send therefore runs on
/// its own pump, fed by a bounded drop-oldest queue and bounded again by <see cref="PushTimeout"/> per bar.
/// A wedged SignalR client costs its own group the bar and nothing else.
/// </para>
/// </remarks>
public sealed class IndicatorPipeline : BackgroundService
{
    /// <summary>
    /// How long one SignalR group send may take before the bar is abandoned for that group. Short on
    /// purpose: a bar that has not reached a client within a fraction of the bar period is already stale,
    /// and the next one is on its way.
    /// </summary>
    private static readonly TimeSpan PushTimeout = TimeSpan.FromMilliseconds(250);

    private readonly SyntheticMarketDataFeed _feed;
    private readonly SnapshotBroadcaster _broadcaster;
    private readonly IHubContext<IndicatorHub> _hub;
    private readonly RealTimeOptions _options;
    private readonly ILogger<IndicatorPipeline> _logger;
    private readonly Channel<IndicatorSnapshot> _pushQueue;
    private long _barsClosed;
    private long _pushesDropped;

    /// <summary>
    /// Initializes a new instance of the <see cref="IndicatorPipeline"/> class.
    /// </summary>
    /// <param name="feed">The synthetic tick source.</param>
    /// <param name="broadcaster">The snapshot distribution point.</param>
    /// <param name="hub">The SignalR hub context used for the push transport.</param>
    /// <param name="options">The bound sample options.</param>
    /// <param name="logger">The logger used for lifecycle messages.</param>
    public IndicatorPipeline(
        SyntheticMarketDataFeed feed,
        SnapshotBroadcaster broadcaster,
        IHubContext<IndicatorHub> hub,
        IOptions<RealTimeOptions> options,
        ILogger<IndicatorPipeline> logger)
    {
        ArgumentNullException.ThrowIfNull(options);

        _feed = feed;
        _broadcaster = broadcaster;
        _hub = hub;
        _options = options.Value;
        _logger = logger;

        // Same capacity and same policy as every other consumer queue in the sample: a late bar is worth
        // nothing, so the oldest is discarded rather than letting the queue — or the tick loop — grow.
        _pushQueue = Channel.CreateBounded<IndicatorSnapshot>(
            new BoundedChannelOptions(_options.SubscriberQueueCapacity)
            {
                FullMode = BoundedChannelFullMode.DropOldest,
                SingleReader = true,
                SingleWriter = true,
                AllowSynchronousContinuations = false
            });
    }

    /// <summary>
    /// Gets the number of bars closed since the process started.
    /// </summary>
    public long BarsClosed => Interlocked.Read(ref _barsClosed);

    /// <summary>
    /// Gets the number of bars the SignalR push transport failed to deliver within <see cref="PushTimeout"/>
    /// or dropped from its queue. Non-zero means a group had a subscriber that stopped reading.
    /// </summary>
    public long PushesDropped => Interlocked.Read(ref _pushesDropped);

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Subscribing before the first await guarantees no tick published after this point is missed.
        using FanoutSubscription<Tick> subscription = _feed.Subscribe();

        TimeSpan barPeriod = TimeSpan.FromSeconds(_options.BarSeconds);
        Dictionary<string, SymbolPipeline> pipelines = new(StringComparer.Ordinal);
        int barsRequired = RollingIndicatorEngine.LargestLookback(_options.Indicators) + 1;

        foreach (string symbol in _feed.Symbols)
        {
            pipelines[symbol] = new SymbolPipeline(
                new BarAggregator(symbol, barPeriod),
                new RollingIndicatorEngine(symbol, _options.WindowSize, _options.Indicators));
        }

        SampleLog.PipelineStarted(_logger, _options.BarSeconds, _options.WindowSize, barsRequired);

        // Started before the read loop so no queued snapshot waits for a pump that does not exist yet.
        Task pushPump = PushLoopAsync();

        try
        {
            await foreach (Tick tick in subscription.Reader.ReadAllAsync(stoppingToken))
            {
                if (!pipelines.TryGetValue(tick.Symbol, out SymbolPipeline? pipeline))
                {
                    continue;
                }

                Bar? closed = pipeline.Aggregator.Add(tick);
                if (closed is null)
                {
                    continue;
                }

                Publish(pipeline, closed);
            }
        }
        catch (OperationCanceledException)
        {
            // Expected on shutdown.
        }

        // Shutdown: close whatever bar is still forming so the last partial period is published rather than
        // silently discarded. Cancellation is already requested at this point, so the publish path uses
        // CancellationToken.None and relies on the push pump's own timeout to stay bounded.
        foreach (SymbolPipeline pipeline in pipelines.Values)
        {
            if (pipeline.Aggregator.Flush() is { } partial)
            {
                Publish(pipeline, partial);
            }
        }

        _pushQueue.Writer.TryComplete();
        await pushPump;

        SampleLog.PipelineStopped(_logger, BarsClosed);
    }

    private void Publish(SymbolPipeline pipeline, Bar bar)
    {
        IndicatorSnapshot snapshot = pipeline.Engine.Update(bar);
        Interlocked.Increment(ref _barsClosed);

        // Pull transport: anything reading a channel (raw WebSocket clients, hub streaming callers).
        _broadcaster.Publish(snapshot);

        // Push transport: handed to the pump rather than awaited here. TryWrite never blocks and never
        // throws; a full queue drops the oldest snapshot, which is the same bargain the fanout makes.
        if (!_pushQueue.Writer.TryWrite(snapshot))
        {
            Interlocked.Increment(ref _pushesDropped);
        }

        SampleLog.BarClosed(
            _logger,
            snapshot.Symbol,
            snapshot.Sequence,
            snapshot.Close,
            snapshot.BarsInWindow,
            snapshot.BarsRequired,
            snapshot.Signal);
    }

    /// <summary>
    /// Drains the push queue and broadcasts each snapshot to its SignalR group, giving every send a deadline
    /// so that a connection whose transport pipe has stopped draining cannot park this pump either.
    /// </summary>
    private async Task PushLoopAsync()
    {
        try
        {
            await foreach (IndicatorSnapshot snapshot in _pushQueue.Reader.ReadAllAsync(CancellationToken.None))
            {
                using CancellationTokenSource send = new(PushTimeout);

                try
                {
                    await _hub.Clients
                        .Group(IndicatorHub.GroupFor(snapshot.Symbol))
                        .SendAsync(IndicatorHub.SnapshotMethod, snapshot, send.Token);
                }
                catch (OperationCanceledException)
                {
                    // The deadline expired: abandon this bar for this group. Sequence numbers are contiguous
                    // per symbol, so a client that cares can see the gap exactly as it would a fanout drop.
                    Interlocked.Increment(ref _pushesDropped);
                    SampleLog.PushTimedOut(_logger, snapshot.Symbol, snapshot.Sequence, PushTimeout.TotalMilliseconds);
                }
            }
        }
        catch (ChannelClosedException)
        {
            // The writer completed while a read was pending. Nothing left to push.
        }
    }

    private sealed record SymbolPipeline(BarAggregator Aggregator, RollingIndicatorEngine Engine);
}
