using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleSeparatingLines : CandleIndicator
    {
        public CandleSeparatingLines(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlSeparatingLines(
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
            int lookbackTotal = this.CdlSeparatingLinesLookback();

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
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            double equalPeriodTotal = 0.0;
            int equalTrailingIdx = startIdx - this.GetCandleAvgPeriod(Equal);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black (white) candle
             * - second candle: bullish (bearish) belt hold with the same open as the prior candle
             * The meaning of "long body" and "very short shadow" of the belt hold is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that separating lines is significant when coming in a trend and the belt hold has 
             * the same direction of the trend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isSeparatingLines =
                    // opposite candles
                    this.GetCandleColor(i - 1, this.open, this.close) == -this.GetCandleColor(i, this.open, this.close) &&
                    // same open
                    this.open[i] <= this.open[i - 1] +
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    this.open[i] >= this.open[i - 1] -
                    this.GetCandleAverage(Equal, equalPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // belt hold: long body
                    this.GetRealBody(i, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    (
                        (
                            // with no lower shadow if bullish
                            this.GetCandleColor(i, this.open, this.close) == 1 &&
                            this.GetLowerShadow(i, this.open, this.low, this.close) <
                            this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, this.open, this.high, this.low, this.close)
                        )
                        ||
                        (
                            // with no upper shadow if bearish
                            this.GetCandleColor(i, this.open, this.close) == -1 &&
                            this.GetUpperShadow(i, this.open, this.low, this.close) <
                            this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i, this.open, this.high, this.low, this.close)
                        )
                    );

                outInteger[outIdx++] = isSeparatingLines ? this.GetCandleColor(i, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                shadowVeryShortPeriodTotal +=
                    this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx, this.open, this.high, this.low, this.close);

                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx, this.open, this.high, this.low, this.close);

                equalPeriodTotal +=
                    this.GetCandleRange(Equal, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Equal, equalTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                shadowVeryShortTrailingIdx++;
                bodyLongTrailingIdx++;
                equalTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlSeparatingLinesLookback()
        {
            return Math.Max(
                Math.Max(this.GetCandleAvgPeriod(ShadowVeryShort), this.GetCandleAvgPeriod(BodyLong)),
                this.GetCandleAvgPeriod(Equal)
            ) + 1;
        }
    }
}
