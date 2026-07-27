// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.TestSupport;

/// <summary>
/// Drives a strategy bar by bar exactly the way <see cref="BacktestEngine"/> does — same cursor, same
/// indicator binding — but without the accounting, so a test can assert on the raw signal of a chosen bar.
/// </summary>
internal sealed class StrategyDriver
{
    private readonly IStrategy _strategy;
    private readonly BarWindow _window;

    internal StrategyDriver(IStrategy strategy, IReadOnlyList<Bar> bars)
    {
        _strategy = strategy;
        _window = new BarWindow(bars);
        Indicators = new IndicatorSet(bars, _window);
        _strategy.Initialize(Indicators);
    }

    internal IndicatorSet Indicators { get; }

    internal IBarWindow Window => _window;

    /// <summary>
    /// Moves the cursor to <paramref name="barIndex"/> and returns the signal the strategy emits there.
    /// </summary>
    internal Signal StepTo(int barIndex, Position? position = null)
    {
        _window.MoveTo(barIndex);
        return _strategy.Evaluate(_window, position);
    }

    /// <summary>
    /// Steps through bars <c>0..lastIndex</c> in order, feeding the same fixed position on every bar, and
    /// returns the signal emitted on each one.
    /// </summary>
    internal IReadOnlyList<Signal> StepThrough(int lastIndex, Func<int, Position?>? positionAt = null)
    {
        List<Signal> signals = new(lastIndex + 1);
        for (int i = 0; i <= lastIndex; i++)
        {
            signals.Add(StepTo(i, positionAt?.Invoke(i)));
        }

        return signals;
    }
}
