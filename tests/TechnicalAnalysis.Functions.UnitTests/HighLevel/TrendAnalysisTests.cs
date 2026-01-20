// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

public class TrendAnalysisTests
{
    [Fact]
    public void EmaWithDefaultPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TrendAnalysis trendAnalysis = new(priceData);

        // Act
        TrendEmaResult result = trendAnalysis.Ema();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(20);
    }

    [Fact]
    public void EmaWithCustomPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TrendAnalysis trendAnalysis = new(priceData);
        const int customPeriod = 50;

        // Act
        TrendEmaResult result = trendAnalysis.Ema(customPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(customPeriod);
    }

    [Fact]
    public void SmaWithDefaultPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TrendAnalysis trendAnalysis = new(priceData);

        // Act
        TrendSmaResult result = trendAnalysis.Sma();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(50);
    }

    [Fact]
    public void SmaWithCustomPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TrendAnalysis trendAnalysis = new(priceData);
        const int customPeriod = 20;

        // Act
        TrendSmaResult result = trendAnalysis.Sma(customPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(customPeriod);
    }

    [Fact]
    public void AdxWithDefaultPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        TrendAnalysis trendAnalysis = new(priceData);

        // Act
        TrendAdxResult result = trendAnalysis.Adx();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(14);
    }

    [Fact]
    public void AdxWithCustomPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        TrendAnalysis trendAnalysis = new(priceData);
        const int customPeriod = 20;

        // Act
        TrendAdxResult result = trendAnalysis.Adx(customPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(customPeriod);
    }
}
