using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.Candle3StarsInSouth;

public class Candle3StarsInSouth : CandleIndicator
{
    private readonly double[] _shadowVeryShortPeriodTotal = new double[2];
    private double _bodyLongPeriodTotal;
    private double _shadowLongPeriodTotal;
    private double _bodyShortPeriodTotal;

    public Candle3StarsInSouth(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public Candle3StarsInSouthResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (_open == null || _high == null || _low == null || _close == null)
        {
            return new(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new(Success, outBegIdx, outNBElement, outInteger);
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
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool is3StarsInSouth =
            // 1st black
            GetCandleColor(i - 2) == -1 &&
            // 2nd black
            GetCandleColor(i - 1) == -1 &&
            // 3rd black
            GetCandleColor(i) == -1 &&
            // 1st: long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // with long lower shadow
            GetLowerShadow(i - 2) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i - 2) &&
            // 2nd: smaller candle
            GetRealBody(i - 1) < GetRealBody(i - 2) &&
            // that opens higher but within 1st range
            _open[i - 1] > _close[i - 2] &&
            _open[i - 1] <= _high[i - 2] &&
            // and trades lower than 1st close
            _low[i - 1] < _close[i - 2] &&
            // but not lower than 1st low
            _low[i - 1] >= _low[i - 2] &&
            // and has a lower shadow
            GetLowerShadow(i - 1) > GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[1], i - 1) &&
            // 3rd: small marubozu
            GetRealBody(i) < GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
            GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal[0], i) &&
            // engulfed by prior candle's range
            _low[i] > _low[i - 1] && _high[i] < _high[i - 1];
            
        return is3StarsInSouth;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(ShadowVeryShort, ShadowLong, BodyLong, BodyShort) + 2;
    }
}
