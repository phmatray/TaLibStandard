// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector hyperbolic sine operation (SINH function).
/// </summary>
/// <remarks>
/// The SINH function calculates the hyperbolic sine of each element in the input array.
/// The hyperbolic sine is defined as sinh(x) = (e^x - e^(-x)) / 2.
/// Unlike the regular sine function, hyperbolic sine can produce values outside the range [-1, 1].
/// </remarks>
public record SinhResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SinhResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the hyperbolic sine values.</param>
    public SinhResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
