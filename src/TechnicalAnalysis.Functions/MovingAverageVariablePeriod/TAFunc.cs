// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in double[] inPeriods,
        in int optInMinPeriod,
        in int optInMaxPeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null! ||
            inPeriods == null! ||
            optInMinPeriod is < 2 or > 100000 ||
            optInMaxPeriod is < 2 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        int lookbackTotal = MovingAverageLookback(optInMaxPeriod, optInMAType);
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

        int tempInt = lookbackTotal > startIdx ? lookbackTotal : startIdx;

        if (tempInt > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outputSize = endIdx - tempInt + 1;
        double[] localOutputArray = new double[outputSize];
        int[] localPeriodArray = new int[outputSize];
        for (i = 0; i < outputSize; i++)
        {
            tempInt = (int)inPeriods[startIdx + i];
            if (tempInt < optInMinPeriod)
            {
                tempInt = optInMinPeriod;
            }
            else if (tempInt > optInMaxPeriod)
            {
                tempInt = optInMaxPeriod;
            }

            localPeriodArray[i] = tempInt;
        }

        i = 0;
        while (true)
        {
            if (i >= outputSize)
            {
                outBegIdx = startIdx;
                outNBElement = outputSize;
                return Success;
            }

            int curPeriod = localPeriodArray[i];
            if (curPeriod != 0)
            {
                int localNbElement = 0;
                int localBegIdx = 0;
                RetCode retCode = MovingAverage(
                    startIdx,
                    endIdx,
                    inReal,
                    curPeriod,
                    optInMAType,
                    ref localBegIdx,
                    ref localNbElement,
                    ref localOutputArray);
                if (retCode != Success)
                {
                    outBegIdx = 0;
                    outNBElement = 0;
                    return retCode;
                }

                outReal[i] = localOutputArray[i];
                for (int j = i + 1; j < outputSize; j++)
                {
                    if (localPeriodArray[j] == curPeriod)
                    {
                        localPeriodArray[j] = 0;
                        outReal[j] = localOutputArray[j];
                    }
                }
            }

            i++;
        }
    }

    public static int MovingAverageVariablePeriodLookback(
        int optInMinPeriod,
        int optInMaxPeriod,
        MAType optInMAType)
    {
        return optInMinPeriod is < 2 or > 100000 ||
            optInMaxPeriod is < 2 or > 100000
            ? -1
            : MovingAverageLookback(optInMaxPeriod, optInMAType);
    }
}
