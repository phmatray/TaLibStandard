using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleEveningDojiStar;

public class CandleEveningDojiStar : CandleIndicator
{
    private double _penetration;
    private double _bodyLongPeriodTotal;
    private double _bodyDojiPeriodTotal;
    private double _bodyShortPeriodTotal;

    public CandleEveningDojiStar(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleEveningDojiStarResult Compute(int startIdx, int endIdx, in double optInPenetration)
    {
        _penetration = optInPenetration;
            
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleEveningDojiStarResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleEveningDojiStarResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleEveningDojiStarResult(BadParam, outBegIdx, outNBElement, outInteger);
        }

        if (optInPenetration < 0.0)
        {
            return new CandleEveningDojiStarResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleEveningDojiStarResult(Success, outBegIdx, outNBElement, outInteger);
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
         * - first candle: long white real body
         * - second candle: doji gapping up
         * - third candle: black real body that moves well within the first candle's real body
         * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
         * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
         * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
         * it to be relatively long
         * outInteger is negative (-1 to -100): evening star is always bearish; 
         * the user should consider that an evening star is significant when it appears in an uptrend, 
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
            
        return new CandleEveningDojiStarResult(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool isEveningDojiStar =
            // 1st: long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // white
            GetCandleColor(i - 2) == 1 &&
            // 2nd: doji
            GetRealBody(i - 1) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i - 1) &&
            // gapping up
            GetRealBodyGapUp(i - 1, i - 2) &&
            // 3rd: longer than short
            GetRealBody(i) > GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
            // black real body
            GetCandleColor(i) == -1 &&
            // closing well within 1st rb
            Close[i] < Close[i - 2] - GetRealBody(i - 2) * _penetration;
            
        return isEveningDojiStar;
    }

    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, BodyLong, BodyShort) + 2;
    }
}