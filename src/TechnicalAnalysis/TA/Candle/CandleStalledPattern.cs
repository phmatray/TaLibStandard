using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleStalledPattern : CandleIndicator
    {
        public CandleStalledPattern(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlStalledPattern(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
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
            if (this.open == null || this.high == null || this.low == null || this.close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.CdlStalledPatternLookback();

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
            bodyLongPeriodTotal[2] = 0.0;
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyShort);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[2] += this.GetCandleRange(BodyLong, i - 2, this.open, this.high, this.low, this.close);
                bodyLongPeriodTotal[1] += this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += this.GetCandleRange(Near, i - 2, this.open, this.high, this.low, this.close);
                nearPeriodTotal[1] += this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close);
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
                    this.GetCandleColor(i - 2, this.open, this.close) == 1 &&
                    // 2nd white
                    this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                    // 3rd white
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // consecutive higher closes
                    this.close[i] > this.close[i - 1] &&
                    this.close[i - 1] > this.close[i - 2] &&
                    // 1st: long real body
                    this.GetRealBody(i - 2, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 2nd: long real body
                    this.GetRealBody(i - 1, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // very short upper shadow 
                    this.GetUpperShadow(i - 1, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // opens within/near 1st real body
                    this.open[i - 1] > this.open[i - 2] &&
                    this.open[i - 1] <= this.close[i - 2] +
                    this.GetCandleAverage(Near, nearPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 3rd: small real body
                    this.GetRealBody(i, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // rides on the shoulder of 2nd real body
                    this.open[i] >= this.close[i - 1] - this.GetRealBody(i, this.open, this.close) -
                    this.GetCandleAverage(Near, nearPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isStalledPattern ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        this.GetCandleRange(BodyLong, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx, this.open, this.high, this.low, this.close);

                    nearPeriodTotal[totIdx] +=
                        this.GetCandleRange(Near, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(Near, nearTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                bodyShortPeriodTotal +=
                    this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyShort, bodyShortTrailingIdx, this.open, this.high, this.low, this.close);

                shadowVeryShortPeriodTotal +=
                    this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1, this.open, this.high, this.low, this.close);

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
            return Math.Max(
                Math.Max(this.GetCandleAvgPeriod(BodyLong), this.GetCandleAvgPeriod(BodyShort)),
                Math.Max(this.GetCandleAvgPeriod(ShadowVeryShort), this.GetCandleAvgPeriod(Near))
            ) + 2;
        }
    }
}
