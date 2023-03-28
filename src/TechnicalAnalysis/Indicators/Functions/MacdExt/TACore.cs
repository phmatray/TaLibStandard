// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MacdExt(
        int startIdx,
        int endIdx,
        in double[] inReal,
        int optInFastPeriod,
        MAType optInFastMAType,
        int optInSlowPeriod,
        MAType optInSlowMAType,
        in int optInSignalPeriod,
        in MAType optInSignalMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMACD,
        ref double[] outMACDSignal,
        ref double[] outMACDHist)
    {
        int i;
        int tempInteger = 0;
        int outNbElement1 = 0;
        int outNbElement2 = 0;
        int outBegIdx2 = 0;
        int outBegIdx1 = 0;
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

        if (optInFastPeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (optInSignalPeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outMACD == null)
        {
            return BadParam;
        }

        if (outMACDSignal == null)
        {
            return BadParam;
        }

        if (outMACDHist == null)
        {
            return BadParam;
        }

        if (optInSlowPeriod < optInFastPeriod)
        {
            tempInteger = optInSlowPeriod;
            optInSlowPeriod = optInFastPeriod;
            optInFastPeriod = tempInteger;
            MAType tempMAType = optInSlowMAType;
            optInSlowMAType = optInFastMAType;
            optInFastMAType = tempMAType;
        }

        int lookbackLargest = MovingAverageLookback(optInFastPeriod, optInFastMAType);
        tempInteger = MovingAverageLookback(optInSlowPeriod, optInSlowMAType);
        if (tempInteger > lookbackLargest)
        {
            lookbackLargest = tempInteger;
        }

        int lookbackSignal = MovingAverageLookback(optInSignalPeriod, optInSignalMAType);
        int lookbackTotal = lookbackSignal + lookbackLargest;
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

        tempInteger = endIdx - startIdx + 1 + lookbackSignal;
        double[] fastMABuffer = new double[tempInteger];
        double[] slowMABuffer = new double[tempInteger];

        tempInteger = startIdx - lookbackSignal;
        RetCode retCode = MovingAverage(
            tempInteger,
            endIdx,
            inReal,
            optInSlowPeriod,
            optInSlowMAType,
            ref outBegIdx1,
            ref outNbElement1,
            ref slowMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        retCode = MovingAverage(
            tempInteger,
            endIdx,
            inReal,
            optInFastPeriod,
            optInFastMAType,
            ref outBegIdx2,
            ref outNbElement2,
            ref fastMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        if (outBegIdx1 != tempInteger || outBegIdx2 != tempInteger || outNbElement1 != outNbElement2 || outNbElement1 != endIdx - startIdx + 1 + lookbackSignal)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return InternalError;
        }

        for (i = 0; i < outNbElement1; i++)
        {
            fastMABuffer[i] -= slowMABuffer[i];
        }

        Array.Copy(fastMABuffer, lookbackSignal, outMACD, 0, endIdx - startIdx + 1);
        retCode = MovingAverage(
            0,
            outNbElement1 - 1,
            fastMABuffer,
            optInSignalPeriod,
            optInSignalMAType,
            ref outBegIdx2,
            ref outNbElement2,
            ref outMACDSignal);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        for (i = 0; i < outNbElement2; i++)
        {
            outMACDHist[i] = outMACD[i] - outMACDSignal[i];
        }

        outBegIdx = startIdx;
        outNBElement = outNbElement2;
        return Success;
    }

    public static int MacdExtLookback(
        int optInFastPeriod,
        MAType optInFastMAType,
        int optInSlowPeriod,
        MAType optInSlowMAType,
        int optInSignalPeriod,
        MAType optInSignalMAType)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSignalPeriod is < 1 or > 100000)
        {
            return -1;
        }

        int lookbackLargest = MovingAverageLookback(optInFastPeriod, optInFastMAType);
        int tempInteger = MovingAverageLookback(optInSlowPeriod, optInSlowMAType);
        if (tempInteger > lookbackLargest)
        {
            lookbackLargest = tempInteger;
        }

        return lookbackLargest + MovingAverageLookback(optInSignalPeriod, optInSignalMAType);
    }
}
