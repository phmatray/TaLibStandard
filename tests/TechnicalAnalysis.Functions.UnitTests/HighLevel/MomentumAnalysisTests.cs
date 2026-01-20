// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

public class MomentumAnalysisTests
{
    [Fact]
    public void RsiWithDefaultPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        MomentumAnalysis momentumAnalysis = new(priceData);

        // Act
        MomentumRsiResult result = momentumAnalysis.Rsi();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(14);
    }

    [Fact]
    public void RsiWithCustomPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        MomentumAnalysis momentumAnalysis = new(priceData);
        const int customPeriod = 21;

        // Act
        MomentumRsiResult result = momentumAnalysis.Rsi(customPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(customPeriod);
    }

    [Fact]
    public void MacdWithDefaultPeriods()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        MomentumAnalysis momentumAnalysis = new(priceData);

        // Act
        MomentumMacdResult result = momentumAnalysis.Macd();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.FastPeriod.ShouldBe(12);
        result.SlowPeriod.ShouldBe(26);
        result.SignalPeriod.ShouldBe(9);
    }

    [Fact]
    public void MacdWithCustomPeriods()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        MomentumAnalysis momentumAnalysis = new(priceData);
        const int customFastPeriod = 5;
        const int customSlowPeriod = 13;
        const int customSignalPeriod = 5;

        // Act
        MomentumMacdResult result = momentumAnalysis.Macd(customFastPeriod, customSlowPeriod, customSignalPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.FastPeriod.ShouldBe(customFastPeriod);
        result.SlowPeriod.ShouldBe(customSlowPeriod);
        result.SignalPeriod.ShouldBe(customSignalPeriod);
    }

    [Fact]
    public void StochWithDefaultPeriods()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        MomentumAnalysis momentumAnalysis = new(priceData);

        // Act
        MomentumStochResult result = momentumAnalysis.Stoch();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.FastKPeriod.ShouldBe(14);
        result.SlowKPeriod.ShouldBe(3);
        result.SlowDPeriod.ShouldBe(3);
    }

    [Fact]
    public void StochWithCustomPeriods()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        MomentumAnalysis momentumAnalysis = new(priceData);
        const int customFastKPeriod = 21;
        const int customSlowKPeriod = 5;
        const int customSlowDPeriod = 5;

        // Act
        MomentumStochResult result = momentumAnalysis.Stoch(customFastKPeriod, customSlowKPeriod, customSlowDPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.FastKPeriod.ShouldBe(customFastKPeriod);
        result.SlowKPeriod.ShouldBe(customSlowKPeriod);
        result.SlowDPeriod.ShouldBe(customSlowDPeriod);
    }
}
