// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Hilbert Transform - Phasor Components for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtPhasorResult containing the in-phase and quadrature components.</returns>
    /// <remarks>
    /// The Hilbert Transform - Phasor Components breaks down the price data into two 
    /// components: In-Phase (I) and Quadrature (Q). These components represent the 
    /// real and imaginary parts of the analytic signal. They are used internally by 
    /// other Hilbert Transform indicators and can help identify cycle characteristics 
    /// in the market data.
    /// </remarks>
    public static HtPhasorResult HtPhasor(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outInPhase = new double[endIdx - startIdx + 1];
        double[] outQuadrature = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtPhasor(
            startIdx,
            endIdx,
            real,
            ref outBegIdx,
            ref outNBElement,
            ref outInPhase,
            ref outQuadrature);
            
        return new HtPhasorResult(retCode, outBegIdx, outNBElement, outInPhase, outQuadrature);
    }

    /// <summary>
    /// Calculates the Hilbert Transform - Phasor Components for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtPhasorResult containing the in-phase and quadrature components.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static HtPhasorResult HtPhasor(int startIdx, int endIdx, float[] real)
        => HtPhasor(startIdx, endIdx, real.ToDouble());
}
