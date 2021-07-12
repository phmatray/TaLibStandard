using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleConcealBabySwallow
{
    public class CandleConcealBabySwallow : CandleIndicator
    {
        private readonly double[] _shadowVeryShortPeriodTotal = new double[4];

        public CandleConcealBabySwallow(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public CandleConcealBabySwallowResult Compute(int startIdx, int endIdx)
        {
            // Initialize output variables 
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            // Validate the requested output range.
            if (startIdx < 0)
            {
                return new(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return new(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
            }

            // Verify required price component.
            if (_open == null || _high == null || _low == null || _close == null)
            {
                return new(BadParam, outBegIdx, outNBElement, outInteger);
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
                return new(Success, outBegIdx, outNBElement, outInteger);
            }

            // Do the calculation using tight loops.
            // Add-up the initial period, except for the last value.
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                _shadowVeryShortPeriodTotal[3] += GetCandleRange(ShadowVeryShort, i - 3);
                _shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2);
                _shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
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
                outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 1; --totIdx)
                {
                    _shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
                }

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return new(Success, outBegIdx, outNBElement, outInteger);
        }

        public override bool GetPatternRecognition(int i)
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
                GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[3], i - 3) &&
                GetUpperShadow(i - 3) <
                GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[3], i - 3) &&
                // 2nd: marubozu
                GetLowerShadow(i - 2) <
                GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], i - 2) &&
                GetUpperShadow(i - 2) <
                GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], i - 2) &&
                // 3rd: opens gapping down
                GetRealBodyGapDown(i - 1, i - 2) &&
                // and HAS an upper shadow
                GetUpperShadow(i - 1) >
                GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
                // that extends into the prior body
                _high[i - 1] > _close[i - 2] &&
                // 4th: engulfs the 3rd including the shadows
                _high[i] > _high[i - 1] && _low[i] < _low[i - 1];
            
            return isConcealBabySwallow;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
