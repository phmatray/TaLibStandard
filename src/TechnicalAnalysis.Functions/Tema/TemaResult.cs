// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Triple Exponential Moving Average (TEMA) indicator.
/// </summary>
/// <remarks>
/// TEMA is an advanced moving average that uses three exponential moving averages to
/// further reduce lag compared to DEMA. It is highly responsive to price changes,
/// making it excellent for identifying short-term price movements and trend reversals.
/// </remarks>
public record TemaResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TemaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of triple exponential moving average values.</param>
    public TemaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
