using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleMatHold;

public class CandleMatHold : CandleIndicator
{
    private readonly double[] _bodyPeriodTotal = new double[5];
    private double _penetration;

    public CandleMatHold(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleMatHoldResult Compute(int startIdx, int endIdx, in double optInPenetration)
    {
        _penetration = optInPenetration;
            
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleMatHoldResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleMatHoldResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleMatHoldResult(BadParam, outBegIdx, outNBElement, outInteger);
        }

        if (optInPenetration < 0.0)
        {
            return new CandleMatHoldResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleMatHoldResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = bodyShortTrailingIdx;
        while (i < startIdx)
        {
            _bodyPeriodTotal[3] += GetCandleRange(BodyShort, i - 3);
            _bodyPeriodTotal[2] += GetCandleRange(BodyShort, i - 2);
            _bodyPeriodTotal[1] += GetCandleRange(BodyShort, i - 1);
            i++;
        }

        i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyPeriodTotal[4] += GetCandleRange(BodyLong, i - 4);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white candle
         * - upside gap between the first and the second bodies
         * - second candle: small black candle
         * - third and fourth candles: falling small real body candlesticks (commonly black) that hold within the long 
         *   white candle's body and are higher than the reaction days of the rising three methods
         * - fifth candle: white candle that opens above the previous small candle's close and closes higher than the 
         *   high of the highest reaction day
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings; 
         * "hold within" means "a part of the real body must be within";
         * optInPenetration is the maximum percentage of the first white body the reaction days can penetrate (it is 
         * to specify how much the reaction days should be "higher than the reaction days of the rising three methods")
         * outInteger is positive (1 to 100): mat hold is always bullish
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal[4] +=
                GetCandleRange(BodyLong, i - 4) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

            int totIdx;
            for (totIdx = 3; totIdx >= 1; --totIdx)
            {
                _bodyPeriodTotal[totIdx] +=
                    GetCandleRange(BodyShort, i - totIdx) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx);
            }

            i++;
            bodyShortTrailingIdx++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleMatHoldResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isMatHold =
            // 1st long, then 3 small
            GetRealBody(index - 4) > GetCandleAverage(BodyLong, _bodyPeriodTotal[4], index - 4) &&
            GetRealBody(index - 3) < GetCandleAverage(BodyShort, _bodyPeriodTotal[3], index - 3) &&
            GetRealBody(index - 2) < GetCandleAverage(BodyShort, _bodyPeriodTotal[2], index - 2) &&
            GetRealBody(index - 1) < GetCandleAverage(BodyShort, _bodyPeriodTotal[1], index - 1) &&
            // white, black, 2 black or white, white
            GetCandleColor(index - 4) == 1 &&
            GetCandleColor(index - 3) == -1 &&
            GetCandleColor(index) == 1 &&
            // upside gap 1st to 2nd
            GetRealBodyGapUp(index - 3, index - 4) &&
            // 3rd to 4th hold within 1st: a part of the real body must be within 1st real body
            Min(Open[index - 2], Close[index - 2]) < Close[index - 4] &&
            Min(Open[index - 1], Close[index - 1]) < Close[index - 4] &&
            // reaction days penetrate first body less than optInPenetration percent
            Min(Open[index - 2], Close[index - 2]) > Close[index - 4] - GetRealBody(index - 4) * _penetration &&
            Min(Open[index - 1], Close[index - 1]) > Close[index - 4] - GetRealBody(index - 4) * _penetration &&
            // 2nd to 4th are falling
            Max(Close[index - 2], Open[index - 2]) < Open[index - 3] &&
            Max(Close[index - 1], Open[index - 1]) < Max(Close[index - 2], Open[index - 2]) &&
            // 5th opens above the prior close
            Open[index] > Close[index - 1] &&
            // 5th closes above the highest high of the reaction days
            Close[index] > Max(Max(High[index - 3], High[index - 2]), High[index - 1]);
            
        return isMatHold;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 4;
    }
}
