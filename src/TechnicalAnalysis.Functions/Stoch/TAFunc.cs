// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Stoch(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInFastKPeriod,
        in int optInSlowKPeriod,
        in MAType optInSlowKMAType,
        in int optInSlowDPeriod,
        in MAType optInSlowDMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outSlowK,
        ref double[] outSlowD)
    {
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
            optInSlowKPeriod is < 1 or > 100000 ||
            optInSlowDPeriod is < 1 or > 100000 ||
            outSlowK == null! ||
            outSlowD == null!)
        {
            return BadParam;
        }

        int lookbackK = optInFastKPeriod - 1;
        int lookbackKSlow = MovingAverageLookback(optInSlowKPeriod, optInSlowKMAType);
        int lookbackDSlow = MovingAverageLookback(optInSlowDPeriod, optInSlowDMAType);
        int lookbackTotal = lookbackK + lookbackDSlow + lookbackKSlow;
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
        double[] tempBuffer = outSlowK == inHigh || outSlowK == inLow || outSlowK == inClose
            ? outSlowK
            : outSlowD == inHigh || outSlowD == inLow || outSlowD == inClose
                ? outSlowD
                : new double[endIdx - today + 1];

Label_0156:
        if (today > endIdx)
        {
            RetCode retCode = MovingAverage(
                0,
                outIdx - 1,
                tempBuffer,
                optInSlowKPeriod,
                optInSlowKMAType,
                ref outBegIdx,
                ref outNBElement,
                ref tempBuffer);
                
            if (retCode != Success || outNBElement == 0)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return retCode;
            }

            retCode = MovingAverage(
                0,
                outNBElement - 1,
                tempBuffer,
                optInSlowDPeriod,
                optInSlowDMAType,
                ref outBegIdx,
                ref outNBElement,
                ref outSlowD);
                
            Array.Copy(tempBuffer, lookbackDSlow, outSlowK, 0, outNBElement);
            if (retCode != Success)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return retCode;
            }

            outBegIdx = startIdx;
            return Success;
        }

        double tmp = inLow[today];
        if (lowestIdx >= trailingIdx)
        {
            if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
                diff = (highest - lowest) / 100.0;
            }

            goto Label_01B5;
        }

        lowestIdx = trailingIdx;
        lowest = inLow[lowestIdx];
        int i = lowestIdx;
        Label_0173:
        i++;
        if (i <= today)
        {
            tmp = inLow[i];
            if (tmp < lowest)
            {
                lowestIdx = i;
                lowest = tmp;
            }

            goto Label_0173;
        }

        diff = (highest - lowest) / 100.0;
        Label_01B5:
        tmp = inHigh[today];
        if (highestIdx >= trailingIdx)
        {
            if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
                diff = (highest - lowest) / 100.0;
            }

            goto Label_0212;
        }

        highestIdx = trailingIdx;
        highest = inHigh[highestIdx];
        i = highestIdx;
        Label_01CC:
        i++;
        if (i <= today)
        {
            tmp = inHigh[i];
            if (tmp > highest)
            {
                highestIdx = i;
                highest = tmp;
            }

            goto Label_01CC;
        }

        diff = (highest - lowest) / 100.0;
        Label_0212:
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
        goto Label_0156;
    }

    public static int StochLookback(
        int optInFastKPeriod,
        int optInSlowKPeriod,
        MAType optInSlowKMAType,
        int optInSlowDPeriod,
        MAType optInSlowDMAType)
    {
        if (optInFastKPeriod is < 1 or > 100000 ||
            optInSlowKPeriod is < 1 or > 100000 ||
            optInSlowDPeriod is < 1 or > 100000)
        {
            return -1;
        }

        int retValue = optInFastKPeriod - 1;
        retValue += MovingAverageLookback(optInSlowKPeriod, optInSlowKMAType);
        return retValue + MovingAverageLookback(optInSlowDPeriod, optInSlowDMAType);
    }
}
