// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// Rising/Falling Three Methods (Pattern Recognition)
/// </summary>
/// <param name="open">An array of open prices.</param>
/// <param name="high">An array of high prices.</param>
/// <param name="low">An array of low prices.</param>
/// <param name="close">An array of close prices.</param>
/// <typeparam name="T">The type of the array elements.</typeparam>
public class CandleRiseFall3Methods<T>(in T[] open, in T[] high, in T[] low, in T[] close)
    : CandleIndicator<T>(open, high, low, close)
    where T : IFloatingPoint<T>
{
    private readonly T[] _bodyPeriodTotal = new T[5];

    /// <summary>
    /// Computes the <see cref="CandleRiseFall3Methods{T}"/> indicator.
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <returns></returns>
    public CandleIndicatorResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[int.Max(0, endIdx - startIdx + 1)];

        // Validate the requested output range.
        ArgumentOutOfRangeException.ThrowIfNegative(startIdx);
        ArgumentOutOfRangeException.ThrowIfNegative(endIdx - startIdx);

        // Verify required price component.
        ArgumentNullException.ThrowIfNull(Open);
        ArgumentNullException.ThrowIfNull(High);
        ArgumentNullException.ThrowIfNull(Low);
        ArgumentNullException.ThrowIfNull(Close);

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
            _bodyPeriodTotal[0] += GetCandleRange(BodyLong, i);
            i++;
        }

        i = startIdx;

        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first candle: long white (black) candlestick
         * - then: group of falling (rising) small real body candlesticks (commonly black (white)) that hold within 
         *   the prior long candle's range: ideally they should be three but two or more than three are ok too
         * - final candle: long white (black) candle that opens above (below) the previous small candle's close 
         *   and closes above (below) the first long candle's close
         * The meaning of "short" and "long" is specified with TA_SetCandleSettings; here only patterns with 3 small candles
         * are considered;
         * outInteger is positive (1 to 100) or negative (-1 to -100)
         */
        int outIdx = 0;
        do
        {
            outInteger[outIdx++] = GetPatternRecognition(i) ? 100 * (int)GetCandleColor(i - 4) : 0;

            /* add the current range and subtract the first range: this is done after the pattern recognition 
             * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
             */
            _bodyPeriodTotal[4] +=
                GetCandleRange(BodyLong, i - 4) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx - 4);

            for (int totIdx = 3; totIdx >= 1; --totIdx)
            {
                _bodyPeriodTotal[totIdx] +=
                    GetCandleRange(BodyShort, i - totIdx) -
                    GetCandleRange(BodyShort, bodyShortTrailingIdx - totIdx);
            }

            _bodyPeriodTotal[0] +=
                GetCandleRange(BodyLong, i) -
                GetCandleRange(BodyLong, bodyLongTrailingIdx);

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
        bool isRiseFall3Methods =
            // 1st long, then 3 small, 5th long
            GetRealBody(i - 4) > GetCandleAverage(BodyLong, _bodyPeriodTotal[4], i - 4) &&
            GetRealBody(i - 3) < GetCandleAverage(BodyShort, _bodyPeriodTotal[3], i - 3) &&
            GetRealBody(i - 2) < GetCandleAverage(BodyShort, _bodyPeriodTotal[2], i - 2) &&
            GetRealBody(i - 1) < GetCandleAverage(BodyShort, _bodyPeriodTotal[1], i - 1) &&
            GetRealBody(i) > GetCandleAverage(BodyLong, _bodyPeriodTotal[0], i) &&
            // white, 3 black, white  ||  black, 3 white, black
            IsColorOpposite(i - 4, i - 3) &&
            IsColorSame(i - 3, i - 2) &&
            IsColorSame(i - 2, i - 1) &&
            IsColorOpposite(i - 1, i) &&
            // 2nd to 4th hold within 1st: a part of the real body must be within 1st range
            T.Min(Open[i - 3], Close[i - 3]) < High[i - 4] &&
            T.Max(Open[i - 3], Close[i - 3]) > Low[i - 4] &&
            T.Min(Open[i - 2], Close[i - 2]) < High[i - 4] &&
            T.Max(Open[i - 2], Close[i - 2]) > Low[i - 4] &&
            T.Min(Open[i - 1], Close[i - 1]) < High[i - 4] &&
            T.Max(Open[i - 1], Close[i - 1]) > Low[i - 4] &&
            // 2nd to 4th are falling (rising)
            Close[i - 2] * T.CreateChecked((int)GetCandleColor(i - 4)) < Close[i - 3] * T.CreateChecked((int)GetCandleColor(i - 4)) &&
            Close[i - 1] * T.CreateChecked((int)GetCandleColor(i - 4)) < Close[i - 2] * T.CreateChecked((int)GetCandleColor(i - 4)) &&
            // 5th opens above (below) the prior close
            Open[i] * T.CreateChecked((int)GetCandleColor(i - 4)) > Close[i - 1] * T.CreateChecked((int)GetCandleColor(i - 4)) &&
            // 5th closes above (below) the 1st close
            Close[i] * T.CreateChecked((int)GetCandleColor(i - 4)) > Close[i - 4] * T.CreateChecked((int)GetCandleColor(i - 4));
            
        return isRiseFall3Methods;
    }

    /// <inheritdoc />
    public override int GetLookback()
    {
        return GetCandleMaxAvgPeriod(BodyShort, BodyLong) + 4;
    }
}
