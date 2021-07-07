using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;

namespace TechnicalAnalysis.Candles.CandleStickSandwich
{
    public class CandleStickSandwich : CandleIndicator
    {
        private double _equalPeriodTotal;

        public CandleStickSandwich(in double[] open, in double[] high, in double[] low, in double[] close)
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
                _equalPeriodTotal += GetCandleRange(Equal, i - 2);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black candle
             * - second candle: white candle that trades only above the prior close (low > prior close)
             * - third candle: black candle with the close equal to the first candle's close
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100): stick sandwich is always bullish;
             * the user should consider that stick sandwich is significant when coming in a downtrend, 
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _equalPeriodTotal +=
                    GetCandleRange(Equal, i - 2) -
                    GetCandleRange(Equal, equalTrailingIdx - 2);

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
            bool isStickSandwich =
                // first black
                GetCandleColor(i - 2) == -1 &&
                // second white
                GetCandleColor(i - 1) == 1 &&
                // third black
                GetCandleColor(i) == -1 &&
                // 2nd low > prior close
                _low[i - 1] > _close[i - 2] &&
                // 1st and 3rd same close
                _close[i] <= _close[i - 2] + GetCandleAverage(Equal, _equalPeriodTotal, i - 2) &&
                _close[i] >= _close[i - 2] - GetCandleAverage(Equal, _equalPeriodTotal, i - 2);
            
            return isStickSandwich;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(Equal) + 2;
        }
    }
}
