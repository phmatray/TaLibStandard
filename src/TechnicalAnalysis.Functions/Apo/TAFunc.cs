// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Apo(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInFastPeriod,
        in int optInSlowPeriod,
        in MAType optInMAType,
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

        if (inReal == null!)
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

        double[] tempBuffer = new double[endIdx - startIdx + 1];

        return TA_INT_PO(
            startIdx,
            endIdx,
            inReal,
            optInFastPeriod,
            optInSlowPeriod,
            optInMAType,
            ref outBegIdx,
            ref outNBElement,
            outReal,
            tempBuffer,
            0);
    }

    public static int ApoLookback(int optInFastPeriod, int optInSlowPeriod, MAType optInMAType)
    {
        return optInFastPeriod is < 2 or > 100000 || optInSlowPeriod is < 2 or > 100000
            ? -1
            : MovingAverageLookback(
                optInSlowPeriod <= optInFastPeriod ? optInFastPeriod : optInSlowPeriod,
                optInMAType);
    }
}
