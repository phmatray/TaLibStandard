// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the average price of a security for each period.
    /// </summary>
    /// <remarks>
    /// The average price is calculated as (Open + High + Low + Close) / 4 for each period.
    /// This provides a single representative price value that considers all four price points
    /// within a trading period. It is often used as a smoothed price input for other technical
    /// indicators or as a simple representation of the period's trading activity.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// An <see cref="AvgPriceResult"/> object containing the calculated average price values
    /// and associated metadata.
    /// </returns>
    public static AvgPriceResult AvgPrice(
        int startIdx,
        int endIdx,
        double[] open,
        double[] high,
        double[] low,
        double[] close)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.AvgPrice(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AvgPriceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the average price of a security for each period using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// The average price is calculated as (Open + High + Low + Close) / 4 for each period.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// An <see cref="AvgPriceResult"/> object containing the calculated average price values
    /// and associated metadata.
    /// </returns>
    public static AvgPriceResult AvgPrice(
        int startIdx,
        int endIdx,
        float[] open,
        float[] high,
        float[] low,
        float[] close)
        => AvgPrice(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
}
