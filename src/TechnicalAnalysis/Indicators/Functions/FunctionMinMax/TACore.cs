using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MinMax(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMin,
        ref double[] outMax)
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

        if (outMin == null)
        {
            return RetCode.BadParam;
        }

        if (outMax == null)
        {
            return RetCode.BadParam;
        }

        int nbInitialElementNeeded = optInTimePeriod - 1;
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return RetCode.Success;
        }

        int outIdx = 0;
        int today = startIdx;
        int trailingIdx = startIdx - nbInitialElementNeeded;
        int highestIdx = -1;
        double highest = 0.0;
        int lowestIdx = -1;
        double lowest = 0.0;
        Label_00A5:
        if (today > endIdx)
        {
            outBegIdx = startIdx;
            outNBElement = outIdx;
            return RetCode.Success;
        }

        double tmpHigh = inReal[today];
        double tmpLow = tmpHigh;
        if (highestIdx < trailingIdx)
        {
            highestIdx = trailingIdx;
            highest = inReal[highestIdx];
            i = highestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_00EC;
                }

                tmpHigh = inReal[i];
                if (tmpHigh > highest)
                {
                    highestIdx = i;
                    highest = tmpHigh;
                }
            }
        }

        if (tmpHigh >= highest)
        {
            highestIdx = today;
            highest = tmpHigh;
        }

        Label_00EC:
        if (lowestIdx < trailingIdx)
        {
            lowestIdx = trailingIdx;
            lowest = inReal[lowestIdx];
            i = lowestIdx;
            while (true)
            {
                i++;
                if (i > today)
                {
                    goto Label_012A;
                }

                tmpLow = inReal[i];
                if (tmpLow < lowest)
                {
                    lowestIdx = i;
                    lowest = tmpLow;
                }
            }
        }

        if (tmpLow <= lowest)
        {
            lowestIdx = today;
            lowest = tmpLow;
        }

        Label_012A:
        outMax[outIdx] = highest;
        outMin[outIdx] = lowest;
        outIdx++;
        trailingIdx++;
        today++;
        goto Label_00A5;
    }
}
