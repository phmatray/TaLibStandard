namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlDoji(
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
            const CandleSettingType BodyDoji = CandleSettingType.BodyDoji;

            // Validate parameters
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlDojiLookback();

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
            double bodyDojiPeriodTotal = 0.0;
            int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);

            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - open quite equal to close
             * How much can be the maximum distance between open and close is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: doji shows uncertainty and it is
             * neither bullish nor bearish when considered alone
             */
            int outIdx = 0;
            do
            {
                bool isRealBodyLowerThanCandleAverage =
                    GetRealBody(i, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, inOpen, inHigh, inLow, inClose);

                outInteger[outIdx++] = isRealBodyLowerThanCandleAverage ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose)
                    - GetCandleRange(BodyDoji, bodyDojiTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyDojiTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;

            return RetCode.Success;
        }

        public static int CdlDojiLookback()
        {
            return GetCandleAvgPeriod(CandleSettingType.BodyDoji);
        }
    }
}
