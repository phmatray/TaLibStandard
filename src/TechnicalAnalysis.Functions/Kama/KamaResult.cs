// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Kaufman Adaptive Moving Average (KAMA) indicator.
/// </summary>
/// <remarks>
/// KAMA is an adaptive moving average designed to account for market noise and volatility.
/// It automatically adjusts its sensitivity based on the efficiency ratio of price movement,
/// moving quickly in trending markets and slowly in ranging markets to reduce whipsaws.
/// </remarks>
public record KamaResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KamaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Kaufman Adaptive Moving Average values.</param>
    public KamaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Kaufman Adaptive Moving Average values.
    /// </summary>
    /// <value>
    /// An array of double values representing the Kaufman Adaptive Moving Average at each data point.
    /// The values adapt to market conditions, providing faster response in trending markets
    /// and slower response in choppy or sideways markets.
    /// </value>
    public double[] Real { get; }
}
