using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3BlackCrows : CandleIndicator
    {
        public Candle3BlackCrows(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode Cdl3BlackCrows(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] shadowVeryShortPeriodTotal = new double[3];
            
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
            int lookbackTotal = this.Cdl3BlackCrowsLookback();
            
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
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] = this.GetCandleRange(ShadowVeryShort, i - 2, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[1] = this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[0] = this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three consecutive and declining black candlesticks
             * - each candle must have no or very short lower shadow
             * - each candle after the first must open within the prior candle's real body
             * - the first candle's close should be under the prior white candle's high
             * The meaning of "very short" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): three black crows is always bearish; 
             * the user should consider that 3 black crows is significant when it appears after a mature advance or at high levels, 
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3BlackCrows =
                    // white
                    this.GetCandleColor(i - 3, this.open, this.close) == 1 &&
                    // 1st black
                    this.GetCandleColor(i - 2, this.open, this.close) == -1 &&
                    // very short lower shadow
                    this.GetLowerShadow(i - 2, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 2nd black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // very short lower shadow
                    this.GetLowerShadow(i - 1, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 3rd black
                    this.GetCandleColor(i, this.open, this.close) == -1 &&
                    // very short lower shadow
                    this.GetLowerShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // 2nd black opens within 1st black's rb
                    this.open[i - 1] < this.open[i - 2] &&
                    this.open[i - 1] > this.close[i - 2] &&
                    // 3rd black opens within 2nd black's rb
                    this.open[i] < this.open[i - 1] &&
                    this.open[i] > this.close[i - 1] &&
                    // 1st black closes under prior candle's high
                    this.high[i - 3] > this.close[i - 2] &&
                    // three declining
                    this.close[i - 2] > this.close[i - 1] &&
                    // three declining
                    this.close[i - 1] > this.close[i];

                outInteger[outIdx++] = is3BlackCrows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        this.GetCandleRange(ShadowVeryShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int Cdl3BlackCrowsLookback()
        {
            return this.GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
