using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in double[] inPeriods,
        in int optInMinPeriod,
        in int optInMaxPeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        int tempInt = 0;
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

        if (inPeriods == null)
        {
            return RetCode.BadParam;
        }

        if (optInMinPeriod is < 2 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (optInMaxPeriod is < 2 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (outReal == null)
        {
            return RetCode.BadParam;
        }

        int lookbackTotal = new MovingAverageLookback(optInMaxPeriod, optInMAType).Result;
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

        if (lookbackTotal > startIdx)
        {
            tempInt = lookbackTotal;
        }
        else
        {
            tempInt = startIdx;
        }

        if (tempInt > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return RetCode.Success;
        }

        int outputSize = endIdx - tempInt + 1;
        double[] localOutputArray = new double[outputSize];
        int[] localPeriodArray = new int[outputSize];
        for (i = 0; i < outputSize; i++)
        {
            tempInt = (int)inPeriods[startIdx + i];
            if (tempInt < optInMinPeriod)
            {
                tempInt = optInMinPeriod;
            }
            else if (tempInt > optInMaxPeriod)
            {
                tempInt = optInMaxPeriod;
            }

            localPeriodArray[i] = tempInt;
        }

        i = 0;
        while (true)
        {
            if (i >= outputSize)
            {
                outBegIdx = startIdx;
                outNBElement = outputSize;
                return RetCode.Success;
            }

            int curPeriod = localPeriodArray[i];
            if (curPeriod != 0)
            {
                int localNbElement = 0;
                int localBegIdx = 0;
                RetCode retCode = TACore.MovingAverage(
                    startIdx,
                    endIdx,
                    inReal,
                    curPeriod,
                    optInMAType,
                    ref localBegIdx,
                    ref localNbElement,
                    ref localOutputArray);
                if (retCode != RetCode.Success)
                {
                    outBegIdx = 0;
                    outNBElement = 0;
                    return retCode;
                }

                outReal[i] = localOutputArray[i];
                for (int j = i + 1; j < outputSize; j++)
                {
                    if (localPeriodArray[j] == curPeriod)
                    {
                        localPeriodArray[j] = 0;
                        outReal[j] = localOutputArray[j];
                    }
                }
            }

            i++;
        }
    }
}
