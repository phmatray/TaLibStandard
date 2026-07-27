// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// The alignment primitive in isolation: every series here is built by hand through
/// <see cref="IndicatorSeries.Create"/> with metadata written out explicitly, so the assertions
/// depend on nothing but the primitive itself.
/// </remarks>
public class IndicatorSeriesTests
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

    [Fact]
    public void CreateMapsArrayElementKToBarFirstBarPlusK()
    {
        // Arrange
        // Three values that describe bars 7, 8 and 9 of a ten-bar series. The array is ten long
        // because TAMath allocates endIdx - startIdx + 1 slots; everything from index 3 on is
        // meaningless padding and must be unreachable.
        double[] values = [1.0, 2.0, 3.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0];

        // Act
        IndicatorSeries series = IndicatorSeries.Create(RetCode.Success, begIdx: 7, nbElement: 3, values, barCount: 10);

        // Assert
        series.FirstBar.ShouldBe(7);
        series.LastBar.ShouldBe(9);
        series.WarmCount.ShouldBe(3);
        series.BarCount.ShouldBe(10);
        series[7].ShouldBe(1.0);
        series[8].ShouldBe(2.0);
        series[9].ShouldBe(3.0);
        series.Latest.ShouldBe(3.0);
        series[6].ShouldBeNull();
        series[0].ShouldBeNull();
        series.WarmValues.Length.ShouldBe(3);
    }

    [Fact]
    public void CreateRejectsMetadataThatOverrunsTheBarCount()
    {
        // Arrange
        // 7 + 4 = 11 > 10: the series claims a value for a bar the price series does not have.
        // This is the check that caught the Adx / Dx / PlusDI / MinusDI loop-translation defect,
        // which reported BegIdx + NBElement exactly two past the end (that defect is now fixed at
        // its root; see DirectionalMovementTests). Clamping would hand back a silently
        // two-bar-misaligned series, which is the failure this design exists to prevent.
        double[] values = new double[10];

        // Act
        ArgumentException exception = Should.Throw<ArgumentException>(() =>
        {
            _ = IndicatorSeries.Create(RetCode.Success, begIdx: 7, nbElement: 4, values, barCount: 10);
        });

        // Assert
        // Exactly ArgumentException, not the ArgumentOutOfRangeException used for negative inputs:
        // the arguments are individually in range and it is their combination that is impossible.
        exception.ShouldBeOfType<ArgumentException>();
        exception.ParamName.ShouldBe("nbElement");
    }

    [Fact]
    public void CreateValidatesItsArguments()
    {
        // Arrange
        double[] values = new double[10];

        // Act
        ArgumentException tooManyElements = Should.Throw<ArgumentException>(() =>
        {
            _ = IndicatorSeries.Create(RetCode.Success, begIdx: 0, nbElement: 11, values, barCount: 20);
        });

        ArgumentNullException nullValues = Should.Throw<ArgumentNullException>(() =>
        {
            _ = IndicatorSeries.Create(RetCode.Success, begIdx: 0, nbElement: 1, values: null!, barCount: 10);
        });

        ArgumentOutOfRangeException negativeBegIdx = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = IndicatorSeries.Create(RetCode.Success, begIdx: -1, nbElement: 1, values, barCount: 10);
        });

        ArgumentOutOfRangeException negativeNbElement = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = IndicatorSeries.Create(RetCode.Success, begIdx: 0, nbElement: -1, values, barCount: 10);
        });

        ArgumentOutOfRangeException negativeBarCount = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = IndicatorSeries.Create(RetCode.Success, begIdx: 0, nbElement: 1, values, barCount: -1);
        });

        // Assert
        tooManyElements.ShouldBeOfType<ArgumentException>();
        tooManyElements.ParamName.ShouldBe("nbElement");
        nullValues.ParamName.ShouldBe("values");
        negativeBegIdx.ParamName.ShouldBe("begIdx");
        negativeNbElement.ParamName.ShouldBe("nbElement");
        negativeBarCount.ParamName.ShouldBe("barCount");
    }

    [Fact]
    public void CreateWithZeroElementsPreservesTheRetCodeAndNeverFabricatesABar()
    {
        // Arrange
        // A failure must not invent a first bar. BegIdx is not even examined when nbElement is 0,
        // because TA-Lib routinely reports BegIdx = 0 alongside NBElement = 0.
        double[] values = new double[10];

        // Act
        IndicatorSeries series = IndicatorSeries.Create(RetCode.BadParam, begIdx: 0, nbElement: 0, values, barCount: 10);

        // Assert
        series.HasValues.ShouldBeFalse();
        series.WarmCount.ShouldBe(0);
        series.BarCount.ShouldBe(10);
        series.RetCode.ShouldBe(RetCode.BadParam);
        series.FirstBar.ShouldBeNull();
    }

    [Fact]
    public void EmptyCarriesABarCountButNoValues()
    {
        // Arrange
        const int BarCount = 7;

        // Act
        IndicatorSeries series = IndicatorSeries.Empty(BarCount);
        ArgumentOutOfRangeException negative = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = IndicatorSeries.Empty(-1);
        });

        // Assert
        series.BarCount.ShouldBe(7);
        series.WarmCount.ShouldBe(0);
        series.RetCode.ShouldBe(RetCode.Success);
        series.FirstBar.ShouldBeNull();
        negative.ParamName.ShouldBe("barCount");
    }

    [Fact]
    public void DefaultInstancesAreValidEmptyValues()
    {
        // Arrange
        // RetCode.Success is 0, so a default IndicatorSeries reports Success. That is exactly the
        // trap TA-Lib itself sets, and it is why IsEmpty rather than RetCode is the warmth test.
        IndicatorSeries series = default;
        PriceSeries prices = default;

        // Act
        // (nothing to do -- the values under test are the defaults themselves)

        // Assert
        series.HasValues.ShouldBeFalse();
        series.BarCount.ShouldBe(0);
        series.WarmCount.ShouldBe(0);
        series.RetCode.ShouldBe(RetCode.Success);
        series.FirstBar.ShouldBeNull();
        series.Latest.ShouldBeNull();
        series.WarmValues.Length.ShouldBe(0);

        prices.BarCount.ShouldBe(0);
        prices.IsEmpty.ShouldBeTrue();
        prices.HasOpen.ShouldBeFalse();
        prices.HasHighLow.ShouldBeFalse();
        prices.HasVolume.ShouldBeFalse();
    }

    [Fact]
    public void ToBarAlignedArrayPadsColdBarsWithNaNAndNeverZero()
    {
        // Arrange
        // SMA(3) over closes 1..10: bar 2 is the mean of 1, 2, 3 = 2.0 and every later bar k is
        // the mean of k - 1, k, k + 1 = k, so bar 9 reads 9.0.
        // The day a[FirstBar - 1] becomes 0.0 instead of NaN is the day the whole bug returns:
        // 0.0 is a plausible-looking number, NaN is not.
        PriceSeries prices = PriceSeries.FromClose(Ramp(10));
        IndicatorSeries sma = prices.Sma(3);

        // Act
        double[] aligned = sma.ToBarAlignedArray();

        // Assert
        sma.FirstBar.ShouldBe(2);
        sma.LastBar.ShouldBe(9);
        sma.WarmCount.ShouldBe(8);
        sma.Latest.ShouldBe(9.0);
        sma[2].ShouldBe(2.0);

        aligned.Length.ShouldBe(10);
        double.IsNaN(aligned[0]).ShouldBeTrue();
        double.IsNaN(aligned[1]).ShouldBeTrue();
        aligned[2].ShouldBe(2.0);
        aligned[9].ShouldBe(9.0);
    }

    [Fact]
    public void ToBarAlignedArrayOfANotYetWarmSeriesIsAllNaN()
    {
        // Arrange
        // Five closes and a thirty-period SMA: no bar is warm, so every bar is NaN and none is 0.0.
        PriceSeries prices = PriceSeries.FromClose([1.0, 2.0, 3.0, 4.0, 5.0]);
        IndicatorSeries sma = prices.Sma(30);

        // Act
        double[] aligned = sma.ToBarAlignedArray();

        // Assert
        aligned.Length.ShouldBe(5);
        foreach (double value in aligned)
        {
            double.IsNaN(value).ShouldBeTrue();
        }
    }

    [Fact]
    public void CopyBarAlignedWritesByBarIndexAndGuardsTheDestination()
    {
        // Arrange
        // SMA(30) over closes 1..100: bar 28 is cold (NaN), bar 29 is 15.5, bar 99 is 85.5.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        IndicatorSeries sma = prices.Sma(30);
        double[] exact = new double[100];
        double[] overlong = new double[120];
        Array.Fill(overlong, -1.0);

        // Act
        sma.CopyBarAligned(exact);
        sma.CopyBarAligned(overlong);
        ArgumentException tooSmall = Should.Throw<ArgumentException>(() =>
        {
            sma.CopyBarAligned(new double[10]);
        });

        // Assert
        double.IsNaN(exact[28]).ShouldBeTrue();
        exact[29].ShouldBe(15.5);
        exact[99].ShouldBe(85.5);
        tooSmall.ShouldBeOfType<ArgumentException>();
        tooSmall.ParamName.ShouldBe("destination");

        // Everything past BarCount is left untouched.
        overlong[99].ShouldBe(85.5);
        overlong[100].ShouldBe(-1.0);
        overlong[119].ShouldBe(-1.0);
    }

    [Fact]
    public void EnumerationYieldsWarmBarsInAscendingBarOrder()
    {
        // Arrange
        // SMA(3) over closes 1..10 is warm on bars 2..9 with value == bar, so the pairs are
        // (2,2) (3,3) (4,4) (5,5) (6,6) (7,7) (8,8) (9,9). The Bar component is a BAR index,
        // not an array index -- an implementation that yielded 0..7 would fail here.
        PriceSeries prices = PriceSeries.FromClose(Ramp(10));
        IndicatorSeries sma = prices.Sma(3);
        IndicatorSeries notWarm = PriceSeries.FromClose([1.0, 2.0, 3.0, 4.0, 5.0]).Sma(30);
        List<(int Bar, double Value)> observed = [];
        int emptyIterations = 0;

        // Act
        foreach ((int bar, double value) in sma)
        {
            observed.Add((bar, value));
        }

        foreach ((int _, double _) in notWarm)
        {
            emptyIterations++;
        }

        // Assert
        observed.Count.ShouldBe(8);
        observed[0].ShouldBe((2, 2.0));
        observed[1].ShouldBe((3, 3.0));
        observed[2].ShouldBe((4, 4.0));
        observed[3].ShouldBe((5, 5.0));
        observed[4].ShouldBe((6, 6.0));
        observed[5].ShouldBe((7, 7.0));
        observed[6].ShouldBe((8, 8.0));
        observed[7].ShouldBe((9, 9.0));
        emptyIterations.ShouldBe(0);
    }

    [Fact]
    public void CurrentBeforeTheFirstMoveNextOrAfterTheLastReportsMisuseRatherThanCrashing()
    {
        // Arrange
        // Enumerator is a public type, so hand-driving it is reachable. Reading Current out of
        // position used to throw NullReferenceException on a series with no values and
        // IndexOutOfRangeException on one with values -- both of which read as a library defect
        // rather than as caller misuse. foreach never reaches this state, which is why nothing
        // caught it.
        PriceSeries prices = PriceSeries.FromClose(Ramp(10));
        IndicatorSeries sma = prices.Sma(3);
        IndicatorSeries.Enumerator beforeStart = sma.GetEnumerator();
        IndicatorSeries.Enumerator onNothing = IndicatorSeries.Empty(100).GetEnumerator();
        IndicatorSeries.Enumerator exhausted = sma.GetEnumerator();
        while (exhausted.MoveNext())
        {
            // Drain it.
        }

        // Act
        InvalidOperationException notStarted = Should.Throw<InvalidOperationException>(() =>
        {
            _ = beforeStart.Current;
        });

        InvalidOperationException noValues = Should.Throw<InvalidOperationException>(() =>
        {
            _ = onNothing.Current;
        });

        InvalidOperationException finished = Should.Throw<InvalidOperationException>(() =>
        {
            _ = exhausted.Current;
        });

        // Assert
        notStarted.ShouldBeOfType<InvalidOperationException>();
        noValues.ShouldBeOfType<InvalidOperationException>();
        finished.ShouldBeOfType<InvalidOperationException>();
        onNothing.MoveNext().ShouldBeFalse();
        exhausted.MoveNext().ShouldBeFalse();
    }

    [Fact]
    public void ToBarAlignedNullableArrayReportsAbsenceAsNullRatherThanAsASentinel()
    {
        // Arrange
        // ToBarAlignedArray has to pad with NaN because a double[] cannot hold null, which collides
        // with a computed non-finite value. The nullable projection has no sentinel at all, so the
        // two states stay distinguishable.
        PriceSeries prices = PriceSeries.FromClose(Ramp(10));
        IndicatorSeries sma = prices.Sma(3);

        // Act
        double?[] aligned = sma.ToBarAlignedNullableArray();
        double?[] nothing = PriceSeries.FromClose([1.0, 2.0, 3.0]).Sma(30).ToBarAlignedNullableArray();

        // Assert
        aligned.Length.ShouldBe(10);
        aligned[0].ShouldBeNull();
        aligned[1].ShouldBeNull();
        aligned[2].ShouldBe(2.0);
        aligned[9].ShouldBe(9.0);

        nothing.Length.ShouldBe(3);
        foreach (double? value in nothing)
        {
            value.ShouldBeNull();
        }
    }

    [Fact]
    public void WarmValuesToArrayLetsTheValuesEscapeTheRefStructSpan()
    {
        // Arrange
        // WarmValues is a ReadOnlySpan, so it cannot cross into a LINQ query, an async method or a
        // field. Without this member there is no non-sentinel way to get the values out at all.
        PriceSeries prices = PriceSeries.FromClose(Ramp(10));
        IndicatorSeries sma = prices.Sma(3);

        // Act
        double[] values = sma.WarmValuesToArray();
        double[] none = PriceSeries.FromClose([1.0, 2.0, 3.0]).Sma(30).WarmValuesToArray();
        double[] narrowed = sma.AsOf(5).WarmValuesToArray();

        // Assert
        values.Length.ShouldBe(8);
        values[0].ShouldBe(2.0);
        values[7].ShouldBe(9.0);
        values.Max().ShouldBe(9.0);
        none.Length.ShouldBe(0);

        // AsOf keeps the same backing array but only four values survive, so the copy must be
        // sliced to WarmCount rather than handed the whole array.
        narrowed.Length.ShouldBe(4);
        narrowed[3].ShouldBe(5.0);
    }

    [Fact]
    public void CreateCopiesSoTheCallerKeepsSoleOwnershipOfItsArray()
    {
        // Arrange
        // The public entry point cannot know whether the array it is handed is reachable from
        // anywhere else -- result.Real is a live public property -- so immutability can only be
        // unconditional if it copies.
        double[] values = [1.0, 2.0, 3.0, 0.0, 0.0];

        // Act
        IndicatorSeries series = IndicatorSeries.Create(RetCode.Success, begIdx: 2, nbElement: 3, values, barCount: 5);
        values[0] = 999.0;
        values[2] = 999.0;

        // Assert
        series[2].ShouldBe(1.0);
        series[4].ShouldBe(3.0);
        series.Latest.ShouldBe(3.0);
        series.WarmValues[0].ShouldBe(1.0);
    }
}
