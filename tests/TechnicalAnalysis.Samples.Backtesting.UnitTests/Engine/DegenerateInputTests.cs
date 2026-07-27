// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

/// <summary>
/// Inputs that a real user will hit sooner or later: no data at all, less data than the longest lookback, a
/// single bar, or a market that never moves. None of them may throw, and none may produce a NaN.
/// </summary>
public class DegenerateInputTests
{
    public static TheoryData<string> StrategyNames => [
        nameof(SmaCrossoverStrategy),
        nameof(RsiMeanReversionStrategy),
        nameof(MacdTrendStrategy),
        nameof(BollingerBreakoutStrategy),
        nameof(BuyAndHoldStrategy)
    ];

    private static IStrategy Create(string name)
    {
        return name switch
        {
            nameof(SmaCrossoverStrategy) => new SmaCrossoverStrategy(20, 50),
            nameof(RsiMeanReversionStrategy) => new RsiMeanReversionStrategy(),
            nameof(MacdTrendStrategy) => new MacdTrendStrategy(),
            nameof(BollingerBreakoutStrategy) => new BollingerBreakoutStrategy(),
            _ => new BuyAndHoldStrategy()
        };
    }

    [Theory]
    [MemberData(nameof(StrategyNames))]
    public void AnEmptySeriesProducesAnEmptyRunRatherThanAnException(string strategyName)
    {
        // Arrange
        BacktestEngine engine = new(new BacktestOptions { InitialCapital = 50_000 });

        // Act
        BacktestResult result = engine.Run(Create(strategyName), []);

        // Assert
        result.EquityCurve.ShouldBeEmpty();
        result.Trades.ShouldBeEmpty();
        result.FinalEquity.ShouldBe(50_000.0);
        result.Metrics.BarCount.ShouldBe(0);
        AssertNoNaN(result.Metrics);
    }

    [Theory]
    [MemberData(nameof(StrategyNames))]
    public void ASeriesShorterThanTheLongestLookbackNeverTradesOnGarbage(string strategyName)
    {
        // Arrange - 10 bars against an SMA(50) / MACD(26,9) / BBands(20) line-up.
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 12, 11, 15, 14, 18, 17, 20, 19, 22]);
        BacktestEngine engine = new(new BacktestOptions { InitialCapital = 50_000 });

        // Act
        BacktestResult result = engine.Run(Create(strategyName), bars);

        // Assert
        result.EquityCurve.Count.ShouldBe(10);
        result.EquityCurve.ShouldAllBe(point => double.IsFinite(point.Equity));
        AssertNoNaN(result.Metrics);

        // Only buy-and-hold, which uses no indicator, is allowed to trade this early.
        if (strategyName != nameof(BuyAndHoldStrategy))
        {
            result.Trades.ShouldBeEmpty();
            result.FinalEquity.ShouldBe(50_000.0, 1e-9);
        }
    }

    [Theory]
    [MemberData(nameof(StrategyNames))]
    public void ASingleBarProducesOneEquityPointAndNoTrade(string strategyName)
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([100.0]);
        BacktestEngine engine = new(new BacktestOptions { InitialCapital = 50_000 });

        // Act
        BacktestResult result = engine.Run(Create(strategyName), bars);

        // Assert - there is no "next bar" to fill against, so nothing can ever be executed.
        result.EquityCurve.Count.ShouldBe(1);
        result.Trades.ShouldBeEmpty();
        result.FinalEquity.ShouldBe(50_000.0);
        result.Metrics.Cagr.ShouldBe(0.0);
        result.Metrics.AnnualizedVolatility.ShouldBe(0.0);
        AssertNoNaN(result.Metrics);
    }

    [Theory]
    [MemberData(nameof(StrategyNames))]
    public void AZeroVolatilitySeriesProducesZeroRiskStatisticsRatherThanNaN(string strategyName)
    {
        // Arrange - 300 identical bars: every return, every range and every standard deviation is zero.
        IReadOnlyList<Bar> bars = TestBars.Flat(300, 100.0);
        BacktestOptions options = new()
        {
            InitialCapital = 50_000,
            CommissionBps = 0,
            SlippageBps = 0
        };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(Create(strategyName), bars);

        // Assert - with no costs and no price movement the account cannot change value.
        result.FinalEquity.ShouldBe(50_000.0, 1e-6);
        result.Metrics.AnnualizedVolatility.ShouldBe(0.0);
        result.Metrics.Sharpe.ShouldBe(0.0);
        result.Metrics.Sortino.ShouldBe(0.0);
        result.Metrics.Calmar.ShouldBe(0.0);
        result.Metrics.MaxDrawdown.ShouldBe(0.0);
        AssertNoNaN(result.Metrics);
    }

    [Fact]
    public void ATwoBarSeriesCanStillFillTheFirstSignal()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromOpenClose([(100, 100), (100, 120)]);
        BacktestOptions options = new() { InitialCapital = 10_000, CommissionBps = 0, SlippageBps = 0 };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(new BuyAndHoldStrategy(), bars);

        // Assert - bought at the open of bar 1 (100) and liquidated at its close (120).
        result.Trades.Count.ShouldBe(1);
        result.Trades[0].EntryIndex.ShouldBe(1);
        result.Trades[0].ExitIndex.ShouldBe(1);
        result.Trades[0].BarsHeld.ShouldBe(0);
        result.FinalEquity.ShouldBe(12_000.0, 1e-9);
    }

    [Fact]
    public void APriceCollapseCannotDriveEquityBelowZero()
    {
        // Arrange - the market loses 99.9% in one bar while the account is fully invested and long only.
        IReadOnlyList<Bar> bars = TestBars.FromOpenClose([(100, 100), (100, 100), (0.1, 0.1), (0.1, 0.1)]);
        BacktestOptions options = new() { InitialCapital = 10_000, CommissionBps = 10, SlippageBps = 5 };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(new BuyAndHoldStrategy(), bars);

        // Assert
        result.EquityCurve.ShouldAllBe(point => point.Equity >= 0.0);
        result.FinalEquity.ShouldBeGreaterThan(0.0);
        result.Metrics.MaxDrawdown.ShouldBeGreaterThan(0.99);
        AssertNoNaN(result.Metrics);
    }

    private static void AssertNoNaN(PerformanceMetrics metrics)
    {
        double[] values =
        [
            metrics.TotalReturn,
            metrics.Cagr,
            metrics.AnnualizedVolatility,
            metrics.MaxDrawdown,
            metrics.Sharpe,
            metrics.Sortino,
            metrics.Calmar,
            metrics.WinRate,
            metrics.AverageWin,
            metrics.AverageLoss,
            metrics.Expectancy,
            metrics.Exposure,
            metrics.FinalEquity
        ];

        values.ShouldAllBe(value => !double.IsNaN(value));

        // ProfitFactor is the one metric allowed to be infinite (wins and no losses); it may never be NaN.
        double.IsNaN(metrics.ProfitFactor).ShouldBeFalse();
    }
}
