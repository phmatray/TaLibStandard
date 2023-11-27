// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Breakaway (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleBreakaway<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private T _bodyLongPeriodTotal = T.Zero;

    /// <summary>
    /// Computes the <see cref="CandleBreakaway{T}"/> indicator.
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
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 4);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long black (white)
         * - second candle: black (white) day whose body gaps down (up)
         * - third candle: black or white day with lower (higher) high and lower (higher) low than prior candle's
         * - fourth candle: black (white) day with lower (higher) high and lower (higher) low than prior candle's
         * - fifth candle: white (black) day that closes inside the gap, erasing the prior 3 days
         * The meaning of "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
         * the user should consider that breakaway is significant in a trend opposite to the last candle, while this 
         * function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? (int)GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 4) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

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
        bool isBreakaway =
            // 1st long
            GetRealBody(i - 4) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 4) &&
            // 1st, 2nd, 4th same color, 5th opposite
            GetCandleColor(i - 4) == GetCandleColor(i - 3) &&
            GetCandleColor(i - 3) == GetCandleColor(i - 1) &&
            IsColorOpposite(i - 1, i) &&
            (
                (
                    // when 1st is black:
                    IsColorRed(i - 4) &&
                    // 2nd gaps down
                    GetRealBodyGapDown(i - 3, i - 4) &&
                    // 3rd has lower high and low than 2nd
                    High[i - 2] < High[i - 3] &&
                    Low[i - 2] < Low[i - 3] &&
                    // 4th has lower high and low than 3rd
                    High[i - 1] < High[i - 2] &&
                    Low[i - 1] < Low[i - 2] &&
                    // 5th closes inside the gap
                    Close[i] > Open[i - 3] &&
                    Close[i] < Close[i - 4]
                )
                ||
                (
                    // when 1st is white:
                    GetCandleColor(i - 4) == CandleColor.Green &&
                    // 2nd gaps up
                    GetRealBodyGapUp(i - 3, i - 4) &&
                    // 3rd has higher high and low than 2nd
                    High[i - 2] > High[i - 3] &&
                    Low[i - 2] > Low[i - 3] &&
                    // 4th has higher high and low than 3rd
                    High[i - 1] > High[i - 2] &&
                    Low[i - 1] > Low[i - 2] &&
                    // 5th closes inside the gap
                    Close[i] < Open[i - 3] &&
                    Close[i] > Close[i - 4]
                )
            );
            
        return isBreakaway;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 4;
    }
}
