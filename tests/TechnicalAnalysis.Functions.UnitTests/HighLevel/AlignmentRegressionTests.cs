// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// This file is the regression suite for the historical alignment bug and is meant to be readable on
/// its own as proof that the bug cannot recur.
///
/// THE BUG. TA-Lib fills its output array from index 0, while <c>IndicatorResult.BegIdx</c> is an index
/// into the INPUT series. Output element <c>k</c> therefore describes bar <c>BegIdx + k</c>: the last
/// valid ARRAY index is <c>NBElement - 1</c> and the last valid BAR index is <c>BegIdx + NBElement - 1</c>.
/// The abandoned high-level API read <c>Values[BegIdx + NBElement - 1]</c> for every "current value"
/// property, i.e. it subscripted the array with a bar index. For SMA(30) over closes 1..100 that is
/// <c>Values[29 + 71 - 1] == Values[99]</c>, an untouched zero slot, so it silently returned 0.0 and every
/// derived predicate was computed from that zero. Its 32 tests all passed because none of them asserted
/// a computed value.
/// </remarks>
public class AlignmentRegressionTests
{
    // The exact fixture the historical bug was measured on: closes 1.0 .. 100.0.
    // TAMath.Sma(0, 99, closes, 30) reports BegIdx = 29, NBElement = 71.
    private static double[] ClosesOneToOneHundred()
    {
        double[] closes = new double[100];
        for (int i = 0; i < 100; i++)
        {
            closes[i] = i + 1;
        }

        return closes;
    }

    // The abandoned branch's expression, written out verbatim so the test names the failure mode.
    // Values is sliced to Count, so this now indexes past the end instead of reading padding.
    private static double ReadTheAbandonedBranchWay(IndicatorSeries series)
    {
        return series.WarmValues[series.FirstBar!.Value + series.WarmCount - 1];
    }

    [Fact]
    public void Sma30OverClosesOneToOneHundredHasLatest85Point5AndNotZero()
    {
        // Arrange
        // SMA(30) at the last bar is the mean of the final thirty closes, 71..100.
        // Sum = (71 + 100) * 30 / 2 = 2565; 2565 / 30 = 85.5.
        // The abandoned API returned 0.0 here, which is why the "not zero" assertion is separate.
        PriceSeries prices = PriceSeries.FromClose(ClosesOneToOneHundred());

        // Act
        IndicatorSeries sma = prices.Sma(30);

        // Assert
        sma.Latest.ShouldBe(85.5);
        sma.Latest.ShouldNotBe(0.0);
        sma.FirstBar.ShouldBe(29);
        sma.LastBar.ShouldBe(99);
        sma.WarmCount.ShouldBe(71);
        sma.BarCount.ShouldBe(100);
        sma.RetCode.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void Sma30ValuesLandOnTheCorrectBarIndices()
    {
        // Arrange
        // bar 29 -> mean of closes 1..30   = (1 + 30) / 2  = 15.5  (the first warm bar)
        // bar 50 -> mean of closes 22..51  = (22 + 51) / 2 = 36.5
        // bar 99 -> mean of closes 71..100 = (71 + 100) / 2 = 85.5
        // Note bar 50 sits at ARRAY index 50 - 29 = 21; a test that passed while the two index
        // spaces were confused would have to read 36.5 out of array slot 50, which holds 65.5.
        PriceSeries prices = PriceSeries.FromClose(ClosesOneToOneHundred());
        IndicatorSeries sma = prices.Sma(30);

        // Act
        double? atFirstWarmBar = sma[29];
        double? atMiddleBar = sma[50];
        double? atLastBar = sma[99];

        // Assert
        atFirstWarmBar.HasValue.ShouldBeTrue();
        atMiddleBar.HasValue.ShouldBeTrue();
        atLastBar.HasValue.ShouldBeTrue();
        atFirstWarmBar.ShouldBe(15.5);
        atMiddleBar.ShouldBe(36.5);
        atLastBar.ShouldBe(85.5);

        // The array-index and bar-index spaces are not interchangeable: array slot 50 is bar 79,
        // whose value is the mean of closes 51..80 = 65.5, not 36.5.
        sma.WarmValues[50].ShouldBe(65.5);
        sma[79].ShouldBe(65.5);
    }

    [Fact]
    public void BarsBeforeTheWarmUpAreNullAndNotWarm()
    {
        // Arrange
        // SMA(30) needs thirty closes, so bars 0..28 have no value at all. Absence is null:
        // never 0.0, never NaN, and never an exception for an in-range bar.
        PriceSeries prices = PriceSeries.FromClose(ClosesOneToOneHundred());
        IndicatorSeries sma = prices.Sma(30);

        // Act
        double? atBarZero = sma[0];
        double? atLastColdBar = sma[28];

        // Assert
        atBarZero.ShouldBeNull();
        atLastColdBar.ShouldBeNull();
        sma.IsWarmAt(28).ShouldBeFalse();
        sma.IsWarmAt(29).ShouldBeTrue();
    }

    [Fact]
    public void BarsOutsideTheSeriesThrowArgumentOutOfRange()
    {
        // Arrange
        // "Bar 5 of a 30-period SMA" is a legitimate question answered null.
        // "Bar 100 of a 100-bar series" is a caller bug and throws.
        PriceSeries prices = PriceSeries.FromClose(ClosesOneToOneHundred());
        IndicatorSeries sma = prices.Sma(30);

        // Act
        ArgumentOutOfRangeException belowRange = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = sma[-1];
        });

