// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode PlusDM(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double tempReal;
        int today;
        double diffP;
        double prevLow;
        double prevHigh;
        double diffM;
        int lookbackTotal;
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        if (optInTimePeriod > 1)
        {
            lookbackTotal = optInTimePeriod + (int)Globals.unstablePeriod[19] - 1;
        }
        else
        {
            lookbackTotal = 1;
        }

        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        if (optInTimePeriod <= 1)
        {
            outBegIdx = startIdx;
            today = startIdx - 1;
            prevHigh = inHigh[today];
            prevLow = inLow[today];
            while (today < endIdx)
            {
                today++;
                tempReal = inHigh[today];
                diffP = tempReal - prevHigh;
                prevHigh = tempReal;
                tempReal = inLow[today];
                diffM = prevLow - tempReal;
                prevLow = tempReal;
                if (diffP > 0.0 && diffP > diffM)
                {
                    outReal[outIdx] = diffP;
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }
            }

            outNBElement = outIdx;
            return Success;
        }

        outBegIdx = startIdx;
        double prevPlusDM = 0.0;
        today = startIdx - lookbackTotal;
        prevHigh = inHigh[today];
        prevLow = inLow[today];
        int i = optInTimePeriod - 1;
        Label_0138:
        i--;
        if (i > 0)
        {
            today++;
            tempReal = inHigh[today];
            diffP = tempReal - prevHigh;
            prevHigh = tempReal;
            tempReal = inLow[today];
            diffM = prevLow - tempReal;
            prevLow = tempReal;
            if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
            }

            goto Label_0138;
        }

        i = (int)Globals.unstablePeriod[19];
        Label_0186:
        i--;
        if (i != 0)
        {
            today++;
            tempReal = inHigh[today];
            diffP = tempReal - prevHigh;
            prevHigh = tempReal;
            tempReal = inLow[today];
            diffM = prevLow - tempReal;
            prevLow = tempReal;
            if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM = prevPlusDM - prevPlusDM / optInTimePeriod + diffP;
            }
            else
            {
                prevPlusDM -= prevPlusDM / optInTimePeriod;
            }

            goto Label_0186;
        }

        outReal[0] = prevPlusDM;
        outIdx = 1;
        while (true)
        {
            if (today >= endIdx)
            {
                break;
            }

            today++;
            tempReal = inHigh[today];
            diffP = tempReal - prevHigh;
            prevHigh = tempReal;
            tempReal = inLow[today];
            diffM = prevLow - tempReal;
            prevLow = tempReal;
            if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM = prevPlusDM - prevPlusDM / optInTimePeriod + diffP;
            }
            else
            {
                prevPlusDM -= prevPlusDM / optInTimePeriod;
            }

            outReal[outIdx] = prevPlusDM;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int PlusDMLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            return -1;
        }

        if (optInTimePeriod > 1)
        {
            return optInTimePeriod + (int)Globals.unstablePeriod[19] - 1;
        }

        return 1;
    }
}
