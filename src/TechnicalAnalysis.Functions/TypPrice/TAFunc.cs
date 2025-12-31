// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Typical Price - the average of high, low, and close prices.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the typical price values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Typical Price is calculated as:
    /// TP = (High + Low + Close) / 3
    /// 
    /// This represents the average price of a period and is often considered
    /// more representative than just the closing price.
    /// 
    /// Common uses:
    /// - Base calculation for many other indicators (e.g., CCI, Money Flow)
    /// - Pivot point calculations
    /// - Alternative to closing price for moving averages
    /// - Volume-weighted price analysis
    /// 
    /// Advantages over closing price:
    /// - Incorporates the full trading range
    /// - Less susceptible to end-of-period manipulation
    /// - Smoother representation of price action
    /// - Better reflects the period's trading activity
    /// 
    /// The typical price is particularly useful in sideways markets where
    /// the closing price alone might not capture the period's price action.
    /// </remarks>
    public static RetCode TypPrice(
        int startIdx,
        int endIdx,
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

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outReal);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            outReal[outIdx] = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Typical Price calculation.
    /// </summary>
    /// <returns>Always returns 0 since Typical Price requires no historical data.</returns>
    public static int TypPriceLookback()
    {
        return 0;
    }
}
