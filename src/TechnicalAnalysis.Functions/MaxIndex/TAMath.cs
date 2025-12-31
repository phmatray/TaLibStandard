// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the index of the highest value over a specified time period (MAXINDEX).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the maximum value.</param>
    /// <returns>A MaxIndexResult containing the indices of maximum values over each rolling window.</returns>
    /// <remarks>
    /// The MAXINDEX function returns the index (position) of the highest value within a moving window
    /// of the specified time period. This is useful for identifying exactly when maximum values occurred
    /// in the data series.
    /// </remarks>
    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        int[] outInteger = new int[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MaxIndex(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outInteger);
            
        return new MaxIndexResult(retCode, outBegIdx, outNBElement, outInteger);
    }
        
    /// <summary>
    /// Calculates the index of the highest value over a specified time period (MAXINDEX) using default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MaxIndexResult containing the indices of maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload uses a default time period of 30.
    /// </remarks>
    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real)
        => MaxIndex(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the index of the highest value over a specified time period (MAXINDEX) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the maximum value.</param>
    /// <returns>A MaxIndexResult containing the indices of maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real, int timePeriod)
        => MaxIndex(startIdx, endIdx, real.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the index of the highest value over a specified time period (MAXINDEX) using float arrays and default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MaxIndexResult containing the indices of maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// Uses a default time period of 30.
    /// </remarks>
    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real)
        => MaxIndex(startIdx, endIdx, real, 30);
}
