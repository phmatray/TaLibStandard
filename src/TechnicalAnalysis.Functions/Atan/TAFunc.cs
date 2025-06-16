// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the arc tangent (inverse tangent) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values (can be any real number).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the arc tangent values in radians.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The arc tangent function returns the angle whose tangent is the input value.
    /// 
    /// Mathematical properties:
    /// - Input domain: All real numbers
    /// - Output range: (-π/2, π/2) radians or (-90°, 90°)
    /// - atan(0) = 0
    /// - atan(1) = π/4 (45°)
    /// - atan(-1) = -π/4 (-45°)
    /// - As x → ∞, atan(x) → π/2
    /// - As x → -∞, atan(x) → -π/2
    /// 
    /// Common uses in trading:
    /// - Converting price slopes to angles
    /// - Trend angle measurements
    /// - Momentum direction calculations
    /// - Normalizing unbounded indicators to a fixed range
    /// - Gann angle calculations
    /// </remarks>
    public static RetCode Atan(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null!)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = Math.Atan(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Atan calculation.
    /// </summary>
    /// <returns>Always returns 0 as arc tangent requires no historical data.</returns>
    public static int AtanLookback()
    {
        return 0;
    }
}
