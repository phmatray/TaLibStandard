// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the midpoint over a specified period.
    /// </summary>
    /// <param name="startIdx">The start index for the calculation.</param>
    /// <param name="endIdx">The end index for the calculation.</param>
    /// <param name="inReal">The input array of real values.</param>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <param name="outBegIdx">The beginning index of the output values.</param>
    /// <param name="outNBElement">The number of elements in the output array.</param>
    /// <param name="outReal">The output array containing the midpoint values.</param>
    /// <returns>A <see cref="RetCode"/> indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The MidPoint function calculates the midpoint of the highest and lowest values over the specified period.
    /// It is calculated as: (Highest Value + Lowest Value) / 2 over the given time period.
    /// This indicator is useful for identifying the central price level within a range.
    /// </remarks>
    public static RetCode MidPoint(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);
        if (validationResult != Success)
        {
            return validationResult;
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

            double lowest = inReal[trailingIdx];
            trailingIdx++;
            double highest = lowest;
            for (int i = trailingIdx; i <= today; i++)
            {
                double tmp = inReal[i];
                if (tmp < lowest)
                {
                    lowest = tmp;
                }
                else if (tmp > highest)
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
    /// Returns the lookback period for the MidPoint function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range is 2 to 100000.</param>
    /// <returns>The number of elements needed before the first valid value, or -1 if the period is invalid.</returns>
    public static int MidPointLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
