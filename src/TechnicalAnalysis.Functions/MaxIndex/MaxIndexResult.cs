// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the index locations of the highest values over a specified period.
/// The MAXINDEX function identifies the position (index) of the maximum value within a rolling window.
/// </summary>
public record MaxIndexResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MaxIndexResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="integers">An array containing the indices of maximum values. Each element represents
    /// the relative position (offset from the start of the period) where the maximum value was found
    /// within the specified rolling window.</param>
    public MaxIndexResult(RetCode retCode, int begIdx, int nbElement, int[] integers)
        : base(retCode, begIdx, nbElement)
    {
        Integers = integers;
    }

    /// <summary>
    /// Gets the array of indices where maximum values were found.
    /// Each value represents the relative position within the rolling period where
    /// the highest data point occurred.
    /// </summary>
    public int[] Integers { get; }
}
