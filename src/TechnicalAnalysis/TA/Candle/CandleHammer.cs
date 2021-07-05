using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleHammer : CandleIndicator
    {
        public CandleHammer(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlHammer(
            int startIdx,
            int endIdx,
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
            if (open == null || high == null || low == null || close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlHammerLookback();

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
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(Near);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += GetCandleRange(ShadowLong, i);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx - 1)
            {
                nearPeriodTotal += GetCandleRange(Near, i);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - small real body
             * - long lower shadow
             * - no, or very short, upper shadow
             * - body below or near the lows of the previous candle
             * The meaning of "short", "long" and "near the lows" is specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): hammer is always bullish;
             * the user should consider that a hammer must appear in a downtrend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isHammer =
                    // small rb
                    GetRealBody(i) < GetCandleAverage(BodyShort, bodyPeriodTotal, i) &&
                    // long lower shadow
                    GetLowerShadow(i) > GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i) &&
                    // very short upper shadow
                    GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i) &&
                    // rb near the prior candle's lows
                    Min(close[i], open[i]) <= low[i - 1] + GetCandleAverage(Near, nearPeriodTotal, i - 1);

                outInteger[outIdx++] = isHammer ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyTrailingIdx);

                shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx);

                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx);

                nearPeriodTotal +=
                    GetCandleRange(Near, i - 1) -
                    GetCandleRange(Near, nearTrailingIdx);

                i++;
                bodyTrailingIdx++;
                shadowLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);
            
            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlHammerLookback()
        {
            return Max(
                Max(
                    Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(ShadowLong)),
                    GetCandleAvgPeriod(ShadowVeryShort)),
                GetCandleAvgPeriod(Near)
            ) + 1;
        }
    }
}
