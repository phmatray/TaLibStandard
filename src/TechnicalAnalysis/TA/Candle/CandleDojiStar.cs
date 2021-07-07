using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleDojiStar : CandleIndicator
    {
        public CandleDojiStar(in double[] open, in double[] high, in double[] low, in double[] close)
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
            double bodyLongPeriodTotal = 0.0;
            double bodyDojiPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyLong);
            int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long real body
             * - second candle: star (open gapping up in an uptrend or down in a downtrend) with a doji
             * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; 
             * it's defined bullish when the long candle is white and the star gaps up, bearish when the long candle 
             * is black and the star gaps down; the user should consider that a doji star is bullish when it appears 
             * in an uptrend and it's bearish when it appears in a downtrend, so to determine the bullishness or 
             * bearishness of the pattern the trend must be analyzed
             */
            int outIdx = 0;
            do
            {
                bool isDojiStar = GetPatternRecognition(i, bodyLongPeriodTotal, bodyDojiPeriodTotal);

                outInteger[outIdx++] = isDojiStar ? -GetCandleColor(i - 1) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyLongPeriodTotal +=
                    GetCandleRange(BodyLong, i - 1) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx);

                bodyDojiPeriodTotal +=
                    GetCandleRange(BodyDoji, i) -
                    GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

                i++;
                bodyLongTrailingIdx++;
                bodyDojiTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        private bool GetPatternRecognition(int i, double bodyLongPeriodTotal, double bodyDojiPeriodTotal)
        {
            bool isDojiStar =
                // 1st: long real body
                GetRealBody(i - 1) > GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 1) &&
                // 2nd: doji
                GetRealBody(i) <= GetCandleAverage(BodyDoji, bodyDojiPeriodTotal, i) &&
                (
                    (
                        // that gaps up if 1st is white
                        GetCandleColor(i - 1) == 1 &&
                        GetRealBodyGapUp(i, i - 1)
                    )
                    ||
                    (
                        // or down if 1st is black
                        GetCandleColor(i - 1) == -1 &&
                        GetRealBodyGapDown(i, i - 1)
                    )
                );
            
            return isDojiStar;
        }

        public override int GetLookback()
        {
            return Max(GetCandleAvgPeriod(BodyDoji), GetCandleAvgPeriod(BodyLong)) + 1;
        }
    }
}
