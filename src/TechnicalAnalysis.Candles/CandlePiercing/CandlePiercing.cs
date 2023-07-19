// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class CandlePiercing<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private readonly T[] _bodyLongPeriodTotal = new T[2];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="open"></param>
    /// <param name="high"></param>
    /// <param name="low"></param>
    /// <param name="close"></param>
    public CandlePiercing(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public CandlePiercingResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandlePiercingResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandlePiercingResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandlePiercingResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandlePiercingResult(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
        int i = bodyLongTrailingIdx;
        while (i < startIdx)
        {
            _bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1);
            _bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long black candle
         * - second candle: long white candle with open below previous day low and close at least at 50% of previous day 
         * real body
         * The meaning of "long" is specified with TA_SetCandleSettings
         * outInteger is positive (1 to 100): piercing pattern is always bullish
         * the user should consider that a piercing pattern is significant when it appears in a downtrend, while 
         * this function does not consider it
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            for (int totIdx = 1; totIdx >= 0; --totIdx)
            {
                _bodyLongPeriodTotal[totIdx] +=
                    GetCandleRange(BodyLong, i - totIdx) -
                    GetCandleRange(BodyLong, bodyLongTrailingIdx - totIdx);
            }

            i++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandlePiercingResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isPiercing =
            // 1st: black
            IsColorRed(i - 1) &&
            // long
            GetRealBody(i - 1) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[1], i - 1) &&
            // 2nd: white
            IsColorGreen(i) &&
            // long
            GetRealBody(i) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal[0], i) &&
            // open below prior low
            Open[i] < Low[i - 1] &&
            // close within prior body
            Close[i] < Open[i - 1] &&
            // above midpoint
            Close[i] > Close[i - 1] + GetRealBody(i - 1) * T.CreateChecked(0.5);
            
        return isPiercing;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleAvgPeriod(BodyLong) + 1;
    }
}
