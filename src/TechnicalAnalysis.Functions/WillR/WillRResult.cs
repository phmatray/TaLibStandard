// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Williams' %R (WillR) indicator.
/// </summary>
/// <remarks>
/// Williams' %R is a momentum indicator that measures overbought and oversold levels.
/// It compares the closing price to the high-low range over a specific period, typically 14 days.
/// The indicator is similar to the Stochastic Oscillator but uses a different scale.
/// </remarks>
public record WillRResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WillRResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Williams' %R values ranging from -100 to 0.</param>
    public WillRResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Williams' %R values.
    /// </summary>
    /// <remarks>
    /// Values range from -100 to 0, where:
    /// - Values from -20 to 0 indicate overbought conditions
    /// - Values from -100 to -80 indicate oversold conditions
    /// - The negative scale is traditional for Williams' %R (inverse of other oscillators)
    /// </remarks>
    public double[] Real { get; }
}
