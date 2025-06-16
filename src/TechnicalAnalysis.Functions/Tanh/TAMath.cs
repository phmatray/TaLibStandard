// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the hyperbolic tangent for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the hyperbolic tangent for.</param>
    /// <returns>
    /// A <see cref="TanhResult"/> containing the calculated hyperbolic tangent values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The hyperbolic tangent function is defined as tanh(x) = sinh(x) / cosh(x) = (e^x - e^(-x)) / (e^x + e^(-x)).
    /// Unlike the regular tangent function, tanh is bounded and returns values in the range [-1, 1].
    /// This makes it useful as a normalization function in technical analysis and is commonly used
    /// in neural networks and other machine learning applications for trading systems.
    /// </remarks>
    public static TanhResult Tanh(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Tanh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TanhResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the hyperbolic tangent for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values to calculate the hyperbolic tangent for.</param>
    /// <returns>
    /// A <see cref="TanhResult"/> containing the calculated hyperbolic tangent values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static TanhResult Tanh(int startIdx, int endIdx, float[] real)
        => Tanh(startIdx, endIdx, real.ToDouble());
}
