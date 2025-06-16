// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Time Series Forecast (TSF) calculation.
/// This indicator projects the linear regression line forward in time, providing a statistical
/// forecast of where prices might be based on the current trend.
/// </summary>
public record TsfResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TsfResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of forecasted values based on linear regression projection.</param>
    public TsfResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of time series forecast values.
    /// Each value represents the projected price based on extending the linear regression line
    /// one period into the future, useful for identifying potential support/resistance levels.
    /// </summary>
    public double[] Real { get; }
}
