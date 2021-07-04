using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlStalledPattern(
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
            double[] bodyLongPeriodTotal = new double[3];
            double[] nearPeriodTotal = new double[3];
            
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
            int lookbackTotal = CdlStalledPatternLookback();

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
            bodyLongPeriodTotal[2] = 0.0;
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[2] += GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose);
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                nearPeriodTotal[1] += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white candlesticks with consecutively higher closes
             * - first candle: long white
             * - second candle: long white with no or very short upper shadow opening within or near the previous white real body
             * and closing higher than the prior candle
             * - third candle: small white that gaps away or "rides on the shoulder" of the prior long real body (= it's at 
             * the upper end of the prior real body)
             * The meanings of "long", "very short", "short", "near" are specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): stalled pattern is always bearish;
             * the user should consider that stalled pattern is significant when it appears in uptrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isStalledPattern =
                    // 1st white
                    GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                    // 2nd white
                    GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                    // 3rd white
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // consecutive higher closes
                    inClose[i] > inClose[i - 1] &&
                    inClose[i - 1] > inClose[i - 2] &&
                    // 1st: long real body
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: long real body
                    GetRealBody(i - 1, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // very short upper shadow 
                    GetUpperShadow(i - 1, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // opens within/near 1st real body
                    inOpen[i - 1] > inOpen[i - 2] &&
                    inOpen[i - 1] <= inClose[i - 2] +
                    GetCandleAverage(Near, nearPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 3rd: small real body
                    GetRealBody(i, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // rides on the shoulder of 2nd real body
                    inOpen[i] >= inClose[i - 1] - GetRealBody(i, inOpen, inClose) -
                    GetCandleAverage(Near, nearPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isStalledPattern ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);

                    nearPeriodTotal[totIdx] +=
                        GetCandleRange(Near, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(Near, nearTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlStalledPatternLookback()
        {
            return Math.Max(
                Math.Max(GetCandleAvgPeriod(BodyLong), GetCandleAvgPeriod(BodyShort)),
                Math.Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(Near))
            ) + 2;
        }
    }
}
