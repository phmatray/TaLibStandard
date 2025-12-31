// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating a Moving Average indicator.
/// </summary>
/// <remarks>
/// Moving averages are fundamental technical indicators that smooth price data by creating
/// a constantly updated average price over a specific period. Various types of moving averages
/// (Simple, Exponential, Weighted, etc.) can be calculated, each with different characteristics
/// for trend identification and signal generation.
/// </remarks>
public record MovingAverageResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MovingAverageResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of moving average values.</param>
    public MovingAverageResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
