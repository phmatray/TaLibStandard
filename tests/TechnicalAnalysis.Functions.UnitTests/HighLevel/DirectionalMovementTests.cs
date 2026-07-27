// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// <para>
/// The regression suite for the directional-movement loop-translation defect.
/// </para>
/// <para>
/// THE DEFECT. The reference implementation seeds with <c>while (i-- &gt; 0)</c> and
/// <c>while (i-- != 0)</c>, each of which executes its body exactly <c>i</c> times. Adx, Dx, PlusDI
/// and MinusDI translated both as <c>while (true) { i--; if (i &lt;= 0) break; ... }</c>, which
/// executes the body <c>i - 1</c> times. Each function has two such loops, so <c>today</c> finished
/// two bars short of <c>startIdx</c>: the tail loop then emitted two extra values, every value was
/// computed from a window shifted two bars early, and <c>outBegIdx + outNBElement</c> came out two
/// past the end of the input. All four still reported <see cref="RetCode.Success"/>, and the only
/// pre-existing tests asserted exactly that.
/// </para>
/// <para>
/// Over 100 bars with a period of 14 the defect produced Adx BegIdx = 27 NBElement = 75 (sum 102)
/// and Dx / PlusDI / MinusDI BegIdx = 14 NBElement = 88 (sum 102), against bar counts of 100. The
/// expected values below come from an independent transcription of the reference algorithm, and the
/// rising fixture's answers are additionally derivable on paper — see each test.
/// </para>
/// </remarks>
public class DirectionalMovementTests
{
    private const int Period = 14;

    private const int BarCount = 100;

    // A series that rises by exactly one point a bar, with a range of two points around the close.
    // Every bar has diffP = +1 and diffM = -1, so +DM accumulates 1 a bar and -DM stays 0, and the
    // true range is a constant 2. The smoothed +DM converges on 14 and the smoothed TR on 28, and
    // the recursions keep TR exactly twice +DM in binary floating point, so:
    //   +DI = 100 * (+DM / TR) = 50 exactly     -DI = 0 exactly
    //   DX  = 100 * |0 - 50| / (0 + 50) = 100 exactly, and therefore ADX = 100 exactly.
    private static (double[] High, double[] Low, double[] Close) Rising()
    {
        double[] high = new double[BarCount];
        double[] low = new double[BarCount];
        double[] close = new double[BarCount];

        for (int bar = 0; bar < BarCount; bar++)
        {
            high[bar] = bar + 2.0;
            low[bar] = bar;
            close[bar] = bar + 1.0;
        }

        return (high, low, close);
    }

    // A triangular wave of period 20 oscillating between 50 and 60, with a range of four points
    // around the close. Unlike the rising fixture, no two warm bars share an answer, so a one-bar
    // shift changes every number rather than none of them.
    private static (double[] High, double[] Low, double[] Close) ZigZag()
    {
        double[] high = new double[BarCount];
        double[] low = new double[BarCount];
        double[] close = new double[BarCount];

        for (int bar = 0; bar < BarCount; bar++)
        {
            int phase = bar % 20;
            double mid = 50.0 + (phase < 10 ? phase : 20 - phase);
            close[bar] = mid;
            high[bar] = mid + 2.0;
            low[bar] = mid - 2.0;
        }

        return (high, low, close);
    }

    [Fact]
    public void AdxMetadataFitsInsideThePriceSeriesInsteadOfOverrunningItByTwo()
    {
        // Arrange
        // The lookback of ADX(14) with an unstable period of 0 is 2 * 14 + 0 - 1 = 27, so the first
        // value describes bar 27 and there is one value for every remaining bar:
        // 100 - 27 = 73. The defect reported 75 and 27 + 75 = 102 > 100.
        (double[] high, double[] low, double[] close) = ZigZag();

        // Act
        AdxResult adx = TAMath.Adx(0, BarCount - 1, high, low, close, Period);
        DxResult dx = TAMath.Dx(0, BarCount - 1, high, low, close, Period);
        PlusDIResult plusDI = TAMath.PlusDI(0, BarCount - 1, high, low, close, Period);
        MinusDIResult minusDI = TAMath.MinusDI(0, BarCount - 1, high, low, close, Period);

        // Assert
        adx.RetCode.ShouldBe(RetCode.Success);
        adx.BegIdx.ShouldBe(27);
        adx.NBElement.ShouldBe(73);
        (adx.BegIdx + adx.NBElement).ShouldBe(BarCount);

        // Dx, PlusDI and MinusDI all have a lookback of period + unstable = 14.
        foreach (IndicatorResult result in new IndicatorResult[] { dx, plusDI, minusDI })
        {
            result.RetCode.ShouldBe(RetCode.Success);
            result.BegIdx.ShouldBe(14);
            result.NBElement.ShouldBe(86);
            (result.BegIdx + result.NBElement).ShouldBe(BarCount);
        }
    }

    [Fact]
    public void OnAStrictlyRisingSeriesTheDirectionalIndicatorsTakeTheirClosedFormValues()
    {
        // Arrange
        // Derived on paper in the Rising() comment: +DI = 50, -DI = 0, DX = 100, ADX = 100, all
        // exactly, on every warm bar. Under the defect ADX read 92.85714285714286 at its first bar
        // and only converged back towards 100, so the first-bar assertion alone catches it.
        (double[] high, double[] low, double[] close) = Rising();
        PriceSeries prices = PriceSeries.FromHlc(high, low, close);

        // Act
        IndicatorSeries adx = prices.Adx(Period);
        PlusDIResult plusDI = TAMath.PlusDI(0, BarCount - 1, high, low, close, Period);
        MinusDIResult minusDI = TAMath.MinusDI(0, BarCount - 1, high, low, close, Period);
        DxResult dx = TAMath.Dx(0, BarCount - 1, high, low, close, Period);

        // Assert
        adx.FirstBar.ShouldBe(27);
        adx.LastBar.ShouldBe(99);
        adx.WarmCount.ShouldBe(73);
        adx[27].ShouldBe(100.0);
        adx[99].ShouldBe(100.0);

        foreach ((int bar, double value) in adx)
        {
            value.ShouldBe(100.0, $"ADX was {value} at bar {bar}.");
        }

        plusDI.Real[0].ShouldBe(50.0);
        plusDI.Real[plusDI.NBElement - 1].ShouldBe(50.0);
        minusDI.Real[0].ShouldBe(0.0);
        minusDI.Real[minusDI.NBElement - 1].ShouldBe(0.0);
        dx.Real[0].ShouldBe(100.0);
        dx.Real[dx.NBElement - 1].ShouldBe(100.0);
    }

