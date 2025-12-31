// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Hilbert Transform - SineWave indicator for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtSineResult containing the sine and lead sine values.</returns>
    /// <remarks>
    /// The Hilbert Transform - SineWave indicator generates two outputs: Sine and LeadSine.
    /// The Sine line shows the current phase position in the dominant cycle, while the 
    /// LeadSine is advanced by 45 degrees. When Sine crosses above LeadSine, it suggests 
    /// a cycle bottom, and when Sine crosses below LeadSine, it suggests a cycle top.
    /// This indicator is most effective in cycling markets.
    /// </remarks>
    public static HtSineResult HtSine(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outSine = new double[endIdx - startIdx + 1];
        double[] outLeadSine = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtSine(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outSine, ref outLeadSine);
            
        return new HtSineResult(retCode, outBegIdx, outNBElement, outSine, outLeadSine);
    }

    /// <summary>
    /// Calculates the Hilbert Transform - SineWave indicator for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtSineResult containing the sine and lead sine values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static HtSineResult HtSine(int startIdx, int endIdx, float[] real)
        => HtSine(startIdx, endIdx, real.ToDouble());
}
