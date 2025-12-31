// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the median price of a security for each period.
    /// </summary>
    /// <remarks>
    /// The median price is calculated as (High + Low) / 2 for each period. This provides
    /// a simple mid-point price that represents the center of the trading range for each period.
    /// It is often used as a simplified price input for other indicators or as a basic
    /// representation of price levels that filters out opening and closing price gaps.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <returns>
    /// A <see cref="MedPriceResult"/> object containing the calculated median price values
    /// and associated metadata.
    /// </returns>
    public static MedPriceResult MedPrice(int startIdx, int endIdx, double[] high, double[] low)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MedPrice(startIdx, endIdx, high, low, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new MedPriceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the median price of a security for each period using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// The median price is calculated as (High + Low) / 2 for each period.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <returns>
    /// A <see cref="MedPriceResult"/> object containing the calculated median price values
    /// and associated metadata.
    /// </returns>
    public static MedPriceResult MedPrice(int startIdx, int endIdx, float[] high, float[] low)
        => MedPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble());
}
