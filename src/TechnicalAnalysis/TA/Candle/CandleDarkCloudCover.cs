using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleDarkCloudCover : CandleIndicator
    {
        public CandleDarkCloudCover(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            in double optInPenetration,
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

            if (optInPenetration < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.CdlDarkCloudCoverLookback();

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
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white candle
             * - second candle: black candle that opens above previous day high and closes within previous day real body; 
             * Greg Morris wants the close to be below the midpoint of the previous real body
             * The meaning of "long" is specified with TA_SetCandleSettings, the penetration of the first real body is specified
             * with optInPenetration
             * outInteger is negative (-1 to -100): dark cloud cover is always bearish
             * the user should consider that a dark cloud cover is significant when it appears in an uptrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isDarkCloudCover =
                    // 1st: white
                    this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                    // long
                    this.GetRealBody(i - 1, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd: black
                    this.GetCandleColor(i, this.open, this.close) == -1 &&
                    // open above prior high
                    this.open[i] > this.high[i - 1] &&
                    // close within prior body
                    this.close[i] > this.open[i - 1] &&
                    this.close[i] < this.close[i - 1] - this.GetRealBody(i - 1, this.open, this.close) * optInPenetration;

                outInteger[outIdx++] = isDarkCloudCover ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlDarkCloudCoverLookback()
        {
            return this.GetCandleAvgPeriod(BodyLong) + 1;
        }
    }
}
