// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MedPrice(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
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

        if (inHigh == null || inLow == null)
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
            outReal[outIdx] = (inHigh[i] + inLow[i]) / 2.0;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    public static int MedPriceLookback()
    {
        return 0;
    }
}
