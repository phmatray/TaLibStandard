// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Average True Range (ATR) indicator calculation.
/// This volatility indicator measures the average of true ranges over a specified period, providing insight into market volatility.
/// </summary>
public record AtrResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AtrResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated ATR values.</param>
    public AtrResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Average True Range values.
    /// Each value represents the moving average of the True Range, indicating the degree of price volatility.
    /// Higher ATR values indicate higher volatility, while lower values suggest lower volatility.
    /// </summary>
    public double[] Real { get; }
}
