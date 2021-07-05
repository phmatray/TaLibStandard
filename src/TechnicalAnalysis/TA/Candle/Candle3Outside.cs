using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis.Candle
{
    public class Candle3Outside : CandleIndicator
    {
        public Candle3Outside(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode Cdl3Outside(
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
            int lookbackTotal = this.Cdl3OutsideLookback();

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
                        this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                        this.GetCandleColor(i - 2, this.open, this.close) == -1 &&
                        this.close[i - 1] > this.open[i - 2] &&
                        this.open[i - 1] < this.close[i - 2] &&
                        // third candle higher
                        this.close[i] > this.close[i - 1]
                    )
                    ||
                    (
                        // black engulfs white
                        this.GetCandleColor(i - 1, this.open, this.close) == -1 &&
                        this.GetCandleColor(i - 2, this.open, this.close) == 1 &&
                        this.open[i - 1] > this.close[i - 2] &&
                        this.close[i - 1] < this.open[i - 2] &&
                        // third candle lower
                        this.close[i] < this.close[i - 1]
                    );

                outInteger[outIdx++] = is3Outside ? this.GetCandleColor(i - 1, this.open, this.close) * 100 : 0;

                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int Cdl3OutsideLookback()
        {
            return 3;
        }
    }
}
