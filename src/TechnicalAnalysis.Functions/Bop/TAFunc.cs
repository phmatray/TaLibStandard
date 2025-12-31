// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Balance of Power (BOP) - an indicator measuring the strength of buyers vs sellers.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inOpen">Input array of opening prices.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the BOP values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Balance of Power measures the ability of buyers and sellers to push prices to extreme levels.
    /// 
    /// Calculation:
    /// BOP = (Close - Open) / (High - Low)
    /// 
    /// Values range from -1 to +1:
    /// - Values near +1: Strong buying pressure (bulls in control)
    /// - Values near -1: Strong selling pressure (bears in control)
    /// - Values near 0: Balance between buyers and sellers
    /// 
    /// Trading signals:
    /// - Positive BOP: Buyers are winning the battle
    /// - Negative BOP: Sellers are winning the battle
    /// - BOP crossing zero: Potential trend change
    /// - Divergence with price: Potential reversal signal
    /// 
    /// Note: When High equals Low (no range), BOP is set to 0 to avoid division by zero.
    /// </remarks>
    public static RetCode Bop(
        int startIdx,
        int endIdx,
        in double[] inOpen,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inOpen, inHigh, inLow, inClose, outReal);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            double tempReal = inHigh[i] - inLow[i];
            if (tempReal < 1E-08)
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = (inClose[i] - inOpen[i]) / tempReal;
                outIdx++;
            }
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Balance of Power calculation.
    /// </summary>
    /// <returns>Always returns 0 as BOP requires no historical data beyond the current period.</returns>
    public static int BopLookback()
    {
        return 0;
    }
}
