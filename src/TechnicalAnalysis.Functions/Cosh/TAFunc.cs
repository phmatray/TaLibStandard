// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the hyperbolic cosine of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the hyperbolic cosine of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The hyperbolic cosine function is defined as:
    /// cosh(x) = (e^x + e^(-x)) / 2
    /// 
    /// Mathematical properties:
    /// - Input domain: All real numbers
    /// - Output range: [1, ∞)
    /// - cosh(0) = 1
    /// - cosh(x) = cosh(-x) (even function)
    /// - Always returns values ≥ 1
    /// 
    /// Common uses in technical analysis:
    /// - Advanced mathematical transformations
    /// - Exponential smoothing calculations
    /// - Volatility modeling with exponential characteristics
    /// - Options pricing models with hyperbolic functions
    /// - Creating custom indicators with exponential growth patterns
    /// 
    /// Note: Large absolute input values may result in overflow to infinity.
    /// </remarks>
    public static RetCode Cosh(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        return MathHelper.ApplyMathFunction(
            startIdx,
            endIdx,
            inReal,
            ref outBegIdx,
            ref outNBElement,
            ref outReal,
            Math.Cosh);
    }

    /// <summary>
    /// Returns the lookback period required for Cosh calculation.
    /// </summary>
    /// <returns>Always returns 0 as hyperbolic cosine requires no historical data.</returns>
    public static int CoshLookback()
    {
        return 0;
    }
}
