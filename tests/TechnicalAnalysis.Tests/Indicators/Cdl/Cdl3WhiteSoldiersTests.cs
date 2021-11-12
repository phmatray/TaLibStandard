using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Candles.Candle3WhiteSoldiers;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Cdl;

public class Cdl3WhiteSoldiersTests
{
    [Fact]
    public void Cdl3WhiteSoldiersDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] open = fixture.CreateMany<double>(100).ToArray();
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
        double[] close = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        Candle3WhiteSoldiersResult actualResult = TAMath.Cdl3WhiteSoldiers(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void Cdl3WhiteSoldiersFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] open = fixture.CreateMany<float>(100).ToArray();
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
        float[] close = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        Candle3WhiteSoldiersResult actualResult = TAMath.Cdl3WhiteSoldiers(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}