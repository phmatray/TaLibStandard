using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleRickshawMan : CandleIndicator
    {
        private double _bodyDojiPeriodTotal;
        private double _shadowLongPeriodTotal;
        private double _nearPeriodTotal;

        public CandleRickshawMan(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
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

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                _nearPeriodTotal += GetCandleRange(Near, i);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - two long shadows
             * - body near the midpoint of the high-low range
             * The meaning of "doji" and "near" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: rickshaw man shows uncertainty
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

                _shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx);

                _nearPeriodTotal +=
                    GetCandleRange(Near, i) -
                    GetCandleRange(Near, nearTrailingIdx);

                i++;
                bodyDojiTrailingIdx++;
                shadowLongTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isRickshawMan =
                // doji
                GetRealBody(i) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i) &&
                // long shadow
                GetLowerShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i) &&
                // long shadow
                GetUpperShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i) &&
                (
                    // body near midpoint
                    Min(open[i], close[i]) <= low[i] + GetHighLowRange(i) / 2 + GetCandleAverage(Near, _nearPeriodTotal, i) &&
                    Max(open[i], close[i]) >= low[i] + GetHighLowRange(i) / 2 - GetCandleAverage(Near, _nearPeriodTotal, i)
                );
            
            return isRickshawMan;
        }

        public override int GetLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(ShadowLong)),
                GetCandleAvgPeriod(Near)
            );
        }
    }
}
