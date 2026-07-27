// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

public class BarWindowTests
{
    [Fact]
    public void CountReportsOnlyVisibleBarsSoTheSeriesLengthNeverLeaks()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12, 13, 14, 15]);

        // Act
        BarWindow window = new(bars, 2);

        // Assert
        window.CurrentIndex.ShouldBe(2);
        window.Count.ShouldBe(3);
    }

    [Fact]
    public void ReadingTheNextBarThrowsLookAhead()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12, 13]);
        BarWindow window = new(bars, 1);

        // Act
        LookAheadException exception = Should.Throw<LookAheadException>(() => window[2]);

        // Assert
        exception.Message.ShouldContain("Look-ahead bias detected");
        exception.Message.ShouldContain("index 2");
    }

    [Fact]
    public void ReadingTheLastBarOfTheSeriesFromAnEarlierPositionThrowsLookAhead()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12, 13]);
        BarWindow window = new(bars, 0);

        // Act / Assert
        Should.Throw<LookAheadException>(() => window[3]);
    }

    [Fact]
    public void ReadingPastAndCurrentBarsIsAllowed()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12, 13]);
        BarWindow window = new(bars, 2);

        // Act
        Bar first = window[0];
        Bar current = window[2];

        // Assert
        first.Close.ShouldBe(10);
        current.Close.ShouldBe(12);
        window.Current.Close.ShouldBe(12);
        window.Ago(0).Close.ShouldBe(12);
        window.Ago(2).Close.ShouldBe(10);
    }

    [Fact]
    public void NegativeIndexThrowsArgumentOutOfRangeNotLookAhead()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12]);
        BarWindow window = new(bars, 1);

        // Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => window[-1]);
    }

    [Fact]
    public void SteppingBackBeforeTheStartOfTheSeriesThrowsArgumentOutOfRange()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12]);
        BarWindow window = new(bars, 1);

        // Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => window.Ago(2));
    }

    [Fact]
    public void AnUnpositionedWindowHasNoCurrentBar()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12]);

        // Act
        BarWindow window = new(bars);

        // Assert
        window.CurrentIndex.ShouldBe(-1);
        window.Count.ShouldBe(0);
        Should.Throw<InvalidOperationException>(() => window.Current);
    }

    [Fact]
    public void AnEmptySeriesProducesAnUnpositionedWindow()
    {
        // Arrange
        IReadOnlyList<Bar> bars = [];

        // Act
        BarWindow window = new(bars);

        // Assert
        window.Count.ShouldBe(0);
        Should.Throw<LookAheadException>(() => window[0]);
    }

    [Fact]
    public void ConstructingBeyondTheEndOfTheSeriesThrows()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([10, 11, 12]);

        // Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => new BarWindow(bars, 3));
        Should.Throw<ArgumentOutOfRangeException>(() => new BarWindow(bars, -2));
    }
}
