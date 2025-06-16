// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Linear Regression (LINEARREG) calculation.
/// This indicator calculates the linear regression line value at each point, providing a statistical
/// best-fit line through the price data over a specified period.
/// </summary>
public record LinearRegResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinearRegResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of linear regression values representing the best-fit line through the data.</param>
    public LinearRegResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of linear regression line values.
    /// Each value represents the y-coordinate of the regression line at that point in time,
    /// calculated using least squares method over the specified lookback period.
    /// </summary>
    public double[] Real { get; }
}
