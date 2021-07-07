using TechnicalAnalysis.Abstractions;
using static System.Math;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleHikkakeMod : CandleIndicator
    {
        private double _nearPeriodTotal;

        public CandleHikkakeMod(in double[] open, in double[] high, in double[] low, in double[] close)
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
            if (_open == null || _high == null || _low == null || _close == null)
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
            int nearTrailingIdx = startIdx - 3 - GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx - 3)
            {
                _nearPeriodTotal += GetCandleRange(Near, i - 2);
                i++;
            }

            int patternIdx = 0;
            int patternResult = 0;
            
            i = startIdx - 3;
            while (i < startIdx)
            {
                if (GetPatternRecognition(i))
                {
                    patternResult = 100 * (_high[i] < _high[i - 1] ? 1 : -1);
                    patternIdx = i;
                }
                else
                {
                    // search for confirmation if modified hikkake was no more than 3 bars ago
                    if (GetPatternConfirmation(i, patternIdx, patternResult))
                    {
                        patternIdx = 0;
                    }
                }

                _nearPeriodTotal +=
                    GetCandleRange(Near, i - 2) -
                    GetCandleRange(Near, nearTrailingIdx - 2);
                
                nearTrailingIdx++;
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle
             * - second candle: candle with range less than first candle and close near the bottom (near the top)
             * - third candle: lower high and higher low than 2nd
             * - fourth candle: lower high and lower low (higher high and higher low) than 3rd
             * outInteger[hikkake bar] is positive (1 to 100) or negative (-1 to -100) meaning bullish or bearish hikkake
             * Confirmation could come in the next 3 days with:
             * - a day that closes higher than the high (lower than the low) of the 3rd candle
             * outInteger[confirmationbar] is equal to 100 + the bullish hikkake result or -100 - the bearish hikkake result
             * Note: if confirmation and a new hikkake come at the same bar, only the new hikkake is reported (the new hikkake
             * overwrites the confirmation of the old hikkake);
             * the user should consider that modified hikkake is a reversal pattern, while hikkake could be both a reversal 
             * or a continuation pattern, so bullish (bearish) modified hikkake is significant when appearing in a downtrend 
             * (uptrend)
             */
            int outIdx = 0;
            do
            {
                if (GetPatternRecognition(i))
                {
                    patternResult = 100 * (_high[i] < _high[i - 1] ? 1 : -1);
                    patternIdx = i;
                    outInteger[outIdx++] = patternResult;
                }
                else
                {
                    /* search for confirmation if modified hikkake was no more than 3 bars ago */
                    if (GetPatternConfirmation(i, patternIdx, patternResult))
                    {
                        outInteger[outIdx++] = patternResult + 100 * (patternResult > 0 ? 1 : -1);
                        patternIdx = 0;
                    }
                    else
                    {
                        outInteger[outIdx++] = 0;
                    }
                }

                _nearPeriodTotal +=
                    GetCandleRange(Near, i - 2) -
                    GetCandleRange(Near, nearTrailingIdx - 2);

                nearTrailingIdx++;
                i++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public override bool GetPatternRecognition(int i)
        {
            bool patternRecognition =
                // 2nd: lower high and higher low than 1st
                _high[i - 2] < _high[i - 3] && _low[i - 2] > _low[i - 3] &&
                // 3rd: lower high and higher low than 2nd
                _high[i - 1] < _high[i - 2] && _low[i - 1] > _low[i - 2] &&
                (
                    // (bull) 4th: lower high and lower low
                    _high[i] < _high[i - 1] && _low[i] < _low[i - 1] &&
                    // (bull) 2nd: close near the low
                    _close[i - 2] <= _low[i - 2] + GetCandleAverage(Near, _nearPeriodTotal, i - 2) ||
                    // (bear) 4th: higher high and higher low
                    _high[i] > _high[i - 1] && _low[i] > _low[i - 1] &&
                    // (bull) 2nd: close near the top
                    _close[i - 2] >= _high[i - 2] - GetCandleAverage(Near, _nearPeriodTotal, i - 2)
                );
            
            return patternRecognition;
        }

        private bool GetPatternConfirmation(int i, int patternIdx, int patternResult)
        {
            bool confirmation =
                i <= patternIdx + 3 &&
                (
                    // close higher than the high of 3rd
                    patternResult > 0 && _close[i] > _high[patternIdx - 1] ||
                    // close lower than the low of 3rd
                    patternResult < 0 && _close[i] < _low[patternIdx - 1]
                );
            
            return confirmation;
        }

        public override int GetLookback()
        {
            return Max(1, GetCandleAvgPeriod(Near)) + 5;
        }
    }
}
