// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode StochF(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInFastKPeriod,
        in int optInFastDPeriod,
        in MAType optInFastDMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outFastK,
        ref double[] outFastD)
    {
        double[] tempBuffer;
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
            optInFastKPeriod is < 1 or > 100000 ||
            optInFastDPeriod is < 1 or > 100000 ||
            outFastK == null! ||
            outFastD == null!)
        {
            return BadParam;
        }

        int lookbackK = optInFastKPeriod - 1;
        int lookbackFastD = MovingAverageLookback(optInFastDPeriod, optInFastDMAType);
        int lookbackTotal = lookbackK + lookbackFastD;
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

        int outIdx = 0;
        int trailingIdx = startIdx - lookbackTotal;
        int today = trailingIdx + lookbackK;
        int highestIdx = -1;
        int lowestIdx = highestIdx;
        double lowest = 0.0;
        double highest = lowest;
        double diff = highest;
        tempBuffer = outFastK == inHigh || outFastK == inLow || outFastK == inClose
            ? outFastK
            : outFastD == inHigh || outFastD == inLow || outFastD == inClose
                ? outFastD
                : new double[endIdx - today + 1];

        while (today <= endIdx)
        {
            double tmp = inLow[today];
            if (lowestIdx < trailingIdx)
            {
                lowestIdx = trailingIdx;
                lowest = inLow[lowestIdx];
                int i = lowestIdx;
                while (i <= today)
                {
                    tmp = inLow[i];
                    if (tmp < lowest)
                    {
                        lowestIdx = i;
                        lowest = tmp;
                    }
                    i++;
                }
                diff = (highest - lowest) / 100.0;
            }
            else if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
                diff = (highest - lowest) / 100.0;
            }

            tmp = inHigh[today];
            if (highestIdx < trailingIdx)
            {
                highestIdx = trailingIdx;
                highest = inHigh[highestIdx];
                int i = highestIdx;
                while (i <= today)
                {
                    tmp = inHigh[i];
                    if (tmp > highest)
                    {
                        highestIdx = i;
                        highest = tmp;
                    }
                    i++;
                }
                diff = (highest - lowest) / 100.0;
            }
            else if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
                diff = (highest - lowest) / 100.0;
            }

            if (diff != 0.0)
            {
                tempBuffer[outIdx] = (inClose[today] - lowest) / diff;
                outIdx++;
            }
            else
            {
                tempBuffer[outIdx] = 0.0;
                outIdx++;
            }

            trailingIdx++;
            today++;
        }

        RetCode retCode = MovingAverage(
            0,
            outIdx - 1,
            tempBuffer,
            optInFastDPeriod,
            optInFastDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outFastD);
            
        if (retCode != Success || outNBElement == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        Array.Copy(tempBuffer, lookbackFastD, outFastK, 0, outNBElement);

        outBegIdx = startIdx;
        return Success;
    }

    public static int StochFLookback(int optInFastKPeriod, int optInFastDPeriod, MAType optInFastDMAType)
    {
        if (optInFastKPeriod is < 1 or > 100000 ||
            optInFastDPeriod is < 1 or > 100000)
        {
            return -1;
        }

        int retValue = optInFastKPeriod - 1;
        return retValue + MovingAverageLookback(optInFastDPeriod, optInFastDMAType);
    }
}
