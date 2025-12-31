// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Hilbert Transform - Dominant Cycle Period for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtDcPeriodResult containing the calculated dominant cycle period values.</returns>
    /// <remarks>
    /// The Hilbert Transform - Dominant Cycle Period is used to identify the dominant 
    /// market cycle period. It uses digital signal processing techniques to measure 
    /// cycle periods in the price data. This indicator helps traders identify the 
    /// current market rhythm and can be used to optimize other indicators' parameters.
    /// </remarks>
    public static HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtDcPeriod(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new HtDcPeriodResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Hilbert Transform - Dominant Cycle Period for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtDcPeriodResult containing the calculated dominant cycle period values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, float[] real)
        => HtDcPeriod(startIdx, endIdx, real.ToDouble());
}
