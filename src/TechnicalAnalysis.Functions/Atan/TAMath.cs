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
    /// Calculates the arctangent (inverse tangent) of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>An AtanResult containing the calculated arctangent values in radians.</returns>
    /// <remarks>
    /// This function computes the arctangent (inverse tangent) for each element in the input array.
    /// The input values can be any real number.
    /// The output values are in radians in the range [-π/2, π/2].
    /// </remarks>
    public static AtanResult Atan(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Atan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new AtanResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the arctangent (inverse tangent) of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>An AtanResult containing the calculated arctangent values in radians.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static AtanResult Atan(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, Atan);
}
