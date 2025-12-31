// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Percentage Price Oscillator (PPO) indicator.
/// </summary>
/// <remarks>
/// PPO displays the difference between two moving averages as a percentage of the slower moving average.
/// This makes it easier to compare momentum across different securities or time periods,
/// as the values are normalized. It is similar to MACD but expressed as a percentage.
/// </remarks>
public record PpoResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PpoResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of percentage price oscillator values.</param>
    public PpoResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
