// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// A read-only, strictly causal view over the price series: everything up to and including the current bar,
/// and nothing beyond it.
/// </summary>
/// <remarks>
/// <para>
/// This is the only channel through which a strategy sees prices, and it is the structural half of the
/// no-look-ahead guarantee. Three properties make peeking impossible rather than merely discouraged:
/// </para>
/// <list type="number">
/// <item>
/// <description>
/// <see cref="Count"/> reports the number of <em>visible</em> bars, so the total length of the series never
/// leaks. <see cref="IndicatorSeries.Count"/> is window-relative for the same reason.
/// </description>
/// </item>
/// <item>
/// <description>
/// Any index strictly greater than <see cref="CurrentIndex"/> throws <see cref="LookAheadException"/>, even
/// when a bar exists there — and it is thrown in preference to an out-of-range error, so the two answers
/// cannot be told apart and used to locate the end of the series.
/// </description>
/// </item>
/// <item>
/// <description>
/// No member returns the backing collection, so the future cannot be reached indirectly.
/// </description>
/// </item>
/// </list>
/// </remarks>
public interface IBarWindow
{
    /// <summary>
    /// Gets the index of the bar currently being evaluated. This is the newest readable index.
    /// </summary>
    int CurrentIndex { get; }

    /// <summary>
    /// Gets the number of visible bars, equal to <c>CurrentIndex + 1</c>. Bars beyond this point exist in
    /// the source series but are deliberately not observable.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Gets the bar currently being evaluated, that is the bar at <see cref="CurrentIndex"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">The window is not positioned on a bar yet.</exception>
    Bar Current { get; }

    /// <summary>
    /// Gets the bar at an absolute index in the source series.
    /// </summary>
    /// <param name="index">The absolute bar index. Must be in <c>[0, CurrentIndex]</c>.</param>
    /// <returns>The requested bar.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is negative.</exception>
    /// <exception cref="LookAheadException"><paramref name="index"/> is greater than <see cref="CurrentIndex"/>.</exception>
    Bar this[int index] { get; }

    /// <summary>
    /// Gets a bar counted backwards from the current one.
    /// </summary>
    /// <param name="offset">
    /// The number of bars to step back. <c>0</c> is the current bar, <c>1</c> the previous one.
    /// </param>
    /// <returns>The requested bar.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="offset"/> is negative or steps before the start of the series.
    /// </exception>
    Bar Ago(int offset);
}
