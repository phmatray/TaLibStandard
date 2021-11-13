using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;
using TechnicalAnalysis.Functions.FunctionRocR;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Trix(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int nbElement = 0;
        int begIdx = 0;
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (outReal == null)
        {
            return RetCode.BadParam;
        }

        int emaLookback = new EmaLookback(optInTimePeriod).Result;
        int rocLookback = new RocRLookback(1).Result;
        int totalLookback = emaLookback * 3 + rocLookback;
        if (startIdx < totalLookback)
        {
            startIdx = totalLookback;
        }

        if (startIdx > endIdx)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return RetCode.Success;
        }

        outBegIdx = startIdx;
        int nbElementToOutput = endIdx - startIdx + 1 + totalLookback;
        double[] tempBuffer = new double[nbElementToOutput];

        double k = 2.0 / (optInTimePeriod + 1);
        RetCode retCode = TA_INT_EMA(
            startIdx - totalLookback,
            endIdx,
            inReal,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != RetCode.Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput--;
        nbElementToOutput -= emaLookback;
        retCode = TA_INT_EMA(
            0,
            nbElementToOutput,
            tempBuffer,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != RetCode.Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput -= emaLookback;
        retCode = TA_INT_EMA(
            0,
            nbElementToOutput,
            tempBuffer,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != RetCode.Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput -= emaLookback;
        retCode = TACore.Roc(0, nbElementToOutput, tempBuffer, 1, ref begIdx, ref outNBElement, ref outReal);
            
        if (retCode != RetCode.Success || outNBElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        return RetCode.Success;
    }
}
