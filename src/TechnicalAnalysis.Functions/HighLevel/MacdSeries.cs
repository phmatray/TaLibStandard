// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// The three bar-aligned outputs of a MACD calculation.
/// </summary>
/// <param name="Line">
/// The MACD line: the fast exponential moving average minus the slow one. Bar-aligned.
/// </param>
/// <param name="Signal">
/// The signal line: an exponential moving average of <paramref name="Line"/>. Bar-aligned.
/// </param>
/// <param name="Histogram">
/// The histogram: <paramref name="Line"/> minus <paramref name="Signal"/>. Bar-aligned.
/// </param>
/// <remarks>
/// Each component is an independently addressable <see cref="IndicatorSeries"/>, so a signal-line
/// crossing needs no dedicated member: <c>macd.Line.CrossedAbove(macd.Signal, bar)</c> already says
/// it, in bar indices, with the differing warm-ups handled for you.
/// </remarks>
public readonly record struct MacdSeries(IndicatorSeries Line, IndicatorSeries Signal, IndicatorSeries Histogram)
{
    /// <summary>
    /// Narrows every component so that it ends at the given BAR index.
    /// </summary>
    /// <param name="bar">
    /// The last BAR index the narrowed components are allowed to know about, with domain
    /// <c>[0, BarCount)</c> of the components.
    /// </param>
    /// <returns>A result whose three components have each been narrowed by <see cref="IndicatorSeries.AsOf"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is outside the bars the components cover.
    /// </exception>
    public MacdSeries AsOf(int bar)
    {
        return new MacdSeries(Line.AsOf(bar), Signal.AsOf(bar), Histogram.AsOf(bar));
    }
}
