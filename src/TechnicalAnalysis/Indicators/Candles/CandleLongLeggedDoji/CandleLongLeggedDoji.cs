using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleLongLeggedDoji;

public class CandleLongLeggedDoji : CandleIndicator
{
    private double _bodyDojiPeriodTotal;
    private double _shadowLongPeriodTotal;

    public CandleLongLeggedDoji(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleLongLeggedDojiResult Compute(int startIdx, int endIdx)
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
        int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
        int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            
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

        /* Proceed with the calculation for the requested range.
         *
         * Must have:
         * - doji body
         * - one or two long shadows
         * The meaning of "doji" is specified with TA_SetCandleSettings
         * outInteger is always positive (1 to 100) but this does not mean it is bullish: long legged doji shows uncertainty
         */
        int outIdx = 0;
        do
        {
            bool isLongLeggedDoji = GetPatternRecognition(i);

            outInteger[outIdx++] = isLongLeggedDoji ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyDojiPeriodTotal +=
                GetCandleRange(BodyDoji, i) -
                GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

            _shadowLongPeriodTotal +=
                GetCandleRange(ShadowLong, i) -
                GetCandleRange(ShadowLong, shadowLongTrailingIdx);

            i++;
            bodyDojiTrailingIdx++;
            shadowLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isLongLeggedDoji =
            GetRealBody(i) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i) &&
            (
                GetLowerShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i) ||
                GetUpperShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i)
            );
            
        return isLongLeggedDoji;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, ShadowLong);
    }
}