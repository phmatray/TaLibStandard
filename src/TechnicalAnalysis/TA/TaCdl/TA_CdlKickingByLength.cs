using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlKickingByLength(
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
            double[] bodyLongPeriodTotal = new double[2];
            
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
            int lookbackTotal = CdlKickingByLengthLookback();

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
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: marubozu
             * - second candle: opposite color marubozu
             * - gap between the two candles: upside gap if black then white, downside gap if white then black
             * The meaning of "long body" and "very short shadow" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; the longer of the two
             * marubozu determines the bullishness or bearishness of this pattern
             */
            int outIdx = 0;
            do
            {
                bool isKickingByLength =
                    // opposite candles
                    GetCandleColor(i - 1, inOpen, inClose) == -GetCandleColor(i, inOpen, inClose) &&
                    // 1st marubozu
                    GetRealBody(i - 1, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i - 1, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    GetLowerShadow(i - 1, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 2nd marubozu
                    GetRealBody(i, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    GetLowerShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    // gap
                    (
                        (GetCandleColor(i - 1, inOpen, inClose) == -1 && GetCandleGapUp(i, i - 1, inHigh, inLow)) ||
                        (GetCandleColor(i - 1, inOpen, inClose) == 1 && GetCandleGapDown(i, i - 1, inHigh, inLow))
                    );

                outInteger[outIdx++] = isKickingByLength
                    ? GetCandleColor(
                        (GetRealBody(i, inOpen, inClose) > GetRealBody(i - 1, inOpen, inClose) ? i : i - 1), inOpen, inClose) * 100
                    : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);

                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                i++;
                shadowVeryShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlKickingByLengthLookback()
        {
            return Math.Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
