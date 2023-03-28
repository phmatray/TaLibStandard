// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

internal static partial class TACore
{
    public static RetCode Trix(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int nbElement = 0;
        int begIdx = 0;
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null)
        {
            return BadParam;
        }

        int emaLookback = EmaLookback(optInTimePeriod);
        int rocLookback = RocRLookback(1);
        int totalLookback = emaLookback * 3 + rocLookback;
        if (startIdx < totalLookback)
        {
            startIdx = totalLookback;
        }

        if (startIdx > endIdx)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return Success;
        }

        outBegIdx = startIdx;
        int nbElementToOutput = endIdx - startIdx + 1 + totalLookback;
        double[] tempBuffer = new double[nbElementToOutput];

        double k = 2.0 / (optInTimePeriod + 1);
        RetCode retCode = TA_INT_EMA(
            startIdx - totalLookback,
            endIdx,
            inReal,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput--;
        nbElementToOutput -= emaLookback;
        retCode = TA_INT_EMA(
            0,
            nbElementToOutput,
            tempBuffer,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput -= emaLookback;
        retCode = TA_INT_EMA(
            0,
            nbElementToOutput,
            tempBuffer,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput -= emaLookback;
        retCode = Roc(0, nbElementToOutput, tempBuffer, 1, ref begIdx, ref outNBElement, ref outReal);
            
        if (retCode != Success || outNBElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        return Success;
    }

    public static int TrixLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            return -1;
        }

        return EmaLookback(optInTimePeriod) * 3 + RocRLookback(1);
    }
}
