using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleConcealBabySwallow : CandleIndicator
    {
        public CandleConcealBabySwallow(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlConcealBabySwallow(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] shadowVeryShortPeriodTotal = new double[4];
            
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
            int lookbackTotal = this.CdlConcealBabySwallowLookback();

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
            shadowVeryShortPeriodTotal[3] = 0.0;
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[3] += this.GetCandleRange(ShadowVeryShort, i - 3, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[2] += this.GetCandleRange(ShadowVeryShort, i - 2, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[1] += this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black marubozu (very short shadows)
             * - second candle: black marubozu (very short shadows)
             * - third candle: black candle that opens gapping down but has an upper shadow that extends into the prior body
             * - fourth candle: black candle that completely engulfs the third candle, including the shadows
             * The meanings of "very short shadow" are specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): concealing baby swallow is always bullish;
             * the user should consider that concealing baby swallow is significant when it appears in downtrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isConcealBabySwallow =
                    // 1st black
                    this.GetCandleColor(i - 3, this.open, this.close) == -1 &&
                    // 2nd black
                    this.GetCandleColor(i - 2, this.open, this.close) == -1 &&
                    // 3rd black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // 4th black
                    this.GetCandleColor(i, this.open, this.close) == -1 &&
                    // 1st: marubozu
                    this.GetLowerShadow(i - 3, this.open, this.low, this.close) < 
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[3], i - 3, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i - 3, this.open, this.low, this.close) < 
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[3], i - 3, this.open, this.high, this.low, this.close) &&
                    // 2nd: marubozu
                    this.GetLowerShadow(i - 2, this.open, this.low, this.close) < 
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i - 2, this.open, this.low, this.close) < 
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 3rd: opens gapping down
                    this.GetRealBodyGapDown(i - 1, i - 2, this.open, this.close) &&
                    // and HAS an upper shadow
                    this.GetUpperShadow(i - 1, this.open, this.low, this.close) > 
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // that extends into the prior body
                    this.high[i - 1] > this.close[i - 2] &&
                    // 4th: engulfs the 3rd including the shadows
                    this.high[i] > this.high[i - 1] && this.low[i] < this.low[i - 1];

                outInteger[outIdx++] = isConcealBabySwallow ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 1; --totIdx)
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

        public int CdlConcealBabySwallowLookback()
        {
            return this.GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
