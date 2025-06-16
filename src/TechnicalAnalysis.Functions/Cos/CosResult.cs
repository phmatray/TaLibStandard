// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector cosine operation (COS function).
/// </summary>
/// <remarks>
/// The COS function calculates the cosine of each element in the input array.
/// Input values are expected to be in radians. The result is an array where each
/// element represents the cosine of the corresponding input angle, with values in the range [-1, 1].
/// </remarks>
public record CosResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CosResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the cosine values.</param>
    public CosResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of cosine values resulting from the COS operation.
    /// </summary>
    /// <value>
    /// An array of doubles where each element represents the cosine
    /// of the corresponding element from the input array (in radians).
    /// </value>
    public double[] Real { get; }
}
