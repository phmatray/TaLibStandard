// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

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
    /// <param name="timePeriod">The number of periods for the moving average calculation.</param>
    /// <param name="nbDevUp">The number of standard deviations for the upper band.</param>
    /// <param name="nbDevDn">The number of standard deviations for the lower band.</param>
    /// <param name="maType">The type of moving average to use for the middle band.</param>
    /// <returns>
    /// A <see cref="BollingerBandsResult"/> object containing the upper band, middle band,
    /// lower band values, and associated metadata.
    /// </returns>
    public static BollingerBandsResult BollingerBands(
        int startIdx,
        int endIdx,
        double[] real,
        int timePeriod,
        double nbDevUp,
        double nbDevDn,
        MAType maType)
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
    /// Calculates Bollinger Bands for a price series using default parameters.
    /// </summary>
    /// <remarks>
    /// This overload uses default values: time period of 5, 2 standard deviations for both upper
    /// and lower bands, and Simple Moving Average (SMA) for the middle band. Bollinger Bands
    /// are widely used for identifying volatility and potential trading opportunities.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values (typically closing prices).</param>
    /// <returns>
    /// A <see cref="BollingerBandsResult"/> object containing the upper band, middle band,
    /// lower band values, and associated metadata.
    /// </returns>
    public static BollingerBandsResult BollingerBands(int startIdx, int endIdx, double[] real)
        => BollingerBands(startIdx, endIdx, real, 5, 2.0, 2.0, MAType.Sma);

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
    /// <param name="timePeriod">The number of periods for the moving average calculation.</param>
    /// <param name="nbDevUp">The number of standard deviations for the upper band.</param>
    /// <param name="nbDevDn">The number of standard deviations for the lower band.</param>
    /// <param name="maType">The type of moving average to use for the middle band.</param>
    /// <returns>
    /// A <see cref="BollingerBandsResult"/> object containing the upper band, middle band,
    /// lower band values, and associated metadata.
    /// </returns>
    public static BollingerBandsResult BollingerBands(
        int startIdx,
        int endIdx,
        float[] real,
        int timePeriod,
        double nbDevUp,
        double nbDevDn,
        MAType maType)
        => BollingerBands(startIdx, endIdx, real.ToDouble(), timePeriod, nbDevUp, nbDevDn, maType);
        
    /// <summary>
    /// Calculates Bollinger Bands for a price series using float arrays with default parameters.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and uses default values: time period of 5, 2 standard
    /// deviations for both bands, and Simple Moving Average. The arrays are converted to double
    /// arrays before performing the calculation.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values (typically closing prices).</param>
    /// <returns>
    /// A <see cref="BollingerBandsResult"/> object containing the upper band, middle band,
    /// lower band values, and associated metadata.
    /// </returns>
    public static BollingerBandsResult BollingerBands(int startIdx, int endIdx, float[] real)
        => BollingerBands(startIdx, endIdx, real, 5, 2.0, 2.0, MAType.Sma);
}
