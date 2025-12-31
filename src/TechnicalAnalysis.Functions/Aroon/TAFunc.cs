// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Aroon indicator - identifies trend changes and measures trend strength.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Typical value: 25.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outAroonDown">Output array for Aroon Down values.</param>
    /// <param name="outAroonUp">Output array for Aroon Up values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Aroon measures the time since the most recent high/low within the lookback period.
    /// 
    /// Calculation:
    /// - Aroon Up = ((Period - Days Since Period High) / Period) * 100
    /// - Aroon Down = ((Period - Days Since Period Low) / Period) * 100
    /// 
    /// Values range from 0 to 100:
    /// - Aroon Up near 100: Strong uptrend (recent new highs)
    /// - Aroon Down near 100: Strong downtrend (recent new lows)
    /// - Both near 50: No clear trend
    /// 
    /// Trading signals:
    /// - Aroon Up crosses above Aroon Down: Bullish signal
    /// - Aroon Down crosses above Aroon Up: Bearish signal
    /// - Either line above 70: Strong trend in that direction
    /// - Either line below 30: Weak trend in that direction
    /// </remarks>
    public static RetCode Aroon(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outAroonDown,
        ref double[] outAroonUp)
    {
        int i;
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inHigh, inLow, outAroonDown, outAroonUp);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        RetCode periodCheck = ValidationHelper.ValidatePeriodRange(optInTimePeriod);
        if (periodCheck != Success)
        {
            return periodCheck;
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
        int today = startIdx;
        int trailingIdx = startIdx - optInTimePeriod;
        int lowestIdx = -1;
        int highestIdx = -1;
        double lowest = 0.0;
        double highest = 0.0;
        double factor = 100.0 / optInTimePeriod;
        
        while (today <= endIdx)
        {
            double tmp = inLow[today];
            
            // Update lowest value and index
            if (lowestIdx < trailingIdx)
            {
                lowestIdx = trailingIdx;
                lowest = inLow[lowestIdx];
                for (i = lowestIdx + 1; i <= today; i++)
                {
                    tmp = inLow[i];
                    if (tmp <= lowest)
                    {
                        lowestIdx = i;
                        lowest = tmp;
                    }
                }
            }
            else if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
            }

            // Update highest value and index
            tmp = inHigh[today];
            if (highestIdx < trailingIdx)
            {
                highestIdx = trailingIdx;
                highest = inHigh[highestIdx];
                for (i = highestIdx + 1; i <= today; i++)
                {
                    tmp = inHigh[i];
                    if (tmp >= highest)
                    {
                        highestIdx = i;
                        highest = tmp;
                    }
                }
            }
            else if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
            }

            // Calculate Aroon values
            outAroonUp[outIdx] = factor * (optInTimePeriod - (today - highestIdx));
            outAroonDown[outIdx] = factor * (optInTimePeriod - (today - lowestIdx));
            
            outIdx++;
            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Aroon calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Aroon values can be calculated, or -1 if parameters are invalid.</returns>
    public static int AroonLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod;
    }
}
