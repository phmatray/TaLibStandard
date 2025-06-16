// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the hyperbolic sine for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the hyperbolic sine for.</param>
    /// <returns>
    /// A <see cref="SinhResult"/> containing the calculated hyperbolic sine values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The hyperbolic sine function is defined as sinh(x) = (e^x - e^(-x)) / 2.
    /// Unlike the regular sine function, sinh is not bounded and can produce values ranging from
    /// negative infinity to positive infinity. In technical analysis, hyperbolic functions are
    /// sometimes used in advanced mathematical models and transformations.
    /// </remarks>
    public static SinhResult Sinh(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sinh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new SinhResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the hyperbolic sine for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the hyperbolic sine for.</param>
    /// <returns>
    /// A <see cref="SinhResult"/> containing the calculated hyperbolic sine values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static SinhResult Sinh(int startIdx, int endIdx, float[] real)
        => Sinh(startIdx, endIdx, real.ToDouble());
}
