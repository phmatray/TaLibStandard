// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Hilbert Transform - Dominant Cycle Phase (HT_DCPHASE) calculation.
/// This indicator measures the phase angle of the dominant market cycle using Hilbert Transform techniques,
/// helping to identify the current position within a price cycle.
/// </summary>
public record HtDcPhaseResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtDcPhaseResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of phase angle values in degrees, indicating the current position within the dominant cycle.</param>
    public HtDcPhaseResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of dominant cycle phase values.
    /// Each value represents the phase angle in degrees (-180 to +180) of the dominant cycle.
    /// Positive values indicate the cycle is in an upward phase, while negative values indicate a downward phase.
    /// </summary>
    public double[] Real { get; }
}
