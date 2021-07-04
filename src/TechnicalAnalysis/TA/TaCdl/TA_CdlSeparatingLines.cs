using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlSeparatingLines(
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
            int lookbackTotal = CdlSeparatingLinesLookback();

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
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double equalPeriodTotal = 0.0;
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black (white) candle
             * - second candle: bullish (bearish) belt hold with the same open as the prior candle
             * The meaning of "long body" and "very short shadow" of the belt hold is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that separating lines is significant when coming in a trend and the belt hold has 
             * the same direction of the trend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isSeparatingLines =
                    // opposite candles
                    GetCandleColor(i - 1, inOpen, inClose) == -GetCandleColor(i, inOpen, inClose) &&
                    // same open
                    inOpen[i] <= inOpen[i - 1] +
                    GetCandleAverage(Equal, equalPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    inOpen[i] >= inOpen[i - 1] -
                    GetCandleAverage(Equal, equalPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // belt hold: long body
                    GetRealBody(i, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    (
                        (
                            // with no lower shadow if bullish
                            GetCandleColor(i, inOpen, inClose) == 1 &&
                            GetLowerShadow(i, inOpen, inLow, inClose) <
                            GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, inOpen, inHigh, inLow, inClose)
                        )
                        ||
                        (
                            // with no upper shadow if bearish
                            GetCandleColor(i, inOpen, inClose) == -1 &&
                            GetUpperShadow(i, inOpen, inLow, inClose) <
                            GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, inOpen, inHigh, inLow, inClose)
                        )
                    );

                outInteger[outIdx++] = isSeparatingLines ? GetCandleColor(i, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Equal, equalTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                shadowVeryShortTrailingIdx++;
                bodyLongTrailingIdx++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlSeparatingLinesLookback()
        {
            return Math.Max(
                Math.Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(BodyLong)),
                GetCandleAvgPeriod(Equal)
            ) + 1;
        }
    }
}
