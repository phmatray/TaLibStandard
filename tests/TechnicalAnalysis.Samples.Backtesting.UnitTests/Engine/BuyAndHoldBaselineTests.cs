// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

/// <summary>
/// The baseline must be exactly the return of the underlying series from the second bar's open to the last
/// bar's close, net of one round trip of costs — nothing more, nothing less. If it were not, every
/// comparison in the report would be measured against the wrong yardstick.
/// </summary>
public class BuyAndHoldBaselineTests
{
    private const double Capital = 100_000.0;

    private static IReadOnlyList<Bar> Series()
    {
        return SyntheticSeriesGenerator.Generate(400, seed: 12_345);
    }

    [Fact]
    public void WithoutCostsItEqualsTheUnderlyingSeriesReturn()
    {
        // Arrange
        IReadOnlyList<Bar> bars = Series();
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = 0,
            SlippageBps = 0
        };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(new BuyAndHoldStrategy(), bars);

        // Assert - bought at the open of bar 1, liquidated at the close of the last bar.
        double underlyingReturn = (bars[^1].Close / bars[1].Open) - 1.0;

        result.Trades.Count.ShouldBe(1);
        result.Trades[0].EntryIndex.ShouldBe(1);
        result.Trades[0].ExitIndex.ShouldBe(bars.Count - 1);
        result.Metrics.TotalReturn.ShouldBe(underlyingReturn, 1e-9);
        result.FinalEquity.ShouldBe(Capital * (1.0 + underlyingReturn), 1e-6);
    }

    [Fact]
    public void WithCostsItEqualsTheUnderlyingReturnNetOfExactlyOneRoundTrip()
    {
        // Arrange
        const double CommissionBps = 7.5;
        const double SlippageBps = 3.0;
        const double CommissionRate = CommissionBps / 10_000.0;
        const double SlippageRate = SlippageBps / 10_000.0;

        IReadOnlyList<Bar> bars = Series();
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = CommissionBps,
            SlippageBps = SlippageBps
        };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(new BuyAndHoldStrategy(), bars);

        // Assert - closed form:
        //   final = C * (lastClose * (1 - s) * (1 - c)) / (firstOpen * (1 + s) * (1 + c))
        double entryPrice = bars[1].Open;
        double exitPrice = bars[^1].Close;
        double expectedFinal =
            Capital
            * (exitPrice * (1.0 - SlippageRate) * (1.0 - CommissionRate))
            / (entryPrice * (1.0 + SlippageRate) * (1.0 + CommissionRate));

        result.Trades.Count.ShouldBe(1);
        result.FinalEquity.ShouldBe(expectedFinal, 1e-6);

        // Exactly one round trip of costs: two fills, no more.
        double grossReturn = (exitPrice / entryPrice) - 1.0;
        double costDrag = 1.0 + grossReturn - (result.FinalEquity / Capital);
        costDrag.ShouldBeGreaterThan(0.0);
        result.Metrics.TotalReturn.ShouldBeLessThan(grossReturn);
    }

    [Fact]
    public void ItIsExposedOnEveryBarExceptTheFirst()
    {
        // Arrange
        IReadOnlyList<Bar> bars = Series();

        // Act
        BacktestResult result = new BacktestEngine(new BacktestOptions { InitialCapital = Capital })
            .Run(new BuyAndHoldStrategy(), bars);

        // Assert - flat on bar 0 (the signal has not been filled yet) and on the last bar (liquidated),
        // long on every bar in between.
        result.EquityCurve[0].IsInPosition.ShouldBeFalse();
        result.EquityCurve[^1].IsInPosition.ShouldBeFalse();
        result.EquityCurve.Skip(1).Take(bars.Count - 2).ShouldAllBe(point => point.SignedQuantity > 0.0);
        result.Metrics.Exposure.ShouldBe((bars.Count - 2.0) / bars.Count, 1e-12);
    }

    [Fact]
    public void KeepingThePositionOpenAtTheEndLeavesItUnrealisedAndUncounted()
    {
        // Arrange
        IReadOnlyList<Bar> bars = Series();
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = 0,
            SlippageBps = 0,
            CloseOpenPositionAtEnd = false
        };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(new BuyAndHoldStrategy(), bars);

        // Assert - no completed round trip, but the equity still marks to market at the final close.
        result.Trades.ShouldBeEmpty();
        result.EquityCurve[^1].IsInPosition.ShouldBeTrue();
        result.FinalEquity.ShouldBe(Capital * bars[^1].Close / bars[1].Open, 1e-6);
    }

    [Fact]
    public void ItEmitsExactlyOneEntrySignalForTheWholeRun()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12, 13, 14, 15]);
        BuyAndHoldStrategy strategy = new();
        StrategyDriver driver = new(strategy, bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert
        signals[0].ShouldBe(Signal.EnterLong);
        signals.Skip(1).ShouldAllBe(signal => signal == Signal.Hold);
    }
}
