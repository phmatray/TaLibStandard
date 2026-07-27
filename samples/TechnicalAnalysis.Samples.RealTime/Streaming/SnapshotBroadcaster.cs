// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using TechnicalAnalysis.Samples.RealTime.Configuration;
using TechnicalAnalysis.Samples.RealTime.Contracts;

namespace TechnicalAnalysis.Samples.RealTime.Streaming;

/// <summary>
/// The per-symbol distribution point for indicator snapshots, shared by the SignalR hub and the raw
/// WebSocket handler.
/// </summary>
/// <remarks>
/// Keeping the last published snapshot per symbol is what stops a client staring at an empty chart for a
/// whole bar period after it connects. New subscribers are handed that snapshot immediately and then join
/// the live stream, so "connected" and "showing data" happen at the same moment.
/// </remarks>
public sealed class SnapshotBroadcaster
{
    private readonly ConcurrentDictionary<string, BoundedFanout<IndicatorSnapshot>> _fanouts;
    private readonly ConcurrentDictionary<string, IndicatorSnapshot> _latest;
    private readonly ConcurrentDictionary<(string ConnectionId, string Symbol), byte> _groupMembers = new();
    private readonly HashSet<string> _knownSymbols;
    private readonly int _capacity;

    /// <summary>
    /// Initializes a new instance of the <see cref="SnapshotBroadcaster"/> class.
    /// </summary>
    /// <param name="options">The bound sample options.</param>
    public SnapshotBroadcaster(IOptions<RealTimeOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);

        RealTimeOptions value = options.Value;
        _capacity = value.SubscriberQueueCapacity;
        _knownSymbols = new HashSet<string>(value.Symbols, StringComparer.OrdinalIgnoreCase);
        _fanouts = new ConcurrentDictionary<string, BoundedFanout<IndicatorSnapshot>>(StringComparer.OrdinalIgnoreCase);
        _latest = new ConcurrentDictionary<string, IndicatorSnapshot>(StringComparer.OrdinalIgnoreCase);
        Symbols = [.. value.Symbols];
    }

    /// <summary>
    /// Gets the symbols this broadcaster accepts, in configuration order.
    /// </summary>
    public IReadOnlyList<string> Symbols { get; }

    /// <summary>
    /// Gets the number of live <em>channel</em> subscribers across every symbol: raw WebSocket clients and
    /// hub streaming callers, i.e. everything that reads a <see cref="BoundedFanout{T}"/>.
    /// </summary>
    /// <remarks>
    /// This deliberately does not count the SignalR push transport, whose subscribers live in a hub group
    /// and never touch a fanout. <see cref="GroupSubscriberCount"/> covers those. A single number over both
    /// would hide a leaked group membership behind a healthy-looking zero.
    /// </remarks>
    public int ChannelSubscriberCount => _fanouts.Values.Sum(fanout => fanout.SubscriberCount);

    /// <summary>
    /// Gets the number of live SignalR group memberships: one per connection per symbol subscribed through
    /// the push transport.
    /// </summary>
    public int GroupSubscriberCount => _groupMembers.Count;

    /// <summary>
    /// Resolves a client-supplied symbol to its configured spelling.
    /// </summary>
    /// <param name="symbol">The requested symbol. Case insensitive; surrounding whitespace is ignored.</param>
    /// <param name="resolved">The configured spelling, when the symbol is known.</param>
    /// <returns><see langword="true"/> when the symbol is published by this server.</returns>
    public bool TryResolveSymbol(string? symbol, out string resolved)
    {
        string candidate = symbol?.Trim() ?? string.Empty;
        if (candidate.Length > 0 && _knownSymbols.Contains(candidate))
        {
            resolved = Symbols.First(known => string.Equals(known, candidate, StringComparison.OrdinalIgnoreCase));
            return true;
        }

        resolved = string.Empty;
        return false;
    }

    /// <summary>
    /// Publishes a snapshot to every subscriber of its symbol.
    /// </summary>
    /// <param name="snapshot">The snapshot to publish.</param>
    public void Publish(IndicatorSnapshot snapshot)
    {
        ArgumentNullException.ThrowIfNull(snapshot);

        _latest[snapshot.Symbol] = snapshot;
        FanoutFor(snapshot.Symbol).Publish(snapshot);
    }

    /// <summary>
    /// Subscribes to one symbol's snapshots.
    /// </summary>
    /// <param name="symbol">The symbol to follow. Must already have been resolved.</param>
    /// <returns>A subscription the caller must dispose when it stops reading.</returns>
    public FanoutSubscription<IndicatorSnapshot> Subscribe(string symbol) => FanoutFor(symbol).Subscribe();

    /// <summary>
    /// Records that a connection joined a symbol's push group.
    /// </summary>
    /// <param name="connectionId">The SignalR connection id.</param>
    /// <param name="symbol">The resolved symbol.</param>
    public void TrackGroupJoin(string connectionId, string symbol) => _groupMembers[(connectionId, symbol)] = 0;

    /// <summary>
    /// Records that a connection left a symbol's push group.
    /// </summary>
    /// <param name="connectionId">The SignalR connection id.</param>
    /// <param name="symbol">The resolved symbol.</param>
    public void TrackGroupLeave(string connectionId, string symbol) => _groupMembers.TryRemove((connectionId, symbol), out _);

    /// <summary>
    /// Forgets every group membership of a connection. Called when the connection ends, because SignalR
    /// removes a dead connection from its groups without telling the application which ones they were.
    /// </summary>
    /// <param name="connectionId">The SignalR connection id.</param>
    public void TrackConnectionClosed(string connectionId)
    {
        foreach ((string ConnectionId, string Symbol) key in _groupMembers.Keys)
        {
            if (string.Equals(key.ConnectionId, connectionId, StringComparison.Ordinal))
            {
                _groupMembers.TryRemove(key, out _);
            }
        }
    }

    /// <summary>
    /// Gets the most recently published snapshot for a symbol.
    /// </summary>
    /// <param name="symbol">The symbol to look up.</param>
    /// <returns>The snapshot, or <see langword="null"/> if no bar has closed yet.</returns>
    public IndicatorSnapshot? Latest(string symbol)
        => _latest.TryGetValue(symbol, out IndicatorSnapshot? snapshot) ? snapshot : null;

    private BoundedFanout<IndicatorSnapshot> FanoutFor(string symbol)
        => _fanouts.GetOrAdd(symbol, static (_, capacity) => new BoundedFanout<IndicatorSnapshot>(capacity), _capacity);
}
