using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleTasukiGap : CandleIndicator
    {
        public CandleTasukiGap(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlTasukiGap(
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
            int lookbackTotal = this.CdlTasukiGapLookback();

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
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close);
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
                        this.GetRealBodyGapUp(i - 1, i - 2, this.open, this.close) &&
                        // 1st: white
                        this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                        // 2nd: black
                        this.GetCandleColor(i, this.open, this.close) == -1 &&
                        // that opens within the white rb
                        this.open[i] < this.close[i - 1] && this.open[i] > this.open[i - 1] &&
                        // and closes under the white rb
                        this.close[i] < this.open[i - 1] &&
                        // inside the gap
                        this.close[i] > Math.Max(this.close[i - 2], this.open[i - 2]) &&
                        // size of 2 rb near the same
                        Math.Abs(this.GetRealBody(i - 1, this.open, this.close) - this.GetRealBody(i, this.open, this.close)) <
                        this.GetCandleAverage(Near, nearPeriodTotal, i - 1, this.open, this.high, this.low, this.close)
                    ) ||
                    (
                        // downside gap
                        this.GetRealBodyGapDown(i - 1, i - 2, this.open, this.close) &&
                        // 1st: black
                        this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                        // 2nd: white
                        this.GetCandleColor(i, this.open, this.close) == 1 &&
                        // that opens within the black rb
                        this.open[i] < this.open[i - 1] && this.open[i] > this.close[i - 1] &&
                        // and closes above the black rb
                        this.close[i] > this.open[i - 1] &&
                        // inside the gap
                        this.close[i] < Math.Min(this.close[i - 2], this.open[i - 2]) &&
                        // size of 2 rb near the same
                        Math.Abs(this.GetRealBody(i - 1, this.open, this.close) - this.GetRealBody(i, this.open, this.close)) <
                        this.GetCandleAverage(Near, nearPeriodTotal, i - 1, this.open, this.high, this.low, this.close)
                    );

                outInteger[outIdx++] = isTasukiGap ? this.GetCandleColor(i - 1, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                nearPeriodTotal +=
                    this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Near, nearTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlTasukiGapLookback()
        {
            return this.GetCandleAvgPeriod(Near) + 2;
        }
    }
}
