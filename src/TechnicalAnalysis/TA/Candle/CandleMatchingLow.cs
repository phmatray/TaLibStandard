using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleMatchingLow : CandleIndicator
    {
        public CandleMatchingLow(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlMatchingLow(
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
            int lookbackTotal = this.CdlMatchingLowLookback();

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
            double equalPeriodTotal = 0.0;
            int equalTrailingIdx = startIdx - this.GetCandleAvgPeriod(Equal);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black candle
             * - second candle: black candle with the close equal to the previous close
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100): matching low is always bullish;
             */
            int outIdx = 0;
            do
            {
                bool isMatchingLow =
                    // first black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // second black
                    this.GetCandleColor(i, this.open, this.close) == -1 &&
                    // 1st and 2nd same close
                    this.close[i] <= this.close[i - 1] +
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    this.close[i] >= this.close[i - 1] -
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isMatchingLow ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                equalPeriodTotal +=
                    this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Equal, equalTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlMatchingLowLookback()
        {
            return this.GetCandleAvgPeriod(Equal) + 1;
        }
    }
}
