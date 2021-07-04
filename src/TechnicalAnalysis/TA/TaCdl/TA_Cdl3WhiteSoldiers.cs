using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3WhiteSoldiers(
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
            double[] nearPeriodTotal = new double[3];
            double[] farPeriodTotal = new double[3];

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
            int lookbackTotal = Cdl3WhiteSoldiersLookback();

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
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - GetCandleAvgPeriod(Far);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                nearPeriodTotal[1] += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = farTrailingIdx;
            while (i < startIdx)
            {
                farPeriodTotal[2] += GetCandleRange(Far, i - 2, inOpen, inHigh, inLow, inClose);
                farPeriodTotal[1] += GetCandleRange(Far, i - 1, inOpen, inHigh, inLow, inClose);
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
             * - three white candlesticks with consecutively higher closes
             * - Greg Morris wants them to be long, Steve Nison doesn't; anyway they should not be short
             * - each candle opens within or near the previous white real body 
             * - each candle must have no or very short upper shadow
             * - to differentiate this pattern from advance block, each candle must not be far shorter than the prior candle
             * The meanings of "not short", "very short shadow", "far" and "near" are specified with TA_SetCandleSettings;
             * here the 3 candles must be not short, if you want them to be long use TA_SetCandleSettings on BodyShort;
             * outInteger is positive (1 to 100): advancing 3 white soldiers is always bullish;
             * the user should consider that 3 white soldiers is significant when it appears in downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3WhiteSoldiers =
                    // 1st white
                    GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                    // very short upper shadow
                    GetUpperShadow(i - 2, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2,
                        inOpen, inHigh, inLow, inClose) &&
                    // 2nd white                
                    GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                    // very short upper shadow
                    GetUpperShadow(i - 1, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1,
                        inOpen, inHigh, inLow, inClose) &&
                    // 3rd white   
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // very short upper shadow
                    GetUpperShadow(i, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i,
                        inOpen, inHigh, inLow, inClose) &&
                    // consecutive higher closes           
                    inClose[i] > inClose[i - 1] &&
                    inClose[i - 1] > inClose[i - 2] &&
                    // 2nd opens within/near 1st real body
                    inOpen[i - 1] > inOpen[i - 2] &&
                    inOpen[i - 1] <= inClose[i - 2] +
                    GetCandleAverage(Near, nearPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 3rd opens within/near 2nd real body
                    inOpen[i] > inOpen[i - 1] &&
                    inOpen[i] <= inClose[i - 1] +
                    GetCandleAverage(Near, nearPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 2nd not far shorter than 1st
                    GetRealBody(i - 1, inOpen, inClose) > GetRealBody(i - 2, inOpen, inClose) -
                    GetCandleAverage(Far, farPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 3rd not far shorter than 2nd
                    GetRealBody(i, inOpen, inClose) > GetRealBody(i - 1, inOpen, inClose) -
                    GetCandleAverage(Far, farPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // not short real body
                    GetRealBody(i, inOpen, inClose) > GetCandleAverage(BodyShort, bodyShortPeriodTotal, i,
                        inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = is3WhiteSoldiers ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowVeryShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, inOpen, inHigh, inLow,
                            inClose);
                }

                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    farPeriodTotal[totIdx] +=
                        GetCandleRange(Far, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(Far, farTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);

                    nearPeriodTotal[totIdx] +=
                        GetCandleRange(Near, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(Near, nearTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                shadowVeryShortTrailingIdx++;
                nearTrailingIdx++;
                farTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3WhiteSoldiersLookback()
        {
            return Math.Max(
                Math.Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(BodyShort)),
                Math.Max(GetCandleAvgPeriod(Far), GetCandleAvgPeriod(Near))
            ) + 2;
        }
    }
}
