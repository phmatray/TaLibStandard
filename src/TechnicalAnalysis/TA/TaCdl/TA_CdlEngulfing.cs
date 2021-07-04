namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlEngulfing(
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
            int lookbackTotal = CdlEngulfingLookback();

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
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that an engulfing must appear in a downtrend if bullish or in an uptrend if bearish,
             * while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isEngulfing =
                    (
                        // white engulfs black
                        GetCandleColor(i, inOpen, inClose) == 1 &&
                        GetCandleColor(i - 1, inOpen, inClose) == -1 &&
                        inClose[i] > inOpen[i - 1] && inOpen[i] < inClose[i - 1]
                    )
                    ||
                    (
                        // black engulfs white
                        GetCandleColor(i, inOpen, inClose) == -1 &&
                        GetCandleColor(i - 1, inOpen, inClose) == 1 &&
                        inOpen[i] > inClose[i - 1] && inClose[i] < inOpen[i - 1]
                    );

                outInteger[outIdx++] = isEngulfing ? GetCandleColor(i, inOpen, inClose) * 100 : 0;

                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlEngulfingLookback()
        {
            return 2;
        }
    }
}
