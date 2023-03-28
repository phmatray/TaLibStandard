// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MacdFix(
        int startIdx,
        int endIdx,
        in double[] inReal,
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

        if (inReal == null)
        {
            return BadParam;
        }

        if (optInSignalPeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outMACD == null)
        {
            return BadParam;
        }

        if (outMACDSignal == null)
        {
            return BadParam;
        }

        if (outMACDHist == null)
        {
            return BadParam;
        }

        return TA_INT_MACD(
            startIdx,
            endIdx,
            inReal,
            0,
            0,
            optInSignalPeriod,
            ref outBegIdx,
            ref outNBElement,
            outMACD,
            outMACDSignal,
            outMACDHist);
    }

    public static int MacdFixLookback(int optInSignalPeriod)
    {
        if (optInSignalPeriod is < 1 or > 100000)
        {
            return -1;
        }

        return EmaLookback(26) + EmaLookback(optInSignalPeriod);
    }
}
