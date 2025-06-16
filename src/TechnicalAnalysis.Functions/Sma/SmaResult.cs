// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Simple Moving Average (SMA) indicator.
/// </summary>
/// <remarks>
/// The SMA is a widely used trend-following indicator that calculates the average price
/// over a specified number of periods. It smooths out price data to help identify trends
/// by filtering out short-term price fluctuations.
/// </remarks>
public record SmaResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of simple moving average values.</param>
    public SmaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of simple moving average values.
    /// </summary>
    /// <value>
    /// An array of double values representing the Simple Moving Average at each data point.
    /// Each value is the arithmetic mean of the specified number of previous periods.
    /// </value>
    public double[] Real { get; }
}
