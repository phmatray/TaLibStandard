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
    /// Calculates the variance of a price series.
    /// </summary>
    /// <remarks>
    /// Variance is a statistical measure that represents the average of the squared differences
    /// from the mean. It is the square of the standard deviation and measures the spread of a
    /// dataset. In financial analysis, variance is used to measure the volatility of returns.
    /// The nbDev parameter allows scaling the output, similar to its use in standard deviation.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <param name="nbDev">The scaling factor for the output (typically 1.0).</param>
    /// <returns>
    /// A <see cref="VarianceResult"/> object containing the calculated variance values
    /// and associated metadata.
    /// </returns>
    public static VarianceResult Variance(int startIdx, int endIdx, double[] real, int timePeriod = 5, double nbDev = 1.0)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Variance(
            startIdx,
            endIdx,
            real,
            timePeriod,
            nbDev,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new VarianceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the variance of a price series using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// Variance measures the volatility of returns in financial analysis.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 5).</param>
    /// <param name="nbDev">The scaling factor for the output (default: 1.0).</param>
    /// <returns>
    /// A <see cref="VarianceResult"/> object containing the calculated variance values
    /// and associated metadata.
    /// </returns>
    public static VarianceResult Variance(int startIdx, int endIdx, float[] real, int timePeriod = 5, double nbDev = 1.0)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => Variance(s, e, r, timePeriod, nbDev));
}
