using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlUpsideGap2Crows(
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
            int lookbackTotal = CdlUpsideGap2CrowsLookback();

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
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: white candle, usually long
             * - second candle: small black real body
             * - gap between the first and the second candle's real bodies
             * - third candle: black candle with a real body that engulfs the preceding candle 
             *   and closes above the white candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): upside gap two crows is always bearish; 
             * the user should consider that an upside gap two crows is significant when it appears in an uptrend, 
             * while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isUpsideGap2Crows =
                    // 1st: white
                    GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                    // long
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // short
                    GetRealBody(i - 1, inOpen, inClose) <=
                    GetCandleAverage(BodyShort, bodyShortPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // gapping up
                    GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose) &&
                    // 3rd: black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // 3rd: engulfing prior rb
                    inOpen[i] > inOpen[i - 1] && inClose[i] < inClose[i - 1] &&
                    // closing above 1st
                    inClose[i] > inClose[i - 2];

                outInteger[outIdx++] = isUpsideGap2Crows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i - 1, inOpen, inHigh, inLow, inClose) -
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

        public static int CdlUpsideGap2CrowsLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 2;
        }
    }
}
