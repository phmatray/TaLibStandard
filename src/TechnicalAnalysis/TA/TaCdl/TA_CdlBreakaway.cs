using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlBreakaway(
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
            int lookbackTotal = CdlBreakawayLookback();

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
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black (white)
             * - second candle: black (white) day whose body gaps down (up)
             * - third candle: black or white day with lower (higher) high and lower (higher) low than prior candle's
             * - fourth candle: black (white) day with lower (higher) high and lower (higher) low than prior candle's
             * - fifth candle: white (black) day that closes inside the gap, erasing the prior 3 days
             * The meaning of "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that breakaway is significant in a trend opposite to the last candle, while this 
             * function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isBreakaway =
                    // 1st long
                    GetRealBody(i - 4, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 4, inOpen, inHigh, inLow, inClose) &&
                    // 1st, 2nd, 4th same color, 5th opposite
                    GetCandleColor(i - 4, inOpen, inClose) == GetCandleColor(i - 3, inOpen, inClose) &&
                    GetCandleColor(i - 3, inOpen, inClose) == GetCandleColor(i - 1, inOpen, inClose) &&
                    GetCandleColor(i - 1, inOpen, inClose) == -GetCandleColor(i, inOpen, inClose) &&
                    (
                        (
                            // when 1st is black:
                            GetCandleColor(i - 4, inOpen, inClose) == -1 &&
                            // 2nd gaps down
                            GetRealBodyGapDown(i - 3, i - 4, inOpen, inClose) &&
                            // 3rd has lower high and low than 2nd
                            inHigh[i - 2] < inHigh[i - 3] &&
                            inLow[i - 2] < inLow[i - 3] &&
                            // 4th has lower high and low than 3rd
                            inHigh[i - 1] < inHigh[i - 2] &&
                            inLow[i - 1] < inLow[i - 2] &&
                            // 5th closes inside the gap
                            inClose[i] > inOpen[i - 3] &&
                            inClose[i] < inClose[i - 4]
                        )
                        ||
                        (
                            // when 1st is white:
                            GetCandleColor(i - 4, inOpen, inClose) == 1 &&
                            // 2nd gaps up
                            GetRealBodyGapUp(i - 3, i - 4, inOpen, inClose) &&
                            // 3rd has higher high and low than 2nd
                            inHigh[i - 2] > inHigh[i - 3] &&
                            inLow[i - 2] > inLow[i - 3] &&
                            // 4th has higher high and low than 3rd
                            inHigh[i - 1] > inHigh[i - 2] &&
                            inLow[i - 1] > inLow[i - 2] &&
                            // 5th closes inside the gap
                            inClose[i] < inOpen[i - 3] &&
                            inClose[i] > inClose[i - 4]
                        )
                    );

                outInteger[outIdx++] = isBreakaway ? GetCandleColor(i, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 4, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlBreakawayLookback()
        {
            return GetCandleAvgPeriod(BodyLong) + 4;
        }
    }
}
