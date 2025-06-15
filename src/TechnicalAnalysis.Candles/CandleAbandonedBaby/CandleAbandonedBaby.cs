// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Abandoned Baby (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleAbandonedBaby<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private T _bodyLongPeriodTotal = T.Zero;
    private T _bodyDojiPeriodTotal = T.Zero;
    private T _bodyShortPeriodTotal = T.Zero;
    private T _penetration = T.Zero;

    /// <summary>
    /// Computes the <see cref="CandleAbandonedBaby{T}"/> indicator.
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="optInPenetration"></param>
    /// <returns></returns>
    public CandleIndicatorResult Compute(int startIdx, int endIdx, in T optInPenetration)
    {
        _penetration = optInPenetration;
            
        // Initialize output variables 
        (int outBegIdx, int outNBElement, int[] outInteger) = PrepareOutput(startIdx, endIdx);
            
        // Validations
        ValidateIndices(ref startIdx, ref endIdx);
        ValidatePriceArrays();
        ValidateParameters(optInPenetration);

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
            return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
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
         * - first candle: long white (black) real body
         * - second candle: doji
         * - third candle: black (white) real body that moves well within the first candle's real body
         * - upside (downside) gap between the first candle and the doji (the shadows of the two candles don't touch)
         * - downside (upside) gap between the doji and the third candle (the shadows of the two candles don't touch)
         * The meaning of "doji" and "long" is specified with TA_SetCandleSettings
         * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
         * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
         * it to be relatively long
         * outInteger is positive (1 to 100) when it's an abandoned baby bottom or negative (-1 to -100) when it's 
         * an abandoned baby top; the user should consider that an abandoned baby is significant when it appears in 
         * an uptrend or downtrend, while this function does not consider the trend
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? (int)GetCandleColor(i) * 100 : 0;

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
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isAbandonedBaby =
            // 1st: long
            GetRealBody(i - 2) > GetCandleAverage(BodyLong, _bodyLongPeriodTotal, i - 2) &&
            // 2nd: doji
            GetRealBody(i - 1) <= GetCandleAverage(BodyDoji, _bodyDojiPeriodTotal, i - 1) &&
            // 3rd: longer than short
            GetRealBody(i) > GetCandleAverage(BodyShort, _bodyShortPeriodTotal, i) &&
            (
                (
                    // 1st white
                    IsColorGreen(i - 2) &&
                    // 3rd black
                    IsColorRed(i) &&
                    // 3rd closes well within 1st rb
                    Close[i] < Close[i - 2] - (GetRealBody(i - 2) * _penetration) &&
                    // upside gap between 1st and 2nd
                    GetCandleGapUp(i - 1, i - 2) &&
                    // downside gap between 2nd and 3rd
                    GetCandleGapDown(i, i - 1)
                )
                ||
                (
                    // 1st black
                    IsColorRed(i - 2) &&
                    // 3rd white
                    IsColorGreen(i) &&
                    // 3rd closes well within 1st rb
                    Close[i] > Close[i - 2] + (GetRealBody(i - 2) * _penetration) &&
                    // downside gap between 1st and 2nd
                    GetCandleGapDown(i - 1, i - 2) &&
                    // upside gap between 2nd and 3rd
                    GetCandleGapUp(i, i - 1)
                )
            );
            
        return isAbandonedBaby;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyDoji, BodyLong, BodyShort) + 2;
    }
}
