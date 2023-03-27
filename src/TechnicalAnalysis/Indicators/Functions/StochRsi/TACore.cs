using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode StochRsi(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in int optInFastK_Period,
        in int optInFastD_Period,
        in MAType optInFastD_MAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outFastK,
        ref double[] outFastD)
    {
        int outNbElement1 = 0;
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

        if (optInTimePeriod is < 2 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (optInFastK_Period is < 1 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (optInFastD_Period is < 1 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (outFastK == null)
        {
            return RetCode.BadParam;
        }

        if (outFastD == null)
        {
            return RetCode.BadParam;
        }

        outBegIdx = 0;
        outNBElement = 0;
        int lookbackSTOCHF = StochFLookback(optInFastK_Period, optInFastD_Period, optInFastD_MAType);
        int lookbackTotal = RsiLookback(optInTimePeriod) + lookbackSTOCHF;
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

        outBegIdx = startIdx;
        int tempArraySize = endIdx - startIdx + 1 + lookbackSTOCHF;
        double[] tempRSIBuffer = new double[tempArraySize];
        RetCode retCode = Rsi(
            startIdx - lookbackSTOCHF,
            endIdx,
            inReal,
            optInTimePeriod,
            ref outBegIdx1,
            ref outNbElement1,
            ref tempRSIBuffer);
            
        if (retCode != RetCode.Success || outNbElement1 == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        retCode = StochF(
            0,
            tempArraySize - 1,
            tempRSIBuffer,
            tempRSIBuffer,
            tempRSIBuffer,
            optInFastK_Period,
            optInFastD_Period,
            optInFastD_MAType,
            ref outBegIdx2,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        if (retCode != RetCode.Success || outNBElement == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        return RetCode.Success;
    }

    public static int StochRsiLookback(
        int optInTimePeriod,
        int optInFastK_Period,
        int optInFastD_Period,
        MAType optInFastD_MAType)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInFastK_Period is < 1 or > 100000)
        {
            return -1;
        }

        if (optInFastD_Period is < 1 or > 100000)
        {
            return -1;
        }

        return RsiLookback(optInTimePeriod) + StochFLookback(
            optInFastK_Period,
            optInFastD_Period,
            optInFastD_MAType);
    }
}
