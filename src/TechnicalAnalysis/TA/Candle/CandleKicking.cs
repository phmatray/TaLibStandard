using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleKicking : CandleIndicator
    {
        private double[] _shadowVeryShortPeriodTotal = new double[2];
        private double[] _bodyLongPeriodTotal = new double[2];

        public CandleKicking(in double[] open, in double[] high, in double[] low, in double[] close)
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
            _shadowVeryShortPeriodTotal[1] = 0.0;
            _shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            _bodyLongPeriodTotal[1] = 0.0;
            _bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                _shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
                _shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                _bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
                _bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: marubozu
             * - second candle: opposite color marubozu
             * - gap between the two candles: upside gap if black then white, downside gap if white then black
             * The meaning of "long body" and "very short shadow" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? GetCandleColor(i) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                int totIdx;
                for (totIdx = 1; totIdx >= 0; --totIdx)
                {
                    _bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);

                    _shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
                }

                i++;
                shadowVeryShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isKicking =
                // opposite candles
                GetCandleColor(i - 1) == -GetCandleColor(i) &&
                // 1st marubozu
                GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[1], i - 1) &&
                GetUpperShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
                GetLowerShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
                // 2nd marubozu
                GetRealBody(i) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[0], i) &&
                GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
                GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
                // gap
                (
                    (GetCandleColor(i - 1) == -1 && GetCandleGapUp(i, i - 1)) ||
                    (GetCandleColor(i - 1) == 1 && GetCandleGapDown(i, i - 1))
                );
            
            return isKicking;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
