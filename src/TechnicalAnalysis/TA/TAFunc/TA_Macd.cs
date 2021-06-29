namespace TechnicalAnalysis
{
    internal partial class TACore
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

            if (optInFastPeriod == -2147483648)
            {
                optInFastPeriod = 12;
            }
            else if (optInFastPeriod is < 2 or > 0x186a0)
            {
                return RetCode.BadParam;
            }

            if (optInSlowPeriod == -2147483648)
            {
                optInSlowPeriod = 26;
            }
            else if (optInSlowPeriod is < 2 or > 0x186a0)
            {
                return RetCode.BadParam;
            }

            if (optInSignalPeriod == -2147483648)
            {
                optInSignalPeriod = 9;
            }
            else if (optInSignalPeriod is < 1 or > 0x186a0)
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
            if (optInFastPeriod == -2147483648)
            {
                optInFastPeriod = 12;
            }
            else if (optInFastPeriod is < 2 or > 0x186a0)
            {
                return -1;
            }

            if (optInSlowPeriod == -2147483648)
            {
                optInSlowPeriod = 0x1a;
            }
            else if (optInSlowPeriod is < 2 or > 0x186a0)
            {
                return -1;
            }

            if (optInSignalPeriod == -2147483648)
            {
                optInSignalPeriod = 9;
            }
            else if (optInSignalPeriod is < 1 or > 0x186a0)
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
