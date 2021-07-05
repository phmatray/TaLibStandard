using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleKickingByLength : CandleIndicator
    {
        public CandleKickingByLength(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlKickingByLength(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] shadowVeryShortPeriodTotal = new double[2];
            double[] bodyLongPeriodTotal = new double[2];
            
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
            int lookbackTotal = this.CdlKickingByLengthLookback();

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
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[0] += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close);
                bodyLongPeriodTotal[0] += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: marubozu
             * - second candle: opposite color marubozu
             * - gap between the two candles: upside gap if black then white, downside gap if white then black
             * The meaning of "long body" and "very short shadow" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; the longer of the two
             * marubozu determines the bullishness or bearishness of this pattern
             */
            int outIdx = 0;
            do
            {
                bool isKickingByLength =
                    // opposite candles
                    this.GetCandleColor(i - 1, this.open, this.close) == -this.GetCandleColor(i, this.open, this.close) &&
                    // 1st marubozu
                    this.GetRealBody(i - 1, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i - 1, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    this.GetLowerShadow(i - 1, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd marubozu
                    this.GetRealBody(i, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    this.GetLowerShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // gap
                    (
                        (this.GetCandleColor(i - 1, this.open, this.close) == -1 && this.GetCandleGapUp(i, i - 1, this.high, this.low)) ||
                        (this.GetCandleColor(i - 1, this.open, this.close) == 1 && this.GetCandleGapDown(i, i - 1, this.high, this.low))
                    );

                outInteger[outIdx++] = isKickingByLength
                    ? this.GetCandleColor(
                        (this.GetRealBody(i, this.open, this.close) > this.GetRealBody(i - 1, this.open, this.close) ? i : i - 1), this.open, this.close) * 100
                    : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        this.GetCandleRange(BodyLong, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, this.open, this.high, this.low, this.close);

                    shadowVeryShortPeriodTotal[totIdx] +=
                        this.GetCandleRange(ShadowVeryShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                i++;
                shadowVeryShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlKickingByLengthLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(ShadowVeryShort), this.GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
