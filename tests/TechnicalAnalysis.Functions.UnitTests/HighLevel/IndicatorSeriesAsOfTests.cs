// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// Causal narrowing. <c>AsOf(bar)</c> returns a series whose <c>BarCount</c> is <c>bar + 1</c>, so the
/// future is not part of the value that was handed over: look-ahead is unrepresentable rather than
/// merely detected. These tests also pin the equivalence that makes it sound -- narrowing an
/// indicator computed over the whole series gives bit-identical values to recomputing the indicator
/// over the truncated price series.
/// </remarks>
public class IndicatorSeriesAsOfTests
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

    private static PriceSeries ConstantRangeHlc(int barCount)
    {
        // high 102, low 98, close 100 on every bar: the true range is exactly 4.0 everywhere and the
        // close sits exactly midway in the range, so ATR and Stoch have closed-form answers.
        double[] high = new double[barCount];
        double[] low = new double[barCount];
        double[] close = new double[barCount];
        Array.Fill(high, 102.0);
        Array.Fill(low, 98.0);
        Array.Fill(close, 100.0);

        return PriceSeries.FromHlc(high, low, close);
    }

    [Fact]
    public void AsOfNarrowsTheAddressableRangeWithoutMovingAnyValue()
    {
        // Arrange
        // SMA(30) over closes 1..100 is warm on bars 29..99. Narrowing to bar 50 keeps bars 29..50,
        // i.e. 50 - 29 + 1 = 22 values, and the newest of those is the mean of closes 22..51 = 36.5.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        IndicatorSeries sma = prices.Sma(30);

        // Act
        IndicatorSeries narrowed = sma.AsOf(50);

        // Assert
        narrowed.BarCount.ShouldBe(51);
        narrowed.LastBar.ShouldBe(50);
        narrowed.Latest.ShouldBe(36.5);
        narrowed.WarmCount.ShouldBe(22);
        narrowed.FirstBar.ShouldBe(29);
        narrowed[29].ShouldBe(15.5);
    }

    [Fact]
    public void AsOfMakesLookAheadUnrepresentable()
    {
        // Arrange
        // After AsOf(50) the series has BarCount 51, so bar 51 is outside [0, BarCount) and asking
        // for it is a caller bug -- not a null, and certainly not tomorrow's value.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        IndicatorSeries narrowed = prices.Sma(30).AsOf(50);

        // Act
        ArgumentOutOfRangeException exception = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = narrowed[51];
        });

        // Assert
        exception.ParamName.ShouldBe("bar");
    }

    [Fact]
    public void AsOfAtTheLastBarIsTheIdentityAndOutOfRangeBarsThrow()
    {
        // Arrange
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        IndicatorSeries sma = prices.Sma(30);

        // Act
        IndicatorSeries identity = sma.AsOf(99);
        ArgumentOutOfRangeException past = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = sma.AsOf(100);
        });

        ArgumentOutOfRangeException negative = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = sma.AsOf(-1);
        });

        // Assert
        (identity == sma).ShouldBeTrue();
        past.ParamName.ShouldBe("bar");
        negative.ParamName.ShouldBe("bar");
    }

    [Fact]
    public void AsOfAtAndBeforeTheWarmUpEdge()
    {
        // Arrange
        // Bar 29 is the first warm bar of SMA(30) over closes 1..100, value 15.5.
        // Bar 28 and anything earlier leaves no value at all, which is an empty series -- not a
        // series with a zero in it.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        IndicatorSeries sma = prices.Sma(30);

        // Act
        IndicatorSeries atEdge = sma.AsOf(29);
        IndicatorSeries justBeforeEdge = sma.AsOf(28);
        IndicatorSeries wellBeforeEdge = sma.AsOf(10);

        // Assert
        atEdge.WarmCount.ShouldBe(1);
        atEdge.Latest.ShouldBe(15.5);
        atEdge.LastBar.ShouldBe(29);

        justBeforeEdge.HasValues.ShouldBeFalse();
        justBeforeEdge.BarCount.ShouldBe(29);
        justBeforeEdge.FirstBar.ShouldBeNull();
        justBeforeEdge.Latest.ShouldBeNull();

        wellBeforeEdge.HasValues.ShouldBeFalse();
        wellBeforeEdge.BarCount.ShouldBe(11);
    }

    [Fact]
    public void SmaNarrowedEqualsSmaRecomputedOverTheNarrowedPrices()
    {
        // Arrange
        // SMA is causal, so truncating the input cannot change an earlier output. Both routes must
        // give the mean of closes 22..51 = 36.5, and they must agree exactly, not approximately.
        double[] closes = Ramp(100);

        // Act
        double? recomputed = PriceSeries.FromClose(closes).AsOf(50).Sma(30).Latest;
        double? narrowed = PriceSeries.FromClose(closes).Sma(30).AsOf(50).Latest;

        // Assert
        recomputed.ShouldBe(36.5);
        narrowed.ShouldBe(36.5);
        recomputed.ShouldBe(narrowed);
    }

    [Fact]
    public void RsiNarrowedEqualsRsiRecomputedOverTheNarrowedPrices()
    {
        // Arrange
        // Closes 1..100 rise by exactly 1 every bar, so there is never a down-move: Wilder's
        // average loss stays 0 and RSI = 100 * gain / (gain + 0) = 100.0 exactly on every warm bar.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        double? recomputed = prices.AsOf(60).Rsi(14).Latest;
        double? fromFullSeries = prices.Rsi(14)[60];

        // Assert
        recomputed.ShouldBe(100.0);
        fromFullSeries.ShouldBe(100.0);
        recomputed.ShouldBe(fromFullSeries);
    }

    [Fact]
    public void MacdNarrowedEqualsMacdRecomputedOverTheNarrowedPrices()
    {
        // Arrange
        // On a unit-slope ramp an N-period EMA seeded with the SMA of the first N closes sits
        // exactly (N - 1) / 2 below the price. MACD = EMA(12) - EMA(26) = 12.5 - 5.5 = 7.0 on
        // every warm bar, and the arithmetic is exact in binary floating point.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        double? recomputed = prices.AsOf(60).Macd().Line.Latest;
        double? fromFullSeries = prices.Macd().Line[60];

        // Assert
        recomputed.ShouldBe(7.0);
        fromFullSeries.ShouldBe(7.0);
        recomputed.ShouldBe(fromFullSeries);
    }

    [Fact]
    public void AtrNarrowedEqualsAtrRecomputedAndMultiOutputAsOfNarrowsEveryComponent()
    {
        // Arrange
        // Constant true range of 4.0 on every bar, so Wilder's average of it is exactly 4.0.
        PriceSeries hlc = ConstantRangeHlc(60);

        // Act
        double? recomputed = hlc.AsOf(40).Atr(14).Latest;
        double? fromFullSeries = hlc.Atr(14)[40];

        MacdSeries macd = PriceSeries.FromClose(Ramp(100)).Macd().AsOf(60);
        BollingerBandsSeries bands = PriceSeries.FromClose(Ramp(100)).BollingerBands(20, 2.0, 2.0).AsOf(60);
        StochSeries stoch = hlc.Stoch().AsOf(40);

        // Assert
        recomputed.ShouldBe(4.0);
        fromFullSeries.ShouldBe(4.0);
        recomputed.ShouldBe(fromFullSeries);

        macd.Line.BarCount.ShouldBe(61);
        macd.Signal.BarCount.ShouldBe(61);
        macd.Histogram.BarCount.ShouldBe(61);
        macd.Line.LastBar.ShouldBe(60);

        bands.Upper.BarCount.ShouldBe(61);
        bands.Middle.BarCount.ShouldBe(61);
        bands.Lower.BarCount.ShouldBe(61);
        bands.Middle.LastBar.ShouldBe(60);

        stoch.SlowK.BarCount.ShouldBe(41);
        stoch.SlowD.BarCount.ShouldBe(41);
        stoch.SlowK.LastBar.ShouldBe(40);
    }
}
