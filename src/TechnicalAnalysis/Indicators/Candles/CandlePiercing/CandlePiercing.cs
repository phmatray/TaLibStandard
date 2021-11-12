using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandlePiercing;

public class CandlePiercing : CandleIndicator
{
    private readonly double[] _bodyLongPeriodTotal = new double[2];

    public CandlePiercing(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandlePiercingResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandlePiercingResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandlePiercingResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandlePiercingResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandlePiercingResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
            _bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long black candle
         * - second candle: long white candle with open below previous day low and close at least at 50% of previous day 
         * real body
         * The meaning of "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100): piercing pattern is always bullish
         * the user should consider that a piercing pattern is significant when it appears in a downtrend, while 
         * this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 1; totIdx >= 0; --totIdx)
            {
                _bodyLongPeriodTotal[totIdx] +=
                    GetCandleRange(BodyLong, i - totIdx) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);
            }

            i++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandlePiercingResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isPiercing =
            // 1st: black
            GetCandleColor(index - 1) == -1 &&
            // long
            GetRealBody(index - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[1], index - 1) &&
            // 2nd: white
            GetCandleColor(index) == 1 &&
            // long
            GetRealBody(index) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[0], index) &&
            // open below prior low
            Open[index] < Low[index - 1] &&
            // close within prior body
            Close[index] < Open[index - 1] &&
            // above midpoint
            Close[index] > Close[index - 1] + GetRealBody(index - 1) * 0.5;
            
        return isPiercing;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 1;
    }
}
