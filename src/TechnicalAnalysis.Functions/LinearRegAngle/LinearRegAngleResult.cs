// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Linear Regression Angle (LINEARREG_ANGLE) calculation.
/// This indicator calculates the angle of the linear regression line in degrees, providing insight
/// into the strength and direction of the trend over a specified period.
/// </summary>
public record LinearRegAngleResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinearRegAngleResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of angle values in degrees representing the slope of the linear regression line.</param>
    public LinearRegAngleResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

    /// <summary>
    /// Gets the array of linear regression angle values in degrees.
    /// Positive angles indicate an upward trend, negative angles indicate a downward trend.
    /// The magnitude of the angle reflects the steepness of the trend.
    /// </summary>
}
