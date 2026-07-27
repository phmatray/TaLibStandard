// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.TestSupport;

/// <summary>
/// A strategy that reads tomorrow's bar and buys whenever tomorrow closes higher — the canonical look-ahead
/// bug. It must be impossible to run.
/// </summary>
internal sealed class FutureBarPeekingStrategy : IStrategy
{
    private readonly int _peekOffset;

    internal FutureBarPeekingStrategy(int peekOffset = 1)
    {
        _peekOffset = peekOffset;
    }

    public string Name => "Cheater (reads a future bar)";

    public string Description => "Reads the close of a bar that has not happened yet.";

    public void Initialize(IIndicatorSource indicators)
    {
    }

    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        Bar tomorrow = bars[bars.CurrentIndex + _peekOffset];
        return tomorrow.Close > bars.Current.Close ? Signal.EnterLong : Signal.Exit;
    }
}

/// <summary>
/// A strategy that reads a future value of an indicator rather than of a bar. An indicator computed from
/// tomorrow's close is exactly as fatal as tomorrow's close itself, so this must fail too.
/// </summary>
internal sealed class FutureIndicatorPeekingStrategy : IStrategy
{
    private IndicatorSeries? _sma;

    public string Name => "Cheater (reads a future indicator value)";

    public string Description => "Reads an indicator value belonging to a bar that has not happened yet.";

    public void Initialize(IIndicatorSource indicators)
    {
        _sma = indicators.Sma(3);
    }

    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        return _sma!.TryGetValue(bars.CurrentIndex + 1, out double future) && future > bars.Current.Close
            ? Signal.EnterLong
            : Signal.Hold;
    }
}

/// <summary>
/// A strategy that tries to discover how long the series is by walking forward until something stops it.
/// The window must stop it on the very first step past the current bar.
/// </summary>
internal sealed class SeriesLengthProbingStrategy : IStrategy
{
    public string Name => "Cheater (probes the series length)";

    public string Description => "Walks forward past the current bar to discover the length of the series.";

    public void Initialize(IIndicatorSource indicators)
    {
    }

    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        int probe = bars.CurrentIndex;
        while (true)
        {
            probe++;
            _ = bars[probe];
        }
    }
}

/// <summary>
/// A strategy that tries to learn the total length of the series from an <see cref="IndicatorSeries"/> rather
/// than from the bar window — the same end-of-sample cheat, taken through the back door. The indicator is
/// obtained in <see cref="Initialize"/>, before bar 0 is ever evaluated, which is exactly when knowing the
/// end date would be most valuable and most impossible in live trading.
/// </summary>
internal sealed class IndicatorLengthProbingStrategy : IStrategy
{
    private IndicatorSeries? _sma;

    public string Name => "Cheater (probes an indicator for the series length)";

    public string Description => "Reads IndicatorSeries.Count to discover how many bars exist in total.";

    /// <summary>
    /// Gets the value <c>Count</c> reported in <see cref="Initialize"/>, before any bar was evaluated.
    /// </summary>
    internal int CountAtInitialize { get; private set; } = -1;

    /// <summary>
    /// Gets the <c>Count</c>, <c>BegIdx</c> and <c>NBElement</c> observed on each bar, in call order.
    /// </summary>
    internal List<(int Count, int BegIdx, int NBElement)> Observed { get; } = [];

    public void Initialize(IIndicatorSource indicators)
    {
        Observed.Clear();
        _sma = indicators.Sma(3);
        CountAtInitialize = _sma.Count;
    }

    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        Observed.Add((_sma!.Count, _sma.BegIdx, _sma.NBElement));
        return Signal.Hold;
    }
}

/// <summary>
/// A strategy that binary-searches <see cref="IndicatorSeries.TryGetPair"/> for the end of the series, using
/// the difference between "returned false" and "threw" as an oracle. Every forward index must throw, so the
/// oracle must not exist.
/// </summary>
internal sealed class IndicatorPairProbingStrategy : IStrategy
{
    private IndicatorSeries? _sma;

    public string Name => "Cheater (probes TryGetPair for the series length)";

    public string Description => "Calls TryGetPair far past the current bar to find where the series ends.";

    public void Initialize(IIndicatorSource indicators)
    {
        _sma = indicators.Sma(3);
    }

    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        // A quiet false here would say "past the end of the series"; a throw says "in the future". Only the
        // second answer is allowed, whatever the probe index.
        return _sma!.TryGetPair(bars.CurrentIndex + 1_000_000, out _, out _) ? Signal.EnterLong : Signal.Hold;
    }
}
