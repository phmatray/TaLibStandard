// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode StochRsi(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in int optInFastKPeriod,
        in int optInFastDPeriod,
        in MAType optInFastDMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outFastK,
        ref double[] outFastD)
    {
        int outNbElement1 = 0;
        int outBegIdx2 = 0;
        int outBegIdx1 = 0;
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
            optInFastKPeriod is < 1 or > 100000 ||
            optInFastDPeriod is < 1 or > 100000 ||
            outFastK == null! ||
            outFastD == null!)
        {
            return BadParam;
        }

        outNBElement = 0;
        int lookbackStochF = StochFLookback(optInFastKPeriod, optInFastDPeriod, optInFastDMAType);
        int lookbackTotal = RsiLookback(optInTimePeriod) + lookbackStochF;
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

        outBegIdx = startIdx;
        int tempArraySize = endIdx - startIdx + 1 + lookbackStochF;
        double[] tempRSIBuffer = new double[tempArraySize];
        RetCode retCode = Rsi(
            startIdx - lookbackStochF,
            endIdx,
            inReal,
            optInTimePeriod,
            ref outBegIdx1,
            ref outNbElement1,
            ref tempRSIBuffer);
            
        if (retCode != Success || outNbElement1 == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        retCode = StochF(
            0,
            tempArraySize - 1,
            tempRSIBuffer,
            tempRSIBuffer,
            tempRSIBuffer,
            optInFastKPeriod,
            optInFastDPeriod,
            optInFastDMAType,
            ref outBegIdx2,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        if (retCode != Success || outNBElement == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        return Success;
    }

    public static int StochRsiLookback(
        int optInTimePeriod,
        int optInFastKPeriod,
        int optInFastDPeriod,
        MAType optInFastDMAType)
    {
        return optInTimePeriod is < 2 or > 100000 ||
               optInFastKPeriod is < 1 or > 100000 ||
               optInFastDPeriod is < 1 or > 100000
            ? -1
            : RsiLookback(optInTimePeriod) + StochFLookback(
                optInFastKPeriod,
                optInFastDPeriod,
                optInFastDMAType);
    }
}
