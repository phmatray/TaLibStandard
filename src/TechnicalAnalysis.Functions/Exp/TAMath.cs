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
    /// Calculates the exponential (e raised to the power) of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>An ExpResult containing the calculated exponential values.</returns>
    /// <remarks>
    /// This function computes e^x for each element x in the input array, where e is Euler's number (approximately 2.71828).
    /// The exponential function is the inverse of the natural logarithm.
    /// Large positive input values may result in overflow, while large negative values approach zero.
    /// </remarks>
    public static ExpResult Exp(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Exp(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new ExpResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the exponential (e raised to the power) of each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">The input array of values.</param>
    /// <returns>An ExpResult containing the calculated exponential values.</returns>
    /// <remarks>
    /// This overload accepts a float array and converts it to a double array before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static ExpResult Exp(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, Exp);
}
