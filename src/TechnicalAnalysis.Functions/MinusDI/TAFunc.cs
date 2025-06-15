// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode MinusDI(
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
        int today;
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
            inClose == null!  ||
            optInTimePeriod is < 1 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        int lookbackTotal = optInTimePeriod > 1 ? optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDI] : 1;

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
        if (optInTimePeriod > 1)
        {
            today = startIdx;
            outBegIdx = today;
            double prevMinusDM = 0.0;
            double prevTR = 0.0;
            today = startIdx - lookbackTotal;
            double prevHigh = inHigh[today];
            double prevLow = inLow[today];
            double prevClose = inClose[today];
            int i = optInTimePeriod - 1;
            while (true)
            {
                i--;
                double tempReal;
                double tempReal2;
                double diffM;
                double diffP;
                if (i <= 0)
                {
                    i = (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDI] + 1;
                    while (true)
                    {
                        i--;
                        if (i == 0)
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

                        tempReal = prevHigh - prevLow;
                        tempReal2 = Math.Abs(prevHigh - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        tempReal2 = Math.Abs(prevLow - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        prevTR = prevTR - (prevTR / optInTimePeriod) + tempReal;
                        prevClose = inClose[today];
                    }

                    outReal[0] = 100.0 * (prevMinusDM / prevTR);

                    outIdx = 1;
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
                            prevMinusDM = prevMinusDM - (prevMinusDM / optInTimePeriod) + diffM;
                        }
                        else
                        {
                            prevMinusDM -= prevMinusDM / optInTimePeriod;
                        }

                        tempReal = prevHigh - prevLow;
                        tempReal2 = Math.Abs(prevHigh - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        tempReal2 = Math.Abs(prevLow - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        prevTR = prevTR - (prevTR / optInTimePeriod) + tempReal;
                        prevClose = inClose[today];
                        outReal[outIdx] = 100.0 * (prevMinusDM / prevTR);
                        outIdx++;
                    }

                    outNBElement = outIdx;
                    return Success;
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
                    prevMinusDM += diffM;
                }

                tempReal = prevHigh - prevLow;
                tempReal2 = Math.Abs(prevHigh - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                tempReal2 = Math.Abs(prevLow - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                prevTR += tempReal;
                prevClose = inClose[today];
            }
        }

        outBegIdx = startIdx;
        today = startIdx - 1;
        while (true)
        {
            if (today >= endIdx)
            {
                break;
            }

            today++;
            outReal[outIdx] = 0.0;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int MinusDILookback(int optInTimePeriod)
    {
        return optInTimePeriod switch
        {
            < 1 or > 100000 => -1,
            > 1 => optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDI],
            _ => 1
        };
    }
}
