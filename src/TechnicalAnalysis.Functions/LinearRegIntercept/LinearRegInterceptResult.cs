// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Linear Regression Intercept (LINEARREG_INTERCEPT) calculation.
/// This indicator calculates the y-intercept of the linear regression line, representing where
/// the regression line would cross the y-axis if extended backward.
/// </summary>
public record LinearRegInterceptResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinearRegInterceptResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of y-intercept values for the linear regression line at each point.</param>
    public LinearRegInterceptResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

    /// <summary>
    /// Gets the array of linear regression intercept values.
    /// Each value represents the y-intercept of the regression line calculated over the lookback period,
    /// useful for projecting the regression line and understanding price levels.
    /// </summary>
}
