// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the indices of the lowest and highest values over a specified period.
    /// </summary>
    /// <param name="startIdx">The start index for the calculation.</param>
    /// <param name="endIdx">The end index for the calculation.</param>
    /// <param name="inReal">The input array of real values.</param>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <param name="outBegIdx">The beginning index of the output values.</param>
    /// <param name="outNBElement">The number of elements in the output arrays.</param>
    /// <param name="outMinIdx">The output array containing the indices of the minimum values for each period.</param>
    /// <param name="outMaxIdx">The output array containing the indices of the maximum values for each period.</param>
    /// <returns>A <see cref="RetCode"/> indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The MinMaxIndex function identifies the array indices where the lowest and highest values occur 
    /// over a specified rolling period. Unlike MinMax which returns the actual values, this function 
    /// returns the positions (indices) where these extremes are found. This is particularly useful for:
    /// - Identifying when price extremes occurred
    /// - Analyzing the timing of peaks and troughs
    /// - Building more complex indicators that need position information
    /// - Backtesting strategies based on extreme value timing
    /// </remarks>
    public static RetCode MinMaxIndex(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref int[] outMinIdx,
        ref int[] outMaxIdx)
    {
        int i;
        double[]? inRealLocal = inReal;
        int optInTimePeriodLocal = optInTimePeriod;
        int[]? outMaxIdxLocal = outMaxIdx;
        int[]? outMinIdxLocal = outMinIdx;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => inRealLocal == null! || outMinIdxLocal == null! || outMaxIdxLocal == null! ? BadParam : Success,
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriodLocal)
        );
        if (validation != Success)
        {
            return validation;
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

            outMaxIdx[outIdx] = highestIdx;
            outMinIdx[outIdx] = lowestIdx;
            outIdx++;
            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period for the MinMaxIndex function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <returns>The number of elements needed before the first valid value, or -1 if the period is invalid.</returns>
    public static int MinMaxIndexLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);
    }
}
