// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the trigonometric cosine of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values in radians.</param>
    /// <returns>A CosResult containing the calculated cosine values.</returns>
    /// <remarks>
    /// This function computes the cosine for each element in the input array.
    /// The input values are expected to be in radians.
    /// The output values will be in the range [-1, 1].
    /// </remarks>
    public static CosResult Cos(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Cos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new CosResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the trigonometric cosine of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values in radians.</param>
    /// <returns>A CosResult containing the calculated cosine values.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static CosResult Cos(int startIdx, int endIdx, float[] real)
        => Cos(startIdx, endIdx, real.ToDouble());
}
