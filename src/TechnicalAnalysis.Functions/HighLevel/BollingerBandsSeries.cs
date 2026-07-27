// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// The three bar-aligned bands of a Bollinger Bands calculation.
/// </summary>
/// <param name="Upper">
/// The upper band: the middle band plus the requested number of standard deviations. Bar-aligned.
/// </param>
/// <param name="Middle">
/// The middle band: the moving average of the closing prices. Bar-aligned.
/// </param>
/// <param name="Lower">
/// The lower band: the middle band minus the requested number of standard deviations. Bar-aligned.
/// </param>
/// <remarks>
/// Each band is an independently addressable <see cref="IndicatorSeries"/>. Derived measures such
/// as %B or bandwidth are deliberately not provided: they are arithmetic on three numbers the
/// caller already has, and every convention for them is an opinion.
/// </remarks>
public readonly record struct BollingerBandsSeries(IndicatorSeries Upper, IndicatorSeries Middle, IndicatorSeries Lower)
{
    /// <summary>
    /// Narrows every band so that it ends at the given BAR index.
    /// </summary>
    /// <param name="bar">
    /// The last BAR index the narrowed bands are allowed to know about, with domain
    /// <c>[0, BarCount)</c> of the bands.
    /// </param>
    /// <returns>A result whose three bands have each been narrowed by <see cref="IndicatorSeries.AsOf"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is outside the bars the bands cover.
    /// </exception>
    public BollingerBandsSeries AsOf(int bar)
    {
        return new BollingerBandsSeries(Upper.AsOf(bar), Middle.AsOf(bar), Lower.AsOf(bar));
    }
}
