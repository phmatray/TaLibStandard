// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Accumulation/Distribution (A/D) indicator.
    /// </summary>
    /// <remarks>
    /// The Accumulation/Distribution indicator is a cumulative indicator that uses volume and price to assess whether 
    /// a stock is being accumulated or distributed. The A/D measure seeks to identify divergences between the stock 
    /// price and volume flow. This provides insight into how strong a trend is. If the price is rising but the 
    /// indicator is falling, then it suggests that buying volume may not be enough to support the price rise and 
    /// a price decline could be forthcoming.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An AdResult object containing the calculated values.</returns>
    public static AdResult Ad(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Ad(
            startIdx,
            endIdx,
            high,
            low,
            close,
            volume,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new AdResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Accumulation/Distribution (A/D) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the A/D indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An AdResult object containing the calculated values.</returns>
    public static AdResult Ad(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
        => Ad(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), volume.ToDouble());
}
