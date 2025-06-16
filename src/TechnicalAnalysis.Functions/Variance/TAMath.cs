// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

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
    public static VarianceResult Variance(int startIdx, int endIdx, double[] real, int timePeriod, double nbDev)
    {
        int outBegIdx = default;
        int outNBElement = default;
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
    /// Calculates the variance of a price series using default parameters.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 5 and nbDev of 1.0. Variance is
    /// the square of standard deviation and measures the spread of values in a dataset.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <returns>
    /// A <see cref="VarianceResult"/> object containing the calculated variance values
    /// and associated metadata.
    /// </returns>
    public static VarianceResult Variance(int startIdx, int endIdx, double[] real)
        => Variance(startIdx, endIdx, real, 5, 1.0);

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
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <param name="nbDev">The scaling factor for the output (typically 1.0).</param>
    /// <returns>
    /// A <see cref="VarianceResult"/> object containing the calculated variance values
    /// and associated metadata.
    /// </returns>
    public static VarianceResult Variance(int startIdx, int endIdx, float[] real, int timePeriod, double nbDev)
        => Variance(startIdx, endIdx, real.ToDouble(), timePeriod, nbDev);
        
    /// <summary>
    /// Calculates the variance of a price series using float arrays with default parameters.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and uses default values of time period 5 and nbDev 1.0.
    /// The arrays are converted to double arrays before performing the calculation.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <returns>
    /// A <see cref="VarianceResult"/> object containing the calculated variance values
    /// and associated metadata.
    /// </returns>
    public static VarianceResult Variance(int startIdx, int endIdx, float[] real)
        => Variance(startIdx, endIdx, real, 5, 1.0);
}
