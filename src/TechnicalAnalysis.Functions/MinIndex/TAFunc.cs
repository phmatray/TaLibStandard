// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode MinIndex(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref int[] outInteger)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outInteger == null!)
        {
            return BadParam;
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

            outInteger[outIdx] = lowestIdx;
            outIdx++;
            trailingIdx++;
            today++;
        }
        
        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    public static int MinIndexLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
