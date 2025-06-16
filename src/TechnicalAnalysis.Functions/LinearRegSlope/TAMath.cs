// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Linear Regression Slope for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A LinearRegSlopeResult containing the calculated slope values.</returns>
    /// <remarks>
    /// Linear Regression Slope calculates the slope of the linear regression line for the 
    /// specified period. The slope indicates the rate of change in the trend - positive 
    /// values indicate an upward trend, negative values indicate a downward trend, and 
    /// the magnitude indicates the strength of the trend.
    /// </remarks>
    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.LinearRegSlope(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new LinearRegSlopeResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Linear Regression Slope using default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>A LinearRegSlopeResult containing the calculated slope values.</returns>
    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, double[] real)
        => LinearRegSlope(startIdx, endIdx, real, 14);

    /// <summary>
    /// Calculates the Linear Regression Slope for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>A LinearRegSlopeResult containing the calculated slope values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, float[] real, int timePeriod)
        => LinearRegSlope(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Linear Regression Slope using default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>A LinearRegSlopeResult containing the calculated slope values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, float[] real)
        => LinearRegSlope(startIdx, endIdx, real, 14);
}
