// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Functions.Internal;

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates Bollinger Bands for a price series.
    /// </summary>
    /// <remarks>
    /// Bollinger Bands are a volatility indicator consisting of three lines: a middle band (moving average),
    /// an upper band (middle band + n standard deviations), and a lower band (middle band - n standard deviations).
    /// The bands expand during periods of high volatility and contract during periods of low volatility.
    /// They are commonly used to identify overbought/oversold conditions and potential support/resistance levels.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the moving average calculation (default: 5).</param>
    /// <param name="nbDevUp">The number of standard deviations for the upper band (default: 2.0).</param>
    /// <param name="nbDevDn">The number of standard deviations for the lower band (default: 2.0).</param>
    /// <param name="maType">The type of moving average to use for the middle band (default: SMA).</param>
    /// <returns>
    /// A <see cref="BollingerBandsResult"/> object containing the upper band, middle band,
    /// lower band values, and associated metadata.
    /// </returns>
    public static BollingerBandsResult BollingerBands(
        int startIdx,
        int endIdx,
        double[] real,
        int timePeriod = 5,
        double nbDevUp = 2.0,
        double nbDevDn = 2.0,
        MAType maType = MAType.Sma)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outRealUpperBand = new double[endIdx - startIdx + 1];
        double[] outRealMiddleBand = new double[endIdx - startIdx + 1];
        double[] outRealLowerBand = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.BollingerBands(
            startIdx,
            endIdx,
            real,
            timePeriod,
            nbDevUp,
            nbDevDn,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outRealUpperBand,
            ref outRealMiddleBand,
            ref outRealLowerBand);
            
        return new BollingerBandsResult(
            retCode,
            outBegIdx,
            outNBElement,
            outRealUpperBand,
            outRealMiddleBand,
            outRealLowerBand);
    }

    /// <summary>
    /// Calculates Bollinger Bands for a price series using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// Bollinger Bands are a popular technical indicator for measuring volatility and identifying
    /// potential support and resistance levels.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the moving average calculation (default: 5).</param>
    /// <param name="nbDevUp">The number of standard deviations for the upper band (default: 2.0).</param>
    /// <param name="nbDevDn">The number of standard deviations for the lower band (default: 2.0).</param>
    /// <param name="maType">The type of moving average to use for the middle band (default: SMA).</param>
    /// <returns>
    /// A <see cref="BollingerBandsResult"/> object containing the upper band, middle band,
    /// lower band values, and associated metadata.
    /// </returns>
    public static BollingerBandsResult BollingerBands(
        int startIdx,
        int endIdx,
        float[] real,
        int timePeriod = 5,
        double nbDevUp = 2.0,
        double nbDevDn = 2.0,
        MAType maType = MAType.Sma)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => BollingerBands(s, e, r, timePeriod, nbDevUp, nbDevDn, maType));
}
