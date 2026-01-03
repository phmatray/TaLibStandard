// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Relative Strength Index (RSI).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="inReal">Array of input values (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods (2 to 100000). Default is 14.</param>
    /// <param name="outBegIdx">The starting index of the output values.</param>
    /// <param name="outNBElement">The number of output values generated.</param>
    /// <param name="outReal">Array to store the calculated RSI values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The RSI is a momentum oscillator that measures the speed and magnitude of price changes.
    /// RSI values range from 0 to 100, where:
    /// - Values above 70 typically indicate overbought conditions
    /// - Values below 30 typically indicate oversold conditions
    /// - The centerline at 50 can indicate the overall trend direction
    /// </remarks>
    public static RetCode Rsi(
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

        outBegIdx = 0;
        outNBElement = 0;
        int lookbackTotal = RsiLookback(optInTimePeriod);
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx <= endIdx)
        {
            double tempValue1;
            double prevGain;
            double prevLoss;
            double tempValue2;
            int i;
            int outIdx = 0;
            if (optInTimePeriod == 1)
            {
                outBegIdx = startIdx;
                i = endIdx - startIdx + 1;
                outNBElement = i;
                Array.Copy(inReal, startIdx, outReal, 0, i);
                return Success;
            }

            int today = startIdx - lookbackTotal;
            double prevValue = inReal[today];
            if (TACore.Globals.UnstablePeriod[FuncUnstId.Rsi] == 0 && TACore.Globals.Compatibility == Compatibility.Metastock)
            {
                double savePrevValue = prevValue;
                prevGain = 0.0;
                prevLoss = 0.0;
                for (i = optInTimePeriod; i > 0; i--)
                {
                    tempValue1 = inReal[today];
                    today++;
                    tempValue2 = tempValue1 - prevValue;
                    prevValue = tempValue1;
                    if (tempValue2 < 0.0)
                    {
                        prevLoss -= tempValue2;
                    }
                    else
                    {
                        prevGain += tempValue2;
                    }
                }

                tempValue1 = prevLoss / optInTimePeriod;
                tempValue2 = prevGain / optInTimePeriod;
                tempValue1 = tempValue2 + tempValue1;
                outReal[outIdx] = 100.0 * (tempValue2 / tempValue1);
                outIdx++;

                if (today > endIdx)
                {
                    outBegIdx = startIdx;
                    outNBElement = outIdx;
                    return Success;
                }

                today -= optInTimePeriod;
                prevValue = savePrevValue;
            }

            prevGain = 0.0;
            prevLoss = 0.0;
            today++;
            for (i = optInTimePeriod; i > 0; i--)
            {
                tempValue1 = inReal[today];
                today++;
                tempValue2 = tempValue1 - prevValue;
                prevValue = tempValue1;
                if (tempValue2 < 0.0)
                {
                    prevLoss -= tempValue2;
                }
                else
                {
                    prevGain += tempValue2;
                }
            }

            prevLoss /= optInTimePeriod;
            prevGain /= optInTimePeriod;
            if (today > startIdx)
            {
                tempValue1 = prevGain + prevLoss;
                outReal[outIdx] = 100.0 * (prevGain / tempValue1);
                outIdx++;
            }
            else
            {
                while (today < startIdx)
                {
                    tempValue1 = inReal[today];
                    tempValue2 = tempValue1 - prevValue;
                    prevValue = tempValue1;
                    prevLoss *= optInTimePeriod - 1;
                    prevGain *= optInTimePeriod - 1;
                    if (tempValue2 < 0.0)
                    {
                        prevLoss -= tempValue2;
                    }
                    else
                    {
                        prevGain += tempValue2;
                    }

                    prevLoss /= optInTimePeriod;
                    prevGain /= optInTimePeriod;
                    today++;
                }
            }

            while (today <= endIdx)
            {
                tempValue1 = inReal[today];
                today++;
                tempValue2 = tempValue1 - prevValue;
                prevValue = tempValue1;
                prevLoss *= optInTimePeriod - 1;
                prevGain *= optInTimePeriod - 1;
                if (tempValue2 < 0.0)
                {
                    prevLoss -= tempValue2;
                }
                else
                {
                    prevGain += tempValue2;
                }

                prevLoss /= optInTimePeriod;
                prevGain /= optInTimePeriod;
                tempValue1 = prevGain + prevLoss;
                outReal[outIdx] = 100.0 * (prevGain / tempValue1);
                outIdx++;
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
        }

        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the RSI indicator.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods (2 to 100000).</param>
    /// <returns>The number of historical data points needed before the first RSI value can be calculated, or -1 if the period is invalid.</returns>
    public static int RsiLookback(int optInTimePeriod)
    {
        int validatedPeriod = ValidationHelper.ValidateLookback(optInTimePeriod);
        if (validatedPeriod == -1)
        {
            return -1;
        }

        int retValue = validatedPeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Rsi];
        if (TACore.Globals.Compatibility == Compatibility.Metastock)
        {
            retValue--;
        }

        return retValue;
    }
}
