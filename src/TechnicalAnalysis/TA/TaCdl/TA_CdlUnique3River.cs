using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlUnique3River(
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
            int lookbackTotal = CdlUnique3RiverLookback();

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
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: black harami candle with a lower low than the first candle's low
             * - third candle: small white candle with open not lower than the second candle's low, better if its open and 
             *   close are under the second candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): unique 3 river is always bullish and should appear in a downtrend 
             * to be significant, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isUnique3River =
                    // 1st: long
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // black
                    GetCandleColor(i - 2, inOpen, inClose) == -1 &&
                    // 2nd: black
                    GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                    // harami
                    inClose[i - 1] > inClose[i - 2] && inOpen[i - 1] <= inOpen[i - 2] &&
                    // lower low
                    inLow[i - 1] < inLow[i - 2] &&
                    // 3rd: short
                    GetRealBody(i, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // white
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // open not lower
                    inOpen[i] > inLow[i - 1];

                outInteger[outIdx++] = isUnique3River ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlUnique3RiverLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 2;
        }
    }
}