    [Fact]
    public void OnAZigZagSeriesEveryValueMatchesAnIndependentTranscriptionOfTheReference()
    {
        // Arrange
        // These constants come from a separate transcription of the reference C, not from a
        // previous run of this library. The defect's answers were 16.50835398166515 at ADX bar 27
        // and 66.66666666666669 at DX bar 14 -- 1.5 and 24.6 points out respectively -- so every
        // one of these assertions discriminates.
        (double[] high, double[] low, double[] close) = ZigZag();
        PriceSeries prices = PriceSeries.FromHlc(high, low, close);
        const double Tolerance = 1e-12;

        // Act
        IndicatorSeries adx = prices.Adx(Period);
        DxResult dx = TAMath.Dx(0, BarCount - 1, high, low, close, Period);
        PlusDIResult plusDI = TAMath.PlusDI(0, BarCount - 1, high, low, close, Period);
        MinusDIResult minusDI = TAMath.MinusDI(0, BarCount - 1, high, low, close, Period);

        // Assert
        adx[27].ShouldNotBeNull();
        adx[27].Value.ShouldBe(18.038560807106332, Tolerance);
        adx[50].Value.ShouldBe(20.906071381560533, Tolerance);
        adx[99].Value.ShouldBe(18.359235977556096, Tolerance);

        // Bar b sits at array index b - BegIdx; DX, +DI and -DI all begin at bar 14.
        dx.Real[0].ShouldBe(42.07650273224045, Tolerance);
        dx.Real[50 - 14].ShouldBe(38.300491054732625, Tolerance);
        dx.Real[99 - 14].ShouldBe(30.413513993573694, Tolerance);

        plusDI.Real[0].ShouldBe(17.75956284153006, Tolerance);
        plusDI.Real[50 - 14].ShouldBe(17.287561381841577, Tolerance);
        plusDI.Real[99 - 14].ShouldBe(8.698310750803287, Tolerance);

        minusDI.Real[0].ShouldBe(7.240437158469945, Tolerance);
        minusDI.Real[50 - 14].ShouldBe(7.712438618158421, Tolerance);
        minusDI.Real[99 - 14].ShouldBe(16.30168924919671, Tolerance);
    }

    [Fact]
    public void TheFluentAdxDiscriminatesBarByBarSoAShiftCannotHide()
    {
        // Arrange
        // A fixture whose every warm bar carries a different answer is the only kind that can catch
        // an off-by-one alignment; a constant series masks a shift completely.
        (double[] high, double[] low, double[] close) = ZigZag();
        PriceSeries prices = PriceSeries.FromHlc(high, low, close);

        // Act
        IndicatorSeries adx = prices.Adx(Period);
        HashSet<double> distinct = [];
        foreach ((int _, double value) in adx)
        {
            distinct.Add(value);
        }

        // Assert
        adx.WarmCount.ShouldBe(73);
        distinct.Count.ShouldBeGreaterThan(60);
        adx[26].ShouldBeNull();
        adx[27].ShouldNotBe(adx[28]);
        adx[50].ShouldNotBe(adx[51]);
    }

    [Fact]
    public void AdxRefusesCloseOnlyDataAndValidatesItsPeriod()
    {
        // Arrange
        // Directional movement is defined by how a bar's range extends past the previous bar's, so
        // there is nothing to compute without a high and a low.
        PriceSeries closeOnly = PriceSeries.FromClose(ZigZag().Close);
        (double[] high, double[] low, double[] close) = ZigZag();
        PriceSeries hlc = PriceSeries.FromHlc(high, low, close);

        // Act
        ArgumentOutOfRangeException badPeriod = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = hlc.Adx(1);
        });

        // Assert
        Should.Throw<InvalidOperationException>(() =>
        {
            _ = closeOnly.Adx(Period);
        });

        badPeriod.ParamName.ShouldBe("timePeriod");
    }

    [Fact]
    public void AdxOverTooLittleDataIsEmptyAndSucceeds()
    {
        // Arrange
        // ADX(14) needs 28 bars before its first value; twenty is not enough, and that is not an
        // error. An absent value must be null rather than a plausible-looking zero.
        double[] high = new double[20];
        double[] low = new double[20];
        double[] close = new double[20];
        for (int bar = 0; bar < 20; bar++)
        {
            high[bar] = bar + 2.0;
            low[bar] = bar;
            close[bar] = bar + 1.0;
        }

        PriceSeries prices = PriceSeries.FromHlc(high, low, close);

        // Act
        IndicatorSeries adx = prices.Adx(Period);

        // Assert
        adx.RetCode.ShouldBe(RetCode.Success);
        adx.HasValues.ShouldBeFalse();
        adx.WarmCount.ShouldBe(0);
        adx.BarCount.ShouldBe(20);
        adx.FirstBar.ShouldBeNull();
        adx.Latest.ShouldBeNull();
        adx[19].ShouldBeNull();
    }
}
