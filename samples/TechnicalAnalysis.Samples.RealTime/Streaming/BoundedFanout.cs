// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Threading.Channels;

namespace TechnicalAnalysis.Samples.RealTime.Streaming;

/// <summary>
/// Fans one producer out to N independent consumers, each with its own bounded queue.
/// </summary>
/// <typeparam name="T">The item being fanned out. Reference types only, because items are shared by every
/// subscriber and must therefore be immutable in practice.</typeparam>
/// <remarks>
/// <para><strong>Backpressure policy: drop oldest, never block the producer.</strong></para>
/// <para>
/// Each subscriber gets a bounded channel created with
/// <see cref="BoundedChannelFullMode.DropOldest"/>. When a consumer stops reading — a browser tab moved
/// to the background, a console client paused at a breakpoint, a socket wedged behind a full TCP window —
/// its queue fills and the oldest queued item is discarded to make room for the newest.
/// </para>
/// <para>
/// This is the right policy for a market feed and the wrong one for an order feed. A late price is worth
/// nothing: a consumer that is 40 bars behind does not want to replay 40 stale bars, it wants the current
/// one. The alternatives are both worse here. <see cref="BoundedChannelFullMode.Wait"/> would let the
/// slowest subscriber throttle the producer and therefore every other subscriber, which is how one
/// wedged client takes down a whole feed. An unbounded channel would trade that stall for unbounded
/// memory growth, which is the same outage with a longer fuse.
/// </para>
/// <para>
/// Dropping is not silent: <see cref="Contracts.IndicatorSnapshot.Sequence"/> increases by one per bar, so
/// a client that cares can see the gap. Anything that must not be lost — fills, cancels, risk limits —
/// belongs on a different, acknowledged channel, not on this one.
/// </para>
/// <para>
/// Subscription is race free and leak free. The subscriber list is copy-on-write: mutations take a lock
/// and publish a brand new array, while <see cref="Publish"/> reads one immutable snapshot and never
/// takes a lock. A publisher holding a snapshot that contains a just-removed channel simply writes into a
/// completed channel, and <see cref="ChannelWriter{T}.TryWrite"/> returns false. Disposing a
/// <see cref="FanoutSubscription{T}"/> is idempotent, so the usual
/// <c>using</c>/finally/disconnect-handler triple call is harmless.
/// </para>
/// </remarks>
public sealed class BoundedFanout<T>
    where T : class
{
    private readonly Lock _gate = new();
    private readonly int _capacity;
    private Channel<T>[] _subscribers = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="BoundedFanout{T}"/> class.
    /// </summary>
    /// <param name="capacity">How many items a single subscriber may buffer before the oldest is dropped.</param>
    /// <exception cref="ArgumentOutOfRangeException">The capacity is not positive.</exception>
    public BoundedFanout(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(capacity, 1);
        _capacity = capacity;
    }

    /// <summary>
    /// Gets the number of live subscribers.
    /// </summary>
    public int SubscriberCount => Volatile.Read(ref _subscribers).Length;

    /// <summary>
    /// Adds a subscriber and hands back the handle used to read from and later detach it.
    /// </summary>
    /// <returns>A subscription that must be disposed when the consumer goes away.</returns>
    public FanoutSubscription<T> Subscribe()
    {
        BoundedChannelOptions options = new(_capacity)
        {
            FullMode = BoundedChannelFullMode.DropOldest,
            SingleReader = true,
            SingleWriter = false,
            AllowSynchronousContinuations = false
        };

        Channel<T> channel = Channel.CreateBounded<T>(options);

        lock (_gate)
        {
            _subscribers = [.. _subscribers, channel];
        }

        return new FanoutSubscription<T>(this, channel);
    }

    /// <summary>
    /// Offers an item to every live subscriber. Never blocks and never throws.
    /// </summary>
    /// <param name="item">The item to publish.</param>
    public void Publish(T item)
    {
        Channel<T>[] snapshot = Volatile.Read(ref _subscribers);
        foreach (Channel<T> channel in snapshot)
        {
            // TryWrite returns false for a channel completed by a concurrent unsubscribe, and drops the
            // oldest queued item for a channel whose consumer has fallen behind. Both are expected.
            channel.Writer.TryWrite(item);
        }
    }

    /// <summary>
    /// Detaches a subscriber and completes its channel so a pending read finishes instead of hanging.
    /// </summary>
    /// <param name="channel">The channel to detach.</param>
    internal void Remove(Channel<T> channel)
    {
        lock (_gate)
        {
            int index = Array.IndexOf(_subscribers, channel);
            if (index < 0)
            {
                return;
            }

            Channel<T>[] replacement = new Channel<T>[_subscribers.Length - 1];
            Array.Copy(_subscribers, replacement, index);
            Array.Copy(_subscribers, index + 1, replacement, index, _subscribers.Length - index - 1);
            _subscribers = replacement;
        }

        channel.Writer.TryComplete();
    }
}

/// <summary>
/// One consumer's view of a <see cref="BoundedFanout{T}"/>: a reader plus the right to leave.
/// </summary>
/// <typeparam name="T">The item being fanned out.</typeparam>
public sealed class FanoutSubscription<T> : IDisposable
    where T : class
{
    private readonly BoundedFanout<T> _owner;
    private readonly Channel<T> _channel;
    private int _disposed;

    internal FanoutSubscription(BoundedFanout<T> owner, Channel<T> channel)
    {
        _owner = owner;
        _channel = channel;
    }

    /// <summary>
    /// Gets the reader this consumer should drain. It completes when the subscription is disposed.
    /// </summary>
    public ChannelReader<T> Reader => _channel.Reader;

    /// <summary>
    /// Detaches from the fanout. Safe to call from any thread and safe to call more than once.
    /// </summary>
    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            _owner.Remove(_channel);
        }
    }
}
