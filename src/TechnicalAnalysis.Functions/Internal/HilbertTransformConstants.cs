// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Contains constants used in Hilbert Transform calculations.
/// </summary>
/// <remarks>
/// These constants are derived from John Ehlers' Hilbert Transform algorithms
/// and are used across all Hilbert Transform indicators (HT_DCPERIOD, HT_DCPHASE,
/// HT_PHASOR, HT_SINE, HT_TRENDLINE, HT_TRENDMODE) and the MAMA indicator.
/// </remarks>
internal static class HilbertTransformConstants
{
    /// <summary>
    /// Hilbert Transform smoothing coefficient A.
    /// Used in the detrending and quadrature calculations.
    /// </summary>
    public const double A = 0.0962;

    /// <summary>
    /// Hilbert Transform smoothing coefficient B.
    /// Used in the detrending and quadrature calculations.
    /// </summary>
    public const double B = 0.5769;
}
