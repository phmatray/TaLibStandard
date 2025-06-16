// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector floor operation (FLOOR function).
/// </summary>
/// <remarks>
/// The FLOOR function calculates the floor of each element in the input array.
/// The floor of a number is the largest integer that is less than or equal to that number.
/// For example, floor(2.3) = 2, floor(-2.3) = -3, floor(5.0) = 5.
/// </remarks>
public record FloorResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloorResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the floor values.</param>
    public FloorResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of floor values resulting from the FLOOR operation.
    /// </summary>
    /// <value>
    /// An array of doubles where each element represents the floor
    /// of the corresponding element from the input array.
    /// </value>
    public double[] Real { get; }
}
