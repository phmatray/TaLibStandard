// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests;

/// <summary>
/// End-to-end checks on the workload the executable actually runs.
/// </summary>
public class BacktestSampleRunnerTests
{
    [Fact]
    public void TheSampleReportIsReproducibleForAGivenSeed()
    {
        // Arrange
        CommandLineOptions options = CommandLineOptions.Parse(["--bars", "600", "--seed", "12345"]);

        // Act
        string first = BacktestSampleRunner.Run(options);
        string second = BacktestSampleRunner.Run(options);

        // Assert - the whole point of the deterministic generator.
        first.ShouldBe(second);
    }

    [Fact]
    public void ChangingTheSeedChangesTheReport()
    {
        // Arrange / Act
        string first = BacktestSampleRunner.Run(CommandLineOptions.Parse(["--bars", "600", "--seed", "1"]));
        string second = BacktestSampleRunner.Run(CommandLineOptions.Parse(["--bars", "600", "--seed", "2"]));

        // Assert
        first.ShouldNotBe(second);
    }

    [Fact]
    public void TheReportCoversEveryStrategyPlusTheBaseline()
    {
        // Arrange
        CommandLineOptions options = CommandLineOptions.Parse(["--bars", "600"]);

        // Act
        string report = BacktestSampleRunner.Run(options);

        // Assert
        BacktestSampleRunner.CreateStrategies().Count.ShouldBe(5);
        report.ShouldContain("RUN CONFIGURATION");
        report.ShouldContain("SIDE-BY-SIDE COMPARISON");
        report.ShouldContain("Buy and hold");
        report.ShouldNotContain("NaN");
    }

    [Fact]
    public void RaisingTheFrictionsLowersEveryStrategyThatTrades()
    {
        // Arrange
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(800, seed: 606);
        BacktestOptions cheap = new() { InitialCapital = 100_000, CommissionBps = 0, SlippageBps = 0 };
        BacktestOptions expensive = cheap with { CommissionBps = 50, SlippageBps = 25 };

        // Act
        IReadOnlyList<BacktestResult> cheapRuns = BacktestSampleRunner.RunAll(BacktestSampleRunner.CreateStrategies(), bars, cheap);
        IReadOnlyList<BacktestResult> expensiveRuns = BacktestSampleRunner.RunAll(BacktestSampleRunner.CreateStrategies(), bars, expensive);

        // Assert
        for (int i = 0; i < cheapRuns.Count; i++)
        {
            if (cheapRuns[i].Trades.Count == 0)
            {
                continue;
            }

            expensiveRuns[i].FinalEquity.ShouldBeLessThan(
                cheapRuns[i].FinalEquity,
                $"{cheapRuns[i].StrategyName} should be worse once it pays 75 bp a fill");
        }
    }

    [Fact]
    public void ARunOverACsvFileUsesThatDataInsteadOfTheGenerator()
    {
        // Arrange
        string path = Path.Combine(Path.GetTempPath(), $"talib-backtest-{Guid.NewGuid():N}.csv");
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(120, seed: 808);
        WriteCsv(path, bars);

        try
        {
            CommandLineOptions options = CommandLineOptions.Parse(["--csv", path]);

            // Act
            IReadOnlyList<Bar> loaded = BacktestSampleRunner.LoadBars(options, out string description);
            string report = BacktestSampleRunner.Run(options);

            // Assert
            loaded.Count.ShouldBe(bars.Count);
            loaded[0].Close.ShouldBe(bars[0].Close, 1e-6);
            description.ShouldContain(path);
            report.ShouldContain(path);
            report.ShouldContain("SIDE-BY-SIDE COMPARISON");
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void AnEmptyCsvFileProducesAnExplanationRatherThanACrash()
    {
        // Arrange
        string path = Path.Combine(Path.GetTempPath(), $"talib-backtest-{Guid.NewGuid():N}.csv");
        File.WriteAllText(path, "Date,Open,High,Low,Close,Volume\n");

        try
        {
            CommandLineOptions options = CommandLineOptions.Parse(["--csv", path]);

            // Act
            string report = BacktestSampleRunner.Run(options);

            // Assert
            report.ShouldContain("nothing to backtest");
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void EveryStrategyRunsOverTheDefaultSeriesWithoutLookingAhead()
    {
        // Arrange
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(1_500);
        BacktestOptions options = new() { InitialCapital = 100_000, AllowShort = true };

        // Act
        IReadOnlyList<BacktestResult> results = BacktestSampleRunner.RunAll(BacktestSampleRunner.CreateStrategies(), bars, options);

        // Assert - no LookAheadException anywhere, and every run is internally consistent.
        results.Count.ShouldBe(5);
        foreach (BacktestResult result in results)
        {
            result.EquityCurve.Count.ShouldBe(bars.Count);
            result.FinalEquity.ShouldBe(result.EquityCurve[^1].Equity);
            result.Metrics.TradeCount.ShouldBe(result.Trades.Count);
            double.IsFinite(result.Metrics.Sharpe).ShouldBeTrue();
        }
    }

    private static void WriteCsv(string path, IReadOnlyList<Bar> bars)
    {
        using StreamWriter writer = new(path);
        writer.WriteLine("Date,Open,High,Low,Close,Volume");
        foreach (Bar bar in bars)
        {
            writer.WriteLine(string.Format(
                CultureInfo.InvariantCulture,
                "{0:yyyy-MM-dd},{1:R},{2:R},{3:R},{4:R},{5:R}",
                bar.Timestamp,
                bar.Open,
                bar.High,
                bar.Low,
                bar.Close,
                bar.Volume));
        }
    }
}
