// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// Value-asserting tests for the momentum studies. Each fixture is chosen so the correct answer is a
/// closed form that can be derived on paper rather than copied out of a previous run.
/// </remarks>
public class MomentumIndicatorsTests
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
        // high 102, low 98, close 100 on every bar: the close is exactly midway in a range that
        // never moves, so %K = (100 - 98) / ((102 - 98) / 100) = 50 on every bar.
        return PriceSeries.FromHlc(Constant(barCount, 102.0), Constant(barCount, 98.0), Constant(barCount, 100.0));
    }

    [Fact]
    public void RsiSaturatesAtOneHundredOnAStrictlyIncreasingSeries()
    {
        // Arrange
        // Closes 1..100 rise by exactly 1 every bar, so Wilder's average loss is 0 on every warm
        // bar and RSI = 100 * gain / (gain + 0) = 100.0 exactly.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        IndicatorSeries rsi = prices.Rsi(14);

        // Assert
        rsi.Latest.ShouldBe(100.0);
        rsi.FirstBar.ShouldBe(14);
        rsi.WarmCount.ShouldBe(86);
        rsi[14].ShouldBe(100.0);
    }

    [Fact]
    public void RsiOnAFlatSeriesIsZeroAndNotNaN()
    {
        // Arrange
        // Fifty identical closes: average gain and average loss are both 0, so the ratio is 0/0.
        // TA-Lib C returns 0 in that state; the unguarded division used to return NaN, and a NaN
        // launders itself into every downstream comparison.
        PriceSeries prices = PriceSeries.FromClose(Constant(50, 100.0));

        // Act
        IndicatorSeries rsi = prices.Rsi(14);

        // Assert
        rsi.Latest.ShouldBe(0.0);
        double.IsNaN(rsi.Latest!.Value).ShouldBeFalse();
        rsi.FirstBar.ShouldBe(14);
        rsi.WarmCount.ShouldBe(36);
    }

    [Fact]
    public void AnAbsentRsiAssertsNothingInEitherDirection()
    {
        // Arrange
        // Five closes and a fourteen-period RSI: there is no value at all. This is the direct
        // counter-test to the abandoned branch, where the corrupted read produced 0.0 and made
        // IsOversold true on every input. A null compares false against BOTH thresholds.
        PriceSeries prices = PriceSeries.FromClose([1.0, 2.0, 3.0, 4.0, 5.0]);

        // Act
        IndicatorSeries rsi = prices.Rsi(14);
        double? latest = rsi.Latest;

        // Assert
        latest.ShouldBeNull();
        (latest < 30.0).ShouldBeFalse();
        (latest > 70.0).ShouldBeFalse();
    }

    [Fact]
    public void MacdLineOnAUnitSlopeRampIsTheDifferenceOfTheTwoEmaLags()
    {
        // Arrange
        // On a ramp of slope 1 an N-period EMA seeded with the mean of the first N closes sits
        // exactly (N - 1) / 2 below the price and stays there. So
        //   EMA(12) - EMA(26) = (price - 5.5) - (price - 12.5) = 7.0
        // on every warm bar, and the recursion is exact in binary floating point because the seed
        // already equals the steady state.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        MacdSeries macd = prices.Macd();

        // Assert
        macd.Line.Latest.ShouldBe(7.0);
    }

    [Fact]
    public void MacdSignalIsTheEmaOfAConstantLineAndTheHistogramCancels()
    {
        // Arrange
        // The MACD line is identically 7.0, so its 9-period EMA is 7.0 and the histogram,
        // line minus signal, is exactly 0.0.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        MacdSeries macd = prices.Macd();

        // Assert
        macd.Signal.Latest.ShouldBe(7.0);
        macd.Histogram.Latest.ShouldBe(0.0);
    }

    [Fact]
    public void MacdComponentsShareTheCombinedLookbackAlignment()
    {
        // Arrange
        // The lookback is (slowPeriod - 1) + (signalPeriod - 1) = 25 + 8 = 33, so the first warm
        // bar is 33 and 100 - 33 = 67 bars carry a value.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        MacdSeries macd = prices.Macd();

        // Assert
        macd.Line.FirstBar.ShouldBe(33);
        macd.Line.WarmCount.ShouldBe(67);
        macd.Line[33].ShouldBe(7.0);
        macd.Signal.FirstBar.ShouldBe(33);
        macd.Histogram.FirstBar.ShouldBe(33);
        macd.Line[32].ShouldBeNull();
    }

    [Fact]
    public void StochOnAFlatRangeSitsExactlyMidwayAtFifty()
    {
        // Arrange
        // Sixty bars with high 102, low 98, close 100. The raw %K is
        // (close - lowest) / ((highest - lowest) / 100) = 2 / 0.04 = 50, and a simple moving
        // average of a constant 50 is 50, twice over.
        PriceSeries prices = ConstantRangeHlc(60);

        // Act
        StochSeries stoch = prices.Stoch();

        // Assert
        stoch.SlowK.Latest.ShouldBe(50.0);
        stoch.SlowD.Latest.ShouldBe(50.0);
    }

    [Fact]
    public void StochComponentsShareTheCombinedLookbackAlignment()
    {
        // Arrange
        // The lookback is (fastK - 1) + (slowK - 1) + (slowD - 1) = 4 + 2 + 2 = 8, so the first
        // warm bar is 8 and 60 - 8 = 52 bars carry a value.
        PriceSeries prices = ConstantRangeHlc(60);

        // Act
        StochSeries stoch = prices.Stoch();

        // Assert
        stoch.SlowK.FirstBar.ShouldBe(8);
        stoch.SlowK.WarmCount.ShouldBe(52);
        stoch.SlowK.BarCount.ShouldBe(60);
        stoch.SlowD.FirstBar.ShouldBe(8);
        stoch.SlowD.WarmCount.ShouldBe(52);
        stoch.SlowK[7].ShouldBeNull();
        stoch.SlowK[8].ShouldBe(50.0);
    }

    [Fact]
    public void MultiOutputWrappersDeconstructPositionallyIntoAddressableSeries()
    {
        // Arrange
        PriceSeries closes = PriceSeries.FromClose(Ramp(100));
        PriceSeries hlc = ConstantRangeHlc(60);

        // Act
        (IndicatorSeries line, IndicatorSeries signal, IndicatorSeries histogram) = closes.Macd();
        (IndicatorSeries upper, IndicatorSeries middle, IndicatorSeries lower) = closes.BollingerBands(20, 2.0, 2.0);
        (IndicatorSeries slowK, IndicatorSeries slowD) = hlc.Stoch();

        // Assert
        line[33].ShouldBe(7.0);
        signal[33].ShouldBe(7.0);
        histogram[33].ShouldBe(0.0);

        middle[19].ShouldBe(10.5);
        upper[19].ShouldBe(10.5 + (2.0 * Math.Sqrt(33.25)));
        lower[19].ShouldBe(10.5 - (2.0 * Math.Sqrt(33.25)));

        slowK[8].ShouldBe(50.0);
        slowD[8].ShouldBe(50.0);
    }

    [Fact]
    public void AMacdLineSignalCrossIsExpressedWithoutAnyThresholdPredicate()
    {
        // Arrange
        // On the ramp the line and the signal are both identically 7.0, so the line is never
        // strictly above the signal and there is never a crossing. That the expression compiles
        // and answers sensibly at every bar is the point: no IsBullish is required.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        MacdSeries macd = prices.Macd();

        // Act
        bool anyCrossing = false;
        for (int bar = 0; bar < macd.Line.BarCount; bar++)
        {
            if (macd.Line.CrossedAbove(macd.Signal, bar))
            {
                anyCrossing = true;
            }
        }

        // Assert
        macd.Line.BarCount.ShouldBe(100);
        anyCrossing.ShouldBeFalse();
    }

    [Fact]
    public void RsiFallsGeometricallyOnceTheSeriesTurnsSoEveryWarmBarHasItsOwnAnswer()
    {
        // Arrange
        // Closes rise by 1 for bars 0..14 and fall by 1 for ever afterwards. The seed at bar 14 is
        // avgGain = 1 and avgLoss = 0, so RSI is 100 there. Each falling bar multiplies avgGain by
        // 13/14 and, because avgGain + avgLoss stays exactly 1, RSI(14 + k) = 100 * (13/14)^k.
        // Every warm bar therefore carries a different number and a one-bar shift changes all of
        // them -- unlike the plain ramp, on which RSI is pinned at 100 and a shift is invisible.
        double[] closes = new double[100];
        for (int bar = 0; bar < 100; bar++)
        {
            closes[bar] = bar <= 14 ? 1.0 + bar : 15.0 - (bar - 14);
        }

        PriceSeries prices = PriceSeries.FromClose(closes);

        // Act
        IndicatorSeries rsi = prices.Rsi(14);

        // Assert
        rsi.FirstBar.ShouldBe(14);
        rsi.WarmCount.ShouldBe(86);
        rsi[14].Value.ShouldBe(100.0, 1e-9);
        rsi[15].Value.ShouldBe(92.85714285714286, 1e-9);
        rsi[16].Value.ShouldBe(86.22448979591837, 1e-9);
        rsi[24].Value.ShouldBe(47.659904336004004, 1e-9);
        rsi[54].Value.ShouldBe(5.159559975746875, 1e-9);
        rsi[99].Value.ShouldBe(0.1837815514462741, 1e-9);
        rsi[13].ShouldBeNull();

        // Strictly decreasing after the turn: no two warm bars agree, so nothing here is masked.
        for (int bar = 16; bar <= 99; bar++)
        {
            rsi[bar].Value.ShouldBeLessThan(rsi[bar - 1].Value);
        }
    }

    [Fact]
    public void MacdLineDecaysAnalyticallyOnceTheRampFlattens()
    {
        // Arrange
        // closes[bar] = 1 + bar below 60, so the last RISING bar is 59 (which is already 60.0) and
        // price is flat from there on. On the ramp each N-period EMA sits exactly (N - 1) / 2 below
        // price, so at bar 59 the fast EMA is 60 - 5.5 and the slow one 60 - 12.5, giving a line of
        // exactly 7. Once price stops moving each EMA decays towards 60 by its own factor
        // 1 - 2 / (N + 1), so
        //     line(59 + m) = 12.5 * (25/27)^m - 5.5 * (11/13)^m
        // Note the anchor is bar 59, not 60: bar 60 is the first FLAT bar, so one decay step has
        // already been applied there and line(60) is 6.9202..., not 7.
        double[] closes = new double[100];
        for (int bar = 0; bar < 100; bar++)
        {
            closes[bar] = bar < 60 ? 1.0 + bar : 60.0;
        }

        PriceSeries prices = PriceSeries.FromClose(closes);

        // Act
        MacdSeries macd = prices.Macd();

        // Assert
        macd.Line.FirstBar.ShouldBe(33);
        macd.Line[59].Value.ShouldBe(7.0, 1e-9);
        macd.Line[60].Value.ShouldBe(6.92022792022792, 1e-9);
        macd.Line[61].Value.ShouldBe(6.778865431287085, 1e-9);
        macd.Line[69].Value.ShouldBe(4.755119558996247, 1e-9);
        macd.Line[98].Value.ShouldBe(0.6132726824101662, 1e-9);
    }

    [Fact]
    public void StochTracksTheClosePositionBarByBarAndDisagreesWhenHighAndLowAreSwapped()
    {
        // Arrange
        // A fixed band -- high 110 and low 100 on every bar -- with the close sawing between 100 and
        // 109. The window's highest and lowest are therefore always 110 and 100, so the raw %K is
        // 10 * (bar % 10), the slow %K is its three-bar mean and the slow %D is the mean of that.
        // Every consecutive pair of warm bars differs, which the flat-range fixture cannot show:
        // there %K is 50 everywhere and swapping the high and the low arguments produces a byte-
        // identical result.
        double[] high = Constant(60, 110.0);
        double[] low = Constant(60, 100.0);
        double[] close = new double[60];
        for (int bar = 0; bar < 60; bar++)
        {
            close[bar] = 100.0 + (bar % 10);
        }

        PriceSeries prices = PriceSeries.FromHlc(high, low, close);
        PriceSeries swapped = PriceSeries.FromHlc(low, high, close);

        // Act
        StochSeries stoch = prices.Stoch();
        StochSeries wrongWayRound = swapped.Stoch();

        // Assert
        stoch.SlowK.FirstBar.ShouldBe(8);
        stoch.SlowK[8].Value.ShouldBe(70.0, 1e-9);
        stoch.SlowD[8].Value.ShouldBe(60.0, 1e-9);
        stoch.SlowK[20].Value.ShouldBe(56.666666666666664, 1e-9);
        stoch.SlowK[21].Value.ShouldBe(33.333333333333336, 1e-9);
        stoch.SlowD[20].Value.ShouldBe(68.88888888888889, 1e-9);
        stoch.SlowK[59].Value.ShouldBe(80.0, 1e-9);

        // Consecutive bars differ, so an off-by-one could not hide in this fixture.
        stoch.SlowK[20].ShouldNotBe(stoch.SlowK[21]);

        // The whole point: reversing the two range arguments must change the answer.
        wrongWayRound.SlowK[20].ShouldNotBe(stoch.SlowK[20]);
        wrongWayRound.SlowK[8].ShouldNotBe(stoch.SlowK[8]);
    }
}
