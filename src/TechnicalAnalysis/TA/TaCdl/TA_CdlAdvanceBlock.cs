using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlAdvanceBlock(
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
            double[] shadowShortPeriodTotal = new double[3];
            double[] shadowLongPeriodTotal = new double[2];
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
            int lookbackTotal = CdlAdvanceBlockLookback();

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
            shadowShortPeriodTotal[2] = 0.0;
            shadowShortPeriodTotal[1] = 0.0;
            shadowShortPeriodTotal[0] = 0.0;
            int shadowShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowShort);
            shadowLongPeriodTotal[1] = 0.0;
            shadowLongPeriodTotal[0] = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - GetCandleAvgPeriod(Far);
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = shadowShortTrailingIdx;
            while (i < startIdx)
            {
                shadowShortPeriodTotal[2] += GetCandleRange(ShadowShort, i - 2, inOpen, inHigh, inLow, inClose);
                shadowShortPeriodTotal[1] += GetCandleRange(ShadowShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowShortPeriodTotal[0] += GetCandleRange(ShadowShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal[1] += GetCandleRange(ShadowLong, i - 1, inOpen, inHigh, inLow, inClose);
                shadowLongPeriodTotal[0] += GetCandleRange(ShadowLong, i, inOpen, inHigh, inLow, inClose);
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

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white candlesticks with consecutively higher closes
             * - each candle opens within or near the previous white real body 
             * - first candle: long white with no or very short upper shadow (a short shadow is accepted too for more flexibility)
             * - second and third candles, or only third candle, show signs of weakening: progressively smaller white real bodies 
             * and/or relatively long upper shadows; see below for specific conditions
             * The meanings of "long body", "short shadow", "far" and "near" are specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): advance block is always bearish;
             * the user should consider that advance block is significant when it appears in uptrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isAdvanceBlock =
                    // 1st white
                    GetCandleColor(i - 2, inOpen, inClose) == 1 &&
                    // 2nd white
                    GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                    // 3rd white
                    GetCandleColor(i, inOpen, inClose) == 1 &&
                    // consecutive higher closes
                    inClose[i] > inClose[i - 1] && inClose[i - 1] > inClose[i - 2] &&
                    // 2nd opens within/near 1st real body
                    inOpen[i - 1] > inOpen[i - 2] &&
                    inOpen[i - 1] <= inClose[i - 2] + GetCandleAverage(Near, nearPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 3rd opens within/near 2nd real body
                    inOpen[i] > inOpen[i - 1] &&
                    inOpen[i] <= inClose[i - 1] +
                    GetCandleAverage(Near, nearPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose) &&
                    // 1st: long real body
                    GetRealBody(i - 2, inOpen, inClose) >
                    GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, inOpen, inHigh, inLow, inClose) &&
                    // 1st: short upper shadow
                    GetUpperShadow(i - 2, inOpen, inLow, inClose) <
                    GetCandleAverage(ShadowShort, shadowShortPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                    (
                        // ( 2 far smaller than 1 && 3 not longer than 2 )
                        // advance blocked with the 2nd, 3rd must not carry on the advance
                        (
                            GetRealBody(i - 1, inOpen, inClose) < GetRealBody(i - 2, inOpen, inClose) -
                            GetCandleAverage(Far, farPeriodTotal[2], i - 2, inOpen, inHigh, inLow, inClose) &&
                            GetRealBody(i, inOpen, inClose) < GetRealBody(i - 1, inOpen, inClose) +
                            GetCandleAverage(Near, nearPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose)
                        ) ||
                        // 3 far smaller than 2
                        // advance blocked with the 3rd
                        (
                            GetRealBody(i, inOpen, inClose) < GetRealBody(i - 1, inOpen, inClose) -
                            GetCandleAverage(Far, farPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose)
                        ) ||
                        // ( 3 smaller than 2 && 2 smaller than 1 && (3 or 2 not short upper shadow) )
                        // advance blocked with progressively smaller real bodies and some upper shadows
                        (
                            GetRealBody(i, inOpen, inClose) < GetRealBody(i - 1, inOpen, inClose) &&
                            GetRealBody(i - 1, inOpen, inClose) < GetRealBody(i - 2, inOpen, inClose) &&
                            (
                                GetUpperShadow(i, inOpen, inLow, inClose) > 
                                GetCandleAverage(ShadowShort, shadowShortPeriodTotal[0], i, inOpen, inHigh, inLow, inClose) ||
                                GetUpperShadow(i - 1, inOpen, inLow, inClose) > 
                                GetCandleAverage(ShadowShort, shadowShortPeriodTotal[1], i - 1, inOpen, inHigh, inLow, inClose)
                            )
                        ) ||
                        // ( 3 smaller than 2 && 3 long upper shadow )
                        // advance blocked with 3rd candle's long upper shadow and smaller body
                        (
                            GetRealBody(i, inOpen, inClose) < GetRealBody(i - 1, inOpen, inClose) &&
                            GetUpperShadow(i, inOpen, inLow, inClose) >
                            GetCandleAverage(ShadowLong, shadowLongPeriodTotal[0], i, inOpen, inHigh, inLow, inClose)
                        )
                    );

                outInteger[outIdx++] = isAdvanceBlock ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowShort, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowShort, shadowShortTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
                }

                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    shadowLongPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowLong, i - totIdx, inOpen, inHigh, inLow, inClose) -
                        GetCandleRange(ShadowLong, shadowLongTrailingIdx - totIdx, inOpen, inHigh, inLow, inClose);
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

                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 2, inOpen, inHigh, inLow, inClose);

                i++;
                shadowShortTrailingIdx++;
                shadowLongTrailingIdx++;
                nearTrailingIdx++;
                farTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlAdvanceBlockLookback()
        {
            return Math.Max(
                Math.Max(
                    Math.Max(GetCandleAvgPeriod(ShadowLong), GetCandleAvgPeriod(ShadowShort)),
                    Math.Max(GetCandleAvgPeriod(Far), GetCandleAvgPeriod(Near))),
                GetCandleAvgPeriod(BodyLong)
            ) + 2;
        }
    }
}
