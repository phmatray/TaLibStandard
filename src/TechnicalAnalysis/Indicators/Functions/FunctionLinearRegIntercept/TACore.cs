using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionLinearRegIntercept;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode LinearRegIntercept(
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

        int lookbackTotal = new LinearRegInterceptLookback(optInTimePeriod).Result;
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
        int today = startIdx;
        double SumX = optInTimePeriod * (optInTimePeriod - 1) * 0.5;
        double SumXSqr = optInTimePeriod * (optInTimePeriod - 1) * (optInTimePeriod * 2 - 1) / 6;
        double Divisor = SumX * SumX - optInTimePeriod * SumXSqr;
        while (true)
        {
            if (today > endIdx)
            {
                outBegIdx = startIdx;
                outNBElement = outIdx;
                return RetCode.Success;
            }

            double SumXY = 0.0;
            double SumY = 0.0;
            int i = optInTimePeriod;
            while (true)
            {
                i--;
                if (i == 0)
                {
                    break;
                }

                double tempValue1 = inReal[today - i];
                SumY += tempValue1;
                SumXY += i * tempValue1;
            }

            double m = (optInTimePeriod * SumXY - SumX * SumY) / Divisor;
            outReal[outIdx] = (SumY - m * SumX) / optInTimePeriod;
            outIdx++;
            today++;
        }
    }
}
