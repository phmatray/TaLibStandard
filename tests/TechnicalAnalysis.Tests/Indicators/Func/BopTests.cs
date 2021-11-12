using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class BopTests
{
    [Fact]
    public void BopDouble()
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
        BopResult actualResult = TAMath.Bop(
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
    public void BopFloat()
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
        BopResult actualResult = TAMath.Bop(
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