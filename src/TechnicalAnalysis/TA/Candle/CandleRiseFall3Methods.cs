using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleRiseFall3Methods : CandleIndicator
    {
        public CandleRiseFall3Methods(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlRiseFall3Methods(
            int startIdx,
            int endIdx,
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

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.CdlRiseFall3MethodsLookback();

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
                bodyPeriodTotal[0] += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) candlestick
             * - then: group of falling (rising) small real body candlesticks (commonly black (white)) that hold within 
             *   the prior long candle's range: ideally they should be three but two or more than three are ok too
             * - final candle: long white (black) candle that opens above (below) the previous small candle's close 
             *   and closes above (below) the first long candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings; here only patterns with 3 small candles
             * are considered;
             * outInteger is positive (1 to 100) or negative (-1 to -100)
             */
            int outIdx = 0;
            do
            {
                bool isRiseFall3Methods =
                    // 1st long, then 3 small, 5th long
                    this.GetRealBody(i - 4, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyPeriodTotal[4], i - 4, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i - 3, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal[3], i - 3, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i - 2, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i - 1, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    this.GetRealBody(i, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // white, 3 black, white  ||  black, 3 white, black
                    this.GetCandleColor(i - 4, this.open, this.close) == -this.GetCandleColor(i - 3, this.open, this.close) &&
                    this.GetCandleColor(i - 3, this.open, this.close) == this.GetCandleColor(i - 2, this.open, this.close) &&
                    this.GetCandleColor(i - 2, this.open, this.close) == this.GetCandleColor(i - 1, this.open, this.close) &&
                    this.GetCandleColor(i - 1, this.open, this.close) == -this.GetCandleColor(i, this.open, this.close) &&
                    // 2nd to 4th hold within 1st: a part of the real body must be within 1st range
                    Math.Min(this.open[i - 3], this.close[i - 3]) < this.high[i - 4] &&
                    Math.Max(this.open[i - 3], this.close[i - 3]) > this.low[i - 4] &&
                    Math.Min(this.open[i - 2], this.close[i - 2]) < this.high[i - 4] &&
                    Math.Max(this.open[i - 2], this.close[i - 2]) > this.low[i - 4] &&
                    Math.Min(this.open[i - 1], this.close[i - 1]) < this.high[i - 4] &&
                    Math.Max(this.open[i - 1], this.close[i - 1]) > this.low[i - 4] &&
                    // 2nd to 4th are falling (rising)
                    this.close[i - 2] * this.GetCandleColor(i - 4, this.open, this.close) <
                    this.close[i - 3] * this.GetCandleColor(i - 4, this.open, this.close) &&
                    this.close[i - 1] * this.GetCandleColor(i - 4, this.open, this.close) <
                    this.close[i - 2] * this.GetCandleColor(i - 4, this.open, this.close) &&
                    // 5th opens above (below) the prior close
                    this.open[i] * this.GetCandleColor(i - 4, this.open, this.close) >
                    this.close[i - 1] * this.GetCandleColor(i - 4, this.open, this.close) &&
                    // 5th closes above (below) the 1st close
                    this.close[i] * this.GetCandleColor(i - 4, this.open, this.close) >
                    this.close[i - 4] * this.GetCandleColor(i - 4, this.open, this.close);

                outInteger[outIdx++] = isRiseFall3Methods ? 100 * this.GetCandleColor(i - 4, this.open, this.close) : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal[4] +=
                    this.GetCandleRange(BodyLong, i - 4, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 4, this.open, this.high, this.low, this.close);

                for (int totIdx = 3; totIdx >= 1; --totIdx)
                {
                    bodyPeriodTotal[totIdx] +=
                        this.GetCandleRange(BodyShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                bodyPeriodTotal[0] +=
                    this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlRiseFall3MethodsLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(BodyShort), this.GetCandleAvgPeriod(BodyLong)) + 4;
        }
    }
}
