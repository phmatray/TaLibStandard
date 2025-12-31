// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Bollinger Bands indicator calculation.
/// Bollinger Bands consist of a middle band (SMA) and two outer bands that represent standard deviations from the middle band, used to measure volatility and identify overbought/oversold conditions.
/// </summary>
public record BollingerBandsResult : TripleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BollingerBandsResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="realUpperBand">The array containing the upper band values.</param>
    /// <param name="realMiddleBand">The array containing the middle band (SMA) values.</param>
    /// <param name="realLowerBand">The array containing the lower band values.</param>
    public BollingerBandsResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] realUpperBand,
        double[] realMiddleBand,
        double[] realLowerBand)
        : base(retCode, begIdx, nbElement, realUpperBand, realMiddleBand, realLowerBand)
    {
    }

    /// <summary>
    /// Gets the array of lower band values.
    /// The lower band is typically calculated as the middle band minus (n × standard deviation).
    /// Prices near or below this band may indicate oversold conditions.
    /// </summary>
    public double[] RealLowerBand => Real2;

    /// <summary>
    /// Gets the array of middle band values.
    /// The middle band is a simple moving average of the specified period.
    /// This band represents the intermediate trend of the price.
    /// </summary>
    public double[] RealMiddleBand => Real1;

    /// <summary>
    /// Gets the array of upper band values.
    /// The upper band is typically calculated as the middle band plus (n × standard deviation).
    /// Prices near or above this band may indicate overbought conditions.
    /// </summary>
    public double[] RealUpperBand => Real0;
}
