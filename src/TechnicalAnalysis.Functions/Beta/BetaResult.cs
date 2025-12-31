// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Beta coefficient calculation.
/// </summary>
/// <remarks>
/// Beta is a statistical measure that compares the volatility of a security or portfolio
/// to the volatility of a benchmark (typically a market index). It measures the systematic
/// risk of an investment. A beta of 1.0 indicates the security moves in line with the market,
/// greater than 1.0 indicates higher volatility than the market, and less than 1.0 indicates
/// lower volatility. Negative beta indicates inverse correlation with the market. Beta is
/// fundamental in the Capital Asset Pricing Model (CAPM) for calculating expected returns.
/// </remarks>
public record BetaResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BetaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated beta coefficient values.</param>
    public BetaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
