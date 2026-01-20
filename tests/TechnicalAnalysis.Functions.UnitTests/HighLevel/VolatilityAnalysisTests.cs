// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

public class VolatilityAnalysisTests
{
    [Fact]
    public void AtrWithDefaultPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        VolatilityAnalysis volatilityAnalysis = new(priceData);

        // Act
        VolatilityAtrResult result = volatilityAnalysis.Atr();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(14);
    }

    [Fact]
    public void AtrWithCustomPeriod()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        VolatilityAnalysis volatilityAnalysis = new(priceData);
        const int customPeriod = 20;

        // Act
        VolatilityAtrResult result = volatilityAnalysis.Atr(customPeriod);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(customPeriod);
    }

    [Fact]
    public void BollingerBandsWithDefaultSettings()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        VolatilityAnalysis volatilityAnalysis = new(priceData);

        // Act
        VolatilityBollingerBandsResult result = volatilityAnalysis.BollingerBands();

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(20);
        result.NbDevUp.ShouldBe(2.0);
        result.NbDevDn.ShouldBe(2.0);
        result.MAType.ShouldBe(MAType.Sma);
    }

    [Fact]
    public void BollingerBandsWithCustomSettings()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        VolatilityAnalysis volatilityAnalysis = new(priceData);
        const int customPeriod = 10;
        const double customNbDevUp = 2.5;
        const double customNbDevDn = 2.5;
        const MAType customMaType = MAType.Ema;

        // Act
        VolatilityBollingerBandsResult result = volatilityAnalysis.BollingerBands(customPeriod, customNbDevUp, customNbDevDn, customMaType);

        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
        result.IsSuccess.ShouldBeTrue();
        result.Period.ShouldBe(customPeriod);
        result.NbDevUp.ShouldBe(customNbDevUp);
        result.NbDevDn.ShouldBe(customNbDevDn);
        result.MAType.ShouldBe(customMaType);
    }
}
