using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleShootingStar : CandleIndicator
    {
        public CandleShootingStar(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlShootingStar(
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
            int lookbackTotal = CdlShootingStarLookback();

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

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - small real body
             * - long upper shadow
             * - no, or very short, lower shadow
             * - gap up from prior real body
             * The meaning of "short", "very short" and "long" is specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): shooting star is always bearish;
             * the user should consider that a shooting star must appear in an uptrend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isShootingStar =
                    // small rb
                    GetRealBody(i) < GetCandleAverage(BodyShort, bodyPeriodTotal, i) &&
                    // long upper shadow
                    GetUpperShadow(i) > GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i) &&
                    // very short lower shadow
                    GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i) &&
                    // gap up
                    GetRealBodyGapUp(i, i - 1);

                outInteger[outIdx++] = isShootingStar ? -100 : 0;

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

                i++;
                bodyTrailingIdx++;
                shadowLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlShootingStarLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(ShadowLong)),
                GetCandleAvgPeriod(ShadowVeryShort)
            ) + 1;
        }
    }
}
