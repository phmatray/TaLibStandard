// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Weighted Moving Average (WMA) indicator.
/// </summary>
/// <remarks>
/// The WMA assigns linearly decreasing weights to older data points, giving more importance
/// to recent prices. Unlike the SMA which treats all periods equally, the WMA provides
/// a middle ground between the responsiveness of the EMA and the smoothness of the SMA.
/// </remarks>
public record WmaResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WmaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of weighted moving average values.</param>
    public WmaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of weighted moving average values.
    /// </summary>
    /// <value>
    /// An array of double values representing the Weighted Moving Average at each data point.
    /// Each value is calculated using linearly decreasing weights, where the most recent
    /// period has the highest weight.
    /// </value>
    public double[] Real { get; }
}
