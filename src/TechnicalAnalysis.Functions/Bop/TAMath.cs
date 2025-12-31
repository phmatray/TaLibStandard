// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Balance of Power (BOP) indicator.
    /// </summary>
    /// <remarks>
    /// The Balance of Power indicator measures the strength of buyers versus sellers by assessing
    /// the ability of each to push price to an extreme level. BOP = (Close - Open) / (High - Low).
    /// Values range from -1 to +1, where positive values indicate buying pressure and negative values
    /// indicate selling pressure.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// A <see cref="BopResult"/> object containing the calculated Balance of Power values
    /// and associated metadata.
    /// </returns>
    public static BopResult Bop(
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

        RetCode retCode = TAFunc.Bop(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new BopResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Balance of Power (BOP) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// The Balance of Power indicator measures the strength of buyers versus sellers by assessing
    /// the ability of each to push price to an extreme level.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// A <see cref="BopResult"/> object containing the calculated Balance of Power values
    /// and associated metadata.
    /// </returns>
    public static BopResult Bop(int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        => Bop(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
}
