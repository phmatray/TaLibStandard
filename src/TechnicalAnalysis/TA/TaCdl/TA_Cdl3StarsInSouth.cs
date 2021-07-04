using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3StarsInSouth(
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
            double[] shadowVeryShortPeriodTotal = new double[2];

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
            int lookbackTotal = Cdl3StarsInSouthLookback();

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
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += GetCandleRange(ShadowLong, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle with long lower shadow
             * - second candle: smaller black candle that opens higher than prior close but within prior candle's range 
             *   and trades lower than prior close but not lower than prior low and closes off of its low (it has a shadow)
             * - third candle: small black marubozu (or candle with very short shadows) engulfed by prior candle's range
             * The meanings of "long body", "short body", "very short shadow" are specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): 3 stars in the south is always bullish;
             * the user should consider that 3 stars in the south is significant when it appears in downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3StarsInSouth =
                    // 1st black
                    GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                    // 2nd black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // 3rd black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // 1st: long
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // with long lower shadow
                    GetLowerShadow(i - 2, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: smaller candle
                    GetRealBody(i - 1, inOpen, inClose) < GetRealBody(i - 2, inOpen, inClose) &&
                    // that opens higher but within 1st range
                    inOpen[i - 1] > inClose[i - 2] &&
                    inOpen[i - 1] <= inHigh[i - 2] &&
                    // and trades lower than 1st close
                    inLow[i - 1] < inClose[i - 2] &&
                    // but not lower than 1st low
                    inLow[i - 1] >= inLow[i - 2] &&
                    // and has a lower shadow
                    GetLowerShadow(i - 1, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 3rd: small marubozu
                    GetRealBody(i, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetLowerShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    // engulfed by prior candle's range
                    inLow[i] > inLow[i - 1] && inHigh[i] < inHigh[i - 1];

                outInteger[outIdx++] = is3StarsInSouth ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 2, inOpen, inHigh, inLow, inClose);

                shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx - 2, inOpen, inHigh, inLow, inClose);

                int totIdx;
                for (totIdx = 1; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
                shadowLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3StarsInSouthLookback()
        {
            return Math.Max(
                Math.Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(ShadowLong)),
                Math.Max(GetCandleAvgPeriod(BodyLong), GetCandleAvgPeriod(BodyShort))
            ) + 2;
        }
    }
}
