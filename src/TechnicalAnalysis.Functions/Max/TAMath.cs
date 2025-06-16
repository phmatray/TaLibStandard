// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the highest value over a specified time period (MAX).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the maximum value.</param>
    /// <returns>A MaxResult containing the maximum values over each rolling window.</returns>
    /// <remarks>
    /// The MAX function identifies the highest value within a moving window of the specified time period.
    /// This is useful for identifying resistance levels and tracking the upper boundaries of price movements.
    /// </remarks>
    public static MaxResult Max(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Max(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new MaxResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the highest value over a specified time period (MAX) using default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MaxResult containing the maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload uses a default time period of 30.
    /// </remarks>
    public static MaxResult Max(int startIdx, int endIdx, double[] real)
        => Max(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the highest value over a specified time period (MAX) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for finding the maximum value.</param>
    /// <returns>A MaxResult containing the maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MaxResult Max(int startIdx, int endIdx, float[] real, int timePeriod)
        => Max(startIdx, endIdx, real.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the highest value over a specified time period (MAX) using float arrays and default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MaxResult containing the maximum values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// Uses a default time period of 30.
    /// </remarks>
    public static MaxResult Max(int startIdx, int endIdx, float[] real)
        => Max(startIdx, endIdx, real, 30);
}
