using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlPiercing(
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
            double[] bodyLongPeriodTotal = new double[2];
            
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
            int lookbackTotal = CdlPiercingLookback();

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
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: long white candle with open below previous day low and close at least at 50% of previous day 
             * real body
             * The meaning of "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): piercing pattern is always bullish
             * the user should consider that a piercing pattern is significant when it appears in a downtrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isPiercing =
                    // 1st: black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // long
                    GetRealBody(i - 1, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: white
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // long
                    GetRealBody(i, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) &&
                    // open below prior low
                    inOpen[i] < inLow[i - 1] &&
                    // close within prior body
                    inClose[i] < inOpen[i - 1] &&
                    // above midpoint
                    inClose[i] > inClose[i - 1] + GetRealBody(i - 1, inOpen, inClose) * 0.5;

                outInteger[outIdx++] = isPiercing ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlPiercingLookback()
        {
            return GetCandleAvgPeriod(BodyLong) + 1;
        }
    }
}
