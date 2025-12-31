// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Directional Movement Index (DX) indicator.
    /// </summary>
    /// <remarks>
    /// The Directional Movement Index (DX) is a component of the Directional Movement System developed by J. Welles Wilder.
    /// It measures the strength of the dominant trend by analyzing the difference between two directional indicators:
    /// the Positive Directional Indicator (+DI) and the Negative Directional Indicator (-DI).
    /// 
    /// The DX is calculated as:
    /// DX = 100 × |((+DI) - (-DI))| / ((+DI) + (-DI))
    /// 
    /// The DX ranges from 0 to 100, where:
    /// - Values below 20 indicate a weak trend
    /// - Values between 20-40 indicate a moderate trend
    /// - Values above 40 indicate a strong trend
    /// 
    /// Note that DX measures trend strength but not trend direction. It is often smoothed to create the 
    /// Average Directional Index (ADX).
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A DxResult object containing the calculated DX values.</returns>
    public static DxResult Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Dx(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new DxResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Directional Movement Index (DX) indicator with default period.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 14.
    /// See the main overload for a detailed description of the DX indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A DxResult object containing the calculated DX values.</returns>
    public static DxResult Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Dx(startIdx, endIdx, high, low, close, 14);

    /// <summary>
    /// Calculates the Directional Movement Index (DX) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the DX indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>A DxResult object containing the calculated DX values.</returns>
    public static DxResult Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => Dx(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the Directional Movement Index (DX) indicator using float arrays with default period.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// Uses a default time period of 14.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A DxResult object containing the calculated DX values.</returns>
    public static DxResult Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Dx(startIdx, endIdx, high, low, close, 14);
}
