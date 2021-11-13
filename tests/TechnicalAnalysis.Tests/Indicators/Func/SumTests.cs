using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionSum;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class SumTests
{
    [Fact]
    public void SumDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] real = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        SumResult actualResult = TAMath.Sum(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void SumFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] real = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        SumResult actualResult = TAMath.Sum(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}