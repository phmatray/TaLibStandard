// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating a Moving Average with Variable Period (MAVP) indicator.
/// </summary>
/// <remarks>
/// The Moving Average Variable Period indicator is an adaptive moving average that dynamically
/// adjusts its lookback period based on an external input array. This allows the moving average
/// to become more or less responsive to price changes based on market conditions or other indicators,
/// providing a more flexible smoothing mechanism than fixed-period moving averages.
/// </remarks>
public record MovingAverageVariablePeriodResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MovingAverageVariablePeriodResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of variable period moving average values.</param>
    public MovingAverageVariablePeriodResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
