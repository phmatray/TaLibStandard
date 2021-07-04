using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlAbandonedBaby(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            in double optInPenetration,
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

            if (optInPenetration < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlAbandonedBabyLookback(optInPenetration);

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
            double bodyDojiPeriodTotal = 0.0;
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyDojiTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyDoji);
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
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
             * - first candle: long white (black) real body
             * - second candle: doji
             * - third candle: black (white) real body that moves well within the first candle's real body
             * - upside (downside) gap between the first candle and the doji (the shadows of the two candles don't touch)
             * - downside (upside) gap between the doji and the third candle (the shadows of the two candles don't touch)
             * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
             * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
             * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
             * it to be relatively long
             * outInteger is positive (1 to 100) when it's an abandoned baby bottom or negative (-1 to -100) when it's 
             * an abandoned baby top; the user should consider that an abandoned baby is significant when it appears in 
             * an uptrend or downtrend, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isAbandonedBaby =
                    // 1st: long
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: doji
                    GetRealBody(i - 1, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 3rd: longer than short
                    GetRealBody(i, inOpen, inClose) >
                    GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    (
                        (
                            // 1st white
                            GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                            // 3rd black
                            GetCandleColor(i, inOpen, inClose) == -1 &&
                            // 3rd closes well within 1st rb
                            inClose[i] < inClose[i - 2] - GetRealBody(i - 2, inOpen, inClose) * optInPenetration &&
                            // upside gap between 1st and 2nd
                            GetCandleGapUp(i - 1, i - 2, inHigh, inLow) &&
                            // downside gap between 2nd and 3rd
                            GetCandleGapDown(i, i - 1, inHigh, inLow)
                        )
                        ||
                        (
                            // 1st black
                            GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                            // 3rd white
                            GetCandleColor(i, inOpen, inClose) == 1 &&
                            // 3rd closes well within 1st rb
                            inClose[i] > inClose[i - 2] + GetRealBody(i - 2, inOpen, inClose) * optInPenetration &&
                            // downside gap between 1st and 2nd
                            GetCandleGapDown(i - 1, i - 2, inHigh, inLow) &&
                            // upside gap between 2nd and 3rd
                            GetCandleGapUp(i, i - 1, inHigh, inLow)
                        )
                    );

                outInteger[outIdx++] = isAbandonedBaby ? GetCandleColor(i, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
                bodyDojiTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlAbandonedBabyLookback(double optInPenetration)
        {
            return Math.Max(
                Math.Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(BodyLong)),
                GetCandleAvgPeriod(BodyShort)
            ) + 2;
        }
    }
}
