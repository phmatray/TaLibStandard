// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector multiplication operation (MULT function).
/// </summary>
/// <remarks>
/// The MULT function performs element-wise multiplication of two input arrays,
/// producing an output array where each element is the product of the corresponding
/// elements from the input arrays.
/// </remarks>
public record MultResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MultResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the product values from the multiplication operation.</param>
    public MultResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
