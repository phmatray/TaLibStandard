namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Variance(
            int startIdx,
            int endIdx,
            in double[] inReal,
            in int optInTimePeriod,
            in double optInNbDev,
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

            if (optInTimePeriod is < 1 or > 100000)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            return TA_INT_VAR(startIdx, endIdx, inReal, optInTimePeriod, ref outBegIdx, ref outNBElement, outReal);
        }

        public static int VarianceLookback(int optInTimePeriod, double optInNbDev)
        {
            if (optInTimePeriod is < 1 or > 100000)
            {
                return -1;
            }

            return optInTimePeriod - 1;
        }
    }
}
