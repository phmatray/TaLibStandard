// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Pearson correlation coefficient between two price series.
    /// </summary>
    /// <remarks>
    /// The correlation coefficient measures the linear relationship between two variables.
    /// It ranges from -1 to +1, where +1 indicates perfect positive correlation,
    /// -1 indicates perfect negative correlation, and 0 indicates no linear correlation.
    /// This is useful for determining how closely two securities move together.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security.</param>
    /// <param name="real1">Array of prices for the second security.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>
    /// A <see cref="CorrelResult"/> object containing the calculated correlation coefficients
    /// and associated metadata.
    /// </returns>
    public static CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Correl(
            startIdx,
            endIdx,
            real0,
            real1,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new CorrelResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates the Pearson correlation coefficient between two price series using default parameters.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 30. The correlation coefficient measures
    /// the linear relationship between two variables, ranging from -1 to +1.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security.</param>
    /// <param name="real1">Array of prices for the second security.</param>
    /// <returns>
    /// A <see cref="CorrelResult"/> object containing the calculated correlation coefficients
    /// and associated metadata.
    /// </returns>
    public static CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1)
        => Correl(startIdx, endIdx, real0, real1, 30);

    /// <summary>
    /// Calculates the Pearson correlation coefficient between two price series using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// The correlation coefficient measures the linear relationship between two variables.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security.</param>
    /// <param name="real1">Array of prices for the second security.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>
    /// A <see cref="CorrelResult"/> object containing the calculated correlation coefficients
    /// and associated metadata.
    /// </returns>
    public static CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod)
        => Correl(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Pearson correlation coefficient between two price series using float arrays with default parameters.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and uses a default time period of 30. The arrays are converted
    /// to double arrays before performing the calculation.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security.</param>
    /// <param name="real1">Array of prices for the second security.</param>
    /// <returns>
    /// A <see cref="CorrelResult"/> object containing the calculated correlation coefficients
    /// and associated metadata.
    /// </returns>
    public static CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1)
        => Correl(startIdx, endIdx, real0, real1, 30);
}
