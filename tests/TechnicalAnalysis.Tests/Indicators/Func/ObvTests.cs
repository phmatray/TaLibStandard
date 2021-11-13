using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionObv;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class ObvTests
{
    [Fact]
    public void ObvDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] real = fixture.CreateMany<double>(100).ToArray();
        double[] volume = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        ObvResult actualResult = TAMath.Obv(
            startIdx,
            endIdx,
            real,
            volume);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void ObvFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] real = fixture.CreateMany<float>(100).ToArray();
        float[] volume = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        ObvResult actualResult = TAMath.Obv(
            startIdx,
            endIdx,
            real,
            volume);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}