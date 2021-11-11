using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class SarTests
{
    [Fact]
    public void SarDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        var actualResult = TAMath.Sar(
            startIdx,
            endIdx,
            high,
            low);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void SarFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        var actualResult = TAMath.Sar(
            startIdx,
            endIdx,
            high,
            low);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}