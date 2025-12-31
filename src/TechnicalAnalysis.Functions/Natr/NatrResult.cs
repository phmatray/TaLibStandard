// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Normalized Average True Range (NATR) indicator.
/// </summary>
/// <remarks>
/// The Normalized Average True Range is a volatility indicator that expresses the Average True Range (ATR)
/// as a percentage of the closing price. This normalization allows for better comparison of volatility
/// across different price levels and between different securities.
/// </remarks>
public record NatrResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NatrResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Normalized Average True Range values expressed as percentages.</param>
    public NatrResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
