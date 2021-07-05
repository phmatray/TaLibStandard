using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3LineStrike : CandleIndicator
    {
        public Candle3LineStrike(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode Cdl3LineStrike(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] nearPeriodTotal = new double[4];

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
            int lookbackTotal = this.Cdl3LineStrikeLookback();

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
            nearPeriodTotal[3] = 0.0;
            nearPeriodTotal[2] = 0.0;
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[3] += this.GetCandleRange(Near, i - 3, this.open, this.high, this.low, this.close);
                nearPeriodTotal[2] += this.GetCandleRange(Near, i - 2, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white soldiers (three black crows): three white (black) candlesticks with consecutively higher (lower) closes,
             * each opening within or near the previous real body
             * - fourth candle: black (white) candle that opens above (below) prior candle's close and closes below (above) 
             * the first candle's open
             * The meaning of "near" is specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that 3-line strike is significant when it appears in a trend in the same direction of
             * the first three candles, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3LineStrike =
                    // three with same color
                    this.GetCandleColor(i - 3, this.open, this.close) == this.GetCandleColor(i - 2, this.open, this.close) &&
                    this.GetCandleColor(i - 2, this.open, this.close) == this.GetCandleColor(i - 1, this.open, this.close) &&
                    // 4th opposite color
                    this.GetCandleColor(i, this.open, this.close) == -this.GetCandleColor(i - 1, this.open, this.close) &&
                    // 2nd opens within/near 1st rb
                    this.open[i - 2] >= Math.Min(this.open[i - 3], this.close[i - 3]) -
                    this.GetCandleAverage(Near, nearPeriodTotal[3], i - 3, this.open, this.high, this.low, this.close) &&
                    this.open[i - 2] <= Math.Max(this.open[i - 3], this.close[i - 3]) +
                    this.GetCandleAverage(Near, nearPeriodTotal[3], i - 3, this.open, this.high, this.low, this.close) &&
                    // 3rd opens within/near 2nd rb
                    this.open[i - 1] >= Math.Min(this.open[i - 2], this.close[i - 2]) -
                    this.GetCandleAverage(Near, nearPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    this.open[i - 1] <= Math.Max(this.open[i - 2], this.close[i - 2]) +
                    this.GetCandleAverage(Near, nearPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    (
                        ( // if three white
                            this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                            this.close[i - 1] > this.close[i - 2] &&
                            // consecutive higher closes
                            this.close[i - 2] > this.close[i - 3] &&
                            // 4th opens above prior close
                            this.open[i] > this.close[i - 1] &&
                            // 4th closes below 1st open
                            this.close[i] < this.open[i - 3]
                        ) ||
                        ( // if three black
                            this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                            this.close[i - 1] < this.close[i - 2] &&
                            // consecutive lower closes
                            this.close[i - 2] < this.close[i - 3] &&
                            // 4th opens below prior close
                            this.open[i] < this.close[i - 1] &&
                            // 4th closes above 1st open
                            this.close[i] > this.open[i - 3]
                        )
                    );

                outInteger[outIdx++] = is3LineStrike ? this.GetCandleColor(i - 1, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 2; --totIdx)
                {
                    nearPeriodTotal[totIdx] +=
                        this.GetCandleRange(Near, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(Near, nearTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                i++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int Cdl3LineStrikeLookback()
        {
            return this.GetCandleAvgPeriod(Near) + 3;
        }
    }
}
