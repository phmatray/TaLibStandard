// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// Value-asserting tests for the overlap studies, plus the two cross-cutting rules that live here by
/// the specification's file assignment: every default is TA-Lib's verbatim, and every indicator over
/// an empty price series returns an empty series rather than throwing.
/// </remarks>
public class OverlapStudyIndicatorsTests
{
    private static double[] Ramp(int count)
    {
        double[] values = new double[count];
        for (int i = 0; i < count; i++)
        {
            values[i] = i + 1;
        }

        return values;
    }

    private static double[] Constant(int count, double value)
    {
        double[] values = new double[count];
        Array.Fill(values, value);
        return values;
    }

    private static PriceSeries ConstantRangeHlc(int barCount)
    {
        return PriceSeries.FromHlc(Constant(barCount, 102.0), Constant(barCount, 98.0), Constant(barCount, 100.0));
    }

    // Equality on IndicatorSeries is reference identity over the backing array, so two independently
    // computed series are never equal even when every value agrees. Comparing them therefore has to
    // compare shape and every bar's value.
    private static void ShouldMatch(IndicatorSeries expected, IndicatorSeries actual)
    {
        actual.RetCode.ShouldBe(expected.RetCode);
        actual.BarCount.ShouldBe(expected.BarCount);
        actual.FirstBar.ShouldBe(expected.FirstBar);
        actual.LastBar.ShouldBe(expected.LastBar);
        actual.WarmCount.ShouldBe(expected.WarmCount);

        for (int bar = 0; bar < expected.BarCount; bar++)
        {
            actual[bar].ShouldBe(expected[bar], $"Bar {bar} differs.");
        }
    }

    private static void ShouldBeEmptyWithNoBars(IndicatorSeries series)
    {
        series.HasValues.ShouldBeFalse();
        series.BarCount.ShouldBe(0);
        series.RetCode.ShouldBe(RetCode.Success);
        series.ToBarAlignedArray().Length.ShouldBe(0);
    }

    [Fact]
    public void SmaAtTheExactLowerBoundaryProducesOneValueAndOneFewerBarProducesNone()
    {
        // Arrange
        // Thirty closes 1..30 is the shortest series a 30-period SMA can warm up on: exactly one
        // value, the mean of 1..30 = 15.5, landing on bar 29.
        PriceSeries exactly = PriceSeries.FromClose(Ramp(30));
        PriceSeries oneShort = PriceSeries.FromClose(Ramp(29));

        // Act
        IndicatorSeries warm = exactly.Sma(30);
        IndicatorSeries cold = oneShort.Sma(30);

        // Assert
        warm.WarmCount.ShouldBe(1);
        warm.FirstBar.ShouldBe(29);
        warm.LastBar.ShouldBe(29);
        warm.Latest.ShouldBe(15.5);
        warm[28].ShouldBeNull();
        cold.HasValues.ShouldBeFalse();
    }

    [Fact]
    public void SmaWithTheSmallestLegalPeriod()
    {
        // Arrange
        // SMA(2) over [1, 2, 3]: bar 1 = (1 + 2) / 2 = 1.5, bar 2 = (2 + 3) / 2 = 2.5.
        PriceSeries prices = PriceSeries.FromClose([1.0, 2.0, 3.0]);

        // Act
        IndicatorSeries sma = prices.Sma(2);

        // Assert
        sma.FirstBar.ShouldBe(1);
        sma.WarmCount.ShouldBe(2);
        sma[0].ShouldBeNull();
        sma[1].ShouldBe(1.5);
        sma[2].ShouldBe(2.5);
    }

