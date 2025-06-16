// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the indices of both the lowest and highest values over a specified time period (MINMAXINDEX).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the minimum and maximum values.</param>
    /// <returns>A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window.</returns>
    /// <remarks>
    /// The MINMAXINDEX function returns the indices (positions) of both the lowest and highest values within
    /// a moving window in a single pass. This is useful for identifying exactly when extreme values occurred
    /// in the data series.
    /// </remarks>
    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        int[] outMinIdx = new int[endIdx - startIdx + 1];
        int[] outMaxIdx = new int[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MinMaxIndex(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMinIdx,
            ref outMaxIdx);
            
        return new MinMaxIndexResult(retCode, outBegIdx, outNBElement, outMinIdx, outMaxIdx);
    }
        
    /// <summary>
    /// Calculates the indices of both the lowest and highest values over a specified time period (MINMAXINDEX) using default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload uses a default time period of 30.
    /// </remarks>
    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, double[] real)
        => MinMaxIndex(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the indices of both the lowest and highest values over a specified time period (MINMAXINDEX) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the minimum and maximum values.</param>
    /// <returns>A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, float[] real, int timePeriod)
        => MinMaxIndex(startIdx, endIdx, real.ToDouble(), timePeriod);        

    /// <summary>
    /// Calculates the indices of both the lowest and highest values over a specified time period (MINMAXINDEX) using float arrays and default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// Uses a default time period of 30.
    /// </remarks>
    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, float[] real)
        => MinMaxIndex(startIdx, endIdx, real, 30);
}
