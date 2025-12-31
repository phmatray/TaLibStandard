// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Rate of Change Ratio (ROCR) indicator.
/// </summary>
/// <remarks>
/// The Rate of Change Ratio measures the ratio between the current price and the price n periods ago.
/// Unlike the standard ROC which shows percentage change, ROCR shows the price ratio, making it useful
/// for comparing relative strength and identifying momentum changes in price movements.
/// </remarks>
public record RocRResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RocRResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Rate of Change Ratio values.</param>
    public RocRResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
