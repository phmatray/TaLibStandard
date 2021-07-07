using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Sum(
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

            int lookbackTotal = optInTimePeriod - 1;
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

            double periodTotal = 0.0;
            int trailingIdx = startIdx - lookbackTotal;
            int i = trailingIdx;
            while (i < startIdx)
            {
                periodTotal += inReal[i];
                i++;
            }

            int outIdx = 0;
            do
            {
                periodTotal += inReal[i];
                i++;
                double tempReal = periodTotal;
                periodTotal -= inReal[trailingIdx];
                trailingIdx++;
                outReal[outIdx] = tempReal;
                outIdx++;
            }
            while (i <= endIdx);

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int SumLookback(int optInTimePeriod)
        {
            if (optInTimePeriod is < 2 or > 100000)
            {
                return -1;
            }

            return optInTimePeriod - 1;
        }
    }
}
