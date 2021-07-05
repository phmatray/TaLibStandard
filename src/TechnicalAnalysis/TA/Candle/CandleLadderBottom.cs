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

        public RetCode TryCompute(
            int startIdx,
            int endIdx,
            out int outBegIdx,
            out int outNBElement,
            out int[] outInteger)
        {
            // Initialize output variables 
            outBegIdx = default;
            outNBElement = default;
            outInteger = new int[endIdx - startIdx + 1];
            
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
            if (open == null || high == null || low == null || close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlLadderBottomLookback();

            // Move up the start index if there is not enough initial data.
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            // Make sure there is still something to evaluate.
            if (startIdx > endIdx)
            {
                return RetCode.Success;
            }

            // Do the calculation using tight loops.
            // Add-up the initial period, except for the last value.
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1);
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
                    GetCandleColor(i - 4) == -1 &&
                    GetCandleColor(i - 3) == -1 &&
                    GetCandleColor(i - 2) == -1 &&
                    // with consecutively lower opens
                    open[i - 4] > open[i - 3] &&
                    open[i - 3] > open[i - 2] &&
                    // and closes
                    close[i - 4] > close[i - 3] &&
                    close[i - 3] > close[i - 2] &&
                    // 4th: black with an upper shadow
                    GetCandleColor(i - 1) == -1 &&
                    GetUpperShadow(i - 1) > GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal, i - 1) &&
                    // 5th: white
                    GetCandleColor(i) == 1 &&
                    // that opens above prior candle's body
                    open[i] > open[i - 1] &&
                    // and closes above prior candle's high
                    close[i] > high[i - 1];

                outInteger[outIdx++] = isLadderBottom ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                shadowVeryShortPeriodTotal +=
                    GetCandleRange(ShadowVeryShort, i - 1) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1);

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
            return GetCandleAvgPeriod(ShadowVeryShort) + 4;
        }
    }
}
