// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Linear Regression Slope (LINEARREG_SLOPE) calculation.
/// This indicator calculates the slope of the linear regression line, indicating the rate of change
/// in price over the specified period.
/// </summary>
public record LinearRegSlopeResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinearRegSlopeResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of slope values representing the rate of change of the regression line.</param>
    public LinearRegSlopeResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

    /// <summary>
    /// Gets the array of linear regression slope values.
    /// Each value represents the slope (rate of change per bar) of the regression line.
    /// Positive values indicate rising prices, negative values indicate falling prices.
    /// </summary>
}
