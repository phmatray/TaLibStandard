// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the lowest and highest values over a specified period.
    /// </summary>
    /// <param name="startIdx">The start index for the calculation.</param>
    /// <param name="endIdx">The end index for the calculation.</param>
    /// <param name="inReal">The input array of real values.</param>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <param name="outBegIdx">The beginning index of the output values.</param>
    /// <param name="outNBElement">The number of elements in the output arrays.</param>
    /// <param name="outMin">The output array containing the minimum values for each period.</param>
    /// <param name="outMax">The output array containing the maximum values for each period.</param>
    /// <returns>A <see cref="RetCode"/> indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The MinMax function identifies the lowest and highest values over a specified rolling period.
    /// This function efficiently tracks both extremes simultaneously, making it useful for:
    /// - Identifying support and resistance levels
    /// - Calculating price channels
    /// - Determining volatility ranges
    /// - Building other indicators that require min/max values
    /// </remarks>
    public static RetCode MinMax(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMin,
        ref double[] outMax)
    {
        int i;
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

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outMin == null!)
        {
            return BadParam;
        }

        if (outMax == null!)
        {
            return BadParam;
        }

        int nbInitialElementNeeded = optInTimePeriod - 1;
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int today = startIdx;
        int trailingIdx = startIdx - nbInitialElementNeeded;
        int highestIdx = -1;
        double highest = 0.0;
        int lowestIdx = -1;
        double lowest = 0.0;
        
        while (today <= endIdx)
        {
            double tmpHigh = inReal[today];
            double tmpLow = tmpHigh;
            
            if (highestIdx < trailingIdx)
            {
                highestIdx = trailingIdx;
                highest = inReal[highestIdx];
                i = highestIdx;
                while (i <= today)
                {
                    tmpHigh = inReal[i];
                    if (tmpHigh > highest)
                    {
                        highestIdx = i;
                        highest = tmpHigh;
                    }
                    i++;
                }
            }
            else if (tmpHigh >= highest)
            {
                highestIdx = today;
                highest = tmpHigh;
            }

            if (lowestIdx < trailingIdx)
            {
                lowestIdx = trailingIdx;
                lowest = inReal[lowestIdx];
                i = lowestIdx;
                while (i <= today)
                {
                    tmpLow = inReal[i];
                    if (tmpLow < lowest)
                    {
                        lowestIdx = i;
                        lowest = tmpLow;
                    }
                    i++;
                }
            }
            else if (tmpLow <= lowest)
            {
                lowestIdx = today;
                lowest = tmpLow;
            }

            outMax[outIdx] = highest;
            outMin[outIdx] = lowest;
            outIdx++;
            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period for the MinMax function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <returns>The number of elements needed before the first valid value, or -1 if the period is invalid.</returns>
    public static int MinMaxLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
