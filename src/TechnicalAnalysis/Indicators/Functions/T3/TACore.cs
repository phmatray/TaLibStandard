using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode T3(
            int startIdx,
            int endIdx,
            in double[] inReal,
            in int optInTimePeriod,
            in double optInVFactor,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
            int i;
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

            if (optInVFactor is < 0.0 or > 1.0)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            int lookbackTotal = (optInTimePeriod - 1) * 6 + (int)Globals.unstablePeriod[22];
            if (startIdx <= lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            if (startIdx > endIdx)
            {
                outNBElement = 0;
                outBegIdx = 0;
                return RetCode.Success;
            }

            outBegIdx = startIdx;
            int today = startIdx - lookbackTotal;
            double k = 2.0 / (optInTimePeriod + 1.0);
            double one_minus_k = 1.0 - k;
            double tempReal = inReal[today];
            today++;
            for (i = optInTimePeriod - 1; i > 0; i--)
            {
                tempReal += inReal[today];
                today++;
            }

            double e1 = tempReal / optInTimePeriod;
            tempReal = e1;
            for (i = optInTimePeriod - 1; i > 0; i--)
            {
                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                tempReal += e1;
            }

            double e2 = tempReal / optInTimePeriod;
            tempReal = e2;
            for (i = optInTimePeriod - 1; i > 0; i--)
            {
                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                e2 = k * e1 + one_minus_k * e2;
                tempReal += e2;
            }

            double e3 = tempReal / optInTimePeriod;
            tempReal = e3;
            for (i = optInTimePeriod - 1; i > 0; i--)
            {
                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                e2 = k * e1 + one_minus_k * e2;
                e3 = k * e2 + one_minus_k * e3;
                tempReal += e3;
            }

            double e4 = tempReal / optInTimePeriod;
            tempReal = e4;
            for (i = optInTimePeriod - 1; i > 0; i--)
            {
                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                e2 = k * e1 + one_minus_k * e2;
                e3 = k * e2 + one_minus_k * e3;
                e4 = k * e3 + one_minus_k * e4;
                tempReal += e4;
            }

            double e5 = tempReal / optInTimePeriod;
            tempReal = e5;
            for (i = optInTimePeriod - 1; i > 0; i--)
            {
                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                e2 = k * e1 + one_minus_k * e2;
                e3 = k * e2 + one_minus_k * e3;
                e4 = k * e3 + one_minus_k * e4;
                e5 = k * e4 + one_minus_k * e5;
                tempReal += e5;
            }

            double e6 = tempReal / optInTimePeriod;
            while (true)
            {
                if (today > startIdx)
                {
                    break;
                }

                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                e2 = k * e1 + one_minus_k * e2;
                e3 = k * e2 + one_minus_k * e3;
                e4 = k * e3 + one_minus_k * e4;
                e5 = k * e4 + one_minus_k * e5;
                e6 = k * e5 + one_minus_k * e6;
            }

            tempReal = optInVFactor * optInVFactor;
            double c1 = -(tempReal * optInVFactor);
            double c2 = 3.0 * (tempReal - c1);
            double c3 = -6.0 * tempReal - 3.0 * (optInVFactor - c1);
            double c4 = 1.0 + 3.0 * optInVFactor - c1 + 3.0 * tempReal;
            int outIdx = 0;
            outReal[outIdx] = c1 * e6 + c2 * e5 + c3 * e4 + c4 * e3;
            outIdx++;
            while (true)
            {
                if (today > endIdx)
                {
                    break;
                }

                e1 = k * inReal[today] + one_minus_k * e1;
                today++;
                e2 = k * e1 + one_minus_k * e2;
                e3 = k * e2 + one_minus_k * e3;
                e4 = k * e3 + one_minus_k * e4;
                e5 = k * e4 + one_minus_k * e5;
                e6 = k * e5 + one_minus_k * e6;
                outReal[outIdx] = c1 * e6 + c2 * e5 + c3 * e4 + c4 * e3;
                outIdx++;
            }

            outNBElement = outIdx;
            return RetCode.Success;
        }

        public static int T3Lookback(int optInTimePeriod, double optInVFactor)
        {
            if (optInTimePeriod is < 2 or > 100000)
            {
                return -1;
            }

            if (optInVFactor is < 0.0 or > 1.0)
            {
                return -1;
            }

            return (optInTimePeriod - 1) * 6 + (int)Globals.unstablePeriod[22];
        }
    }
}
