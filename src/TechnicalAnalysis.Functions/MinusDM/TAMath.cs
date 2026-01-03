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
    /// Calculates the Minus Directional Movement (-DM) which measures negative price movement between periods.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A MinusDMResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Minus Directional Movement is a component of the Directional Movement System developed by Welles Wilder.
    /// It measures the negative (downward) movement in price from one period to the next. -DM occurs when the
    /// previous low minus the current low is greater than the current high minus the previous high, and is
    /// positive. The -DM values are typically smoothed using Wilder's smoothing method.
    /// </remarks>
    public static MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MinusDM(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MinusDMResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Minus Directional Movement (-DM) for float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A MinusDMResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// This ensures compatibility with data sources that provide float precision while maintaining accuracy
    /// in the calculations.
    /// </remarks>
    public static MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, (s, e, h, l) => MinusDM(s, e, h, l, timePeriod));
}
