using System;
using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cci(
            int startIdx,
            int endIdx,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            in int optInTimePeriod,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
            int circBufferIdx = 0;
            int maxIdxCircBuffer = 29;
            
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inHigh == null || inLow == null || inClose == null)
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

            double[] circBuffer = new double[optInTimePeriod];

            maxIdxCircBuffer = optInTimePeriod - 1;
            int i = startIdx - lookbackTotal;
            while (i < startIdx)
            {
                circBuffer[circBufferIdx] = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
                i++;
                circBufferIdx++;
                if (circBufferIdx > maxIdxCircBuffer)
                {
                    circBufferIdx = 0;
                }
            }

            int outIdx = 0;
            do
            {
                double lastValue = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
                circBuffer[circBufferIdx] = lastValue;
                double theAverage = 0.0;
                int j = 0;
                while (j < optInTimePeriod)
                {
                    theAverage += circBuffer[j];
                    j++;
                }

                theAverage /= optInTimePeriod;
                double tempReal2 = 0.0;
                for (j = 0; j < optInTimePeriod; j++)
                {
                    tempReal2 += Math.Abs(circBuffer[j] - theAverage);
                }

                double tempReal = lastValue - theAverage;
                if (tempReal != 0.0 && tempReal2 != 0.0)
                {
                    outReal[outIdx] = tempReal / (0.015 * (tempReal2 / optInTimePeriod));
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }

                circBufferIdx++;
                if (circBufferIdx > maxIdxCircBuffer)
                {
                    circBufferIdx = 0;
                }

                i++;
            }
            while (i <= endIdx);

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CciLookback(int optInTimePeriod)
        {
            if (optInTimePeriod is < 2 or > 100000)
            {
                return -1;
            }

            return optInTimePeriod - 1;
        }
    }
}
