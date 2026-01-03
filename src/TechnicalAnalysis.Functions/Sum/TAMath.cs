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
    /// Calculates the summation of values over a specified time period (SUM).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to sum.</param>
    /// <returns>A SumResult containing the sum values over each rolling window.</returns>
    /// <remarks>
    /// The SUM function calculates the total sum of values within a moving window of the specified time period.
    /// This is a fundamental calculation used in many other indicators and can help identify cumulative trends
    /// or total volume/value over specific periods.
    /// </remarks>
    public static SumResult Sum(int startIdx, int endIdx, double[] real, int timePeriod = 30)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);

        return new SumResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the summation of values over a specified time period (SUM) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to sum. Default is 30.</param>
    /// <returns>A SumResult containing the sum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static SumResult Sum(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => Sum(s, e, r, timePeriod));
}
