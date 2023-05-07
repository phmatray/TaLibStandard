// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.CandleClosingMarubozu;

public class CandleClosingMarubozu<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _bodyLongPeriodTotal = T.Zero;
    private T _shadowVeryShortPeriodTotal = T.Zero;

    public CandleClosingMarubozu(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    public CandleClosingMarubozuResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleClosingMarubozuResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleClosingMarubozuResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleClosingMarubozuResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleClosingMarubozuResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i);
            i++;
        }

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - long white (black) real body
         * - no or very short upper (lower) shadow
         * The meaning of "long" and "very short" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when white (bullish), negative (-1 to -100) when black (bearish)
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            _shadowVeryShortPeriodTotal +=
                GetCandleRange(ShadowVeryShort, i) -
                GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
            shadowVeryShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleClosingMarubozuResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isClosingMarubozu =
            // long body
            GetRealBody(i) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i) &&
            (
                ( // white body and very short lower shadow
                    GetCandleColor(i) == 1 &&
                    GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i)
                ) ||
                ( // black body and very short upper shadow
                    GetCandleColor(i) == -1 &&
                    GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i)
                )
            );
            
        return isClosingMarubozu;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyLong, ShadowVeryShort);
    }
}
