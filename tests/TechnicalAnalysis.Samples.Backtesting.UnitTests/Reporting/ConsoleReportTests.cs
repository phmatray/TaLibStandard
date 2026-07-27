// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Reporting;

public class ConsoleReportTests
{
    private static readonly IReadOnlyList<Bar> s_series = SyntheticSeriesGenerator.Generate(400, seed: 5150);

    private static IReadOnlyList<BacktestResult> Results()
    {
        BacktestOptions options = new() { InitialCapital = 100_000 };
        return BacktestSampleRunner.RunAll(BacktestSampleRunner.CreateStrategies(), s_series, options);
    }

    [Fact]
    public void TheComparisonTableHasOneColumnPerStrategyAndOneRowPerMetric()
    {
        // Arrange
        IReadOnlyList<BacktestResult> results = Results();

        // Act
        string table = ConsoleReport.RenderComparison(results);

        // Assert
        foreach (BacktestResult result in results)
        {
            table.ShouldContain(result.StrategyName);
        }

        table.ShouldContain("Total return");
        table.ShouldContain("Max drawdown");
        table.ShouldContain("Sharpe");
        table.ShouldContain("Sortino");
        table.ShouldContain("Calmar");
        table.ShouldContain("Profit factor");
        table.ShouldContain("Expectancy / trade");
        table.ShouldContain("Exposure");
    }

    [Fact]
    public void EveryReportLineFitsInTheHouseLineLength()
    {
        // Arrange
        IReadOnlyList<BacktestResult> results = Results();

        // Act
        string report = ConsoleReport.RenderConfiguration(results[0].Options, s_series.Count, "test series")
            + ConsoleReport.RenderStrategyCard(results[0], "description")
            + ConsoleReport.RenderTradeLog(results[0])
            + ConsoleReport.RenderComparison(results);

        // Assert - 140 characters is the repository's maximum line length; the report must respect it too.
        string[] lines = report.Split(Environment.NewLine);
        lines.ShouldAllBe(line => line.Length <= 140);
    }

    [Fact]
    public void TheBestValueOfEachComparableRowIsMarked()
    {
        // Arrange
        IReadOnlyList<BacktestResult> results = Results();

        // Act
        string table = ConsoleReport.RenderComparison(results);
        string totalReturnRow = table
            .Split(Environment.NewLine)
            .First(line => line.StartsWith("Total return", StringComparison.Ordinal));

        // Assert - exactly one cell of the row carries the marker, and it is the largest total return.
        totalReturnRow.Count(c => c == '*').ShouldBe(1);

        double best = results.Max(result => result.Metrics.TotalReturn);
        string bestCell = (best * 100.0).ToString("F2", CultureInfo.InvariantCulture) + " %";
        totalReturnRow.ShouldContain("* " + bestCell);
    }

    [Fact]
    public void NumbersAreFormattedWithTheInvariantCultureOnEveryMachine()
    {
        // Arrange
        PerformanceMetrics metrics = PerformanceMetrics.Compute(
            [
                new EquityPoint(0, TestBars.Origin, 100.0, 0.0, 0.0, 1_234.5),
                new EquityPoint(1, TestBars.Origin.AddDays(1), 100.0, 0.0, 0.0, 1_357.95)
            ],
            [],
            1_234.5,
            252);

        // Act
        string rendered = ConsoleReport.RenderMetrics(metrics);

        // Assert - a decimal point and a comma group separator, never the other way round.
        rendered.ShouldContain("1,357.95");
        rendered.ShouldContain("10.00 %");
    }

    [Fact]
    public void AnInfiniteProfitFactorIsRenderedReadably()
    {
        // Arrange - one winning trade and no losing ones.
        IReadOnlyList<Trade> trades =
        [
            new(OrderSide.Buy, 10.0, 0, TestBars.Origin, 100.0, 1, TestBars.Origin.AddDays(1), 110.0, 0.0)
        ];

        PerformanceMetrics metrics = PerformanceMetrics.Compute(
            [
                new EquityPoint(0, TestBars.Origin, 100.0, 0.0, 0.0, 1_000.0),
                new EquityPoint(1, TestBars.Origin.AddDays(1), 110.0, 0.0, 0.0, 1_100.0)
            ],
            trades,
            1_000.0,
            252);

        // Act
        string rendered = ConsoleReport.RenderMetrics(metrics);

        // Assert
        metrics.ProfitFactor.ShouldBe(double.PositiveInfinity);
        rendered.ShouldContain("inf");
        rendered.ShouldNotContain("NaN");
        rendered.ShouldNotContain("∞");
    }

    [Fact]
    public void TheTradeLogListsRoundTripsAndTruncatesLongOnes()
    {
        // Arrange
        IReadOnlyList<BacktestResult> results = Results();
        BacktestResult busiest = results.MaxBy(result => result.Trades.Count)!;

        // Act
        string log = ConsoleReport.RenderTradeLog(busiest, maxTrades: 3);

        // Assert
        busiest.Trades.Count.ShouldBeGreaterThan(3);
        log.ShouldContain("Net P&L");
        log.ShouldContain("more round trip(s) not shown");
        log.Split(Environment.NewLine)
            .Count(line =>
                line.Contains("LONG", StringComparison.Ordinal)
                || line.Contains("SHORT", StringComparison.Ordinal))
            .ShouldBe(3);
    }

    [Fact]
    public void AStrategyWithNoTradesGetsAnExplicitTradeLog()
    {
        // Arrange
        BacktestResult result = new BacktestEngine().Run(new SmaCrossoverStrategy(20, 50), TestBars.FromCloses([1, 2, 3, 4, 5]));

        // Act
        string log = ConsoleReport.RenderTradeLog(result);

        // Assert
        log.ShouldContain("no completed round trips");
    }

    [Fact]
    public void AnEmptyComparisonIsHandled()
    {
        // Arrange / Act
        string table = ConsoleReport.RenderComparison([]);

        // Assert
        table.ShouldBe("(nothing to compare)");
    }

    [Fact]
    public void TheConfigurationBlockEchoesTheFrictionsThatWereApplied()
    {
        // Arrange
        BacktestOptions options = new()
        {
            InitialCapital = 250_000,
            CommissionBps = 7.5,
            SlippageBps = 1.25,
            AllowShort = true,
            BarsPerYear = 365
        };

        // Act
        string rendered = ConsoleReport.RenderConfiguration(options, 1_000, "synthetic");

        // Assert
        rendered.ShouldContain("250,000.00");
        rendered.ShouldContain("7.5 bp per fill");
        rendered.ShouldContain("1.25 bp per fill");
        rendered.ShouldContain("365 bars per year");
        rendered.ShouldContain("enabled");
    }
}
