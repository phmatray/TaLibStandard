// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the hyperbolic sine of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the hyperbolic sine of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The hyperbolic sine function is defined as:
    /// sinh(x) = (e^x - e^(-x)) / 2
    /// 
    /// Mathematical properties:
    /// - Input domain: All real numbers
    /// - Output range: All real numbers
    /// - sinh(0) = 0
    /// - sinh(-x) = -sinh(x) (odd function)
    /// - Approximately linear near zero
    /// - Exponential growth for large positive values
    /// 
    /// Common uses in technical analysis:
    /// - Advanced mathematical transformations
    /// - Modeling exponential growth and decay
    /// - Creating indicators with asymmetric response
    /// - Options pricing with hyperbolic models
    /// - Signal transformations that preserve sign but amplify magnitude
    /// 
    /// Note: Large absolute input values may result in overflow to ±infinity.
    /// </remarks>
    public static RetCode Sinh(
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
            Math.Sinh);
    }

    /// <summary>
    /// Returns the lookback period required for Sinh calculation.
    /// </summary>
    /// <returns>Always returns 0 as hyperbolic sine requires no historical data.</returns>
    public static int SinhLookback()
    {
        return 0;
    }
}
