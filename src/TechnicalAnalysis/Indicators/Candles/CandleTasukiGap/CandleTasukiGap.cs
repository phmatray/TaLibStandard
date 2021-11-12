using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleTasukiGap;

public class CandleTasukiGap : CandleIndicator
{
    private double _nearPeriodTotal;

    public CandleTasukiGap(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleTasukiGapResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleTasukiGapResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleTasukiGapResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleTasukiGapResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleTasukiGapResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
        int i = nearTrailingIdx;
        while (i < startIdx)
        {
            _nearPeriodTotal += GetCandleRange(Near, i - 1);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - upside (downside) gap
         * - first candle after the window: white (black) candlestick
         * - second candle: black (white) candlestick that opens within the previous real body and closes under (above)
         *   the previous real body inside the gap
         * - the size of two real bodies should be near the same
         * The meaning of "near" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
         * the user should consider that tasuki gap is significant when it appears in a trend, while this function does 
         * not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? GetCandleColor(i - 1) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _nearPeriodTotal +=
                GetCandleRange(Near, i - 1) -
                GetCandleRange(Near, nearTrailingIdx - 1);

            i++;
            nearTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleTasukiGapResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isTasukiGap =
            (
                // upside gap
                GetRealBodyGapUp(index - 1, index - 2) &&
                // 1st: white
                GetCandleColor(index - 1) == 1 &&
                // 2nd: black
                GetCandleColor(index) == -1 &&
                // that opens within the white rb
                Open[index] < Close[index - 1] && Open[index] > Open[index - 1] &&
                // and closes under the white rb
                Close[index] < Open[index - 1] &&
                // inside the gap
                Close[index] > Max(Close[index - 2], Open[index - 2]) &&
                // size of 2 rb near the same
                Abs(GetRealBody(index - 1) - GetRealBody(index)) < GetCandleAverage(Near, _nearPeriodTotal, index - 1)
            ) ||
            (
                // downside gap
                GetRealBodyGapDown(index - 1, index - 2) &&
                // 1st: black
                GetCandleColor(index - 1) == -1 &&
                // 2nd: white
                GetCandleColor(index) == 1 &&
                // that opens within the black rb
                Open[index] < Open[index - 1] && Open[index] > Close[index - 1] &&
                // and closes above the black rb
                Close[index] > Open[index - 1] &&
                // inside the gap
                Close[index] < Min(Close[index - 2], Open[index - 2]) &&
                // size of 2 rb near the same
                Abs(GetRealBody(index - 1) - GetRealBody(index)) < GetCandleAverage(Near, _nearPeriodTotal, index - 1)
            );
            
        return isTasukiGap;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(Near) + 2;
    }
}
