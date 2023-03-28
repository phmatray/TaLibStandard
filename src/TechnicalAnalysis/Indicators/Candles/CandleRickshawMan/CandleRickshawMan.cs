using System.Numerics;
using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleRickshawMan;

public class CandleRickshawMan<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _bodyDojiPeriodTotal = T.Zero;
    private T _shadowLongPeriodTotal = T.Zero;
    private T _nearPeriodTotal = T.Zero;

    public CandleRickshawMan(in T[] open, in T[] high, in T[] low, in T[] close)
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
        // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (Open == null || High == null || Low == null || Close == null)
        // ReSharper restore ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
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
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

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

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isRickshawMan =
            // doji
            GetRealBody(i) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i) &&
            // long shadow
            GetLowerShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i) &&
            // long shadow
            GetUpperShadow(i) > GetCandleAverage(ShadowLong, _shadowLongPeriodTotal, i) &&
            (
                // body near midpoint
                T.Min(Open[i], Close[i]) <= Low[i] + GetHighLowRange(i) / T.CreateChecked(2) + GetCandleAverage(Near, _nearPeriodTotal, i) &&
                T.Max(Open[i], Close[i]) >= Low[i] + GetHighLowRange(i) / T.CreateChecked(2) - GetCandleAverage(Near, _nearPeriodTotal, i)
            );
            
        return isRickshawMan;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, ShadowLong, Near);
    }
}
