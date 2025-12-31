// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the hyperbolic tangent of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the hyperbolic tangent of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The hyperbolic tangent function is defined as:
    /// tanh(x) = sinh(x) / cosh(x) = (e^x - e^(-x)) / (e^x + e^(-x))
    /// 
    /// Mathematical properties:
    /// - Input domain: All real numbers
    /// - Output range: (-1, 1)
    /// - tanh(0) = 0
    /// - tanh(-x) = -tanh(x) (odd function)
    /// - As x → ∞, tanh(x) → 1
    /// - As x → -∞, tanh(x) → -1
    /// 
    /// Common uses in technical analysis:
    /// - Normalizing unbounded indicators to [-1, 1] range
    /// - Creating sigmoid-like transformations
    /// - Neural network activation functions in AI-based trading
    /// - Smoothing extreme values while preserving direction
    /// - Alternative to RSI-style normalization
    /// 
    /// The S-shaped curve of tanh makes it useful for creating bounded
    /// oscillators from unbounded indicators.
    /// </remarks>
    public static RetCode Tanh(
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
            outReal[outIdx] = Math.Tanh(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Tanh calculation.
    /// </summary>
    /// <returns>Always returns 0 as hyperbolic tangent requires no historical data.</returns>
    public static int TanhLookback()
    {
        return 0;
    }
}
