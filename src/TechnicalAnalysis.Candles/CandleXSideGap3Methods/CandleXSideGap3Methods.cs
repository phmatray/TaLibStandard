// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// 
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T"></typeparam>
public class CandleXSideGap3Methods<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
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
        int i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: white (black) candle
         * - second candle: white (black) candle
         * - upside (downside) gap between the first and the second real bodies
         * - third candle: black (white) candle that opens within the second real body and closes within the first real body
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
         * the user should consider that up/downside gap 3 methods is significant when it appears in a trend, while this 
         * function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? (int)GetCandleColor(i - 2) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            i++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isXSideGap3Methods =
            // 1st and 2nd of same color
            IsColorSame(i - 2, i - 1) &&
            // 3rd opposite color
            IsColorOpposite(i - 1, i) &&
            // 3rd opens within 2nd rb
            Open[i] < T.Max(Close[i - 1], Open[i - 1]) &&
            Open[i] > T.Min(Close[i - 1], Open[i - 1]) &&
            // 3rd closes within 1st rb
            Close[i] < T.Max(Close[i - 2], Open[i - 2]) &&
            Close[i] > T.Min(Close[i - 2], Open[i - 2]) &&
            (
                (
                    // when 1st is white
                    IsColorGreen(i - 2) &&
                    // upside gap
                    GetRealBodyGapUp(i - 1, i - 2)
                ) ||
                (
                    // when 1st is black
                    IsColorRed(i - 2) &&
                    // downside gap
                    GetRealBodyGapDown(i - 1, i - 2)
                )
            );
            
        return isXSideGap3Methods;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return 2;
    }
}
