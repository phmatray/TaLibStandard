using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.Candle2Crows;

public class Candle2Crows : CandleIndicator
{
    private double _bodyLongPeriodTotal;

    public Candle2Crows(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public Candle2CrowsResult Compute(int startIdx, int endIdx)
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
        int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);

        int i = bodyLongTrailingIdx;
        while (i < startIdx - 2)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white candle
         * - second candle: black real body
         * - gap between the first and the second candle's real bodies
         * - third candle: black candle that opens within the second real body and closes within the first real body
         * The meaning of "long" is specified with TA_SetCandleSettings
         * outInteger is negative (-1 to -100): two crows is always bearish; 
         * the user should consider that two crows is significant when it appears in an uptrend, while this function 
         * does not consider the trend
         */

        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? -100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 2) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;

        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool is2Crows =
            // 1st: white
            GetCandleColor(i - 2) == 1 &&
            // long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // 2nd: black
            GetCandleColor(i - 1) == -1 &&
            // gapping up
            GetRealBodyGapUp(i - 1, i - 2) &&
            // 3rd: black
            GetCandleColor(i) == -1 &&
            // opening within 2nd rb
            _open[i] < _open[i - 1] && _open[i] > _close[i - 1] &&
            // closing within 1st rb
            _close[i] > _open[i - 2] && _close[i] < _close[i - 2];

        return is2Crows;
    }

    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 2;
    }
}
