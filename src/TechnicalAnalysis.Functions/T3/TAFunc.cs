// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode T3(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in double optInVFactor,
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

        if (inReal == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            optInVFactor is < 0.0 or > 1.0 ||
            outReal == null!)
        {
            return BadParam;
        }

        int lookbackTotal = (optInTimePeriod - 1) * 6 + (int)TACore.Globals.UnstablePeriod[FuncUnstId.T3];
        if (startIdx <= lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return Success;
        }

        outBegIdx = startIdx;
        int today = startIdx - lookbackTotal;
        double k = 2.0 / (optInTimePeriod + 1.0);
        double oneMinusK = 1.0 - k;
        double tempReal = inReal[today];
        today++;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            tempReal += inReal[today];
            today++;
        }

        double e1 = tempReal / optInTimePeriod;
        tempReal = e1;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            tempReal += e1;
        }

        double e2 = tempReal / optInTimePeriod;
        tempReal = e2;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            e2 = k * e1 + oneMinusK * e2;
            tempReal += e2;
        }

        double e3 = tempReal / optInTimePeriod;
        tempReal = e3;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            e2 = k * e1 + oneMinusK * e2;
            e3 = k * e2 + oneMinusK * e3;
            tempReal += e3;
        }

        double e4 = tempReal / optInTimePeriod;
        tempReal = e4;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            e2 = k * e1 + oneMinusK * e2;
            e3 = k * e2 + oneMinusK * e3;
            e4 = k * e3 + oneMinusK * e4;
            tempReal += e4;
        }

        double e5 = tempReal / optInTimePeriod;
        tempReal = e5;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            e2 = k * e1 + oneMinusK * e2;
            e3 = k * e2 + oneMinusK * e3;
            e4 = k * e3 + oneMinusK * e4;
            e5 = k * e4 + oneMinusK * e5;
            tempReal += e5;
        }

        double e6 = tempReal / optInTimePeriod;
        while (true)
        {
            if (today > startIdx)
            {
                break;
            }

            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            e2 = k * e1 + oneMinusK * e2;
            e3 = k * e2 + oneMinusK * e3;
            e4 = k * e3 + oneMinusK * e4;
            e5 = k * e4 + oneMinusK * e5;
            e6 = k * e5 + oneMinusK * e6;
        }

        tempReal = optInVFactor * optInVFactor;
        double c1 = -(tempReal * optInVFactor);
        double c2 = 3.0 * (tempReal - c1);
        double c3 = -6.0 * tempReal - 3.0 * (optInVFactor - c1);
        double c4 = 1.0 + 3.0 * optInVFactor - c1 + 3.0 * tempReal;
        int outIdx = 0;
        outReal[outIdx] = c1 * e6 + c2 * e5 + c3 * e4 + c4 * e3;
        outIdx++;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            e1 = k * inReal[today] + oneMinusK * e1;
            today++;
            e2 = k * e1 + oneMinusK * e2;
            e3 = k * e2 + oneMinusK * e3;
            e4 = k * e3 + oneMinusK * e4;
            e5 = k * e4 + oneMinusK * e5;
            e6 = k * e5 + oneMinusK * e6;
            outReal[outIdx] = c1 * e6 + c2 * e5 + c3 * e4 + c4 * e3;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int T3Lookback(int optInTimePeriod, double optInVFactor)
    {
        return optInTimePeriod is < 2 or > 100000 ||
            optInVFactor is < 0.0 or > 1.0
            ? -1
            : (optInTimePeriod - 1) * 6 + (int)TACore.Globals.UnstablePeriod[FuncUnstId.T3];
    }
}
