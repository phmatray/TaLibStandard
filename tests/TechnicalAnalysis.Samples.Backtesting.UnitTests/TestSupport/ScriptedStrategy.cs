// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.TestSupport;

/// <summary>
/// A strategy whose signal on each bar is dictated by the test, so the engine's execution and accounting can
/// be checked against arithmetic done by hand.
/// </summary>
internal sealed class ScriptedStrategy : IStrategy
{
    private readonly Func<IBarWindow, Position?, Signal> _script;

    internal ScriptedStrategy(Func<IBarWindow, Position?, Signal> script, string name = "Scripted")
    {
        _script = script;
        Name = name;
    }

    /// <summary>
    /// Creates a strategy that emits a specific signal on specific bar indices and holds everywhere else.
    /// </summary>
    internal static ScriptedStrategy At(IReadOnlyDictionary<int, Signal> signals, string name = "Scripted")
    {
        return new ScriptedStrategy(
            (bars, _) => signals.TryGetValue(bars.CurrentIndex, out Signal signal) ? signal : Signal.Hold,
            name);
    }

    public string Name { get; }

    public string Description => "Test double whose signals are supplied by the test.";

    /// <summary>
    /// Gets the bar indices <see cref="Evaluate"/> was called on, in call order.
    /// </summary>
    internal List<int> ObservedIndices { get; } = [];

    /// <summary>
    /// Gets the number of visible bars reported by the window on each call, in call order.
    /// </summary>
    internal List<int> ObservedCounts { get; } = [];

    public void Initialize(IIndicatorSource indicators)
    {
        ObservedIndices.Clear();
        ObservedCounts.Clear();
    }

    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        ObservedIndices.Add(bars.CurrentIndex);
        ObservedCounts.Add(bars.Count);
        return _script(bars, position);
    }
}
