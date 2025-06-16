// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the ceiling (smallest integer greater than or equal to) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the ceiling of each input value.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The ceiling function rounds up to the nearest integer:
    /// - ceil(4.1) = 5
    /// - ceil(4.9) = 5
    /// - ceil(5.0) = 5
    /// - ceil(-4.1) = -4
    /// - ceil(-4.9) = -4
    /// 
    /// Common uses in technical analysis:
    /// - Rounding up price levels for resistance calculations
    /// - Setting minimum tick sizes or lot sizes
    /// - Creating discrete levels from continuous indicators
    /// - Position sizing (always round up to ensure sufficient capital)
    /// - Grid trading level calculations
    /// - Stop loss and take profit level adjustments
    /// 
    /// Ceiling is often used when you need to ensure values meet
    /// minimum requirements or when creating price grids.
    /// </remarks>
    public static RetCode Ceil(
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
            outReal[outIdx] = Math.Ceiling(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Ceil calculation.
    /// </summary>
    /// <returns>Always returns 0 as ceiling requires no historical data.</returns>
    public static int CeilLookback()
    {
        return 0;
    }
}
