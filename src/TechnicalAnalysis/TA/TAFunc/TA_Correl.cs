using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Correl(
            int startIdx,
            int endIdx,
            in double[] inReal0,
            in double[] inReal1,
            in int optInTimePeriod,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
            double y;
            double x;
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inReal0 == null)
            {
                return RetCode.BadParam;
            }

            if (inReal1 == null)
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

            outBegIdx = startIdx;
            int trailingIdx = startIdx - lookbackTotal;
            double sumY2 = 0.0;
            double sumX2 = sumY2;
            double sumY = sumX2;
            double sumX = sumY;
            double sumXY = sumX;
            int today = trailingIdx;
            while (today <= startIdx)
            {
                x = inReal0[today];
                sumX += x;
                sumX2 += x * x;
                y = inReal1[today];
                sumXY += x * y;
                sumY += y;
                sumY2 += y * y;
                today++;
            }

            double trailingX = inReal0[trailingIdx];
            double trailingY = inReal1[trailingIdx];
            trailingIdx++;
            double tempReal = (sumX2 - sumX * sumX / optInTimePeriod)
                              * (sumY2 - sumY * sumY / optInTimePeriod);
            if (tempReal >= 1E-08)
            {
                outReal[0] = (sumXY - sumX * sumY / optInTimePeriod) / Math.Sqrt(tempReal);
            }
            else
            {
                outReal[0] = 0.0;
            }

            int outIdx = 1;
            while (today <= endIdx)
            {
                sumX -= trailingX;
                sumX2 -= trailingX * trailingX;
                sumXY -= trailingX * trailingY;
                sumY -= trailingY;
                sumY2 -= trailingY * trailingY;
                x = inReal0[today];
                sumX += x;
                sumX2 += x * x;
                y = inReal1[today];
                today++;
                sumXY += x * y;
                sumY += y;
                sumY2 += y * y;
                trailingX = inReal0[trailingIdx];
                trailingY = inReal1[trailingIdx];
                trailingIdx++;
                tempReal = (sumX2 - sumX * sumX / optInTimePeriod)
                           * (sumY2 - sumY * sumY / optInTimePeriod);
                if (tempReal >= 1E-08)
                {
                    outReal[outIdx] = (sumXY - sumX * sumY / optInTimePeriod) / Math.Sqrt(tempReal);
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }
            }

            outNBElement = outIdx;
            return RetCode.Success;
        }

        public static int CorrelLookback(int optInTimePeriod)
        {
            if (optInTimePeriod is < 1 or > 100000)
            {
                return -1;
            }

            return optInTimePeriod - 1;
        }
    }
}
