using System.Numerics;
using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleLadderBottom;

public class CandleLadderBottom<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _shadowVeryShortPeriodTotal = T.Zero;

    public CandleLadderBottom(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    public CandleLadderBottomResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleLadderBottomResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleLadderBottomResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (Open == null || High == null || Low == null || Close == null)
        // ReSharper restore ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        {
            return new CandleLadderBottomResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleLadderBottomResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
        int i = shadowVeryShortTrailingIdx;
        while (i < startIdx)
        {
            _shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - three black candlesticks with consecutively lower opens and closes
         * - fourth candle: black candle with an upper shadow (it's supposed to be not very short)
         * - fifth candle: white candle that opens above prior candle's body and closes above prior candle's high
         * The meaning of "very short" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100): ladder bottom is always bullish; 
         * the user should consider that ladder bottom is significant when it appears in a downtrend, 
         * while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _shadowVeryShortPeriodTotal +=
                GetCandleRange(ShadowVeryShort, i - 1) -
                GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - 1);

            i++;
            shadowVeryShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleLadderBottomResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isLadderBottom =
            // 3 black candlesticks
            GetCandleColor(i - 4) == -1 &&
            GetCandleColor(i - 3) == -1 &&
            GetCandleColor(i - 2) == -1 &&
            // with consecutively lower opens
            Open[i - 4] > Open[i - 3] &&
            Open[i - 3] > Open[i - 2] &&
            // and closes
            Close[i - 4] > Close[i - 3] &&
            Close[i - 3] > Close[i - 2] &&
            // 4th: black with an upper shadow
            GetCandleColor(i - 1) == -1 &&
            GetUpperShadow(i - 1) > GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, i - 1) &&
            // 5th: white
            GetCandleColor(i) == 1 &&
            // that opens above prior candle's body
            Open[i] > Open[i - 1] &&
            // and closes above prior candle's high
            Close[i] > High[i - 1];
            
        return isLadderBottom;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(ShadowVeryShort) + 4;
    }
}
