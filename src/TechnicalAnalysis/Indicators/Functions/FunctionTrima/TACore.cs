using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Trima(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        double tempReal;
        double numerator;
        double numeratorAdd;
        double numeratorSub;
        int middleIdx;
        int trailingIdx;
        int todayIdx;
        double factor;
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

        int outIdx = 0;
        if (optInTimePeriod % 2 != 1)
        {
            i = optInTimePeriod >> 1;
            factor = i * (i + 1);
            factor = 1.0 / factor;
            trailingIdx = startIdx - lookbackTotal;
            middleIdx = trailingIdx + i - 1;
            todayIdx = middleIdx + i;
            numerator = 0.0;
            numeratorSub = 0.0;
            i = middleIdx;
            while (i >= trailingIdx)
            {
                tempReal = inReal[i];
                numeratorSub += tempReal;
                numerator += numeratorSub;
                i--;
            }

            numeratorAdd = 0.0;
            middleIdx++;
            for (i = middleIdx; i <= todayIdx; i++)
            {
                tempReal = inReal[i];
                numeratorAdd += tempReal;
                numerator += numeratorAdd;
            }

            outIdx = 0;
            tempReal = inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = numerator * factor;
            outIdx++;
            todayIdx++;
            while (todayIdx <= endIdx)
            {
                numerator -= numeratorSub;
                numeratorSub -= tempReal;
                tempReal = inReal[middleIdx];
                middleIdx++;
                numeratorSub += tempReal;
                numeratorAdd -= tempReal;
                numerator += numeratorAdd;
                tempReal = inReal[todayIdx];
                todayIdx++;
                numeratorAdd += tempReal;
                numerator += tempReal;
                tempReal = inReal[trailingIdx];
                trailingIdx++;
                outReal[outIdx] = numerator * factor;
                outIdx++;
            }
        }
        else
        {
            i = optInTimePeriod >> 1;
            factor = (i + 1) * (i + 1);
            factor = 1.0 / factor;
            trailingIdx = startIdx - lookbackTotal;
            middleIdx = trailingIdx + i;
            todayIdx = middleIdx + i;
            numerator = 0.0;
            numeratorSub = 0.0;
            for (i = middleIdx; i >= trailingIdx; i--)
            {
                tempReal = inReal[i];
                numeratorSub += tempReal;
                numerator += numeratorSub;
            }

            numeratorAdd = 0.0;
            middleIdx++;
            for (i = middleIdx; i <= todayIdx; i++)
            {
                tempReal = inReal[i];
                numeratorAdd += tempReal;
                numerator += numeratorAdd;
            }

            outIdx = 0;
            tempReal = inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = numerator * factor;
            outIdx++;
            todayIdx++;
            while (todayIdx <= endIdx)
            {
                numerator -= numeratorSub;
                numeratorSub -= tempReal;
                tempReal = inReal[middleIdx];
                middleIdx++;
                numeratorSub += tempReal;
                numerator += numeratorAdd;
                numeratorAdd -= tempReal;
                tempReal = inReal[todayIdx];
                todayIdx++;
                numeratorAdd += tempReal;
                numerator += tempReal;
                tempReal = inReal[trailingIdx];
                trailingIdx++;
                outReal[outIdx] = numerator * factor;
                outIdx++;
            }
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return RetCode.Success;
    }
}
