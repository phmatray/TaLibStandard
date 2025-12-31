// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Triangular Moving Average (TRIMA) indicator.
/// </summary>
/// <remarks>
/// TRIMA is a double-smoothed moving average that places greater weight on values in the
/// middle of the period. It creates a smoother line than a simple moving average,
/// making it useful for identifying longer-term trends while filtering out short-term noise.
/// </remarks>
public record TrimaResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrimaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of triangular moving average values.</param>
    public TrimaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
