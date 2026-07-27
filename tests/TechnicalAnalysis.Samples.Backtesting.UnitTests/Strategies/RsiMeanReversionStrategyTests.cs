// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Strategies;

/// <summary>
/// The fixture is 21 bars of steady one-point decline (which drives RSI(14) to zero) followed by one large
/// up bar, which is enough to lift RSI back above the oversold level in a single step.
/// </summary>
public class RsiMeanReversionStrategyTests
{
    private const int ReboundBar = 21;

    private static IReadOnlyList<Bar> Series()
    {
        List<double> closes = [];
        for (int i = 0; i <= 20; i++)
        {
            closes.Add(100.0 - i);
        }

        closes.Add(110.0);
        for (int i = 0; i < 10; i++)
        {
            closes.Add(110.0 + i);
        }

        return TestBars.FromCloses(closes, wick: 0.0);
    }

    [Fact]
    public void CrossingBackAboveTheOversoldLevelEmitsALongSignal()
    {
        // Arrange
        IReadOnlyList<Bar> bars = Series();
        StrategyDriver driver = new(new RsiMeanReversionStrategy(14, 30.0, 70.0, 50.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert - the precondition of the rule is verified first, so the test explains itself when it fails.
        IndicatorSeries rsi = driver.Indicators.Rsi(14);
        rsi.TryGetValue(ReboundBar - 1, out double previous).ShouldBeTrue();
        rsi.TryGetValue(ReboundBar, out double current).ShouldBeTrue();
        previous.ShouldBeLessThanOrEqualTo(30.0);
        current.ShouldBeGreaterThan(30.0);

        signals[ReboundBar].ShouldBe(Signal.EnterLong);
    }

    [Fact]
    public void NoSignalIsEmittedWhileTheIndicatorIsStillWarmingUp()
    {
        // Arrange - RSI(14) has no value before bar 14, and the rule also needs bar 13.
        IReadOnlyList<Bar> bars = Series();
        StrategyDriver driver = new(new RsiMeanReversionStrategy(), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert
        signals.Take(15).ShouldAllBe(signal => signal == Signal.Hold);
    }

    [Fact]
    public void ALongPositionIsHeldWhileTheIndicatorStaysBelowTheExitLevel()
    {
        // Arrange - during the decline RSI sits near zero, far below the exit level of 50.
        IReadOnlyList<Bar> bars = Series();
        Position longPosition = new(OrderSide.Buy, 10.0, 100.0, 15, TestBars.Origin, 0.0);
        StrategyDriver driver = new(new RsiMeanReversionStrategy(14, 30.0, 70.0, 50.0), bars);

        // Act - carry the same long position from bar 15 onwards so only the exit rule can fire.
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1, i => i >= 15 ? longPosition : null);

        // Assert
        IndicatorSeries rsi = driver.Indicators.Rsi(14);
        for (int i = 15; i < ReboundBar; i++)
        {
            rsi[i].ShouldBeLessThan(50.0);
            signals[i].ShouldBe(Signal.Hold);
        }
    }

    [Fact]
    public void ALongPositionIsClosedOnTheFirstBarAtOrAboveTheExitLevel()
    {
        // Arrange
        IReadOnlyList<Bar> bars = Series();
        Position longPosition = new(OrderSide.Buy, 10.0, 100.0, 15, TestBars.Origin, 0.0);
        StrategyDriver driver = new(new RsiMeanReversionStrategy(14, 30.0, 70.0, 50.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1, i => i >= 15 ? longPosition : null);

        // Assert - the rebound bar itself emits the entry (the entry rules are tested first), and the very
        // next bar, still above 50, closes the position. The rule is a level test, not a crossing test.
        IndicatorSeries rsi = driver.Indicators.Rsi(14);
        signals[ReboundBar].ShouldBe(Signal.EnterLong);
        rsi[ReboundBar + 1].ShouldBeGreaterThanOrEqualTo(50.0);
        signals[ReboundBar + 1].ShouldBe(Signal.Exit);
    }

    [Fact]
    public void AShortPositionIsNotClosedByTheLongExitRule()
    {
        // Arrange - RSI is far above 50 late in the rising leg, which must not close a short.
        IReadOnlyList<Bar> bars = Series();
        Position shortPosition = new(OrderSide.Sell, 10.0, 100.0, 0, TestBars.Origin, 0.0);
        StrategyDriver driver = new(new RsiMeanReversionStrategy(14, 30.0, 70.0, 50.0), bars);
        driver.StepThrough(bars.Count - 2, _ => shortPosition);

        // Act
        Signal signal = driver.StepTo(bars.Count - 1, shortPosition);

        // Assert
        IndicatorSeries rsi = driver.Indicators.Rsi(14);
        rsi[bars.Count - 1].ShouldBeGreaterThan(50.0);
        signal.ShouldNotBe(Signal.Exit);
    }

    [Theory]
    [InlineData(0, 30, 70, 50)]
    [InlineData(14, 70, 30, 50)]
    [InlineData(14, 30, 70, 20)]
    [InlineData(14, 30, 70, 80)]
    public void AnInvalidConfigurationIsRejected(int period, double oversold, double overbought, double exit)
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => new RsiMeanReversionStrategy(period, oversold, overbought, exit));
    }
}
