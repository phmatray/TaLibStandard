using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Dema(
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
        int lookbackEMA = new EmaLookback(optInTimePeriod).Result;
        int lookbackTotal = lookbackEMA * 2;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx <= endIdx)
        {
            double[] firstEMA;
            int firstEMANbElement = 0;
            int secondEMANbElement = 0;
            int secondEMABegIdx = 0;
            int firstEMABegIdx = 0;
            if (inReal == outReal)
            {
                firstEMA = outReal;
            }
            else
            {
                int tempInt = lookbackTotal + (endIdx - startIdx) + 1;
                firstEMA = new double[tempInt];
            }

            double k = 2.0 / (optInTimePeriod + 1);
            RetCode retCode = TA_INT_EMA(
                startIdx - lookbackEMA,
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

            int firstEMAIdx = secondEMABegIdx;
            int outIdx = 0;
            while (true)
            {
                if (outIdx >= secondEMANbElement)
                {
                    break;
                }

                outReal[outIdx] = 2.0 * firstEMA[firstEMAIdx] - secondEMA[outIdx];
                firstEMAIdx++;
                outIdx++;
            }

            outBegIdx = firstEMABegIdx + secondEMABegIdx;
            outNBElement = outIdx;
        }

        return RetCode.Success;
    }
}
