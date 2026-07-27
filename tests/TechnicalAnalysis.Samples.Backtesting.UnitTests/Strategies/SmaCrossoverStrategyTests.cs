// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Strategies;

/// <summary>
/// The fixture is chosen so that both moving averages can be computed by hand.
/// </summary>
/// <remarks>
/// Closes: <c>10 10 10 10 10 20 20 20 20 5 5 5 5</c> with SMA(2) against SMA(4).
/// <code>
/// bar  close  SMA2   SMA4    relation
///  4    10    10     10      equal
///  5    20    15     12.5    fast above  -> golden cross on bar 5
///  8    20    20     20      equal
///  9     5    12.5   16.25   fast below  -> death cross on bar 9
/// </code>
/// </remarks>
public class SmaCrossoverStrategyTests
{
    private static readonly IReadOnlyList<Bar> s_series =
        TestBars.FromCloses([10, 10, 10, 10, 10, 20, 20, 20, 20, 5, 5, 5, 5], wick: 0.0);

    [Fact]
    public void TheGoldenCrossBarEmitsALongSignal()
    {
        // Arrange
        StrategyDriver driver = new(new SmaCrossoverStrategy(2, 4), s_series);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(s_series.Count - 1);

        // Assert - the averages are equal on bar 4 and the fast one is strictly above on bar 5.
        IndicatorSeries fast = driver.Indicators.Sma(2);
        IndicatorSeries slow = driver.Indicators.Sma(4);
        fast[4].ShouldBe(10.0, 1e-12);
        slow[4].ShouldBe(10.0, 1e-12);
        fast[5].ShouldBe(15.0, 1e-12);
        slow[5].ShouldBe(12.5, 1e-12);

        signals[4].ShouldBe(Signal.Hold);
        signals[5].ShouldBe(Signal.EnterLong);
        signals[6].ShouldBe(Signal.Hold);
    }

    [Fact]
    public void TheDeathCrossBarEmitsAShortSignal()
    {
        // Arrange
        StrategyDriver driver = new(new SmaCrossoverStrategy(2, 4), s_series);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(s_series.Count - 1);

        // Assert
        IndicatorSeries fast = driver.Indicators.Sma(2);
        IndicatorSeries slow = driver.Indicators.Sma(4);
        fast[9].ShouldBe(12.5, 1e-12);
        slow[9].ShouldBe(16.25, 1e-12);

        signals[8].ShouldBe(Signal.Hold);
        signals[9].ShouldBe(Signal.EnterShort);
    }

    [Fact]
    public void NoSignalIsEmittedWhileTheSlowAverageIsStillWarmingUp()
    {
        // Arrange - SMA(4) has no value before bar 3, and the rule also needs bar 2.
        StrategyDriver driver = new(new SmaCrossoverStrategy(2, 4), s_series);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(s_series.Count - 1);

        // Assert
        signals.Take(4).ShouldAllBe(signal => signal == Signal.Hold);
    }

    [Fact]
    public void EvaluateBeforeInitializeIsRejected()
    {
        // Arrange
        SmaCrossoverStrategy strategy = new(2, 4);
        BarWindow window = new(s_series, 5);

        // Act / Assert
        Should.Throw<InvalidOperationException>(() => strategy.Evaluate(window, null));
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(10, 10)]
    [InlineData(50, 20)]
    public void AnInvalidPeriodPairIsRejected(int fast, int slow)
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => new SmaCrossoverStrategy(fast, slow));
    }

    [Fact]
    public void TheNameAndDescriptionCarryTheConfiguredPeriods()
    {
        // Arrange
        SmaCrossoverStrategy strategy = new(20, 60);

        // Act / Assert
        strategy.Name.ShouldBe("SMA 20/60");
        strategy.Description.ShouldContain("SMA20");
        strategy.Description.ShouldContain("SMA60");
    }
}
