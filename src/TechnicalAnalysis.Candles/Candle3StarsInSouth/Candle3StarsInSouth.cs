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
public class Candle3StarsInSouth<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private readonly T[] _shadowVeryShortPeriodTotal = new T[2];
    private T _bodyLongPeriodTotal = T.Zero;
    private T _shadowLongPeriodTotal = T.Zero;
    private T _bodyShortPeriodTotal = T.Zero;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="open"></param>
    /// <param name="high"></param>
    /// <param name="low"></param>
    /// <param name="close"></param>
    public Candle3StarsInSouth(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public Candle3StarsInSouthResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new Candle3StarsInSouthResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new Candle3StarsInSouthResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new Candle3StarsInSouthResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new Candle3StarsInSouthResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
        int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
        int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2);
            i++;
        }

        i = shadowLongTrailingIdx;
        while (i < startIdx)
        {
            _shadowLongPeriodTotal += GetCandleRange(ShadowLong, i - 2);
            i++;
        }

        i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1);
            _shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i);
            i++;
        }

        i = bodyShortTrailingIdx;
        while (i < startIdx)
        {
            _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long black candle with long lower shadow
         * - second candle: smaller black candle that opens higher than prior close but within prior candle's range 
         *   and trades lower than prior close but not lower than prior low and closes off of its low (it has a shadow)
         * - third candle: small black marubozu (or candle with very short shadows) engulfed by prior candle's range
         * The meanings of "long body", "short body", "very short shadow" are specified with TA_SetCandleSettings;
         * outInteger is positive (1 to 100): 3 stars in the south is always bullish;
         * the user should consider that 3 stars in the south is significant when it appears in downtrend, while this function 
         * does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 2) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 2);

            _shadowLongPeriodTotal +=
                GetCandleRange(ShadowLong, i - 2) -
                GetCandleRange(ShadowLong, shadowLongTrailingIdx - 2);

            int totIdx;
            for (totIdx = 1; totIdx >= 0; --totIdx)
            {
                _shadowVeryShortPeriodTotal[totIdx] +=
                    GetCandleRange(ShadowVeryShort, i - totIdx) -
                    GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx);
            }

            _bodyShortPeriodTotal +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
            shadowLongTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            bodyShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new Candle3StarsInSouthResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool is3StarsInSouth =
            // 1st black
            IsColorRed(i - 2) &&
            // 2nd black
            IsColorRed(i - 1) &&
            // 3rd black
            IsColorRed(i) &&
            // 1st: long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // with long lower shadow
            GetLowerShadow(i - 2) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i - 2) &&
            // 2nd: smaller candle
            GetRealBody(i - 1) < GetRealBody(i - 2) &&
            // that opens higher but within 1st range
            Open[i - 1] > Close[i - 2] &&
            Open[i - 1] <= High[i - 2] &&
            // and trades lower than 1st close
            Low[i - 1] < Close[i - 2] &&
            // but not lower than 1st low
            Low[i - 1] >= Low[i - 2] &&
            // and has a lower shadow
            GetLowerShadow(i - 1) > GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            // 3rd: small marubozu
            GetRealBody(i) < GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
            GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            // engulfed by prior candle's range
            Low[i] > Low[i - 1] && High[i] < High[i - 1];
            
        return is3StarsInSouth;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, ShadowLong, BodyLong, BodyShort) + 2;
    }
}
