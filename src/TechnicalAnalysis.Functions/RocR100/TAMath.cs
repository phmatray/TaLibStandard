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
    /// Calculates the Rate of Change Ratio 100 scale (ROCR100) which measures price momentum as a percentage.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of input values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 10).</param>
    /// <returns>A RocR100Result object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Rate of Change Ratio 100 scale (ROCR100) is a momentum oscillator that measures the percentage
    /// change in price from n periods ago, scaled by 100. It is calculated as: ((Current Price / Price n periods ago) * 100).
    /// Values above 100 indicate upward momentum, while values below 100 indicate downward momentum.
    /// A value of 100 indicates no change. This is essentially ROCR multiplied by 100 for easier interpretation.
    /// </remarks>
    public static RocR100Result RocR100(int startIdx, int endIdx, double[] real, int timePeriod = 10)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.RocR100(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);

        return new RocR100Result(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Rate of Change Ratio 100 scale (ROCR100) for float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of input values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 10).</param>
    /// <returns>A RocR100Result object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// This ensures compatibility with data sources that provide float precision while maintaining accuracy
    /// in the calculations.
    /// </remarks>
    public static RocR100Result RocR100(int startIdx, int endIdx, float[] real, int timePeriod = 10)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => RocR100(s, e, r, timePeriod));
}
