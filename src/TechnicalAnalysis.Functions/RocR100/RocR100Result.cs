// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Rate of Change Ratio 100 scale (ROCR100) indicator.
/// </summary>
/// <remarks>
/// The Rate of Change Ratio 100 scale is a momentum indicator that measures the percentage change
/// between the current price and the price n periods ago, scaled to oscillate around 100.
/// This scaling makes it easier to identify overbought and oversold conditions.
/// </remarks>
public record RocR100Result : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RocR100Result"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Rate of Change Ratio 100 scale values.</param>
    public RocR100Result(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Rate of Change Ratio 100 scale values.
    /// </summary>
    /// <remarks>
    /// Values oscillate around 100:
    /// - Values above 100 indicate the current price is higher than n periods ago
    /// - Values below 100 indicate the current price is lower than n periods ago
    /// - A value of 100 indicates no change in price
    /// - For example, a value of 110 means the price has increased by 10%
    /// </remarks>
    public double[] Real { get; }
}
