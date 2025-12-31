// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Exponential Moving Average (EMA) indicator.
/// </summary>
/// <remarks>
/// The EMA is a type of moving average that gives more weight to recent prices,
/// making it more responsive to new information compared to the Simple Moving Average (SMA).
/// It is commonly used to identify trends and generate trading signals.
/// </remarks>
public record EmaResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of exponential moving average values.</param>
    public EmaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
