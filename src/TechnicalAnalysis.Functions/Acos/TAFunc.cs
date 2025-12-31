// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the arc cosine (inverse cosine) of input values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values. Values must be in the range [-1, 1].</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the arc cosine values in radians.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The arc cosine function returns the angle whose cosine is the input value.
    /// 
    /// Mathematical properties:
    /// - Input domain: [-1, 1]
    /// - Output range: [0, π] radians or [0°, 180°]
    /// - acos(1) = 0
    /// - acos(0) = π/2
    /// - acos(-1) = π
    /// 
    /// Common uses in trading:
    /// - Cycle analysis and phase calculations
    /// - Advanced harmonic pattern recognition
    /// - Signal processing and frequency analysis
    /// - Converting correlation coefficients to angular measurements
    /// 
    /// Note: Input values outside [-1, 1] will result in NaN (Not a Number).
    /// </remarks>
    public static RetCode Acos(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal);
        if (validationResult != Success)
        {
            return validationResult;
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = Math.Acos(inReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Acos calculation.
    /// </summary>
    /// <returns>Always returns 0 as arc cosine requires no historical data.</returns>
    public static int AcosLookback()
    {
        return 0;
    }
}
