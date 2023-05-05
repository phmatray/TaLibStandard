// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Ad(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
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

        if (inHigh == null! || inLow == null! || inClose == null! || inVolume == null!)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int nbBar = endIdx - startIdx + 1;
        outNBElement = nbBar;
        outBegIdx = startIdx;
        int currentBar = startIdx;
        int outIdx = 0;
        double ad = 0.0;
        while (true)
        {
            if (nbBar == 0)
            {
                break;
            }

            double high = inHigh[currentBar];
            double low = inLow[currentBar];
            double tmp = high - low;
            double close = inClose[currentBar];
            if (tmp > 0.0)
            {
                ad += (close - low - (high - close)) / tmp * inVolume[currentBar];
            }

            outReal[outIdx] = ad;
            outIdx++;
            currentBar++;
            nbBar--;
        }

        return Success;
    }

    public static int AdLookback()
    {
        return 0;
    }
}
