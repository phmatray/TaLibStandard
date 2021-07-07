using TechnicalAnalysis.Abstractions;
using static System.Math;

namespace TechnicalAnalysis.Candle
{
    public class CandleXSideGap3Methods : CandleIndicator
    {
        public CandleXSideGap3Methods(in double[] open, in double[] high, in double[] low, in double[] close)
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
            if (_open == null || _high == null || _low == null || _close == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = GetLookback();

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
            int i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: white (black) candle
             * - second candle: white (black) candle
             * - upside (downside) gap between the first and the second real bodies
             * - third candle: black (white) candle that opens within the second real body and closes within the first real body
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that up/downside gap 3 methods is significant when it appears in a trend, while this 
             * function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isXSideGap3Methods = GetPatternRecognition(i);

                outInteger[outIdx++] = isXSideGap3Methods ? GetCandleColor(i - 2) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isXSideGap3Methods =
                // 1st and 2nd of same color
                GetCandleColor(i - 2) == GetCandleColor(i - 1) &&
                // 3rd opposite color
                GetCandleColor(i - 1) == -GetCandleColor(i) &&
                // 3rd opens within 2nd rb
                _open[i] < Max(_close[i - 1], _open[i - 1]) &&
                _open[i] > Min(_close[i - 1], _open[i - 1]) &&
                // 3rd closes within 1st rb
                _close[i] < Max(_close[i - 2], _open[i - 2]) &&
                _close[i] > Min(_close[i - 2], _open[i - 2]) &&
                (
                    (
                        // when 1st is white
                        GetCandleColor(i - 2) == 1 &&
                        // upside gap
                        GetRealBodyGapUp(i - 1, i - 2)
                    ) ||
                    (
                        // when 1st is black
                        GetCandleColor(i - 2) == -1 &&
                        // downside gap
                        GetRealBodyGapDown(i - 1, i - 2)
                    )
                );
            
            return isXSideGap3Methods;
        }

        public override int GetLookback()
        {
            return 2;
        }
    }
}
