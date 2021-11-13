using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionAdOsc;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func;

public class AdOscTests
{
    [Fact]
    public void AdOscDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
        double[] close = fixture.CreateMany<double>(100).ToArray();
        double[] volume = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        AdOscResult actualResult = TAMath.AdOsc(
            startIdx,
            endIdx,
            high,
            low,
            close,
            volume);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void AdOscFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
        float[] close = fixture.CreateMany<float>(100).ToArray();
        float[] volume = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        AdOscResult actualResult = TAMath.AdOsc(
            startIdx,
            endIdx,
            high,
            low,
            close,
            volume);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}