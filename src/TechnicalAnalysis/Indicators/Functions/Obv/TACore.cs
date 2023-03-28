// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Obv(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in double[] inVolume,
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

        if (inReal == null)
        {
            return BadParam;
        }

        if (inVolume == null)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        double prevOBV = inVolume[startIdx];
        double prevReal = inReal[startIdx];
        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            double tempReal = inReal[i];
            if (tempReal > prevReal)
            {
                prevOBV += inVolume[i];
            }
            else if (tempReal < prevReal)
            {
                prevOBV -= inVolume[i];
            }

            outReal[outIdx] = prevOBV;
            outIdx++;
            prevReal = tempReal;
        }

        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    public static int ObvLookback()
    {
        return 0;
    }
}
