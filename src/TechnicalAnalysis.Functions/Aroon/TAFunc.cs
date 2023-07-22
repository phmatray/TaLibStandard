// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
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
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inHigh == null! || inLow == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outAroonDown == null!)
        {
            return BadParam;
        }

        if (outAroonUp == null!)
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
        Label_00BB:
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
                    goto Label_00FF;
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

        Label_00FF:
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
                    goto Label_0136;
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

        Label_0136:
        outAroonUp[outIdx] = factor * (optInTimePeriod - (today - highestIdx));
        outAroonDown[outIdx] = factor * (optInTimePeriod - (today - lowestIdx));
        outIdx++;
        trailingIdx++;
        today++;
        goto Label_00BB;
    }

    public static int AroonLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod;
    }
}
