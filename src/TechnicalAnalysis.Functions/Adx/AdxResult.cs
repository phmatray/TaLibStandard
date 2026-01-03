// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of an ADX (Average Directional Index) calculation.
/// </summary>
public record AdxResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the AdxResult record.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid value in the output array.</param>
    /// <param name="nbElement">The number of valid values in the output array.</param>
    /// <param name="real">The array containing the calculated ADX values.</param>
    public AdxResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
