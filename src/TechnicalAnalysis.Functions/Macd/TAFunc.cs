// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Macd(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInFastPeriod,
        in int optInSlowPeriod,
        in int optInSignalPeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMACD,
        ref double[] outMACDSignal,
        ref double[] outMACDHist)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null! ||
            optInFastPeriod is < 2 or > 100000 ||
            optInSlowPeriod is < 2 or > 100000 ||
            optInSignalPeriod is < 1 or > 100000 ||
            outMACD == null! ||
            outMACDSignal == null! ||
            outMACDHist == null!)
        {
            return BadParam;
        }

        RetCode taIntMACD = TA_INT_MACD(
            startIdx,
            endIdx,
            inReal,
            optInFastPeriod,
            optInSlowPeriod,
            optInSignalPeriod,
            ref outBegIdx,
            ref outNBElement,
            outMACD,
            outMACDSignal,
            outMACDHist);
        
        return taIntMACD;
    }

    public static int MacdLookback(int optInFastPeriod, int optInSlowPeriod, int optInSignalPeriod)
    {
        if (optInFastPeriod is < 2 or > 100000 ||
            optInSlowPeriod is < 2 or > 100000 ||
            optInSignalPeriod is < 1 or > 100000)
        {
            return -1;
        }

        if (optInSlowPeriod < optInFastPeriod)
        {
            (optInSlowPeriod, _) = (optInFastPeriod, optInSlowPeriod);
        }

        return EmaLookback(optInSlowPeriod) + EmaLookback(optInSignalPeriod);
    }
}
