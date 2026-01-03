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
    public static StdDevResult StdDev(int startIdx, int endIdx, double[] real, int timePeriod = 5, double nbDev = 1.0)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
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
    /// Calculates the standard deviation of a price series using float arrays.
    /// </summary>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// Standard deviation is a measure of volatility in financial markets.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of price values.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 5).</param>
    /// <param name="nbDev">The number of standard deviations to scale the output by (default: 1.0).</param>
    /// <returns>
    /// A <see cref="StdDevResult"/> object containing the calculated standard deviation values
    /// and associated metadata.
    /// </returns>
    public static StdDevResult StdDev(int startIdx, int endIdx, float[] real, int timePeriod = 5, double nbDev = 1.0)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => StdDev(s, e, r, timePeriod, nbDev));
}
