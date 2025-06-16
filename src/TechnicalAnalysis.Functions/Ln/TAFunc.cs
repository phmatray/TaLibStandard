// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the natural logarithm (base e) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values (must be positive).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the natural logarithm of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This function calculates:
    /// outReal[i] = ln(inReal[i])
    /// 
    /// Note: Input values must be positive. Zero or negative values will result in NaN or negative infinity.
    /// 
    /// Common uses in technical analysis:
    /// - Log returns calculation: ln(Price[t] / Price[t-1])
    /// - Normalizing exponentially growing data
    /// - Volatility calculations using log returns
    /// - Option pricing models (Black-Scholes)
    /// - Converting multiplicative processes to additive
    /// 
    /// Natural log is preferred in finance because log returns can be
    /// summed to get cumulative returns and have better statistical properties.
    /// </remarks>
    public static RetCode Ln(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null!)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = Math.Log(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for natural logarithm calculation.
    /// </summary>
    /// <returns>Always returns 0 as logarithm calculation requires no historical data.</returns>
    public static int LnLookback()
    {
        return 0;
    }
}
