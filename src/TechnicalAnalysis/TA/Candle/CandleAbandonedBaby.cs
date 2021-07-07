using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleAbandonedBaby : CandleIndicator
    {
        private double _bodyLongPeriodTotal;
        private double _bodyDojiPeriodTotal;
        private double _bodyShortPeriodTotal;
        private double _penetration;

        public CandleAbandonedBaby(in double[] open, in double[] high, in double[] low, in double[] close)
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
            int bodyDojiTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyDoji);
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (i < startIdx - 1)
            {
                _bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white (black) real body
             * - second candle: doji
             * - third candle: black (white) real body that moves well within the first candle's real body
             * - upside (downside) gap between the first candle and the doji (the shadows of the two candles don't touch)
             * - downside (upside) gap between the doji and the third candle (the shadows of the two candles don't touch)
             * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
             * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
             * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
             * it to be relatively long
             * outInteger is positive (1 to 100) when it's an abandoned baby bottom or negative (-1 to -100) when it's 
             * an abandoned baby top; the user should consider that an abandoned baby is significant when it appears in 
             * an uptrend or downtrend, while this function does not consider the trend
             */
            int outIdx = 0;
            do
            {
                outInteger[outIdx++] = GetPatternRecognition(i) ? GetCandleColor(i) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                _bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 2) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx);

                _bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i - 1) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

                _bodyShortPeriodTotal +=
                    GetCandleRange(BodyShort, i) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx);

                i++;
                bodyLongTrailingIdx++;
                bodyDojiTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool isAbandonedBaby =
                // 1st: long
                GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
                // 2nd: doji
                GetRealBody(i - 1) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i - 1) &&
                // 3rd: longer than short
                GetRealBody(i) > GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
                (
                    (
                        // 1st white
                        GetCandleColor(i - 2) == 1 &&
                        // 3rd black
                        GetCandleColor(i) == -1 &&
                        // 3rd closes well within 1st rb
                        _close[i] < _close[i - 2] - GetRealBody(i - 2) * _penetration &&
                        // upside gap between 1st and 2nd
                        GetCandleGapUp(i - 1, i - 2) &&
                        // downside gap between 2nd and 3rd
                        GetCandleGapDown(i, i - 1)
                    )
                    ||
                    (
                        // 1st black
                        GetCandleColor(i - 2) == -1 &&
                        // 3rd white
                        GetCandleColor(i) == 1 &&
                        // 3rd closes well within 1st rb
                        _close[i] > _close[i - 2] + GetRealBody(i - 2) * _penetration &&
                        // downside gap between 1st and 2nd
                        GetCandleGapDown(i - 1, i - 2) &&
                        // upside gap between 2nd and 3rd
                        GetCandleGapUp(i, i - 1)
                    )
                );
            
            return isAbandonedBaby;
        }

        public override int GetLookback()
        {
            return Max(
                Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(BodyLong)),
                GetCandleAvgPeriod(BodyShort)
            ) + 2;
        }
    }
}
