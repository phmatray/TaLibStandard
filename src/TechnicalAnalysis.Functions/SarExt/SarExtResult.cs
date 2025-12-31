// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Parabolic SAR Extended (SAREXT) calculation.
/// This is an enhanced version of the standard SAR indicator with additional customization options
/// for acceleration factors and other parameters, providing more flexibility in trend following.
/// </summary>
public record SarExtResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SarExtResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of extended SAR values with customized parameters for stop-loss levels.</param>
    public SarExtResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
