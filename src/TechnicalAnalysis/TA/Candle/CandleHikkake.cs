using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis.Candle
{
    public class CandleHikkake : CandleIndicator
    {
        public CandleHikkake(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int lookbackTotal = CdlHikkakeLookback();

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
            int patternIdx = 0;
            int patternResult = 0;
            
            int i = startIdx - 3;
            while (i < startIdx)
            {
                bool patternRecognition =
                    // 1st + 2nd: lower high and higher low
                    high[i - 1] < high[i - 2] && low[i - 1] > low[i - 2] &&
                    (
                        // (bull) 3rd: lower high and lower low
                        (high[i] < high[i - 1] && low[i] < low[i - 1]) ||
                        // (bear) 3rd: higher high and higher low
                        (high[i] > high[i - 1] && low[i] > low[i - 1])
                    );

                if (patternRecognition)
                {
                    patternResult = 100 * (high[i] < high[i - 1] ? 1 : -1);
                    patternIdx = i;
                }
                else
                {
                    // search for confirmation if hikkake was no more than 3 bars ago
                    bool confirmation =
                        i <= patternIdx + 3 &&
                        (
                            // close higher than the high of 2nd
                            (patternResult > 0 && close[i] > high[patternIdx - 1]) ||
                            // close lower than the low of 2nd
                            (patternResult < 0 && close[i] < low[patternIdx - 1])
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
                    high[i - 1] < high[i - 2] && low[i - 1] > low[i - 2] &&
                    (
                        // (bull) 3rd: lower high and lower low
                        (high[i] < high[i - 1] && low[i] < low[i - 1]) ||
                        // (bear) 3rd: higher high and higher low
                        (high[i] > high[i - 1] && low[i] > low[i - 1])
                    );

                if (patternRecognition)
                {
                    patternResult = 100 * (high[i] < high[i - 1] ? 1 : -1);
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
                            (patternResult > 0 && close[i] > high[patternIdx - 1]) ||
                            // close lower than the low of 2nd
                            (patternResult < 0 && close[i] < low[patternIdx - 1])
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
