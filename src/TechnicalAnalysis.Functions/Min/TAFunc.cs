// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the lowest value over a specified period (MIN).
    /// </summary>
    /// <param name="startIdx">The start index for the calculation within the input array.</param>
    /// <param name="endIdx">The end index for the calculation within the input array.</param>
    /// <param name="inReal">The input array of real values.</param>
    /// <param name="optInTimePeriod">The time period over which to find the minimum value. Valid range is 2 to 100000.</param>
    /// <param name="outBegIdx">The beginning index of the output values within the output array.</param>
    /// <param name="outNBElement">The number of elements to be set in the output array.</param>
    /// <param name="outReal">The output array that will contain the minimum values for each period.</param>
    /// <returns>A <see cref="RetCode"/> indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The MIN function identifies the lowest value within a rolling window of the specified period.
    /// This is useful for identifying local troughs and support levels in price data.
    /// </remarks>
    public static RetCode Min(
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
        int lowestIdx = -1;
        double lowest = 0.0;
        
        while (today <= endIdx)
        {
            double tmp = inReal[today];
            if (lowestIdx < trailingIdx)
            {
                lowestIdx = trailingIdx;
                lowest = inReal[lowestIdx];
                int i = lowestIdx;
                while (i <= today)
                {
                    tmp = inReal[i];
                    if (tmp < lowest)
                    {
                        lowestIdx = i;
                        lowest = tmp;
                    }
                    i++;
                }
            }
            else if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
            }

            outReal[outIdx] = lowest;
            outIdx++;
            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period required for the MIN function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period over which to find the minimum value. Valid range is 2 to 100000.</param>
    /// <returns>The number of data points required before the first valid MIN value, or -1 if the period is invalid.</returns>
    public static int MinLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);
    }
}
