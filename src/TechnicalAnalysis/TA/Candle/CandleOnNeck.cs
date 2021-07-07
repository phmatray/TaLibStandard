using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleOnNeck : CandleIndicator
    {
        private double _equalPeriodTotal;
        private double _bodyLongPeriodTotal;

        public CandleOnNeck(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                _equalPeriodTotal += GetCandleRange(Equal, i - 1);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 1);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: white candle with open below previous day low and close equal to previous day low
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): on-neck is always bearish
             * the user should consider that on-neck is significant when it appears in a downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _equalPeriodTotal +=
                    GetCandleRange(Equal, i - 1) -
                    GetCandleRange(Equal, equalTrailingIdx - 1);

                _bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 1) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - 1);

                i++;
                equalTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isOnNeck =
                // 1st: black
                GetCandleColor(i - 1) == -1 &&
                // long
                GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 1) &&
                // 2nd: white
                GetCandleColor(i) == 1 &&
                // open below prior low
                open[i] < low[i - 1] &&
                // close equal to prior low
                close[i] <= low[i - 1] + GetCandleAverage(Equal, _equalPeriodTotal, i - 1) &&
                close[i] >= low[i - 1] - GetCandleAverage(Equal, _equalPeriodTotal, i - 1);
            
            return isOnNeck;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(Equal), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
