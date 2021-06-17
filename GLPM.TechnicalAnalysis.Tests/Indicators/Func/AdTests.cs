using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace GLPM.TechnicalAnalysis.Tests.Indicators.Func
{
    public class AdTests
    {
        [Fact]
        public void AdDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            double[] volume = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Ad(
                StartIdx,
                EndIdx,
                high,
                low,
                close,
                volume);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void AdFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] high = fixture.CreateMany<float>(count: 100).ToArray();
            float[] low = fixture.CreateMany<float>(count: 100).ToArray();
            float[] close = fixture.CreateMany<float>(count: 100).ToArray();
            float[] volume = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Ad(
                StartIdx,
                EndIdx,
                high,
                low,
                close,
                volume);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
