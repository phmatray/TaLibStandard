using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleLadderBottom;

public class CandleLadderBottom : CandleIndicator
{
    private double _shadowVeryShortPeriodTotal;

    public CandleLadderBottom(in double[] open, in double[] high, in double[] low, in double[] close)
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
        if (Open == null || High == null || Low == null || Close == null)
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
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 : 0;

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
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isLadderBottom =
            // 3 black candlesticks
            GetCandleColor(index - 4) == -1 &&
            GetCandleColor(index - 3) == -1 &&
            GetCandleColor(index - 2) == -1 &&
            // with consecutively lower opens
            Open[index - 4] > Open[index - 3] &&
            Open[index - 3] > Open[index - 2] &&
            // and closes
            Close[index - 4] > Close[index - 3] &&
            Close[index - 3] > Close[index - 2] &&
            // 4th: black with an upper shadow
            GetCandleColor(index - 1) == -1 &&
            GetUpperShadow(index - 1) > GetCandleAverage(ShadowVeryShort, _shadowVeryShortPeriodTotal, index - 1) &&
            // 5th: white
            GetCandleColor(index) == 1 &&
            // that opens above prior candle's body
            Open[index] > Open[index - 1] &&
            // and closes above prior candle's high
            Close[index] > High[index - 1];
            
        return isLadderBottom;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(ShadowVeryShort) + 4;
    }
}
