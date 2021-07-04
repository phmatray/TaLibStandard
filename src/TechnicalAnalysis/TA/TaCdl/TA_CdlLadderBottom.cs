using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlLadderBottom(
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
            int lookbackTotal = CdlLadderBottomLookback();

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
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three black candlesticks with consecutively lower opens and closes
             * - fourth candle: black candle with an upper shadow (it's supposed to be not very short)
             * - fifth candle: white candle that opens above prior candle's body and closes above prior candle's high
             * The meaning of "very short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): ladder bottom is always bullish; 
             * the user should consider that ladder bottom is significant when it appears in a downtrend, 
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isLadderBottom =
                    // 3 black candlesticks
                    GetCandleColor(i - 4, inOpen, inClose) == -1 &&
                    GetCandleColor(i - 3, inOpen, inClose) == -1 &&
                    GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                    // with consecutively lower opens
                    inOpen[i - 4] > inOpen[i - 3] &&
                    inOpen[i - 3] > inOpen[i - 2] &&
                    // and closes
                    inClose[i - 4] > inClose[i - 3] &&
                    inClose[i - 3] > inClose[i - 2] &&
                    // 4th: black with an upper shadow
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    GetUpperShadow(i - 1, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 5th: white
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // that opens above prior candle's body
                    inOpen[i] > inOpen[i - 1] &&
                    // and closes above prior candle's high
                    inClose[i] > inHigh[i - 1];

                outInteger[outIdx++] = isLadderBottom ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlLadderBottomLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 4;
        }
    }
}
