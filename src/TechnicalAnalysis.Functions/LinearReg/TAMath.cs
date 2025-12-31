// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Linear Regression (LINEARREG) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the linear regression (default: 14).</param>
    /// <returns>A LinearRegResult object containing the calculated values.</returns>
    /// <remarks>
    /// Linear Regression uses the least squares method to fit a straight line through the price data
    /// over the specified period. The indicator returns the endpoint value of the linear regression line.
    /// This can be used to identify the underlying trend direction and strength.
    /// The indicator is similar to a moving average but with less lag, as it projects the current trend forward.
    /// </remarks>
    public static LinearRegResult LinearReg(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.LinearReg(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new LinearRegResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates the Linear Regression (LINEARREG) indicator using the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A LinearRegResult object containing the calculated values.</returns>
    /// <remarks>Uses the default time period of 14.</remarks>
    public static LinearRegResult LinearReg(int startIdx, int endIdx, double[] real)
        => LinearReg(startIdx, endIdx, real, 14);

    /// <summary>
    /// Calculates the Linear Regression (LINEARREG) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the linear regression.</param>
    /// <returns>A LinearRegResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static LinearRegResult LinearReg(int startIdx, int endIdx, float[] real, int timePeriod)
        => LinearReg(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Linear Regression (LINEARREG) indicator using float arrays and the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A LinearRegResult object containing the calculated values.</returns>
    /// <remarks>
    /// Uses the default time period of 14. This overload accepts float arrays and converts them to double arrays.
    /// </remarks>
    public static LinearRegResult LinearReg(int startIdx, int endIdx, float[] real)
        => LinearReg(startIdx, endIdx, real, 14);
}
