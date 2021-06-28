using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace GLPM.TechnicalAnalysis.Tests.Indicators.Func
{
    public class AvgPriceTests
    {
        [Fact]
        public void AvgPriceDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] open = fixture.CreateMany<double>(count: 100).ToArray();
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.AvgPrice(
                StartIdx,
                EndIdx,
                open,
                high,
                low,
                close);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void AvgPriceFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] open = fixture.CreateMany<double>(count: 100).ToArray();
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.AvgPrice(
                StartIdx,
                EndIdx,
                open,
                high,
                low,
                close);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
