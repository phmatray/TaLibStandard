// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// Value-asserting tests for the volatility studies, and the refusal that matters most here: close-only
/// data can never produce a true range, so it must raise rather than quietly measure something else.
/// </remarks>
public class VolatilityIndicatorsTests
{
    private static double[] Constant(int count, double value)
    {
        double[] values = new double[count];
        Array.Fill(values, value);
        return values;
    }

    private static double[] Ramp(int count)
    {
        double[] values = new double[count];
        for (int i = 0; i < count; i++)
        {
            values[i] = i + 1;
        }

        return values;
    }

    [Fact]
    public void AtrOverAConstantTrueRangeEqualsThatTrueRangeExactly()
    {
        // Arrange
        // Sixty bars of high 102, low 98, close 100. On every bar the true range is
        // max(102 - 98, |102 - 100|, |98 - 100|) = 4.0, so the seed is the mean of fourteen 4s = 4
        // and each later bar is (4 * 13 + 4) / 14 = 4. Wilder's average of a constant is that
        // constant, exactly -- no tolerance is warranted and none is used.
        // This also pins the ATR normalisation fix on this branch: the running average used to be
        // left multiplied by (period - 1) every bar and diverged geometrically to +Infinity.
        PriceSeries prices = PriceSeries.FromHlc(Constant(60, 102.0), Constant(60, 98.0), Constant(60, 100.0));

        // Act
        IndicatorSeries atr = prices.Atr(14);

        // Assert
        atr.Latest.ShouldBe(4.0);
        atr[14].ShouldBe(4.0);
        atr.FirstBar.ShouldBe(14);
        atr.WarmCount.ShouldBe(46);
        atr.BarCount.ShouldBe(60);
        atr[13].ShouldBeNull();

        foreach ((int bar, double value) in atr)
        {
            double.IsFinite(value).ShouldBeTrue($"ATR was {value} at bar {bar}.");
            value.ShouldBe(4.0);
        }
    }

    [Fact]
    public void AtrRefusesCloseOnlyDataRatherThanFabricatingARange()
    {
        // Arrange
        // The abandoned branch's FromClose set Open = High = Low = Close, which makes ATR compute
        // the absolute close-to-close change and present it as a true range. Refusing is the only
        // honest answer: there is no high and no low to measure.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        // (the call is made inside the assertion below)

        // Assert
        Should.Throw<InvalidOperationException>(() =>
        {
            _ = prices.Atr(14);
        });
    }

    [Fact]
    public void StochRefusesCloseOnlyDataForTheSameReason()
    {
        // Arrange
        // %K is the close's position inside the high/low range of the window. Without a range there
        // is no position, and substituting the close for both bounds would report a constant zero.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        // (the call is made inside the assertion below)

        // Assert
        Should.Throw<InvalidOperationException>(() =>
        {
            _ = prices.Stoch();
        });
    }

    [Fact]
    public void AtrReadsTheHighAndTheLowInThatOrderAndNotTheOtherWayRound()
    {
        // Arrange
        // With high 102, low 98 and close 100 the true range is max(4, 2, 2) = 4 and ATR is 4.
        // Reverse the two arguments and the range term becomes 98 - 102 = -4, so the true range
        // collapses to max(-4, 2, 2) = 2 and ATR reads 2. Nothing else in the suite would notice
        // the swap, because every other assertion about this fixture is shape rather than value.
        PriceSeries correct = PriceSeries.FromHlc(Constant(60, 102.0), Constant(60, 98.0), Constant(60, 100.0));
        PriceSeries swapped = PriceSeries.FromHlc(Constant(60, 98.0), Constant(60, 102.0), Constant(60, 100.0));

        // Act
        IndicatorSeries fromCorrect = correct.Atr(14);
        IndicatorSeries fromSwapped = swapped.Atr(14);

        // Assert
        fromCorrect.Latest.ShouldBe(4.0);
        fromSwapped.Latest.ShouldBe(2.0);
        fromSwapped.Latest.ShouldNotBe(fromCorrect.Latest);
    }

    [Fact]
    public void AtrRisesAndFallsWithTheRangeSoEveryWarmBarHasItsOwnAnswer()
    {
        // Arrange
        // Close pinned at 100 with a range that widens from 2 to 20 points over the series:
        // high = 100 + r, low = 100 - r with r = 1 + bar / 10, so the true range on bar b is
        // max(2r, r, r) = 2r = 2 + bar / 5 and grows monotonically. Wilder's average of a strictly
        // increasing sequence is itself strictly increasing, so no two warm bars agree and it lags
        // the current true range -- which a constant-range fixture cannot show at all.
        double[] high = new double[100];
        double[] low = new double[100];
        double[] close = Constant(100, 100.0);
        for (int bar = 0; bar < 100; bar++)
        {
            double halfRange = 1.0 + (bar / 10.0);
            high[bar] = 100.0 + halfRange;
            low[bar] = 100.0 - halfRange;
        }

        PriceSeries prices = PriceSeries.FromHlc(high, low, close);

        // Act
        IndicatorSeries atr = prices.Atr(14);

        // Assert
        atr.FirstBar.ShouldBe(14);
        atr.WarmCount.ShouldBe(86);

        double? previous = null;
        int warmBars = 0;
        foreach ((int bar, double value) in atr)
        {
            double trueRange = 2.0 + (bar / 5.0);
            double.IsFinite(value).ShouldBeTrue($"ATR was {value} at bar {bar}.");

            // Wilder's average trails the current true range on a widening series, and never by
            // more than the whole range: a value at or above the current true range would mean the
            // smoothing is reading a later bar than it should.
            value.ShouldBeLessThan(trueRange);
            value.ShouldBeGreaterThan(trueRange / 2.0);

            if (previous is { } earlier)
            {
                value.ShouldBeGreaterThan(earlier);
            }

            previous = value;
            warmBars++;
        }

        warmBars.ShouldBe(86);
    }
}
