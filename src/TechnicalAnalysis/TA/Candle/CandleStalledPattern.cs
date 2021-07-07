using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleStalledPattern : CandleIndicator
    {
        public CandleStalledPattern(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double[] bodyLongPeriodTotal = new double[3];
            double[] nearPeriodTotal = new double[3];
            
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

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlStalledPatternLookback();

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
            bodyLongPeriodTotal[2] = 0.0;
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[2] += GetCandleRange(BodyLong, i - 2);
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2);
                nearPeriodTotal[1] += GetCandleRange(Near, i - 1);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white candlesticks with consecutively higher closes
             * - first candle: long white
             * - second candle: long white with no or very short upper shadow opening within or near the previous white real body
             * and closing higher than the prior candle
             * - third candle: small white that gaps away or "rides on the shoulder" of the prior long real body (= it's at 
             * the upper end of the prior real body)
             * The meanings of "long", "very short", "short", "near" are specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): stalled pattern is always bearish;
             * the user should consider that stalled pattern is significant when it appears in uptrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isStalledPattern =
                    // 1st white
                    GetCandleColor(i - 2) == 1 &&
                    // 2nd white
                    GetCandleColor(i - 1) == 1 &&
                    // 3rd white
                    GetCandleColor(i) == 1 &&
                    // consecutive higher closes
                    close[i] > close[i - 1] &&
                    close[i - 1] > close[i - 2] &&
                    // 1st: long real body
                    GetRealBody(i - 2) > GetCandleAverage(BodyLong, bodyLongPeriodTotal[2], i - 2) &&
                    // 2nd: long real body
                    GetRealBody(i - 1) > GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1) &&
                    // very short upper shadow 
                    GetUpperShadow(i - 1) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i - 1) &&
                    // opens within/near 1st real body
                    open[i - 1] > open[i - 2] &&
                    open[i - 1] <= close[i - 2] + GetCandleAverage(Near, nearPeriodTotal[2], i - 2) &&
                    // 3rd: small real body
                    GetRealBody(i) < GetCandleAverage(BodyShort, bodyShortPeriodTotal, i) &&
                    // rides on the shoulder of 2nd real body
                    open[i] >= close[i - 1] - GetRealBody(i) - GetCandleAverage(Near, nearPeriodTotal[1], i - 1);

                outInteger[outIdx++] = isStalledPattern ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);

                    nearPeriodTotal[totIdx] +=
                        GetCandleRange(Near, i - totIdx) -
                        GetCandleRange(Near, nearTrailingIdx - totIdx);
                }

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx);

                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i - 1) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlStalledPatternLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(BodyLong), GetCandleAvgPeriod(BodyShort)),
                Max(GetCandleAvgPeriod(ShadowVeryShort), GetCandleAvgPeriod(Near))
            ) + 2;
        }
    }
}
