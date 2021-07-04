using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3BlackCrows(
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
            double[] shadowVeryShortPeriodTotal = new double[3];
            
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
            int lookbackTotal = Cdl3BlackCrowsLookback();
            
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
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] = GetCandleRange(ShadowVeryShort, i - 2, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[1] = GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] = GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three consecutive and declining black candlesticks
             * - each candle must have no or very short lower shadow
             * - each candle after the first must open within the prior candle's real body
             * - the first candle's close should be under the prior white candle's high
             * The meaning of "very short" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): three black crows is always bearish; 
             * the user should consider that 3 black crows is significant when it appears after a mature advance or at high levels, 
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3BlackCrows =
                    // white
                    GetCandleColor(i - 3, inOpen, inClose) == 1 &&
                    // 1st black
                    GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                    // very short lower shadow
                    GetLowerShadow(i - 2, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2,
                        inOpen, inHigh, inLow, inClose) &&
                    // 2nd black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // very short lower shadow
                    GetLowerShadow(i - 1, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1,
                        inOpen, inHigh, inLow, inClose) &&
                    // 3rd black
                    GetCandleColor(i, inOpen, inClose) == -1 &&
                    // very short lower shadow
                    GetLowerShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i,
                        inOpen, inHigh, inLow, inClose) &&
                    // 2nd black opens within 1st black's rb
                    inOpen[i - 1] < inOpen[i - 2] &&
                    inOpen[i - 1] > inClose[i - 2] &&
                    // 3rd black opens within 2nd black's rb
                    inOpen[i] < inOpen[i - 1] &&
                    inOpen[i] > inClose[i - 1] &&
                    // 1st black closes under prior candle's high
                    inHigh[i - 3] > inClose[i - 2] &&
                    // three declining
                    inClose[i - 2] > inClose[i - 1] &&
                    // three declining
                    inClose[i - 1] > inClose[i];

                outInteger[outIdx++] = is3BlackCrows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx,
                            inOpen, inHigh, inLow, inClose);
                }

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3BlackCrowsLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 3;
        }
    }
}
