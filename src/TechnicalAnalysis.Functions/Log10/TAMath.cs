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
    /// Calculates the base-10 logarithm for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the base-10 logarithm for.</param>
    /// <returns>
    /// A <see cref="Log10Result"/> containing the calculated base-10 logarithm values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The base-10 logarithm (common logarithm) is frequently used in finance and technical analysis
    /// for scaling data and analyzing order of magnitude changes. For example, log10(100) = 2 and log10(1000) = 3.
    /// This function is undefined for negative values and zero, which may result in NaN or negative infinity.
    /// </remarks>
    public static Log10Result Log10(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Log10(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new Log10Result(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the base-10 logarithm for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the base-10 logarithm for.</param>
    /// <returns>
    /// A <see cref="Log10Result"/> containing the calculated base-10 logarithm values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static Log10Result Log10(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, Log10);
}
