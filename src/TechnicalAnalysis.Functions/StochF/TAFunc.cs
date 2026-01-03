// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Fast Stochastic Oscillator - a momentum indicator showing the location of the close relative to the high-low range.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInFastKPeriod">Number of periods for Fast %K calculation. Typical value: 14.</param>
    /// <param name="optInFastDPeriod">Number of periods for Fast %D calculation. Typical value: 3.</param>
    /// <param name="optInFastDMAType">Moving average type for Fast %D calculation. Typical: SMA.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outFastK">Output array for Fast %K values (raw stochastic).</param>
    /// <param name="outFastD">Output array for Fast %D values (moving average of Fast %K).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Fast Stochastic Oscillator calculation:
    /// - Fast %K = 100 × (Close - Lowest Low) / (Highest High - Lowest Low)
    /// - Fast %D = Moving Average of Fast %K
    /// 
    /// Key differences from Slow Stochastic:
    /// - Fast Stochastic uses raw %K values (no smoothing)
    /// - More responsive but generates more signals
    /// - Can be more prone to whipsaws
    /// 
    /// Interpretation:
    /// - Values range from 0 to 100
    /// - Above 80: Potentially overbought
    /// - Below 20: Potentially oversold
    /// - %K crossing above %D: Bullish signal
    /// - %K crossing below %D: Bearish signal
    /// 
    /// Trading strategies:
    /// - Overbought/Oversold: Look for reversals when extreme levels are reached
    /// - Crossovers: Trade when %K crosses %D in the direction of the trend
    /// - Divergences: Price making new highs/lows while oscillator doesn't
    /// 
    /// The Fast Stochastic is best used:
    /// - In trending markets with clear support/resistance levels
    /// - For short-term trading due to its sensitivity
    /// - In combination with trend-following indicators to filter signals
    /// </remarks>
    public static RetCode StochF(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInFastKPeriod,
        in int optInFastDPeriod,
        in MAType optInFastDMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outFastK,
        ref double[] outFastD)
    {
        double[] tempBuffer;
        var inCloseLocal = inClose;
        var inHighLocal = inHigh;
        var inLowLocal = inLow;
        var outFastDLocal = outFastD;
        var outFastKLocal = outFastK;
        var optInFastDPeriodLocal = optInFastDPeriod;
        var optInFastKPeriodLocal = optInFastKPeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, inCloseLocal, outFastKLocal, outFastDLocal),
            () => ValidationHelper.ValidatePeriodRange(optInFastKPeriodLocal, 1),
            () => ValidationHelper.ValidatePeriodRange(optInFastDPeriodLocal, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        int lookbackK = optInFastKPeriod - 1;
        int lookbackFastD = MovingAverageLookback(optInFastDPeriod, optInFastDMAType);
        int lookbackTotal = lookbackK + lookbackFastD;
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

        int outIdx = 0;
        int trailingIdx = startIdx - lookbackTotal;
        int today = trailingIdx + lookbackK;
        int highestIdx = -1;
        int lowestIdx = highestIdx;
        double lowest = 0.0;
        double highest = lowest;
        double diff = highest;
        tempBuffer = outFastK == inHigh || outFastK == inLow || outFastK == inClose
            ? outFastK
            : outFastD == inHigh || outFastD == inLow || outFastD == inClose
                ? outFastD
                : new double[endIdx - today + 1];

        while (today <= endIdx)
        {
            double tmp = inLow[today];
            if (lowestIdx < trailingIdx)
            {
                lowestIdx = trailingIdx;
                lowest = inLow[lowestIdx];
                int i = lowestIdx;
                while (i <= today)
                {
                    tmp = inLow[i];
                    if (tmp < lowest)
                    {
                        lowestIdx = i;
                        lowest = tmp;
                    }
                    i++;
                }
                diff = (highest - lowest) / 100.0;
            }
            else if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
                diff = (highest - lowest) / 100.0;
            }

            tmp = inHigh[today];
            if (highestIdx < trailingIdx)
            {
                highestIdx = trailingIdx;
                highest = inHigh[highestIdx];
                int i = highestIdx;
                while (i <= today)
                {
                    tmp = inHigh[i];
                    if (tmp > highest)
                    {
                        highestIdx = i;
                        highest = tmp;
                    }
                    i++;
                }
                diff = (highest - lowest) / 100.0;
            }
            else if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
                diff = (highest - lowest) / 100.0;
            }

            if (diff != 0.0)
            {
                tempBuffer[outIdx] = (inClose[today] - lowest) / diff;
                outIdx++;
            }
            else
            {
                tempBuffer[outIdx] = 0.0;
                outIdx++;
            }

            trailingIdx++;
            today++;
        }

        RetCode retCode = MovingAverage(
            0,
            outIdx - 1,
            tempBuffer,
            optInFastDPeriod,
            optInFastDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outFastD);
            
        if (retCode != Success || outNBElement == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        Array.Copy(tempBuffer, lookbackFastD, outFastK, 0, outNBElement);

        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the Fast Stochastic Oscillator function.
    /// </summary>
    /// <param name="optInFastKPeriod">Number of periods for Fast %K calculation.</param>
    /// <param name="optInFastDPeriod">Number of periods for Fast %D calculation.</param>
    /// <param name="optInFastDMAType">Moving average type for Fast %D calculation.</param>
    /// <returns>The minimum number of data points required, or -1 for invalid parameters.</returns>
    public static int StochFLookback(int optInFastKPeriod, int optInFastDPeriod, MAType optInFastDMAType)
    {
        if (optInFastKPeriod is < 1 or > 100000 ||
            optInFastDPeriod is < 1 or > 100000)
        {
            return -1;
        }

        int retValue = optInFastKPeriod - 1;
        return retValue + MovingAverageLookback(optInFastDPeriod, optInFastDMAType);
    }
}
