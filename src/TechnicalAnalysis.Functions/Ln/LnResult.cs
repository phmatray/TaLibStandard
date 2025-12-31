// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector natural logarithm operation (LN function).
/// </summary>
/// <remarks>
/// The LN function calculates the natural logarithm (base e) of each element in the input array.
/// The natural logarithm is the inverse of the exponential function. Input values must be positive.
/// For example, ln(e) = 1, ln(1) = 0.
/// </remarks>
public record LnResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LnResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the natural logarithm values.</param>
    public LnResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
