// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Hilbert Transform - Phasor Components (HT_PHASOR) calculation.
/// This indicator decomposes price data into its in-phase and quadrature components using Hilbert Transform,
/// providing a complex representation of market cycles for advanced signal processing.
/// </summary>
public record HtPhasorResult : DualOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtPhasorResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="inPhase">The array of in-phase component values representing the real part of the complex signal.</param>
    /// <param name="quadrature">The array of quadrature component values representing the imaginary part of the complex signal.</param>
    public HtPhasorResult(RetCode retCode, int begIdx, int nbElement, double[] inPhase, double[] quadrature)
        : base(retCode, begIdx, nbElement, inPhase, quadrature)
    {
    }

    /// <summary>
    /// Gets the array of in-phase component values.
    /// The in-phase component represents the real part of the Hilbert Transform output,
    /// aligned with the original signal's phase.
    /// </summary>
    public double[] InPhase => Real0;

    /// <summary>
    /// Gets the array of quadrature component values.
    /// The quadrature component represents the imaginary part of the Hilbert Transform output,
    /// phase-shifted by 90 degrees from the original signal.
    /// </summary>
    public double[] Quadrature => Real1;
}
