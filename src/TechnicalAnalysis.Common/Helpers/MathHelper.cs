// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Provides helper methods for mathematical function indicators.
/// </summary>
/// <remarks>
/// This helper class consolidates the common boilerplate code used by simple
/// mathematical transformation indicators (Sin, Cos, Sqrt, Exp, etc.) that apply
/// a single mathematical function to each input element without requiring historical data.
/// </remarks>
public static class MathHelper
{
    /// <summary>
    /// Applies a mathematical function element-wise to an input array.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the transformed values.</param>
    /// <param name="mathFunction">The mathematical function to apply to each element.</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if the calculation succeeds;
    /// appropriate error code otherwise.
    /// </returns>
    /// <remarks>
    /// This method provides a generic template for mathematical transformation indicators
    /// that don't require historical data (lookback period = 0). It handles:
    /// - Index range validation
    /// - Array null checking
    /// - Element-wise function application
    /// - Output parameter setup
    ///
    /// Example usage:
    /// <code>
    /// public static RetCode Sin(...) =>
    ///     MathHelper.ApplyMathFunction(startIdx, endIdx, inReal,
    ///         ref outBegIdx, ref outNBElement, ref outReal, Math.Sin);
    /// </code>
    ///
    /// This pattern reduces code duplication across 15+ mathematical function indicators.
    /// </remarks>
    public static RetCode ApplyMathFunction(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal,
        Func<double, double> mathFunction)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal);
        if (validationResult != Success)
        {
            return validationResult;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            outReal[outIdx] = mathFunction(inReal[i]);
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }
}
