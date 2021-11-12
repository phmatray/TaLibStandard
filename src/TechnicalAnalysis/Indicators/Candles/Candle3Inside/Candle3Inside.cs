using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.Candle3Inside;

public class Candle3Inside : CandleIndicator
{
    private double _bodyLongPeriodTotal;
    private double _bodyShortPeriodTotal;

    public Candle3Inside(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public Candle3InsideResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new Candle3InsideResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new Candle3InsideResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new Candle3InsideResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new Candle3InsideResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
        int bodyShortTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyShort);

        int i = bodyLongTrailingIdx;
        while (i < startIdx - 2)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = bodyShortTrailingIdx;
        while (i < startIdx - 1)
        {
            _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white (black) real body
         * - second candle: short real body totally engulfed by the first
         * - third candle: black (white) candle that closes lower (higher) than the first candle's open
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) for the three inside up or negative (-1 to -100) for the three inside down; 
         * the user should consider that a three inside up is significant when it appears in a downtrend and a three inside
         * down is significant when it appears in an uptrend, while this function does not consider the trend
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i)
                ? -GetCandleColor(i - 2) * 100
                : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 2) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            _bodyShortPeriodTotal +=
                GetCandleRange(BodyShort, i - 1) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;

        return new Candle3InsideResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool is3Inside =
            // 1st: long
            GetRealBody(index - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, index - 2) &&
            // 2nd: short
            GetRealBody(index - 1) <= GetCandleAverage(BodyShort, _bodyShortPeriodTotal, index - 1) &&
            // engulfed by 1st
            Max(Close[index - 1], Open[index - 1]) < Max(Close[index - 2], Open[index - 2]) &&
            Min(Close[index - 1], Open[index - 1]) > Min(Close[index - 2], Open[index - 2]) &&
            (
                ( // 3rd: opposite to 1st
                    GetCandleColor(index - 2) == 1 &&
                    GetCandleColor(index) == -1 &&
                    Close[index] < Open[index - 2]
                ) ||
                ( // and closing out
                    GetCandleColor(index - 2) == -1 &&
                    GetCandleColor(index) == 1 &&
                    Close[index] > Open[index - 2]
                )
            );

        return is3Inside;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 2;
    }
}
