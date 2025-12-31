// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector square root operation (SQRT function).
/// </summary>
/// <remarks>
/// The SQRT function calculates the square root of each element in the input array.
/// Input values must be non-negative (zero or positive). The square root is the value that,
/// when multiplied by itself, gives the original number. For example, sqrt(4) = 2, sqrt(9) = 3.
/// </remarks>
public record SqrtResult : SingleOutputResult
{
    /// Initializes a new instance of the <see cref="SqrtResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the square root values.</param>
    public SqrtResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

}
