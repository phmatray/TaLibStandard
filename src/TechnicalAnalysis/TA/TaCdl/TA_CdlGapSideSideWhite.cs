using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlGapSideSideWhite(
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
            int lookbackTotal = CdlGapSideSideWhiteLookback();

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
            double nearPeriodTotal = 0.0;
            double equalPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - upside or downside gap (between the bodies)
             * - first candle after the window: white candlestick
             * - second candle after the window: white candlestick with similar size (near the same) and about the same 
             *   open (equal) of the previous candle
             * - the second candle does not close the window
             * The meaning of "near" and "equal" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) or negative (-1 to -100): the user should consider that upside 
             * or downside gap side-by-side white lines is significant when it appears in a trend, while this function 
             * does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isGapSideSideWhite =
                    ( // upside or downside gap between the 1st candle and both the next 2 candles
                        (
                            GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose) &&
                            GetRealBodyGapUp(i, i - 2, inOpen, inClose)
                        )
                        ||
                        (
                            GetRealBodyGapDown(i - 1, i - 2, inOpen, inClose) &&
                            GetRealBodyGapDown(i, i - 2, inOpen, inClose)
                        )
                    ) &&
                    // 2nd: white
                    GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                    // 3rd: white
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // same size 2 and 3
                    GetRealBody(i, inOpen, inClose) >= GetRealBody(i - 1, inOpen, inClose) -
                    GetCandleAverage(Near, nearPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i, inOpen, inClose) <= GetRealBody(i - 1, inOpen, inClose) +
                    GetCandleAverage(Near, nearPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    // same open 2 and 3
                    inOpen[i] >= inOpen[i - 1] -
                    GetCandleAverage(Equal, equalPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose) &&
                    inOpen[i] <= inOpen[i - 1] +
                    GetCandleAverage(Equal, equalPeriodTotal, i - 1, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] =
                    isGapSideSideWhite ? GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose) ? 100 : -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                nearPeriodTotal +=
                    GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Near, nearTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Equal, equalTrailingIdx - 1, inOpen, inHigh, inLow, inClose);

                i++;
                nearTrailingIdx++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlGapSideSideWhiteLookback()
        {
            return Math.Max(GetCandleAvgPeriod(Near), GetCandleAvgPeriod(Equal)) + 2;
        }
    }
}
