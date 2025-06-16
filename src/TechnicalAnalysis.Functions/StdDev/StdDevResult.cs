// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Standard Deviation (StdDev) indicator calculation.
/// Standard Deviation is a statistical measure of volatility that shows how much variation exists from the average (mean) price.
/// </summary>
public record StdDevResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StdDevResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated standard deviation values.</param>
    public StdDevResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Standard Deviation values.
    /// Higher values indicate greater price volatility and dispersion from the mean.
    /// Lower values suggest prices are staying close to the average with less volatility.
    /// </summary>
    public double[] Real { get; }
}
