// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Parabolic Stop and Reverse (SAR) calculation.
/// This indicator provides trailing stop-loss points that follow the price trend, helping traders
/// identify potential reversal points and manage risk in trending markets.
/// </summary>
public record SarResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SarResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of SAR values representing stop-loss levels for each period.</param>
    public SarResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Parabolic SAR values.
    /// Each value represents a stop-loss level that trails the price. When price is above SAR,
    /// the trend is bullish; when below, it's bearish. SAR flips sides when price crosses it.
    /// </summary>
    public double[] Real { get; }
}
