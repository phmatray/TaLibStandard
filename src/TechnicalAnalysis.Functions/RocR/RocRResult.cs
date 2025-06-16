// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Rate of Change Ratio (ROCR) indicator.
/// </summary>
/// <remarks>
/// The Rate of Change Ratio measures the ratio between the current price and the price n periods ago.
/// Unlike the standard ROC which shows percentage change, ROCR shows the price ratio, making it useful
/// for comparing relative strength and identifying momentum changes in price movements.
/// </remarks>
public record RocRResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RocRResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Rate of Change Ratio values.</param>
    public RocRResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Rate of Change Ratio values.
    /// </summary>
    /// <remarks>
    /// Values represent the ratio of current price to past price:
    /// - Values above 1.0 indicate the current price is higher than n periods ago
    /// - Values below 1.0 indicate the current price is lower than n periods ago
    /// - A value of 1.0 indicates no change in price
    /// - The further from 1.0, the greater the momentum
    /// </remarks>
    public double[] Real { get; }
}
