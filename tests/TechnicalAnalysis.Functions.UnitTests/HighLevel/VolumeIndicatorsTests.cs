// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// The one indicator on this surface with no warm-up at all: on-balance volume is warm from bar 0,
/// which makes it the case that proves <c>FirstBar</c> is read from the result rather than assumed
/// to be positive. It is also the only consumer of the volume component, so it is what keeps the
/// volume guard and the volume accessor honest.
/// </remarks>
public class VolumeIndicatorsTests
{
    private static double[] Constant(int count, double value)
    {
        double[] values = new double[count];
        Array.Fill(values, value);
        return values;
    }

    [Fact]
    public void ObvSignsEachBarsVolumeByTheDirectionOfTheCloseAndIsWarmFromBarZero()
    {
        // Arrange
        // Closes 10, 11, 11, 9, 12 with volumes 100, 200, 300, 400, 500. The running total starts
        // at the first bar's volume and then adds on an up close, subtracts on a down close and
        // holds on an unchanged close:
        //   bar 0: 100                       (seed)
        //   bar 1: 100 + 200 = 300           (11 > 10)
        //   bar 2: 300                       (11 == 11)
        //   bar 3: 300 - 400 = -100          (9 < 11)
        //   bar 4: -100 + 500 = 400          (12 > 9)
        double[] close = [10.0, 11.0, 11.0, 9.0, 12.0];
        double[] high = [11.0, 12.0, 12.0, 10.0, 13.0];
        double[] low = [9.0, 10.0, 10.0, 8.0, 11.0];
        double[] volume = [100.0, 200.0, 300.0, 400.0, 500.0];
        PriceSeries prices = PriceSeries.FromOhlcv(close, high, low, close, volume);

        // Act
        IndicatorSeries obv = prices.Obv();

        // Assert
        obv.RetCode.ShouldBe(RetCode.Success);
        obv.FirstBar.ShouldBe(0);
        obv.LastBar.ShouldBe(4);
        obv.WarmCount.ShouldBe(5);
        obv.BarCount.ShouldBe(5);
        obv[0].ShouldBe(100.0);
        obv[1].ShouldBe(300.0);
        obv[2].ShouldBe(300.0);
        obv[3].ShouldBe(-100.0);
        obv[4].ShouldBe(400.0);
        obv.Latest.ShouldBe(400.0);

        // Warm from bar 0 means the bar-aligned projection has no NaN padding at all.
        foreach (double value in obv.ToBarAlignedArray())
        {
            double.IsNaN(value).ShouldBeFalse();
        }
    }

    [Fact]
    public void ObvRefusesAPriceSeriesThatCarriesNoVolume()
    {
        // Arrange
        // Substituting a constant volume would silently turn on-balance volume into a signed bar
        // counter, which is exactly the sort of plausible-looking wrong answer this API refuses to
        // produce.
        PriceSeries closeOnly = PriceSeries.FromClose(Constant(50, 100.0));
        PriceSeries hlc = PriceSeries.FromHlc(Constant(50, 101.0), Constant(50, 99.0), Constant(50, 100.0));

        // Act
        InvalidOperationException fromCloseOnly = Should.Throw<InvalidOperationException>(() =>
        {
            _ = closeOnly.Obv();
        });

        InvalidOperationException fromHlc = Should.Throw<InvalidOperationException>(() =>
        {
            _ = hlc.Obv();
        });

        // Assert
        fromCloseOnly.Message.ShouldContain("FromOhlcv");
        fromHlc.Message.ShouldContain("FromOhlcv");
    }

    [Fact]
    public void ObvOverAnEmptyFeedIsEmptyRatherThanThrowing()
    {
        // Arrange
        PriceSeries empty = PriceSeries.FromOhlcv([], [], [], [], []);

        // Act
        IndicatorSeries obv = empty.Obv();

        // Assert
        obv.RetCode.ShouldBe(RetCode.Success);
        obv.HasValues.ShouldBeFalse();
        obv.BarCount.ShouldBe(0);
        obv.FirstBar.ShouldBeNull();
        obv.Latest.ShouldBeNull();
    }
}
