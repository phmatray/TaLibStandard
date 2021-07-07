using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleRiseFall3Methods : CandleIndicator
    {
        public CandleRiseFall3Methods(in double[] open, in double[] high, in double[] low, in double[] close)
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
            
            // Local variables
            double[] bodyPeriodTotal = new double[5];

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
            int lookbackTotal = CdlRiseFall3MethodsLookback();

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
            bodyPeriodTotal[4] = 0.0;
            bodyPeriodTotal[3] = 0.0;
            bodyPeriodTotal[2] = 0.0;
            bodyPeriodTotal[1] = 0.0;
            bodyPeriodTotal[0] = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[3] += GetCandleRange(BodyShort, i - 3);
                bodyPeriodTotal[2] += GetCandleRange(BodyShort, i - 2);
                bodyPeriodTotal[1] += GetCandleRange(BodyShort, i - 1);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[4] += GetCandleRange(BodyLong, i - 4);
                bodyPeriodTotal[0] += GetCandleRange(BodyLong, i);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) candlestick
             * - then: group of falling (rising) small real body candlesticks (commonly black (white)) that hold within 
             *   the prior long candle's range: ideally they should be three but two or more than three are ok too
             * - final candle: long white (black) candle that opens above (below) the previous small candle's close 
             *   and closes above (below) the first long candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings; here only patterns with 3 small candles
             * are considered;
             * outInteger is positive (1 to 100) or negative (-1 to -100)
             */
            int outIdx = 0;
            do
            {
                bool isRiseFall3Methods =
                    // 1st long, then 3 small, 5th long
                    GetRealBody(i - 4) > GetCandleAverage(BodyLong, bodyPeriodTotal[4], i - 4) &&
                    GetRealBody(i - 3) < GetCandleAverage(BodyShort, bodyPeriodTotal[3], i - 3) &&
                    GetRealBody(i - 2) < GetCandleAverage(BodyShort, bodyPeriodTotal[2], i - 2) &&
                    GetRealBody(i - 1) < GetCandleAverage(BodyShort, bodyPeriodTotal[1], i - 1) &&
                    GetRealBody(i) > GetCandleAverage(BodyLong, bodyPeriodTotal[0], i) &&
                    // white, 3 black, white  ||  black, 3 white, black
                    GetCandleColor(i - 4) == -GetCandleColor(i - 3) &&
                    GetCandleColor(i - 3) == GetCandleColor(i - 2) &&
                    GetCandleColor(i - 2) == GetCandleColor(i - 1) &&
                    GetCandleColor(i - 1) == -GetCandleColor(i) &&
                    // 2nd to 4th hold within 1st: a part of the real body must be within 1st range
                    Min(open[i - 3], close[i - 3]) < high[i - 4] &&
                    Max(open[i - 3], close[i - 3]) > low[i - 4] &&
                    Min(open[i - 2], close[i - 2]) < high[i - 4] &&
                    Max(open[i - 2], close[i - 2]) > low[i - 4] &&
                    Min(open[i - 1], close[i - 1]) < high[i - 4] &&
                    Max(open[i - 1], close[i - 1]) > low[i - 4] &&
                    // 2nd to 4th are falling (rising)
                    close[i - 2] * GetCandleColor(i - 4) < close[i - 3] * GetCandleColor(i - 4) &&
                    close[i - 1] * GetCandleColor(i - 4) < close[i - 2] * GetCandleColor(i - 4) &&
                    // 5th opens above (below) the prior close
                    open[i] * GetCandleColor(i - 4) > close[i - 1] * GetCandleColor(i - 4) &&
                    // 5th closes above (below) the 1st close
                    close[i] * GetCandleColor(i - 4) > close[i - 4] * GetCandleColor(i - 4);

                outInteger[outIdx++] = isRiseFall3Methods ? 100 * GetCandleColor(i - 4) : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal[4] +=
                    GetCandleRange(BodyLong, i - 4) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

                for (int totIdx = 3; totIdx >= 1; --totIdx)
                {
                    bodyPeriodTotal[totIdx] +=
                        GetCandleRange(BodyShort, i - totIdx) -
                        GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx);
                }

                bodyPeriodTotal[0] +=
                    GetCandleRange(BodyLong, i) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx);

                i++;
                bodyShortTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlRiseFall3MethodsLookback()
        {
            return Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 4;
        }
    }
}
