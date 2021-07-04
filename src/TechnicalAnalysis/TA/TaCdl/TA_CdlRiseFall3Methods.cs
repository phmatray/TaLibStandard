using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlRiseFall3Methods(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] bodyPeriodTotal = new double[5];

            // Validate the requested output range.
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            // Verify required price component.
            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlRiseFall3MethodsLookback();

            // Move up the start index if there is not enough initial data.
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            // Make sure there is still something to evaluate.
            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            // Do the calculation using tight loops.
            // Add-up the initial period, except for the last value.
            bodyPeriodTotal[4] = 0.0;
            bodyPeriodTotal[3] = 0.0;
            bodyPeriodTotal[2] = 0.0;
            bodyPeriodTotal[1] = 0.0;
            bodyPeriodTotal[0] = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[3] += GetCandleRange(BodyShort, i - 3, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[2] += GetCandleRange(BodyShort, i - 2, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[1] += GetCandleRange(BodyShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[4] += GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[0] += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) candlestick
             * - then: group of falling (rising) small real body candlesticks (commonly black (white)) that hold within 
             *   the prior long candle's range: ideally they should be three but two or more than three are ok too
             * - final candle: long white (black) candle that opens above (below) the previous small candle's close 
             *   and closes above (below) the first long candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings; here only patterns with 3 small candles
             * are considered;
             * outInteger is positive (1 to 100) or negative (-1 to -100)
             */
            int outIdx = 0;
            do
            {
                bool isRiseFall3Methods =
                    // 1st long, then 3 small, 5th long
                    GetRealBody(i - 4, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyPeriodTotal[4], i - 4, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i - 3, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal[3], i - 3, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i - 2, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i - 1, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    // white, 3 black, white  ||  black, 3 white, black
                    GetCandleColor(i - 4, inOpen, inClose) == -GetCandleColor(i - 3, inOpen, inClose) &&
                    GetCandleColor(i - 3, inOpen, inClose) == GetCandleColor(i - 2, inOpen, inClose) &&
                    GetCandleColor(i - 2, inOpen, inClose) == GetCandleColor(i - 1, inOpen, inClose) &&
                    GetCandleColor(i - 1, inOpen, inClose) == -GetCandleColor(i, inOpen, inClose) &&
                    // 2nd to 4th hold within 1st: a part of the real body must be within 1st range
                    Math.Min(inOpen[i - 3], inClose[i - 3]) < inHigh[i - 4] &&
                    Math.Max(inOpen[i - 3], inClose[i - 3]) > inLow[i - 4] &&
                    Math.Min(inOpen[i - 2], inClose[i - 2]) < inHigh[i - 4] &&
                    Math.Max(inOpen[i - 2], inClose[i - 2]) > inLow[i - 4] &&
                    Math.Min(inOpen[i - 1], inClose[i - 1]) < inHigh[i - 4] &&
                    Math.Max(inOpen[i - 1], inClose[i - 1]) > inLow[i - 4] &&
                    // 2nd to 4th are falling (rising)
                    inClose[i - 2] * GetCandleColor(i - 4, inOpen, inClose) <
                    inClose[i - 3] * GetCandleColor(i - 4, inOpen, inClose) &&
                    inClose[i - 1] * GetCandleColor(i - 4, inOpen, inClose) <
                    inClose[i - 2] * GetCandleColor(i - 4, inOpen, inClose) &&
                    // 5th opens above (below) the prior close
                    inOpen[i] * GetCandleColor(i - 4, inOpen, inClose) >
                    inClose[i - 1] * GetCandleColor(i - 4, inOpen, inClose) &&
                    // 5th closes above (below) the 1st close
                    inClose[i] * GetCandleColor(i - 4, inOpen, inClose) >
                    inClose[i - 4] * GetCandleColor(i - 4, inOpen, inClose);

                outInteger[outIdx++] = isRiseFall3Methods ? 100 * GetCandleColor(i - 4, inOpen, inClose) : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal[4] +=
                    GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 4, inOpen, inHigh, inLow, inClose);

                for (int totIdx = 3; totIdx >= 1; --totIdx)
                {
                    bodyPeriodTotal[totIdx] +=
                        GetCandleRange(BodyShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                bodyPeriodTotal[0] +=
                    GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlRiseFall3MethodsLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 4;
        }
    }
}
