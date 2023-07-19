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
public class CandleConcealBabySwallow<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private readonly T[] _shadowVeryShortPeriodTotal = new T[4];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="open"></param>
    /// <param name="high"></param>
    /// <param name="low"></param>
    /// <param name="close"></param>
    public CandleConcealBabySwallow(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public CandleConcealBabySwallowResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleConcealBabySwallowResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleConcealBabySwallowResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleConcealBabySwallowResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleConcealBabySwallowResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
        int i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal[3] += GetCandleRange(ShadowVeryShort, i - 3);
            _shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2);
            _shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: black marubozu (very short shadows)
         * - second candle: black marubozu (very short shadows)
         * - third candle: black candle that opens gapping down but has an upper shadow that extends into the prior body
         * - fourth candle: black candle that completely engulfs the third candle, including the shadows
         * The meanings of "very short shadow" are specified with TA_SetCandleSettings;
         * outInteger is positive (1 to 100): concealing baby swallow is always bullish;
         * the user should consider that concealing baby swallow is significant when it appears in downtrend, while 
         * this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 3; totIdx >= 1; --totIdx)
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
            
        return new CandleConcealBabySwallowResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isConcealBabySwallow =
            // 1st black
            IsColorRed(i - 3) &&
            // 2nd black
            IsColorRed(i - 2) &&
            // 3rd black
            IsColorRed(i - 1) &&
            // 4th black
            IsColorRed(i) &&
            // 1st: marubozu
            GetLowerShadow(i - 3) <
            GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[3], i - 3) &&
            GetUpperShadow(i - 3) <
            GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[3], i - 3) &&
            // 2nd: marubozu
            GetLowerShadow(i - 2) <
            GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], i - 2) &&
            GetUpperShadow(i - 2) <
            GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[2], i - 2) &&
            // 3rd: opens gapping down
            GetRealBodyGapDown(i - 1, i - 2) &&
            // and HAS an upper shadow
            GetUpperShadow(i - 1) >
            GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            // that extends into the prior body
            High[i - 1] > Close[i - 2] &&
            // 4th: engulfs the 3rd including the shadows
            High[i] > High[i - 1] && Low[i] < Low[i - 1];
            
        return isConcealBabySwallow;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(ShadowVeryShort) + 3;
    }
}
