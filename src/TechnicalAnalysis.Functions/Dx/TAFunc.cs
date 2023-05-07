// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Dx(
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
        double tempReal;
        double tempReal2;
        double diffM;
        double diffP;
        double plusDI;
        double minusDI;
        int lookbackTotal;
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

        lookbackTotal = optInTimePeriod > 1 ? optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Dx] : 2;

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

        int today = startIdx;
        outBegIdx = today;
        double prevMinusDM = 0.0;
        double prevPlusDM = 0.0;
        double prevTR = 0.0;
        today = startIdx - lookbackTotal;
        double prevHigh = inHigh[today];
        double prevLow = inLow[today];
        double prevClose = inClose[today];
        int i = optInTimePeriod - 1;
        while (true)
        {
            i--;
            if (i <= 0)
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
                prevMinusDM += diffM;
            }
            else if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
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

        i = (int)TACore.Globals.UnstablePeriod[FuncUnstId.Dx] + 1;
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
            prevMinusDM -= prevMinusDM / optInTimePeriod;
            prevPlusDM -= prevPlusDM / optInTimePeriod;
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM += diffM;
            }
            else if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
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

            prevTR = prevTR - prevTR / optInTimePeriod + tempReal;
            prevClose = inClose[today];
        }

        minusDI = 100.0 * (prevMinusDM / prevTR);
        plusDI = 100.0 * (prevPlusDM / prevTR);
        tempReal = minusDI + plusDI;
        outReal[0] = 100.0 * (Math.Abs(minusDI - plusDI) / tempReal);

        int outIdx = 1;
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
            prevMinusDM -= prevMinusDM / optInTimePeriod;
            prevPlusDM -= prevPlusDM / optInTimePeriod;
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM += diffM;
            }
            else if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
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

            prevTR = prevTR - prevTR / optInTimePeriod + tempReal;
            prevClose = inClose[today];
            minusDI = 100.0 * (prevMinusDM / prevTR);
            plusDI = 100.0 * (prevPlusDM / prevTR);
            tempReal = minusDI + plusDI;
            outReal[outIdx] = 100.0 * (Math.Abs(minusDI - plusDI) / tempReal);

            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int DxLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Dx];
    }
}
