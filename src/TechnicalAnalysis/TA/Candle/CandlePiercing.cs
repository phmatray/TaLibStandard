using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandlePiercing : CandleIndicator
    {
        public CandlePiercing(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlPiercing(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] bodyLongPeriodTotal = new double[2];
            
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

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlPiercingLookback();

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
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
                bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: long white candle with open below previous day low and close at least at 50% of previous day 
             * real body
             * The meaning of "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): piercing pattern is always bullish
             * the user should consider that a piercing pattern is significant when it appears in a downtrend, while 
             * this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isPiercing =
                    // 1st: black
                    GetCandleColor(i - 1) == -1 &&
                    // long
                    GetRealBody(i - 1) > GetCandleAverage(BodyLong, bodyLongPeriodTotal[1], i - 1) &&
                    // 2nd: white
                    GetCandleColor(i) == 1 &&
                    // long
                    GetRealBody(i) > GetCandleAverage(BodyLong, bodyLongPeriodTotal[0], i) &&
                    // open below prior low
                    open[i] < low[i - 1] &&
                    // close within prior body
                    close[i] < open[i - 1] &&
                    // above midpoint
                    close[i] > close[i - 1] + GetRealBody(i - 1) * 0.5;

                outInteger[outIdx++] = isPiercing ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    bodyLongPeriodTotal[totIdx] +=
                        GetCandleRange(BodyLong, i - totIdx) -
                        GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);
                }

                i++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlPiercingLookback()
        {
            return GetCandleAvgPeriod(BodyLong) + 1;
        }
    }
}
