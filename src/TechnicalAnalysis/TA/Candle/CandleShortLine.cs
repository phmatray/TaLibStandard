using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleShortLine : CandleIndicator
    {
        public CandleShortLine(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double bodyPeriodTotal = 0.0;
            int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowPeriodTotal = 0.0;
            int shadowTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowShort);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = shadowTrailingIdx;
            while (i < startIdx)
            {
                shadowPeriodTotal += GetCandleRange(ShadowShort, i);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - short real body
             * - short upper and lower shadow
             * The meaning of "short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when white, negative (-1 to -100) when black;
             * it does not mean bullish or bearish
             */
            int outIdx = 0;
            do
            {
                bool isShortLine = GetPatternRecognition(i, bodyPeriodTotal, shadowPeriodTotal);

                outInteger[outIdx++] = isShortLine ? GetCandleColor(i) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyTrailingIdx);

                shadowPeriodTotal +=
                    GetCandleRange(ShadowShort, i) -
                    GetCandleRange(ShadowShort, shadowTrailingIdx);

                i++;
                bodyTrailingIdx++;
                shadowTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        private bool GetPatternRecognition(int i, double bodyPeriodTotal, double shadowPeriodTotal)
        {
            bool isShortLine =
                GetRealBody(i) < GetCandleAverage(BodyShort, bodyPeriodTotal, i) &&
                GetUpperShadow(i) < GetCandleAverage(ShadowShort, shadowPeriodTotal, i) &&
                GetLowerShadow(i) < GetCandleAverage(ShadowShort, shadowPeriodTotal, i);
            
            return isShortLine;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(ShadowShort));
        }
    }
}
