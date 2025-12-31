// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Zig Zag indicator.
/// </summary>
/// <remarks>
/// The Zig Zag indicator filters out price movements smaller than a specified percentage,
/// connecting significant peaks and troughs with straight lines. It helps identify trend
/// reversals and eliminates random price fluctuations, making it easier to see the underlying
/// price structure and major support/resistance levels.
/// </remarks>
public record ZigZagResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ZigZagResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Zig Zag values at reversal points.</param>
    public ZigZagResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}