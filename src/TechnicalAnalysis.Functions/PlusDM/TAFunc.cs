// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Plus Directional Movement (+DM) - measures upward price movement.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the +DM calculation. Valid range: 1 to 100000. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the +DM values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// +DM is part of the Directional Movement System developed by Welles Wilder.
    /// It quantifies the magnitude of upward price movements.
    /// 
    /// Calculation:
    /// 1. Raw +DM = Current High - Previous High (only if positive and greater than -DM)
    /// 2. If optInTimePeriod = 1: Returns raw +DM values
    /// 3. If optInTimePeriod &gt; 1: Applies Wilder's smoothing:
    ///    - Initial: Sum of first 'period' +DM values
    ///    - Subsequent: Smoothed +DM = Previous Smoothed +DM - (Previous Smoothed +DM / period) + Current +DM
    /// 
    /// Key characteristics:
    /// - +DM is 0 when there's no upward movement or when downward movement is stronger
    /// - Used to calculate +DI (Plus Directional Indicator) when divided by Average True Range
    /// - Part of ADX calculation for trend strength measurement
    /// 
    /// The smoothed +DM values help filter out noise and provide a clearer view of 
    /// the upward directional movement trend.
    /// </remarks>
    public static RetCode PlusDM(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double tempReal;
        int today;
        double diffP;
        double prevLow;
        double prevHigh;
        double diffM;
        var inHighLocal = inHigh;
        var inLowLocal = inLow;
        var outRealLocal = outReal;
        var optInTimePeriodLocal = optInTimePeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriodLocal, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        int lookbackTotal = optInTimePeriod > 1 ? optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.PlusDM] - 1 : 1;

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
        if (optInTimePeriod <= 1)
        {
            outBegIdx = startIdx;
            today = startIdx - 1;
            prevHigh = inHigh[today];
            prevLow = inLow[today];
            while (today < endIdx)
            {
                today++;
                tempReal = inHigh[today];
                diffP = tempReal - prevHigh;
                prevHigh = tempReal;
                tempReal = inLow[today];
                diffM = prevLow - tempReal;
                prevLow = tempReal;
                if (diffP > 0.0 && diffP > diffM)
                {
                    outReal[outIdx] = diffP;
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }
            }

            outNBElement = outIdx;
            return Success;
        }

        outBegIdx = startIdx;
        double prevPlusDM = 0.0;
        today = startIdx - lookbackTotal;
        prevHigh = inHigh[today];
        prevLow = inLow[today];
        int i = optInTimePeriod - 1;
        
        while (i > 0)
        {
            i--;
            today++;
            tempReal = inHigh[today];
            diffP = tempReal - prevHigh;
            prevHigh = tempReal;
            tempReal = inLow[today];
            diffM = prevLow - tempReal;
            prevLow = tempReal;
            if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM += diffP;
            }
        }

        i = (int)TACore.Globals.UnstablePeriod[FuncUnstId.PlusDM];
        
        while (i != 0)
        {
            i--;
            today++;
            tempReal = inHigh[today];
            diffP = tempReal - prevHigh;
            prevHigh = tempReal;
            tempReal = inLow[today];
            diffM = prevLow - tempReal;
            prevLow = tempReal;
            if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM = prevPlusDM - (prevPlusDM / optInTimePeriod) + diffP;
            }
            else
            {
                prevPlusDM -= prevPlusDM / optInTimePeriod;
            }
        }

        outReal[0] = prevPlusDM;
        outIdx = 1;
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
            if (diffP > 0.0 && diffP > diffM)
            {
                prevPlusDM = prevPlusDM - (prevPlusDM / optInTimePeriod) + diffP;
            }
            else
            {
                prevPlusDM -= prevPlusDM / optInTimePeriod;
            }

            outReal[outIdx] = prevPlusDM;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the Plus Directional Movement (+DM) function.
    /// </summary>
    /// <param name="optInTimePeriod">The time period for the calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid +DM value, or -1 if parameters are invalid.</returns>
    /// <remarks>
    /// The lookback period determines how many historical data points are needed before 
    /// the function can produce its first valid output value.
    /// 
    /// For optInTimePeriod = 1: Only 1 data point is needed (raw +DM).
    /// For optInTimePeriod &gt; 1: The lookback includes the smoothing period plus any unstable period.
    /// </remarks>
    public static int PlusDMLookback(int optInTimePeriod)
    {
        return optInTimePeriod switch
        {
            < 1 or > 100000 => -1,
            > 1 => optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.PlusDM] - 1,
            _ => 1
        };
    }
}
