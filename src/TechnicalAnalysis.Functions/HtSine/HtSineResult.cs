// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Hilbert Transform - SineWave (HT_SINE) calculation.
/// This indicator generates sine and leading sine wave indicators from price data using Hilbert Transform,
/// useful for identifying cycle turns and generating trading signals in trending markets.
/// </summary>
public record HtSineResult : DualOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtSineResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="sine">The array of sine wave values derived from the dominant cycle.</param>
    /// <param name="leadSine">The array of leading sine wave values, phase-advanced for early signal generation.</param>
    public HtSineResult(RetCode retCode, int begIdx, int nbElement, double[] sine, double[] leadSine)
        : base(retCode, begIdx, nbElement, sine, leadSine)
    {
    }

    /// <summary>
    /// Gets the array of leading sine wave values.
    /// The lead sine is phase-advanced by 45 degrees from the sine wave,
    /// providing early signals for potential cycle turns.
    /// </summary>
    public double[] LeadSine => Real1;

    /// <summary>
    /// Gets the array of sine wave values.
    /// Values oscillate between -1 and +1, representing the smoothed cyclic component of price movement.
    /// Crossovers between sine and lead sine can indicate cycle turning points.
    /// </summary>
    public double[] Sine => Real0;
}
