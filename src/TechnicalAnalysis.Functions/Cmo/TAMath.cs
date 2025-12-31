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
    /// Calculates the Chande Momentum Oscillator (CMO) which measures momentum on both up and down days.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A CmoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The CMO is calculated as: ((Sum of up days - Sum of down days) / (Sum of up days + Sum of down days)) * 100.
    /// It oscillates between -100 and +100, with values above +50 indicating overbought conditions
    /// and values below -50 indicating oversold conditions.
    /// </remarks>
    public static CmoResult Cmo(int startIdx, int endIdx, double[] real, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Cmo(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);

        return new CmoResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Chande Momentum Oscillator (CMO) which measures momentum on both up and down days.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A CmoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static CmoResult Cmo(int startIdx, int endIdx, float[] real, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => Cmo(s, e, r, timePeriod));
}
