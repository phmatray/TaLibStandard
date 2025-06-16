// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the MACD Fix indicator with fixed 12/26 periods.
/// </summary>
/// <remarks>
/// MACD Fix uses the standard fixed periods of 12 and 26 for the fast and slow EMAs,
/// with a customizable signal period. This is a variation of the MACD indicator that
/// maintains the traditional period settings while allowing signal line customization.
/// </remarks>
public record MacdFixResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MacdFixResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="macd">The array of MACD line values (12 EMA - 26 EMA).</param>
    /// <param name="macdSignal">The array of signal line values (EMA of MACD line).</param>
    /// <param name="macdHist">The array of histogram values (MACD line - signal line).</param>
    public MacdFixResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] macd,
        double[] macdSignal,
        double[] macdHist)
        : base(retCode, begIdx, nbElement)
    {
        MACD = macd;
        MACDSignal = macdSignal;
        MACDHist = macdHist;
    }

    /// <summary>
    /// Gets the array of MACD line values.
    /// </summary>
    /// <value>
    /// An array of double values representing the MACD line, calculated as the difference
    /// between the 12-period EMA and the 26-period EMA.
    /// </value>
    public double[] MACD { get; }

    /// <summary>
    /// Gets the array of MACD histogram values.
    /// </summary>
    /// <value>
    /// An array of double values representing the MACD histogram, showing the difference
    /// between the MACD line and the signal line as a bar chart visualization.
    /// </value>
    public double[] MACDHist { get; }

    /// <summary>
    /// Gets the array of signal line values.
    /// </summary>
    /// <value>
    /// An array of double values representing the signal line, which is an EMA
    /// of the MACD line with a customizable period.
    /// </value>
    public double[] MACDSignal { get; }
}
