namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode RocR(
            int startIdx,
            int endIdx,
            double[] inReal,
            int optInTimePeriod,
            ref int outBegIdx,
            ref int outNBElement,
            double[] outReal)
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

            if (optInTimePeriod is < 1 or > 100000)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            if (startIdx < optInTimePeriod)
            {
                startIdx = optInTimePeriod;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            int outIdx = 0;
            int inIdx = startIdx;
            int trailingIdx = startIdx - optInTimePeriod;
            while (true)
            {
                if (inIdx > endIdx)
                {
                    break;
                }

                double tempReal = inReal[trailingIdx];
                trailingIdx++;
                if (tempReal != 0.0)
                {
                    outReal[outIdx] = inReal[inIdx] / tempReal;
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }

                inIdx++;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int RocRLookback(int optInTimePeriod)
        {
            if (optInTimePeriod is < 1 or > 100000)
            {
                return -1;
            }

            return optInTimePeriod;
        }
    }
}
