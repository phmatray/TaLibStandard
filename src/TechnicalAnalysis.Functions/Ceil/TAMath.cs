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
    /// Calculates the ceiling (smallest integer greater than or equal to) of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>A CeilResult containing the calculated ceiling values.</returns>
    /// <remarks>
    /// This function computes the ceiling for each element in the input array.
    /// The ceiling function rounds each value up to the nearest integer.
    /// For example: ceil(1.1) = 2, ceil(-1.1) = -1, ceil(5.0) = 5.
    /// </remarks>
    public static CeilResult Ceil(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Ceil(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new CeilResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the ceiling (smallest integer greater than or equal to) of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>A CeilResult containing the calculated ceiling values.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static CeilResult Ceil(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, Ceil);
}
