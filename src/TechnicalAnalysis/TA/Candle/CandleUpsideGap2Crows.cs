using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleUpsideGap2Crows : CandleIndicator
    {
        public CandleUpsideGap2Crows(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlUpsideGap2Crows(
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
            int lookbackTotal = this.CdlUpsideGap2CrowsLookback();

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
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - this.GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - 1 - this.GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyShortPeriodTotal += this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: white candle, usually long
             * - second candle: small black real body
             * - gap between the first and the second candle's real bodies
             * - third candle: black candle with a real body that engulfs the preceding candle 
             *   and closes above the white candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): upside gap two crows is always bearish; 
             * the user should consider that an upside gap two crows is significant when it appears in an uptrend, 
             * while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isUpsideGap2Crows =
                    // 1st: white
                    this.GetCandleColor(i - 2, this.open, this.close) == 1 &&
                    // long
                    this.GetRealBody(i - 2, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, this.open, this.high, this.low, this.close) &&
                    // 2nd: black
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    // short
                    this.GetRealBody(i - 1, this.open, this.close) <=
                    this.GetCandleAverage(BodyShort, bodyShortPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // gapping up
                    this.GetRealBodyGapUp(i - 1, i - 2, this.open, this.close) &&
                    // 3rd: black
                    this.GetCandleColor(i, this.open, this.close) == -1 &&
                    // 3rd: engulfing prior rb
                    this.open[i] > this.open[i - 1] && this.close[i] < this.close[i - 1] &&
                    // closing above 1st
                    this.close[i] > this.close[i - 2];

                outInteger[outIdx++] = isUpsideGap2Crows ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 2, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx, this.open, this.high, this.low, this.close);

                bodyShortPeriodTotal +=
                    this.GetCandleRange(BodyShort, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyShort, bodyShortTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlUpsideGap2CrowsLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(BodyShort), this.GetCandleAvgPeriod(BodyLong)) + 2;
        }
    }
}
