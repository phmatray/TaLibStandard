using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3StarsInSouth : CandleIndicator
    {
        public Candle3StarsInSouth(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double[] shadowVeryShortPeriodTotal = new double[2];

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
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += GetCandleRange(ShadowLong, i - 2);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle with long lower shadow
             * - second candle: smaller black candle that opens higher than prior close but within prior candle's range 
             *   and trades lower than prior close but not lower than prior low and closes off of its low (it has a shadow)
             * - third candle: small black marubozu (or candle with very short shadows) engulfed by prior candle's range
             * The meanings of "long body", "short body", "very short shadow" are specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): 3 stars in the south is always bullish;
             * the user should consider that 3 stars in the south is significant when it appears in downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3StarsInSouth = GetPatternRecognition(
                    i, bodyLongPeriodTotal, shadowLongPeriodTotal, shadowVeryShortPeriodTotal, bodyShortPeriodTotal);

                outInteger[outIdx++] = is3StarsInSouth ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 2);

                shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i - 2) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx - 2);

                int totIdx;
                for (totIdx = 1; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
                }

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx);

                i++;
                bodyLongTrailingIdx++;
                shadowLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        private bool GetPatternRecognition(
            int i, 
            double bodyLongPeriodTotal,
            double shadowLongPeriodTotal,
            double[] shadowVeryShortPeriodTotal,
            double bodyShortPeriodTotal)
        {
            bool is3StarsInSouth =
                // 1st black
                GetCandleColor(i - 2) == -1 &&
                // 2nd black
                GetCandleColor(i - 1) == -1 &&
                // 3rd black
                GetCandleColor(i) == -1 &&
                // 1st: long
                GetRealBody(i - 2) > GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2) &&
                // with long lower shadow
                GetLowerShadow(i - 2) > GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i - 2) &&
                // 2nd: smaller candle
                GetRealBody(i - 1) < GetRealBody(i - 2) &&
                // that opens higher but within 1st range
                open[i - 1] > close[i - 2] &&
                open[i - 1] <= high[i - 2] &&
                // and trades lower than 1st close
                low[i - 1] < close[i - 2] &&
                // but not lower than 1st low
                low[i - 1] >= low[i - 2] &&
                // and has a lower shadow
                GetLowerShadow(i - 1) > GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1) &&
                // 3rd: small marubozu
                GetRealBody(i) < GetCandleAverage(BodyShort, bodyShortPeriodTotal, i) &&
                GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i) &&
                GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i) &&
                // engulfed by prior candle's range
                low[i] > low[i - 1] && high[i] < high[i - 1];
            
            return is3StarsInSouth;
        }

        public override int GetLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(ShadowLong)),
                Max(GetCandleAvgPeriod(BodyLong), GetCandleAvgPeriod(BodyShort))
            ) + 2;
        }
    }
}
