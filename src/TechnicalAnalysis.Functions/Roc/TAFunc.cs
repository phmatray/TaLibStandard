// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Rate of Change (ROC) - a momentum oscillator that measures percentage price change.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods to look back. Typical values: 9, 12, 25.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the ROC values (as percentages).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// ROC is calculated as:
    /// ROC = ((Price(today) / Price(N periods ago)) - 1) × 100
    /// 
    /// Interpretation:
    /// - Positive values indicate price is higher than N periods ago
    /// - Negative values indicate price is lower than N periods ago
    /// - Zero line represents no change
    /// - Extreme readings may indicate overbought/oversold conditions
    /// 
    /// ROC oscillates around zero and is expressed as a percentage.
    /// Unlike momentum, ROC normalizes the price change, making it
    /// easier to compare across different securities or time periods.
    /// </remarks>
    public static RetCode Roc(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        if (startIdx < optInTimePeriod)
        {
            startIdx = optInTimePeriod;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int inIdx = startIdx;
        int trailingIdx = startIdx - optInTimePeriod;
        while (true)
        {
            if (inIdx > endIdx)
            {
                break;
            }

            double tempReal = inReal[trailingIdx];
            trailingIdx++;
            if (tempReal != 0.0)
            {
                outReal[outIdx] = ((inReal[inIdx] / tempReal) - 1.0) * 100.0;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            inIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for ROC calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods to look back. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid ROC value can be calculated, or -1 if parameters are invalid.</returns>
    public static int RocLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : optInTimePeriod;
    }
}
