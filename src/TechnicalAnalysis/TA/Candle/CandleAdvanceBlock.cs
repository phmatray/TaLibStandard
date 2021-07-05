using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleAdvanceBlock : CandleIndicator
    {
        public CandleAdvanceBlock(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode TryCompute(
            int startIdx,
            int endIdx,
            out int outBegIdx,
            out int outNBElement,
            out int[] outInteger)
        {
            // Initialize output variables 
            outBegIdx = default;
            outNBElement = default;
            outInteger = new int[endIdx - startIdx + 1];
            
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
            if (open == null || high == null || low == null || close == null)
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
                shadowShortPeriodTotal[2] += GetCandleRange(ShadowShort, i - 2);
                shadowShortPeriodTotal[1] += GetCandleRange(ShadowShort, i - 1);
                shadowShortPeriodTotal[0] += GetCandleRange(ShadowShort, i);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal[1] += GetCandleRange(ShadowLong, i - 1);
                shadowLongPeriodTotal[0] += GetCandleRange(ShadowLong, i);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2);
                nearPeriodTotal[1] += GetCandleRange(Near, i - 1);
                i++;
            }

            i = farTrailingIdx;
            while (i < startIdx)
            {
                farPeriodTotal[2] += GetCandleRange(Far, i - 2);
                farPeriodTotal[1] += GetCandleRange(Far, i - 1);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2);
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
                    GetCandleColor(i - 2) == 1 &&
                    // 2nd white
                    GetCandleColor(i - 1) == 1 &&
                    // 3rd white
                    GetCandleColor(i) == 1 &&
                    // consecutive higher closes
                    close[i] > close[i - 1] && close[i - 1] > close[i - 2] &&
                    // 2nd opens within/near 1st real body
                    open[i - 1] > open[i - 2] &&
                    open[i - 1] <= close[i - 2] + GetCandleAverage(Near, nearPeriodTotal[2], i - 2) &&
                    // 3rd opens within/near 2nd real body
                    open[i] > open[i - 1] &&
                    open[i] <= close[i - 1] + GetCandleAverage(Near, nearPeriodTotal[1], i - 1) &&
                    // 1st: long real body
                    GetRealBody(i - 2) > GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2) &&
                    // 1st: short upper shadow
                    GetUpperShadow(i - 2) < GetCandleAverage(ShadowShort, shadowShortPeriodTotal[2], i - 2) &&
                    (
                        // ( 2 far smaller than 1 && 3 not longer than 2 )
                        // advance blocked with the 2nd, 3rd must not carry on the advance
                        (
                            GetRealBody(i - 1) < GetRealBody(i - 2) -
                            GetCandleAverage(Far, farPeriodTotal[2], i - 2) &&
                            GetRealBody(i) < GetRealBody(i - 1) +
                            GetCandleAverage(Near, nearPeriodTotal[1], i - 1)
                        ) ||
                        // 3 far smaller than 2
                        // advance blocked with the 3rd
                        (
                            GetRealBody(i) < GetRealBody(i - 1) -
                            GetCandleAverage(Far, farPeriodTotal[1], i - 1)
                        ) ||
                        // ( 3 smaller than 2 && 2 smaller than 1 && (3 or 2 not short upper shadow) )
                        // advance blocked with progressively smaller real bodies and some upper shadows
                        (
                            GetRealBody(i) < GetRealBody(i - 1) &&
                            GetRealBody(i - 1) < GetRealBody(i - 2) &&
                            (
                                GetUpperShadow(i) > 
                                GetCandleAverage(ShadowShort, shadowShortPeriodTotal[0], i) ||
                                GetUpperShadow(i - 1) > 
                                GetCandleAverage(ShadowShort, shadowShortPeriodTotal[1], i - 1)
                            )
                        ) ||
                        // ( 3 smaller than 2 && 3 long upper shadow )
                        // advance blocked with 3rd candle's long upper shadow and smaller body
                        (
                            GetRealBody(i) < GetRealBody(i - 1) &&
                            GetUpperShadow(i) > GetCandleAverage(ShadowLong, shadowLongPeriodTotal[0], i)
                        )
                    );

                outInteger[outIdx++] = isAdvanceBlock ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowShortPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowShort, i - totIdx) -
                        GetCandleRange(ShadowShort, shadowShortTrailingIdx - totIdx);
                }

                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    shadowLongPeriodTotal[totIdx] +=
                        GetCandleRange(ShadowLong, i - totIdx) -
                        GetCandleRange(ShadowLong, shadowLongTrailingIdx - totIdx);
                }

                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    farPeriodTotal[totIdx] +=
                        GetCandleRange(Far, i - totIdx) -
                        GetCandleRange(Far, farTrailingIdx - totIdx);

                    nearPeriodTotal[totIdx] +=
                        GetCandleRange(Near, i - totIdx) -
                        GetCandleRange(Near, nearTrailingIdx - totIdx);
                }

                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 2);

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

        public int CdlAdvanceBlockLookback()
        {
            return Max(
                Max(
                    Max(GetCandleAvgPeriod(ShadowLong), GetCandleAvgPeriod(ShadowShort)),
                    Max(GetCandleAvgPeriod(Far), GetCandleAvgPeriod(Near))),
                GetCandleAvgPeriod(BodyLong)
            ) + 2;
        }
    }
}
