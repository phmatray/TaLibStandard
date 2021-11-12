using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleBreakaway;

public class CandleBreakaway : CandleIndicator
{
    private double _bodyLongPeriodTotal;

    public CandleBreakaway(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleBreakawayResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleBreakawayResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleBreakawayResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleBreakawayResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleBreakawayResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 4);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long black (white)
         * - second candle: black (white) day whose body gaps down (up)
         * - third candle: black or white day with lower (higher) high and lower (higher) low than prior candle's
         * - fourth candle: black (white) day with lower (higher) high and lower (higher) low than prior candle's
         * - fifth candle: white (black) day that closes inside the gap, erasing the prior 3 days
         * The meaning of "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
         * the user should consider that breakaway is significant in a trend opposite to the last candle, while this 
         * function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 4) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

            i++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleBreakawayResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isBreakaway =
            // 1st long
            GetRealBody(index - 4) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, index - 4) &&
            // 1st, 2nd, 4th same color, 5th opposite
            GetCandleColor(index - 4) == GetCandleColor(index - 3) &&
            GetCandleColor(index - 3) == GetCandleColor(index - 1) &&
            GetCandleColor(index - 1) == -GetCandleColor(index) &&
            (
                (
                    // when 1st is black:
                    GetCandleColor(index - 4) == -1 &&
                    // 2nd gaps down
                    GetRealBodyGapDown(index - 3, index - 4) &&
                    // 3rd has lower high and low than 2nd
                    High[index - 2] < High[index - 3] &&
                    Low[index - 2] < Low[index - 3] &&
                    // 4th has lower high and low than 3rd
                    High[index - 1] < High[index - 2] &&
                    Low[index - 1] < Low[index - 2] &&
                    // 5th closes inside the gap
                    Close[index] > Open[index - 3] &&
                    Close[index] < Close[index - 4]
                )
                ||
                (
                    // when 1st is white:
                    GetCandleColor(index - 4) == 1 &&
                    // 2nd gaps up
                    GetRealBodyGapUp(index - 3, index - 4) &&
                    // 3rd has higher high and low than 2nd
                    High[index - 2] > High[index - 3] &&
                    Low[index - 2] > Low[index - 3] &&
                    // 4th has higher high and low than 3rd
                    High[index - 1] > High[index - 2] &&
                    Low[index - 1] > Low[index - 2] &&
                    // 5th closes inside the gap
                    Close[index] < Open[index - 3] &&
                    Close[index] > Close[index - 4]
                )
            );
            
        return isBreakaway;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 4;
    }
}
