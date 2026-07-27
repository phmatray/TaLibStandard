// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Strategies;

/// <summary>
/// The fixture is 20 identical closes (so the bands collapse onto the price) followed by one breakout bar.
/// </summary>
/// <remarks>
/// On bar 20 the 20-bar window is nineteen 100s and one 110, so
/// <c>mean = 100.5</c>, <c>population variance = (19 * 0.25 + 90.25) / 20 = 4.75</c>,
/// <c>sigma = 2.179449...</c> and the upper band is <c>100.5 + 2 * 2.179449 = 104.858899...</c>.
/// A close of 110 clears it, and on bar 19 the close sat exactly on a zero-width band.
/// </remarks>
public class BollingerBreakoutStrategyTests
{
    private static IReadOnlyList<Bar> BreakoutSeries(double breakoutClose)
    {
        List<double> closes = [];
        for (int i = 0; i < 20; i++)
        {
            closes.Add(100.0);
        }

        closes.Add(breakoutClose);
        closes.Add(breakoutClose);

        return TestBars.FromCloses(closes, wick: 0.0);
    }

    [Fact]
    public void ACloseBreakingAboveTheUpperBandEmitsALongSignal()
    {
        // Arrange
        IReadOnlyList<Bar> bars = BreakoutSeries(110.0);
        StrategyDriver driver = new(new BollingerBreakoutStrategy(20, 2.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert - the hand-computed band values first.
        BollingerBandSeries bands = driver.Indicators.BollingerBands(20, 2.0, 2.0);
        bands.Upper[19].ShouldBe(100.0, 1e-9);
        bands.Middle[20].ShouldBe(100.5, 1e-9);
        bands.Upper[20].ShouldBe(100.5 + (2.0 * Math.Sqrt(4.75)), 1e-9);

        signals[19].ShouldBe(Signal.Hold);
        signals[20].ShouldBe(Signal.EnterLong);
    }

    [Fact]
    public void ACloseBreakingBelowTheLowerBandEmitsAShortSignal()
    {
        // Arrange - symmetric fixture: the same move downwards.
        IReadOnlyList<Bar> bars = BreakoutSeries(90.0);
        StrategyDriver driver = new(new BollingerBreakoutStrategy(20, 2.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert
        BollingerBandSeries bands = driver.Indicators.BollingerBands(20, 2.0, 2.0);
        bands.Middle[20].ShouldBe(99.5, 1e-9);
        bands.Lower[20].ShouldBe(99.5 - (2.0 * Math.Sqrt(4.75)), 1e-9);

        signals[20].ShouldBe(Signal.EnterShort);
    }

    [Fact]
    public void ALongIsClosedWhenThePriceFallsBackToTheMiddleBand()
    {
        // Arrange - break out to 110, then drift back to the moving average.
        List<double> closes = [];
        for (int i = 0; i < 20; i++)
        {
            closes.Add(100.0);
        }

        closes.Add(110.0);
        closes.Add(100.0);

        IReadOnlyList<Bar> bars = TestBars.FromCloses(closes, wick: 0.0);
        Position longPosition = new(OrderSide.Buy, 10.0, 110.0, 21, TestBars.Origin, 0.0);
        StrategyDriver driver = new(new BollingerBreakoutStrategy(20, 2.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1, i => i > 20 ? longPosition : null);

        // Assert - on bar 21 the close (100) is at or below the middle band (100.5), so the breakout is spent.
        BollingerBandSeries bands = driver.Indicators.BollingerBands(20, 2.0, 2.0);
        bands.Middle[21].ShouldBe(100.5, 1e-9);
        signals[21].ShouldBe(Signal.Exit);
    }

    [Fact]
    public void NoSignalIsEmittedWhileTheBandsAreStillWarmingUp()
    {
        // Arrange
        IReadOnlyList<Bar> bars = BreakoutSeries(110.0);
        StrategyDriver driver = new(new BollingerBreakoutStrategy(20, 2.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert - BBANDS(20) has no value before bar 19, and the rule also needs bar 18.
        signals.Take(20).ShouldAllBe(signal => signal == Signal.Hold);
    }

    [Theory]
    [InlineData(1, 2.0)]
    [InlineData(20, 0.0)]
    [InlineData(20, -1.0)]
    public void AnInvalidConfigurationIsRejected(int timePeriod, double deviations)
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => new BollingerBreakoutStrategy(timePeriod, deviations));
    }
}
