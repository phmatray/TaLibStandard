using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleIdentical3Crows : CandleIndicator
    {
        public CandleIdentical3Crows(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double[] equalPeriodTotal = new double[3];
            
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

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlIdentical3CrowsLookback();

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
            equalPeriodTotal[2] = 0.0;
            equalPeriodTotal[1] = 0.0;
            equalPeriodTotal[0] = 0.0;
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2);
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal[2] += GetCandleRange(Equal, i - 2);
                equalPeriodTotal[1] += GetCandleRange(Equal, i - 1);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three consecutive and declining black candlesticks
             * - each candle must have no or very short lower shadow
             * - each candle after the first must open at or very close to the prior candle's close
             * The meaning of "very short" is specified with TA_SetCandleSettings;
             * the meaning of "very close" is specified with TA_SetCandleSettings (Equal);
             * outInteger is negative (-1 to -100): identical three crows is always bearish; 
             * the user should consider that identical 3 crows is significant when it appears after a mature advance or at high levels, 
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isIdentical3Crows =
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
                    // three declining
                    close[i - 2] > close[i - 1] &&
                    close[i - 1] > close[i] &&
                    // 2nd black opens very close to 1st close
                    open[i - 1] <= close[i - 2] + GetCandleAverage(Equal, equalPeriodTotal[2], i - 2) &&
                    open[i - 1] >= close[i - 2] - GetCandleAverage(Equal, equalPeriodTotal[2], i - 2) &&
                    // 3rd black opens very close to 2nd close 
                    open[i] <= close[i - 1] + GetCandleAverage(Equal, equalPeriodTotal[1], i - 1) &&
                    open[i] >= close[i - 1] - GetCandleAverage(Equal, equalPeriodTotal[1], i - 1);

                outInteger[outIdx++] = isIdentical3Crows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
                }

                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    equalPeriodTotal[totIdx] +=
                        GetCandleRange(Equal, i - totIdx) -
                        GetCandleRange(Equal, equalTrailingIdx - totIdx);
                }

                i++;
                shadowVeryShortTrailingIdx++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlIdentical3CrowsLookback()
        {
            return Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(Equal)) + 2;
        }
    }
}
