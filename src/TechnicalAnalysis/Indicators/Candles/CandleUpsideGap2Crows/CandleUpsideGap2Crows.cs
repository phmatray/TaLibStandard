using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleUpsideGap2Crows;

public class CandleUpsideGap2Crows : CandleIndicator
{
    private double _bodyLongPeriodTotal;
    private double _bodyShortPeriodTotal;

    public CandleUpsideGap2Crows(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleUpsideGap2CrowsResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleUpsideGap2CrowsResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleUpsideGap2CrowsResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleUpsideGap2CrowsResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleUpsideGap2CrowsResult(Success, outBegIdx, outNBElement, outInteger);
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
         * - first candle: white candle, usually long
         * - second candle: small black real body
         * - gap between the first and the second candle's real bodies
         * - third candle: black candle with a real body that engulfs the preceding candle 
         *   and closes above the white candle's close
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings
         * outInteger is negative (-1 to -100): upside gap two crows is always bearish; 
         * the user should consider that an upside gap two crows is significant when it appears in an uptrend, 
         * while this function does not consider the trend
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
            
        return new CandleUpsideGap2CrowsResult(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isUpsideGap2Crows =
            // 1st: white
            GetCandleColor(i - 2) == 1 &&
            // long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // 2nd: black
            GetCandleColor(i - 1) == -1 &&
            // short
            GetRealBody(i - 1) <= GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i - 1) &&
            // gapping up
            GetRealBodyGapUp(i - 1, i - 2) &&
            // 3rd: black
            GetCandleColor(i) == -1 &&
            // 3rd: engulfing prior rb
            Open[i] > Open[i - 1] && Close[i] < Close[i - 1] &&
            // closing above 1st
            Close[i] > Close[i - 2];
            
        return isUpsideGap2Crows;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 2;
    }
}