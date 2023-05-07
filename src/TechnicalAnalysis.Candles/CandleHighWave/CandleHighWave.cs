// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.CandleHighWave;

public class CandleHighWave<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _bodyPeriodTotal = T.Zero;
    private T _shadowPeriodTotal = T.Zero;

    public CandleHighWave(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    public CandleHighWaveResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleHighWaveResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleHighWaveResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleHighWaveResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleHighWaveResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
        int shadowTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryLong);
            
        int i = bodyTrailingIdx;
        while (i < startIdx)
        {
            _bodyPeriodTotal += GetCandleRange(BodyShort, i);
            i++;
        }

        i = shadowTrailingIdx;
        while (i < startIdx)
        {
            _shadowPeriodTotal += GetCandleRange(ShadowVeryLong, i);
            i++;
        }

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - short real body
         * - very long upper and lower shadow
         * The meaning of "short" and "very long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when white or negative (-1 to -100) when black;
         * it does not mean bullish or bearish
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyTrailingIdx);

            _shadowPeriodTotal +=
                GetCandleRange(ShadowVeryLong, i) -
                GetCandleRange(ShadowVeryLong, shadowTrailingIdx);

            i++;
            bodyTrailingIdx++;
            shadowTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleHighWaveResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isHighWave =
            GetRealBody(i) < GetCandleAverage(BodyShort, _bodyPeriodTotal, i) &&
            GetUpperShadow(i) > GetCandleAverage(ShadowVeryLong, _shadowPeriodTotal, i) &&
            GetLowerShadow(i) > GetCandleAverage(ShadowVeryLong, _shadowPeriodTotal, i);
            
        return isHighWave;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, ShadowVeryLong);
    }
}