    [Fact]
    public void EmaOverAConstantSeriesEqualsTheConstantExactly()
    {
        // Arrange
        // An exponential average of a constant must be that constant: the seed is the mean of the
        // first twenty 100s and every later bar is 100 + (100 - 100) * k. Anything lower means the
        // seeding loop dropped a term, which is the TA_INT_EMA defect already fixed on this branch.
        PriceSeries prices = PriceSeries.FromClose(Constant(100, 100.0));

        // Act
        IndicatorSeries ema = prices.Ema(20);

        // Assert
        ema.Latest.ShouldBe(100.0);
        ema.FirstBar.ShouldBe(19);
        ema.WarmCount.ShouldBe(81);
        foreach ((int _, double value) in ema)
        {
            value.ShouldBe(100.0);
        }
    }

    [Fact]
    public void BollingerBandsMiddleBandIsTheSimpleMovingAverage()
    {
        // Arrange
        // Closes 1..100 with a 20-period window. Middle at bar 99 is the mean of closes 81..100
        // = (81 + 100) / 2 = 90.5; at bar 19 it is the mean of closes 1..20 = 10.5.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        BollingerBandsSeries bands = prices.BollingerBands(20, 2.0, 2.0);

        // Assert
        bands.Middle.Latest.ShouldBe(90.5);
        bands.Middle.FirstBar.ShouldBe(19);
        bands.Middle.WarmCount.ShouldBe(81);
        bands.Middle[19].ShouldBe(10.5);
    }

    [Fact]
    public void BollingerBandsEnvelopeIsTwoPopulationStandardDeviationsWide()
    {
        // Arrange
        // The population standard deviation of n consecutive integers is sqrt((n^2 - 1) / 12);
        // for n = 20 that is sqrt(399 / 12) = sqrt(33.25) = 5.766281297335398.
        // Every intermediate value here is exactly representable -- the running sum of squares for
        // closes 81..100 is 164470, 164470 / 20 = 8223.5, 90.5 * 90.5 = 8190.25 and the difference
        // is exactly 33.25 -- so exact equality is the right assertion, not a tolerance.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        BollingerBandsSeries bands = prices.BollingerBands(20, 2.0, 2.0);

        // Assert
        bands.Upper.Latest.ShouldBe(90.5 + (2.0 * Math.Sqrt(33.25)));
        bands.Lower.Latest.ShouldBe(90.5 - (2.0 * Math.Sqrt(33.25)));
    }

    [Fact]
    public void AllThreeBollingerComponentsAreIndependentlyValidAndShareTheirAlignment()
    {
        // Arrange
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        BollingerBandsSeries bands = prices.BollingerBands(20, 2.0, 2.0);
        (IndicatorSeries upper, IndicatorSeries middle, IndicatorSeries lower) = bands;

        // Assert
        upper.FirstBar.ShouldBe(19);
        middle.FirstBar.ShouldBe(19);
        lower.FirstBar.ShouldBe(19);
        upper.WarmCount.ShouldBe(81);
        middle.WarmCount.ShouldBe(81);
        lower.WarmCount.ShouldBe(81);
        upper.BarCount.ShouldBe(100);
        middle.BarCount.ShouldBe(100);
        lower.BarCount.ShouldBe(100);

        // Each is independently addressable by bar index and the envelope brackets the middle.
        upper[19]!.Value.ShouldBeGreaterThan(middle[19]!.Value);
        lower[19]!.Value.ShouldBeLessThan(middle[19]!.Value);
        upper[99]!.Value.ShouldBeGreaterThan(middle[99]!.Value);
    }

    [Fact]
    public void BollingerBandsDefaultPeriodIsTaLibsFiveAndNotTheTaughtTwenty()
    {
        // Arrange
        // TA-Lib's BBANDS default is 5 even though 20 is the conventional trading choice. The rule
        // is that the fluent layer never invents a number, so this test exists specifically to stop
        // the default silently drifting to 20.
        // With period 5 over closes 1..100: bar 4's mean is (1 + 5) / 2 = 3.0 and the population
        // standard deviation of 1..5 is sqrt(55/5 - 9) = sqrt(2), so Upper[4] = 3 + 2 * sqrt(2).
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        BollingerBandsSeries defaulted = prices.BollingerBands();
        BollingerBandsSeries explicitly = prices.BollingerBands(5, 2.0, 2.0, MAType.Sma);

        // Assert
        defaulted.Middle.FirstBar.ShouldBe(4);
        defaulted.Middle[4].ShouldBe(3.0);
        defaulted.Upper[4].ShouldBe(3.0 + (2.0 * Math.Sqrt(2.0)));
        ShouldMatch(explicitly.Upper, defaulted.Upper);
        ShouldMatch(explicitly.Middle, defaulted.Middle);
        ShouldMatch(explicitly.Lower, defaulted.Lower);
    }

