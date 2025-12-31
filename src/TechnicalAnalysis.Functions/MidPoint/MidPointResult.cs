// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the MidPoint indicator.
/// </summary>
/// <remarks>
/// The MidPoint indicator calculates the midpoint between the highest and lowest values
/// over a specified period. It represents the center of the price range and can be used
/// as a simple trend indicator or as a component in other technical analysis calculations.
/// </remarks>
public record MidPointResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MidPointResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of midpoint values calculated as (highest + lowest) / 2.</param>
    public MidPointResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
