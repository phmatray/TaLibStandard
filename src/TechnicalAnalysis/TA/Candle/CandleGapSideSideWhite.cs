using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleGapSideSideWhite : CandleIndicator
    {
        public CandleGapSideSideWhite(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlGapSideSideWhite(
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
            int lookbackTotal = this.CdlGapSideSideWhiteLookback();

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
            double equalPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            int equalTrailingIdx = startIdx - this.GetCandleAvgPeriod(Equal);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - upside or downside gap (between the bodies)
             * - first candle after the window: white candlestick
             * - second candle after the window: white candlestick with similar size (near the same) and about the same 
             *   open (equal) of the previous candle
             * - the second candle does not close the window
             * The meaning of "near" and "equal" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) or negative (-1 to -100): the user should consider that upside 
             * or downside gap side-by-side white lines is significant when it appears in a trend, while this function 
             * does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isGapSideSideWhite =
                    ( // upside or downside gap between the 1st candle and both the next 2 candles
                        (
                            this.GetRealBodyGapUp(i - 1, i - 2, this.open, this.close) &&
                            this.GetRealBodyGapUp(i, i - 2, this.open, this.close)
                        )
                        ||
                        (
                            this.GetRealBodyGapDown(i - 1, i - 2, this.open, this.close) &&
                            this.GetRealBodyGapDown(i, i - 2, this.open, this.close)
                        )
                    ) &&
                    // 2nd: white
                    this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                    // 3rd: white
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // same size 2 and 3
                    this.GetRealBody(i, this.open, this.close) >= this.GetRealBody(i - 1, this.open, this.close) -
                    this.GetCandleAverage(Near, nearPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i, this.open, this.close) <= this.GetRealBody(i - 1, this.open, this.close) +
                    this.GetCandleAverage(Near, nearPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // same open 2 and 3
                    this.open[i] >= this.open[i - 1] -
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    this.open[i] <= this.open[i - 1] +
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] =
                    isGapSideSideWhite ? this.GetRealBodyGapUp(i - 1, i - 2, this.open, this.close) ? 100 : -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                nearPeriodTotal +=
                    this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Near, nearTrailingIdx - 1, this.open, this.high, this.low, this.close);

                equalPeriodTotal +=
                    this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Equal, equalTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                nearTrailingIdx++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlGapSideSideWhiteLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(Near), this.GetCandleAvgPeriod(Equal)) + 2;
        }
    }
}