    [Fact]
    public void EveryIndicatorDefaultIsCopiedVerbatimFromTaMath()
    {
        // Arrange
        // The Stoch case is the one that matters most: the abandoned branch silently redefined
        // fastKPeriod from TA-Lib's 5 to 14, which changes every value it ever produced.
        PriceSeries closes = PriceSeries.FromClose(Ramp(100));
        PriceSeries hlc = ConstantRangeHlc(60);

        // Act
        IndicatorSeries sma = closes.Sma();
        IndicatorSeries ema = closes.Ema();
        IndicatorSeries rsi = closes.Rsi();
        IndicatorSeries atr = hlc.Atr();
        MacdSeries macd = closes.Macd();
        StochSeries stoch = hlc.Stoch();

        // Assert
        ShouldMatch(closes.Sma(30), sma);
        ShouldMatch(closes.Ema(30), ema);
        ShouldMatch(closes.Rsi(14), rsi);
        ShouldMatch(hlc.Atr(14), atr);

        MacdSeries explicitMacd = closes.Macd(12, 26, 9);
        ShouldMatch(explicitMacd.Line, macd.Line);
        ShouldMatch(explicitMacd.Signal, macd.Signal);
        ShouldMatch(explicitMacd.Histogram, macd.Histogram);

        StochSeries explicitStoch = hlc.Stoch(5, 3, MAType.Sma, 3, MAType.Sma);
        ShouldMatch(explicitStoch.SlowK, stoch.SlowK);
        ShouldMatch(explicitStoch.SlowD, stoch.SlowD);
    }

    [Fact]
    public void EveryIndicatorOverAnEmptyPriceSeriesReturnsAnEmptySeries()
    {
        // Arrange
        // TAMath is never called for an empty series, because endIdx would be -1 and that returns
        // OutOfRangeEndIndex -- not a state worth propagating.
        // Atr and Stoch need high/low, and the availability guard runs before the emptiness
        // short-circuit, so their fixture is an empty high/low/close feed rather than default.
        PriceSeries emptyClose = PriceSeries.Empty;
        PriceSeries emptyHlc = PriceSeries.FromHlc([], [], []);

        // Act
        IndicatorSeries sma = emptyClose.Sma(30);
        IndicatorSeries ema = emptyClose.Ema(30);
        IndicatorSeries rsi = emptyClose.Rsi(14);
        MacdSeries macd = emptyClose.Macd();
        BollingerBandsSeries bands = emptyClose.BollingerBands();
        IndicatorSeries atr = emptyHlc.Atr(14);
        StochSeries stoch = emptyHlc.Stoch();

        // Assert
        emptyHlc.HasHighLow.ShouldBeTrue();

        ShouldBeEmptyWithNoBars(sma);
        ShouldBeEmptyWithNoBars(ema);
        ShouldBeEmptyWithNoBars(rsi);
        ShouldBeEmptyWithNoBars(atr);
        ShouldBeEmptyWithNoBars(macd.Line);
        ShouldBeEmptyWithNoBars(macd.Signal);
        ShouldBeEmptyWithNoBars(macd.Histogram);
        ShouldBeEmptyWithNoBars(bands.Upper);
        ShouldBeEmptyWithNoBars(bands.Middle);
        ShouldBeEmptyWithNoBars(bands.Lower);
        ShouldBeEmptyWithNoBars(stoch.SlowK);
        ShouldBeEmptyWithNoBars(stoch.SlowD);
    }

