// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Kama(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double tempReal;
        const double ConstMax = 0.064516129032258063;
        const double ConstDiff = 0.66666666666666663 - ConstMax;
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

        int lookbackTotal = optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Kama];
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

        double sumRoc1 = 0.0;
        int today = startIdx - lookbackTotal;
        int trailingIdx = today;
        int i = optInTimePeriod;
        while (true)
        {
            i--;
            if (i <= 0)
            {
                break;
            }

            tempReal = inReal[today];
            today++;
            tempReal -= inReal[today];
            sumRoc1 += Math.Abs(tempReal);
        }

        double prevKama = inReal[today - 1];
        tempReal = inReal[today];
        double tempReal2 = inReal[trailingIdx];
        trailingIdx++;
        double periodRoc = tempReal - tempReal2;
        double trailingValue = tempReal2;
        tempReal = sumRoc1 <= periodRoc ? 1.0 : Math.Abs(periodRoc / sumRoc1);

        tempReal = (tempReal * ConstDiff) + ConstMax;
        tempReal *= tempReal;
        prevKama = ((inReal[today] - prevKama) * tempReal) + prevKama;
        today++;
        while (true)
        {
            if (today > startIdx)
            {
                break;
            }

            tempReal = inReal[today];
            tempReal2 = inReal[trailingIdx];
            trailingIdx++;
            periodRoc = tempReal - tempReal2;
            sumRoc1 -= Math.Abs(trailingValue - tempReal2);
            sumRoc1 += Math.Abs(tempReal - inReal[today - 1]);
            trailingValue = tempReal2;
            tempReal = sumRoc1 <= periodRoc ? 1.0 : Math.Abs(periodRoc / sumRoc1);

            tempReal = (tempReal * ConstDiff) + ConstMax;
            tempReal *= tempReal;
            prevKama = ((inReal[today] - prevKama) * tempReal) + prevKama;
            today++;
        }

        outReal[0] = prevKama;
        int outIdx = 1;
        outBegIdx = today - 1;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            tempReal = inReal[today];
            tempReal2 = inReal[trailingIdx];
            trailingIdx++;
            periodRoc = tempReal - tempReal2;
            sumRoc1 -= Math.Abs(trailingValue - tempReal2);
            sumRoc1 += Math.Abs(tempReal - inReal[today - 1]);
            trailingValue = tempReal2;
            tempReal = sumRoc1 <= periodRoc ? 1.0 : Math.Abs(periodRoc / sumRoc1);

            tempReal = (tempReal * ConstDiff) + ConstMax;
            tempReal *= tempReal;
            prevKama = ((inReal[today] - prevKama) * tempReal) + prevKama;
            today++;
            outReal[outIdx] = prevKama;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int KamaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Kama];
    }
}
