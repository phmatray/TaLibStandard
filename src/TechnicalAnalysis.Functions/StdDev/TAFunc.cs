// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
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

        if (inReal == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            outReal == null!)
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

        if (Math.Abs(optInNbDev - 1.0) < 0.00000000000001)
        {
            for (i = 0; i < outNBElement; i++)
            {
                tempReal = outReal[i];
                outReal[i] = tempReal >= 1E-08 ? Math.Sqrt(tempReal) : 0.0;
            }
        }
        else
        {
            for (i = 0; i < outNBElement; i++)
            {
                tempReal = outReal[i];
                outReal[i] = tempReal >= 1E-08 ? Math.Sqrt(tempReal) * optInNbDev : 0.0;
            }
        }

        return Success;
    }

    public static int StdDevLookback(int optInTimePeriod, double optInNbDev)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : VarianceLookback(optInTimePeriod);
    }
}
