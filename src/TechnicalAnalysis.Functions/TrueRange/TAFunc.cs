// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the True Range (TR) - a volatility measure that captures the full range of price movement.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the True Range values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// True Range is the greatest of:
    /// - Current High - Current Low
    /// - |Current High - Previous Close|
    /// - |Current Low - Previous Close|
    /// 
    /// TR is used:
    /// - As the foundation for ATR (Average True Range)
    /// - To measure volatility including gaps
    /// - For position sizing and stop-loss placement
    /// - As a component in other indicators like ADX
    /// 
    /// Unlike simple range (High - Low), True Range accounts for gaps between periods,
    /// providing a more complete picture of price volatility.
    /// </remarks>
    public static RetCode TrueRange(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outReal);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        if (startIdx < 1)
        {
            startIdx = 1;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int today = startIdx;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            double tempLT = inLow[today];
            double tempHT = inHigh[today];
            double tempCY = inClose[today - 1];
            double greatest = tempHT - tempLT;
            double val2 = Math.Abs(tempCY - tempHT);
            if (val2 > greatest)
            {
                greatest = val2;
            }

            double val3 = Math.Abs(tempCY - tempLT);
            if (val3 > greatest)
            {
                greatest = val3;
            }

            outReal[outIdx] = greatest;
            outIdx++;
            today++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for True Range calculation.
    /// </summary>
    /// <returns>The number of historical data points required before the first valid True Range value can be calculated.</returns>
    public static int TrueRangeLookback()
    {
        return 1;
    }
}
