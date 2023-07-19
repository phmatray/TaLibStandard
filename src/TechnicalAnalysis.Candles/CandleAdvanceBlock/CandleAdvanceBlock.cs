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
public class CandleAdvanceBlock<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private readonly T[] _shadowShortPeriodTotal = new T[3];
    private readonly T[] _shadowLongPeriodTotal = new T[2];
    private readonly T[] _nearPeriodTotal = new T[3];
    private readonly T[] _farPeriodTotal = new T[3];
    private T _bodyLongPeriodTotal = T.Zero;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="open"></param>
    /// <param name="high"></param>
    /// <param name="low"></param>
    /// <param name="close"></param>
    public CandleAdvanceBlock(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public CandleAdvanceBlockResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleAdvanceBlockResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleAdvanceBlockResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleAdvanceBlockResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleAdvanceBlockResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int shadowShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowShort);
        int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
        int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
        int farTrailingIdx = startIdx - GetCandleAvgPeriod(Far);
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = shadowShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowShortPeriodTotal[2] += GetCandleRange(ShadowShort, i - 2);
            _shadowShortPeriodTotal[1] += GetCandleRange(ShadowShort, i - 1);
            _shadowShortPeriodTotal[0] += GetCandleRange(ShadowShort, i);
            i++;
        }

        i = shadowLongTrailingIdx;
        while (i < startIdx)
        {
            _shadowLongPeriodTotal[1] += GetCandleRange(ShadowLong, i - 1);
            _shadowLongPeriodTotal[0] += GetCandleRange(ShadowLong, i);
            i++;
        }

        i = nearTrailingIdx;
        while (i < startIdx)
        {
            _nearPeriodTotal[2] += GetCandleRange(Near, i - 2);
            _nearPeriodTotal[1] += GetCandleRange(Near, i - 1);
            i++;
        }

        i = farTrailingIdx;
        while (i < startIdx)
        {
            _farPeriodTotal[2] += GetCandleRange(Far, i - 2);
            _farPeriodTotal[1] += GetCandleRange(Far, i - 1);
            i++;
        }

        i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - three white candlesticks with consecutively higher closes
         * - each candle opens within or near the previous white real body 
         * - first candle: long white with no or very short upper shadow (a short shadow is accepted too for more flexibility)
         * - second and third candles, or only third candle, show signs of weakening: progressively smaller white real bodies 
         * and/or relatively long upper shadows; see below for specific conditions
         * The meanings of "long body", "short shadow", "far" and "near" are specified with TA_SetCandleSettings;
         * outInteger is negative (-1 to -100): advance block is always bearish;
         * the user should consider that advance block is significant when it appears in uptrend, while this function 
         * does not consider it
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
                _shadowShortPeriodTotal[totIdx] +=
                    GetCandleRange(ShadowShort, i - totIdx) -
                    GetCandleRange(ShadowShort, shadowShortTrailingIdx - totIdx);
            }

            for (int totIdx = 1; totIdx >= 0; --totIdx)
            {
                _shadowLongPeriodTotal[totIdx] +=
                    GetCandleRange(ShadowLong, i - totIdx) -
                    GetCandleRange(ShadowLong, shadowLongTrailingIdx - totIdx);
            }

            for (int totIdx = 2; totIdx >= 1; --totIdx)
            {
                _farPeriodTotal[totIdx] +=
                    GetCandleRange(Far, i - totIdx) -
                    GetCandleRange(Far, farTrailingIdx - totIdx);

                _nearPeriodTotal[totIdx] +=
                    GetCandleRange(Near, i - totIdx) -
                    GetCandleRange(Near, nearTrailingIdx - totIdx);
            }

            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 2) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 2);

            i++;
            shadowShortTrailingIdx++;
            shadowLongTrailingIdx++;
            nearTrailingIdx++;
            farTrailingIdx++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleAdvanceBlockResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isAdvanceBlock =
            // 1st white
            IsColorGreen(i - 2) &&
            // 2nd white
            IsColorGreen(i - 1) &&
            // 3rd white
            IsColorGreen(i) &&
            // consecutive higher closes
            Close[i] > Close[i - 1] && Close[i - 1] > Close[i - 2] &&
            // 2nd opens within/near 1st real body
            Open[i - 1] > Open[i - 2] &&
            Open[i - 1] <= Close[i - 2] + GetCandleAverage(Near, _nearPeriodTotal[2], i - 2) &&
            // 3rd opens within/near 2nd real body
            Open[i] > Open[i - 1] &&
            Open[i] <= Close[i - 1] + GetCandleAverage(Near, _nearPeriodTotal[1], i - 1) &&
            // 1st: long real body
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // 1st: short upper shadow
            GetUpperShadow(i - 2) < GetCandleAverage(ShadowShort, _shadowShortPeriodTotal[2], i - 2) &&
            (
                // ( 2 far smaller than 1 && 3 not longer than 2 )
                // advance blocked with the 2nd, 3rd must not carry on the advance
                (
                    GetRealBody(i - 1) < GetRealBody(i - 2) -
                    GetCandleAverage(Far, _farPeriodTotal[2], i - 2) &&
                    GetRealBody(i) < GetRealBody(i - 1) +
                    GetCandleAverage(Near, _nearPeriodTotal[1], i - 1)
                ) ||
                // 3 far smaller than 2
                // advance blocked with the 3rd
                (
                    GetRealBody(i) < GetRealBody(i - 1) -
                    GetCandleAverage(Far, _farPeriodTotal[1], i - 1)
                ) ||
                // ( 3 smaller than 2 && 2 smaller than 1 && (3 or 2 not short upper shadow) )
                // advance blocked with progressively smaller real bodies and some upper shadows
                (
                    GetRealBody(i) < GetRealBody(i - 1) &&
                    GetRealBody(i - 1) < GetRealBody(i - 2) &&
                    (
                        GetUpperShadow(i) >
                        GetCandleAverage(ShadowShort, _shadowShortPeriodTotal[0], i) ||
                        GetUpperShadow(i - 1) >
                        GetCandleAverage(ShadowShort, _shadowShortPeriodTotal[1], i - 1)
                    )
                ) ||
                // ( 3 smaller than 2 && 3 long upper shadow )
                // advance blocked with 3rd candle's long upper shadow and smaller body
                (
                    GetRealBody(i) < GetRealBody(i - 1) &&
                    GetUpperShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal[0], i)
                )
            );
            
        return isAdvanceBlock;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowLong, ShadowShort, Far, Near, BodyLong) + 2;
    }
}
