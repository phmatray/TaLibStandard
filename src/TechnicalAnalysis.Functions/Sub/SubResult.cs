// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector subtraction operation (SUB function).
/// </summary>
/// <remarks>
/// The SUB function performs element-wise subtraction of two input arrays,
/// producing an output array where each element is the difference between the corresponding
/// elements from the input arrays (first array minus second array).
/// </remarks>
public record SubResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the difference values from the subtraction operation.</param>
    public SubResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of difference values resulting from the element-wise subtraction operation.
    /// </summary>
    /// <value>
    /// An array of doubles where each element represents the difference between the corresponding
    /// elements from the two input arrays (first array minus second array).
    /// </value>
    public double[] Real { get; }
}
