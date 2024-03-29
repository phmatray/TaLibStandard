// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode WillR(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
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

        if (inHigh == null! ||
            inLow == null! ||
            inClose == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            outReal == null!)
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
        int lowestIdx = highestIdx;
        double lowest = 0.0;
        double highest = lowest;
        double diff = highest;
Label_00B1:
        if (today > endIdx)
        {
            outBegIdx = startIdx;
            outNBElement = outIdx;
            return Success;
        }

        double tmp = inLow[today];
        if (lowestIdx >= trailingIdx)
        {
            if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
                diff = (highest - lowest) / -100.0;
            }

            goto Label_0112;
        }

        lowestIdx = trailingIdx;
        lowest = inLow[lowestIdx];
        int i = lowestIdx;
        Label_00D0:
        i++;
        if (i <= today)
        {
            tmp = inLow[i];
            if (tmp < lowest)
            {
                lowestIdx = i;
                lowest = tmp;
            }

            goto Label_00D0;
        }

        diff = (highest - lowest) / -100.0;
        Label_0112:
        tmp = inHigh[today];
        if (highestIdx >= trailingIdx)
        {
            if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
                diff = (highest - lowest) / -100.0;
            }

            goto Label_016B;
        }

        highestIdx = trailingIdx;
        highest = inHigh[highestIdx];
        i = highestIdx;
        Label_0129:
        i++;
        if (i <= today)
        {
            tmp = inHigh[i];
            if (tmp > highest)
            {
                highestIdx = i;
                highest = tmp;
            }

            goto Label_0129;
        }

        diff = (highest - lowest) / -100.0;
        Label_016B:
        if (diff != 0.0)
        {
            outReal[outIdx] = (highest - inClose[today]) / diff;
            outIdx++;
        }
        else
        {
            outReal[outIdx] = 0.0;
            outIdx++;
        }

        trailingIdx++;
        today++;
        goto Label_00B1;
    }

    public static int WillRLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
