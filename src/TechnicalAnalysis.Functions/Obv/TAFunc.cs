// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the On Balance Volume (OBV) - a momentum indicator that uses volume flow to predict price changes.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="inVolume">Input array of volume data.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the OBV values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// OBV is a cumulative indicator that adds volume on up days and subtracts volume on down days.
    /// 
    /// Calculation:
    /// - If Close &gt; Previous Close: OBV = Previous OBV + Volume
    /// - If Close &lt; Previous Close: OBV = Previous OBV - Volume
    /// - If Close = Previous Close: OBV = Previous OBV
    /// 
    /// Interpretation:
    /// - Rising OBV confirms an uptrend (buying pressure)
    /// - Falling OBV confirms a downtrend (selling pressure)
    /// - Divergence between OBV and price suggests potential reversal
    /// - OBV breakouts often precede price breakouts
    /// 
    /// The absolute value of OBV is not important; focus on the direction and divergences.
    /// </remarks>
    public static RetCode Obv(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in double[] inVolume,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inReal, inVolume, outReal);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        double prevOBV = inVolume[startIdx];
        double prevReal = inReal[startIdx];
        int outIdx = 0;
        for (int i = startIdx; i <= endIdx; i++)
        {
            double tempReal = inReal[i];
            if (tempReal > prevReal)
            {
                prevOBV += inVolume[i];
            }
            else if (tempReal < prevReal)
            {
                prevOBV -= inVolume[i];
            }

            outReal[outIdx] = prevOBV;
            outIdx++;
            prevReal = tempReal;
        }

        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for OBV calculation.
    /// </summary>
    /// <returns>Always returns 0 as OBV can be calculated from the first data point.</returns>
    public static int ObvLookback()
    {
        return 0;
    }
}
