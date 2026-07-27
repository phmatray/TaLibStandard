// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Text;

namespace TechnicalAnalysis.Samples.Backtesting;

/// <summary>
/// Runs the sample's whole workload — load or generate the data, backtest every strategy plus the baseline,
/// and format the report — and returns it as text.
/// </summary>
/// <remarks>
/// Keeping this out of <c>Main</c> means the entire sample is exercisable from a test without touching the
/// console.
/// </remarks>
public static class BacktestSampleRunner
{
    /// <summary>
    /// Builds the strategy line-up the sample compares: four indicator strategies followed by the
    /// buy-and-hold baseline, which is always last so it reads as the reference column.
    /// </summary>
    /// <returns>A fresh list of strategy instances.</returns>
    public static IReadOnlyList<IStrategy> CreateStrategies()
    {
        return
        [
            new SmaCrossoverStrategy(20, 50),
            new RsiMeanReversionStrategy(),
            new MacdTrendStrategy(),
            new BollingerBreakoutStrategy(),
            new BuyAndHoldStrategy()
        ];
    }

    /// <summary>
    /// Loads the bar series described by the command line: the CSV file when one was given, otherwise a
    /// deterministic synthetic series.
    /// </summary>
    /// <param name="options">The parsed command line.</param>
    /// <param name="description">Receives a short human-readable description of the data source.</param>
    /// <returns>The bar series.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">The CSV file does not exist.</exception>
    /// <exception cref="FormatException">The CSV file is malformed.</exception>
    public static IReadOnlyList<Bar> LoadBars(CommandLineOptions options, out string description)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (options.CsvPath is { } path)
        {
            IReadOnlyList<Bar> bars = CsvBarLoader.LoadFile(path);
            description = string.Format(CultureInfo.InvariantCulture, "CSV file '{0}'", path);
            return bars;
        }

        description = string.Format(
            CultureInfo.InvariantCulture,
            "deterministic synthetic series (seed {0})",
            options.Seed);

        return SyntheticSeriesGenerator.Generate(
            options.BarCount,
            options.Seed,
            barsPerYear: options.Backtest.BarsPerYear);
    }

    /// <summary>
    /// Runs every strategy over the same series with the same engine settings.
    /// </summary>
    /// <param name="strategies">The strategies to run.</param>
    /// <param name="bars">The bar series.</param>
    /// <param name="options">The engine settings.</param>
    /// <returns>One result per strategy, in the order the strategies were supplied.</returns>
    /// <exception cref="ArgumentNullException">Any argument is <see langword="null"/>.</exception>
    public static IReadOnlyList<BacktestResult> RunAll(
        IReadOnlyList<IStrategy> strategies,
        IReadOnlyList<Bar> bars,
        BacktestOptions options)
    {
        ArgumentNullException.ThrowIfNull(strategies);
        ArgumentNullException.ThrowIfNull(bars);
        ArgumentNullException.ThrowIfNull(options);

        BacktestEngine engine = new(options);
        List<BacktestResult> results = new(strategies.Count);

        foreach (IStrategy strategy in strategies)
        {
            results.Add(engine.Run(strategy, bars));
        }

        return results;
    }

    /// <summary>
    /// Produces the complete report the sample prints.
    /// </summary>
    /// <param name="options">The parsed command line.</param>
    /// <returns>The report text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">The CSV file does not exist.</exception>
    /// <exception cref="FormatException">The CSV file is malformed.</exception>
    public static string Run(CommandLineOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        IReadOnlyList<Bar> bars = LoadBars(options, out string dataDescription);
        IReadOnlyList<string> problems = CsvBarLoader.Validate(bars);

        StringBuilder builder = new();
        builder.Append(ConsoleReport.RenderConfiguration(options.Backtest, bars.Count, dataDescription));

        if (problems.Count > 0)
        {
            builder.Append(Environment.NewLine).Append("  Data warnings:").Append(Environment.NewLine);
            foreach (string problem in problems.Take(5))
            {
                builder.Append("    - ").Append(problem).Append(Environment.NewLine);
            }
        }

        if (bars.Count == 0)
        {
            builder.Append(Environment.NewLine)
                .Append("The bar series is empty; there is nothing to backtest.")
                .Append(Environment.NewLine);
            return builder.ToString();
        }

        IReadOnlyList<IStrategy> strategies = CreateStrategies();
        IReadOnlyList<BacktestResult> results = RunAll(strategies, bars, options.Backtest);

        for (int i = 0; i < results.Count; i++)
        {
            builder.Append(ConsoleReport.RenderStrategyCard(results[i], strategies[i].Description));

            if (options.ShowTradeLog)
            {
                builder.Append(ConsoleReport.RenderTradeLog(results[i]));
            }
        }

        builder.Append(ConsoleReport.RenderComparison(results));

        return builder.ToString();
    }
}
