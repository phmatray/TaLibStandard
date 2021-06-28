using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace GLPM.TechnicalAnalysis.Tests.Indicators.Func
{
    public class StochTests
    {
        [Fact]
        public void StochDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Stoch(
                StartIdx,
                EndIdx,
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
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] high = fixture.CreateMany<float>(count: 100).ToArray();
            float[] low = fixture.CreateMany<float>(count: 100).ToArray();
            float[] close = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Stoch(
                StartIdx,
                EndIdx,
                high,
                low,
                close);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}