// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the base-10 logarithm of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values (must be positive).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the base-10 logarithm of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This function calculates:
    /// outReal[i] = log₁₀(inReal[i])
    /// 
    /// Note: Input values must be positive. Zero or negative values will result in NaN or negative infinity.
    /// 
    /// Common uses in technical analysis:
    /// - Logarithmic price scales for long-term charts
    /// - Normalizing data with exponential growth
    /// - Percent change approximations
    /// - Technical indicators on log-scale charts
    /// - Reducing the impact of outliers in price data
    /// 
    /// Log base 10 is often preferred for financial data as it's easier to interpret
    /// (e.g., a difference of 1 represents a 10x change).
    /// </remarks>
    public static RetCode Log10(
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
            outReal[outIdx] = Math.Log10(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Log10 calculation.
    /// </summary>
    /// <returns>Always returns 0 as logarithm calculation requires no historical data.</returns>
    public static int Log10Lookback()
    {
        return 0;
    }
}
