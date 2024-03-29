// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
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
        Label_00A5:
        if (today > endIdx)
        {
            outBegIdx = startIdx;
            outNBElement = outIdx;
            return Success;
        }

        double tmpHigh = inReal[today];
        double tmpLow = tmpHigh;
        if (highestIdx < trailingIdx)
        {
            highestIdx = trailingIdx;
            highest = inReal[highestIdx];
            i = highestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_00EC;
                }

                tmpHigh = inReal[i];
                if (tmpHigh > highest)
                {
                    highestIdx = i;
                    highest = tmpHigh;
                }
            }
        }

        if (tmpHigh >= highest)
        {
            highestIdx = today;
            highest = tmpHigh;
        }

        Label_00EC:
        if (lowestIdx < trailingIdx)
        {
            lowestIdx = trailingIdx;
            lowest = inReal[lowestIdx];
            i = lowestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_012A;
                }

                tmpLow = inReal[i];
                if (tmpLow < lowest)
                {
                    lowestIdx = i;
                    lowest = tmpLow;
                }
            }
        }

        if (tmpLow <= lowest)
        {
            lowestIdx = today;
            lowest = tmpLow;
        }

        Label_012A:
        outMax[outIdx] = highest;
        outMin[outIdx] = lowest;
        outIdx++;
        trailingIdx++;
        today++;
        goto Label_00A5;
    }

    public static int MinMaxLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
