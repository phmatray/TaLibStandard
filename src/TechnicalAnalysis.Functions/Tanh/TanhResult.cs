// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector hyperbolic tangent operation (TANH function).
/// </summary>
/// <remarks>
/// The TANH function calculates the hyperbolic tangent of each element in the input array.
/// The hyperbolic tangent is defined as tanh(x) = sinh(x)/cosh(x) = (e^x - e^(-x))/(e^x + e^(-x)).
/// The output values are always in the range (-1, 1), making it useful for normalization.
/// </remarks>
public record TanhResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TanhResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the hyperbolic tangent values.</param>
    public TanhResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
