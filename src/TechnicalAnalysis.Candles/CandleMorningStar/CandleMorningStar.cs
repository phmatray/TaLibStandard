// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.CandleMorningStar;

public class CandleMorningStar<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _penetration = T.Zero;
    private T _bodyLongPeriodTotal = T.Zero;
    private T _bodyShortPeriodTotal = T.Zero;
    private T _bodyShortPeriodTotal2 = T.Zero;

    public CandleMorningStar(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    public CandleMorningStarResult Compute(int startIdx, int endIdx, in T optInPenetration)
    {
        _penetration = optInPenetration;
            
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleMorningStarResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleMorningStarResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleMorningStarResult(BadParam, outBegIdx, outNBElement, outInteger);
        }

        if (optInPenetration < T.Zero)
        {
            return new CandleMorningStarResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleMorningStarResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
        int bodyShortTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyShort);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx - 2)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = bodyShortTrailingIdx;
        while (i < startIdx - 1)
        {
            _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
            _bodyShortPeriodTotal2 += GetCandleRange(BodyShort, i + 1);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long black real body
         * - second candle: star (Short real body gapping down)
         * - third candle: white real body that moves well within the first candle's real body
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings
         * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
         * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
         * it to be relatively long
         * outInteger is positive (1 to 100): morning star is always bullish; 
         * the user should consider that a morning star is significant when it appears in a downtrend, 
         * while this function does not consider the trend
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
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            _bodyShortPeriodTotal +=
                GetCandleRange(BodyShort, i - 1) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx);

            _bodyShortPeriodTotal2 +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx + 1);

            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleMorningStarResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isMorningStar =
            // 1st: long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // black
            GetCandleColor(i - 2) == -1 &&
            // 2nd: short
            GetRealBody(i - 1) <= GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i - 1) &&
            // gapping down
            GetRealBodyGapDown(i - 1, i - 2) &&
            // 3rd: longer than short
            GetRealBody(i) > GetCandleAverage(BodyShort, _bodyShortPeriodTotal2, i) &&
            // black real body
            GetCandleColor(i) == 1 &&
            // closing well within 1st rb
            Close[i] > Close[i - 2] + GetRealBody(i - 2) * _penetration;
            
        return isMorningStar;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 2;
    }
}