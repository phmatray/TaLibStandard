using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleBeltHold : CandleIndicator
    {
        public CandleBeltHold(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlBeltHold(
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
            int lookbackTotal = this.CdlBeltHoldLookback();

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
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - long white (black) real body
             * - no or very short lower (upper) shadow
             * The meaning of "long" and "very short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when white (bullish), negative (-1 to -100) when black (bearish)
             */
            int outIdx = 0;
            do
            {
                bool isBeltHold =
                    // long body
                    this.GetRealBody(i, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i, this.open, this.high, this.low, this.close) && 
                    (
                        ( // white body and very short lower shadow
                            this.GetCandleColor(i, this.open, this.close) == 1 &&
                            this.GetLowerShadow(i, this.open, this.low, this.close) <
                            this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, this.open, this.high, this.low, this.close)
                        ) ||
                        ( // black body and very short upper shadow
                            this.GetCandleColor(i, this.open, this.close) == -1 &&
                            this.GetUpperShadow(i, this.open, this.low, this.close) <
                            this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, this.open, this.high, this.low, this.close)
                        )
                    );

                outInteger[outIdx++] = isBeltHold ? this.GetCandleColor(i, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx, this.open, this.high, this.low, this.close);

                shadowVeryShortPeriodTotal +=
                    this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlBeltHoldLookback()
        {
            return Math.Max( this.GetCandleAvgPeriod(BodyLong), this.GetCandleAvgPeriod(ShadowVeryShort) );
        }
    }
}
