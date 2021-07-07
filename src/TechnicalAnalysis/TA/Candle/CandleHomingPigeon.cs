using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleHomingPigeon : CandleIndicator
    {
        private double _bodyLongPeriodTotal;
        private double _bodyShortPeriodTotal;

        public CandleHomingPigeon(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 1);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: short black real body completely inside the previous day's body
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): homing pigeon is always bullish; 
             * the user should consider that homing pigeon is significant when it appears in a downtrend,
             * while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isHomingPigeon = GetPatternRecognition(i);

                outInteger[outIdx++] = isHomingPigeon ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 1) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 1);

                _bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isHomingPigeon =
                // 1st black
                GetCandleColor(i - 1) == -1 &&
                // 2nd black
                GetCandleColor(i) == -1 &&
                // 1st long
                GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 1) &&
                // 2nd short
                GetRealBody(i) <= GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
                // 2nd engulfed by 1st
                _open[i] < _open[i - 1] &&
                _close[i] > _close[i - 1];
            
            return isHomingPigeon;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
