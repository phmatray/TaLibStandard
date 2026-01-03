// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Functions.Internal;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides mathematical wrapper functions for technical analysis calculations.
/// </summary>
/// <remarks>
/// This partial class provides convenient overloads for mathematical functions used in technical analysis.
/// It wraps the core TAFunc methods and provides automatic type conversions for ease of use.
/// All mathematical functions follow standard conventions and return results in appropriate units
/// (e.g., trigonometric functions work with radians).
/// </remarks>
public static partial class TAMath
{
    /// <summary>
    /// Calculates the arc cosine (inverse cosine) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="real">Input array of values (must be between -1 and 1).</param>
    /// <returns>An AcosResult containing the calculated arc cosine values in radians and calculation metadata.</returns>
    /// <remarks>
    /// The arc cosine function:
    /// - Returns the angle whose cosine is the input value
    /// - Input values must be in the range [-1, 1]
    /// - Output values are in radians, ranging from 0 to π
    /// - Invalid input values (outside [-1, 1]) will result in NaN
    /// </remarks>
    public static AcosResult Acos(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Acos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new AcosResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the arc cosine (inverse cosine) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="real">Input array of values (must be between -1 and 1).</param>
    /// <returns>An AcosResult containing the calculated arc cosine values in radians and calculation metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and internally converts them to double arrays for calculation.
    /// See the double array overload for detailed behavior description.
    /// </remarks>
    public static AcosResult Acos(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, Acos);
}
