// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Reflection;

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// The entry point. It owns the copy (so immutability is unconditional rather than promised), the
/// ragged-length rejection, the component-availability rules, and the <c>Align</c> escape hatch that
/// bar-aligns the ninety-odd indicators the fluent surface does not wrap.
/// </remarks>
public class PriceSeriesTests
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

    // Spans cannot be captured by a lambda, so the component accessors are exercised through these.
    private static int OpenLength(PriceSeries prices)
    {
        return prices.Open.Length;
    }

    private static int HighLength(PriceSeries prices)
    {
        return prices.High.Length;
    }

    private static int LowLength(PriceSeries prices)
    {
        return prices.Low.Length;
    }

    private static int VolumeLength(PriceSeries prices)
    {
        return prices.Volume.Length;
    }

    [Fact]
    public void FactoriesCopyTheirInputSoLaterMutationCannotBeObserved()
    {
        // Arrange
        // SMA(2) over [10, 20, 30, 40] is 15, 25, 35 on bars 1..3. If the factory kept a reference,
        // mutating element 0 to 1000 after construction would make bar 1 read (1000 + 20) / 2 = 510.
        double[] closes = [10.0, 20.0, 30.0, 40.0];
        PriceSeries prices = PriceSeries.FromClose(closes);

        // Act
        closes[0] = 1000.0;
        IndicatorSeries sma = prices.Sma(2);

        // Assert
        prices.Close[0].ShouldBe(10.0);
        sma[1].ShouldBe(15.0);
        sma[2].ShouldBe(25.0);
        sma[3].ShouldBe(35.0);
    }

    [Fact]
    public void RaggedComponentArraysAreRejectedNamingTheOffendingParameter()
    {
        // Arrange
        // close defines the length; every other component must match it, checked in the order
        // open, high, low, volume. Without this guard TAMath.Atr throws IndexOutOfRangeException
        // from deep inside TAFunc. Only the exception type and ParamName are contractual.
        double[] hundred = new double[100];

        // Act
        ArgumentException shortHigh = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromHlc(new double[50], hundred, hundred);
        });

        ArgumentException shortOpen = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromOhlc(new double[50], hundred, hundred, hundred);
        });

        ArgumentException shortLow = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromOhlc(hundred, hundred, new double[50], hundred);
        });

        // Assert
        shortHigh.ShouldBeOfType<ArgumentException>();
        shortHigh.ParamName.ShouldBe("high");
        shortOpen.ShouldBeOfType<ArgumentException>();
        shortOpen.ParamName.ShouldBe("open");
        shortLow.ShouldBeOfType<ArgumentException>();
        shortLow.ParamName.ShouldBe("low");
    }

    [Fact]
    public void AnEmptyFeedIsALegalPriceSeries()
    {
        // Arrange
        // A zero-length feed is a normal state for a streaming engine; throwing here would force
        // defensive code at every call site.
        double[] nothing = [];

        // Act
        PriceSeries prices = PriceSeries.FromClose(nothing);

        // Assert
        prices.BarCount.ShouldBe(0);
        prices.IsEmpty.ShouldBeTrue();
        prices.Close.Length.ShouldBe(0);
    }

    [Fact]
    public void ComponentAvailabilityReflectsTheFactoryThatWasUsed()
    {
        // Arrange
        double[] bars = Ramp(10);

        // Act
        PriceSeries close = PriceSeries.FromClose(bars);
        PriceSeries hlc = PriceSeries.FromHlc(bars, bars, bars);
        PriceSeries ohlc = PriceSeries.FromOhlc(bars, bars, bars, bars);
        PriceSeries ohlcv = PriceSeries.FromOhlcv(bars, bars, bars, bars, bars);

        // Assert
        close.HasOpen.ShouldBeFalse();
        close.HasHighLow.ShouldBeFalse();
        close.HasVolume.ShouldBeFalse();

        hlc.HasHighLow.ShouldBeTrue();
        hlc.HasOpen.ShouldBeFalse();
        hlc.HasVolume.ShouldBeFalse();

        ohlc.HasOpen.ShouldBeTrue();
        ohlc.HasHighLow.ShouldBeTrue();
        ohlc.HasVolume.ShouldBeFalse();

        ohlcv.HasOpen.ShouldBeTrue();
        ohlcv.HasHighLow.ShouldBeTrue();
        ohlcv.HasVolume.ShouldBeTrue();
    }

    [Fact]
    public void AbsentComponentsThrowRatherThanFabricatingData()
    {
        // Arrange
        // The abandoned branch's FromClose set Open = High = Low = Close, which makes ATR compute
        // the absolute close-to-close change and call it a true range. Absence must be loud.
        double[] bars = Ramp(10);
        PriceSeries closeOnly = PriceSeries.FromClose(bars);
        PriceSeries hlc = PriceSeries.FromHlc(bars, bars, bars);
        PriceSeries ohlc = PriceSeries.FromOhlc(bars, bars, bars, bars);

        // Act
        // (each accessor is invoked inside the assertions below)

        // Assert
        Should.Throw<InvalidOperationException>(() =>
        {
            _ = HighLength(closeOnly);
        });

        Should.Throw<InvalidOperationException>(() =>
        {
            _ = LowLength(closeOnly);
        });

        Should.Throw<InvalidOperationException>(() =>
        {
            _ = OpenLength(closeOnly);
        });

        Should.Throw<InvalidOperationException>(() =>
        {
            _ = VolumeLength(closeOnly);
        });

        Should.Throw<InvalidOperationException>(() =>
        {
            _ = OpenLength(hlc);
        });

        Should.Throw<InvalidOperationException>(() =>
        {
            _ = VolumeLength(ohlc);
        });
    }

    [Fact]
    public void AsOfTruncatesEveryComponentAndKeepsBarIndicesAbsolute()
    {
        // Arrange
        // Closes 1..100, so bar 50 holds 51.0 and still holds 51.0 after narrowing -- AsOf never
        // rebases bar indices, which is exactly why Slice does not exist.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        PriceSeries narrowed = prices.AsOf(50);
        ArgumentOutOfRangeException past = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = prices.AsOf(100);
        });

        ArgumentOutOfRangeException negative = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = prices.AsOf(-1);
        });

        // Assert
        narrowed.BarCount.ShouldBe(51);
        narrowed.Close.Length.ShouldBe(51);
        narrowed.Close[50].ShouldBe(51.0);
        past.ParamName.ShouldBe("bar");
        negative.ParamName.ShouldBe("bar");
    }

    [Fact]
    public void AlignBarAlignsAnySingleOutputResult()
    {
        // Arrange
        // CCI(20) with high = close + 1 and low = close - 1 has typical price
        // ((c + 1) + (c - 1) + c) / 3 = c, i.e. the ramp itself. At bar 99 the mean of closes
        // 81..100 is 90.5 and the mean absolute deviation of twenty consecutive integers about
        // their mean is 5.0, so CCI = (100 - 90.5) / (0.015 * 5.0) = 9.5 / 0.075 = 126.6666...
        double[] closes = Ramp(100);
        double[] high = new double[100];
        double[] low = new double[100];
        for (int i = 0; i < 100; i++)
        {
            high[i] = closes[i] + 1.0;
            low[i] = closes[i] - 1.0;
        }

        PriceSeries prices = PriceSeries.FromHlc(high, low, closes);

        // Act
        IndicatorSeries cci = prices.Align(TAMath.Cci(0, 99, high, low, closes, 20));

        // Assert
        cci.FirstBar.ShouldBe(19);
        cci.WarmCount.ShouldBe(81);
        cci.BarCount.ShouldBe(100);
        cci.Latest.HasValue.ShouldBeTrue();
        cci.Latest.Value.ShouldBe(126.66666666666667, 1e-9);
    }

    [Fact]
    public void AlignWithASelectorBarAlignsOneComponentOfAMultiOutputResult()
    {
        // Arrange
        // The selector, rather than a two-argument Align(metadata, array), is what prevents pairing
        // one result's metadata with another result's array.
        double[] closes = Ramp(100);
        PriceSeries prices = PriceSeries.FromClose(closes);
        BollingerBandsResult raw = TAMath.BollingerBands(0, 99, closes, 20, 2.0, 2.0, MAType.Sma);

        // Act
        IndicatorSeries viaAlign = prices.Align(raw, static r => r.RealUpperBand);
        IndicatorSeries viaFacade = prices.BollingerBands(20, 2.0, 2.0).Upper;

        // Assert
        viaAlign.FirstBar.ShouldBe(19);
        viaFacade.FirstBar.ShouldBe(19);
        viaAlign.WarmCount.ShouldBe(viaFacade.WarmCount);
        viaAlign.Latest.ShouldBe(viaFacade.Latest);
        viaAlign.Latest.ShouldBe(90.5 + (2.0 * Math.Sqrt(33.25)));
    }

    [Fact]
    public void AlignRejectsNullArguments()
    {
        // Arrange
        double[] closes = Ramp(100);
        PriceSeries prices = PriceSeries.FromClose(closes);
        BollingerBandsResult raw = TAMath.BollingerBands(0, 99, closes, 20, 2.0, 2.0, MAType.Sma);

        // Act
        // (both calls are made inside the assertions below)

        // Assert
        Should.Throw<ArgumentNullException>(() =>
        {
            _ = prices.Align(null!);
        });

        Should.Throw<ArgumentNullException>(() =>
        {
            _ = prices.Align(raw, null!);
        });
    }

    [Fact]
    public void AlignAcceptsTheDxFamilyNowThatItsSeedingLoopsRunTheRightNumberOfTimes()
    {
        // Arrange
        // Adx, Dx, PlusDI and MinusDI used to share a loop-translation defect: their seeding loops
        // ran period - 2 times where the reference runs period - 1, so BegIdx + NBElement landed
        // exactly two past the end of the price series and every value was misaligned by two bars.
        // Over 100 bars ADX(14) reported BegIdx = 27 and NBElement = 75, and 27 + 75 = 102 > 100,
        // which made this the one family Align could not accept. The lookback of ADX(14) is
        // 2 * 14 + 0 - 1 = 27, so the correct metadata is BegIdx = 27, NBElement = 73, summing to
        // exactly the bar count.
        double[] closes = Ramp(100);
        double[] high = new double[100];
        double[] low = new double[100];
        for (int i = 0; i < 100; i++)
        {
            high[i] = closes[i] + 1.0;
            low[i] = closes[i] - 1.0;
        }

        PriceSeries prices = PriceSeries.FromHlc(high, low, closes);
        AdxResult raw = TAMath.Adx(0, 99, high, low, closes, 14);

        // Act
        IndicatorSeries adx = prices.Align(raw);

        // Assert
        raw.RetCode.ShouldBe(RetCode.Success);
        raw.BegIdx.ShouldBe(27);
        raw.NBElement.ShouldBe(73);
        (raw.BegIdx + raw.NBElement).ShouldBe(prices.BarCount);
        adx.FirstBar.ShouldBe(27);
        adx.LastBar.ShouldBe(99);
        adx.WarmCount.ShouldBe(73);
    }

    [Fact]
    public void AlignBlamesItsOwnParameterWhenAnIndicatorReportsInconsistentMetadata()
    {
        // Arrange
        // IndicatorSeries.Create throws naming nbElement or values, which name nothing the caller
        // of Align passed -- and worse, they read as "your argument is bad" when the fault is the
        // indicator's metadata. Align re-blames the one argument the caller can see. The stand-in
        // for a defective indicator is a hand-built result claiming bars 90..109 of a 100-bar
        // series.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        SmaResult inconsistent = new(RetCode.Success, 90, 20, new double[100]);

        // Act
        ArgumentException thrown = Should.Throw<ArgumentException>(() =>
        {
            _ = prices.Align(inconsistent);
        });

        // Assert
        thrown.ParamName.ShouldBe("result");
        thrown.InnerException.ShouldBeOfType<ArgumentException>();
        thrown.Message.ShouldContain("90..109");
    }

    [Fact]
    public void FactoriesRejectNonFinitePricesNamingTheComponentAndTheFirstBadBar()
    {
        // Arrange
        // TA_INT_SMA keeps a running sum: once periodTotal is NaN, `NaN - finite` is NaN for ever
        // after, so one bad tick at bar 40 poisons every SMA value from bar 40 to the end while
        // RetCode stays Success and the indexer keeps returning a non-null double.NaN. Refusing at
        // the boundary is the only place the failure is still diagnosable.
        double[] withNaN = Ramp(100);
        withNaN[40] = double.NaN;
        double[] withInfinity = Ramp(100);
        withInfinity[7] = double.PositiveInfinity;
        double[] clean = Ramp(100);

        // Act
        ArgumentException nan = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromClose(withNaN);
        });

        ArgumentException infinite = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromClose(withInfinity);
        });

        ArgumentException badHigh = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromHlc(withNaN, clean, clean);
        });

        ArgumentException badVolume = Should.Throw<ArgumentException>(() =>
        {
            _ = PriceSeries.FromOhlcv(clean, clean, clean, clean, withNaN);
        });

        // Assert
        nan.ParamName.ShouldBe("close");
        nan.Message.ShouldContain("bar 40");
        infinite.ParamName.ShouldBe("close");
        infinite.Message.ShouldContain("bar 7");
        badHigh.ParamName.ShouldBe("high");
        badVolume.ParamName.ShouldBe("volume");
    }

    [Fact]
    public void AlignCopiesSoLaterMutationOfTheRawResultCannotReachTheSeries()
    {
        // Arrange
        // result.Real is a public get-only property returning the live array, so a caller who
        // post-processes it in place -- clipping, smoothing, back-filling -- would otherwise mutate
        // an IndicatorSeries already handed out, possibly one another thread is reading. The type
        // promises unconditional immutability, so Align pays for a copy.
        double[] closes = Ramp(100);
        PriceSeries prices = PriceSeries.FromClose(closes);
        SmaResult raw = TAMath.Sma(0, 99, closes, 30);

        // Act
        IndicatorSeries sma = prices.Align(raw);
        raw.Real[70] = 999.0;

        // Assert
        sma[99].ShouldBe(85.5);
        sma.Latest.ShouldBe(85.5);
        sma.WarmValues[70].ShouldBe(85.5);
    }

    [Fact]
    public void NoPublicAlignOverloadAcceptsABarCount()
    {
        // Arrange
        // Align supplies BarCount itself, so a mismatched bar count is not merely discouraged --
        // it is unrepresentable.
        MethodInfo[] alignOverloads = [.. typeof(PriceSeries)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(m => m.Name == "Align")];

        // Act
        string[] parameterNames = [.. alignOverloads.SelectMany(m => m.GetParameters()).Select(p => p.Name!)];

        // Assert
        alignOverloads.Length.ShouldBeGreaterThan(0);
        parameterNames.ShouldNotContain("barCount");
        parameterNames.ShouldNotContain("barcount");
    }
}
