using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3LineStrike : CandleIndicator
    {
        public Candle3LineStrike(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double[] nearPeriodTotal = new double[4];

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
            nearPeriodTotal[3] = 0.0;
            nearPeriodTotal[2] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[3] += GetCandleRange(Near, i - 3);
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white soldiers (three black crows): three white (black) candlesticks with consecutively higher (lower) closes,
             * each opening within or near the previous real body
             * - fourth candle: black (white) candle that opens above (below) prior candle's close and closes below (above) 
             * the first candle's open
             * The meaning of "near" is specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that 3-line strike is significant when it appears in a trend in the same direction of
             * the first three candles, while this function does not consider it
             */
            int outIdx = 0;
            do
            {
                bool is3LineStrike =
                    // three with same color
                    GetCandleColor(i - 3) == GetCandleColor(i - 2) &&
                    GetCandleColor(i - 2) == GetCandleColor(i - 1) &&
                    // 4th opposite color
                    GetCandleColor(i) == -GetCandleColor(i - 1) &&
                    // 2nd opens within/near 1st rb
                    open[i - 2] >= Min(open[i - 3], close[i - 3]) -
                    GetCandleAverage(Near, nearPeriodTotal[3], i - 3) &&
                    open[i - 2] <= Max(open[i - 3], close[i - 3]) +
                    GetCandleAverage(Near, nearPeriodTotal[3], i - 3) &&
                    // 3rd opens within/near 2nd rb
                    open[i - 1] >= Min(open[i - 2], close[i - 2]) -
                    GetCandleAverage(Near, nearPeriodTotal[2], i - 2) &&
                    open[i - 1] <= Max(open[i - 2], close[i - 2]) +
                    GetCandleAverage(Near, nearPeriodTotal[2], i - 2) &&
                    (
                        ( // if three white
                            GetCandleColor(i - 1) == 1 &&
                            close[i - 1] > close[i - 2] &&
                            // consecutive higher closes
                            close[i - 2] > close[i - 3] &&
                            // 4th opens above prior close
                            open[i] > close[i - 1] &&
                            // 4th closes below 1st open
                            close[i] < open[i - 3]
                        ) ||
                        ( // if three black
                            GetCandleColor(i - 1) == -1 &&
                            close[i - 1] < close[i - 2] &&
                            // consecutive lower closes
                            close[i - 2] < close[i - 3] &&
                            // 4th opens below prior close
                            open[i] < close[i - 1] &&
                            // 4th closes above 1st open
                            close[i] > open[i - 3]
                        )
                    );

                outInteger[outIdx++] = is3LineStrike ? GetCandleColor(i - 1) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 3; totIdx >= 2; --totIdx)
                {
                    nearPeriodTotal[totIdx] +=
                        GetCandleRange(Near, i - totIdx) -
                        GetCandleRange(Near, nearTrailingIdx - totIdx);
                }

                i++;
                nearTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override int GetLookback()
        {
            return GetCandleAvgPeriod(Near) + 3;
        }
    }
}
