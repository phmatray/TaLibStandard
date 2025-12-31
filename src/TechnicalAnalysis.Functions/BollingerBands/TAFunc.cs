// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates Bollinger Bands - a volatility indicator that creates upper and lower bands around a moving average.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the moving average calculation. Typical value: 20.</param>
    /// <param name="optInNbDevUp">Number of standard deviations for the upper band. Typical value: 2.0.</param>
    /// <param name="optInNbDevDn">Number of standard deviations for the lower band. Typical value: 2.0.</param>
    /// <param name="optInMAType">Type of moving average to use (SMA, EMA, etc.). Default: SMA.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outRealUpperBand">Output array for the upper band values.</param>
    /// <param name="outRealMiddleBand">Output array for the middle band (moving average) values.</param>
    /// <param name="outRealLowerBand">Output array for the lower band values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Bollinger Bands consist of three lines:
    /// - Upper Band = Moving Average + (Standard Deviation × Number of Deviations)
    /// - Middle Band = Moving Average (typically 20-period SMA)
    /// - Lower Band = Moving Average - (Standard Deviation × Number of Deviations)
    /// 
    /// The bands expand during volatile periods and contract during consolidation.
    /// Price touching the upper band may indicate overbought conditions, while touching
    /// the lower band may indicate oversold conditions. However, prices can remain at
    /// band extremes during strong trends.
    /// </remarks>
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
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inReal, outRealUpperBand, outRealMiddleBand, outRealLowerBand);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        RetCode periodCheck = ValidationHelper.ValidatePeriodRange(optInTimePeriod);
        if (periodCheck != Success)
        {
            return periodCheck;
        }

        int i;
        double tempReal2;
        double tempReal;
        double[] tempBuffer2;
        double[] tempBuffer1;

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

    /// <summary>
    /// Returns the lookback period required for Bollinger Bands calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the moving average calculation. Valid range: 2 to 100000.</param>
    /// <param name="optInMAType">Type of moving average to use (SMA, EMA, etc.).</param>
    /// <returns>The number of historical data points required before the first valid Bollinger Bands value can be calculated, or -1 if parameters are invalid.</returns>
    public static int BollingerBandsLookback(
        int optInTimePeriod,
        MAType optInMAType)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : MovingAverageLookback(optInTimePeriod, optInMAType);
    }
}
