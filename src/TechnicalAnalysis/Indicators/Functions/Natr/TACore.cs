// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Natr(
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
        int outNbElement1 = 0;
        int outBegIdx1 = 0;
        double[] prevATRTemp = new double[1];
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        outBegIdx = 0;
        outNBElement = 0;
        int lookbackTotal = NatrLookback(optInTimePeriod);
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            return Success;
        }

        if (optInTimePeriod <= 1)
        {
            return TrueRange(startIdx, endIdx, inHigh, inLow, inClose, ref outBegIdx, ref outNBElement, ref outReal);
        }

        double[] tempBuffer = new double[lookbackTotal + (endIdx - startIdx) + 1];
        RetCode retCode = TrueRange(
            startIdx - lookbackTotal + 1,
            endIdx,
            inHigh,
            inLow,
            inClose,
            ref outBegIdx1,
            ref outNbElement1,
            ref tempBuffer);
            
        if (retCode == Success)
        {
            retCode = TA_INT_SMA(
                optInTimePeriod - 1,
                optInTimePeriod - 1,
                tempBuffer,
                optInTimePeriod,
                ref outBegIdx1,
                ref outNbElement1,
                prevATRTemp);
            if (retCode != Success)
            {
                return retCode;
            }

            double prevATR = prevATRTemp[0];
            int today = optInTimePeriod;
            int outIdx = (int)Globals.unstablePeriod[17];
            while (true)
            {
                if (outIdx == 0)
                {
                    break;
                }

                prevATR *= optInTimePeriod - 1;
                prevATR += tempBuffer[today];
                today++;
                prevATR /= optInTimePeriod;
                outIdx--;
            }

            outIdx = 1;
            double tempValue = inClose[today];
            outReal[0] = prevATR / tempValue * 100.0;

            int nbATR = endIdx - startIdx + 1;
            while (true)
            {
                nbATR--;
                if (nbATR == 0)
                {
                    break;
                }

                prevATR *= optInTimePeriod - 1;
                prevATR += tempBuffer[today];
                today++;
                prevATR /= optInTimePeriod;
                tempValue = inClose[today];
                outReal[outIdx] = prevATR / tempValue * 100.0;

                outIdx++;
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
        }

        return retCode;
    }

    public static int NatrLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            return -1;
        }

        return optInTimePeriod + (int)Globals.unstablePeriod[17];
    }
}
