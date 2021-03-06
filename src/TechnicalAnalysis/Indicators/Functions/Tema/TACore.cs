using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Tema(
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

            outNBElement = 0;
            outBegIdx = 0;
            int lookbackEMA = EmaLookback(optInTimePeriod);
            int lookbackTotal = lookbackEMA * 3;
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            if (startIdx <= endIdx)
            {
                int firstEMANbElement = 0;
                int thirdEMANbElement = 0;
                int thirdEMABegIdx = 0;
                int secondEMANbElement = 0;
                int secondEMABegIdx = 0;
                int firstEMABegIdx = 0;
                int tempInt = lookbackTotal + (endIdx - startIdx) + 1;
                double[] firstEMA = new double[tempInt];

                double k = 2.0 / (optInTimePeriod + 1);
                RetCode retCode = TA_INT_EMA(
                    startIdx - lookbackEMA * 2,
                    endIdx,
                    inReal,
                    optInTimePeriod,
                    k,
                    ref firstEMABegIdx,
                    ref firstEMANbElement,
                    firstEMA);
                if (retCode != RetCode.Success || firstEMANbElement == 0)
                {
                    return retCode;
                }

                double[] secondEMA = new double[firstEMANbElement];

                retCode = TA_INT_EMA(
                    0,
                    firstEMANbElement - 1,
                    firstEMA,
                    optInTimePeriod,
                    k,
                    ref secondEMABegIdx,
                    ref secondEMANbElement,
                    secondEMA);
                if (retCode != RetCode.Success || secondEMANbElement == 0)
                {
                    return retCode;
                }

                retCode = TA_INT_EMA(
                    0,
                    secondEMANbElement - 1,
                    secondEMA,
                    optInTimePeriod,
                    k,
                    ref thirdEMABegIdx,
                    ref thirdEMANbElement,
                    outReal);
                if (retCode != RetCode.Success || thirdEMANbElement == 0)
                {
                    return retCode;
                }

                int firstEMAIdx = thirdEMABegIdx + secondEMABegIdx;
                int secondEMAIdx = thirdEMABegIdx;
                outBegIdx = firstEMAIdx + firstEMABegIdx;
                int outIdx = 0;
                while (true)
                {
                    if (outIdx >= thirdEMANbElement)
                    {
                        break;
                    }

                    outReal[outIdx] += 3.0 * firstEMA[firstEMAIdx] - 3.0 * secondEMA[secondEMAIdx];
                    secondEMAIdx++;
                    firstEMAIdx++;
                    outIdx++;
                }

                outNBElement = outIdx;
            }

            return RetCode.Success;
        }

        public static int TemaLookback(int optInTimePeriod)
        {
            if (optInTimePeriod is < 2 or > 100000)
            {
                return -1;
            }

            return EmaLookback(optInTimePeriod) * 3;
        }
    }
}
