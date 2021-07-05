using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleBreakaway : CandleIndicator
    {
        public CandleBreakaway(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlBreakaway(
            int startIdx,
            int endIdx,
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
            if (open == null || high == null || low == null || close == null)
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
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 4);
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
                    GetRealBody(i - 4) > GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 4) &&
                    // 1st, 2nd, 4th same color, 5th opposite
                    GetCandleColor(i - 4) == GetCandleColor(i - 3) &&
                    GetCandleColor(i - 3) == GetCandleColor(i - 1) &&
                    GetCandleColor(i - 1) == -GetCandleColor(i) &&
                    (
                        (
                            // when 1st is black:
                            GetCandleColor(i - 4) == -1 &&
                            // 2nd gaps down
                            GetRealBodyGapDown(i - 3, i - 4) &&
                            // 3rd has lower high and low than 2nd
                            high[i - 2] < high[i - 3] &&
                            low[i - 2] < low[i - 3] &&
                            // 4th has lower high and low than 3rd
                            high[i - 1] < high[i - 2] &&
                            low[i - 1] < low[i - 2] &&
                            // 5th closes inside the gap
                            close[i] > open[i - 3] &&
                            close[i] < close[i - 4]
                        )
                        ||
                        (
                            // when 1st is white:
                            GetCandleColor(i - 4) == 1 &&
                            // 2nd gaps up
                            GetRealBodyGapUp(i - 3, i - 4) &&
                            // 3rd has higher high and low than 2nd
                            high[i - 2] > high[i - 3] &&
                            low[i - 2] > low[i - 3] &&
                            // 4th has higher high and low than 3rd
                            high[i - 1] > high[i - 2] &&
                            low[i - 1] > low[i - 2] &&
                            // 5th closes inside the gap
                            close[i] < open[i - 3] &&
                            close[i] > close[i - 4]
                        )
                    );

                outInteger[outIdx++] = isBreakaway ? GetCandleColor(i) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 4) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlBreakawayLookback()
        {
            return GetCandleAvgPeriod(BodyLong) + 4;
        }
    }
}
