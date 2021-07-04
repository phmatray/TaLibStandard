using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlMatchingLow(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
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
            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlMatchingLowLookback();

            // Move up the start index if there is not enough initial data.
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            // Make sure there is still something to evaluate.
            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            // Do the calculation using tight loops.
            // Add-up the initial period, except for the last value.
            double equalPeriodTotal = 0.0;
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose);
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
                bool isMatchingLow =
                    // first black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // second black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // 1st and 2nd same close
                    inClose[i] <= inClose[i - 1] +
                    GetCandleAverage(Equal, equalPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    inClose[i] >= inClose[i - 1] -
                    GetCandleAverage(Equal, equalPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isMatchingLow ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Equal, equalTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlMatchingLowLookback()
        {
            return GetCandleAvgPeriod(Equal) + 1;
        }
    }
}
