// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.CandleHomingPigeon;

public class CandleHomingPigeon<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _bodyLongPeriodTotal = T.Zero;
    private T _bodyShortPeriodTotal = T.Zero;

    public CandleHomingPigeon(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    public CandleHomingPigeonResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleHomingPigeonResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleHomingPigeonResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleHomingPigeonResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleHomingPigeonResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
        int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 1);
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
         * - first candle: long black candle
         * - second candle: short black real body completely inside the previous day's body
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100): homing pigeon is always bullish; 
         * the user should consider that homing pigeon is significant when it appears in a downtrend,
         * while this function does not consider the trend
         */
        int outIdx = 0;
        do
        {
            bool isHomingPigeon = GetPatternRecognition(i);

            outInteger[outIdx++] = isHomingPigeon ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 1) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 1);

            _bodyShortPeriodTotal +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleHomingPigeonResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isHomingPigeon =
            // 1st black
            GetCandleColor(i - 1) == -1 &&
            // 2nd black
            GetCandleColor(i) == -1 &&
            // 1st long
            GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 1) &&
            // 2nd short
            GetRealBody(i) <= GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
            // 2nd engulfed by 1st
            Open[i] < Open[i - 1] &&
            Close[i] > Close[i - 1];
            
        return isHomingPigeon;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 1;
    }
}
