// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Strategies;

public class MacdTrendStrategyTests
{
    private static readonly Position s_longPosition = new(OrderSide.Buy, 10.0, 100.0, 1, TestBars.Origin, 0.0);

    /// <summary>
    /// 20 quiet bars around 100 with a one-point range, then a collapse to 50.
    /// ATR(14) settles near 1, so a 3x ATR trailing stop sits near 97 and the collapse must breach it.
    /// </summary>
    private static List<Bar> CollapseSeries()
    {
        List<Bar> bars = [];
        for (int i = 0; i < 20; i++)
        {
            bars.Add(new Bar(TestBars.Origin.AddDays(i), 100.0, 100.5, 99.5, 100.0, 1_000.0));
        }

        bars.Add(new Bar(TestBars.Origin.AddDays(20), 100.0, 100.0, 50.0, 50.0, 1_000.0));
        bars.Add(new Bar(TestBars.Origin.AddDays(21), 50.0, 50.5, 49.5, 50.0, 1_000.0));

        return bars;
    }

    [Fact]
    public void TheAtrTrailingStopExitsALongOnTheBarThatBreachesIt()
    {
        // Arrange
        List<Bar> bars = CollapseSeries();
        StrategyDriver driver = new(new MacdTrendStrategy(12, 26, 9, 14, 3.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1, _ => s_longPosition);

        // Assert - the stop is armed and unbreached while the price is quiet ...
        IndicatorSeries atr = driver.Indicators.Atr(14);
        atr.TryGetValue(19, out double quietAtr).ShouldBeTrue();
        quietAtr.ShouldBeGreaterThan(0.0);
        (100.0 - (3.0 * quietAtr)).ShouldBeLessThan(100.0);
        signals[19].ShouldBe(Signal.Hold);

        // ... and the collapse to 50 is far below it, so the position is closed on that very bar.
        signals[20].ShouldBe(Signal.Exit);
    }

    [Fact]
    public void TheTrailingStopIsIgnoredWhileTheAccountIsFlat()
    {
        // Arrange
        List<Bar> bars = CollapseSeries();
        StrategyDriver driver = new(new MacdTrendStrategy(12, 26, 9, 14, 3.0), bars);

        // Act - no position on any bar.
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert - MACD needs 26 + 9 bars, so nothing at all can fire on this 22-bar fixture.
        signals.ShouldAllBe(signal => signal == Signal.Hold);
    }

    /// <summary>
    /// 15 quiet bars whose true range is exactly 1, then a 10-point rally, then a pull-back.
    /// </summary>
    /// <remarks>
    /// <code>
    /// bar  O      H      L      C      TR     ATR(14)   stop = C - 3 x ATR
    ///  14  100    100.5   99.5  100    1      1         97          armed here
    ///  15  100    110.5   99.5  110    11     24/14     104.857...  ratchets up
    ///  16  110    110.0   99.5  100    10.5   -         -           candidate is lower, stop holds
    /// </code>
    /// On bar 16 the close of 100 is below the ratcheted stop of 104.857 even though it is still at the
    /// level the position was opened at, so the trailing stop — and only the trailing stop — closes it.
    /// </remarks>
    private static List<Bar> RallyThenPullBackSeries()
    {
        List<Bar> bars = [];
        for (int i = 0; i <= 14; i++)
        {
            bars.Add(new Bar(TestBars.Origin.AddDays(i), 100.0, 100.5, 99.5, 100.0, 1_000.0));
        }

        bars.Add(new Bar(TestBars.Origin.AddDays(15), 100.0, 110.5, 99.5, 110.0, 1_000.0));
        bars.Add(new Bar(TestBars.Origin.AddDays(16), 110.0, 110.0, 99.5, 100.0, 1_000.0));

        return bars;
    }

    [Fact]
    public void TheStopRatchetsUpwardsAndNeverGivesGround()
    {
        // Arrange
        List<Bar> bars = RallyThenPullBackSeries();
        StrategyDriver driver = new(new MacdTrendStrategy(12, 26, 9, 14, 3.0), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1, _ => s_longPosition);

        // Assert - the two ATR values the stop is built from, hand-computed above.
        IndicatorSeries atr = driver.Indicators.Atr(14);
        atr.BegIdx.ShouldBe(14);
        atr[14].ShouldBe(1.0, 1e-12);
        atr[15].ShouldBe(24.0 / 14.0, 1e-12);

        // The stop is armed at 97 on bar 14 and ratchets up to 104.857 on bar 15; neither bar breaches it.
        signals[14].ShouldBe(Signal.Hold);
        signals[15].ShouldBe(Signal.Hold);

        // The pull-back to 100 is above the original stop of 97 but below the ratcheted one, so the exit
        // can only be explained by the ratchet having moved.
        double originalStop = 100.0 - (3.0 * 1.0);
        double ratchetedStop = 110.0 - (3.0 * (24.0 / 14.0));
        bars[16].Close.ShouldBeGreaterThan(originalStop);
        bars[16].Close.ShouldBeLessThan(ratchetedStop);
        signals[16].ShouldBe(Signal.Exit);
    }

    [Fact]
    public void MacdCrossingsDriveTheEntriesOnALongEnoughSeries()
    {
        // Arrange - a series with a genuine down leg followed by a genuine up leg produces both crossings.
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(400, seed: 777);
        StrategyDriver driver = new(new MacdTrendStrategy(), bars);

        // Act
        IReadOnlyList<Signal> signals = driver.StepThrough(bars.Count - 1);

        // Assert - every entry signal sits exactly on a bar where the MACD line crosses its signal line.
        MacdSeries macd = driver.Indicators.Macd(12, 26, 9);
        signals.Count(signal => signal is Signal.EnterLong or Signal.EnterShort).ShouldBeGreaterThan(0);

        for (int i = 0; i < signals.Count; i++)
        {
            if (signals[i] is not (Signal.EnterLong or Signal.EnterShort))
            {
                continue;
            }

            macd.Line.TryGetPair(i, out double previousLine, out double currentLine).ShouldBeTrue();
            macd.Signal.TryGetPair(i, out double previousSignal, out double currentSignal).ShouldBeTrue();

            bool crossedUp = previousLine <= previousSignal && currentLine > currentSignal;
            bool crossedDown = previousLine >= previousSignal && currentLine < currentSignal;
            (crossedUp || crossedDown).ShouldBeTrue($"bar {i} emitted {signals[i]} without a MACD crossing");
        }
    }

    [Theory]
    [InlineData(0, 26, 9, 14, 3.0)]
    [InlineData(26, 12, 9, 14, 3.0)]
    [InlineData(12, 26, 0, 14, 3.0)]
    [InlineData(12, 26, 9, 0, 3.0)]
    [InlineData(12, 26, 9, 14, 0.0)]
    public void AnInvalidConfigurationIsRejected(int fast, int slow, int signal, int atrPeriod, double atrMultiple)
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => new MacdTrendStrategy(fast, slow, signal, atrPeriod, atrMultiple));
    }
}
