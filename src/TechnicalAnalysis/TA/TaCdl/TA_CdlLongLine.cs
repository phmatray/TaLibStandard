using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlLongLine(
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
            int lookbackTotal = CdlLongLineLookback();

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
            int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double shadowPeriodTotal = 0.0;
            int shadowTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowShort);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowTrailingIdx;
            while (i < startIdx)
            {
                shadowPeriodTotal += GetCandleRange(ShadowShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - long real body
             * - short upper and lower shadow
             * The meaning of "long" and "short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when white (bullish), negative (-1 to -100) when black (bearish)
             */
            int outIdx = 0;
            do
            {
                bool isLongLine =
                    GetRealBody(i, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowShort, shadowPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetLowerShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowShort, shadowPeriodTotal, i, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isLongLine ? GetCandleColor(i, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowPeriodTotal +=
                    GetCandleRange(ShadowShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowShort, shadowTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyTrailingIdx++;
                shadowTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlLongLineLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyLong), GetCandleAvgPeriod(ShadowShort));
        }
    }
}
