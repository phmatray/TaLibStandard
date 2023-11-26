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
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleTasukiGap<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private T _nearPeriodTotal = T.Zero;

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
        int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
        int i = nearTrailingIdx;
        while (i < startIdx)
        {
            _nearPeriodTotal += GetCandleRange(Near, i - 1);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - upside (downside) gap
         * - first candle after the window: white (black) candlestick
         * - second candle: black (white) candlestick that opens within the previous real body and closes under (above)
         *   the previous real body inside the gap
         * - the size of two real bodies should be near the same
         * The meaning of "near" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
         * the user should consider that tasuki gap is significant when it appears in a trend, while this function does 
         * not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? (int)GetCandleColor(i - 1) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _nearPeriodTotal +=
                GetCandleRange(Near, i - 1) -
                GetCandleRange(Near, nearTrailingIdx - 1);

            i++;
            nearTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isTasukiGap =
            (
                // upside gap
                GetRealBodyGapUp(i - 1, i - 2) &&
                // 1st: white
                IsColorGreen(i - 1) &&
                // 2nd: black
                IsColorRed(i) &&
                // that opens within the white rb
                Open[i] < Close[i - 1] && Open[i] > Open[i - 1] &&
                // and closes under the white rb
                Close[i] < Open[i - 1] &&
                // inside the gap
                Close[i] > T.Max(Close[i - 2], Open[i - 2]) &&
                // size of 2 rb near the same
                T.Abs(GetRealBody(i - 1) - GetRealBody(i)) < GetCandleAverage(Near, _nearPeriodTotal, i - 1)
            ) ||
            (
                // downside gap
                GetRealBodyGapDown(i - 1, i - 2) &&
                // 1st: black
                IsColorRed(i - 1) &&
                // 2nd: white
                IsColorGreen(i) &&
                // that opens within the black rb
                Open[i] < Open[i - 1] && Open[i] > Close[i - 1] &&
                // and closes above the black rb
                Close[i] > Open[i - 1] &&
                // inside the gap
                Close[i] < T.Min(Close[i - 2], Open[i - 2]) &&
                // size of 2 rb near the same
                T.Abs(GetRealBody(i - 1) - GetRealBody(i)) < GetCandleAverage(Near, _nearPeriodTotal, i - 1)
            );
            
        return isTasukiGap;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(Near) + 2;
    }
}
