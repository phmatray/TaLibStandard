// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Text;

namespace TechnicalAnalysis.Samples.Backtesting.Reporting;

/// <summary>
/// Formats backtest results as plain text: a per-strategy metrics card, a side-by-side comparison table and a
/// trade-log excerpt.
/// </summary>
/// <remarks>
/// Every method returns a string rather than writing to the console, so the output can be asserted in tests,
/// written to a file or piped somewhere else. All formatting is invariant-culture, so the numbers are the
/// same on every machine.
/// </remarks>
public static class ConsoleReport
{
    private const int MetricLabelWidth = 26;
    private const int MetricValueWidth = 16;

    /// <summary>
    /// Renders the run configuration: capital, frictions, sizing policy and annualisation constant.
    /// </summary>
    /// <param name="options">The options the runs were executed with.</param>
    /// <param name="barCount">The number of bars in the series.</param>
    /// <param name="dataSource">A short description of where the bars came from.</param>
    /// <returns>The formatted header block.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="options"/> or <paramref name="dataSource"/> is <see langword="null"/>.
    /// </exception>
    public static string RenderConfiguration(BacktestOptions options, int barCount, string dataSource)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(dataSource);

        StringBuilder builder = new();
        AppendRule(builder, "RUN CONFIGURATION");

        string sizing = options.Sizing == PositionSizing.FixedFraction
            ? string.Format(CultureInfo.InvariantCulture, "fixed fraction {0:P0} of equity", options.PositionFraction)
            : string.Format(CultureInfo.InvariantCulture, "fixed cash {0:N0} per position", options.PositionCash);

        AppendField(builder, "Data", dataSource);
        AppendField(builder, "Bars", barCount.ToString("N0", CultureInfo.InvariantCulture));
        AppendField(builder, "Initial capital", options.InitialCapital.ToString("N2", CultureInfo.InvariantCulture));
        AppendField(builder, "Commission", string.Format(CultureInfo.InvariantCulture, "{0:0.##} bp per fill", options.CommissionBps));
        AppendField(builder, "Slippage", string.Format(CultureInfo.InvariantCulture, "{0:0.##} bp per fill", options.SlippageBps));
        AppendField(builder, "Position sizing", sizing);
        AppendField(builder, "Short selling", options.AllowShort ? "enabled" : "disabled (short signals go flat)");
        AppendField(builder, "Annualisation", string.Format(CultureInfo.InvariantCulture, "{0} bars per year", options.BarsPerYear));

