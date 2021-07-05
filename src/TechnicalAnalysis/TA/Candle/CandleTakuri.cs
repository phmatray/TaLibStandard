using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleTakuri : CandleIndicator
    {
        public CandleTakuri(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlTakuri(
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
            int lookbackTotal = this.CdlTakuriLookback();

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
            double bodyDojiPeriodTotal = 0.0;
            int bodyDojiTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyDoji);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            double shadowVeryLongPeriodTotal = 0.0;
            int shadowVeryLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryLong);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowVeryLongTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryLongPeriodTotal += this.GetCandleRange(ShadowVeryLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - open and close at the high of the day = no or very short upper shadow
             * - very long lower shadow
             * The meaning of "doji", "very short" and "very long" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: takuri must be considered
             * relatively to the trend
             */
            int outIdx = 0;
            do
            {
                bool isTakuri =
                    this.GetRealBody(i, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    this.GetLowerShadow(i, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowVeryLong, shadowVeryLongPeriodTotal, i, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isTakuri ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyDojiPeriodTotal +=
                    this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyDoji, bodyDojiTrailingIdx, this.open, this.high, this.low, this.close);

                shadowVeryShortPeriodTotal +=
                    this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, this.open, this.high, this.low, this.close);

                shadowVeryLongPeriodTotal +=
                    this.GetCandleRange(ShadowVeryLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryLong, shadowVeryLongTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyDojiTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                shadowVeryLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlTakuriLookback()
        {
            return Math.Max(
                Math.Max(this.GetCandleAvgPeriod(BodyDoji), this.GetCandleAvgPeriod(ShadowVeryShort)),
                this.GetCandleAvgPeriod(ShadowVeryLong)
            );
        }
    }
}
