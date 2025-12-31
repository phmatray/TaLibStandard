// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Double Exponential Moving Average (DEMA) indicator.
/// </summary>
/// <remarks>
/// DEMA is a technical indicator that uses two exponential moving averages to eliminate lag.
/// It provides a smoother and more responsive moving average compared to traditional EMAs,
/// making it particularly useful for identifying trend changes more quickly.
/// </remarks>
public record DemaResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DemaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of double exponential moving average values.</param>
    public DemaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