        return Normalise(builder);
    }

    /// <summary>
    /// Renders a full card for a single run: the strategy's rules, its metrics and its equity curve.
    /// </summary>
    /// <param name="result">The run to report on.</param>
    /// <param name="description">The strategy's entry and exit rules, shown under the title.</param>
    /// <param name="curveWidth">The width of the ASCII equity curve, in characters.</param>
    /// <param name="curveHeight">The height of the ASCII equity curve, in rows.</param>
    /// <returns>The formatted card.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="result"/> or <paramref name="description"/> is <see langword="null"/>.
    /// </exception>
    public static string RenderStrategyCard(BacktestResult result, string description, int curveWidth = 78, int curveHeight = 12)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(description);

        StringBuilder builder = new();
        AppendRule(builder, result.StrategyName.ToUpperInvariant());
        builder.Append(description).Append('\n').Append('\n');
        builder.Append(RenderMetrics(result.Metrics)).Append('\n');
        builder.Append("Equity curve (initial capital = 100)").Append('\n');
        builder.Append(AsciiEquityCurve.Render(result.EquityCurve, curveWidth, curveHeight)).Append('\n');

        return Normalise(builder);
    }

    /// <summary>
    /// Renders a two-column metrics table for one run.
    /// </summary>
    /// <param name="metrics">The metrics to render.</param>
    /// <returns>The formatted table.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="metrics"/> is <see langword="null"/>.</exception>
    public static string RenderMetrics(PerformanceMetrics metrics)
    {
        ArgumentNullException.ThrowIfNull(metrics);

        StringBuilder builder = new();
        foreach (MetricRow row in MetricRows)
        {
            builder
                .Append("  ")
                .Append(row.Label.PadRight(MetricLabelWidth))
                .Append(row.Format(metrics).PadLeft(MetricValueWidth))
                .Append('\n');
        }

        return Normalise(builder);
    }

    /// <summary>
    /// Renders a side-by-side comparison of several runs, one column per strategy, and marks the best value
    /// of each row with a leading <c>*</c>.
    /// </summary>
    /// <param name="results">The runs to compare, in display order. Put the baseline last for readability.</param>
    /// <returns>The formatted comparison table.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="results"/> is <see langword="null"/>.</exception>
    public static string RenderComparison(IReadOnlyList<BacktestResult> results)
    {
        ArgumentNullException.ThrowIfNull(results);

        if (results.Count == 0)
        {
            return "(nothing to compare)";
        }

        int columnWidth = 2;
        foreach (BacktestResult result in results)
        {
            columnWidth = Math.Max(columnWidth, result.StrategyName.Length);
        }

        columnWidth = Math.Max(columnWidth, MetricValueWidth - 2) + 2;

        StringBuilder builder = new();
        AppendRule(builder, "SIDE-BY-SIDE COMPARISON");

        builder.Append("Metric".PadRight(MetricLabelWidth));
        foreach (BacktestResult result in results)
        {
            builder.Append(result.StrategyName.PadLeft(columnWidth));
        }

        builder.Append('\n');
        builder.Append(new string('-', MetricLabelWidth + (columnWidth * results.Count))).Append('\n');

        foreach (MetricRow row in MetricRows)
        {
            int bestIndex = row.FindBest(results);

            builder.Append(row.Label.PadRight(MetricLabelWidth));
            for (int i = 0; i < results.Count; i++)
            {
                string cell = row.Format(results[i].Metrics);
                string marked = i == bestIndex ? "* " + cell : cell;
                builder.Append(marked.PadLeft(columnWidth));
            }

            builder.Append('\n');
        }

        builder.Append('\n').Append("  * marks the best value of the row.").Append('\n');

        return Normalise(builder);
    }

    /// <summary>
    /// Renders the first few completed round trips of a run, so the reader can sanity-check the fills.
    /// </summary>
    /// <param name="result">The run whose trades to list.</param>
    /// <param name="maxTrades">The maximum number of trades to show. Defaults to <c>10</c>.</param>
    /// <returns>The formatted trade log.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="result"/> is <see langword="null"/>.</exception>
    public static string RenderTradeLog(BacktestResult result, int maxTrades = 10)
    {
        ArgumentNullException.ThrowIfNull(result);

        StringBuilder builder = new();
        AppendRule(builder, string.Format(CultureInfo.InvariantCulture, "TRADE LOG - {0}", result.StrategyName.ToUpperInvariant()));

        if (result.Trades.Count == 0)
        {
            builder.Append("  (no completed round trips)").Append('\n');
            return Normalise(builder);
        }

        builder
            .Append("  ")
            .Append("Side".PadRight(6))
            .Append("Entry".PadRight(13))
            .Append("Exit".PadRight(13))
            .Append("Entry px".PadLeft(11))
            .Append("Exit px".PadLeft(11))
            .Append("Qty".PadLeft(11))
            .Append("Fees".PadLeft(10))
            .Append("Net P&L".PadLeft(13))
            .Append("Bars".PadLeft(7))
            .Append('\n');

        int shown = Math.Min(maxTrades, result.Trades.Count);
        for (int i = 0; i < shown; i++)
        {
            Trade trade = result.Trades[i];
            builder
                .Append("  ")
                .Append((trade.IsLong ? "LONG" : "SHORT").PadRight(6))
                .Append(trade.EntryTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).PadRight(13))
                .Append(trade.ExitTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).PadRight(13))
                .Append(trade.EntryPrice.ToString("N2", CultureInfo.InvariantCulture).PadLeft(11))
                .Append(trade.ExitPrice.ToString("N2", CultureInfo.InvariantCulture).PadLeft(11))
                .Append(trade.Quantity.ToString("N2", CultureInfo.InvariantCulture).PadLeft(11))
                .Append(trade.Commission.ToString("N2", CultureInfo.InvariantCulture).PadLeft(10))
                .Append(trade.NetProfit.ToString("N2", CultureInfo.InvariantCulture).PadLeft(13))
                .Append(trade.BarsHeld.ToString(CultureInfo.InvariantCulture).PadLeft(7))
                .Append('\n');
        }

        if (result.Trades.Count > shown)
        {
            builder
                .Append("  ... ")
                .Append((result.Trades.Count - shown).ToString(CultureInfo.InvariantCulture))
                .Append(" more round trip(s) not shown.")
                .Append('\n');
        }

        return Normalise(builder);
    }

    private static void AppendRule(StringBuilder builder, string title)
    {
        builder.Append('\n').Append(new string('=', 100)).Append('\n');
        builder.Append(title).Append('\n');
        builder.Append(new string('=', 100)).Append('\n');
    }

    private static void AppendField(StringBuilder builder, string label, string value)
    {
        builder.Append("  ").Append((label + ':').PadRight(MetricLabelWidth)).Append(value).Append('\n');
    }

    /// <summary>
    /// Converts the single '\n' used while composing into the platform newline. Fragments produced by other
    /// renderers are already platform-normalised, so any CRLF is folded back first — otherwise a second pass
    /// on Windows would turn "\r\n" into "\r\r\n".
    /// </summary>
    private static string Normalise(StringBuilder builder)
    {
        return builder
            .ToString()
            .Replace("\r\n", "\n", StringComparison.Ordinal)
            .Replace("\n", Environment.NewLine, StringComparison.Ordinal);
    }

    private static string Percent(double value)
    {
        return double.IsFinite(value)
            ? (value * 100.0).ToString("F2", CultureInfo.InvariantCulture) + " %"
            : "n/a";
    }

    private static string Ratio(double value)
    {
        if (double.IsPositiveInfinity(value))
        {
            return "inf";
        }

        return double.IsFinite(value) ? value.ToString("F2", CultureInfo.InvariantCulture) : "n/a";
    }

    private static string Money(double value)
    {
        return double.IsFinite(value) ? value.ToString("N2", CultureInfo.InvariantCulture) : "n/a";
    }

    private static string Count(double value)
    {
        return value.ToString("N0", CultureInfo.InvariantCulture);
    }

    private static readonly MetricRow[] MetricRows =
    [
        new("Final equity", m => Money(m.FinalEquity), m => m.FinalEquity, true),
        new("Total return", m => Percent(m.TotalReturn), m => m.TotalReturn, true),
        new("CAGR", m => Percent(m.Cagr), m => m.Cagr, true),
        new("Annualised volatility", m => Percent(m.AnnualizedVolatility), m => m.AnnualizedVolatility, false),
        new("Max drawdown", m => Percent(m.MaxDrawdown), m => m.MaxDrawdown, false),
        new("Max DD duration (bars)", m => Count(m.MaxDrawdownDurationBars), m => m.MaxDrawdownDurationBars, false),
        new("Sharpe", m => Ratio(m.Sharpe), m => m.Sharpe, true),
        new("Sortino", m => Ratio(m.Sortino), m => m.Sortino, true),
        new("Calmar", m => Ratio(m.Calmar), m => m.Calmar, true),
        new("Trades", m => Count(m.TradeCount), m => m.TradeCount, null),
        new("Win rate", m => Percent(m.WinRate), m => m.WinRate, true),
        new("Profit factor", m => Ratio(m.ProfitFactor), m => m.ProfitFactor, true),
        new("Average win", m => Money(m.AverageWin), m => m.AverageWin, true),
        new("Average loss", m => Money(m.AverageLoss), m => m.AverageLoss, true),
        new("Expectancy / trade", m => Money(m.Expectancy), m => m.Expectancy, true),
        new("Exposure", m => Percent(m.Exposure), m => m.Exposure, null)
    ];

    private sealed record MetricRow(
        string Label,
        Func<PerformanceMetrics, string> Format,
        Func<PerformanceMetrics, double> Value,
        bool? HigherIsBetter)
    {
        public int FindBest(IReadOnlyList<BacktestResult> results)
        {
            if (HigherIsBetter is not { } higherIsBetter || results.Count < 2)
            {
                return -1;
            }

            int bestIndex = -1;
            double best = 0.0;

            for (int i = 0; i < results.Count; i++)
            {
                double value = Value(results[i].Metrics);
                if (double.IsNaN(value))
                {
                    continue;
                }

                bool better = bestIndex < 0 || (higherIsBetter ? value > best : value < best);
                if (better)
                {
                    bestIndex = i;
                    best = value;
                }
            }

            return bestIndex;
        }
    }
}
