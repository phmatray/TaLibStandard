// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Average Price - the mean of open, high, low, and close prices.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inOpen">Input array of opening prices.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the Average Price values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Average Price provides a single value representation of price action for each period.
    /// 
    /// Calculation:
    /// Average Price = (Open + High + Low + Close) / 4
    /// 
    /// Uses:
    /// - Price smoothing: Reduces noise compared to using close price alone
    /// - Support/Resistance: Can act as dynamic support/resistance levels
    /// - Trend confirmation: Price above/below average price confirms trend direction
    /// - Input for other indicators: Used as input for moving averages or oscillators
    /// 
    /// The Average Price is also known as the "Typical Price" when calculated as (High + Low + Close) / 3,
    /// but this implementation uses all four price points for a more comprehensive average.
    /// </remarks>
    public static RetCode AvgPrice(
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
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inOpen, inHigh, inLow, inClose, outReal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            outReal[outIdx] = (inHigh[i] + inLow[i] + inClose[i] + inOpen[i]) / 4.0;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Average Price calculation.
    /// </summary>
    /// <returns>Always returns 0 as Average Price requires no historical data beyond the current period.</returns>
    public static int AvgPriceLookback()
    {
        return 0;
    }
}
