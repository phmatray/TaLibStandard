using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func
{
    public class AroonOscTests
    {
        [Fact]
        public void AroonOscDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int startIdx = 0;
            const int endIdx = 99;
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.AroonOsc(
                startIdx,
                endIdx,
                high,
                low);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void AroonOscFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int startIdx = 0;
            const int endIdx = 99;
            float[] high = fixture.CreateMany<float>(count: 100).ToArray();
            float[] low = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.AroonOsc(
                startIdx,
                endIdx,
                high,
                low);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
