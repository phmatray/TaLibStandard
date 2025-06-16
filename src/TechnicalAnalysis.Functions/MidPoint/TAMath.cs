// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the midpoint value over a specified time period (MIDPOINT).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for calculating the midpoint.</param>
    /// <returns>A MidPointResult containing the midpoint values over each rolling window.</returns>
    /// <remarks>
    /// The MIDPOINT function calculates the midpoint between the highest and lowest values within a moving window:
    /// (Highest Value + Lowest Value) / 2. This indicator is useful for identifying the center of the price range
    /// and can be used as a simple trend-following indicator.
    /// </remarks>
    public static MidPointResult MidPoint(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MidPoint(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
        return new MidPointResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the midpoint value over a specified time period (MIDPOINT) using default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MidPointResult containing the midpoint values over each rolling window.</returns>
    /// <remarks>
    /// This overload uses a default time period of 14.
    /// </remarks>
    public static MidPointResult MidPoint(int startIdx, int endIdx, double[] real)
        => MidPoint(startIdx, endIdx, real, 14);

    /// <summary>
    /// Calculates the midpoint value over a specified time period (MIDPOINT) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="timePeriod">The number of periods to look back for calculating the midpoint.</param>
    /// <returns>A MidPointResult containing the midpoint values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MidPointResult MidPoint(int startIdx, int endIdx, float[] real, int timePeriod)
        => MidPoint(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the midpoint value over a specified time period (MIDPOINT) using float arrays and default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <returns>A MidPointResult containing the midpoint values over each rolling window.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before processing.
    /// Uses a default time period of 14.
    /// </remarks>
    public static MidPointResult MidPoint(int startIdx, int endIdx, float[] real)
        => MidPoint(startIdx, endIdx, real, 14);
}
