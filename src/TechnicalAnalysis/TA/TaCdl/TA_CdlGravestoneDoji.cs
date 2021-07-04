using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlGravestoneDoji(
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
            int lookbackTotal = CdlGravestoneDojiLookback();

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
            double bodyDojiPeriodTotal = 0.0;
            int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - open and close at the low of the day = no or very short lower shadow
             * - upper shadow (to distinguish from other dojis, here upper shadow should not be very short)
             * The meaning of "doji" and "very short" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: gravestone doji must be considered
             * relatively to the trend
             */
            int outIdx = 0;
            do
            {
                bool isGravestoneDoji =
                    GetRealBody(i, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetLowerShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isGravestoneDoji ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyDojiTrailingIdx++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlGravestoneDojiLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(ShadowVeryShort));
        }
    }
}
