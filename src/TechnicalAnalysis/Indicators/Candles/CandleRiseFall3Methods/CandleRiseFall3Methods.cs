using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleRiseFall3Methods;

public class CandleRiseFall3Methods : CandleIndicator
{
    private readonly double[] _bodyPeriodTotal = new double[5];

    public CandleRiseFall3Methods(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleRiseFall3MethodsResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleRiseFall3MethodsResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleRiseFall3MethodsResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleRiseFall3MethodsResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleRiseFall3MethodsResult(Success, outBegIdx, outNBElement, outInteger);
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
            _bodyPeriodTotal[0] += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white (black) candlestick
         * - then: group of falling (rising) small real body candlesticks (commonly black (white)) that hold within 
         *   the prior long candle's range: ideally they should be three but two or more than three are ok too
         * - final candle: long white (black) candle that opens above (below) the previous small candle's close 
         *   and closes above (below) the first long candle's close
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings; here only patterns with 3 small candles
         * are considered;
         * outInteger is positive (1 to 100) or negative (-1 to -100)
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 * GetCandleColor(i - 4) : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal[4] +=
                GetCandleRange(BodyLong, i - 4) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

            for (int totIdx = 3; totIdx >= 1; --totIdx)
            {
                _bodyPeriodTotal[totIdx] +=
                    GetCandleRange(BodyShort, i - totIdx) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx);
            }

            _bodyPeriodTotal[0] +=
                GetCandleRange(BodyLong, i) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            i++;
            bodyShortTrailingIdx++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleRiseFall3MethodsResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isRiseFall3Methods =
            // 1st long, then 3 small, 5th long
            GetRealBody(index - 4) > GetCandleAverage(BodyLong, _bodyPeriodTotal[4], index - 4) &&
            GetRealBody(index - 3) < GetCandleAverage(BodyShort, _bodyPeriodTotal[3], index - 3) &&
            GetRealBody(index - 2) < GetCandleAverage(BodyShort, _bodyPeriodTotal[2], index - 2) &&
            GetRealBody(index - 1) < GetCandleAverage(BodyShort, _bodyPeriodTotal[1], index - 1) &&
            GetRealBody(index) > GetCandleAverage(BodyLong, _bodyPeriodTotal[0], index) &&
            // white, 3 black, white  ||  black, 3 white, black
            GetCandleColor(index - 4) == -GetCandleColor(index - 3) &&
            GetCandleColor(index - 3) == GetCandleColor(index - 2) &&
            GetCandleColor(index - 2) == GetCandleColor(index - 1) &&
            GetCandleColor(index - 1) == -GetCandleColor(index) &&
            // 2nd to 4th hold within 1st: a part of the real body must be within 1st range
            Min(Open[index - 3], Close[index - 3]) < High[index - 4] &&
            Max(Open[index - 3], Close[index - 3]) > Low[index - 4] &&
            Min(Open[index - 2], Close[index - 2]) < High[index - 4] &&
            Max(Open[index - 2], Close[index - 2]) > Low[index - 4] &&
            Min(Open[index - 1], Close[index - 1]) < High[index - 4] &&
            Max(Open[index - 1], Close[index - 1]) > Low[index - 4] &&
            // 2nd to 4th are falling (rising)
            Close[index - 2] * GetCandleColor(index - 4) < Close[index - 3] * GetCandleColor(index - 4) &&
            Close[index - 1] * GetCandleColor(index - 4) < Close[index - 2] * GetCandleColor(index - 4) &&
            // 5th opens above (below) the prior close
            Open[index] * GetCandleColor(index - 4) > Close[index - 1] * GetCandleColor(index - 4) &&
            // 5th closes above (below) the 1st close
            Close[index] * GetCandleColor(index - 4) > Close[index - 4] * GetCandleColor(index - 4);
            
        return isRiseFall3Methods;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 4;
    }
}
