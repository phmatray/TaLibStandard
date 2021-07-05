using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleMatHold : CandleIndicator
    {
        public CandleMatHold(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlMatHold(
            int startIdx,
            int endIdx,
            in double optInPenetration,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] bodyPeriodTotal = new double[5];

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

            if (optInPenetration < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.CdlMatHoldLookback();

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
            bodyPeriodTotal[4] = 0.0;
            bodyPeriodTotal[3] = 0.0;
            bodyPeriodTotal[2] = 0.0;
            bodyPeriodTotal[1] = 0.0;
            bodyPeriodTotal[0] = 0.0;
            int bodyShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyShort);
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            
            int i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[3] += this.GetCandleRange(BodyShort, i - 3, this.open, this.high, this.low, this.close);
                bodyPeriodTotal[2] += this.GetCandleRange(BodyShort, i - 2, this.open, this.high, this.low, this.close);
                bodyPeriodTotal[1] += this.GetCandleRange(BodyShort, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[4] += this.GetCandleRange(BodyLong, i - 4, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white candle
             * - upside gap between the first and the second bodies
             * - second candle: small black candle
             * - third and fourth candles: falling small real body candlesticks (commonly black) that hold within the long 
             *   white candle's body and are higher than the reaction days of the rising three methods
             * - fifth candle: white candle that opens above the previous small candle's close and closes higher than the 
             *   high of the highest reaction day
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings; 
             * "hold within" means "a part of the real body must be within";
             * optInPenetration is the maximum percentage of the first white body the reaction days can penetrate (it is 
             * to specify how much the reaction days should be "higher than the reaction days of the rising three methods")
             * outInteger is positive (1 to 100): mat hold is always bullish
             */
            int outIdx = 0;
            do
            {
                bool isMatHold =
                    // 1st long, then 3 small
                    this.GetRealBody(i - 4, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyPeriodTotal[4], i - 4, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i - 3, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal[3], i - 3, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i - 2, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i - 1, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // white, black, 2 black or white, white
                    this.GetCandleColor(i - 4, this.open, this.close) == 1 &&
                    this.GetCandleColor(i - 3, this.open, this.close) == -1 &&
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // upside gap 1st to 2nd
                    this.GetRealBodyGapUp(i - 3, i - 4, this.open, this.close) &&
                    // 3rd to 4th hold within 1st: a part of the real body must be within 1st real body
                    Math.Min(this.open[i - 2], this.close[i - 2]) < this.close[i - 4] &&
                    Math.Min(this.open[i - 1], this.close[i - 1]) < this.close[i - 4] &&
                    // reaction days penetrate first body less than optInPenetration percent
                    Math.Min(this.open[i - 2], this.close[i - 2]) >
                    this.close[i - 4] - this.GetRealBody(i - 4, this.open, this.close) * optInPenetration &&
                    Math.Min(this.open[i - 1], this.close[i - 1]) >
                    this.close[i - 4] - this.GetRealBody(i - 4, this.open, this.close) * optInPenetration &&
                    // 2nd to 4th are falling
                    Math.Max(this.close[i - 2], this.open[i - 2]) < this.open[i - 3] &&
                    Math.Max(this.close[i - 1], this.open[i - 1]) < Math.Max(this.close[i - 2], this.open[i - 2]) &&
                    // 5th opens above the prior close
                    this.open[i] > this.close[i - 1] &&
                    // 5th closes above the highest high of the reaction days
                    this.close[i] > Math.Max(Math.Max(this.high[i - 3], this.high[i - 2]), this.high[i - 1]);

                outInteger[outIdx++] = isMatHold ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal[4] +=
                    this.GetCandleRange(BodyLong, i - 4, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 4, this.open, this.high, this.low, this.close);

                int totIdx;
                for (totIdx = 3; totIdx >= 1; --totIdx)
                {
                    bodyPeriodTotal[totIdx] +=
                        this.GetCandleRange(BodyShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                i++;
                bodyShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlMatHoldLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(BodyShort), this.GetCandleAvgPeriod(BodyLong)) + 4;
        }
    }
}
