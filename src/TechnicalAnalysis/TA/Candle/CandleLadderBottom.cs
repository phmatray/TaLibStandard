using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleLadderBottom : CandleIndicator
    {
        public CandleLadderBottom(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlLadderBottom(
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
            int lookbackTotal = this.CdlLadderBottomLookback();

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
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three black candlesticks with consecutively lower opens and closes
             * - fourth candle: black candle with an upper shadow (it's supposed to be not very short)
             * - fifth candle: white candle that opens above prior candle's body and closes above prior candle's high
             * The meaning of "very short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): ladder bottom is always bullish; 
             * the user should consider that ladder bottom is significant when it appears in a downtrend, 
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isLadderBottom =
                    // 3 black candlesticks
                    this.GetCandleColor(i - 4, this.open, this.close) == -1 &&
                    this.GetCandleColor(i - 3, this.open, this.close) == -1 &&
                    this.GetCandleColor(i - 2, this.open, this.close) == -1 &&
                    // with consecutively lower opens
                    this.open[i - 4] > this.open[i - 3] &&
                    this.open[i - 3] > this.open[i - 2] &&
                    // and closes
                    this.close[i - 4] > this.close[i - 3] &&
                    this.close[i - 3] > this.close[i - 2] &&
                    // 4th: black with an upper shadow
                    this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                    this.GetUpperShadow(i - 1, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i - 1, this.open, this.high, this.low, this.close) &&
                    // 5th: white
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // that opens above prior candle's body
                    this.open[i] > this.open[i - 1] &&
                    // and closes above prior candle's high
                    this.close[i] > this.high[i - 1];

                outInteger[outIdx++] = isLadderBottom ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                shadowVeryShortPeriodTotal +=
                    this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1, this.open, this.high, this.low, this.close);

                i++;
                shadowVeryShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlLadderBottomLookback()
        {
            return this.GetCandleAvgPeriod(ShadowVeryShort) + 4;
        }
    }
}
