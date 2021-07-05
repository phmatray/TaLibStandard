using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleDoji : CandleIndicator
    {
        public CandleDoji(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlDoji(
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
            int lookbackTotal = this.CdlDojiLookback();

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

            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - open quite equal to close
             * How much can be the maximum distance between open and close is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: doji shows uncertainty and it is
             * neither bullish nor bearish when considered alone
             */
            int outIdx = 0;
            do
            {
                bool isDoji =
                    this.GetRealBody(i, this.open, this.close) <=
                    this.GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isDoji ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyDojiPeriodTotal +=
                    this.GetCandleRange(BodyDoji, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyDoji, bodyDojiTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyDojiTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;

            return RetCode.Success;
        }

        public int CdlDojiLookback()
        {
            return this.GetCandleAvgPeriod(BodyDoji);
        }
    }
}
