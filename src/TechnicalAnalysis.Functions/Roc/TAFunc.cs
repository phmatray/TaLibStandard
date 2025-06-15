// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Roc(
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

        if (inReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        if (startIdx < optInTimePeriod)
        {
            startIdx = optInTimePeriod;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int inIdx = startIdx;
        int trailingIdx = startIdx - optInTimePeriod;
        while (true)
        {
            if (inIdx > endIdx)
            {
                break;
            }

            double tempReal = inReal[trailingIdx];
            trailingIdx++;
            if (tempReal != 0.0)
            {
                outReal[outIdx] = ((inReal[inIdx] / tempReal) - 1.0) * 100.0;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            inIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    public static int RocLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : optInTimePeriod;
    }
}
