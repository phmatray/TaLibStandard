using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlConcealBabySwallow(
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
            double[] shadowVeryShortPeriodTotal = new double[4];
            
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
            int lookbackTotal = CdlConcealBabySwallowLookback();

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
            shadowVeryShortPeriodTotal[3] = 0.0;
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[3] += GetCandleRange(ShadowVeryShort, i - 3, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black marubozu (very short shadows)
             * - second candle: black marubozu (very short shadows)
             * - third candle: black candle that opens gapping down but has an upper shadow that extends into the prior body
             * - fourth candle: black candle that completely engulfs the third candle, including the shadows
             * The meanings of "very short shadow" are specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): concealing baby swallow is always bullish;
             * the user should consider that concealing baby swallow is significant when it appears in downtrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isConcealBabySwallow =
                    // 1st black
                    GetCandleColor(i - 3, inOpen, inClose) == -1 &&
                    // 2nd black
                    GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                    // 3rd black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // 4th black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // 1st: marubozu
                    GetLowerShadow(i - 3, inOpen, inLow, inClose) < 
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[3], i - 3, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i - 3, inOpen, inLow, inClose) < 
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[3], i - 3, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: marubozu
                    GetLowerShadow(i - 2, inOpen, inLow, inClose) < 
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i - 2, inOpen, inLow, inClose) < 
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 3rd: opens gapping down
                    GetRealBodyGapDown(i - 1, i - 2, inOpen, inClose) &&
                    // and HAS an upper shadow
                    GetUpperShadow(i - 1, inOpen, inLow, inClose) > 
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // that extends into the prior body
                    inHigh[i - 1] > inClose[i - 2] &&
                    // 4th: engulfs the 3rd including the shadows
                    inHigh[i] > inHigh[i - 1] && inLow[i] < inLow[i - 1];

                outInteger[outIdx++] = isConcealBabySwallow ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 1; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlConcealBabySwallowLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
