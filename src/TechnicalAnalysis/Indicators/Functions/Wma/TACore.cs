// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Wma(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double tempReal;
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null)
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

        int lookbackTotal = optInTimePeriod - 1;
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

        if (optInTimePeriod == 1)
        {
            outBegIdx = startIdx;
            outNBElement = endIdx - startIdx + 1;
            Array.Copy(inReal, startIdx, outReal, 0, outNBElement);
            return Success;
        }

        int divider = (optInTimePeriod * (optInTimePeriod + 1)) >> 1;
        int outIdx = 0;
        int trailingIdx = startIdx - lookbackTotal;
        double periodSub = 0.0;
        double periodSum = periodSub;
        int inIdx = trailingIdx;
        int i = 1;
        while (true)
        {
            if (inIdx >= startIdx)
            {
                break;
            }

            tempReal = inReal[inIdx];
            inIdx++;
            periodSub += tempReal;
            periodSum += tempReal * i;
            i++;
        }

        double trailingValue = 0.0;
        while (true)
        {
            if (inIdx > endIdx)
            {
                break;
            }

            tempReal = inReal[inIdx];
            inIdx++;
            periodSub += tempReal;
            periodSub -= trailingValue;
            periodSum += tempReal * optInTimePeriod;
            trailingValue = inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = periodSum / divider;
            outIdx++;
            periodSum -= periodSub;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    public static int WmaLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            return -1;
        }

        return optInTimePeriod - 1;
    }
}
