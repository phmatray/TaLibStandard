using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3Inside : CandleIndicator
    {
        public Candle3Inside(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode Cdl3Inside(
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
            if (open == null || high == null || low == null || close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = Cdl3InsideLookback();
            
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
            double bodyLongPeriodTotal = 0.0;
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) real body
             * - second candle: short real body totally engulfed by the first
             * - third candle: black (white) candle that closes lower (higher) than the first candle's open
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) for the three inside up or negative (-1 to -100) for the three inside down; 
             * the user should consider that a three inside up is significant when it appears in a downtrend and a three inside
             * down is significant when it appears in an uptrend, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                bool is3Inside =
                    // 1st: long
                    GetRealBody(i - 2) > GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2) &&
                    // 2nd: short
                    GetRealBody(i - 1) <= GetCandleAverage(BodyShort, bodyShortPeriodTotal, i - 1) &&
                    // engulfed by 1st
                    Max(close[i - 1], open[i - 1]) < Max(close[i - 2], open[i - 2]) &&
                    Min(close[i - 1], open[i - 1]) > Min(close[i - 2], open[i - 2]) &&
                    (
                        ( // 3rd: opposite to 1st
                            GetCandleColor(i - 2) == 1 &&
                            GetCandleColor(i) == -1 &&
                            close[i] < open[i - 2]
                        ) ||
                        ( // and closing out
                            GetCandleColor(i - 2) == -1 &&
                            GetCandleColor(i) == 1 &&
                            close[i] > open[i - 2]
                        )
                    );

                outInteger[outIdx++] = is3Inside ? -GetCandleColor(i - 2) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx);

                bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i - 1) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int Cdl3InsideLookback()
        {
            return Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 2;
        }
    }
}
