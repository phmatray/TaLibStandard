using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlTasukiGap(
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
            int lookbackTotal = CdlTasukiGapLookback();

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
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - upside (downside) gap
             * - first candle after the window: white (black) candlestick
             * - second candle: black (white) candlestick that opens within the previous real body and closes under (above)
             *   the previous real body inside the gap
             * - the size of two real bodies should be near the same
             * The meaning of "near" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that tasuki gap is significant when it appears in a trend, while this function does 
             * not consider it
             */
            int outIdx = 0;
            do
            {
                bool isTasukiGap =
                    (
                        // upside gap
                        GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose) &&
                        // 1st: white
                        GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                        // 2nd: black
                        GetCandleColor(i, inOpen, inClose) == -1 &&
                        // that opens within the white rb
                        inOpen[i] < inClose[i - 1] && inOpen[i] > inOpen[i - 1] &&
                        // and closes under the white rb
                        inClose[i] < inOpen[i - 1] &&
                        // inside the gap
                        inClose[i] > Math.Max(inClose[i - 2], inOpen[i - 2]) &&
                        // size of 2 rb near the same
                        Math.Abs(GetRealBody(i - 1, inOpen, inClose) - GetRealBody(i, inOpen, inClose)) <
                        GetCandleAverage(Near, nearPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose)
                    ) ||
                    (
                        // downside gap
                        GetRealBodyGapDown(i - 1, i - 2, inOpen, inClose) &&
                        // 1st: black
                        GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                        // 2nd: white
                        GetCandleColor(i, inOpen, inClose) == 1 &&
                        // that opens within the black rb
                        inOpen[i] < inOpen[i - 1] && inOpen[i] > inClose[i - 1] &&
                        // and closes above the black rb
                        inClose[i] > inOpen[i - 1] &&
                        // inside the gap
                        inClose[i] < Math.Min(inClose[i - 2], inOpen[i - 2]) &&
                        // size of 2 rb near the same
                        Math.Abs(GetRealBody(i - 1, inOpen, inClose) - GetRealBody(i, inOpen, inClose)) <
                        GetCandleAverage(Near, nearPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose)
                    );

                outInteger[outIdx++] = isTasukiGap ? GetCandleColor(i - 1, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                nearPeriodTotal +=
                    GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Near, nearTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlTasukiGapLookback()
        {
            return GetCandleAvgPeriod(Near) + 2;
        }
    }
}
