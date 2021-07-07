using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleTristar : CandleIndicator
    {
        public CandleTristar(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int bodyTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyDoji);
            
            int i = bodyTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyPeriodTotal += GetCandleRange(BodyDoji, i);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - 3 consecutive doji days
             * - the second doji is a star
             * The meaning of "doji" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish
             */
            int outIdx = 0;
            do
            {
                bool isCdlTristar =
                    // 1st: doji
                    GetRealBody(i - 2) <= GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2) &&
                    // 2nd: doji
                    GetRealBody(i - 1) <= GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2) &&
                    // 3rd: doji
                    GetRealBody(i) <= GetCandleAverage(BodyDoji, bodyPeriodTotal, i - 2);

                if (isCdlTristar)
                {
                    outInteger[outIdx] = 0;

                    if ( // 2nd gaps up
                        GetRealBodyGapUp(i - 1, i - 2) &&
                        // 3rd is not higher than 2nd
                        Max(open[i], close[i]) < Max(open[i - 1], close[i - 1]))
                    {
                        outInteger[outIdx] = -100;
                    }

                    if ( // 2nd gaps down 
                        GetRealBodyGapDown(i - 1, i - 2) &&
                        // 3rd is not lower than 2nd
                        Min(open[i], close[i]) > Min(open[i - 1], close[i - 1]))
                    {
                        outInteger[outIdx] = +100;
                    }

                    outIdx++;
                }
                else
                {
                    outInteger[outIdx++] = 0;
                }

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    GetCandleRange(BodyDoji, i - 2) -
                    GetCandleRange(BodyDoji, bodyTrailingIdx);

                i++;
                bodyTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(BodyDoji) + 2;
        }
    }
}
