// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

public class TechnicalAnalyzerTests
{
    [Fact]
    public void Constructor_WithPriceData_InitializesSuccessfully()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);

        // Act
        TechnicalAnalyzer analyzer = new(priceData);

        // Assert
        analyzer.ShouldNotBeNull();
    }

    [Fact]
    public void TrendProperty_ReturnsValidInstance()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TechnicalAnalyzer analyzer = new(priceData);

        // Act
        TrendAnalysis trend = analyzer.Trend;

        // Assert
        trend.ShouldNotBeNull();
    }

    [Fact]
    public void TrendProperty_ReturnsTheSameInstance()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TechnicalAnalyzer analyzer = new(priceData);

        // Act
        TrendAnalysis trend1 = analyzer.Trend;
        TrendAnalysis trend2 = analyzer.Trend;

        // Assert
        trend1.ShouldBe(trend2);
    }

    [Fact]
    public void MomentumProperty_ReturnsValidInstance()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TechnicalAnalyzer analyzer = new(priceData);

        // Act
        MomentumAnalysis momentum = analyzer.Momentum;

        // Assert
        momentum.ShouldNotBeNull();
    }

    [Fact]
    public void MomentumProperty_ReturnsTheSameInstance()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromClose(close);
        TechnicalAnalyzer analyzer = new(priceData);

        // Act
        MomentumAnalysis momentum1 = analyzer.Momentum;
        MomentumAnalysis momentum2 = analyzer.Momentum;

        // Assert
        momentum1.ShouldBe(momentum2);
    }

    [Fact]
    public void VolatilityProperty_ReturnsValidInstance()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        TechnicalAnalyzer analyzer = new(priceData);

        // Act
        VolatilityAnalysis volatility = analyzer.Volatility;

        // Assert
        volatility.ShouldNotBeNull();
    }

    [Fact]
    public void VolatilityProperty_ReturnsTheSameInstance()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        PriceData priceData = PriceData.FromOHLC(open, high, low, close);
        TechnicalAnalyzer analyzer = new(priceData);

        // Act
        VolatilityAnalysis volatility1 = analyzer.Volatility;
        VolatilityAnalysis volatility2 = analyzer.Volatility;

        // Assert
        volatility1.ShouldBe(volatility2);
    }

    [Fact]
    public void FromClose_CreatesValidAnalyzer()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];

        // Act
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromClose(close);

        // Assert
        analyzer.ShouldNotBeNull();
    }

    [Fact]
    public void FromClose_SupportsFluentAnalysis()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];

        // Act
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromClose(close);
        TrendEmaResult emaResult = analyzer.Trend.Ema();

        // Assert
        emaResult.ShouldNotBeNull();
        emaResult.RetCode.ShouldBe(RetCode.Success);
        emaResult.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void FromOHLC_CreatesValidAnalyzer()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];

        // Act
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromOHLC(open, high, low, close);

        // Assert
        analyzer.ShouldNotBeNull();
    }

    [Fact]
    public void FromOHLC_SupportsFluentAnalysis()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];

        // Act
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromOHLC(open, high, low, close);
        TrendAdxResult adxResult = analyzer.Trend.Adx();

        // Assert
        adxResult.ShouldNotBeNull();
        adxResult.RetCode.ShouldBe(RetCode.Success);
        adxResult.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void FromOHLCV_CreatesValidAnalyzer()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        double[] volume = [.. fixture.CreateMany<double>(100)];

        // Act
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromOHLCV(open, high, low, close, volume);

        // Assert
        analyzer.ShouldNotBeNull();
    }

    [Fact]
    public void FromOHLCV_SupportsFluentAnalysis()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        double[] volume = [.. fixture.CreateMany<double>(100)];

        // Act
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromOHLCV(open, high, low, close, volume);
        VolatilityAtrResult atrResult = analyzer.Volatility.Atr();

        // Assert
        atrResult.ShouldNotBeNull();
        atrResult.RetCode.ShouldBe(RetCode.Success);
        atrResult.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void FluentAPI_SupportsChainingAcrossWorkflows()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromOHLC(open, high, low, close);

        // Act - Chain multiple analysis operations
        TrendEmaResult emaResult = analyzer.Trend.Ema();
        MomentumRsiResult rsiResult = analyzer.Momentum.Rsi();
        VolatilityAtrResult atrResult = analyzer.Volatility.Atr();

        // Assert
        emaResult.ShouldNotBeNull();
        emaResult.IsSuccess.ShouldBeTrue();

        rsiResult.ShouldNotBeNull();
        rsiResult.IsSuccess.ShouldBeTrue();

        atrResult.ShouldNotBeNull();
        atrResult.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void FluentAPI_SupportsMultipleIndicatorsFromSameWorkflow()
    {
        // Arrange
        Fixture fixture = new();
        double[] close = [.. fixture.CreateMany<double>(100)];
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromClose(close);

        // Act - Multiple trend indicators
        TrendEmaResult emaResult = analyzer.Trend.Ema();
        TrendSmaResult smaResult = analyzer.Trend.Sma();

        // Assert
        emaResult.ShouldNotBeNull();
        emaResult.IsSuccess.ShouldBeTrue();
        emaResult.Period.ShouldBe(20);

        smaResult.ShouldNotBeNull();
        smaResult.IsSuccess.ShouldBeTrue();
        smaResult.Period.ShouldBe(50);
    }

    [Fact]
    public void FluentAPI_SupportsCompleteWorkflowExample()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(100)];
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];

        // Act - Complete workflow as shown in documentation
        TechnicalAnalyzer analyzer = TechnicalAnalyzer.FromOHLC(open, high, low, close);

        // Analyze trend
        TrendEmaResult ema = analyzer.Trend.Ema();
        TrendSmaResult sma = analyzer.Trend.Sma(period: 50);

        // Analyze momentum
        MomentumRsiResult rsi = analyzer.Momentum.Rsi();
        MomentumMacdResult macd = analyzer.Momentum.Macd();

        // Analyze volatility
        VolatilityAtrResult atr = analyzer.Volatility.Atr();
        VolatilityBollingerBandsResult bb = analyzer.Volatility.BollingerBands();

        // Assert - All operations succeed
        ema.IsSuccess.ShouldBeTrue();
        sma.IsSuccess.ShouldBeTrue();
        rsi.IsSuccess.ShouldBeTrue();
        macd.IsSuccess.ShouldBeTrue();
        atr.IsSuccess.ShouldBeTrue();
        bb.IsSuccess.ShouldBeTrue();
    }
}
