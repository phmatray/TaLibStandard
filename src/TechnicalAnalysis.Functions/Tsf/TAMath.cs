// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Time Series Forecast (TSF) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the linear regression (default: 14).</param>
    /// <returns>A TsfResult object containing the calculated values.</returns>
    /// <remarks>
    /// The Time Series Forecast indicator is a linear regression calculation that plots the statistical trend of a security's price over time.
    /// It uses the least squares method to fit a straight line to the data for the selected period and then projects that line forward.
    /// TSF can be used to identify the underlying trend and potential support/resistance levels.
    /// The indicator attempts to predict future values based on historical linear regression analysis.
    /// </remarks>
    public static TsfResult Tsf(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Tsf(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TsfResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Time Series Forecast (TSF) indicator using the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A TsfResult object containing the calculated values.</returns>
    /// <remarks>Uses the default time period of 14.</remarks>
    public static TsfResult Tsf(int startIdx, int endIdx, double[] real)
        => Tsf(startIdx, endIdx, real, 14);

    /// <summary>
    /// Calculates the Time Series Forecast (TSF) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the linear regression.</param>
    /// <returns>A TsfResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static TsfResult Tsf(int startIdx, int endIdx, float[] real, int timePeriod)
        => Tsf(startIdx, endIdx, real.ToDouble(), timePeriod);
            
    /// <summary>
    /// Calculates the Time Series Forecast (TSF) indicator using float arrays and the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A TsfResult object containing the calculated values.</returns>
    /// <remarks>
    /// Uses the default time period of 14. This overload accepts float arrays and converts them to double arrays.
    /// </remarks>
    public static TsfResult Tsf(int startIdx, int endIdx, float[] real)
        => Tsf(startIdx, endIdx, real, 14);
}
