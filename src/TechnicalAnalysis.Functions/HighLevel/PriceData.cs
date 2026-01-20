// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Encapsulates price data for technical analysis operations.
/// </summary>
/// <param name="Open">Array of opening prices.</param>
/// <param name="High">Array of high prices.</param>
/// <param name="Low">Array of low prices.</param>
/// <param name="Close">Array of closing prices.</param>
/// <param name="Volume">Optional array of volume data.</param>
public record PriceData(
    double[] Open,
    double[] High,
    double[] Low,
    double[] Close,
    double[]? Volume = null)
{
    /// <summary>
    /// Gets the number of data points in the price series.
    /// </summary>
    public int Length => Close.Length;

    /// <summary>
    /// Creates a PriceData instance from closing prices only.
    /// </summary>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A PriceData instance with all OHLC values set to the closing prices.</returns>
    /// <remarks>
    /// This is useful for indicators that only require closing prices (e.g., SMA, EMA).
    /// The Open, High, and Low arrays will be set to the same values as Close.
    /// </remarks>
    public static PriceData FromClose(double[] close)
    {
        return new PriceData(close, close, close, close);
    }

    /// <summary>
    /// Creates a PriceData instance with volume data.
    /// </summary>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of volume data.</param>
    /// <returns>A PriceData instance with OHLCV data.</returns>
    public static PriceData FromOHLCV(
        double[] open,
        double[] high,
        double[] low,
        double[] close,
        double[] volume)
    {
        return new PriceData(open, high, low, close, volume);
    }

    /// <summary>
    /// Creates a PriceData instance without volume data.
    /// </summary>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A PriceData instance with OHLC data.</returns>
    public static PriceData FromOHLC(
        double[] open,
        double[] high,
        double[] low,
        double[] close)
    {
        return new PriceData(open, high, low, close);
    }
}
