using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            in double optInPenetration,
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

            if (optInPenetration < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlDarkCloudCoverLookback();

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
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white candle
             * - second candle: black candle that opens above previous day high and closes within previous day real body; 
             * Greg Morris wants the close to be below the midpoint of the previous real body
             * The meaning of "long" is specified with TA_SetCandleSettings, the penetration of the first real body is specified
             * with optInPenetration
             * outInteger is negative (-1 to -100): dark cloud cover is always bearish
             * the user should consider that a dark cloud cover is significant when it appears in an uptrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isDarkCloudCover =
                    // 1st: white
                    GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                    // long
                    GetRealBody(i - 1, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // open above prior high
                    inOpen[i] > inHigh[i - 1] &&
                    // close within prior body
                    inClose[i] > inOpen[i - 1] &&
                    inClose[i] < inClose[i - 1] - GetRealBody(i - 1, inOpen, inClose) * optInPenetration;

                outInteger[outIdx++] = isDarkCloudCover ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlDarkCloudCoverLookback()
        {
            return GetCandleAvgPeriod(BodyLong) + 1;
        }
    }
}
