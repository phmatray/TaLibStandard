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
public class CandleLongLeggedDoji<T> : CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    private T _bodyDojiPeriodTotal = T.Zero;
    private T _shadowLongPeriodTotal = T.Zero;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="open"></param>
    /// <param name="high"></param>
    /// <param name="low"></param>
    /// <param name="close"></param>
    public CandleLongLeggedDoji(in T[] open, in T[] high, in T[] low, in T[] close)
        : base(open, high, low, close)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <returns></returns>
    public CandleLongLeggedDojiResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new CandleLongLeggedDojiResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new CandleLongLeggedDojiResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (Open == null! || High == null! || Low == null! || Close == null!)
        {
            return new CandleLongLeggedDojiResult(BadParam, outBegIdx, outNBElement, outInteger);
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
            return new CandleLongLeggedDojiResult(Success, outBegIdx, outNBElement, outInteger);
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
            
        return new CandleLongLeggedDojiResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, ShadowLong);
    }
}
