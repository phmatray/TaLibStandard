using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class MamaTests
{
    [Fact]
    public void MamaDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] real = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        MamaResult actualResult = TAMath.Mama(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void MamaFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] real = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        MamaResult actualResult = TAMath.Mama(
            startIdx,
            endIdx,
            real);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}