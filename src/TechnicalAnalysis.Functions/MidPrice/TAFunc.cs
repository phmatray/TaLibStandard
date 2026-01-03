// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the midpoint price over a specified period.
    /// </summary>
    /// <param name="startIdx">The start index for the calculation.</param>
    /// <param name="endIdx">The end index for the calculation.</param>
    /// <param name="inHigh">The input array of high prices.</param>
    /// <param name="inLow">The input array of low prices.</param>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <param name="outBegIdx">The beginning index of the output values.</param>
    /// <param name="outNBElement">The number of elements in the output array.</param>
    /// <param name="outReal">The output array containing the midpoint price values.</param>
    /// <returns>A <see cref="RetCode"/> indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The MidPrice function calculates the midpoint of the highest high and lowest low over the specified period.
    /// It is calculated as: (Highest High + Lowest Low) / 2 over the given time period.
    /// This indicator is particularly useful in identifying the median price level in a given timeframe,
    /// and can be used to determine support and resistance levels.
    /// </remarks>
    public static RetCode MidPrice(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double[] inHighLocal = inHigh;
        double[] inLowLocal = inLow;
        double[] outRealLocal = outReal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod)
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
        while (true)
        {
            if (today > endIdx)
            {
                outBegIdx = startIdx;
                outNBElement = outIdx;
                return Success;
            }

            double lowest = inLow[trailingIdx];
            double highest = inHigh[trailingIdx];
            trailingIdx++;
            for (int i = trailingIdx; i <= today; i++)
            {
                double tmp = inLow[i];
                if (tmp < lowest)
                {
                    lowest = tmp;
                }

                tmp = inHigh[i];
                if (tmp > highest)
                {
                    highest = tmp;
                }
            }

            outReal[outIdx] = (highest + lowest) / 2.0;
            outIdx++;
            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period for the MidPrice function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <returns>The number of elements needed before the first valid value, or -1 if the period is invalid.</returns>
    public static int MidPriceLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);
    }
}
