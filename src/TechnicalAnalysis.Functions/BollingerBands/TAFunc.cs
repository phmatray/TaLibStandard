// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode BollingerBands(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in double optInNbDevUp,
        in double optInNbDevDn,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outRealUpperBand,
        ref double[] outRealMiddleBand,
        ref double[] outRealLowerBand)
    {
        int i;
        double tempReal2;
        double tempReal;
        double[] tempBuffer2;
        double[] tempBuffer1;
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
            outRealUpperBand == null! ||
            outRealMiddleBand == null! ||
            outRealLowerBand == null!)
        {
            return BadParam;
        }

        if (inReal == outRealUpperBand)
        {
            tempBuffer1 = outRealMiddleBand;
            tempBuffer2 = outRealLowerBand;
        }
        else if (inReal == outRealLowerBand)
        {
            tempBuffer1 = outRealMiddleBand;
            tempBuffer2 = outRealUpperBand;
        }
        else if (inReal == outRealMiddleBand)
        {
            tempBuffer1 = outRealLowerBand;
            tempBuffer2 = outRealUpperBand;
        }
        else
        {
            tempBuffer1 = outRealMiddleBand;
            tempBuffer2 = outRealUpperBand;
        }

        if (tempBuffer1 == inReal || tempBuffer2 == inReal)
        {
            return BadParam;
        }

        RetCode retCode = MovingAverage(
            startIdx,
            endIdx,
            inReal,
            optInTimePeriod,
            optInMAType,
            ref outBegIdx,
            ref outNBElement,
            ref tempBuffer1);
        if (retCode != Success || outNBElement == 0)
        {
            outNBElement = 0;
            return retCode;
        }

        if (optInMAType == MAType.Sma)
        {
            TA_INT_stddev_using_precalc_ma(
                inReal,
                tempBuffer1,
                outBegIdx,
                outNBElement,
                optInTimePeriod,
                tempBuffer2);
        }
        else
        {
            retCode = StdDev(
                outBegIdx,
                endIdx,
                inReal,
                optInTimePeriod,
                1.0,
                ref outBegIdx,
                ref outNBElement,
                ref tempBuffer2);
                
            if (retCode != Success)
            {
                outNBElement = 0;
                return retCode;
            }
        }

        if (tempBuffer1 != outRealMiddleBand)
        {
            Array.Copy(tempBuffer1, 0, outRealMiddleBand, 0, outNBElement);
        }

        if (optInNbDevUp == optInNbDevDn)
        {
            if (optInNbDevUp == 1.0)
            {
                // Both deviations are 1.0
                for (i = 0; i < outNBElement; i++)
                {
                    tempReal = tempBuffer2[i];
                    tempReal2 = outRealMiddleBand[i];
                    outRealUpperBand[i] = tempReal2 + tempReal;
                    outRealLowerBand[i] = tempReal2 - tempReal;
                }
            }
            else
            {
                // Both deviations are equal but not 1.0
                for (i = 0; i < outNBElement; i++)
                {
                    tempReal = tempBuffer2[i] * optInNbDevUp;
                    tempReal2 = outRealMiddleBand[i];
                    outRealUpperBand[i] = tempReal2 + tempReal;
                    outRealLowerBand[i] = tempReal2 - tempReal;
                }
            }
        }
        else
        {
            // Different deviations for upper and lower bands
            if (optInNbDevUp == 1.0)
            {
                // Upper deviation is 1.0, lower is different
                for (i = 0; i < outNBElement; i++)
                {
                    tempReal = tempBuffer2[i];
                    tempReal2 = outRealMiddleBand[i];
                    outRealUpperBand[i] = tempReal2 + tempReal;
                    outRealLowerBand[i] = tempReal2 - (tempReal * optInNbDevDn);
                }
            }
            else if (optInNbDevDn == 1.0)
            {
                // Lower deviation is 1.0, upper is different
                for (i = 0; i < outNBElement; i++)
                {
                    tempReal = tempBuffer2[i];
                    tempReal2 = outRealMiddleBand[i];
                    outRealLowerBand[i] = tempReal2 - tempReal;
                    outRealUpperBand[i] = tempReal2 + (tempReal * optInNbDevUp);
                }
            }
            else
            {
                // Both deviations are different and neither is 1.0
                for (i = 0; i < outNBElement; i++)
                {
                    tempReal = tempBuffer2[i];
                    tempReal2 = outRealMiddleBand[i];
                    outRealUpperBand[i] = tempReal2 + (tempReal * optInNbDevUp);
                    outRealLowerBand[i] = tempReal2 - (tempReal * optInNbDevDn);
                }
            }
        }

        return Success;
    }

    public static int BollingerBandsLookback(
        int optInTimePeriod,
        MAType optInMAType)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : MovingAverageLookback(optInTimePeriod, optInMAType);
    }
}
