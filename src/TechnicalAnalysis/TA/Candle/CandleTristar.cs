using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleTristar : CandleIndicator
    {
        public CandleTristar(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlTristar(
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
            int lookbackTotal = this.CdlTristarLookback();

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
            int bodyTrailingIdx = startIdx - 2 - this.GetCandleAvgPeriod(BodyDoji);
            
            int i = bodyTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyPeriodTotal += this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - 3 consecutive doji days
             * - the second doji is a star
             * The meaning of "doji" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish
             */
            int outIdx = 0;
            do
            {
                bool isCdlTristar =
                    // 1st: doji
                    this.GetRealBody(i - 2, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2, this.open, this.high, this.low, this.close) &&
                    // 2nd: doji
                    this.GetRealBody(i - 1, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2, this.open, this.high, this.low, this.close) &&
                    // 3rd: doji
                    this.GetRealBody(i, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2, this.open, this.high, this.low, this.close);

                if (isCdlTristar)
                {
                    outInteger[outIdx] = 0;

                    if ( // 2nd gaps up
                        this.GetRealBodyGapUp(i - 1, i - 2, this.open, this.close) &&
                        // 3rd is not higher than 2nd
                        Math.Max(this.open[i], this.close[i]) < Math.Max(this.open[i - 1], this.close[i - 1]))
                    {
                        outInteger[outIdx] = -100;
                    }

                    if ( // 2nd gaps down 
                        this.GetRealBodyGapDown(i - 1, i - 2, this.open, this.close) &&
                        // 3rd is not lower than 2nd
                        Math.Min(this.open[i], this.close[i]) > Math.Min(this.open[i - 1], this.close[i - 1]))
                    {
                        outInteger[outIdx] = +100;
                    }

                    outIdx++;
                }
                else
                {
                    outInteger[outIdx++] = 0;
                }

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    this.GetCandleRange(BodyDoji, i - 2, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyDoji, bodyTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlTristarLookback()
        {
            return this.GetCandleAvgPeriod(BodyDoji) + 2;
        }
    }
}
