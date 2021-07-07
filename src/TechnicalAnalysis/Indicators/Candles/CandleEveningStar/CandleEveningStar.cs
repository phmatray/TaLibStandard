using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;

namespace TechnicalAnalysis.Candles.CandleEveningStar
{
    public class CandleEveningStar : CandleIndicator
    {
        private double _penetration;
        private double _bodyLongPeriodTotal;
        private double _bodyShortPeriodTotal;
        private double _bodyShortPeriodTotal2;

        public CandleEveningStar(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode TryCompute(
            int startIdx,
            int endIdx,
            in double optInPenetration,
            out int outBegIdx,
            out int outNBElement,
            out int[] outInteger)
        {
            _penetration = optInPenetration;
            
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
            if (_open == null || _high == null || _low == null || _close == null)
            {
                return RetCode.BadParam;
            }

            if (optInPenetration < 0.0)
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
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx - 1)
            {
                _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
                _bodyShortPeriodTotal2 += GetCandleRange(BodyShort, i + 1);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white real body
             * - second candle: star (short real body gapping up)
             * - third candle: black real body that moves well within the first candle's real body
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
             * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
             * it to be relatively long
             * outInteger is negative (-1 to -100): evening star is always bearish; 
             * the user should consider that an evening star is significant when it appears in an uptrend, 
             * while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx);

                _bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i - 1) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx);

                _bodyShortPeriodTotal2 +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx + 1);

                i++;
                bodyLongTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isEveningStar =
                // 1st: long
                GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
                // white
                GetCandleColor(i - 2) == 1 &&
                // 2nd: short
                GetRealBody(i - 1) <= GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i - 1) &&
                // gapping up
                GetRealBodyGapUp(i - 1, i - 2) &&
                // 3rd: longer than short
                GetRealBody(i) > GetCandleAverage(BodyShort, _bodyShortPeriodTotal2, i) &&
                // black real body
                GetCandleColor(i) == -1 &&
                // closing well within 1st rb
                _close[i] < _close[i - 2] - GetRealBody(i - 2) * _penetration;
            
            return isEveningStar;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(BodyShort), GetCandleAvgPeriod(BodyLong)) + 2;
        }
    }
}
