// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Performs element-wise subtraction of two input arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real0">The first input array (minuend).</param>
    /// <param name="real1">The second input array (subtrahend).</param>
    /// <returns>A SubResult containing the calculated values where each element is real0[i] - real1[i].</returns>
    /// <remarks>
    /// This function performs vector subtraction by subtracting corresponding elements of the second array from the first array.
    /// The operation is performed for each index i in the range [startIdx, endIdx].
    /// </remarks>
    public static SubResult Sub(int startIdx, int endIdx, double[] real0, double[] real1)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sub(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new SubResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Performs element-wise subtraction of two input arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real0">The first input array (minuend).</param>
    /// <param name="real1">The second input array (subtrahend).</param>
    /// <returns>A SubResult containing the calculated values where each element is real0[i] - real1[i].</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static SubResult Sub(int startIdx, int endIdx, float[] real0, float[] real1)
        => Sub(startIdx, endIdx, real0.ToDouble(), real1.ToDouble());
}
