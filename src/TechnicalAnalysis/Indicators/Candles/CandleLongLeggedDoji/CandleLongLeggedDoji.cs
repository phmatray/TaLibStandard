using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;

namespace TechnicalAnalysis.Candles.CandleLongLeggedDoji
{
    public class CandleLongLeggedDoji : CandleIndicator
    {
        private double _bodyDojiPeriodTotal;
        private double _shadowLongPeriodTotal;

        public CandleLongLeggedDoji(in double[] open, in double[] high, in double[] low, in double[] close)
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
            if (_open == null || _high == null || _low == null || _close == null)
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
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                _bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                _shadowLongPeriodTotal += GetCandleRange(ShadowLong, i);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - one or two long shadows
             * The meaning of "doji" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: long legged doji shows uncertainty
             */
            int outIdx = 0;
            do
            {
                bool isLongLeggedDoji = GetPatternRecognition(i);

                outInteger[outIdx++] = isLongLeggedDoji ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

                _shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx);

                i++;
                bodyDojiTrailingIdx++;
                shadowLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isLongLeggedDoji =
                GetRealBody(i) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i) &&
                (
                    GetLowerShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i) ||
                    GetUpperShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i)
                );
            
            return isLongLeggedDoji;
        }

        public override int GetLookback()
        {
            return GetCandleMaxAvgPeriod(BodyDoji, ShadowLong);
        }
    }
}
