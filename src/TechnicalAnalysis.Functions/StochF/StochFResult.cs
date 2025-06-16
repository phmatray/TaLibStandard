// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Fast Stochastic (StochF) indicator calculation.
/// The Fast Stochastic is a momentum indicator that provides a more responsive version of the standard Stochastic Oscillator.
/// </summary>
public record StochFResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StochFResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="fastK">The array containing the Fast %K line values.</param>
    /// <param name="fastD">The array containing the Fast %D line values (signal line).</param>
    public StochFResult(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
        : base(retCode, begIdx, nbElement)
    {
        FastK = fastK;
        FastD = fastD;
    }

    /// <summary>
    /// Gets the array of Fast %D values (signal line).
    /// This is a moving average of the Fast %K line, used to smooth out the indicator and generate signals.
    /// Crossovers between %K and %D can indicate potential buy or sell opportunities.
    /// </summary>
    public double[] FastD { get; }

    /// <summary>
    /// Gets the array of Fast %K values.
    /// Values range from 0 to 100, calculated as: 100 × (Close - Lowest Low) / (Highest High - Lowest Low).
    /// This raw stochastic value is more sensitive to price changes than the slow version.
    /// </summary>
    public double[] FastK { get; }
}
