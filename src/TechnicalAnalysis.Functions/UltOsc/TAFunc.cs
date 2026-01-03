// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Ultimate Oscillator - a momentum oscillator that combines short, intermediate, and long-term price movements.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod1">First (shortest) time period. Typical value: 7.</param>
    /// <param name="optInTimePeriod2">Second (intermediate) time period. Typical value: 14.</param>
    /// <param name="optInTimePeriod3">Third (longest) time period. Typical value: 28.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the Ultimate Oscillator values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Ultimate Oscillator was developed by Larry Williams to avoid the pitfalls
    /// of single-period oscillators by incorporating multiple timeframes.
    /// 
    /// Calculation:
    /// 1. Calculate Buying Pressure (BP) = Close - True Low
    /// 2. Calculate True Range (TR)
    /// 3. Calculate averages for each period:
    ///    - Average7 = Sum(BP,7) / Sum(TR,7)
    ///    - Average14 = Sum(BP,14) / Sum(TR,14)
    ///    - Average28 = Sum(BP,28) / Sum(TR,28)
    /// 4. UO = 100 * [(4 * Average7) + (2 * Average14) + Average28] / 7
    /// 
    /// Values range from 0 to 100:
    /// - Above 70: Overbought condition
    /// - Below 30: Oversold condition
    /// - 50: Neutral level
    /// 
    /// Trading signals:
    /// - Bullish divergence + break above divergence high
    /// - Bearish divergence + break below divergence low
    /// - Overbought/oversold reversals with confirmation
    /// 
    /// Advantages:
    /// - Reduces false signals by using multiple timeframes
    /// - Less prone to whipsaws than single-period oscillators
    /// - Weighted calculation emphasizes short-term movements
    /// 
    /// Best used in conjunction with price action and trend analysis.
    /// </remarks>
    public static RetCode UltOsc(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        int optInTimePeriod1,
        int optInTimePeriod2,
        int optInTimePeriod3,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int outIdx;
        int[] usedFlag = new int[3];
        int[] periods = new int[3];
        int[] sortedPeriods = new int[3];
        double[] inCloseLocal = inClose;
        double[] inHighLocal = inHigh;
        double[] inLowLocal = inLow;
        double[] outRealLocal = outReal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, inCloseLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod1, 1),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod2, 1),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod3, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        outBegIdx = 0;
        outNBElement = 0;
        periods[0] = optInTimePeriod1;
        periods[1] = optInTimePeriod2;
        periods[2] = optInTimePeriod3;
        usedFlag[0] = 0;
        usedFlag[1] = 0;
        usedFlag[2] = 0;
        int i = 0;
        while (true)
        {
            if (i >= 3)
            {
                double trueRange;
                double tempDouble;
                double tempCY;
                double tempLT;
                double tempHT;
                double closeMinusTrueLow;
                double trueLow;
                optInTimePeriod1 = sortedPeriods[2];
                optInTimePeriod2 = sortedPeriods[1];
                optInTimePeriod3 = sortedPeriods[0];
                int lookbackTotal = UltOscLookback(optInTimePeriod1, optInTimePeriod2, optInTimePeriod3);
                if (startIdx < lookbackTotal)
                {
                    startIdx = lookbackTotal;
                }

                if (startIdx > endIdx)
                {
                    return Success;
                }

                double a1Total = 0.0;
                double b1Total = 0.0;
                i = startIdx - optInTimePeriod1 + 1;
                while (i < startIdx)
                {
                    tempLT = inLow[i];
                    tempHT = inHigh[i];
                    tempCY = inClose[i - 1];
                    double num7 = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num7;
                    closeMinusTrueLow = inClose[i] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a1Total += closeMinusTrueLow;
                    b1Total += trueRange;
                    i++;
                }

                double a2Total = 0.0;
                double b2Total = 0.0;
                i = startIdx - optInTimePeriod2 + 1;
                while (i < startIdx)
                {
                    tempLT = inLow[i];
                    tempHT = inHigh[i];
                    tempCY = inClose[i - 1];
                    double num6 = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num6;
                    closeMinusTrueLow = inClose[i] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a2Total += closeMinusTrueLow;
                    b2Total += trueRange;
                    i++;
                }

                double a3Total = 0.0;
                double b3Total = 0.0;
                i = startIdx - optInTimePeriod3 + 1;
                while (i < startIdx)
                {
                    tempLT = inLow[i];
                    tempHT = inHigh[i];
                    tempCY = inClose[i - 1];
                    double num5 = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num5;
                    closeMinusTrueLow = inClose[i] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a3Total += closeMinusTrueLow;
                    b3Total += trueRange;
                    i++;
                }

                int today = startIdx;
                outIdx = 0;
                int trailingIdx1 = today - optInTimePeriod1 + 1;
                int trailingIdx2 = today - optInTimePeriod2 + 1;
                for (int trailingIdx3 = today - optInTimePeriod3 + 1; today <= endIdx; trailingIdx3++)
                {
                    tempLT = inLow[today];
                    tempHT = inHigh[today];
                    tempCY = inClose[today - 1];
                    double num4 = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num4;
                    closeMinusTrueLow = inClose[today] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a1Total += closeMinusTrueLow;
                    a2Total += closeMinusTrueLow;
                    a3Total += closeMinusTrueLow;
                    b1Total += trueRange;
                    b2Total += trueRange;
                    b3Total += trueRange;
                    double output = 0.0;
                    output += 4.0 * (a1Total / b1Total);
                    output += 2.0 * (a2Total / b2Total);
                    output += a3Total / b3Total;

                    tempLT = inLow[trailingIdx1];
                    tempHT = inHigh[trailingIdx1];
                    tempCY = inClose[trailingIdx1 - 1];
                    double num3 = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num3;
                    closeMinusTrueLow = inClose[trailingIdx1] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a1Total -= closeMinusTrueLow;
                    b1Total -= trueRange;
                    tempLT = inLow[trailingIdx2];
                    tempHT = inHigh[trailingIdx2];
                    tempCY = inClose[trailingIdx2 - 1];
                    double num2 = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num2;
                    closeMinusTrueLow = inClose[trailingIdx2] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a2Total -= closeMinusTrueLow;
                    b2Total -= trueRange;
                    tempLT = inLow[trailingIdx3];
                    tempHT = inHigh[trailingIdx3];
                    tempCY = inClose[trailingIdx3 - 1];
                    double num = tempLT < tempCY ? tempLT : tempCY;

                    trueLow = num;
                    closeMinusTrueLow = inClose[trailingIdx3] - trueLow;
                    trueRange = tempHT - tempLT;
                    tempDouble = Math.Abs(tempCY - tempHT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    tempDouble = Math.Abs(tempCY - tempLT);
                    if (tempDouble > trueRange)
                    {
                        trueRange = tempDouble;
                    }

                    a3Total -= closeMinusTrueLow;
                    b3Total -= trueRange;
                    outReal[outIdx] = 100.0 * (output / 7.0);
                    outIdx++;
                    today++;
                    trailingIdx1++;
                    trailingIdx2++;
                }

                break;
            }

            int longestPeriod = 0;
            int longestIndex = 0;
            for (int j = 0; j < 3; j++)
            {
                if (usedFlag[j] == 0 && periods[j] > longestPeriod)
                {
                    longestPeriod = periods[j];
                    longestIndex = j;
                }
            }

            usedFlag[longestIndex] = 1;
            sortedPeriods[i] = longestPeriod;
            i++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Ultimate Oscillator calculation.
    /// </summary>
    /// <param name="optInTimePeriod1">First time period. Valid range: 1 to 100000.</param>
    /// <param name="optInTimePeriod2">Second time period. Valid range: 1 to 100000.</param>
    /// <param name="optInTimePeriod3">Third time period. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Ultimate Oscillator value can be calculated, or -1 if parameters are invalid.</returns>
    public static int UltOscLookback(int optInTimePeriod1, int optInTimePeriod2, int optInTimePeriod3)
    {
        if (optInTimePeriod1 is < 1 or > 100000 ||
            optInTimePeriod2 is < 1 or > 100000 ||
            optInTimePeriod3 is < 1 or > 100000)
        {
            return -1;
        }

        int maxPeriod = (optInTimePeriod1 <= optInTimePeriod2 ? optInTimePeriod2 : optInTimePeriod1) > optInTimePeriod3
            ? optInTimePeriod1 <= optInTimePeriod2 ? optInTimePeriod2 : optInTimePeriod1
            : optInTimePeriod3;
        
        return SmaLookback(maxPeriod) + 1;
    }
}
