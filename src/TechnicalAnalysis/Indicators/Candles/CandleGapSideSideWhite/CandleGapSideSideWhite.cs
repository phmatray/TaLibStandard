using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleGapSideSideWhite;

public class CandleGapSideSideWhite : CandleIndicator
{
    private double _nearPeriodTotal;
    private double _equalPeriodTotal;

    public CandleGapSideSideWhite(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleGapSideSideWhiteResult Compute(int startIdx, int endIdx)
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
        if (Open == null || High == null || Low == null || Close == null)
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
        int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
        int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
        int i = nearTrailingIdx;
        while (i < startIdx)
        {
            _nearPeriodTotal += GetCandleRange(Near, i - 1);
            i++;
        }

        i = equalTrailingIdx;
        while (i < startIdx)
        {
            _equalPeriodTotal += GetCandleRange(Equal, i - 1);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - upside or downside gap (between the bodies)
         * - first candle after the window: white candlestick
         * - second candle after the window: white candlestick with similar size (near the same) and about the same 
         *   open (equal) of the previous candle
         * - the second candle does not close the window
         * The meaning of "near" and "equal" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) or negative (-1 to -100): the user should consider that upside 
         * or downside gap side-by-side white lines is significant when it appears in a trend, while this function 
         * does not consider the trend
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i)
                ? GetRealBodyGapUp(i - 1, i - 2) ? 100 : -100
                : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _nearPeriodTotal +=
                GetCandleRange(Near, i - 1) -
                GetCandleRange(Near, nearTrailingIdx - 1);

            _equalPeriodTotal +=
                GetCandleRange(Equal, i - 1) -
                GetCandleRange(Equal, equalTrailingIdx - 1);

            i++;
            nearTrailingIdx++;
            equalTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isGapSideSideWhite =
            ( // upside or downside gap between the 1st candle and both the next 2 candles
                (
                    GetRealBodyGapUp(i - 1, i - 2) &&
                    GetRealBodyGapUp(i, i - 2)
                )
                ||
                (
                    GetRealBodyGapDown(i - 1, i - 2) &&
                    GetRealBodyGapDown(i, i - 2)
                )
            ) &&
            // 2nd: white
            GetCandleColor(i - 1) == 1 &&
            // 3rd: white
            GetCandleColor(i) == 1 &&
            // same size 2 and 3
            GetRealBody(i) >= GetRealBody(i - 1) -
            GetCandleAverage(Near, _nearPeriodTotal, i - 1) &&
            GetRealBody(i) <= GetRealBody(i - 1) +
            GetCandleAverage(Near, _nearPeriodTotal, i - 1) &&
            // same open 2 and 3
            Open[i] >= Open[i - 1] -
            GetCandleAverage(Equal, _equalPeriodTotal, i - 1) &&
            Open[i] <= Open[i - 1] +
            GetCandleAverage(Equal, _equalPeriodTotal, i - 1);
            
        return isGapSideSideWhite;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(Near, Equal) + 2;
    }
}