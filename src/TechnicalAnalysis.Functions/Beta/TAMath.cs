// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Beta coefficient between two price series.
    /// </summary>
    /// <remarks>
    /// Beta measures the volatility or systematic risk of a security or portfolio compared to the market as a whole.
    /// It is calculated as the covariance between the returns of the security and the market divided by the variance
    /// of the market returns. A beta of 1 indicates the security moves with the market, greater than 1 indicates
    /// higher volatility than the market, and less than 1 indicates lower volatility.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security (typically the security being analyzed).</param>
    /// <param name="real1">Array of prices for the second security (typically the market benchmark).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>
    /// A <see cref="BetaResult"/> object containing the calculated beta values
    /// and associated metadata.
    /// </returns>
    public static BetaResult Beta(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Beta(
            startIdx,
            endIdx,
            real0,
            real1,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new BetaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Beta coefficient between two price series using default parameters.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 5. Beta measures the volatility or systematic risk
    /// of a security compared to the market as a whole.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security (typically the security being analyzed).</param>
    /// <param name="real1">Array of prices for the second security (typically the market benchmark).</param>
    /// <returns>
    /// A <see cref="BetaResult"/> object containing the calculated beta values
    /// and associated metadata.
    /// </returns>
    public static BetaResult Beta(int startIdx, int endIdx, double[] real0, double[] real1)
        => Beta(startIdx, endIdx, real0, real1, 5);

    /// <summary>
    /// Calculates the Beta coefficient between two price series using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// Beta measures the volatility or systematic risk of a security compared to the market as a whole.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security (typically the security being analyzed).</param>
    /// <param name="real1">Array of prices for the second security (typically the market benchmark).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>
    /// A <see cref="BetaResult"/> object containing the calculated beta values
    /// and associated metadata.
    /// </returns>
    public static BetaResult Beta(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod)
        => Beta(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Beta coefficient between two price series using float arrays with default parameters.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and uses a default time period of 5. The arrays are converted
    /// to double arrays before performing the calculation.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real0">Array of prices for the first security (typically the security being analyzed).</param>
    /// <param name="real1">Array of prices for the second security (typically the market benchmark).</param>
    /// <returns>
    /// A <see cref="BetaResult"/> object containing the calculated beta values
    /// and associated metadata.
    /// </returns>
    public static BetaResult Beta(int startIdx, int endIdx, float[] real0, float[] real1)
        => Beta(startIdx, endIdx, real0, real1, 5);
}
