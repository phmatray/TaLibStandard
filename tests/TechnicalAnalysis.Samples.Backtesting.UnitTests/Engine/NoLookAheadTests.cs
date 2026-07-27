// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

/// <summary>
/// The headline guarantee: a strategy cannot read data from the future, and the engine cannot act on a signal
/// before the bar that follows the one that produced it.
/// </summary>
public class NoLookAheadTests
{
    private static readonly IReadOnlyList<Bar> s_series =
        TestBars.FromCloses([10, 11, 9, 12, 13, 11, 14, 15, 13, 16, 17, 15]);

    [Fact]
    public void AStrategyThatReadsTomorrowsBarMakesTheRunFail()
    {
        // Arrange
        BacktestEngine engine = new();
        FutureBarPeekingStrategy cheater = new();

        // Act
        LookAheadException exception = Should.Throw<LookAheadException>(() => engine.Run(cheater, s_series));

        // Assert
        exception.Message.ShouldContain("Look-ahead bias detected");
        exception.Message.ShouldContain("bars");
    }

    [Fact]
    public void AStrategyThatReadsAFutureIndicatorValueMakesTheRunFail()
    {
        // Arrange
        BacktestEngine engine = new();
        FutureIndicatorPeekingStrategy cheater = new();

        // Act
        LookAheadException exception = Should.Throw<LookAheadException>(() => engine.Run(cheater, s_series));

        // Assert
        exception.Message.ShouldContain("SMA(3)");
    }

    [Fact]
    public void AStrategyThatProbesForwardIsStoppedOnTheFirstStep()
    {
        // Arrange
        BacktestEngine engine = new();
        SeriesLengthProbingStrategy cheater = new();

        // Act / Assert - it never reaches an ArgumentOutOfRangeException at the end of the array,
        // because the very first step past the current bar is refused.
        Should.Throw<LookAheadException>(() => engine.Run(cheater, s_series));
    }

    [Fact]
    public void TheEngineNeverSwallowsALookAheadException()
    {
        // Arrange - peeking two bars ahead is still peeking.
        BacktestEngine engine = new();
        FutureBarPeekingStrategy cheater = new(2);

        // Act / Assert
        Should.Throw<LookAheadException>(() => engine.Run(cheater, s_series));
    }

    [Fact]
    public void TheWindowShowsExactlyOneMoreBarOnEveryStepAndNeverRevealsTheTotalLength()
    {
        // Arrange
        BacktestEngine engine = new();
        ScriptedStrategy strategy = new((_, _) => Signal.Hold);

        // Act
        engine.Run(strategy, s_series);

        // Assert
        strategy.ObservedIndices.ShouldBe([.. Enumerable.Range(0, s_series.Count)]);
        strategy.ObservedCounts.ShouldBe([.. Enumerable.Range(1, s_series.Count)]);
    }

    [Fact]
    public void AnIndicatorSeriesNeverRevealsTheTotalLengthOfTheSeries()
    {
        // Arrange - the window guard covers IBarWindow, but a strategy also holds the IndicatorSeries objects
        // it asked for in Initialize. Reading Count off one of those used to hand back the full bar count,
        // which is enough to express an end-of-sample bias without ever reading a price.
        BacktestEngine engine = new();
        IndicatorLengthProbingStrategy cheater = new();

        // Act
        engine.Run(cheater, s_series);

        // Assert - nothing observed, at any point, equals the total number of bars.
        cheater.CountAtInitialize.ShouldBe(0);
        cheater.Observed.Count.ShouldBe(s_series.Count);
        cheater.Observed.Select(o => o.Count).ShouldBe([.. Enumerable.Range(1, s_series.Count)]);

        // SMA(3) starts on bar 2, so BegIdx stays hidden until the window reaches it, and NBElement only ever
        // counts values that have already happened. BegIdx + NBElement is therefore never past the cursor.
        cheater.Observed[0].BegIdx.ShouldBe(-1);
        cheater.Observed[1].BegIdx.ShouldBe(-1);
        cheater.Observed[2].BegIdx.ShouldBe(2);
        cheater.Observed[0].NBElement.ShouldBe(0);
        cheater.Observed[2].NBElement.ShouldBe(1);
        for (int i = 0; i < cheater.Observed.Count; i++)
        {
            (_, int begIdx, int nbElement) = cheater.Observed[i];
            if (begIdx >= 0)
            {
                (begIdx + nbElement).ShouldBeLessThanOrEqualTo(i + 1);
            }
        }
    }

    [Fact]
    public void ProbingAnIndicatorPastTheEndOfTheSeriesThrowsInsteadOfAnsweringQuietly()
    {
        // Arrange - TryGetPair used to range-check against the full length, so a probe past the end returned
        // false while a probe merely in the future threw. The pair of answers located the end of the series.
        BacktestEngine engine = new();
        IndicatorPairProbingStrategy cheater = new();

        // Act / Assert
        Should.Throw<LookAheadException>(() => engine.Run(cheater, s_series));
    }

    [Fact]
    public void ASignalTakenOnBarZeroIsFilledAtTheOpenOfBarOne()
    {
        // Arrange - zero frictions so the fill price is exactly the bar's open.
        IReadOnlyList<Bar> bars = TestBars.FromOpenClose([(100, 101), (103, 105), (106, 108)]);
        BacktestOptions options = new()
        {
            InitialCapital = 10_000,
            CommissionBps = 0,
            SlippageBps = 0
        };

        BacktestEngine engine = new(options);
        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal> { [0] = Signal.EnterLong });

        // Act
        BacktestResult result = engine.Run(strategy, bars);

        // Assert - the fill is on bar 1 at 103, never on bar 0 at 100 or 101.
        result.Trades.Count.ShouldBe(1);
        result.Trades[0].EntryIndex.ShouldBe(1);
        result.Trades[0].EntryPrice.ShouldBe(103.0, 1e-12);

        // Bar 0 closes with the account still flat and untouched.
        result.EquityCurve[0].SignedQuantity.ShouldBe(0.0);
        result.EquityCurve[0].Equity.ShouldBe(10_000.0, 1e-12);
    }

    [Fact]
    public void ASignalEmittedOnTheLastBarIsNeverExecuted()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromOpenClose([(100, 101), (101, 102), (102, 103)]);
        BacktestEngine engine = new(new BacktestOptions { CommissionBps = 0, SlippageBps = 0 });
        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal> { [2] = Signal.EnterLong });

        // Act
        BacktestResult result = engine.Run(strategy, bars);

        // Assert - there is no bar 3 to fill against, so nothing happened.
        result.Trades.ShouldBeEmpty();
        result.FinalEquity.ShouldBe(result.InitialCapital, 1e-12);
    }
}
