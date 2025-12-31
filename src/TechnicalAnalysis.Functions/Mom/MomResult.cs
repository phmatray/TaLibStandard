// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Momentum (MOM) indicator.
/// </summary>
/// <remarks>
/// The Momentum indicator measures the rate of change in price over a specified period.
/// It is calculated by subtracting the price n periods ago from the current price.
/// Positive values indicate upward momentum, while negative values indicate downward momentum.
/// </remarks>
public record MomResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MomResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of momentum values.</param>
    public MomResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
