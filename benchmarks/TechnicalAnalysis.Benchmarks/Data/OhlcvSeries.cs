// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Benchmarks.Data;

/// <summary>
/// An open / high / low / close / volume series projected onto a single numeric type.
/// </summary>
/// <typeparam name="T">The numeric type the series is projected onto (double, float or decimal).</typeparam>
/// <remarks>
/// All five arrays always have the same length. Instances are produced by <see cref="MarketDataGenerator"/> and are
/// treated as immutable by the benchmarks: an indicator must never write into its input.
/// </remarks>
public sealed class OhlcvSeries<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OhlcvSeries{T}"/> class.
    /// </summary>
    /// <param name="open">The open prices.</param>
    /// <param name="high">The high prices.</param>
    /// <param name="low">The low prices.</param>
    /// <param name="close">The close prices.</param>
    /// <param name="volume">The traded volumes.</param>
    public OhlcvSeries(T[] open, T[] high, T[] low, T[] close, T[] volume)
    {
        Open = open;
        High = high;
        Low = low;
        Close = close;
        Volume = volume;
    }

    /// <summary>
    /// Gets the open prices.
    /// </summary>
    public T[] Open { get; }

    /// <summary>
    /// Gets the high prices.
    /// </summary>
    public T[] High { get; }

    /// <summary>
    /// Gets the low prices.
    /// </summary>
    public T[] Low { get; }

    /// <summary>
    /// Gets the close prices.
    /// </summary>
    public T[] Close { get; }

    /// <summary>
    /// Gets the traded volumes.
    /// </summary>
    public T[] Volume { get; }

    /// <summary>
    /// Gets the number of bars in the series.
    /// </summary>
    public int Length => Close.Length;
}
