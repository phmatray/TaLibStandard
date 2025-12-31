// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the vector floor function for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the floor for.</param>
    /// <returns>
    /// A <see cref="FloorResult"/> containing the calculated floor values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The floor function returns the largest integer less than or equal to each value in the input array.
    /// For example, floor(2.8) returns 2.0, and floor(-2.3) returns -3.0.
    /// This is useful for rounding down values to the nearest integer in technical analysis calculations.
    /// </remarks>
    public static FloorResult Floor(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Floor(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
        return new FloorResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the vector floor function for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the floor for.</param>
    /// <returns>
    /// A <see cref="FloorResult"/> containing the calculated floor values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static FloorResult Floor(int startIdx, int endIdx, float[] real)
        => Floor(startIdx, endIdx, real.ToDouble());
}
