using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHarami(
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
            int lookbackTotal = CdlHaramiLookback();

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
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
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
             * - second candle: short real body totally engulfed by the first
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; 
             * the user should consider that a harami is significant when it appears in a downtrend if bullish or 
             * in an uptrend when bearish, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isHarami =
                    // 1st: long
                    GetRealBody(i - 1, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: short
                    GetRealBody(i, inOpen, inClose) <=
                    GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // engulfed by 1st
                    Math.Max(inClose[i], inOpen[i]) < Math.Max(inClose[i - 1], inOpen[i - 1]) &&
                    Math.Min(inClose[i], inOpen[i]) > Math.Min(inClose[i - 1], inOpen[i - 1]);

                outInteger[outIdx++] = isHarami ? -GetCandleColor(i - 1, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHaramiLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
