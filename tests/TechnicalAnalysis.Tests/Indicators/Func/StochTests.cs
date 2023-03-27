using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class StochTests
{
    [Fact]
    public void StochDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
        double[] close = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        var actualResult = TAMath.Stoch(
            startIdx,
            endIdx,
            high,
            low,
            close);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void StochFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
        float[] close = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        var actualResult = TAMath.Stoch(
            startIdx,
            endIdx,
            high,
            low,
            close);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}