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
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] = GetCandleRange(ShadowVeryShort, i - 2);
                shadowVeryShortPeriodTotal[1] = GetCandleRange(ShadowVeryShort, i - 1);
                shadowVeryShortPeriodTotal[0] = GetCandleRange(ShadowVeryShort, i);
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
                bool is3BlackCrows = GetPatternRecognition(i, shadowVeryShortPeriodTotal);

                outInteger[outIdx++] = is3BlackCrows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
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
            bool is3BlackCrows =
                // white
                GetCandleColor(i - 3) == 1 &&
                // 1st black
                GetCandleColor(i - 2) == -1 &&
                // very short lower shadow
                GetLowerShadow(i - 2) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2) &&
                // 2nd black
                GetCandleColor(i - 1) == -1 &&
                // very short lower shadow
                GetLowerShadow(i - 1) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1) &&
                // 3rd black
                GetCandleColor(i) == -1 &&
                // very short lower shadow
                GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i) &&
                // 2nd black opens within 1st black's rb
                open[i - 1] < open[i - 2] &&
                open[i - 1] > close[i - 2] &&
                // 3rd black opens within 2nd black's rb
                open[i] < open[i - 1] &&
                open[i] > close[i - 1] &&
                // 1st black closes under prior candle's high
                high[i - 3] > close[i - 2] &&
                // three declining
                close[i - 2] > close[i - 1] &&
                // three declining
                close[i - 1] > close[i];
            
            return is3BlackCrows;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
