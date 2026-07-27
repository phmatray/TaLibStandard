// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// The two bar-aligned outputs of a stochastic oscillator calculation.
/// </summary>
/// <param name="SlowK">
/// The slow %K line: the smoothed position of the close within the recent high-low range,
/// expressed from 0 to 100. Bar-aligned.
/// </param>
/// <param name="SlowD">
/// The slow %D line: a moving average of <paramref name="SlowK"/>, acting as its signal line.
/// Bar-aligned.
/// </param>
/// <remarks>
/// The component names match <see cref="StochResult"/>, so moving between the raw and fluent layers
/// costs nothing. A %K/%D crossing is <c>stoch.SlowK.CrossedAbove(stoch.SlowD, bar)</c>.
/// </remarks>
public readonly record struct StochSeries(IndicatorSeries SlowK, IndicatorSeries SlowD)
{
    /// <summary>
    /// Narrows both lines so that they end at the given BAR index.
    /// </summary>
    /// <param name="bar">
    /// The last BAR index the narrowed lines are allowed to know about, with domain
    /// <c>[0, BarCount)</c> of the lines.
    /// </param>
    /// <returns>A result whose two lines have each been narrowed by <see cref="IndicatorSeries.AsOf"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is outside the bars the lines cover.
    /// </exception>
    public StochSeries AsOf(int bar)
    {
        return new StochSeries(SlowK.AsOf(bar), SlowD.AsOf(bar));
    }
}
