// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector tangent operation (TAN function).
/// </summary>
/// <remarks>
/// The TAN function calculates the tangent of each element in the input array.
/// Input values are expected to be in radians. The tangent is defined as sin(x)/cos(x).
/// Note that tangent has vertical asymptotes at odd multiples of π/2, where the function is undefined.
/// </remarks>
public record TanResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TanResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the tangent values.</param>
    public TanResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
