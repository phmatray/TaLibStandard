using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionBollingerBands;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class BollingerBandsTests
{
    [Fact]
    public void BollingerBandsDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] real = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        BollingerBandsResult actualResult = TAMath.BollingerBands(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void BollingerBandsFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] real = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        BollingerBandsResult actualResult = TAMath.BollingerBands(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}