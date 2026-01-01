// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Minus Directional Indicator (-DI) - measures the strength of downward price movement.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the -DI calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the -DI values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// -DI is part of the Directional Movement System developed by Welles Wilder.
    /// It quantifies the strength of downward price movements.
    /// 
    /// Calculation:
    /// 1. Minus Directional Movement (-DM) = Previous Low - Current Low (if positive and greater than +DM)
    /// 2. True Range (TR) = Max(High-Low, |High-Previous Close|, |Low-Previous Close|)
    /// 3. Smoothed -DM and TR over the period
    /// 4. -DI = 100 * Smoothed -DM / Smoothed TR
    /// 
    /// Values range from 0 to 100:
    /// - Higher values indicate stronger downward movement
    /// - Values above 25 suggest a strong downtrend
    /// 
    /// Trading signals (used with +DI):
    /// - -DI crossing above +DI: Bearish signal
    /// - -DI above +DI: Downtrend in progress
    /// - +DI and -DI diverging: Trend strengthening
    /// - +DI and -DI converging: Trend weakening
    /// 
    /// -DI is commonly used with +DI and ADX to form a complete trend analysis system.
    /// </remarks>
    public static RetCode MinusDI(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int today;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outReal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        int lookbackTotal = optInTimePeriod > 1 ? optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDI] : 1;

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

        int outIdx = 0;
        if (optInTimePeriod > 1)
        {
            today = startIdx;
            outBegIdx = today;
            double prevMinusDM = 0.0;
            double prevTR = 0.0;
            today = startIdx - lookbackTotal;
            double prevHigh = inHigh[today];
            double prevLow = inLow[today];
            double prevClose = inClose[today];
            int i = optInTimePeriod - 1;
            while (true)
            {
                i--;
                double tempReal;
                double tempReal2;
                double diffM;
                double diffP;
                if (i <= 0)
                {
                    i = (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDI] + 1;
                    while (true)
                    {
                        i--;
                        if (i == 0)
                        {
                            break;
                        }

                        today++;
                        tempReal = inHigh[today];
                        diffP = tempReal - prevHigh;
                        prevHigh = tempReal;
                        tempReal = inLow[today];
                        diffM = prevLow - tempReal;
                        prevLow = tempReal;
                        if (diffM > 0.0 && diffP < diffM)
                        {
                            prevMinusDM = prevMinusDM - (prevMinusDM / optInTimePeriod) + diffM;
                        }
                        else
                        {
                            prevMinusDM -= prevMinusDM / optInTimePeriod;
                        }

                        tempReal = prevHigh - prevLow;
                        tempReal2 = Math.Abs(prevHigh - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        tempReal2 = Math.Abs(prevLow - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        prevTR = prevTR - (prevTR / optInTimePeriod) + tempReal;
                        prevClose = inClose[today];
                    }

                    outReal[0] = 100.0 * (prevMinusDM / prevTR);

                    outIdx = 1;
                    while (today < endIdx)
                    {
                        today++;
                        tempReal = inHigh[today];
                        diffP = tempReal - prevHigh;
                        prevHigh = tempReal;
                        tempReal = inLow[today];
                        diffM = prevLow - tempReal;
                        prevLow = tempReal;
                        if (diffM > 0.0 && diffP < diffM)
                        {
                            prevMinusDM = prevMinusDM - (prevMinusDM / optInTimePeriod) + diffM;
                        }
                        else
                        {
                            prevMinusDM -= prevMinusDM / optInTimePeriod;
                        }

                        tempReal = prevHigh - prevLow;
                        tempReal2 = Math.Abs(prevHigh - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        tempReal2 = Math.Abs(prevLow - prevClose);
                        if (tempReal2 > tempReal)
                        {
                            tempReal = tempReal2;
                        }

                        prevTR = prevTR - (prevTR / optInTimePeriod) + tempReal;
                        prevClose = inClose[today];
                        outReal[outIdx] = 100.0 * (prevMinusDM / prevTR);
                        outIdx++;
                    }

                    outNBElement = outIdx;
                    return Success;
                }

                today++;
                tempReal = inHigh[today];
                diffP = tempReal - prevHigh;
                prevHigh = tempReal;
                tempReal = inLow[today];
                diffM = prevLow - tempReal;
                prevLow = tempReal;
                if (diffM > 0.0 && diffP < diffM)
                {
                    prevMinusDM += diffM;
                }

                tempReal = prevHigh - prevLow;
                tempReal2 = Math.Abs(prevHigh - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                tempReal2 = Math.Abs(prevLow - prevClose);
                if (tempReal2 > tempReal)
                {
                    tempReal = tempReal2;
                }

                prevTR += tempReal;
                prevClose = inClose[today];
            }
        }

        outBegIdx = startIdx;
        today = startIdx - 1;
        while (true)
        {
            if (today >= endIdx)
            {
                break;
            }

            today++;
            outReal[outIdx] = 0.0;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for -DI calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the -DI calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid -DI value can be calculated, or -1 if parameters are invalid.</returns>
    public static int MinusDILookback(int optInTimePeriod)
    {
        return optInTimePeriod switch
        {
            < 1 or > 100000 => -1,
            > 1 => optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.MinusDI],
            _ => 1
        };
    }
}
