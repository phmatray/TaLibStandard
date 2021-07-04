using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHaramiCross(
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
            int lookbackTotal = CdlHaramiCrossLookback();

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
            int bodyLongTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyLong);
            int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) real body
             * - second candle: doji totally engulfed by the first
             * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; 
             * the user should consider that a harami cross is significant when it appears in a downtrend if bullish or 
             * in an uptrend when bearish, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isHaramiCross =
                    // 1st: long
                    GetRealBody(i - 1, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: doji
                    GetRealBody(i, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // engulfed by 1st
                    Math.Max(inClose[i], inOpen[i]) < Math.Max(inClose[i - 1], inOpen[i - 1]) &&
                    Math.Min(inClose[i], inOpen[i]) > Math.Min(inClose[i - 1], inOpen[i - 1]);

                outInteger[outIdx++] = isHaramiCross ? -GetCandleColor(i - 1, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
                bodyDojiTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHaramiCrossLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
