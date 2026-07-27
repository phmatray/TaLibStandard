// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Strategies;

/// <summary>
/// A trading rule: it declares the indicators it needs once, then emits a target exposure after each bar
/// closes.
/// </summary>
/// <remarks>
/// <para>
/// The contract is deliberately narrow so that look-ahead bias cannot be written even by accident. A strategy
/// never receives the bar series — only an <see cref="IBarWindow"/> that stops at the current bar and
/// <see cref="IndicatorSeries"/> instances bound to the same cursor. Both throw
/// <see cref="LookAheadException"/> on a future index.
/// </para>
/// <para>
/// A strategy may hold mutable state across bars (a trailing stop, for example), but that state must be reset
/// in <see cref="Initialize"/>, because the same instance may be run over several series.
/// </para>
/// </remarks>
public interface IStrategy
{
    /// <summary>
    /// Gets the short display name used in reports, for example <c>"SMA 50/200 crossover"</c>.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets a one-line description of the entry and exit rules, shown above the metrics table.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Called once before the first bar. Resolve indicators here and reset any per-run state.
    /// </summary>
    /// <param name="indicators">The factory used to declare the indicators the strategy needs.</param>
    void Initialize(IIndicatorSource indicators);

    /// <summary>
    /// Called once per bar, after the bar has closed, with the window positioned on that bar. The returned
    /// signal is executed at the <em>open of the next bar</em> — never on the bar that produced it.
    /// </summary>
    /// <param name="bars">The causal price view, positioned on the bar that just closed.</param>
    /// <param name="position">The position currently open, or <see langword="null"/> when flat.</param>
    /// <returns>The target exposure the strategy wants from the next bar onwards.</returns>
    Signal Evaluate(IBarWindow bars, Position? position);
}
