using System;
using TechnicalAnalysis.Common;

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
            return RetCode.OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return RetCode.OutOfRangeEndIndex;
        }

        if (inReal == null)
        {
            return RetCode.BadParam;
        }

        if (optInFastPeriod is < 2 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (optInSignalPeriod is < 1 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (outMACD == null)
        {
            return RetCode.BadParam;
        }

        if (outMACDSignal == null)
        {
            return RetCode.BadParam;
        }

        if (outMACDHist == null)
        {
            return RetCode.BadParam;
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
            return RetCode.Success;
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
            
        if (retCode != RetCode.Success)
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
            
        if (retCode != RetCode.Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        if (outBegIdx1 != tempInteger || outBegIdx2 != tempInteger || outNbElement1 != outNbElement2 || outNbElement1 != endIdx - startIdx + 1 + lookbackSignal)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return RetCode.InternalError;
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
            
        if (retCode != RetCode.Success)
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
        return RetCode.Success;
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
