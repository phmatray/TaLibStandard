// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode AdOsc(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in double[] inVolume,
        in int optInFastPeriod,
        in int optInSlowPeriod,
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

        if (inHigh == null! || inLow == null! || inClose == null! || inVolume == null!)
        {
            return BadParam;
        }

        if (optInFastPeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int slowestPeriod = optInFastPeriod < optInSlowPeriod
            ? optInSlowPeriod
            : optInFastPeriod;

        int lookbackTotal = EmaLookback(slowestPeriod);
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

        outBegIdx = startIdx;
        int today = startIdx - lookbackTotal;
        double ad = 0.0;
        double fastK = 2.0 / (optInFastPeriod + 1);
        double oneMinusFastK = 1.0 - fastK;
        double slowK = 2.0 / (optInSlowPeriod + 1);
        double oneMinusSlowK = 1.0 - slowK;
        double high = inHigh[today];
        double low = inLow[today];
        double tmp = high - low;
        double close = inClose[today];
        if (tmp > 0.0)
        {
            ad += (close - low - (high - close)) / tmp * inVolume[today];
        }

        today++;
        double fastEMA = ad;
        double slowEMA = ad;
        while (true)
        {
            if (today >= startIdx)
            {
                break;
            }

            high = inHigh[today];
            low = inLow[today];
            tmp = high - low;
            close = inClose[today];
            if (tmp > 0.0)
            {
                ad += (close - low - (high - close)) / tmp * inVolume[today];
            }

            today++;
            fastEMA = fastK * ad + oneMinusFastK * fastEMA;
            slowEMA = slowK * ad + oneMinusSlowK * slowEMA;
        }

        int outIdx = 0;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            high = inHigh[today];
            low = inLow[today];
            tmp = high - low;
            close = inClose[today];
            if (tmp > 0.0)
            {
                ad += (close - low - (high - close)) / tmp * inVolume[today];
            }

            today++;
            fastEMA = fastK * ad + oneMinusFastK * fastEMA;
            slowEMA = slowK * ad + oneMinusSlowK * slowEMA;
            outReal[outIdx] = fastEMA - slowEMA;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int AdOscLookback(int optInFastPeriod, int optInSlowPeriod)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return -1;
        }

        int slowestPeriod = optInFastPeriod < optInSlowPeriod
            ? optInSlowPeriod
            : optInFastPeriod;

        return EmaLookback(slowestPeriod);
    }
}
