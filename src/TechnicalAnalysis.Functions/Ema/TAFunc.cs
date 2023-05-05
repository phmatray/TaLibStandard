// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Ema(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
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

        if (inReal == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        RetCode taIntEMA = TA_INT_EMA(
            startIdx,
            endIdx,
            inReal,
            optInTimePeriod,
            2.0 / (optInTimePeriod + 1),
            ref outBegIdx,
            ref outNBElement,
            outReal);
        
        return taIntEMA;
    }

    public static int EmaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1 + (int)Globals._unstablePeriod[5];
    }
}
