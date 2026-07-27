// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Samples.RealTime.Contracts;

namespace TechnicalAnalysis.Samples.RealTime.Streaming;

/// <summary>
/// Folds a tick stream for one symbol into fixed-period OHLCV bars.
/// </summary>
/// <remarks>
/// <para>
/// Bars are aligned to absolute time, not to the first tick seen: a tick's bucket is its Unix timestamp
/// floored to the bar period. Two servers started seconds apart therefore agree on bar boundaries, and a
/// client can label a bar without asking when the server booted.
/// </para>
/// <para>
/// A bar is closed by the arrival of the first tick belonging to a later bucket. That is the standard
/// aggregator contract and it has one consequence worth stating: a period with no ticks in it produces no
/// bar, and the previous bar stays open until trading resumes. With the synthetic feed ticking several
/// times a second that never happens; against a real venue at 3am it happens constantly, and downstream
/// code must treat bar timestamps as a sparse series rather than a metronome.
/// </para>
/// <para>
/// This type is not thread safe. Each symbol gets its own instance, driven by the single pipeline loop.
/// </para>
/// </remarks>
public sealed class BarAggregator
{
    private readonly string _symbol;
    private readonly long _periodMilliseconds;

    private long _bucketStart = -1;
    private decimal _open;
    private decimal _high;
    private decimal _low;
    private decimal _close;
    private long _volume;
    private int _tickCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="BarAggregator"/> class.
    /// </summary>
    /// <param name="symbol">The symbol whose ticks this aggregator folds.</param>
    /// <param name="period">The bar period. Must be positive.</param>
    /// <exception cref="ArgumentOutOfRangeException">The period is not positive.</exception>
    public BarAggregator(string symbol, TimeSpan period)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(period, TimeSpan.Zero);

        _symbol = symbol;
        _periodMilliseconds = (long)period.TotalMilliseconds;
    }

    /// <summary>
    /// Gets a value indicating whether a bar is currently open.
    /// </summary>
    public bool HasOpenBar => _bucketStart >= 0;

    /// <summary>
    /// Adds a tick.
    /// </summary>
    /// <param name="tick">The tick to fold in.</param>
    /// <returns>
    /// The bar that just closed, if this tick crossed a period boundary; otherwise <see langword="null"/>.
    /// </returns>
    public Bar? Add(Tick tick)
    {
        ArgumentNullException.ThrowIfNull(tick);

        long bucket = FloorToBucket(tick.Timestamp);

        if (_bucketStart < 0)
        {
            StartBucket(bucket, tick);
            return null;
        }

        if (bucket == _bucketStart)
        {
            Accumulate(tick);
            return null;
        }

        // A late tick belonging to an already-closed bucket is dropped rather than back-filled: rewriting
        // a bar a client has already charted is worse than ignoring one print.
        if (bucket < _bucketStart)
        {
            return null;
        }

        Bar closed = BuildBar();
        StartBucket(bucket, tick);
        return closed;
    }

    /// <summary>
    /// Closes the in-progress bar, if any. Called on shutdown so the last partial period is not lost.
    /// </summary>
    /// <returns>The partial bar, or <see langword="null"/> if no bar was open.</returns>
    public Bar? Flush()
    {
        if (_bucketStart < 0)
        {
            return null;
        }

        Bar closed = BuildBar();
        _bucketStart = -1;
        return closed;
    }

    /// <summary>
    /// Floors a timestamp to its bar bucket. The remainder is taken with floor semantics rather than C#
    /// truncation so pre-epoch timestamps bucket downwards too.
    /// </summary>
    private long FloorToBucket(DateTimeOffset timestamp)
    {
        long milliseconds = timestamp.ToUnixTimeMilliseconds();
        long remainder = milliseconds % _periodMilliseconds;
        if (remainder < 0)
        {
            remainder += _periodMilliseconds;
        }

        return milliseconds - remainder;
    }

    private void StartBucket(long bucket, Tick tick)
    {
        _bucketStart = bucket;
        _open = tick.Price;
        _high = tick.Price;
        _low = tick.Price;
        _close = tick.Price;
        _volume = tick.Volume;
        _tickCount = 1;
    }

    private void Accumulate(Tick tick)
    {
        if (tick.Price > _high)
        {
            _high = tick.Price;
        }

        if (tick.Price < _low)
        {
            _low = tick.Price;
        }

        _close = tick.Price;
        _volume += tick.Volume;
        _tickCount++;
    }

    private Bar BuildBar()
        => new(
            _symbol,
            DateTimeOffset.FromUnixTimeMilliseconds(_bucketStart),
            _open,
            _high,
            _low,
            _close,
            _volume,
            _tickCount);
}
