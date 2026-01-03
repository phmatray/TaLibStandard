// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Moving Average Convergence Divergence (MACD) indicator.
/// </summary>
/// <remarks>
/// MACD is a trend-following momentum indicator that shows the relationship between
/// two moving averages of prices. It consists of three components: the MACD line
/// (difference between 12 and 26 period EMAs), the signal line (9 period EMA of MACD),
/// and the histogram (difference between MACD and signal line).
/// </remarks>
public record MacdResult : TripleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MacdResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="macdValue">The array of MACD line values (fast EMA - slow EMA).</param>
    /// <param name="macdSignal">The array of signal line values (EMA of MACD line).</param>
    /// <param name="macdHist">The array of histogram values (MACD line - signal line).</param>
    public MacdResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] macdValue,
        double[] macdSignal,
        double[] macdHist)
        : base(retCode, begIdx, nbElement, macdValue, macdSignal, macdHist)
    {
    }

    /// <summary>
    /// Gets the array of MACD line values.
    /// </summary>
    /// <value>
    /// An array of double values representing the MACD line, calculated as the difference
    /// between the fast EMA (typically 12 periods) and the slow EMA (typically 26 periods).
    /// </value>
    public double[] MacdValue => Real0;

    /// <summary>
    /// Gets the array of MACD histogram values.
    /// </summary>
    /// <value>
    /// An array of double values representing the MACD histogram, calculated as the difference
    /// between the MACD line and the signal line. Positive values indicate bullish momentum,
    /// while negative values indicate bearish momentum.
    /// </value>
    public double[] MacdHist => Real2;

    /// <summary>
    /// Gets the array of signal line values.
    /// </summary>
    /// <value>
    /// An array of double values representing the signal line, which is typically a 9-period
    /// EMA of the MACD line. Crossovers between the MACD line and signal line often
    /// indicate potential buy or sell signals.
    /// </value>
    public double[] MacdSignal => Real1;
}
