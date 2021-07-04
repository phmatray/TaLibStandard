using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlRickshawMan(
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
            int lookbackTotal = CdlRickshawManLookback();

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
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += GetCandleRange(ShadowLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += GetCandleRange(Near, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - two long shadows
             * - body near the midpoint of the high-low range
             * The meaning of "doji" and "near" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: rickshaw man shows uncertainty
             */
            int outIdx = 0;
            do
            {
                bool isRickshawMan =
                    // doji
                    GetRealBody(i, inOpen, inClose) <=
                    GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // long shadow
                    GetLowerShadow(i, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    // long shadow
                    GetUpperShadow(i, inOpen, inLow, inClose) >
                    GetCandleAverage(ShadowLong, shadowLongPeriodTotal, i, inOpen, inHigh, inLow, inClose) &&
                    (
                        // body near midpoint
                        Math.Min(inOpen[i], inClose[i]) <= inLow[i] + GetHighLowRange(i, inHigh, inLow) / 2 +
                        GetCandleAverage(Near, nearPeriodTotal, i, inOpen, inHigh, inLow, inClose)
                        &&
                        Math.Max(inOpen[i], inClose[i]) >= inLow[i] + GetHighLowRange(i, inHigh, inLow) / 2 -
                        GetCandleAverage(Near, nearPeriodTotal, i, inOpen, inHigh, inLow, inClose)
                    );

                outInteger[outIdx++] = isRickshawMan ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx, inOpen, inHigh, inLow, inClose);

                shadowLongPeriodTotal +=
                    GetCandleRange(ShadowLong, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx, inOpen, inHigh, inLow, inClose);

                nearPeriodTotal +=
                    GetCandleRange(Near, i, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Near, nearTrailingIdx, inOpen, inHigh, inLow, inClose);

                i++;
                bodyDojiTrailingIdx++;
                shadowLongTrailingIdx++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlRickshawManLookback()
        {
            return Math.Max(
                Math.Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(ShadowLong)),
                GetCandleAvgPeriod(Near)
            );
        }
    }
}
