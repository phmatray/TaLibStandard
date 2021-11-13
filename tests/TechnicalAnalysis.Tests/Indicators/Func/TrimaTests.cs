using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionTrima;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class TrimaTests
{
    [Fact]
    public void TrimaDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] real = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        TrimaResult actualResult = TAMath.Trima(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void TrimaFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] real = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        TrimaResult actualResult = TAMath.Trima(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}