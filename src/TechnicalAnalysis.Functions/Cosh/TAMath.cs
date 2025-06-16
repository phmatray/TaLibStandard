// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the hyperbolic cosine of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>A CoshResult containing the calculated hyperbolic cosine values.</returns>
    /// <remarks>
    /// This function computes the hyperbolic cosine for each element in the input array.
    /// The hyperbolic cosine is defined as cosh(x) = (e^x + e^-x) / 2.
    /// The output values are always greater than or equal to 1.
    /// Large input values may result in overflow.
    /// </remarks>
    public static CoshResult Cosh(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Cosh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new CoshResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the hyperbolic cosine of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>A CoshResult containing the calculated hyperbolic cosine values.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static CoshResult Cosh(int startIdx, int endIdx, float[] real)
        => Cosh(startIdx, endIdx, real.ToDouble());
}
