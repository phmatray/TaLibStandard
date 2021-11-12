using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleIdentical3Crows;

public class CandleIdentical3Crows : CandleIndicator
{
    private readonly double[] _shadowVeryShortPeriodTotal = new double[3];
    private readonly double[] _equalPeriodTotal = new double[3];

    public CandleIdentical3Crows(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleIdentical3CrowsResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleIdentical3CrowsResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleIdentical3CrowsResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleIdentical3CrowsResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleIdentical3CrowsResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
        int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
        int i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2);
            _shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
            _shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i);
            i++;
        }

        i = equalTrailingIdx;
        while (i < startIdx)
        {
            _equalPeriodTotal[2] += GetCandleRange(Equal, i - 2);
            _equalPeriodTotal[1] += GetCandleRange(Equal, i - 1);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - three consecutive and declining black candlesticks
         * - each candle must have no or very short lower shadow
         * - each candle after the first must open at or very close to the prior candle's close
         * The meaning of "very short" is specified with TA_SetCandleSettings;
         * the meaning of "very close" is specified with TA_SetCandleSettings (Equal);
         * outInteger is negative (-1 to -100): identical three crows is always bearish; 
         * the user should consider that identical 3 crows is significant when it appears after a mature advance or at high levels, 
         * while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            bool isIdentical3Crows = RecognizeCandlePattern(i);

            outInteger[outIdx++] = isIdentical3Crows ? -100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 2; totIdx >= 0; --totIdx)
            {
                _shadowVeryShortPeriodTotal[totIdx] +=
                    GetCandleRange(ShadowVeryShort, i - totIdx) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
            }

            for (int totIdx = 2; totIdx >= 1; --totIdx)
            {
                _equalPeriodTotal[totIdx] +=
                    GetCandleRange(Equal, i - totIdx) -
                    GetCandleRange(Equal, equalTrailingIdx - totIdx);
            }

            i++;
            shadowVeryShortTrailingIdx++;
            equalTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleIdentical3CrowsResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isIdentical3Crows =
            // 1st black
            GetCandleColor(index - 2) == -1 &&
            // very short lower shadow
            GetLowerShadow(index - 2) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], index - 2) &&
            // 2nd black
            GetCandleColor(index - 1) == -1 &&
            // very short lower shadow
            GetLowerShadow(index - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], index - 1) &&
            // 3rd black
            GetCandleColor(index) == -1 &&
            // very short lower shadow
            GetLowerShadow(index) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], index) &&
            // three declining
            Close[index - 2] > Close[index - 1] &&
            Close[index - 1] > Close[index] &&
            // 2nd black opens very close to 1st close
            Open[index - 1] <= Close[index - 2] + GetCandleAverage(Equal, _equalPeriodTotal[2], index - 2) &&
            Open[index - 1] >= Close[index - 2] - GetCandleAverage(Equal, _equalPeriodTotal[2], index - 2) &&
            // 3rd black opens very close to 2nd close 
            Open[index] <= Close[index - 1] + GetCandleAverage(Equal, _equalPeriodTotal[1], index - 1) &&
            Open[index] >= Close[index - 1] - GetCandleAverage(Equal, _equalPeriodTotal[1], index - 1);
            
        return isIdentical3Crows;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, Equal) + 2;
    }
}
