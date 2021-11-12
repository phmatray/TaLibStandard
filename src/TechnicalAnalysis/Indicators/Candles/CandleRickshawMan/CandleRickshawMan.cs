using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleRickshawMan;

public class CandleRickshawMan : CandleIndicator
{
    private double _bodyDojiPeriodTotal;
    private double _shadowLongPeriodTotal;
    private double _nearPeriodTotal;

    public CandleRickshawMan(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleRickshawManResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleRickshawManResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleRickshawManResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleRickshawManResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleRickshawManResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
        int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
        int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
        int i = bodyDojiTrailingIdx;
        while (i < startIdx)
        {
            _bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
            i++;
        }

        i = shadowLongTrailingIdx;
        while (i < startIdx)
        {
            _shadowLongPeriodTotal += GetCandleRange(ShadowLong, i);
            i++;
        }

        i = nearTrailingIdx;
        while (i < startIdx)
        {
            _nearPeriodTotal += GetCandleRange(Near, i);
            i++;
        }

        /* Proceed with the calculation for the requested range.
         *
         * Must have:
         * - doji body
         * - two long shadows
         * - body near the midpoint of the high-low range
         * The meaning of "doji" and "near" is specified with TA_SetCandleSettings
         * outInteger is always positive (1 to 100) but this does not mean it is bullish: rickshaw man shows uncertainty
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyDojiPeriodTotal +=
                GetCandleRange(BodyDoji, i) -
                GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

            _shadowLongPeriodTotal +=
                GetCandleRange(ShadowLong, i) -
                GetCandleRange(ShadowLong, shadowLongTrailingIdx);

            _nearPeriodTotal +=
                GetCandleRange(Near, i) -
                GetCandleRange(Near, nearTrailingIdx);

            i++;
            bodyDojiTrailingIdx++;
            shadowLongTrailingIdx++;
            nearTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleRickshawManResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isRickshawMan =
            // doji
            GetRealBody(index) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, index) &&
            // long shadow
            GetLowerShadow(index) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, index) &&
            // long shadow
            GetUpperShadow(index) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, index) &&
            (
                // body near midpoint
                Min(Open[index], Close[index]) <= Low[index] + GetHighLowRange(index) / 2 + GetCandleAverage(Near, _nearPeriodTotal, index) &&
                Max(Open[index], Close[index]) >= Low[index] + GetHighLowRange(index) / 2 - GetCandleAverage(Near, _nearPeriodTotal, index)
            );
            
        return isRickshawMan;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, ShadowLong, Near);
    }
}
