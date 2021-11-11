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
            return new(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (_open == null || _high == null || _low == null || _close == null)
        {
            return new(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new(Success, outBegIdx, outNBElement, outInteger);
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
            bool isIdentical3Crows = GetPatternRecognition(i);

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
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isIdentical3Crows =
            // 1st black
            GetCandleColor(i - 2) == -1 &&
            // very short lower shadow
            GetLowerShadow(i - 2) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], i - 2) &&
            // 2nd black
            GetCandleColor(i - 1) == -1 &&
            // very short lower shadow
            GetLowerShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            // 3rd black
            GetCandleColor(i) == -1 &&
            // very short lower shadow
            GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            // three declining
            _close[i - 2] > _close[i - 1] &&
            _close[i - 1] > _close[i] &&
            // 2nd black opens very close to 1st close
            _open[i - 1] <= _close[i - 2] + GetCandleAverage(Equal, _equalPeriodTotal[2], i - 2) &&
            _open[i - 1] >= _close[i - 2] - GetCandleAverage(Equal, _equalPeriodTotal[2], i - 2) &&
            // 3rd black opens very close to 2nd close 
            _open[i] <= _close[i - 1] + GetCandleAverage(Equal, _equalPeriodTotal[1], i - 1) &&
            _open[i] >= _close[i - 1] - GetCandleAverage(Equal, _equalPeriodTotal[1], i - 1);
            
        return isIdentical3Crows;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, Equal) + 2;
    }
}