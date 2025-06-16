// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Stochastic Oscillator (Stoch) indicator calculation.
/// The Stochastic Oscillator is a momentum indicator that shows the location of the close relative to the high-low range over a set number of periods.
/// </summary>
public record StochResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StochResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="slowK">The array containing the %K line values (smoothed).</param>
    /// <param name="slowD">The array containing the %D line values (signal line).</param>
    public StochResult(RetCode retCode, int begIdx, int nbElement, double[] slowK, double[] slowD)
        : base(retCode, begIdx, nbElement)
    {
        SlowK = slowK;
        SlowD = slowD;
    }

    /// <summary>
    /// Gets the array of Slow %D values (signal line).
    /// This is a moving average of the Slow %K line, typically used to generate trading signals.
    /// Buy signals often occur when %K crosses above %D, and sell signals when %K crosses below %D.
    /// </summary>
    public double[] SlowD { get; }

    /// <summary>
    /// Gets the array of Slow %K values.
    /// Values range from 0 to 100. Readings above 80 indicate overbought conditions, while readings below 20 indicate oversold conditions.
    /// The Slow %K is a smoothed version of the Fast %K, reducing false signals.
    /// </summary>
    public double[] SlowK { get; }
}
