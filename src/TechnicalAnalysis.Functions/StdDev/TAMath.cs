// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the standard deviation of a price series.
    /// </summary>
    /// <remarks>
    /// Standard deviation is a statistical measure of the dispersion of values in a dataset.
    /// In financial markets, it is commonly used as a measure of volatility. Higher standard
    /// deviation indicates greater price volatility. The nbDev parameter allows scaling the
    /// output by a number of standard deviations (e.g., for Bollinger Bands calculations).
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <param name="nbDev">The number of standard deviations to scale the output by.</param>
    /// <returns>
    /// A <see cref="StdDevResult"/> object containing the calculated standard deviation values
    /// and associated metadata.
    /// </returns>
    public static StdDevResult StdDev(int startIdx, int endIdx, double[] real, int timePeriod, double nbDev)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.StdDev(
            startIdx,
            endIdx,
            real,
            timePeriod,
            nbDev,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new StdDevResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the standard deviation of a price series using default parameters.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 5 and nbDev of 1.0. Standard deviation
    /// measures the dispersion of values and is commonly used as a volatility indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <returns>
    /// A <see cref="StdDevResult"/> object containing the calculated standard deviation values
    /// and associated metadata.
    /// </returns>
    public static StdDevResult StdDev(int startIdx, int endIdx, double[] real)
        => StdDev(startIdx, endIdx, real, 5, 1.0);

    /// <summary>
    /// Calculates the standard deviation of a price series using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// Standard deviation is a measure of volatility in financial markets.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <param name="nbDev">The number of standard deviations to scale the output by.</param>
    /// <returns>
    /// A <see cref="StdDevResult"/> object containing the calculated standard deviation values
    /// and associated metadata.
    /// </returns>
    public static StdDevResult StdDev(int startIdx, int endIdx, float[] real, int timePeriod, double nbDev)
        => StdDev(startIdx, endIdx, real.ToDouble(), timePeriod, nbDev);
        
    /// <summary>
    /// Calculates the standard deviation of a price series using float arrays with default parameters.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and uses default values of time period 5 and nbDev 1.0.
    /// The arrays are converted to double arrays before performing the calculation.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <returns>
    /// A <see cref="StdDevResult"/> object containing the calculated standard deviation values
    /// and associated metadata.
    /// </returns>
    public static StdDevResult StdDev(int startIdx, int endIdx, float[] real)
        => StdDev(startIdx, endIdx, real, 5, 1.0);
}
