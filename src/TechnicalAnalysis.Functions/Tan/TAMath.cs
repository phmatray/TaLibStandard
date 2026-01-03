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
    /// Calculates the trigonometric tangent for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (in radians) to calculate the tangent for.</param>
    /// <returns>
    /// A <see cref="TanResult"/> containing the calculated tangent values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The tangent function takes input values in radians and is defined as tan(x) = sin(x) / cos(x).
    /// The function is undefined at odd multiples of π/2 (90°, 270°, etc.) where it approaches infinity.
    /// In technical analysis, tangent functions may be used in advanced cycle analysis and angular calculations.
    /// To convert degrees to radians, multiply by π/180.
    /// </remarks>
    public static TanResult Tan(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Tan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TanResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the trigonometric tangent for each element in the input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (in radians) to calculate the tangent for.</param>
    /// <returns>
    /// A <see cref="TanResult"/> containing the calculated tangent values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static TanResult Tan(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, Tan);
}
