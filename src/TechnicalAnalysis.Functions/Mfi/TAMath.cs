// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Money Flow Index (MFI) indicator.
    /// </summary>
    /// <remarks>
    /// The Money Flow Index (MFI) is a momentum indicator that uses both price and volume data to measure 
    /// buying and selling pressure. It is also known as volume-weighted RSI. The MFI starts with the typical 
    /// price for each period. Money flow is positive when the typical price rises (buying pressure) and negative 
    /// when the typical price declines (selling pressure). A ratio of positive and negative money flow is then 
    /// plugged into an RSI formula to create an oscillator that moves between zero and one hundred.
    /// 
    /// The MFI is interpreted similarly to the RSI: readings below 20 indicate oversold conditions, while 
    /// readings above 80 indicate overbought conditions. Divergences between the indicator and price action 
    /// are also significant and can signal potential reversals.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>An MfiResult object containing the calculated MFI values.</returns>
    public static MfiResult Mfi(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        double[] volume,
        int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Mfi(
            startIdx,
            endIdx,
            high,
            low,
            close,
            volume,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MfiResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Money Flow Index (MFI) indicator with default period.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 14.
    /// See the main overload for a detailed description of the MFI indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An MfiResult object containing the calculated MFI values.</returns>
    public static MfiResult Mfi(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume)
        => Mfi(startIdx, endIdx, high, low, close, volume, 14);

    /// <summary>
    /// Calculates the Money Flow Index (MFI) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the MFI indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>An MfiResult object containing the calculated MFI values.</returns>
    public static MfiResult Mfi(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        float[] volume,
        int timePeriod)
        => Mfi(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), volume.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Money Flow Index (MFI) indicator using float arrays with default period.
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
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An MfiResult object containing the calculated MFI values.</returns>
    public static MfiResult Mfi(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
        => Mfi(startIdx, endIdx, high, low, close, volume, 14);
}
