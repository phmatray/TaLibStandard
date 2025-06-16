// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Extended MACD indicator with configurable moving average types.
/// </summary>
/// <remarks>
/// MACD Extended allows customization of the moving average types used for calculating
/// the fast MA, slow MA, and signal line. This provides more flexibility than the
/// standard MACD which uses only exponential moving averages.
/// </remarks>
public record MacdExtResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MacdExtResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="macd">The array of MACD line values (fast MA - slow MA).</param>
    /// <param name="macdSignal">The array of signal line values (MA of MACD line).</param>
    /// <param name="macdHist">The array of histogram values (MACD line - signal line).</param>
    public MacdExtResult(
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
    /// between the fast moving average and the slow moving average using the specified MA types.
    /// </value>
    public double[] MACD { get; }

    /// <summary>
    /// Gets the array of MACD histogram values.
    /// </summary>
    /// <value>
    /// An array of double values representing the MACD histogram, calculated as the difference
    /// between the MACD line and the signal line. Used to visualize convergence and divergence.
    /// </value>
    public double[] MACDHist { get; }

    /// <summary>
    /// Gets the array of signal line values.
    /// </summary>
    /// <value>
    /// An array of double values representing the signal line, which is a moving average
    /// of the MACD line using the specified signal MA type.
    /// </value>
    public double[] MACDSignal { get; }
}
