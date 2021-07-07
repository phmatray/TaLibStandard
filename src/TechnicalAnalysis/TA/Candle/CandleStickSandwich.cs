using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleStickSandwich : CandleIndicator
    {
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
            if (open == null || high == null || low == null || close == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlStickSandwichLookback();

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
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 2);
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
                bool isStickSandwich =
                    // first black
                    GetCandleColor(i - 2) == -1 &&
                    // second white
                    GetCandleColor(i - 1) == 1 &&
                    // third black
                    GetCandleColor(i) == -1 &&
                    // 2nd low > prior close
                    low[i - 1] > close[i - 2] &&
                    // 1st and 3rd same close
                    close[i] <= close[i - 2] + GetCandleAverage(Equal, equalPeriodTotal, i - 2) &&
                    close[i] >= close[i - 2] - GetCandleAverage(Equal, equalPeriodTotal, i - 2);

                outInteger[outIdx++] = isStickSandwich ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                equalPeriodTotal +=
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

        public int CdlStickSandwichLookback()
        {
            return GetCandleAvgPeriod(Equal) + 2;
        }
    }
}
