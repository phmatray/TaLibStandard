using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandlePiercing : CandleIndicator
    {
        public CandlePiercing(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlPiercing(
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
            int lookbackTotal = this.CdlPiercingLookback();

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
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close);
                bodyLongPeriodTotal[0] += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: long white candle with open below previous day low and close at least at 50% of previous day 
             * real body
             * The meaning of "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): piercing pattern is always bullish
             * the user should consider that a piercing pattern is significant when it appears in a downtrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isPiercing =
                    // 1st: black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // long
                    this.GetRealBody(i - 1, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd: white
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // long
                    this.GetRealBody(i, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // open below prior low
                    this.open[i] < this.low[i - 1] &&
                    // close within prior body
                    this.close[i] < this.open[i - 1] &&
                    // above midpoint
                    this.close[i] > this.close[i - 1] + this.GetRealBody(i - 1, this.open, this.close) * 0.5;

                outInteger[outIdx++] = isPiercing ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        this.GetCandleRange(BodyLong, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlPiercingLookback()
        {
            return this.GetCandleAvgPeriod(BodyLong) + 1;
        }
    }
}
