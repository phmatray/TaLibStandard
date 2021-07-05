using System;
using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis.Candle
{
    public class CandleXSideGap3Methods : CandleIndicator
    {
        public CandleXSideGap3Methods(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlXSideGap3Methods(
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
            int lookbackTotal = this.CdlXSideGap3MethodsLookback();

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
                    this.GetCandleColor(i - 2, this.open, this.close) == this.GetCandleColor(i - 1, this.open, this.close) &&
                    // 3rd opposite color
                    this.GetCandleColor(i - 1, this.open, this.close) == -this.GetCandleColor(i, this.open, this.close) &&
                    // 3rd opens within 2nd rb
                    this.open[i] < Math.Max(this.close[i - 1], this.open[i - 1]) &&
                    this.open[i] > Math.Min(this.close[i - 1], this.open[i - 1]) &&
                    // 3rd closes within 1st rb
                    this.close[i] < Math.Max(this.close[i - 2], this.open[i - 2]) &&
                    this.close[i] > Math.Min(this.close[i - 2], this.open[i - 2]) &&
                    ((
                         // when 1st is white
                         this.GetCandleColor(i - 2, this.open, this.close) == 1 &&
                         // upside gap
                         this.GetRealBodyGapUp(i - 1, i - 2, this.open, this.close)
                     ) ||
                     (
                         // when 1st is black
                         this.GetCandleColor(i - 2, this.open, this.close) == -1 &&
                         // downside gap
                         this.GetRealBodyGapDown(i - 1, i - 2, this.open, this.close)
                     )
                    );

                outInteger[outIdx++] = isXSideGap3Methods ? this.GetCandleColor(i - 2, this.open, this.close) * 100 : 0;

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

        public int CdlXSideGap3MethodsLookback()
        {
            return 2;
        }
    }
}
