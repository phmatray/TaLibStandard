using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleInNeck : CandleIndicator
    {
        public CandleInNeck(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlInNeck(
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
            int lookbackTotal = this.CdlInNeckLookback();

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
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: white candle with open below previous day low and close slightly into previous day body
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): in-neck is always bearish
             * the user should consider that in-neck is significant when it appears in a downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isInNeck =
                    // 1st: black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // long
                    this.GetRealBody(i - 1, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd: white
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // open below prior low
                    this.open[i] < this.low[i - 1] &&
                    // close slightly into prior body
                    this.close[i] <= this.close[i - 1] +
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    this.close[i] >= this.close[i - 1];

                outInteger[outIdx++] = isInNeck ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                equalPeriodTotal +=
                    this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Equal, equalTrailingIdx - 1, this.open, this.high, this.low, this.close);

                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                equalTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlInNeckLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(Equal), this.GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
