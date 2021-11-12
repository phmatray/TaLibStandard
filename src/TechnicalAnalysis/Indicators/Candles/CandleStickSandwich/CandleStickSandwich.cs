using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleStickSandwich;

public class CandleStickSandwich : CandleIndicator
{
    private double _equalPeriodTotal;

    public CandleStickSandwich(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleStickSandwichResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleStickSandwichResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleStickSandwichResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleStickSandwichResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleStickSandwichResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
        int i = equalTrailingIdx;
        while (i < startIdx)
        {
            _equalPeriodTotal += GetCandleRange(Equal, i - 2);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: black candle
         * - second candle: white candle that trades only above the prior close (low > prior close)
         * - third candle: black candle with the close equal to the first candle's close
         * The meaning of "equal" is specified with TA_SetCandleSettings
         * outInteger is always positive (1 to 100): stick sandwich is always bullish;
         * the user should consider that stick sandwich is significant when coming in a downtrend, 
         * while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _equalPeriodTotal +=
                GetCandleRange(Equal, i - 2) -
                GetCandleRange(Equal, equalTrailingIdx - 2);

            i++;
            equalTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleStickSandwichResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isStickSandwich =
            // first black
            GetCandleColor(index - 2) == -1 &&
            // second white
            GetCandleColor(index - 1) == 1 &&
            // third black
            GetCandleColor(index) == -1 &&
            // 2nd low > prior close
            Low[index - 1] > Close[index - 2] &&
            // 1st and 3rd same close
            Close[index] <= Close[index - 2] + GetCandleAverage(Equal, _equalPeriodTotal, index - 2) &&
            Close[index] >= Close[index - 2] - GetCandleAverage(Equal, _equalPeriodTotal, index - 2);
            
        return isStickSandwich;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(Equal) + 2;
    }
}
