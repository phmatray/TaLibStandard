// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Average Price calculation.
/// </summary>
/// <remarks>
/// The Average Price is a simple price transformation that calculates the arithmetic mean
/// of the high, low, close, and open prices for each period. This provides a single value
/// that represents the average trading price for the period, smoothing out price fluctuations
/// and potentially providing a clearer view of the overall price trend. It is calculated as:
/// (High + Low + Close + Open) / 4.
/// </remarks>
public record AvgPriceResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AvgPriceResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated average price values.</param>
    public AvgPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
