// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// Crossings are mechanical, not opinionated: a crossing is a transition between two adjacent bars,
/// so it is false where the state was already reached and false wherever either of the two bars has
/// no value. Every fixture below pins its indicator values first, so a crossing assertion can never
/// be true for the wrong reason.
/// </remarks>
public class IndicatorSeriesCrossingTests
{
    // SMA(2) over [10, 10, 10, 10, 20, 20]: warm from bar 1, values 10, 10, 10, 15, 20 on bars 1..5.
    // The rise across the 12.0 level happens exactly once, between bar 3 (10) and bar 4 (15).
    private static IndicatorSeries RisingFixture()
    {
        return PriceSeries.FromClose([10.0, 10.0, 10.0, 10.0, 20.0, 20.0]).Sma(2);
    }

    // SMA(2) over [20, 20, 20, 20, 10, 10]: warm from bar 1, values 20, 20, 20, 15, 10 on bars 1..5.
    private static IndicatorSeries FallingFixture()
    {
        return PriceSeries.FromClose([20.0, 20.0, 20.0, 20.0, 10.0, 10.0]).Sma(2);
    }

    private static double[] EightBarCloses()
    {
        return [10.0, 10.0, 10.0, 10.0, 10.0, 30.0, 30.0, 30.0];
    }

    [Fact]
    public void RisingFixtureHasTheValuesTheCrossingTestsRelyOn()
    {
        // Arrange
        // bar 1 = (10 + 10) / 2 = 10, bar 2 = 10, bar 3 = 10,
        // bar 4 = (10 + 20) / 2 = 15, bar 5 = (20 + 20) / 2 = 20.
        IndicatorSeries x = RisingFixture();

        // Act
        // (the fixture itself is the subject)

        // Assert
        x.FirstBar.ShouldBe(1);
        x.BarCount.ShouldBe(6);
        x[0].ShouldBeNull();
        x[1].ShouldBe(10.0);
        x[2].ShouldBe(10.0);
        x[3].ShouldBe(10.0);
        x[4].ShouldBe(15.0);
        x[5].ShouldBe(20.0);
    }

    [Fact]
    public void CrossedAboveIsTrueOnlyAtTheBarWhereTheLevelIsPassed()
    {
        // Arrange
        // At bar 4 the value is 15 (> 12) while at bar 3 it was 10 (<= 12): that is the transition.
        IndicatorSeries x = RisingFixture();

        // Act
        bool atCrossing = x.CrossedAbove(12.0, 4);

        // Assert
        atCrossing.ShouldBeTrue();
    }

    [Fact]
    public void CrossedAboveIsFalseWhileAlreadyAboveTheLevel()
    {
        // Arrange
        // Bar 5 is 20 and bar 4 was already 15: being above is a state, crossing is a transition.
        IndicatorSeries x = RisingFixture();

        // Act
        bool afterCrossing = x.CrossedAbove(12.0, 5);

        // Assert
        afterCrossing.ShouldBeFalse();
    }

    [Fact]
    public void CrossedAboveIsFalseBeforeTheCrossingAndCrossedBelowIsFalseOnARise()
    {
        // Arrange
        // Bar 3 is 10 and bar 2 was 10: nothing happened. And a rise is never a fall.
        IndicatorSeries x = RisingFixture();

        // Act
        bool beforeCrossing = x.CrossedAbove(12.0, 3);
        bool wrongDirection = x.CrossedBelow(12.0, 4);

        // Assert
        beforeCrossing.ShouldBeFalse();
        wrongDirection.ShouldBeFalse();
    }

