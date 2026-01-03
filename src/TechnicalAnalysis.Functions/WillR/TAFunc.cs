// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates Williams' %R - a momentum oscillator that measures overbought and oversold levels.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Valid range: 2 to 100000. Default is 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for Williams' %R values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Williams' %R is calculated as:
    /// %R = (Highest High - Close) / (Highest High - Lowest Low) * -100
    /// 
    /// The indicator ranges from -100 to 0, where:
    /// - Values from -20 to 0 indicate overbought conditions
    /// - Values from -100 to -80 indicate oversold conditions
    /// - The -50 level is the midpoint
    /// 
    /// Williams' %R is used for:
    /// - Identifying overbought and oversold conditions
    /// - Momentum confirmation
    /// - Divergence analysis
    /// - Entry and exit timing
    /// 
    /// This indicator is essentially the inverse of the Fast Stochastic Oscillator.
    /// While Stochastic ranges from 0 to 100, Williams' %R ranges from -100 to 0.
    /// </remarks>
    public static RetCode WillR(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        var inCloseLocal = inClose;
        var inHighLocal = inHigh;
        var inLowLocal = inLow;
        var outRealLocal = outReal;
        var optInTimePeriodLocal = optInTimePeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, inCloseLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriodLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int nbInitialElementNeeded = optInTimePeriod - 1;
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int today = startIdx;
        int trailingIdx = startIdx - nbInitialElementNeeded;
        int highestIdx = -1;
        int lowestIdx = highestIdx;
        double lowest = 0.0;
        double highest = lowest;
        double diff = highest;
        
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
                diff = (highest - lowest) / -100.0;
            }
            else if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
                diff = (highest - lowest) / -100.0;
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
                diff = (highest - lowest) / -100.0;
            }
            else if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
                diff = (highest - lowest) / -100.0;
            }

            if (diff != 0.0)
            {
                outReal[outIdx] = (highest - inClose[today]) / diff;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Williams' %R calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Williams' %R value can be calculated, or -1 if parameters are invalid.</returns>
    public static int WillRLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);
    }
}
