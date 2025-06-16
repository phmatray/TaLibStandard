// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector arcsine operation (ASIN function).
/// </summary>
/// <remarks>
/// The ASIN function calculates the arcsine (inverse sine) of each element in the input array.
/// The result is an array of angles in radians, where each element represents the arcsine
/// of the corresponding input value. Input values must be in the range [-1, 1].
/// </remarks>
public record AsinResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AsinResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the arcsine values in radians.</param>
    public AsinResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of arcsine values resulting from the ASIN operation.
    /// </summary>
    /// <value>
    /// An array of doubles where each element represents the arcsine (in radians)
    /// of the corresponding element from the input array.
    /// </value>
    public double[] Real { get; }
}
