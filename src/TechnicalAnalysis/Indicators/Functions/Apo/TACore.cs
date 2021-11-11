using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Apo(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInFastPeriod,
        in int optInSlowPeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
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

        if (outReal == null)
        {
            return RetCode.BadParam;
        }

        double[] tempBuffer = new double[endIdx - startIdx + 1];

        return TA_INT_PO(
            startIdx,
            endIdx,
            inReal,
            optInFastPeriod,
            optInSlowPeriod,
            optInMAType,
            ref outBegIdx,
            ref outNBElement,
            outReal,
            tempBuffer,
            0);
    }

    public static int ApoLookback(int optInFastPeriod, int optInSlowPeriod, MAType optInMAType)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return -1;
        }

        return MovingAverageLookback(
            optInSlowPeriod <= optInFastPeriod ? optInFastPeriod : optInSlowPeriod,
            optInMAType);
    }
}