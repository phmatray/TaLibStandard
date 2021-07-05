using System;
using TechnicalAnalysis.Abstractions;
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
            if (this.open == null || this.high == null || this.low == null || this.close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.CdlHammerLookback();

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
            int bodyTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyShort);
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowLong);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - 1 - this.GetCandleAvgPeriod(Near);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += this.GetCandleRange(ShadowLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx - 1)
            {
                nearPeriodTotal += this.GetCandleRange(Near, i, this.open, this.high, this.low, this.close);
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
                    this.GetRealBody(i, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // long lower shadow
                    this.GetLowerShadow(i, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // very short upper shadow
                    this.GetUpperShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // rb near the prior candle's lows
                    Math.Min(this.close[i], this.open[i]) <= this.low[i - 1] +
                    this.GetCandleAverage(Near, nearPeriodTotal, i - 1, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isHammer ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyShort, bodyTrailingIdx, this.open, this.high, this.low, this.close);

                shadowLongPeriodTotal +=
                    this.GetCandleRange(ShadowLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowLong, shadowLongTrailingIdx, this.open, this.high, this.low, this.close);

                shadowVeryShortPeriodTotal +=
                    this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, this.open, this.high, this.low, this.close);

                nearPeriodTotal +=
                    this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Near, nearTrailingIdx, this.open, this.high, this.low, this.close);

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
            return Math.Max(
                Math.Max(
                    Math.Max(this.GetCandleAvgPeriod(BodyShort), this.GetCandleAvgPeriod(ShadowLong)),
                    this.GetCandleAvgPeriod(ShadowVeryShort)),
                this.GetCandleAvgPeriod(Near)
            ) + 1;
        }
    }
}
