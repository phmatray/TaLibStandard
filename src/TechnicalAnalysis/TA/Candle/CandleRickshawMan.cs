using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleRickshawMan : CandleIndicator
    {
        public CandleRickshawMan(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlRickshawMan(
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
            int lookbackTotal = this.CdlRickshawManLookback();

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
            double bodyDojiPeriodTotal = 0.0;
            int bodyDojiTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyDoji);
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowLong);
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += this.GetCandleRange(ShadowLong, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += this.GetCandleRange(Near, i, this.open, this.high, this.low, this.close);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - two long shadows
             * - body near the midpoint of the high-low range
             * The meaning of "doji" and "near" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: rickshaw man shows uncertainty
             */
            int outIdx = 0;
            do
            {
                bool isRickshawMan =
                    // doji
                    this.GetRealBody(i, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // long shadow
                    this.GetLowerShadow(i, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    // long shadow
                    this.GetUpperShadow(i, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    (
                        // body near midpoint
                        Math.Min(this.open[i], this.close[i]) <= this.low[i] + this.GetHighLowRange(i, this.high, this.low) / 2 +
                        this.GetCandleAverage(Near, nearPeriodTotal, i, this.open, this.high, this.low, this.close)
                        &&
                        Math.Max(this.open[i], this.close[i]) >= this.low[i] + this.GetHighLowRange(i, this.high, this.low) / 2 -
                        this.GetCandleAverage(Near, nearPeriodTotal, i, this.open, this.high, this.low, this.close)
                    );

                outInteger[outIdx++] = isRickshawMan ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyDojiPeriodTotal +=
                    this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyDoji, bodyDojiTrailingIdx, this.open, this.high, this.low, this.close);

                shadowLongPeriodTotal +=
                    this.GetCandleRange(ShadowLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowLong, shadowLongTrailingIdx, this.open, this.high, this.low, this.close);

                nearPeriodTotal +=
                    this.GetCandleRange(Near, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(Near, nearTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyDojiTrailingIdx++;
                shadowLongTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlRickshawManLookback()
        {
            return Math.Max(
                Math.Max(this.GetCandleAvgPeriod(BodyDoji), this.GetCandleAvgPeriod(ShadowLong)),
                this.GetCandleAvgPeriod(Near)
            );
        }
    }
}
