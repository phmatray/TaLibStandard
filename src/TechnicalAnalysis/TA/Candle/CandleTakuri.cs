using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleTakuri : CandleIndicator
    {
        private double _bodyDojiPeriodTotal;
        private double _shadowVeryShortPeriodTotal;
        private double _shadowVeryLongPeriodTotal;

        public CandleTakuri(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            int shadowVeryLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryLong);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                _bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                _shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i);
                i++;
            }

            i = shadowVeryLongTrailingIdx;
            while (i < startIdx)
            {
                _shadowVeryLongPeriodTotal += GetCandleRange(ShadowVeryLong, i);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - open and close at the high of the day = no or very short upper shadow
             * - very long lower shadow
             * The meaning of "doji", "very short" and "very long" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: takuri must be considered
             * relatively to the trend
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

                _shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx);

                _shadowVeryLongPeriodTotal +=
                    GetCandleRange(ShadowVeryLong, i) -
                    GetCandleRange(ShadowVeryLong, shadowVeryLongTrailingIdx);

                i++;
                bodyDojiTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                shadowVeryLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isTakuri =
                GetRealBody(i) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i) &&
                GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i) &&
                GetLowerShadow(i) > GetCandleAverage(ShadowVeryLong, _shadowVeryLongPeriodTotal, i);
            
            return isTakuri;
        }

        public override int GetLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(ShadowVeryShort)),
                GetCandleAvgPeriod(ShadowVeryLong)
            );
        }
    }
}
