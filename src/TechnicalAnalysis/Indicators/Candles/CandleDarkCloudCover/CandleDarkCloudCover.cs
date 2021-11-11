using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleDarkCloudCover;

public class CandleDarkCloudCover : CandleIndicator
{
    private double _penetration;
    private double _bodyLongPeriodTotal;

    public CandleDarkCloudCover(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleDarkCloudCoverResult Compute(int startIdx, int endIdx, in double optInPenetration)
    {
        _penetration = optInPenetration;
            
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

        if (optInPenetration < 0.0)
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
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 1);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white candle
         * - second candle: black candle that opens above previous day high and closes within previous day real body; 
         * Greg Morris wants the close to be below the midpoint of the previous real body
         * The meaning of "long" is specified with TA_SetCandleSettings, the penetration of the first real body is specified
         * with optInPenetration
         * outInteger is negative (-1 to -100): dark cloud cover is always bearish
         * the user should consider that a dark cloud cover is significant when it appears in an uptrend, while 
         * this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? -100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 1) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 1);

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
        bool isDarkCloudCover =
            // 1st: white
            GetCandleColor(i - 1) == 1 &&
            // long
            GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 1) &&
            // 2nd: black
            GetCandleColor(i) == -1 &&
            // open above prior high
            _open[i] > _high[i - 1] &&
            // close within prior body
            _close[i] > _open[i - 1] &&
            _close[i] < _close[i - 1] - GetRealBody(i - 1) * _penetration;
            
        return isDarkCloudCover;
    }

    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 1;
    }
}