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
    /// Calculates both the lowest and highest values over a specified time period (MINMAX).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the minimum and maximum values (default: 30).</param>
    /// <returns>A MinMaxResult containing both the minimum and maximum values over each rolling window.</returns>
    /// <remarks>
    /// The MINMAX function efficiently calculates both the minimum and maximum values within a moving window
    /// in a single pass. This is useful for identifying price ranges and volatility over the specified period.
    /// </remarks>
    public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real, int timePeriod = 30)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outMin = new double[endIdx - startIdx + 1];
        double[] outMax = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MinMax(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMin,
            ref outMax);
            
        return new MinMaxResult(retCode, outBegIdx, outNBElement, outMin, outMax);
    }

    /// <summary>
    /// Calculates both the lowest and highest values over a specified time period (MINMAX) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the minimum and maximum values (default: 30).</param>
    /// <returns>A MinMaxResult containing both the minimum and maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => MinMax(s, e, r, timePeriod));
}
