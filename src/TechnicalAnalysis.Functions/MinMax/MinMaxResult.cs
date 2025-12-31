// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the minimum and maximum values over a specified period.
/// </summary>
/// <remarks>
/// The MinMax function calculates the lowest and highest values within a rolling window period.
/// This is useful for identifying price ranges, calculating channels, and determining
/// support and resistance levels based on recent price extremes.
/// </remarks>
public record MinMaxResult : DualOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MinMaxResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="min">The array of minimum values found within each period.</param>
    /// <param name="max">The array of maximum values found within each period.</param>
    public MinMaxResult(RetCode retCode, int begIdx, int nbElement, double[] min, double[] max)
        : base(retCode, begIdx, nbElement, min, max)
    {
    }

    /// <summary>
    /// Gets the array of maximum values.
    /// </summary>
    /// <remarks>
    /// Each element represents the highest value found within the lookback period
    /// ending at that point. These values can be used as dynamic resistance levels
    /// or to calculate price channels and bands.
    /// </remarks>
    public double[] Max => Real1;

    /// <summary>
    /// Gets the array of minimum values.
    /// </summary>
    /// <remarks>
    /// Each element represents the lowest value found within the lookback period
    /// ending at that point. These values can be used as dynamic support levels
    /// or to calculate price channels and bands.
    /// </remarks>
    public double[] Min => Real0;
}
