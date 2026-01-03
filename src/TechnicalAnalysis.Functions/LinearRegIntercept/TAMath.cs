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
    /// Calculates the Linear Regression Intercept for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A LinearRegInterceptResult containing the calculated intercept values.</returns>
    /// <remarks>
    /// Linear Regression Intercept calculates the y-intercept of the linear regression line 
    /// for the specified period. This represents where the regression line would intersect 
    /// the y-axis if extended. It's useful for identifying the baseline value of the trend.
    /// </remarks>
    public static LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, double[] real, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.LinearRegIntercept(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new LinearRegInterceptResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Linear Regression Intercept for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A LinearRegInterceptResult containing the calculated intercept values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, float[] real, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => LinearRegIntercept(s, e, r, timePeriod));
}
