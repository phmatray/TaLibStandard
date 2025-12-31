// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the index of the highest value over a specified period (MAXINDEX).
    /// </summary>
    /// <param name="startIdx">The start index for the calculation within the input array.</param>
    /// <param name="endIdx">The end index for the calculation within the input array.</param>
    /// <param name="inReal">The input array of real values.</param>
    /// <param name="optInTimePeriod">The time period over which to find the maximum value index. Valid range is 2 to 100000.</param>
    /// <param name="outBegIdx">The beginning index of the output values within the output array.</param>
    /// <param name="outNBElement">The number of elements to be set in the output array.</param>
    /// <param name="outInteger">The output array that will contain the indices of the maximum values for each period.</param>
    /// <returns>A <see cref="RetCode"/> indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The MAXINDEX function returns the array index location of the highest value within a rolling window.
    /// This is useful for identifying when peaks occurred in the data series.
    /// </remarks>
    public static RetCode MaxIndex(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref int[] outInteger)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        if (inReal == null! || outInteger == null!)
        {
            return BadParam;
        }

        RetCode periodCheck = ValidationHelper.ValidatePeriodRange(optInTimePeriod);
        if (periodCheck != Success)
        {
            return periodCheck;
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
        
        while (today <= endIdx)
        {
            double tmp = inReal[today];
            if (highestIdx < trailingIdx)
            {
                highestIdx = trailingIdx;
                highest = inReal[highestIdx];
                int i = highestIdx;
                while (i <= today)
                {
                    tmp = inReal[i];
                    if (tmp > highest)
                    {
                        highestIdx = i;
                        highest = tmp;
                    }
                    i++;
                }
            }
            else if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
            }

            outInteger[outIdx] = highestIdx;
            outIdx++;
            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period required for the MAXINDEX function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period over which to find the maximum value index. Valid range is 2 to 100000.</param>
    /// <returns>The number of data points required before the first valid MAXINDEX value, or -1 if the period is invalid.</returns>
    public static int MaxIndexLookback(int optInTimePeriod)
        => optInTimePeriod is < 2 or > 100000
            ? -1
            : optInTimePeriod - 1;
}
