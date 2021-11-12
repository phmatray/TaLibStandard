using TechnicalAnalysis.Common;
using static System.Math;
using static TechnicalAnalysis.Common.CandleSettingType;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.CandleHaramiCross;

public class CandleHaramiCross : CandleIndicator
{
    private double _bodyLongPeriodTotal;
    private double _bodyDojiPeriodTotal;

    public CandleHaramiCross(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public CandleHaramiCrossResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleHaramiCrossResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleHaramiCrossResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null || High == null || Low == null || Close == null)
        {
            return new CandleHaramiCrossResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleHaramiCrossResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyLong);
        int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx - 1)
        {
            _bodyLongPeriodTotal += GetCandleRange(BodyLong, i);
            i++;
        }

        i = bodyDojiTrailingIdx;
        while (i < startIdx)
        {
            _bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white (black) real body
         * - second candle: doji totally engulfed by the first
         * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; 
         * the user should consider that a harami cross is significant when it appears in a downtrend if bullish or 
         * in an uptrend when bearish, while this function does not consider the trend
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = RecognizeCandlePattern(i) ? -GetCandleColor(i - 1) * 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyLongPeriodTotal +=
                GetCandleRange(BodyLong, i - 1) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

            _bodyDojiPeriodTotal +=
                GetCandleRange(BodyDoji, i) -
                GetCandleRange(BodyDoji, bodyDojiTrailingIdx);

            i++;
            bodyLongTrailingIdx++;
            bodyDojiTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleHaramiCrossResult(Success, outBegIdx, outNBElement, outInteger);
    }
    
    /// <inheritdoc cref="CandleIndicator.RecognizeCandlePattern"/>
    public override bool RecognizeCandlePattern(int index)
    {
        bool isHaramiCross =
            // 1st: long
            GetRealBody(index - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, index - 1) &&
            // 2nd: doji
            GetRealBody(index) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, index) &&
            // engulfed by 1st
            Max(Close[index], Open[index]) < Max(Close[index - 1], Open[index - 1]) &&
            Min(Close[index], Open[index]) > Min(Close[index - 1], Open[index - 1]);
            
        return isHaramiCross;
    }
    
    /// <inheritdoc cref="CandleIndicator.GetLookback"/>
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, BodyLong) + 1;
    }
}
