// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Stalled Pattern (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleStalledPattern<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private readonly T[] _bodyLongPeriodTotal = new T[3];
    private readonly T[] _nearPeriodTotal = new T[3];
    private T _bodyShortPeriodTotal = T.Zero;
    private T _shadowVeryShortPeriodTotal = T.Zero;

    /// <summary>
    /// Computes the <see cref="CandleStalledPattern{T}"/> indicator.
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
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
        int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
        int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal[2] += GetCandleRange(BodyLong, i - 2);
            _bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
            i++;
        }

        i = bodyShortTrailingIdx;
        while (i < startIdx)
        {
            _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
            i++;
        }

        i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1);
            i++;
        }

        i = nearTrailingIdx;
        while (i < startIdx)
        {
            _nearPeriodTotal[2] += GetCandleRange(Near, i - 2);
            _nearPeriodTotal[1] += GetCandleRange(Near, i - 1);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - three white candlesticks with consecutively higher closes
         * - first candle: long white
         * - second candle: long white with no or very short upper shadow opening within or near the previous white real body
         * and closing higher than the prior candle
         * - third candle: small white that gaps away or "rides on the shoulder" of the prior long real body (= it's at 
         * the upper end of the prior real body)
         * The meanings of "long", "very short", "short", "near" are specified with TA_SetCandleSettings;
         * outInteger is negative (-1 to -100): stalled pattern is always bearish;
         * the user should consider that stalled pattern is significant when it appears in uptrend, while this function 
         * does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? -100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 2; totIdx >= 1; --totIdx)
            {
                _bodyLongPeriodTotal[totIdx] +=
                    GetCandleRange(BodyLong, i - totIdx) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);

                _nearPeriodTotal[totIdx] +=
                    GetCandleRange(Near, i - totIdx) -
                    GetCandleRange(Near, nearTrailingIdx - totIdx);
            }

            _bodyShortPeriodTotal +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx);

            _shadowVeryShortPeriodTotal +=
                GetCandleRange(ShadowVeryShort, i - 1) -
                GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1);

            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
            shadowVeryShortTrailingIdx++;
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
        bool isStalledPattern =
            // 1st white
            IsColorGreen(i - 2) &&
            // 2nd white
            IsColorGreen(i - 1) &&
            // 3rd white
            IsColorGreen(i) &&
            // consecutive higher closes
            Close[i] > Close[i - 1] &&
            Close[i - 1] > Close[i - 2] &&
            // 1st: long real body
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[2], i - 2) &&
            // 2nd: long real body
            GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[1], i - 1) &&
            // very short upper shadow 
            GetUpperShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i - 1) &&
            // opens within/near 1st real body
            Open[i - 1] > Open[i - 2] &&
            Open[i - 1] <= Close[i - 2] + GetCandleAverage(Near, _nearPeriodTotal[2], i - 2) &&
            // 3rd: small real body
            GetRealBody(i) < GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
            // rides on the shoulder of 2nd real body
            Open[i] >= Close[i - 1] - GetRealBody(i) - GetCandleAverage(Near, _nearPeriodTotal[1], i - 1);
            
        return isStalledPattern;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyLong, BodyShort, ShadowVeryShort, Near) + 2;
    }
}
