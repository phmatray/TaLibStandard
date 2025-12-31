// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the typical price of a security for each period.
    /// </summary>
    /// <remarks>
    /// The typical price is calculated as (High + Low + Close) / 3 for each period. This price
    /// is considered more representative than just the closing price as it takes into account
    /// the period's trading range. It is commonly used as input for other technical indicators
    /// such as Money Flow Index and Commodity Channel Index.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// A <see cref="TypPriceResult"/> object containing the calculated typical price values
    /// and associated metadata.
    /// </returns>
    public static TypPriceResult TypPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.TypPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, ref outReal);
        return new TypPriceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the typical price of a security for each period using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// The typical price is calculated as (High + Low + Close) / 3 for each period.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// A <see cref="TypPriceResult"/> object containing the calculated typical price values
    /// and associated metadata.
    /// </returns>
    public static TypPriceResult TypPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => TypPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
}
