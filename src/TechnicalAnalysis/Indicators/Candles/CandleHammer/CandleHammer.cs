using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleHammer;

public class CandleHammer : CandleIndicator
{
    private double _bodyPeriodTotal;
    private double _shadowLongPeriodTotal;
    private double _shadowVeryShortPeriodTotal;
    private double _nearPeriodTotal;

    public CandleHammer(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleHammerResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleHammerResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleHammerResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleHammerResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleHammerResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
        int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
        int nearTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(Near);
            
        int i = bodyTrailingIdx;
        while (i < startIdx)
        {
            _bodyPeriodTotal += GetCandleRange(BodyShort, i);
            i++;
        }

        i = shadowLongTrailingIdx;
        while (i < startIdx)
        {
            _shadowLongPeriodTotal += GetCandleRange(ShadowLong, i);
            i++;
        }

        i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i);
            i++;
        }

        i = nearTrailingIdx;
        while (i < startIdx - 1)
        {
            _nearPeriodTotal += GetCandleRange(Near, i);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - small real body
         * - long lower shadow
         * - no, or very short, upper shadow
         * - body below or near the lows of the previous candle
         * The meaning of "short", "long" and "near the lows" is specified with TA_SetCandleSettings;
         * outInteger is positive (1 to 100): hammer is always bullish;
         * the user should consider that a hammer must appear in a downtrend, while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyTrailingIdx);

            _shadowLongPeriodTotal +=
                GetCandleRange(ShadowLong, i) -
                GetCandleRange(ShadowLong, shadowLongTrailingIdx);

            _shadowVeryShortPeriodTotal +=
                GetCandleRange(ShadowVeryShort, i) -
                GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx);

            _nearPeriodTotal +=
                GetCandleRange(Near, i - 1) -
                GetCandleRange(Near, nearTrailingIdx);

            i++;
            bodyTrailingIdx++;
            shadowLongTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            nearTrailingIdx++;
        } while (i <= endIdx);
            
        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleHammerResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isHammer =
            // small rb
            GetRealBody(index) < GetCandleAverage(BodyShort, _bodyPeriodTotal, index) &&
            // long lower shadow
            GetLowerShadow(index) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, index) &&
            // very short upper shadow
            GetUpperShadow(index) < GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, index) &&
            // rb near the prior candle's lows
            Min(Close[index], Open[index]) <= Low[index - 1] + GetCandleAverage(Near, _nearPeriodTotal, index - 1);
            
        return isHammer;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, ShadowLong, ShadowVeryShort, Near) + 1;
    }
}
