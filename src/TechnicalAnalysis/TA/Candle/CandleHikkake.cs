using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis.Candle
{
    public class CandleHikkake : CandleIndicator
    {
        public CandleHikkake(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlHikkake(
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
            int lookbackTotal = this.CdlHikkakeLookback();

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
            int patternIdx = 0;
            int patternResult = 0;
            
            int i = startIdx - 3;
            while (i < startIdx)
            {
                bool patternRecognition =
                    // 1st + 2nd: lower high and higher low
                    this.high[i - 1] < this.high[i - 2] && this.low[i - 1] > this.low[i - 2] &&
                    (
                        // (bull) 3rd: lower high and lower low
                        (this.high[i] < this.high[i - 1] && this.low[i] < this.low[i - 1]) ||
                        // (bear) 3rd: higher high and higher low
                        (this.high[i] > this.high[i - 1] && this.low[i] > this.low[i - 1])
                    );

                if (patternRecognition)
                {
                    patternResult = 100 * (this.high[i] < this.high[i - 1] ? 1 : -1);
                    patternIdx = i;
                }
                else
                {
                    // search for confirmation if hikkake was no more than 3 bars ago
                    bool confirmation =
                        i <= patternIdx + 3 &&
                        (
                            // close higher than the high of 2nd
                            (patternResult > 0 && this.close[i] > this.high[patternIdx - 1]) ||
                            // close lower than the low of 2nd
                            (patternResult < 0 && this.close[i] < this.low[patternIdx - 1])
                        );

                    if (confirmation)
                    {
                        patternIdx = 0;
                    }
                }

                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first and second candle: inside bar (2nd has lower high and higher low than 1st)
             * - third candle: lower high and lower low than 2nd (higher high and higher low than 2nd)
             * outInteger[hikkakebar] is positive (1 to 100) or negative (-1 to -100) meaning bullish or bearish hikkake
             * Confirmation could come in the next 3 days with:
             * - a day that closes higher than the high (lower than the low) of the 2nd candle
             * outInteger[confirmationbar] is equal to 100 + the bullish hikkake result or -100 - the bearish hikkake result
             * Note: if confirmation and a new hikkake come at the same bar, only the new hikkake is reported (the new hikkake
             * overwrites the confirmation of the old hikkake)
             */
            int outIdx = 0;
            do
            {
                bool patternRecognition =
                    // 1st + 2nd: lower high and higher low
                    this.high[i - 1] < this.high[i - 2] && this.low[i - 1] > this.low[i - 2] &&
                    (
                        // (bull) 3rd: lower high and lower low
                        (this.high[i] < this.high[i - 1] && this.low[i] < this.low[i - 1]) ||
                        // (bear) 3rd: higher high and higher low
                        (this.high[i] > this.high[i - 1] && this.low[i] > this.low[i - 1])
                    );

                if (patternRecognition)
                {
                    patternResult = 100 * (this.high[i] < this.high[i - 1] ? 1 : -1);
                    patternIdx = i;
                    outInteger[outIdx++] = patternResult;
                }
                else
                {
                    /* search for confirmation if hikkake was no more than 3 bars ago */
                    bool confirmation =
                        i <= patternIdx + 3 &&
                        (
                            // close higher than the high of 2nd
                            (patternResult > 0 && this.close[i] > this.high[patternIdx - 1]) ||
                            // close lower than the low of 2nd
                            (patternResult < 0 && this.close[i] < this.low[patternIdx - 1])
                        );

                    if (confirmation)
                    {
                        outInteger[outIdx++] = patternResult + 100 * (patternResult > 0 ? 1 : -1);
                        patternIdx = 0;
                    }
                    else
                    {
                        outInteger[outIdx++] = 0;
                    }
                }

                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlHikkakeLookback()
        {
            return 5;
        }
    }
}
