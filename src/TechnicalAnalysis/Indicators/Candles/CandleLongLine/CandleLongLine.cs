using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleLongLine;

public class CandleLongLine : CandleIndicator
{
    private double _bodyPeriodTotal;
    private double _shadowPeriodTotal;

    public CandleLongLine(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleLongLineResult Compute(int startIdx, int endIdx)
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
        int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
        int shadowTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowShort);
            
        int i = bodyTrailingIdx;
        while (i < startIdx)
        {
            _bodyPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = shadowTrailingIdx;
        while (i < startIdx)
        {
            _shadowPeriodTotal += GetCandleRange(ShadowShort, i);
            i++;
        }

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - long real body
         * - short upper and lower shadow
         * The meaning of "long" and "short" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when white (bullish), negative (-1 to -100) when black (bearish)
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal +=
                GetCandleRange(BodyLong, i) -
                GetCandleRange(BodyLong, bodyTrailingIdx);

            _shadowPeriodTotal +=
                GetCandleRange(ShadowShort, i) -
                GetCandleRange(ShadowShort, shadowTrailingIdx);

            i++;
            bodyTrailingIdx++;
            shadowTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isLongLine =
            GetRealBody(i) > GetCandleAverage(BodyLong, _bodyPeriodTotal, i) &&
            GetUpperShadow(i) < GetCandleAverage(ShadowShort, _shadowPeriodTotal, i) &&
            GetLowerShadow(i) < GetCandleAverage(ShadowShort, _shadowPeriodTotal, i);
            
        return isLongLine;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyLong, ShadowShort);
    }
}