// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the floor (largest integer less than or equal to) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the floor of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The floor function rounds down to the nearest integer:
    /// - floor(4.1) = 4
    /// - floor(4.9) = 4
    /// - floor(5.0) = 5
    /// - floor(-4.1) = -5
    /// - floor(-4.9) = -5
    /// 
    /// Common uses in technical analysis:
    /// - Rounding down price levels for support calculations
    /// - Creating discrete trading levels from continuous prices
    /// - Position sizing (round down to stay within capital limits)
    /// - Calculating whole number profit targets
    /// - Grid trading level calculations
    /// - Converting fractional shares to whole lots
    /// 
    /// Floor is often used when you need conservative estimates
    /// or when dealing with discrete units that cannot be fractional.
    /// </remarks>
    public static RetCode Floor(
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
            outReal[outIdx] = Math.Floor(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Floor calculation.
    /// </summary>
    /// <returns>Always returns 0 as floor requires no historical data.</returns>
    public static int FloorLookback()
    {
        return 0;
    }
}
