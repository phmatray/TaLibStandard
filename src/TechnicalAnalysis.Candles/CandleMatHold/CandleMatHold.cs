// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Mat Hold (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleMatHold<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private readonly T[] _bodyPeriodTotal = new T[5];
    private T _penetration = T.Zero;

    /// <summary>
    /// Computes the <see cref="CandleMatHold{T}"/> indicator.
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
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white candle
         * - upside gap between the first and the second bodies
         * - second candle: small black candle
         * - third and fourth candles: falling small real body candlesticks (commonly black) that hold within the long 
         *   white candle's body and are higher than the reaction days of the rising three methods
         * - fifth candle: white candle that opens above the previous small candle's close and closes higher than the 
         *   high of the highest reaction day
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings; 
         * "hold within" means "a part of the real body must be within";
         * optInPenetration is the maximum percentage of the first white body the reaction days can penetrate (it is 
         * to specify how much the reaction days should be "higher than the reaction days of the rising three methods")
         * outInteger is positive (1 to 100): mat hold is always bullish
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal[4] +=
                GetCandleRange(BodyLong, i - 4) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

            int totIdx;
            for (totIdx = 3; totIdx >= 1; --totIdx)
            {
                _bodyPeriodTotal[totIdx] +=
                    GetCandleRange(BodyShort, i - totIdx) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx);
            }

            i++;
            bodyShortTrailingIdx++;
            bodyLongTrailingIdx++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new CandleIndicatorResult(Success, outBegIdx, outNBElement, outInteger);
    }

    /// <inheritdoc />
    public override bool GetPatternRecognition(int i)
    {
        bool isMatHold =
            // 1st long, then 3 small
            GetRealBody(i - 4) > GetCandleAverage(BodyLong, _bodyPeriodTotal[4], i - 4) &&
            GetRealBody(i - 3) < GetCandleAverage(BodyShort, _bodyPeriodTotal[3], i - 3) &&
            GetRealBody(i - 2) < GetCandleAverage(BodyShort, _bodyPeriodTotal[2], i - 2) &&
            GetRealBody(i - 1) < GetCandleAverage(BodyShort, _bodyPeriodTotal[1], i - 1) &&
            // white, black, 2 black or white, white
            IsColorGreen(i - 4) &&
            IsColorRed(i - 3) &&
            IsColorGreen(i) &&
            // upside gap 1st to 2nd
            GetRealBodyGapUp(i - 3, i - 4) &&
            // 3rd to 4th hold within 1st: a part of the real body must be within 1st real body
            T.Min(Open[i - 2], Close[i - 2]) < Close[i - 4] &&
            T.Min(Open[i - 1], Close[i - 1]) < Close[i - 4] &&
            // reaction days penetrate first body less than optInPenetration percent
            T.Min(Open[i - 2], Close[i - 2]) > Close[i - 4] - (GetRealBody(i - 4) * _penetration) &&
            T.Min(Open[i - 1], Close[i - 1]) > Close[i - 4] - (GetRealBody(i - 4) * _penetration) &&
            // 2nd to 4th are falling
            T.Max(Close[i - 2], Open[i - 2]) < Open[i - 3] &&
            T.Max(Close[i - 1], Open[i - 1]) < T.Max(Close[i - 2], Open[i - 2]) &&
            // 5th opens above the prior close
            Open[i] > Close[i - 1] &&
            // 5th closes above the highest high of the reaction days
            Close[i] > T.Max(T.Max(High[i - 3], High[i - 2]), High[i - 1]);
            
        return isMatHold;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 4;
    }
}
