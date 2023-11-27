// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Three Black Crows (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class Candle3BlackCrows<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private readonly T[] _shadowVeryShortPeriodTotal = new T[3];

    /// <summary>
    /// Computes the <see cref="Candle3BlackCrows{T}"/> indicator.
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <returns></returns>
    public CandleIndicatorResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleIndicatorResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleIndicatorResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleIndicatorResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
        int i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal[2] = GetCandleRange(ShadowVeryShort, i - 2);
            _shadowVeryShortPeriodTotal[1] = GetCandleRange(ShadowVeryShort, i - 1);
            _shadowVeryShortPeriodTotal[0] = GetCandleRange(ShadowVeryShort, i);
            i++;
        }
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - three consecutive and declining black candlesticks
         * - each candle must have no or very short lower shadow
         * - each candle after the first must open within the prior candle's real body
         * - the first candle's close should be under the prior white candle's high
         * The meaning of "very short" is specified with TA_SetCandleSettings
         * outInteger is negative (-1 to -100): three black crows is always bearish; 
         * the user should consider that 3 black crows is significant when it appears after a mature advance or at high levels, 
         * while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? -100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 2; totIdx >= 0; --totIdx)
            {
                _shadowVeryShortPeriodTotal[totIdx] +=
                    GetCandleRange(ShadowVeryShort, i - totIdx) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
            }

            i++;
            shadowVeryShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool is3BlackCrows =
            // white
            IsColorGreen(i - 3) &&
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
            // 2nd black opens within 1st black's rb
            Open[i - 1] < Open[i - 2] &&
            Open[i - 1] >= Close[i - 2] &&
            // 3rd black opens within 2nd black's rb
            Open[i] < Open[i - 1] &&
            Open[i] >= Close[i - 1] &&
            // 1st black closes under prior candle's high
            High[i - 3] > Close[i - 2] &&
            // three declining
            Close[i - 2] > Close[i - 1] &&
            // three declining
            Close[i - 1] > Close[i];
            
        return is3BlackCrows;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(ShadowVeryShort) + 3;
    }
}
