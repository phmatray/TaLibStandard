using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class MinusDMTests
{
    [Fact]
    public void MinusDMDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        MinusDMResult actualResult = TAMath.MinusDM(
            startIdx,
            endIdx,
            high,
            low);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void MinusDMFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        MinusDMResult actualResult = TAMath.MinusDM(
            startIdx,
            endIdx,
            high,
            low);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}