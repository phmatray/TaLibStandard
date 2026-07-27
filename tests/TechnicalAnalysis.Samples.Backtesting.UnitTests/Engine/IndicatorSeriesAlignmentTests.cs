// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

/// <summary>
/// Guards the TA-Lib alignment rule: <c>output[k]</c> describes bar <c>BegIdx + k</c>, and elements from
/// <c>NBElement</c> onwards are meaningless. Reading the raw array as if element <c>k</c> described bar
/// <c>k</c> shifts every signal in time, which is the classic silent bug when consuming the library.
/// </summary>
public class IndicatorSeriesAlignmentTests
{
    [Fact]
    public void RawTaLibOutputIsOffsetByBegIdxAndTheSeriesUndoesIt()
    {
        // Arrange - closes 1..6; SMA(3) is 2 on bar 2, 3 on bar 3, 4 on bar 4, 5 on bar 5 (hand-computed).
        double[] closes = [1, 2, 3, 4, 5, 6];

        // Act
        SmaResult raw = TAMath.Sma(0, closes.Length - 1, closes, 3);
        IndicatorSeries series = new("SMA(3)", closes.Length, raw.BegIdx, raw.NBElement, raw.Real, window: null);

        // Assert - TA-Lib fills from element 0 and reports where element 0 belongs.
        raw.RetCode.ShouldBe(RetCode.Success);
        raw.BegIdx.ShouldBe(2);
        raw.NBElement.ShouldBe(4);
        raw.Real[0].ShouldBe(2.0, 1e-12);

        // The wrapper puts element 0 on bar 2 ...
        series.HasValueAt(0).ShouldBeFalse();
        series.HasValueAt(1).ShouldBeFalse();
        series[2].ShouldBe(2.0, 1e-12);
        series[3].ShouldBe(3.0, 1e-12);
        series[4].ShouldBe(4.0, 1e-12);
        series[5].ShouldBe(5.0, 1e-12);

        // ... and the naive read (raw.Real[barIndex]) would have reported 4 on bar 2: a two-bar shift.
        raw.Real[2].ShouldBe(4.0, 1e-12);
        series[2].ShouldNotBe(raw.Real[2]);
    }

    [Fact]
    public void ElementsBeyondNbElementAreNeverExposed()
    {
        // Arrange - the output array is sized endIdx - startIdx + 1 = 6 but only 4 elements are meaningful.
        double[] closes = [1, 2, 3, 4, 5, 6];
        SmaResult raw = TAMath.Sma(0, closes.Length - 1, closes, 3);

        // Act
        IndicatorSeries series = new("SMA(3)", closes.Length, raw.BegIdx, raw.NBElement, raw.Real, window: null);

        // Assert - bar 2 + 4 = 6 would be the next bar; it does not exist, and nothing beyond bar 5 has a value.
        raw.Real.Length.ShouldBe(6);
        raw.Real[4].ShouldBe(0.0);
        series.Count.ShouldBe(6);
        series.NBElement.ShouldBe(4);
        Enumerable.Range(0, 6).Count(series.HasValueAt).ShouldBe(4);
    }

    [Fact]
    public void IndicatorSetProducesTheSameAlignmentAsTheRawCall()
    {
        // Arrange
        double[] closes = [10, 12, 11, 15, 14, 18, 17, 20];
        IReadOnlyList<Bar> bars = TestBars.FromCloses(closes);

        // Act
        IndicatorSet indicators = new(bars, window: null);
        IndicatorSeries sma = indicators.Sma(4);
        SmaResult raw = TAMath.Sma(0, closes.Length - 1, closes, 4);

        // Assert
        sma.BegIdx.ShouldBe(raw.BegIdx);
        sma.NBElement.ShouldBe(raw.NBElement);
        for (int k = 0; k < raw.NBElement; k++)
        {
            sma[raw.BegIdx + k].ShouldBe(raw.Real[k], 1e-12);
        }

        // Bar 3 is the first with a value: mean of 10, 12, 11, 15 = 12.
        sma.BegIdx.ShouldBe(3);
        sma[3].ShouldBe(12.0, 1e-12);
    }

    [Fact]
    public void RequestingTheSameIndicatorTwiceReturnsTheCachedInstance()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([1, 2, 3, 4, 5, 6, 7, 8]);
        IndicatorSet indicators = new(bars, window: null);

        // Act
        IndicatorSeries first = indicators.Sma(3);
        IndicatorSeries second = indicators.Sma(3);
        IndicatorSeries other = indicators.Sma(4);

        // Assert
        second.ShouldBeSameAs(first);
        other.ShouldNotBeSameAs(first);
    }

    [Fact]
    public void ReadingAWarmUpBarThrowsButTryGetValueReportsItQuietly()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([1, 2, 3, 4, 5]);
        IndicatorSet indicators = new(bars, window: null);
        IndicatorSeries sma = indicators.Sma(3);

        // Act
        bool hasValue = sma.TryGetValue(1, out double value);

        // Assert
        hasValue.ShouldBeFalse();
        value.ShouldBe(0.0);
        Should.Throw<InvalidOperationException>(() => sma[1]);
    }

    [Fact]
    public void TryGetPairNeedsBothBarsToCarryAValue()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromCloses([1, 2, 3, 4, 5]);
        IndicatorSet indicators = new(bars, window: null);
        IndicatorSeries sma = indicators.Sma(3);

        // Act
        bool atFirstValidBar = sma.TryGetPair(2, out _, out _);
        bool atSecondValidBar = sma.TryGetPair(3, out double previous, out double current);

        // Assert - bar 2 is the first with a value, so the pair (1, 2) is incomplete.
        atFirstValidBar.ShouldBeFalse();
        atSecondValidBar.ShouldBeTrue();
        previous.ShouldBe(2.0, 1e-12);
        current.ShouldBe(3.0, 1e-12);
    }

    [Fact]
    public void AFailedTaLibCallProducesASeriesWithNoValues()
    {
        // Arrange - a period longer than the series makes TA-Lib return nothing usable.
        IReadOnlyList<Bar> bars = TestBars.FromCloses([1, 2, 3]);
        IndicatorSet indicators = new(bars, window: null);

        // Act
        IndicatorSeries sma = indicators.Sma(50);

        // Assert
        sma.NBElement.ShouldBe(0);
        Enumerable.Range(0, 3).ShouldAllBe(i => !sma.HasValueAt(i));
    }

    [Fact]
    public void AnEmptySeriesProducesAnEmptyIndicator()
    {
        // Arrange
        IReadOnlyList<Bar> bars = [];
        IndicatorSet indicators = new(bars, window: null);

        // Act
        IndicatorSeries sma = indicators.Sma(3);
        MacdSeries macd = indicators.Macd(12, 26, 9);
        BollingerBandSeries bands = indicators.BollingerBands(20, 2.0, 2.0);

        // Assert
        sma.Count.ShouldBe(0);
        macd.Line.Count.ShouldBe(0);
        bands.Upper.Count.ShouldBe(0);
    }
}
