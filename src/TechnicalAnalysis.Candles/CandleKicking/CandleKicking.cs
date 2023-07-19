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
public class CandleKicking<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private readonly T[] _shadowVeryShortPeriodTotal = new T[2];
    private readonly T[] _bodyLongPeriodTotal = new T[2];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="open"></param>
    /// <param name="high"></param>
    /// <param name="low"></param>
    /// <param name="close"></param>
    public CandleKicking(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public CandleKickingResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleKickingResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleKickingResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleKickingResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleKickingResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
            _shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i);
            i++;
        }

        i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
            _bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: marubozu
         * - second candle: opposite color marubozu
         * - gap between the two candles: upside gap if black then white, downside gap if white then black
         * The meaning of "long body" and "very short shadow" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? (int)GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            int totIdx;
            for (totIdx = 1; totIdx >= 0; --totIdx)
            {
                _bodyLongPeriodTotal[totIdx] +=
                    GetCandleRange(BodyLong, i - totIdx) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);

                _shadowVeryShortPeriodTotal[totIdx] +=
                    GetCandleRange(ShadowVeryShort, i - totIdx) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
            }

            i++;
            shadowVeryShortTrailingIdx++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleKickingResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isKicking =
            // opposite candles
            IsColorOpposite(i - 1, i) &&
            // 1st marubozu
            GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[1], i - 1) &&
            GetUpperShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            GetLowerShadow(i - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            // 2nd marubozu
            GetRealBody(i) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[0], i) &&
            GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            // gap
            (
                (IsColorRed(i - 1) && GetCandleGapUp(i, i - 1)) ||
                (IsColorGreen(i - 1) && GetCandleGapDown(i, i - 1))
            );
            
        return isKicking;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, BodyLong) + 1;
    }
}
