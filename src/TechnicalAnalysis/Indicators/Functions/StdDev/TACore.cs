// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode StdDev(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in double optInNbDev,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        double tempReal;
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        RetCode retCode = TA_INT_VAR(
            startIdx,
            endIdx,
            inReal,
            optInTimePeriod,
            ref outBegIdx,
            ref outNBElement,
            outReal);
        if (retCode != Success)
        {
            return retCode;
        }

        if (optInNbDev == 1.0)
        {
            i = 0;
            while (i < outNBElement)
            {
                tempReal = outReal[i];
                if (tempReal >= 1E-08)
                {
                    outReal[i] = Math.Sqrt(tempReal);
                }
                else
                {
                    outReal[i] = 0.0;
                }

                i++;
            }
        }
        else
        {
            for (i = 0; i < outNBElement; i++)
            {
                tempReal = outReal[i];
                if (tempReal >= 1E-08)
                {
                    outReal[i] = Math.Sqrt(tempReal) * optInNbDev;
                }
                else
                {
                    outReal[i] = 0.0;
                }
            }
        }

        return Success;
    }

    public static int StdDevLookback(int optInTimePeriod, double optInNbDev)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            return -1;
        }

        return VarianceLookback(optInTimePeriod, optInNbDev);
    }
}
