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
    /// Calculates the weighted close price of a security for each period.
    /// </summary>
    /// <remarks>
    /// The weighted close price is calculated as (High + Low + Close * 2) / 4 for each period.
    /// This formula gives extra weight to the closing price, recognizing its importance as the
    /// final agreed-upon value for the period. It is often used as an alternative to typical
    /// price when more emphasis on the closing price is desired in technical analysis.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// A <see cref="WclPriceResult"/> object containing the calculated weighted close price values
    /// and associated metadata.
    /// </returns>
    public static WclPriceResult WclPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.WclPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new WclPriceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the weighted close price of a security for each period using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// The weighted close price is calculated as (High + Low + Close * 2) / 4 for each period.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// A <see cref="WclPriceResult"/> object containing the calculated weighted close price values
    /// and associated metadata.
    /// </returns>
    public static WclPriceResult WclPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, close, WclPrice);
}
