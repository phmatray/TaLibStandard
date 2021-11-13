using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode MinusDI(
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
        double tempReal;
        int today;
        double tempReal2;
        double prevLow;
        double prevHigh;
        double diffM;
        double prevClose;
        double diffP;
        int lookbackTotal;
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return RetCode.BadParam;
        }

        if (outReal == null)
        {
            return RetCode.BadParam;
        }

        if (optInTimePeriod > 1)
        {
            lookbackTotal = optInTimePeriod + (int)TechnicalAnalysis.TACore.Globals.unstablePeriod[15];
        }
        else
        {
            lookbackTotal = 1;
        }

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
        if (optInTimePeriod > 1)
        {
            today = startIdx;
            outBegIdx = today;
            double prevMinusDM = 0.0;
            double prevTR = 0.0;
            today = startIdx - lookbackTotal;
            prevHigh = inHigh[today];
            prevLow = inLow[today];
            prevClose = inClose[today];
            int i = optInTimePeriod - 1;
            while (true)
            {
                i--;
                if (i <= 0)
                {
                    i = (int)TechnicalAnalysis.TACore.Globals.unstablePeriod[15] + 1;
                    while (true)
                    {
                        i--;
                        if (i == 0)
                        {
                            break;
                        }

                        today++;
                        tempReal = inHigh[today];
                        diffP = tempReal - prevHigh;
                        prevHigh = tempReal;
                        tempReal = inLow[today];
                        diffM = prevLow - tempReal;
                        prevLow = tempReal;
                        if (diffM > 0.0 && diffP < diffM)
                        {
                            prevMinusDM = prevMinusDM - prevMinusDM / optInTimePeriod + diffM;
                        }
                        else
                        {
                            prevMinusDM -= prevMinusDM / optInTimePeriod;
                        }

                        tempReal = prevHigh - prevLow;
                        tempReal2 = Math.Abs(prevHigh - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        tempReal2 = Math.Abs(prevLow - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        prevTR = prevTR - prevTR / optInTimePeriod + tempReal;
                        prevClose = inClose[today];
                    }

                    outReal[0] = 100.0 * (prevMinusDM / prevTR);

                    outIdx = 1;
                    while (today < endIdx)
                    {
                        today++;
                        tempReal = inHigh[today];
                        diffP = tempReal - prevHigh;
                        prevHigh = tempReal;
                        tempReal = inLow[today];
                        diffM = prevLow - tempReal;
                        prevLow = tempReal;
                        if (diffM > 0.0 && diffP < diffM)
                        {
                            prevMinusDM = prevMinusDM - prevMinusDM / optInTimePeriod + diffM;
                        }
                        else
                        {
                            prevMinusDM -= prevMinusDM / optInTimePeriod;
                        }

                        tempReal = prevHigh - prevLow;
                        tempReal2 = Math.Abs(prevHigh - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        tempReal2 = Math.Abs(prevLow - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        prevTR = prevTR - prevTR / optInTimePeriod + tempReal;
                        prevClose = inClose[today];
                        outReal[outIdx] = 100.0 * (prevMinusDM / prevTR);
                        outIdx++;
                    }

                    outNBElement = outIdx;
                    return RetCode.Success;
                }

                today++;
                tempReal = inHigh[today];
                diffP = tempReal - prevHigh;
                prevHigh = tempReal;
                tempReal = inLow[today];
                diffM = prevLow - tempReal;
                prevLow = tempReal;
                if (diffM > 0.0 && diffP < diffM)
                {
                    prevMinusDM += diffM;
                }

                tempReal = prevHigh - prevLow;
                tempReal2 = Math.Abs(prevHigh - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                tempReal2 = Math.Abs(prevLow - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                prevTR += tempReal;
                prevClose = inClose[today];
            }
        }

        outBegIdx = startIdx;
        today = startIdx - 1;
        prevHigh = inHigh[today];
        prevLow = inLow[today];
        prevClose = inClose[today];
        while (true)
        {
            if (today >= endIdx)
            {
                break;
            }

            today++;
            tempReal = inHigh[today];
            diffP = tempReal - prevHigh;
            prevHigh = tempReal;
            tempReal = inLow[today];
            diffM = prevLow - tempReal;
            prevLow = tempReal;
            if (diffM > 0.0 && diffP < diffM)
            {
                tempReal = prevHigh - prevLow;
                tempReal2 = Math.Abs(prevHigh - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                tempReal2 = Math.Abs(prevLow - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                outReal[outIdx] = 0.0;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            prevClose = inClose[today];
        }

        outNBElement = outIdx;
        return RetCode.Success;
    }
}
