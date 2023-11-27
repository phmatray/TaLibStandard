// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Identical Three Crows (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleIdentical3Crows<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private readonly T[] _shadowVeryShortPeriodTotal = new T[3];
    private readonly T[] _equalPeriodTotal = new T[3];

    /// <summary>
    /// Computes the <see cref="CandleIdentical3Crows{T}"/> indicator.
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <returns></returns>
    public CandleIndicatorResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        (int outBegIdx, int outNBElement, int[] outInteger) = PrepareOutput(startIdx, endIdx);

        // Validations
        ValidateIndices(ref startIdx, ref endIdx);
        ValidatePriceArrays();

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
            return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
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
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isIdentical3Crows =
            // 1st black
            IsColorRed(i - 2) &&
            // very short lower shadow
            GetLowerShadow(i - 2) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], i - 2) &&
            // 2nd black
            IsColorRed(i - 1) &&
            // very short lower shadow
            GetLowerShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            // 3rd black
            IsColorRed(i) &&
            // very short lower shadow
            GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            // three declining
            Close[i - 2] > Close[i - 1] &&
            Close[i - 1] > Close[i] &&
            // 2nd black opens very close to 1st close
            Open[i - 1] <= Close[i - 2] + GetCandleAverage(Equal, _equalPeriodTotal[2], i - 2) &&
            Open[i - 1] >= Close[i - 2] - GetCandleAverage(Equal, _equalPeriodTotal[2], i - 2) &&
            // 3rd black opens very close to 2nd close 
            Open[i] <= Close[i - 1] + GetCandleAverage(Equal, _equalPeriodTotal[1], i - 1) &&
            Open[i] >= Close[i - 1] - GetCandleAverage(Equal, _equalPeriodTotal[1], i - 1);
            
        return isIdentical3Crows;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, Equal) + 2;
    }
}
