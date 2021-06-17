using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace GLPM.TechnicalAnalysis.Tests.Indicators.Func
{
    public class TrueRangeTests
    {
        [Fact]
        public void TrueRangeDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.TrueRange(
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
        public void TrueRangeFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.TrueRange(
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
