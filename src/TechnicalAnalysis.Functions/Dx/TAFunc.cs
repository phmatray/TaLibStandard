// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Directional Movement Index (DX) - measures the strength of directional movement without regard to direction.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the DX calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the DX values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// DX is the foundation of the ADX (Average Directional Index) indicator.
    /// It measures the strength of directional movement, regardless of whether it's up or down.
    /// 
    /// Calculation:
    /// DX = 100 * |+DI - -DI| / (+DI + -DI)
    /// 
    /// Where:
    /// - +DI = Positive Directional Indicator (upward movement)
    /// - -DI = Negative Directional Indicator (downward movement)
    /// 
    /// Values range from 0 to 100:
    /// - 0-25: Weak directional movement
    /// - 25-50: Moderate directional movement
    /// - 50-75: Strong directional movement
    /// - 75-100: Very strong directional movement
    /// 
    /// Key differences from ADX:
    /// - DX is more volatile (not smoothed)
    /// - DX reacts faster to changes
    /// - ADX is the smoothed average of DX
    /// 
    /// Uses:
    /// - Identifying trending vs ranging markets
    /// - Timing entries when combined with +DI/-DI
    /// - Risk management (avoid trades in low DX environments)
    /// </remarks>
    public static RetCode Dx(
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
        double tempReal;
        double tempReal2;
        double diffM;
        double diffP;
        double plusDI;
        double minusDI;
        int lookbackTotal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outReal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod)
        );
        if (validation != Success)
        {
            return validation;
        }

        lookbackTotal = optInTimePeriod > 1 ? optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Dx] : 2;

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

        int today = startIdx;
        outBegIdx = today;
        double prevMinusDM = 0.0;
        double prevPlusDM = 0.0;
        double prevTR = 0.0;
        today = startIdx - lookbackTotal;
        double prevHigh = inHigh[today];
        double prevLow = inLow[today];
        double prevClose = inClose[today];
        int i = optInTimePeriod - 1;
        while (true)
        {
            i--;
            if (i <= 0)
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
                prevMinusDM += diffM;
            }
            else if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
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

        i = (int)TACore.Globals.UnstablePeriod[FuncUnstId.Dx] + 1;
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
            prevMinusDM -= prevMinusDM / optInTimePeriod;
            prevPlusDM -= prevPlusDM / optInTimePeriod;
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM += diffM;
            }
            else if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
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

        minusDI = 100.0 * (prevMinusDM / prevTR);
        plusDI = 100.0 * (prevPlusDM / prevTR);
        tempReal = minusDI + plusDI;
        outReal[0] = 100.0 * (Math.Abs(minusDI - plusDI) / tempReal);

        int outIdx = 1;
        while (true)
        {
            if (today >= endIdx)
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
            prevMinusDM -= prevMinusDM / optInTimePeriod;
            prevPlusDM -= prevPlusDM / optInTimePeriod;
            if (diffM > 0.0 && diffP < diffM)
            {
                prevMinusDM += diffM;
            }
            else if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
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
            minusDI = 100.0 * (prevMinusDM / prevTR);
            plusDI = 100.0 * (prevPlusDM / prevTR);
            tempReal = minusDI + plusDI;
            outReal[outIdx] = 100.0 * (Math.Abs(minusDI - plusDI) / tempReal);

            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for DX calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the DX calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid DX value can be calculated, or -1 if parameters are invalid.</returns>
    public static int DxLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Dx];
    }
}
