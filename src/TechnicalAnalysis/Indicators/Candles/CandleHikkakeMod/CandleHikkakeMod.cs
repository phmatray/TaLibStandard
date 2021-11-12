using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleHikkakeMod;

public class CandleHikkakeMod : CandleIndicator
{
    private double _nearPeriodTotal;

    public CandleHikkakeMod(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleHikkakeModResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleHikkakeModResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleHikkakeModResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleHikkakeModResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleHikkakeModResult(Success, outBegIdx, outNBElement, outInteger);
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
            if (RecognizeCandlePattern(i))
            {
                patternResult = 100 * (High[i] < High[i - 1] ? 1 : -1);
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
            if (RecognizeCandlePattern(i))
            {
                patternResult = 100 * (High[i] < High[i - 1] ? 1 : -1);
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
            
        return new CandleHikkakeModResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool patternRecognition =
            // 2nd: lower high and higher low than 1st
            High[index - 2] < High[index - 3] && Low[index - 2] > Low[index - 3] &&
            // 3rd: lower high and higher low than 2nd
            High[index - 1] < High[index - 2] && Low[index - 1] > Low[index - 2] &&
            (
                // (bull) 4th: lower high and lower low
                High[index] < High[index - 1] && Low[index] < Low[index - 1] &&
                // (bull) 2nd: close near the low
                Close[index - 2] <= Low[index - 2] + GetCandleAverage(Near, _nearPeriodTotal, index - 2) ||
                // (bear) 4th: higher high and higher low
                High[index] > High[index - 1] && Low[index] > Low[index - 1] &&
                // (bull) 2nd: close near the top
                Close[index - 2] >= High[index - 2] - GetCandleAverage(Near, _nearPeriodTotal, index - 2)
            );
            
        return patternRecognition;
    }

    private bool GetPatternConfirmation(int i, int patternIdx, int patternResult)
    {
        bool confirmation =
            i <= patternIdx + 3 &&
            (
                // close higher than the high of 3rd
                patternResult > 0 && Close[i] > High[patternIdx - 1] ||
                // close lower than the low of 3rd
                patternResult < 0 && Close[i] < Low[patternIdx - 1]
            );
            
        return confirmation;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return Max(1, GetCandleAvgPeriod(Near)) + 5;
    }
}
