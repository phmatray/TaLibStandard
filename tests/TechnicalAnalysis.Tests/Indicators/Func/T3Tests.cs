using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionT3;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class T3Tests
{
    [Fact]
    public void T3Double()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] real = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        T3Result actualResult = TAMath.T3(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void T3Float()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] real = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        T3Result actualResult = TAMath.T3(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}