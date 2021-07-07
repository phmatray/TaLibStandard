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

        public RetCode TryCompute(
            int startIdx,
            int endIdx,
            out int outBegIdx,
            out int outNBElement,
            out int[] outInteger)
        {
            // Initialize output variables 
            outBegIdx = default;
            outNBElement = default;
            outInteger = new int[endIdx - startIdx + 1];
            
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
            if (open == null || high == null || low == null || close == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = GetLookback();

            // Move up the start index if there is not enough initial data.
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            // Make sure there is still something to evaluate.
            if (startIdx > endIdx)
            {
                return RetCode.Success;
            }

            // Do the calculation using tight loops.
            // Add-up the initial period, except for the last value.
            shadowVeryShortPeriodTotal[3] = 0.0;
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[3] += GetCandleRange(ShadowVeryShort, i - 3);
                shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2);
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
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
                bool isConcealBabySwallow = GetPatternRecognition(i, shadowVeryShortPeriodTotal);

                outInteger[outIdx++] = isConcealBabySwallow ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 1; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
                }

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        private bool GetPatternRecognition(int i, double[] shadowVeryShortPeriodTotal)
        {
            bool isConcealBabySwallow =
                // 1st black
                GetCandleColor(i - 3) == -1 &&
                // 2nd black
                GetCandleColor(i - 2) == -1 &&
                // 3rd black
                GetCandleColor(i - 1) == -1 &&
                // 4th black
                GetCandleColor(i) == -1 &&
                // 1st: marubozu
                GetLowerShadow(i - 3) <
                GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[3], i - 3) &&
                GetUpperShadow(i - 3) <
                GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[3], i - 3) &&
                // 2nd: marubozu
                GetLowerShadow(i - 2) <
                GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2) &&
                GetUpperShadow(i - 2) <
                GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2) &&
                // 3rd: opens gapping down
                GetRealBodyGapDown(i - 1, i - 2) &&
                // and HAS an upper shadow
                GetUpperShadow(i - 1) >
                GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1) &&
                // that extends into the prior body
                high[i - 1] > close[i - 2] &&
                // 4th: engulfs the 3rd including the shadows
                high[i] > high[i - 1] && low[i] < low[i - 1];
            
            return isConcealBabySwallow;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
