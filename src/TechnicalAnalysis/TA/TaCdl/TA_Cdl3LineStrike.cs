using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3LineStrike(
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
            double[] nearPeriodTotal = new double[4];

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
            int lookbackTotal = Cdl3LineStrikeLookback();

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
            nearPeriodTotal[3] = 0.0;
            nearPeriodTotal[2] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[3] += GetCandleRange(Near, i - 3, inOpen, inHigh, inLow, inClose);
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white soldiers (three black crows): three white (black) candlesticks with consecutively higher (lower) closes,
             * each opening within or near the previous real body
             * - fourth candle: black (white) candle that opens above (below) prior candle's close and closes below (above) 
             * the first candle's open
             * The meaning of "near" is specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that 3-line strike is significant when it appears in a trend in the same direction of
             * the first three candles, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3LineStrike =
                    // three with same color
                    GetCandleColor(i - 3, inOpen, inClose) == GetCandleColor(i - 2, inOpen, inClose) &&
                    GetCandleColor(i - 2, inOpen, inClose) == GetCandleColor(i - 1, inOpen, inClose) &&
                    // 4th opposite color
                    GetCandleColor(i, inOpen, inClose) == -GetCandleColor(i - 1, inOpen, inClose) &&
                    // 2nd opens within/near 1st rb
                    inOpen[i - 2] >= Math.Min(inOpen[i - 3], inClose[i - 3]) -
                    GetCandleAverage(Near, nearPeriodTotal[3], i - 3, inOpen, inHigh, inLow, inClose) &&
                    inOpen[i - 2] <= Math.Max(inOpen[i - 3], inClose[i - 3]) +
                    GetCandleAverage(Near, nearPeriodTotal[3], i - 3, inOpen, inHigh, inLow, inClose) &&
                    // 3rd opens within/near 2nd rb
                    inOpen[i - 1] >= Math.Min(inOpen[i - 2], inClose[i - 2]) -
                    GetCandleAverage(Near, nearPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    inOpen[i - 1] <= Math.Max(inOpen[i - 2], inClose[i - 2]) +
                    GetCandleAverage(Near, nearPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    (
                        ( // if three white
                            GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                            inClose[i - 1] > inClose[i - 2] &&
                            // consecutive higher closes
                            inClose[i - 2] > inClose[i - 3] &&
                            // 4th opens above prior close
                            inOpen[i] > inClose[i - 1] &&
                            // 4th closes below 1st open
                            inClose[i] < inOpen[i - 3]
                        ) ||
                        ( // if three black
                            GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                            inClose[i - 1] < inClose[i - 2] &&
                            // consecutive lower closes
                            inClose[i - 2] < inClose[i - 3] &&
                            // 4th opens below prior close
                            inOpen[i] < inClose[i - 1] &&
                            // 4th closes above 1st open
                            inClose[i] > inOpen[i - 3]
                        )
                    );

                outInteger[outIdx++] = is3LineStrike ? GetCandleColor(i - 1, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 2; --totIdx)
                {
                    nearPeriodTotal[totIdx] +=
                        GetCandleRange(Near, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(Near, nearTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                i++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3LineStrikeLookback()
        {
            return GetCandleAvgPeriod(Near) + 3;
        }
    }
}
