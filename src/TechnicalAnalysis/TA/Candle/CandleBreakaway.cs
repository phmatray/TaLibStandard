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
            if (this.open == null || this.high == null || this.low == null || this.close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.CdlBreakawayLookback();

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
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i - 4, this.open, this.high, this.low, this.close);
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
                    this.GetRealBody(i - 4, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 4, this.open, this.high, this.low, this.close) &&
                    // 1st, 2nd, 4th same color, 5th opposite
                    this.GetCandleColor(i - 4, this.open, this.close) == this.GetCandleColor(i - 3, this.open, this.close) &&
                    this.GetCandleColor(i - 3, this.open, this.close) == this.GetCandleColor(i - 1, this.open, this.close) &&
                    this.GetCandleColor(i - 1, this.open, this.close) == -this.GetCandleColor(i, this.open, this.close) &&
                    (
                        (
                            // when 1st is black:
                            this.GetCandleColor(i - 4, this.open, this.close) == -1 &&
                            // 2nd gaps down
                            this.GetRealBodyGapDown(i - 3, i - 4, this.open, this.close) &&
                            // 3rd has lower high and low than 2nd
                            this.high[i - 2] < this.high[i - 3] &&
                            this.low[i - 2] < this.low[i - 3] &&
                            // 4th has lower high and low than 3rd
                            this.high[i - 1] < this.high[i - 2] &&
                            this.low[i - 1] < this.low[i - 2] &&
                            // 5th closes inside the gap
                            this.close[i] > this.open[i - 3] &&
                            this.close[i] < this.close[i - 4]
                        )
                        ||
                        (
                            // when 1st is white:
                            this.GetCandleColor(i - 4, this.open, this.close) == 1 &&
                            // 2nd gaps up
                            this.GetRealBodyGapUp(i - 3, i - 4, this.open, this.close) &&
                            // 3rd has higher high and low than 2nd
                            this.high[i - 2] > this.high[i - 3] &&
                            this.low[i - 2] > this.low[i - 3] &&
                            // 4th has higher high and low than 3rd
                            this.high[i - 1] > this.high[i - 2] &&
                            this.low[i - 1] > this.low[i - 2] &&
                            // 5th closes inside the gap
                            this.close[i] < this.open[i - 3] &&
                            this.close[i] > this.close[i - 4]
                        )
                    );

                outInteger[outIdx++] = isBreakaway ? this.GetCandleColor(i, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 4, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 4, this.open, this.high, this.low, this.close);

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
            return this.GetCandleAvgPeriod(BodyLong) + 4;
        }
    }
}
