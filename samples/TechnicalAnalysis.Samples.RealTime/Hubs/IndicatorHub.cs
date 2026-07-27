// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Runtime.CompilerServices;
using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR;
using TechnicalAnalysis.Samples.RealTime.Contracts;
using TechnicalAnalysis.Samples.RealTime.Streaming;

namespace TechnicalAnalysis.Samples.RealTime.Hubs;

/// <summary>
/// The SignalR surface of the sample, offering the same data two ways.
/// </summary>
/// <remarks>
/// <para>
/// <strong>Push</strong> — call <see cref="SubscribeAsync"/> and handle the <c>snapshot</c> client method.
/// The connection joins a per-symbol group and the server pushes each closed bar to the whole group. One
/// send per group per bar regardless of how many clients are watching, which is what you want when
/// thousands of browsers follow the same instrument.
/// </para>
/// <para>
/// <strong>Streaming</strong> — call <see cref="StreamSnapshotsAsync"/> and consume the
/// <see cref="IAsyncEnumerable{T}"/>. Each caller gets its own bounded queue, its own cancellation, and
/// disposal that is guaranteed to run when the client walks away or the connection dies. Prefer this when
/// a caller wants per-request lifetime rather than a connection-wide subscription.
/// </para>
/// <para>
/// Both paths hand out the same <see cref="IndicatorSnapshot"/> instances and drop under the same
/// backpressure policy; see <see cref="BoundedFanout{T}"/>.
/// </para>
/// </remarks>
/// <param name="broadcaster">The snapshot distribution point every transport reads from.</param>
public sealed class IndicatorHub(SnapshotBroadcaster broadcaster) : Hub
{
    /// <summary>The client method name the server invokes with each closed bar's snapshot.</summary>
    public const string SnapshotMethod = "snapshot";

    private readonly SnapshotBroadcaster _broadcaster = broadcaster;

    /// <summary>
    /// Builds the SignalR group name used for a symbol.
    /// </summary>
    /// <param name="symbol">The resolved symbol.</param>
    /// <returns>The group name.</returns>
    public static string GroupFor(string symbol) => $"symbol:{symbol}";

    /// <summary>
    /// Lists the symbols this server publishes.
    /// </summary>
    /// <returns>The configured symbols, in configuration order.</returns>
    [HubMethodName("GetSymbols")]
    public IReadOnlyList<string> GetSymbols() => _broadcaster.Symbols;

    /// <summary>
    /// Subscribes this connection to a symbol's push stream and immediately replays the latest snapshot.
    /// </summary>
    /// <param name="symbol">The symbol to follow. Case insensitive.</param>
    /// <returns>A task that completes once the connection has joined the group.</returns>
    /// <exception cref="HubException">The symbol is not published by this server.</exception>
    [HubMethodName("Subscribe")]
    public async Task SubscribeAsync(string symbol)
    {
        string resolved = Resolve(symbol);

        await Groups.AddToGroupAsync(Context.ConnectionId, GroupFor(resolved), Context.ConnectionAborted);
        _broadcaster.TrackGroupJoin(Context.ConnectionId, resolved);

        // Replaying the last bar means a client that connects mid-period sees data now rather than after
        // the next boundary. The replayed snapshot carries its own sequence number, so a client that
        // reconnects can tell whether it already had this bar.
        if (_broadcaster.Latest(resolved) is { } latest)
        {
            await Clients.Caller.SendAsync(SnapshotMethod, latest, Context.ConnectionAborted);
        }
    }

    /// <summary>
    /// Unsubscribes this connection from a symbol's push stream.
    /// </summary>
    /// <param name="symbol">The symbol to stop following. Case insensitive.</param>
    /// <returns>A task that completes once the connection has left the group.</returns>
    /// <exception cref="HubException">The symbol is not published by this server.</exception>
    [HubMethodName("Unsubscribe")]
    public async Task UnsubscribeAsync(string symbol)
    {
        string resolved = Resolve(symbol);

        await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupFor(resolved), Context.ConnectionAborted);
        _broadcaster.TrackGroupLeave(Context.ConnectionId, resolved);
    }

    /// <inheritdoc />
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        // SignalR drops a dead connection from its groups without telling us which ones they were, so the
        // membership counter has to be reconciled here or /health would report a leak that does not exist.
        _broadcaster.TrackConnectionClosed(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }

    /// <summary>
    /// Streams a symbol's snapshots to the caller until the caller cancels or the connection ends.
    /// </summary>
    /// <param name="symbol">The symbol to follow. Case insensitive.</param>
    /// <param name="cancellationToken">
    /// Supplied by SignalR. It fires when the client disposes its stream, when the connection drops, and
    /// when the host shuts down; honouring it is what makes the subscription leak free.
    /// </param>
    /// <returns>An async sequence of snapshots, newest last.</returns>
    /// <exception cref="HubException">The symbol is not published by this server.</exception>
    [HubMethodName("StreamSnapshots")]
    public async IAsyncEnumerable<IndicatorSnapshot> StreamSnapshotsAsync(
        string symbol,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string resolved = Resolve(symbol);

        // Subscribe before yielding anything so no bar can slip between the replay and the live stream.
        using FanoutSubscription<IndicatorSnapshot> subscription = _broadcaster.Subscribe(resolved);

        // Subscribing before the replay closes the loss window and opens a duplication one: a publish that
        // interleaves between the broadcaster storing "latest" and fanning out delivers the same bar twice.
        // Tracking the highest sequence yielded closes that too, so the stream is strictly increasing.
        long lastSequence = -1;

        if (_broadcaster.Latest(resolved) is { } latest)
        {
            lastSequence = latest.Sequence;
            yield return latest;
        }

        while (true)
        {
            IndicatorSnapshot? next = await ReadNextAsync(subscription.Reader, cancellationToken);
            if (next is null)
            {
                yield break;
            }

            if (next.Sequence <= lastSequence)
            {
                continue;
            }

            lastSequence = next.Sequence;
            yield return next;
        }
    }

    /// <summary>
    /// Reads the next snapshot, translating the two normal end-of-stream conditions into a null so the
    /// iterator can finish without an exception. An iterator cannot yield from inside a try/catch, which
    /// is why this lives in its own method.
    /// </summary>
    private static async Task<IndicatorSnapshot?> ReadNextAsync(
        ChannelReader<IndicatorSnapshot> reader,
        CancellationToken cancellationToken)
    {
        try
        {
            return await reader.ReadAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            return null;
        }
        catch (ChannelClosedException)
        {
            return null;
        }
    }

    private string Resolve(string symbol)
    {
        if (!_broadcaster.TryResolveSymbol(symbol, out string resolved))
        {
            throw new HubException($"Unknown symbol '{symbol}'. Call GetSymbols for the list this server publishes.");
        }

        return resolved;
    }
}
