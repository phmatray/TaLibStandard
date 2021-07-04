using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlMatHold(
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
            // Local variables
            double[] bodyPeriodTotal = new double[5];

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
            int lookbackTotal = CdlMatHoldLookback();

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
            bodyPeriodTotal[4] = 0.0;
            bodyPeriodTotal[3] = 0.0;
            bodyPeriodTotal[2] = 0.0;
            bodyPeriodTotal[1] = 0.0;
            bodyPeriodTotal[0] = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[3] += GetCandleRange(BodyShort, i - 3, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[2] += GetCandleRange(BodyShort, i - 2, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[1] += GetCandleRange(BodyShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[4] += GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white candle
             * - upside gap between the first and the second bodies
             * - second candle: small black candle
             * - third and fourth candles: falling small real body candlesticks (commonly black) that hold within the long 
             *   white candle's body and are higher than the reaction days of the rising three methods
             * - fifth candle: white candle that opens above the previous small candle's close and closes higher than the 
             *   high of the highest reaction day
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings; 
             * "hold within" means "a part of the real body must be within";
             * optInPenetration is the maximum percentage of the first white body the reaction days can penetrate (it is 
             * to specify how much the reaction days should be "higher than the reaction days of the rising three methods")
             * outInteger is positive (1 to 100): mat hold is always bullish
             */
            int outIdx = 0;
            do
            {
                bool isMatHold =
                    // 1st long, then 3 small
                    GetRealBody(i - 4, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyPeriodTotal[4], i - 4, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i - 3, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal[3], i - 3, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i - 2, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    GetRealBody(i - 1, inOpen, inClose) <
                    GetCandleAverage(BodyShort, bodyPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // white, black, 2 black or white, white
                    GetCandleColor(i - 4, inOpen, inClose) == 1 &&
                    GetCandleColor(i - 3, inOpen, inClose) == -1 &&
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // upside gap 1st to 2nd
                    GetRealBodyGapUp(i - 3, i - 4, inOpen, inClose) &&
                    // 3rd to 4th hold within 1st: a part of the real body must be within 1st real body
                    Math.Min(inOpen[i - 2], inClose[i - 2]) < inClose[i - 4] &&
                    Math.Min(inOpen[i - 1], inClose[i - 1]) < inClose[i - 4] &&
                    // reaction days penetrate first body less than optInPenetration percent
                    Math.Min(inOpen[i - 2], inClose[i - 2]) >
                    inClose[i - 4] - GetRealBody(i - 4, inOpen, inClose) * optInPenetration &&
                    Math.Min(inOpen[i - 1], inClose[i - 1]) >
                    inClose[i - 4] - GetRealBody(i - 4, inOpen, inClose) * optInPenetration &&
                    // 2nd to 4th are falling
                    Math.Max(inClose[i - 2], inOpen[i - 2]) < inOpen[i - 3] &&
                    Math.Max(inClose[i - 1], inOpen[i - 1]) < Math.Max(inClose[i - 2], inOpen[i - 2]) &&
                    // 5th opens above the prior close
                    inOpen[i] > inClose[i - 1] &&
                    // 5th closes above the highest high of the reaction days
                    inClose[i] > Math.Max(Math.Max(inHigh[i - 3], inHigh[i - 2]), inHigh[i - 1]);

                outInteger[outIdx++] = isMatHold ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal[4] +=
                    GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 4, inOpen, inHigh, inLow, inClose);

                int totIdx;
                for (totIdx = 3; totIdx >= 1; --totIdx)
                {
                    bodyPeriodTotal[totIdx] +=
                        GetCandleRange(BodyShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                i++;
                bodyShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlMatHoldLookback()
        {
            return Math.Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 4;
        }
    }
}
