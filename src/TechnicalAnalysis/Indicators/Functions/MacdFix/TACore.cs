using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MacdFix(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInSignalPeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMACD,
        ref double[] outMACDSignal,
        ref double[] outMACDHist)
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

        return TA_INT_MACD(
            startIdx,
            endIdx,
            inReal,
            0,
            0,
            optInSignalPeriod,
            ref outBegIdx,
            ref outNBElement,
            outMACD,
            outMACDSignal,
            outMACDHist);
    }

    public static int MacdFixLookback(int optInSignalPeriod)
    {
        if (optInSignalPeriod is < 1 or > 100000)
        {
            return -1;
        }

        return EmaLookback(26) + EmaLookback(optInSignalPeriod);
    }
}