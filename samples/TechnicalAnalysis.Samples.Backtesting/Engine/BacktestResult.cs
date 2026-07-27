// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The complete outcome of one simulation: the equity curve sampled at every bar close, the list of completed
/// round trips, and the performance metrics derived from both.
/// </summary>
public sealed record BacktestResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BacktestResult"/> class.
    /// </summary>
    /// <param name="strategyName">The name of the strategy that produced the result.</param>
    /// <param name="options">The options the simulation ran under.</param>
    /// <param name="equityCurve">The equity curve, one point per bar of the source series.</param>
    /// <param name="trades">The completed round trips, in chronological order.</param>
    /// <param name="metrics">The performance metrics derived from the curve and the trades.</param>
    /// <exception cref="ArgumentNullException">Any argument is <see langword="null"/>.</exception>
    public BacktestResult(
        string strategyName,
        BacktestOptions options,
        IReadOnlyList<EquityPoint> equityCurve,
        IReadOnlyList<Trade> trades,
        PerformanceMetrics metrics)
    {
        ArgumentNullException.ThrowIfNull(strategyName);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(equityCurve);
        ArgumentNullException.ThrowIfNull(trades);
        ArgumentNullException.ThrowIfNull(metrics);

        StrategyName = strategyName;
        Options = options;
        EquityCurve = equityCurve;
        Trades = trades;
        Metrics = metrics;
    }

    /// <summary>
    /// Gets the name of the strategy that produced the result.
    /// </summary>
    public string StrategyName { get; }

    /// <summary>
    /// Gets the options the simulation ran under.
    /// </summary>
    public BacktestOptions Options { get; }

    /// <summary>
    /// Gets the equity curve, sampled at the close of every bar after that bar's fills.
    /// </summary>
    public IReadOnlyList<EquityPoint> EquityCurve { get; }

    /// <summary>
    /// Gets the completed round trips, in chronological order of their exit.
    /// </summary>
    public IReadOnlyList<Trade> Trades { get; }

    /// <summary>
    /// Gets the performance metrics of the run.
    /// </summary>
    public PerformanceMetrics Metrics { get; }

    /// <summary>
    /// Gets the starting equity of the account.
    /// </summary>
    public double InitialCapital => Options.InitialCapital;

    /// <summary>
    /// Gets the equity at the close of the last bar, or the initial capital when the series was empty.
    /// </summary>
    public double FinalEquity => EquityCurve.Count > 0 ? EquityCurve[^1].Equity : Options.InitialCapital;
}
