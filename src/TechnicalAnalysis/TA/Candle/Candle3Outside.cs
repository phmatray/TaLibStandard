using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis.Candle
{
    public class Candle3Outside : CandleIndicator
    {
        public Candle3Outside(in double[] open, in double[] high, in double[] low, in double[] close)
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
             * - first: black (white) real body
             * - second: white (black) real body that engulfs the prior real body
             * - third: candle that closes higher (lower) than the second candle
             * outInteger is positive (1 to 100) for the three outside up or negative (-1 to -100) for the three outside down;
             * the user should consider that a three outside up must appear in a downtrend and three outside down must appear
             * in an uptrend, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3Outside =
                    (
                        // white engulfs black
                        GetCandleColor(i - 1) == 1 &&
                        GetCandleColor(i - 2) == -1 &&
                        close[i - 1] > open[i - 2] &&
                        open[i - 1] < close[i - 2] &&
                        // third candle higher
                        close[i] > close[i - 1]
                    )
                    ||
                    (
                        // black engulfs white
                        GetCandleColor(i - 1) == -1 &&
                        GetCandleColor(i - 2) == 1 &&
                        open[i - 1] > close[i - 2] &&
                        close[i - 1] < open[i - 2] &&
                        // third candle lower
                        close[i] < close[i - 1]
                    );

                outInteger[outIdx++] = is3Outside ? GetCandleColor(i - 1) * 100 : 0;

                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override int GetLookback()
        {
            return 3;
        }
    }
}
