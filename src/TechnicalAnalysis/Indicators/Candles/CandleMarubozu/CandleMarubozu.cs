using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleMarubozu;

public class CandleMarubozu : CandleIndicator
{
    private double _bodyLongPeriodTotal;
    private double _shadowVeryShortPeriodTotal;

    public CandleMarubozu(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleMarubozuResult Compute(int startIdx, int endIdx)
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
         * - long real body
         * - no or very short upper and lower shadow
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
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isMarubozu =
            GetRealBody(i) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i) &&
            GetUpperShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i) &&
            GetLowerShadow(i) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i);
            
        return isMarubozu;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyLong, ShadowVeryShort);
    }
}