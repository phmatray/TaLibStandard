// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Two Crows (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class Candle2Crows<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private T _bodyLongPeriodTotal = T.Zero;
    
    private void ValidateIndices(ref int startIdx, ref int endIdx)
    {
        // Validate the requested output range.
        ArgumentOutOfRangeException.ThrowIfNegative(startIdx);
        ArgumentOutOfRangeException.ThrowIfNegative(endIdx - startIdx);

        // Verify required price component.
        ArgumentNullException.ThrowIfNull(Open);
        ArgumentNullException.ThrowIfNull(High);
        ArgumentNullException.ThrowIfNull(Low);
        ArgumentNullException.ThrowIfNull(Close);
    }
    
    /// <summary>
    /// Computes the <see cref="Candle2Crows{T}"/> indicator.
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
        ArgumentOutOfRangeException.ThrowIfNegative(startIdx);
        ArgumentOutOfRangeException.ThrowIfNegative(endIdx - startIdx);

        // Verify required price component.
        ArgumentNullException.ThrowIfNull(Open);
        ArgumentNullException.ThrowIfNull(High);
        ArgumentNullException.ThrowIfNull(Low);
        ArgumentNullException.ThrowIfNull(Close);

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
        int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);

        int i = bodyLongTrailingIdx;
        while (i < startIdx - 2)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white candle
         * - second candle: black real body
         * - gap between the first and the second candle's real bodies
         * - third candle: black candle that opens within the second real body and closes within the first real body
         * The meaning of "long" is specified with TA_SetCandleSettings
         * outInteger is negative (-1 to -100): two crows is always bearish; 
         * the user should consider that two crows is significant when it appears in an uptrend, while this function 
         * does not consider the trend
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

            i++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool is2Crows =
            // 1st: white
            IsColorGreen(i - 2) &&
            // long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // 2nd: black
            IsColorRed(i - 1) &&
            // gapping up
            GetRealBodyGapUp(i - 1, i - 2) &&
            // 3rd: black
            IsColorRed(i) &&
            // opening within 2nd rb
            Open[i] < Open[i - 1] && Open[i] >= Close[i - 1] &&
            // closing within 1st rb
            Close[i] > Open[i - 2] && Close[i] < Close[i - 2];

        return is2Crows;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 2;
    }
}
