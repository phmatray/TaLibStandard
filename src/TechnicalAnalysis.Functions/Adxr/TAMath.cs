// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Functions.Internal;

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Average Directional Movement Index Rating (ADXR) indicator.
    /// </summary>
    /// <remarks>
    /// The Average Directional Movement Index Rating (ADXR) is a smoothed version of the ADX indicator.
    /// It is calculated as the average of the current ADX value and the ADX value from a specified number 
    /// of periods ago (typically half the ADX period).
    /// 
    /// ADXR = (ADX[today] + ADX[n periods ago]) / 2
    /// 
    /// The ADXR provides a smoother representation of trend strength compared to ADX, making it useful for:
    /// - Filtering out short-term fluctuations in trend strength
    /// - Confirming longer-term trend conditions
    /// - Reducing false signals in choppy markets
    /// 
    /// Like ADX, ADXR values indicate:
    /// - Below 25: Weak or absent trend
    /// - 25-50: Strong trend
    /// - Above 50: Very strong trend
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods for the calculation (default: 14).</param>
    /// <returns>An AdxrResult object containing the calculated ADXR values.</returns>
    public static AdxrResult Adxr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Adxr(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AdxrResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Average Directional Movement Index Rating (ADXR) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the ADXR indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods for the calculation (default: 14).</param>
    /// <returns>An AdxrResult object containing the calculated ADXR values.</returns>
    public static AdxrResult Adxr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, close, (s, e, h, l, c) => Adxr(s, e, h, l, c, timePeriod));
}
