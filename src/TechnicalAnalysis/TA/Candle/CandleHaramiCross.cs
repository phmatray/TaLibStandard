using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleHaramiCross : CandleIndicator
    {
        public CandleHaramiCross(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlHaramiCross(
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
            int lookbackTotal = this.CdlHaramiCrossLookback();

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
            double bodyDojiPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 1 - this.GetCandleAvgPeriod(BodyLong);
            int bodyDojiTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyDoji);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) real body
             * - second candle: doji totally engulfed by the first
             * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; 
             * the user should consider that a harami cross is significant when it appears in a downtrend if bullish or 
             * in an uptrend when bearish, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool isHaramiCross =
                    // 1st: long
                    this.GetRealBody(i - 1, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd: doji
                    this.GetRealBody(i, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // engulfed by 1st
                    Math.Max(this.close[i], this.open[i]) < Math.Max(this.close[i - 1], this.open[i - 1]) &&
                    Math.Min(this.close[i], this.open[i]) > Math.Min(this.close[i - 1], this.open[i - 1]);

                outInteger[outIdx++] = isHaramiCross ? -this.GetCandleColor(i - 1, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx, this.open, this.high, this.low, this.close);

                bodyDojiPeriodTotal +=
                    this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyDoji, bodyDojiTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyLongTrailingIdx++;
                bodyDojiTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlHaramiCrossLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(BodyDoji), this.GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
