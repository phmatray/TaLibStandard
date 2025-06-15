// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode MinusDM(
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
        double diffM;
        double prevLow;
        double prevHigh;
        double diffP;
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        int lookbackTotal =
            inHigh == null! ||
            inLow == null! ||
            optInTimePeriod is < 1 or > 100000 ||
            outReal == null! ||
            optInTimePeriod > 1
                ? optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDM] - 1
                : 1;

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
                if (diffM > 0.0 && diffP < diffM)
                {
                    outReal[outIdx] = diffM;
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
        double prevMinusDM = 0.0;
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
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM += diffM;
            }

            goto Label_0138;
        }

        i = (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDM];
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
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM = prevMinusDM - (prevMinusDM / optInTimePeriod) + diffM;
            }
            else
            {
                prevMinusDM -= prevMinusDM / optInTimePeriod;
            }

            goto Label_0186;
        }

        outReal[0] = prevMinusDM;
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
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM = prevMinusDM - (prevMinusDM / optInTimePeriod) + diffM;
            }
            else
            {
                prevMinusDM -= prevMinusDM / optInTimePeriod;
            }

            outReal[outIdx] = prevMinusDM;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int MinusDMLookback(int optInTimePeriod)
    {
        return optInTimePeriod switch
        {
            < 1 or > 100000 => -1,
            > 1 => optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDM] - 1,
            _ => 1
        };
    }
}
