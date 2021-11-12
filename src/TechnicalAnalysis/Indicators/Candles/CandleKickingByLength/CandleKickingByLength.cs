using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleKickingByLength;

public class CandleKickingByLength : CandleIndicator
{
    private readonly double[] _shadowVeryShortPeriodTotal = new double[2];
    private readonly double[] _bodyLongPeriodTotal = new double[2];

    public CandleKickingByLength(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleKickingByLengthResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleKickingByLengthResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleKickingByLengthResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleKickingByLengthResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleKickingByLengthResult(Success, outBegIdx, outNBElement, outInteger);
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
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; the longer of the two
         * marubozu determines the bullishness or bearishness of this pattern
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i)
                ? GetCandleColor((GetRealBody(i) > GetRealBody(i - 1) ? i : i - 1)) * 100
                : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 1; totIdx >= 0; --totIdx)
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
            
        return new CandleKickingByLengthResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isKickingByLength =
            // opposite candles
            GetCandleColor(index - 1) == -GetCandleColor(index) &&
            // 1st marubozu
            GetRealBody(index - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[1], index - 1) &&
            GetUpperShadow(index - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], index - 1) &&
            GetLowerShadow(index - 1) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], index - 1) &&
            // 2nd marubozu
            GetRealBody(index) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[0], index) &&
            GetUpperShadow(index) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], index) &&
            GetLowerShadow(index) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], index) &&
            // gap
            (
                (GetCandleColor(index - 1) == -1 && GetCandleGapUp(index, index - 1)) ||
                (GetCandleColor(index - 1) == 1 && GetCandleGapDown(index, index - 1))
            );
            
        return isKickingByLength;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, BodyLong) + 1;
    }
}
