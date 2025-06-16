// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

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
    public static SumResult Sum(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new SumResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the summation of values over a specified time period (SUM) using default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A SumResult containing the sum values over each rolling window.</returns>
    /// <remarks>
    /// This overload uses a default time period of 30.
    /// </remarks>
    public static SumResult Sum(int startIdx, int endIdx, double[] real)
        => Sum(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the summation of values over a specified time period (SUM) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to sum.</param>
    /// <returns>A SumResult containing the sum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static SumResult Sum(int startIdx, int endIdx, float[] real, int timePeriod)
        => Sum(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the summation of values over a specified time period (SUM) using float arrays and default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A SumResult containing the sum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// Uses a default time period of 30.
    /// </remarks>
    public static SumResult Sum(int startIdx, int endIdx, float[] real)
        => Sum(startIdx, endIdx, real, 30);
}
