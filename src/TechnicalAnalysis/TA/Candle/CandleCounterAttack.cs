using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleCounterAttack : CandleIndicator
    {
        public CandleCounterAttack(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlCounterAttack(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] bodyLongPeriodTotal = new double[2];

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
            int lookbackTotal = this.CdlCounterAttackLookback();

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
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
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
                bodyLongPeriodTotal[1] += this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close);
                bodyLongPeriodTotal[0] += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black (white)
             * - second candle: long white (black) with close equal to the prior close
             * The meaning of "equal" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that counterattack is significant in a trend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isCounterAttack =
                    // opposite candles
                    this.GetCandleColor(i - 1, this.open, this.close) == -this.GetCandleColor(i, this.open, this.close) &&
                    // 1st long
                    this.GetRealBody(i - 1, this.open, this.close) > 
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd long
                    this.GetRealBody(i, this.open, this.close) > 
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // equal closes
                    this.close[i] <= this.close[i - 1] + this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    this.close[i] >= this.close[i - 1] - this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isCounterAttack ? this.GetCandleColor(i, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                equalPeriodTotal +=
                    this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Equal, equalTrailingIdx - 1, this.open, this.high, this.low, this.close);

                int totIdx;
                for (totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        this.GetCandleRange(BodyLong, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                i++;
                equalTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlCounterAttackLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(Equal), this.GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
