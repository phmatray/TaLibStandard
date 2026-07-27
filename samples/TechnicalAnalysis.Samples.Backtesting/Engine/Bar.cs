// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// Represents a single OHLCV price bar (candle) of a time series.
/// </summary>
/// <param name="Timestamp">The instant the bar closed. Bars are expected to be ordered strictly ascending by this value.</param>
/// <param name="Open">The first traded price of the bar. Orders generated on the previous bar are filled at this price.</param>
/// <param name="High">The highest traded price of the bar.</param>
/// <param name="Low">The lowest traded price of the bar.</param>
/// <param name="Close">The last traded price of the bar. Used for mark-to-market valuation of open positions.</param>
/// <param name="Volume">The traded volume of the bar.</param>
public sealed record Bar(DateTime Timestamp, double Open, double High, double Low, double Close, double Volume)
{
    /// <summary>
    /// Gets the typical price of the bar, defined as <c>(High + Low + Close) / 3</c>.
    /// </summary>
    public double TypicalPrice => (High + Low + Close) / 3.0;

    /// <summary>
    /// Gets the high-low range of the bar, defined as <c>High - Low</c>.
    /// </summary>
    public double Range => High - Low;

    /// <summary>
    /// Validates that the bar is internally consistent: the high is the maximum and the low is the minimum
    /// of the open, high, low and close prices, all prices are finite and strictly positive, and the volume
    /// is finite and non-negative.
    /// </summary>
    /// <returns><see langword="true"/> when the bar is internally consistent; otherwise <see langword="false"/>.</returns>
    public bool IsWellFormed()
    {
        if (!double.IsFinite(Open) || !double.IsFinite(High) || !double.IsFinite(Low) || !double.IsFinite(Close))
        {
            return false;
        }

        if (Open <= 0.0 || High <= 0.0 || Low <= 0.0 || Close <= 0.0)
        {
            return false;
        }

        if (!double.IsFinite(Volume) || Volume < 0.0)
        {
            return false;
        }

        return High >= Math.Max(Open, Close) && Low <= Math.Min(Open, Close) && High >= Low;
    }
}
