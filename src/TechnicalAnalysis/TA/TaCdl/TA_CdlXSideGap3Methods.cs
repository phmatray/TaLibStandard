using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlXSideGap3Methods(
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
            int lookbackTotal = CdlXSideGap3MethodsLookback();

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
            int i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: white (black) candle
             * - second candle: white (black) candle
             * - upside (downside) gap between the first and the second real bodies
             * - third candle: black (white) candle that opens within the second real body and closes within the first real body
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that up/downside gap 3 methods is significant when it appears in a trend, while this 
             * function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isXSideGap3Methods =
                    // 1st and 2nd of same color
                    GetCandleColor(i - 2, inOpen, inClose) == GetCandleColor(i - 1, inOpen, inClose) &&
                    // 3rd opposite color
                    GetCandleColor(i - 1, inOpen, inClose) == -GetCandleColor(i, inOpen, inClose) &&
                    // 3rd opens within 2nd rb
                    inOpen[i] < Math.Max(inClose[i - 1], inOpen[i - 1]) &&
                    inOpen[i] > Math.Min(inClose[i - 1], inOpen[i - 1]) &&
                    // 3rd closes within 1st rb
                    inClose[i] < Math.Max(inClose[i - 2], inOpen[i - 2]) &&
                    inClose[i] > Math.Min(inClose[i - 2], inOpen[i - 2]) &&
                    ((
                         // when 1st is white
                         GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                         // upside gap
                         GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose)
                     ) ||
                     (
                         // when 1st is black
                         GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                         // downside gap
                         GetRealBodyGapDown(i - 1, i - 2, inOpen, inClose)
                     )
                    );

                outInteger[outIdx++] = isXSideGap3Methods ? GetCandleColor(i - 2, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlXSideGap3MethodsLookback()
        {
            return 2;
        }
    }
}
