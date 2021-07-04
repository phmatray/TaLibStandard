using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlTristar(
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
            int lookbackTotal = CdlTristarLookback();

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
            int bodyTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyDoji);
            
            int i = bodyTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - 3 consecutive doji days
             * - the second doji is a star
             * The meaning of "doji" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish
             */
            int outIdx = 0;
            do
            {
                bool isCdlTristar =
                    // 1st: doji
                    GetRealBody(i - 2, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 2nd: doji
                    GetRealBody(i - 1, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 3rd: doji
                    GetRealBody(i, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose);

                if (isCdlTristar)
                {
                    outInteger[outIdx] = 0;

                    if ( // 2nd gaps up
                        GetRealBodyGapUp(i - 1, i - 2, inOpen, inClose) &&
                        // 3rd is not higher than 2nd
                        Math.Max(inOpen[i], inClose[i]) < Math.Max(inOpen[i - 1], inClose[i - 1]))
                    {
                        outInteger[outIdx] = -100;
                    }

                    if ( // 2nd gaps down 
                        GetRealBodyGapDown(i - 1, i - 2, inOpen, inClose) &&
                        // 3rd is not lower than 2nd
                        Math.Min(inOpen[i], inClose[i]) > Math.Min(inOpen[i - 1], inClose[i - 1]))
                    {
                        outInteger[outIdx] = +100;
                    }

                    outIdx++;
                }
                else
                {
                    outInteger[outIdx++] = 0;
                }

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyDoji, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyDoji, bodyTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlTristarLookback()
        {
            return GetCandleAvgPeriod(BodyDoji) + 2;
        }
    }
}
