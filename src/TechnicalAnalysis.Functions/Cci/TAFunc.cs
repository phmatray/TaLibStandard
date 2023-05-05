// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Cci(
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
        int circBufferIdx = 0;
        int maxIdxCircBuffer = 29;
            
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inHigh == null! ||
            inLow == null! ||
            inClose == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        int lookbackTotal = optInTimePeriod - 1;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double[] circBuffer = new double[optInTimePeriod];

        maxIdxCircBuffer = optInTimePeriod - 1;
        int i = startIdx - lookbackTotal;
        while (i < startIdx)
        {
            circBuffer[circBufferIdx] = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
            i++;
            circBufferIdx++;
            if (circBufferIdx > maxIdxCircBuffer)
            {
                circBufferIdx = 0;
            }
        }

        int outIdx = 0;
        do
        {
            double lastValue = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
            circBuffer[circBufferIdx] = lastValue;
            double theAverage = 0.0;
            int j = 0;
            while (j < optInTimePeriod)
            {
                theAverage += circBuffer[j];
                j++;
            }

            theAverage /= optInTimePeriod;
            double tempReal2 = 0.0;
            for (j = 0; j < optInTimePeriod; j++)
            {
                tempReal2 += Math.Abs(circBuffer[j] - theAverage);
            }

            double tempReal = lastValue - theAverage;
            if (tempReal != 0.0 && tempReal2 != 0.0)
            {
                outReal[outIdx] = tempReal / (0.015 * (tempReal2 / optInTimePeriod));
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            circBufferIdx++;
            if (circBufferIdx > maxIdxCircBuffer)
            {
                circBufferIdx = 0;
            }

            i++;
        }
        while (i <= endIdx);

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    public static int CciLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
