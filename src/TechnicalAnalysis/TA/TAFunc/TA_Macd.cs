namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Macd(
            int startIdx,
            int endIdx,
            double[] inReal,
            int optInFastPeriod,
            int optInSlowPeriod,
            int optInSignalPeriod,
            ref int outBegIdx,
            ref int outNBElement,
            double[] outMACD,
            double[] outMACDSignal,
            double[] outMACDHist)
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
                optInFastPeriod,
                optInSlowPeriod,
                optInSignalPeriod,
                ref outBegIdx,
                ref outNBElement,
                outMACD,
                outMACDSignal,
                outMACDHist);
        }

        public static int MacdLookback(int optInFastPeriod, int optInSlowPeriod, int optInSignalPeriod)
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

            if (optInSlowPeriod < optInFastPeriod)
            {
                int tempInteger = optInSlowPeriod;
                optInSlowPeriod = optInFastPeriod;
                optInFastPeriod = tempInteger;
            }

            return EmaLookback(optInSlowPeriod) + EmaLookback(optInSignalPeriod);
        }
    }
}
