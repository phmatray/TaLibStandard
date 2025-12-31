// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Accumulation/Distribution Line (A/D) indicator calculation.
/// </summary>
/// <remarks>
/// The A/D Line is a volume-based indicator that measures the cumulative flow of money into 
/// and out of a security. It combines price and volume to show how money may be flowing 
/// into or out of a stock. Rising A/D values indicate accumulation (buying pressure), 
/// while falling values indicate distribution (selling pressure).
/// </remarks>
public record AdResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated A/D Line values.</param>
    public AdResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
