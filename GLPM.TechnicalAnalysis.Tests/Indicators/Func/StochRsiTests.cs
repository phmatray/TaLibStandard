using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace GLPM.TechnicalAnalysis.Tests.Indicators.Func
{
    public class StochRsiTests
    {
        [Fact]
        public void StochRsiDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] real = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.StochRsi(
                StartIdx,
                EndIdx,
                real);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void StochRsiFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] real = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.StochRsi(
                StartIdx,
                EndIdx,
                real);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}