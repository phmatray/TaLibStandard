using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleSeparatingLines : CandleIndicator
    {
        private double _shadowVeryShortPeriodTotal;
        private double _bodyLongPeriodTotal;
        private double _equalPeriodTotal;

        public CandleSeparatingLines(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                _shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                _equalPeriodTotal += GetCandleRange(Equal, i - 1);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black (white) candle
             * - second candle: bullish (bearish) belt hold with the same open as the prior candle
             * The meaning of "long body" and "very short shadow" of the belt hold is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that separating lines is significant when coming in a trend and the belt hold has 
             * the same direction of the trend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? GetCandleColor(i) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx);

                _bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx);

                _equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1) -
                    GetCandleRange(Equal, equalTrailingIdx - 1);

                i++;
                shadowVeryShortTrailingIdx++;
                bodyLongTrailingIdx++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isSeparatingLines =
                // opposite candles
                GetCandleColor(i - 1) == -GetCandleColor(i) &&
                // same open
                _open[i] <= _open[i - 1] + GetCandleAverage(Equal, _equalPeriodTotal, i - 1) &&
                _open[i] >= _open[i - 1] - GetCandleAverage(Equal, _equalPeriodTotal, i - 1) &&
                // belt hold: long body
                GetRealBody(i) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i) &&
                (
                    (
                        // with no lower shadow if bullish
                        GetCandleColor(i) == 1 &&
                        GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i)
                    )
                    ||
                    (
                        // with no upper shadow if bearish
                        GetCandleColor(i) == -1 &&
                        GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i)
                    )
                );
            
            return isSeparatingLines;
        }

        public override int GetLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(BodyLong)),
                GetCandleAvgPeriod(Equal)
            ) + 1;
        }
    }
}
