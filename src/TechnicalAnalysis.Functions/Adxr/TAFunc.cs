// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Adxr(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
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

        if (inHigh == null! || inLow == null! || inClose == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int adxrLookback = AdxrLookback(optInTimePeriod);
        if (startIdx < adxrLookback)
        {
            startIdx = adxrLookback;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double[] adx = new double[endIdx - startIdx + 2 * optInTimePeriod];

        RetCode retCode = Adx(
            startIdx - (optInTimePeriod - 1),
            endIdx,
            inHigh,
            inLow,
            inClose,
            optInTimePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref adx);
            
        if (retCode != Success)
        {
            return retCode;
        }

        int i = optInTimePeriod - 1;
        int j = 0;
        int outIdx = 0;
        int nbElement = endIdx - startIdx + 2;
        while (true)
        {
            nbElement--;
            if (nbElement == 0)
            {
                break;
            }

            outReal[outIdx] = (adx[i] + adx[j]) / 2.0;
            outIdx++;
            j++;
            i++;
        }

        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    public static int AdxrLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000
            ? -1
            : optInTimePeriod + AdxLookback(optInTimePeriod) - 1;
    }
}
