namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl2Crows(
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
            // Local variables
            const CandleSettingType BodyLong = CandleSettingType.BodyLong;

            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = Cdl2CrowsLookback();

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
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);

            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white candle
             * - second candle: black real body
             * - gap between the first and the second candle's real bodies
             * - third candle: black candle that opens within the second real body and closes within the first real body
             * The meaning of "long" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): two crows is always bearish; 
             * the user should consider that two crows is significant when it appears in an uptrend, while this function 
             * does not consider the trend
             */

            int outIdx = 0;
            do
            {
                bool is2Crows =
                    // 1st: white
                    GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                    // long
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // gapping up
                    GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose) &&
                    // 3rd: black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // opening within 2nd rb
                    inOpen[i] < inOpen[i - 1] && inOpen[i] > inClose[i - 1] &&
                    // closing within 1st rb
                    inClose[i] > inOpen[i - 2] && inClose[i] < inClose[i - 2];

                outInteger[outIdx++] = is2Crows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose)
                    - GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;

            return RetCode.Success;
        }

        public static int Cdl2CrowsLookback()
        {
            return GetCandleAvgPeriod(CandleSettingType.BodyLong) + 2;
        }
    }
}
