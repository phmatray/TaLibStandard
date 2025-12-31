// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector ceiling operation (CEIL function).
/// </summary>
/// <remarks>
/// The CEIL function calculates the ceiling of each element in the input array.
/// The ceiling of a number is the smallest integer that is greater than or equal to that number.
/// For example, ceil(2.3) = 3, ceil(-2.3) = -2, ceil(5.0) = 5.
/// </remarks>
public record CeilResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CeilResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the ceiling values.</param>
    public CeilResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
