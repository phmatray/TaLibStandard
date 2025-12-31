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
    /// Calculates the index of the lowest value over a specified time period (MININDEX).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the minimum value.</param>
    /// <returns>A MinIndexResult containing the indices of minimum values over each rolling window.</returns>
    /// <remarks>
    /// The MININDEX function returns the index (position) of the lowest value within a moving window
    /// of the specified time period. This is useful for identifying exactly when minimum values occurred
    /// in the data series.
    /// </remarks>
    public static MinIndexResult MinIndex(int startIdx, int endIdx, double[] real, int timePeriod = 30)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        int[] outInteger = new int[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MinIndex(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outInteger);

        return new MinIndexResult(retCode, outBegIdx, outNBElement, outInteger);
    }

    /// <summary>
    /// Calculates the index of the lowest value over a specified time period (MININDEX) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the minimum value (default: 30).</param>
    /// <returns>A MinIndexResult containing the indices of minimum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MinIndexResult MinIndex(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => MinIndex(s, e, r, timePeriod));
}
