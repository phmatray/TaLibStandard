// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the square root for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the square root for.</param>
    /// <returns>
    /// A <see cref="SqrtResult"/> containing the calculated square root values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The square root function returns the positive square root of each input value.
    /// This function is undefined for negative values, which will result in NaN.
    /// In technical analysis, square roots are commonly used in volatility calculations,
    /// such as in the calculation of standard deviation and related indicators.
    /// </remarks>
    public static SqrtResult Sqrt(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sqrt(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new SqrtResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the square root for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the square root for.</param>
    /// <returns>
    /// A <see cref="SqrtResult"/> containing the calculated square root values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static SqrtResult Sqrt(int startIdx, int endIdx, float[] real)
        => Sqrt(startIdx, endIdx, real.ToDouble());
}
