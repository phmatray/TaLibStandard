// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the square root of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values (must be non-negative).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the square root of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This function calculates:
    /// outReal[i] = √(inReal[i])
    /// 
    /// Note: Negative input values will result in NaN (Not a Number) in the output.
    /// 
    /// Common uses in technical analysis:
    /// - Volatility calculations (square root of variance)
    /// - Normalizing quadratic relationships
    /// - Standard deviation and related calculations
    /// - Risk metrics (square root of time scaling)
    /// - Options pricing models (square root of time to expiration)
    /// </remarks>
    public static RetCode Sqrt(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal);
        if (validationResult != Success)
        {
            return validationResult;
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = Math.Sqrt(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Sqrt calculation.
    /// </summary>
    /// <returns>Always returns 0 as square root calculation requires no historical data.</returns>
    public static int SqrtLookback()
    {
        return 0;
    }
}
