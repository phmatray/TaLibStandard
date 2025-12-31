// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Chande Momentum Oscillator (CMO) calculation.
/// This indicator measures momentum by calculating the difference between the sum of gains and losses
/// over a specified period, normalized to oscillate between -100 and +100.
/// </summary>
public record CmoResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CmoResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of CMO values ranging from -100 to +100.</param>
    public CmoResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
