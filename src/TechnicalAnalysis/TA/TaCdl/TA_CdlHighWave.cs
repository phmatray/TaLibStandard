using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHighWave(
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
            int lookbackTotal = CdlHighWaveLookback();

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
            double bodyPeriodTotal = 0.0;
            int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowPeriodTotal = 0.0;
            int shadowTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryLong);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowTrailingIdx;
            while (i < startIdx)
            {
                shadowPeriodTotal += GetCandleRange(ShadowVeryLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - short real body
             * - very long upper and lower shadow
             * The meaning of "short" and "very long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when white or negative (-1 to -100) when black;
             * it does not mean bullish or bearish
             */
            int outIdx = 0;
            do
            {
                bool isHighWave =
                    GetRealBody(i, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetUpperShadow(i, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowVeryLong, shadowPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    GetLowerShadow(i, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowVeryLong, shadowPeriodTotal, i, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isHighWave ? GetCandleColor(i, inOpen, inClose) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowPeriodTotal +=
                    GetCandleRange(ShadowVeryLong, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowVeryLong, shadowTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyTrailingIdx++;
                shadowTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHighWaveLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(ShadowVeryLong));
        }
    }
}
