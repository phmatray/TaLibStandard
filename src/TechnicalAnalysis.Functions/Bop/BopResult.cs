// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Balance Of Power (BOP) indicator.
/// </summary>
/// <remarks>
/// The Balance Of Power indicator measures the strength of buyers versus sellers by
/// comparing the close price relative to the high-low range. Values range from -1 to +1,
/// where positive values indicate buying pressure and negative values indicate selling pressure.
/// </remarks>
public record BopResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BopResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Balance Of Power values ranging from -1 to +1.</param>
    public BopResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
