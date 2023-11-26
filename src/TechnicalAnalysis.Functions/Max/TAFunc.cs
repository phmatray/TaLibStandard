// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Max(
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

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
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
        Label_008A:
        if (today > endIdx)
        {
            outBegIdx = startIdx;
            outNBElement = outIdx;
            return Success;
        }

        double tmp = inReal[today];
        if (highestIdx < trailingIdx)
        {
            highestIdx = trailingIdx;
            highest = inReal[highestIdx];
            int i = highestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_00CC;
                }

                tmp = inReal[i];
                if (tmp > highest)
                {
                    highestIdx = i;
                    highest = tmp;
                }
            }
        }

        if (tmp >= highest)
        {
            highestIdx = today;
            highest = tmp;
        }

        Label_00CC:
        outReal[outIdx] = highest;
        outIdx++;
        trailingIdx++;
        today++;
        goto Label_008A;
    }

    public static int MaxLookback(int optInTimePeriod)
        => optInTimePeriod is < 2 or > 100000
            ? -1
            : optInTimePeriod - 1;
}
