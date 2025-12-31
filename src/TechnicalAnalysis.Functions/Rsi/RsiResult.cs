// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Relative Strength Index (RSI) indicator.
/// </summary>
/// <remarks>
/// The RSI is a momentum oscillator that measures the speed and magnitude of price changes.
/// It oscillates between 0 and 100, helping identify overbought and oversold conditions.
/// Values above 70 typically indicate overbought conditions, while values below 30 indicate oversold conditions.
/// </remarks>
public record RsiResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RsiResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of RSI values, typically ranging from 0 to 100.</param>
    public RsiResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
