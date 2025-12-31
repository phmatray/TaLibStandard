// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Typical Price calculation.
/// </summary>
/// <remarks>
/// The Typical Price is a price transformation that represents the average price of a
/// trading period, calculated as the arithmetic mean of the high, low, and close prices.
/// It is widely used as a more representative single price point than just the closing
/// price, as it incorporates the entire trading range. The formula is: (High + Low + Close) / 3.
/// This price is often used as the basis for other indicators like Money Flow Index and
/// Commodity Channel Index.
/// </remarks>
public record TypPriceResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TypPriceResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated typical price values.</param>
    public TypPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
