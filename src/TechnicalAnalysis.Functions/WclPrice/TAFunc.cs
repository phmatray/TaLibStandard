// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Weighted Close Price - a price that emphasizes the closing price.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the weighted close price values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Weighted Close Price is calculated as:
    /// WCL = (High + Low + Close + Close) / 4
    /// 
    /// This gives double weight to the closing price, making it more influential
    /// than the high and low prices of the period.
    /// 
    /// Common uses:
    /// - Alternative price input for technical indicators
    /// - Emphasizing closing price importance in analysis
    /// - Smoothing price action while maintaining close price significance
    /// - Trend identification with closing price emphasis
    /// 
    /// The weighted close is particularly useful when:
    /// - Closing price is considered most important (e.g., daily charts)
    /// - You want to reduce the impact of intraday volatility
    /// - Creating custom indicators that need close-weighted input
    /// 
    /// Compare with:
    /// - Typical Price: (H+L+C)/3 - equal weight
    /// - Average Price: (O+H+L+C)/4 - includes open
    /// - Median Price: (H+L)/2 - ignores close
    /// </remarks>
    public static RetCode WclPrice(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        var inCloseLocal = inClose;
        var inHighLocal = inHigh;
        var inLowLocal = inLow;
        var outRealLocal = outReal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, inCloseLocal, outRealLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            outReal[outIdx] = (inHigh[i] + inLow[i] + (inClose[i] * 2.0)) / 4.0;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Weighted Close Price calculation.
    /// </summary>
    /// <returns>Always returns 0 since Weighted Close Price requires no historical data.</returns>
    public static int WclPriceLookback()
    {
        return 0;
    }
}
