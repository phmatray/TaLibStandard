// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Performs element-wise division of two input arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real0">The first input array (dividend).</param>
    /// <param name="real1">The second input array (divisor).</param>
    /// <returns>A DivResult containing the calculated values where each element is real0[i] / real1[i].</returns>
    /// <remarks>
    /// This function performs vector division by dividing corresponding elements of the first array by the second array.
    /// The operation is performed for each index i in the range [startIdx, endIdx].
    /// Division by zero will result in infinity or NaN values according to IEEE 754 standards.
    /// </remarks>
    public static DivResult Div(int startIdx, int endIdx, double[] real0, double[] real1)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Div(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new DivResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Performs element-wise division of two input arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real0">The first input array (dividend).</param>
    /// <param name="real1">The second input array (divisor).</param>
    /// <returns>A DivResult containing the calculated values where each element is real0[i] / real1[i].</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static DivResult Div(int startIdx, int endIdx, float[] real0, float[] real1)
        => Div(startIdx, endIdx, real0.ToDouble(), real1.ToDouble());
}
