// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Absolute Price Oscillator (APO) indicator.
/// </summary>
/// <remarks>
/// APO displays the difference between two moving averages of different periods in absolute terms.
/// Unlike the Percentage Price Oscillator (PPO), APO shows the actual price difference,
/// making it useful for comparing price momentum across different time periods.
/// </remarks>
public record ApoResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApoResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of absolute price oscillator values.</param>
    public ApoResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
