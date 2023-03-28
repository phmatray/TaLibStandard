// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode AroonOsc(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
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

        if (inHigh == null || inLow == null)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null)
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
        int today = startIdx;
        int trailingIdx = startIdx - optInTimePeriod;
        int lowestIdx = -1;
        int highestIdx = -1;
        double lowest = 0.0;
        double highest = 0.0;
        double factor = 100.0 / optInTimePeriod;
        Label_00AF:
        if (today > endIdx)
        {
            outBegIdx = startIdx;
            outNBElement = outIdx;
            return Success;
        }

        double tmp = inLow[today];
        if (lowestIdx < trailingIdx)
        {
            lowestIdx = trailingIdx;
            lowest = inLow[lowestIdx];
            i = lowestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_00F3;
                }

                tmp = inLow[i];
                if (tmp <= lowest)
                {
                    lowestIdx = i;
                    lowest = tmp;
                }
            }
        }

        if (tmp <= lowest)
        {
            lowestIdx = today;
            lowest = tmp;
        }

        Label_00F3:
        tmp = inHigh[today];
        if (highestIdx < trailingIdx)
        {
            highestIdx = trailingIdx;
            highest = inHigh[highestIdx];
            i = highestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_012A;
                }

                tmp = inHigh[i];
                if (tmp >= highest)
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

        Label_012A:
        double aroon = factor * (highestIdx - lowestIdx);
        outReal[outIdx] = aroon;
        outIdx++;
        trailingIdx++;
        today++;
        goto Label_00AF;
    }

    public static int AroonOscLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            return -1;
        }

        return optInTimePeriod;
    }
}