    [Fact]
    public void APeriodLargerThanTheDataIsNotAnError()
    {
        // Arrange
        // Three closes and a thirty-period SMA is a perfectly ordinary warm-up state, so it returns
        // an empty series with Success rather than throwing or reporting a bad parameter.
        PriceSeries prices = PriceSeries.FromClose([1.0, 2.0, 3.0]);

        // Act
        IndicatorSeries sma = prices.Sma(30);

        // Assert
        sma.HasValues.ShouldBeFalse();
        sma.RetCode.ShouldBe(RetCode.Success);
        sma.BarCount.ShouldBe(3);
        sma.FirstBar.ShouldBeNull();
        sma.Latest.ShouldBeNull();
    }

    [Fact]
    public void EmaTrailsARampByHalfTheLookbackSoEveryWarmBarHasItsOwnAnswer()
    {
        // Arrange
        // On a slope-1 ramp an N-period EMA seeded with the mean of the first N closes is already
        // at its steady state, sitting exactly (N - 1) / 2 below price and staying there. For
        // N = 20 that is price - 9.5 on every warm bar, which is a different number on every bar --
        // unlike the constant fixture, where EMA is 100 everywhere and a shift is invisible.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        IndicatorSeries ema = prices.Ema(20);

        // Assert
        ema.FirstBar.ShouldBe(19);
        ema.WarmCount.ShouldBe(81);
        ema[19].Value.ShouldBe(10.5, 1e-9);
        ema[50].Value.ShouldBe(41.5, 1e-9);
        ema[99].Value.ShouldBe(90.5, 1e-9);
        ema[18].ShouldBeNull();

        foreach ((int bar, double value) in ema)
        {
            value.ShouldBe(bar + 1.0 - 9.5, 1e-9, $"EMA was {value} at bar {bar}.");
        }
    }

    [Fact]
    public void PriceSeriesEmptyCarriesNoComponentsSoTheRangeIndicatorsRefuseIt()
    {
        // Arrange
        // PriceSeries.Empty is default(PriceSeries), so it carries no high, low or volume at all and
        // the component guard -- which runs before the emptiness short-circuit -- refuses. This is
        // the documented behaviour rather than an accident, and the component-agnostic empty feed
        // is FromOhlcv with five empty spans.
        PriceSeries none = PriceSeries.Empty;
        PriceSeries emptyOhlcv = PriceSeries.FromOhlcv([], [], [], [], []);

        // Act
        // (the refusals are asserted below)

        // Assert
        none.HasHighLow.ShouldBeFalse();
        none.HasVolume.ShouldBeFalse();

        Should.Throw<InvalidOperationException>(() => { _ = none.Atr(14); });
        Should.Throw<InvalidOperationException>(() => { _ = none.Stoch(); });
        Should.Throw<InvalidOperationException>(() => { _ = none.Adx(14); });
        Should.Throw<InvalidOperationException>(() => { _ = none.Obv(); });

        // The close-only indicators are happy with it.
        ShouldBeEmptyWithNoBars(none.Sma(30));
        ShouldBeEmptyWithNoBars(none.Ema(30));
        ShouldBeEmptyWithNoBars(none.Rsi(14));
        ShouldBeEmptyWithNoBars(none.Macd().Line);
        ShouldBeEmptyWithNoBars(none.BollingerBands().Middle);

        // And the fully-populated empty feed answers every one of them.
        emptyOhlcv.HasHighLow.ShouldBeTrue();
        emptyOhlcv.HasVolume.ShouldBeTrue();
        ShouldBeEmptyWithNoBars(emptyOhlcv.Atr(14));
        ShouldBeEmptyWithNoBars(emptyOhlcv.Adx(14));
        ShouldBeEmptyWithNoBars(emptyOhlcv.Obv());
        ShouldBeEmptyWithNoBars(emptyOhlcv.Stoch().SlowK);
    }
}
