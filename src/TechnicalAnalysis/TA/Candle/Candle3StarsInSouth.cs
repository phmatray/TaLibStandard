using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3StarsInSouth : CandleIndicator
    {
        public Candle3StarsInSouth(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode Cdl3StarsInSouth(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] shadowVeryShortPeriodTotal = new double[2];

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
            int lookbackTotal = this.Cdl3StarsInSouthLookback();

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
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowLong);
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i - 2, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += this.GetCandleRange(ShadowLong, i - 2, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[0] += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle with long lower shadow
             * - second candle: smaller black candle that opens higher than prior close but within prior candle's range 
             *   and trades lower than prior close but not lower than prior low and closes off of its low (it has a shadow)
             * - third candle: small black marubozu (or candle with very short shadows) engulfed by prior candle's range
             * The meanings of "long body", "short body", "very short shadow" are specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): 3 stars in the south is always bullish;
             * the user should consider that 3 stars in the south is significant when it appears in downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3StarsInSouth =
                    // 1st black
                    this.GetCandleColor(i - 2, this.open, this.close) == -1 &&
                    // 2nd black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // 3rd black
                    this.GetCandleColor(i, this.open, this.close) == -1 &&
                    // 1st: long
                    this.GetRealBody(i - 2, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, this.open, this.high, this.low, this.close) &&
                    // with long lower shadow
                    this.GetLowerShadow(i - 2, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i - 2, this.open, this.high, this.low, this.close) &&
                    // 2nd: smaller candle
                    this.GetRealBody(i - 1, this.open, this.close) < this.GetRealBody(i - 2, this.open, this.close) &&
                    // that opens higher but within 1st range
                    this.open[i - 1] > this.close[i - 2] &&
                    this.open[i - 1] <= this.high[i - 2] &&
                    // and trades lower than 1st close
                    this.low[i - 1] < this.close[i - 2] &&
                    // but not lower than 1st low
                    this.low[i - 1] >= this.low[i - 2] &&
                    // and has a lower shadow
                    this.GetLowerShadow(i - 1, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 3rd: small marubozu
                    this.GetRealBody(i, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    this.GetLowerShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // engulfed by prior candle's range
                    this.low[i] > this.low[i - 1] && this.high[i] < this.high[i - 1];

                outInteger[outIdx++] = is3StarsInSouth ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 2, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 2, this.open, this.high, this.low, this.close);

                shadowLongPeriodTotal +=
                    this.GetCandleRange(ShadowLong, i - 2, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowLong, shadowLongTrailingIdx - 2, this.open, this.high, this.low, this.close);

                int totIdx;
                for (totIdx = 1; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        this.GetCandleRange(ShadowVeryShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                bodyShortPeriodTotal +=
                    this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyShort, bodyShortTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyLongTrailingIdx++;
                shadowLongTrailingIdx++;
                shadowVeryShortTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int Cdl3StarsInSouthLookback()
        {
            return Math.Max(
                Math.Max(this.GetCandleAvgPeriod(ShadowVeryShort), this.GetCandleAvgPeriod(ShadowLong)),
                Math.Max(this.GetCandleAvgPeriod(BodyLong), this.GetCandleAvgPeriod(BodyShort))
            ) + 2;
        }
    }
}