        ArgumentOutOfRangeException aboveRange = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = sma[100];
        });

        // Assert
        belowRange.ParamName.ShouldBe("bar");
        aboveRange.ParamName.ShouldBe("bar");
    }

    [Fact]
    public void TheAbandonedBranchExpressionNowThrowsInsteadOfReturningPadding()
    {
        // Arrange
        // Values is sliced to exactly Count, so the padding is unreachable. The old expression
        // Values[BegIdx + NBElement - 1] is Values[29 + 71 - 1] = Values[99] over a 71-element
        // span, which raises IndexOutOfRangeException rather than quietly returning 0.0.
        PriceSeries prices = PriceSeries.FromClose(ClosesOneToOneHundred());
        IndicatorSeries sma = prices.Sma(30);

        // Act
        int valuesLength = sma.WarmValues.Length;
        double firstValue = sma.WarmValues[0];
        double lastValue = sma.WarmValues[70];

        // Assert
        valuesLength.ShouldBe(71);
        firstValue.ShouldBe(15.5);
        lastValue.ShouldBe(85.5);
        Should.Throw<IndexOutOfRangeException>(() =>
        {
            _ = ReadTheAbandonedBranchWay(sma);
        });
    }

    [Fact]
    public void RetCodeSuccessDoesNotMeanTheSeriesHasValues()
    {
        // Arrange
        // TAMath.Sma(0, 4, fiveBars, 30) returns Success with BegIdx = 0 and NBElement = 0.
        // BegIdx is a lie in that state, so IsEmpty (equivalently Count == 0) is the only warmth
        // test. This is the assertion the abandoned branch's 32 tests were missing.
        double[] fiveBars = [1.0, 2.0, 3.0, 4.0, 5.0];
        PriceSeries prices = PriceSeries.FromClose(fiveBars);

        // Act
        IndicatorSeries sma = prices.Sma(30);

        // Assert
        sma.RetCode.ShouldBe(RetCode.Success);
        sma.HasValues.ShouldBeFalse();
        sma.WarmCount.ShouldBe(0);
        sma.BarCount.ShouldBe(5);
        sma.FirstBar.ShouldBeNull();
        sma.LastBar.ShouldBeNull();
        sma.Latest.ShouldBeNull();
        sma[4].ShouldBeNull();
        sma.WarmValues.Length.ShouldBe(0);
    }
}
