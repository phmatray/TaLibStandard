// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Bop(
        int startIdx,
        int endIdx,
        in double[] inOpen,
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

        if (inOpen == null || inHigh == null || inLow == null || inClose == null)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            double tempReal = inHigh[i] - inLow[i];
            if (tempReal < 1E-08)
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = (inClose[i] - inOpen[i]) / tempReal;
                outIdx++;
            }
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    public static int BopLookback()
    {
        return 0;
    }
}
