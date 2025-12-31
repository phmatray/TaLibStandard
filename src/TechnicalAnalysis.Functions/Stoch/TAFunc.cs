// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Stochastic Oscillator - a momentum indicator comparing closing price to price range.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInFastKPeriod">Number of periods for %K calculation. Typical value: 14.</param>
    /// <param name="optInSlowKPeriod">Smoothing periods for %K (to create Slow %K). Typical value: 3.</param>
    /// <param name="optInSlowKMAType">Moving average type for Slow %K smoothing. Typical: SMA.</param>
    /// <param name="optInSlowDPeriod">Number of periods for %D calculation. Typical value: 3.</param>
    /// <param name="optInSlowDMAType">Moving average type for %D calculation. Typical: SMA.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outSlowK">Output array for Slow %K values (smoothed %K).</param>
    /// <param name="outSlowD">Output array for Slow %D values (moving average of Slow %K).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Stochastic Oscillator calculation:
    /// - Fast %K = 100 × (Close - Lowest Low) / (Highest High - Lowest Low)
    /// - Slow %K = Moving Average of Fast %K
    /// - Slow %D = Moving Average of Slow %K
    /// 
    /// Interpretation:
    /// - Values range from 0 to 100
    /// - Above 80: Potentially overbought
    /// - Below 20: Potentially oversold
    /// - %K crossing above %D: Bullish signal
    /// - %K crossing below %D: Bearish signal
    /// - Divergences between price and oscillator indicate potential reversals
    /// </remarks>
    public static RetCode Stoch(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInFastKPeriod,
        in int optInSlowKPeriod,
        in MAType optInSlowKMAType,
        in int optInSlowDPeriod,
        in MAType optInSlowDMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outSlowK,
        ref double[] outSlowD)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outSlowK, outSlowD);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        RetCode fastKCheck = ValidationHelper.ValidatePeriodRange(optInFastKPeriod, 1);
        if (fastKCheck != Success)
        {
            return fastKCheck;
        }

        RetCode slowKCheck = ValidationHelper.ValidatePeriodRange(optInSlowKPeriod, 1);
        if (slowKCheck != Success)
        {
            return slowKCheck;
        }

        RetCode slowDCheck = ValidationHelper.ValidatePeriodRange(optInSlowDPeriod, 1);
        if (slowDCheck != Success)
        {
            return slowDCheck;
        }

        int lookbackK = optInFastKPeriod - 1;
        int lookbackKSlow = MovingAverageLookback(optInSlowKPeriod, optInSlowKMAType);
        int lookbackDSlow = MovingAverageLookback(optInSlowDPeriod, optInSlowDMAType);
        int lookbackTotal = lookbackK + lookbackDSlow + lookbackKSlow;
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
        double[] tempBuffer = outSlowK == inHigh || outSlowK == inLow || outSlowK == inClose
            ? outSlowK
            : outSlowD == inHigh || outSlowD == inLow || outSlowD == inClose
                ? outSlowD
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
            optInSlowKPeriod,
            optInSlowKMAType,
            ref outBegIdx,
            ref outNBElement,
            ref tempBuffer);
            
        if (retCode != Success || outNBElement == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        retCode = MovingAverage(
            0,
            outNBElement - 1,
            tempBuffer,
            optInSlowDPeriod,
            optInSlowDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outSlowD);
            
        Array.Copy(tempBuffer, lookbackDSlow, outSlowK, 0, outNBElement);
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Stochastic Oscillator calculation.
    /// </summary>
    /// <param name="optInFastKPeriod">Number of periods for %K calculation. Valid range: 1 to 100000.</param>
    /// <param name="optInSlowKPeriod">Smoothing periods for %K. Valid range: 1 to 100000.</param>
    /// <param name="optInSlowKMAType">Moving average type for Slow %K smoothing.</param>
    /// <param name="optInSlowDPeriod">Number of periods for %D calculation. Valid range: 1 to 100000.</param>
    /// <param name="optInSlowDMAType">Moving average type for %D calculation.</param>
    /// <returns>The number of historical data points required before the first valid Stochastic value can be calculated, or -1 if parameters are invalid.</returns>
    public static int StochLookback(
        int optInFastKPeriod,
        int optInSlowKPeriod,
        MAType optInSlowKMAType,
        int optInSlowDPeriod,
        MAType optInSlowDMAType)
    {
        if (optInFastKPeriod is < 1 or > 100000 ||
            optInSlowKPeriod is < 1 or > 100000 ||
            optInSlowDPeriod is < 1 or > 100000)
        {
            return -1;
        }

        int retValue = optInFastKPeriod - 1;
        retValue += MovingAverageLookback(optInSlowKPeriod, optInSlowKMAType);
        return retValue + MovingAverageLookback(optInSlowDPeriod, optInSlowDMAType);
    }
}
