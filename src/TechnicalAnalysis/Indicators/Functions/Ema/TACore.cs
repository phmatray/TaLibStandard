using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Ema(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
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

        if (optInTimePeriod is < 2 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (outReal == null)
        {
            return RetCode.BadParam;
        }

        return TA_INT_EMA(
            startIdx,
            endIdx,
            inReal,
            optInTimePeriod,
            2.0 / (optInTimePeriod + 1),
            ref outBegIdx,
            ref outNBElement,
            outReal);
    }

    public static int EmaLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            return -1;
        }

        return optInTimePeriod - 1 + (int)Globals.unstablePeriod[5];
    }
}