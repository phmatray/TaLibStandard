// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the summation of values over a specified period.
/// The SUM function calculates the total of all values within a rolling window.
/// </summary>
public record SumResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SumResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">An array containing the calculated sums. Each element represents
    /// the total of all values within the specified period ending at that index.</param>
    public SumResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
