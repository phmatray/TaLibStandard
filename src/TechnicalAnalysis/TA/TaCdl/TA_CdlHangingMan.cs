using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHangingMan(
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
            int lookbackTotal = CdlHangingManLookback();

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
            double bodyPeriodTotal = 0.0;
            int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(Near);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += GetCandleRange(ShadowLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx - 1)
            {
                nearPeriodTotal += GetCandleRange(Near, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - small real body
             * - long lower shadow
             * - no, or very short, upper shadow
             * - body above or near the highs of the previous candle
             * The meaning of "short", "long" and "near the highs" is specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): hanging man is always bearish;
             * the user should consider that a hanging man must appear in an uptrend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isHangingMan =
                    // small rb
                    GetRealBody(i, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // long lower shadow
                    GetLowerShadow(i, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // very short upper shadow
                    GetUpperShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // rb near the prior candle's highs
                    Math.Min(inClose[i], inOpen[i]) >=
                    inHigh[i - 1] - GetCandleAverage(Near, nearPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isHangingMan ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                nearPeriodTotal +=
                    GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Near, nearTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyTrailingIdx++;
                shadowLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHangingManLookback()
        {
            return Math.Max(
                Math.Max(
                    Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(ShadowLong)),
                    GetCandleAvgPeriod(ShadowVeryShort)),
                GetCandleAvgPeriod(Near)
            ) + 1;
        }
    }
}
