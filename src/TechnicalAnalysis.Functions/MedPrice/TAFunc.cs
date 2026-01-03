// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Median Price (HL/2) - the midpoint between the high and low prices.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the Median Price values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Median Price is the simplest price transformation, representing the midpoint of the daily trading range.
    /// 
    /// Calculation:
    /// Median Price = (High + Low) / 2
    /// 
    /// Uses and characteristics:
    /// - Smooths out price action by focusing on the range midpoint
    /// - Less affected by opening and closing volatility
    /// - Often used as input for other indicators instead of close price
    /// - Represents the "fair value" within the day's range
    /// 
    /// Trading applications:
    /// - Alternative price input for moving averages and oscillators
    /// - Identifying the daily equilibrium price
    /// - Reducing noise in trend analysis
    /// - Support/resistance level identification
    /// 
    /// The Median Price is part of a family of price transformations including
    /// Typical Price (HLC/3), Weighted Close (HLCC/4), and Average Price (OHLC/4).
    /// </remarks>
    public static RetCode MedPrice(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        var inHighLocal = inHigh;
        var inLowLocal = inLow;
        var outRealLocal = outReal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, outRealLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            outReal[outIdx] = (inHigh[i] + inLow[i]) / 2.0;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Median Price calculation.
    /// </summary>
    /// <returns>Always returns 0 as Median Price requires no historical data beyond the current period.</returns>
    public static int MedPriceLookback()
    {
        return 0;
    }
}
