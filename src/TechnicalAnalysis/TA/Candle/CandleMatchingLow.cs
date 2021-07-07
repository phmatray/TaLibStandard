using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleMatchingLow : CandleIndicator
    {
        private double _equalPeriodTotal;

        public CandleMatchingLow(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                _equalPeriodTotal += GetCandleRange(Equal, i - 1);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black candle
             * - second candle: black candle with the close equal to the previous close
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100): matching low is always bullish;
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1) -
                    GetCandleRange(Equal, equalTrailingIdx - 1);

                i++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isMatchingLow =
                // first black
                GetCandleColor(i - 1) == -1 &&
                // second black
                GetCandleColor(i) == -1 &&
                // 1st and 2nd same close
                _close[i] <= _close[i - 1] + GetCandleAverage(Equal, _equalPeriodTotal, i - 1) &&
                _close[i] >= _close[i - 1] - GetCandleAverage(Equal, _equalPeriodTotal, i - 1);
            
            return isMatchingLow;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(Equal) + 1;
        }
    }
}
