// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Hilbert Transform - Dominant Cycle Phase for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtDcPhaseResult containing the calculated dominant cycle phase values.</returns>
    /// <remarks>
    /// The Hilbert Transform - Dominant Cycle Phase measures the phase angle of the 
    /// dominant market cycle. The phase ranges from 0 to 360 degrees, indicating 
    /// where the current price is within the identified cycle. This helps traders 
    /// identify cycle tops and bottoms and can be used for timing entries and exits.
    /// </remarks>
    public static HtDcPhaseResult HtDcPhase(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtDcPhase(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new HtDcPhaseResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Hilbert Transform - Dominant Cycle Phase for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtDcPhaseResult containing the calculated dominant cycle phase values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static HtDcPhaseResult HtDcPhase(int startIdx, int endIdx, float[] real)
        => HtDcPhase(startIdx, endIdx, real.ToDouble());
}
