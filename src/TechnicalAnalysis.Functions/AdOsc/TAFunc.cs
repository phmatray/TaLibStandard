// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Chaikin Accumulation/Distribution Oscillator - a momentum indicator of the A/D Line.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="inVolume">Input array of volume data.</param>
    /// <param name="optInFastPeriod">Number of periods for the fast EMA. Typical value: 3.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow EMA. Typical value: 10.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the A/D Oscillator values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The A/D Oscillator is the difference between fast and slow EMAs of the A/D Line.
    /// 
    /// Calculation:
    /// 1. Calculate A/D Line (cumulative)
    /// 2. Fast EMA of A/D Line (typically 3-period)
    /// 3. Slow EMA of A/D Line (typically 10-period)
    /// 4. A/D Oscillator = Fast EMA - Slow EMA
    /// 
    /// Interpretation:
    /// - Positive values: Buying pressure (bullish)
    /// - Negative values: Selling pressure (bearish)
    /// - Zero line crossovers signal momentum changes
    /// - Divergences with price indicate potential reversals
    /// 
    /// The oscillator helps identify when money flow momentum is accelerating
    /// or decelerating, often leading price movements.
    /// </remarks>
    public static RetCode AdOsc(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in double[] inVolume,
        in int optInFastPeriod,
        in int optInSlowPeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double[] inCloseLocal = inClose;
        double[] inHighLocal = inHigh;
        double[] inLowLocal = inLow;
        double[] inVolumeLocal = inVolume;
        double[] outRealLocal = outReal;
        int optInFastPeriodLocal = optInFastPeriod;
        int optInSlowPeriodLocal = optInSlowPeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, inCloseLocal, inVolumeLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInFastPeriodLocal),
            () => ValidationHelper.ValidatePeriodRange(optInSlowPeriodLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int slowestPeriod = optInFastPeriod < optInSlowPeriod
            ? optInSlowPeriod
            : optInFastPeriod;

        int lookbackTotal = EmaLookback(slowestPeriod);
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        outBegIdx = startIdx;
        int today = startIdx - lookbackTotal;
        double ad = 0.0;
        double fastK = 2.0 / (optInFastPeriod + 1);
        double oneMinusFastK = 1.0 - fastK;
        double slowK = 2.0 / (optInSlowPeriod + 1);
        double oneMinusSlowK = 1.0 - slowK;
        double high = inHigh[today];
        double low = inLow[today];
        double tmp = high - low;
        double close = inClose[today];
        if (tmp > 0.0)
        {
            ad += (close - low - (high - close)) / tmp * inVolume[today];
        }

        today++;
        double fastEMA = ad;
        double slowEMA = ad;
        while (true)
        {
            if (today >= startIdx)
            {
                break;
            }

            high = inHigh[today];
            low = inLow[today];
            tmp = high - low;
            close = inClose[today];
            if (tmp > 0.0)
            {
                ad += (close - low - (high - close)) / tmp * inVolume[today];
            }

            today++;
            fastEMA = (fastK * ad) + (oneMinusFastK * fastEMA);
            slowEMA = (slowK * ad) + (oneMinusSlowK * slowEMA);
        }

        int outIdx = 0;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            high = inHigh[today];
            low = inLow[today];
            tmp = high - low;
            close = inClose[today];
            if (tmp > 0.0)
            {
                ad += (close - low - (high - close)) / tmp * inVolume[today];
            }

            today++;
            fastEMA = (fastK * ad) + (oneMinusFastK * fastEMA);
            slowEMA = (slowK * ad) + (oneMinusSlowK * slowEMA);
            outReal[outIdx] = fastEMA - slowEMA;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for A/D Oscillator calculation.
    /// </summary>
    /// <param name="optInFastPeriod">Number of periods for the fast EMA. Valid range: 2 to 100000.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow EMA. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid A/D Oscillator value can be calculated, or -1 if parameters are invalid.</returns>
    public static int AdOscLookback(int optInFastPeriod, int optInSlowPeriod)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return -1;
        }

        int slowestPeriod = optInFastPeriod < optInSlowPeriod
            ? optInSlowPeriod
            : optInFastPeriod;

        return EmaLookback(slowestPeriod);
    }
}
