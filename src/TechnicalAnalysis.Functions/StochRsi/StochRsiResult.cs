// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Stochastic Relative Strength Index (STOCHRSI) calculation.
/// This indicator applies the Stochastic oscillator formula to RSI values, creating a more sensitive
/// momentum oscillator that combines the benefits of both indicators.
/// </summary>
public record StochRsiResult : DualOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StochRsiResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="fastK">The array of %K values representing the raw stochastic of RSI.</param>
    /// <param name="fastD">The array of %D values representing the smoothed %K line.</param>
    public StochRsiResult(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
        : base(retCode, begIdx, nbElement, fastK, fastD)
    {
    }

    /// <summary>
    /// Gets the array of %D values (smoothed %K).
    /// This is typically a 3-period moving average of %K, providing a smoother signal line.
    /// Values range from 0 to 100, with readings above 80 indicating overbought and below 20 indicating oversold.
    /// </summary>
    public double[] FastD => Real1;

    /// <summary>
    /// Gets the array of %K values (raw StochRSI).
    /// This represents the position of the current RSI relative to its range over the lookback period.
    /// Values range from 0 to 100, with extreme readings suggesting potential reversal points.
    /// </summary>
    public double[] FastK => Real0;
}
