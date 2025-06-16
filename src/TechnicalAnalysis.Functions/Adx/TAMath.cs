// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides mathematical functions for technical analysis.
/// </summary>
public static partial class TAMath
{
    /// <summary>
    /// Calculates the Average Directional Index (ADX) indicator.
    /// </summary>
    /// <remarks>
    /// The Average Directional Index (ADX) is a trend strength indicator developed by J. Welles Wilder.
    /// It is a smoothed average of the Directional Movement Index (DX) and is used to determine whether 
    /// a market is trending or ranging, regardless of trend direction.
    /// 
    /// The ADX is derived from two other indicators:
    /// - +DI (Positive Directional Indicator): measures upward trend strength
    /// - -DI (Negative Directional Indicator): measures downward trend strength
    /// 
    /// ADX values help identify trend strength:
    /// - 0-25: Absent or weak trend
    /// - 25-50: Strong trend
    /// - 50-75: Very strong trend
    /// - 75-100: Extremely strong trend
    /// 
    /// The ADX does not indicate trend direction, only trend strength. Traders often use it in combination 
    /// with the +DI and -DI lines to determine both trend direction and strength.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">Number of periods for the ADX calculation (default: 14).</param>
    /// <returns>An AdxResult containing the calculated values and metadata.</returns>
    public static AdxResult Adx(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Adx(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AdxResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Average Directional Index (ADX) using the default period of 14.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 14.
    /// See the main overload for a detailed description of the ADX indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>An AdxResult containing the calculated values and metadata.</returns>
    public static AdxResult Adx(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Adx(startIdx, endIdx, high, low, close, 14);

    /// <summary>
    /// Calculates the Average Directional Index (ADX) for the specified period using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the ADX indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">Number of periods for the ADX calculation.</param>
    /// <returns>An AdxResult containing the calculated values and metadata.</returns>
    public static AdxResult Adx(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => Adx(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the Average Directional Index (ADX) using the default period of 14 with float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// Uses a default time period of 14.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>An AdxResult containing the calculated values and metadata.</returns>
    public static AdxResult Adx(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Adx(startIdx, endIdx, high, low, close, 14);
}
