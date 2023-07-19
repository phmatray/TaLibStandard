// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class Candle3Outside<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="open">An array of open prices.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of close prices.</param>
    public Candle3Outside(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public Candle3OutsideResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new Candle3OutsideResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }
            
        if (endIdx < 0 || endIdx < startIdx)
        {
            return new Candle3OutsideResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new Candle3OutsideResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new Candle3OutsideResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first: black (white) real body
         * - second: white (black) real body that engulfs the prior real body
         * - third: candle that closes higher (lower) than the second candle
         * outInteger is positive (1 to 100) for the three outside up or negative (-1 to -100) for the three outside down;
         * the user should consider that a three outside up must appear in a downtrend and three outside down must appear
         * in an uptrend, while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? (int)GetCandleColor(i - 1) * 100 : 0;
            i++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new Candle3OutsideResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool is3Outside =
            (
                // white engulfs black
                IsColorGreen(i - 1) &&
                IsColorRed(i - 2) &&
                Close[i - 1] > Open[i - 2] &&
                Open[i - 1] < Close[i - 2] &&
                // third candle higher
                Close[i] > Close[i - 1]
            )
            ||
            (
                // black engulfs white
                IsColorRed(i - 1) &&
                IsColorGreen(i - 2) &&
                Open[i - 1] > Close[i - 2] &&
                Close[i - 1] < Open[i - 2] &&
                // third candle lower
                Close[i] < Close[i - 1]
            );
            
        return is3Outside;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return 3;
    }
}