    [Fact]
    public void CrossingAtTheWarmUpEdgeIsFalseButAnOutOfRangeBarStillThrows()
    {
        // Arrange
        // Bar 1 is warm but bar 0 is not, so there is no prior value and therefore no transition.
        // Bar 0 has no predecessor at all. Neither is an error: they are statements about the data
        // that is present. Bar 6 is outside [0, 6) and is a caller bug.
        IndicatorSeries x = RisingFixture();

        // Act
        bool priorBarNotWarm = x.CrossedAbove(12.0, 1);
        bool noPriorBarAtAll = x.CrossedAbove(12.0, 0);
        ArgumentOutOfRangeException outOfRange = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = x.CrossedAbove(12.0, 6);
        });

        // Assert
        priorBarNotWarm.ShouldBeFalse();
        noPriorBarAtAll.ShouldBeFalse();
        outOfRange.ParamName.ShouldBe("bar");
    }

    [Fact]
    public void CrossedBelowIsTrueOnlyAtTheBarWhereTheLevelIsPassedDownward()
    {
        // Arrange
        // bar 4 = (20 + 10) / 2 = 15, bar 5 = (10 + 10) / 2 = 10. The fall through 12.0 is at bar 5.
        IndicatorSeries x = FallingFixture();

        // Act
        bool beforeCrossing = x.CrossedBelow(12.0, 4);
        bool atCrossing = x.CrossedBelow(12.0, 5);
        bool wrongDirection = x.CrossedAbove(12.0, 5);

        // Assert
        x[4].ShouldBe(15.0);
        x[5].ShouldBe(10.0);
        beforeCrossing.ShouldBeFalse();
        atCrossing.ShouldBeTrue();
        wrongDirection.ShouldBeFalse();
    }

    [Fact]
    public void TwoSeriesFixtureHasTheValuesTheCrossingTestsRelyOn()
    {
        // Arrange
        // Closes [10, 10, 10, 10, 10, 30, 30, 30].
        // SMA(2) warm from bar 1: 10, 10, 10, 10, 20, 30, 30 on bars 1..7.
        // SMA(4) warm from bar 3: 10, 10, 15, 20, 25       on bars 3..7.
        double[] closes = EightBarCloses();

        // Act
        IndicatorSeries fast = PriceSeries.FromClose(closes).Sma(2);
        IndicatorSeries slow = PriceSeries.FromClose(closes).Sma(4);

        // Assert
        fast.FirstBar.ShouldBe(1);
        fast[1].ShouldBe(10.0);
        fast[2].ShouldBe(10.0);
        fast[3].ShouldBe(10.0);
        fast[4].ShouldBe(10.0);
        fast[5].ShouldBe(20.0);
        fast[6].ShouldBe(30.0);
        fast[7].ShouldBe(30.0);

        slow.FirstBar.ShouldBe(3);
        slow[2].ShouldBeNull();
        slow[3].ShouldBe(10.0);
        slow[4].ShouldBe(10.0);
        slow[5].ShouldBe(15.0);
        slow[6].ShouldBe(20.0);
        slow[7].ShouldBe(25.0);
    }

    [Fact]
    public void FastCrossesSlowExactlyOnceAndTheReciprocalCrossingAgrees()
    {
        // Arrange
        // At bar 5 fast is 20 and slow is 15 (fast above); at bar 4 both were 10 (fast <= slow).
        // At bar 6 fast is 30 and slow is 20, but fast was already above at bar 5.
        double[] closes = EightBarCloses();
        IndicatorSeries fast = PriceSeries.FromClose(closes).Sma(2);
        IndicatorSeries slow = PriceSeries.FromClose(closes).Sma(4);

        // Act
        bool atCrossing = fast.CrossedAbove(slow, 5);
        bool afterCrossing = fast.CrossedAbove(slow, 6);
        bool reciprocal = slow.CrossedBelow(fast, 5);

        // Assert
        atCrossing.ShouldBeTrue();
        afterCrossing.ShouldBeFalse();
        reciprocal.ShouldBeTrue();
    }

    [Fact]
    public void DifferingWarmUpsAreHandledAndMismatchedBarCountsAreRejected()
    {
        // Arrange
        // At bar 3 the slow SMA is warm but at bar 2 it is not, so there is no transition to
        // report -- the caller never has to reason about the two different warm-up lengths.
        double[] closes = EightBarCloses();
        IndicatorSeries fast = PriceSeries.FromClose(closes).Sma(2);
        IndicatorSeries slow = PriceSeries.FromClose(closes).Sma(4);
        IndicatorSeries unrelated = PriceSeries.FromClose(RampOfOneHundred()).Sma(30);

        // Act
        bool priorBarNotWarmInOther = fast.CrossedAbove(slow, 3);
        bool survivesNarrowing = fast.AsOf(6).CrossedAbove(slow.AsOf(6), 5);
        ArgumentException mismatched = Should.Throw<ArgumentException>(() =>
        {
            _ = fast.CrossedAbove(unrelated, 5);
        });

        // Assert
        priorBarNotWarmInOther.ShouldBeFalse();
        survivesNarrowing.ShouldBeTrue();
        mismatched.ShouldBeOfType<ArgumentException>();
        mismatched.ParamName.ShouldBe("other");
    }

    private static double[] RampOfOneHundred()
    {
        double[] values = new double[100];
        for (int i = 0; i < 100; i++)
        {
            values[i] = i + 1;
        }

        return values;
    }
}
