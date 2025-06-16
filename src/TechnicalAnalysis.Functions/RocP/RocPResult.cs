// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Rate of Change Percentage (ROCP) indicator calculation.
/// This momentum indicator measures the rate of change in price expressed as a decimal percentage (0.1 = 10%).
/// </summary>
public record RocPResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RocPResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated ROCP values as decimal percentages.</param>
    public RocPResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Rate of Change Percentage values.
    /// Each value represents the rate of change as a decimal (e.g., 0.05 = 5% increase, -0.03 = 3% decrease).
    /// This is calculated as: (price - price[n periods ago]) / price[n periods ago].
    /// </summary>
    public double[] Real { get; }
}
