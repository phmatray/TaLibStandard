// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector base-10 logarithm operation (LOG10 function).
/// </summary>
/// <remarks>
/// The LOG10 function calculates the base-10 logarithm of each element in the input array.
/// The base-10 logarithm answers the question: "10 to what power equals this number?".
/// Input values must be positive. For example, log10(100) = 2, log10(10) = 1, log10(1) = 0.
/// </remarks>
public record Log10Result : SingleOutputResult
{
    /// Initializes a new instance of the <see cref="Log10Result"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the base-10 logarithm values.</param>
    public Log10Result(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

}
