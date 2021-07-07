using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleCounterAttack : CandleIndicator
    {
        public CandleCounterAttack(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double equalPeriodTotal = 0.0;
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 1);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
                bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i);
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
                bool isCounterAttack = GetPatternRecognition(i, bodyLongPeriodTotal, equalPeriodTotal);

                outInteger[outIdx++] = isCounterAttack ? GetCandleColor(i) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1) -
                    GetCandleRange(Equal, equalTrailingIdx - 1);

                int totIdx;
                for (totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);
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

        private bool GetPatternRecognition(int i, double[] bodyLongPeriodTotal, double equalPeriodTotal)
        {
            bool isCounterAttack =
                // opposite candles
                GetCandleColor(i - 1) == -GetCandleColor(i) &&
                // 1st long
                GetRealBody(i - 1) > GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1) &&
                // 2nd long
                GetRealBody(i) > GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i) &&
                // equal closes
                close[i] <= close[i - 1] + GetCandleAverage(Equal, equalPeriodTotal, i - 1) &&
                close[i] >= close[i - 1] - GetCandleAverage(Equal, equalPeriodTotal, i - 1);
            
            return isCounterAttack;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(Equal), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
