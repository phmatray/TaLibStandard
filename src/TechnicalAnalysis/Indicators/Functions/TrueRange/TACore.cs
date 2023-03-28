// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode TrueRange(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
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

        if (inHigh == null || inLow == null || inClose == null)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        if (startIdx < 1)
        {
            startIdx = 1;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int today = startIdx;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            double tempLT = inLow[today];
            double tempHT = inHigh[today];
            double tempCY = inClose[today - 1];
            double greatest = tempHT - tempLT;
            double val2 = Math.Abs(tempCY - tempHT);
            if (val2 > greatest)
            {
                greatest = val2;
            }

            double val3 = Math.Abs(tempCY - tempLT);
            if (val3 > greatest)
            {
                greatest = val3;
            }

            outReal[outIdx] = greatest;
            outIdx++;
            today++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    public static int TrueRangeLookback()
    {
        return 1;
    }
}
