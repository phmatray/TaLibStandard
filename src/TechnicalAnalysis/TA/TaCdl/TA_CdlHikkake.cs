using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHikkake(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            
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
            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
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
                    inHigh[i - 1] < inHigh[i - 2] && inLow[i - 1] > inLow[i - 2] &&
                    (
                        // (bull) 3rd: lower high and lower low
                        inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1] ||
                        // (bear) 3rd: higher high and higher low
                        inHigh[i] > inHigh[i - 1] && inLow[i] > inLow[i - 1]
                    );

                if (patternRecognition)
                {
                    patternResult = 100 * (inHigh[i] < inHigh[i - 1] ? 1 : -1);
                    patternIdx = i;
                }
                else
                {
                    // search for confirmation if hikkake was no more than 3 bars ago
                    bool confirmation =
                        i <= patternIdx + 3 &&
                        (
                            // close higher than the high of 2nd
                            patternResult > 0 && inClose[i] > inHigh[patternIdx - 1] ||
                            // close lower than the low of 2nd
                            patternResult < 0 && inClose[i] < inLow[patternIdx - 1]
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
                if (inHigh[i - 1] < inHigh[i - 2] && inLow[i - 1] > inLow[i - 2]
                                                  && (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1]
                                                      || inHigh[i] > inHigh[i - 1] && inLow[i] > inLow[i - 1]))
                {
                    patternResult = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
                    patternIdx = i;
                    outInteger[outIdx] = patternResult;
                    outIdx++;
                }
                else if (i <= patternIdx + 3 && (patternResult > 0 && inClose[i] > inHigh[patternIdx - 1]
                                                 || patternResult < 0 && inClose[i] < inLow[patternIdx - 1]))
                {
                    int num;
                    if (patternResult > 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        num = -1;
                    }

                    outInteger[outIdx] = patternResult + num * 100;
                    outIdx++;
                    patternIdx = 0;
                }
                else
                {
                    outInteger[outIdx] = 0;
                    outIdx++;
                }

                i++;
            }
            while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHikkakeLookback()
        {
            return 5;
        }
    }
}
