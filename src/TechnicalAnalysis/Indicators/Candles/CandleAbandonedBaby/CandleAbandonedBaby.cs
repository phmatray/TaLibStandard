using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleAbandonedBaby;

public class CandleAbandonedBaby : CandleIndicator
{
    private double _bodyLongPeriodTotal;
    private double _bodyDojiPeriodTotal;
    private double _bodyShortPeriodTotal;
    private double _penetration;

    public CandleAbandonedBaby(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleAbandonedBabyResult Compute(int startIdx, int endIdx, in double optInPenetration)
    {
        _penetration = optInPenetration;
            
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleAbandonedBabyResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleAbandonedBabyResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleAbandonedBabyResult(BadParam, outBegIdx, outNBElement, outInteger);
        }

        if (optInPenetration < 0.0)
        {
            return new CandleAbandonedBabyResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleAbandonedBabyResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
        int bodyDojiTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyDoji);
        int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx - 2)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = bodyDojiTrailingIdx;
        while (i < startIdx - 1)
        {
            _bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
            i++;
        }

        i = bodyShortTrailingIdx;
        while (i < startIdx)
        {
            _bodyShortPeriodTotal += GetCandleRange(BodyShort, i);
            i++;
        }

        i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white (black) real body
         * - second candle: doji
         * - third candle: black (white) real body that moves well within the first candle's real body
         * - upside (downside) gap between the first candle and the doji (the shadows of the two candles don't touch)
         * - downside (upside) gap between the doji and the third candle (the shadows of the two candles don't touch)
         * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
         * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
         * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
         * it to be relatively long
         * outInteger is positive (1 to 100) when it's an abandoned baby bottom or negative (-1 to -100) when it's 
         * an abandoned baby top; the user should consider that an abandoned baby is significant when it appears in 
         * an uptrend or downtrend, while this function does not consider the trend
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? GetCandleColor(i) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 2) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            _bodyDojiPeriodTotal +=
                GetCandleRange(BodyDoji, i - 1) -
                GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

            _bodyShortPeriodTotal +=
                GetCandleRange(BodyShort, i) -
                GetCandleRange(BodyShort, bodyShortTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
            bodyDojiTrailingIdx++;
            bodyShortTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleAbandonedBabyResult(Success, outBegIdx, outNBElement, outInteger);
    }

    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isAbandonedBaby =
            // 1st: long
            GetRealBody(index - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, index - 2) &&
            // 2nd: doji
            GetRealBody(index - 1) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, index - 1) &&
            // 3rd: longer than short
            GetRealBody(index) > GetCandleAverage(BodyShort, _bodyShortPeriodTotal, index) &&
            (
                (
                    // 1st white
                    GetCandleColor(index - 2) == 1 &&
                    // 3rd black
                    GetCandleColor(index) == -1 &&
                    // 3rd closes well within 1st rb
                    Close[index] < Close[index - 2] - GetRealBody(index - 2) * _penetration &&
                    // upside gap between 1st and 2nd
                    GetCandleGapUp(index - 1, index - 2) &&
                    // downside gap between 2nd and 3rd
                    GetCandleGapDown(index, index - 1)
                )
                ||
                (
                    // 1st black
                    GetCandleColor(index - 2) == -1 &&
                    // 3rd white
                    GetCandleColor(index) == 1 &&
                    // 3rd closes well within 1st rb
                    Close[index] > Close[index - 2] + GetRealBody(index - 2) * _penetration &&
                    // downside gap between 1st and 2nd
                    GetCandleGapDown(index - 1, index - 2) &&
                    // upside gap between 2nd and 3rd
                    GetCandleGapUp(index, index - 1)
                )
            );
            
        return isAbandonedBaby;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, BodyLong, BodyShort) + 2;
    }
}
