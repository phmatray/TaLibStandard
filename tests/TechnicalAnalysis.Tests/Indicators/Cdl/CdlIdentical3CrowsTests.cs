using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Cdl
{
    public class CdlIdentical3CrowsTests
    {
        [Fact]
        public void CdlIdentical3CrowsDouble()
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
            var actualResult = TAMath.CdlIdentical3Crows(
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
        public void CdlIdentical3CrowsFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] open = fixture.CreateMany<float>(count: 100).ToArray();
            float[] high = fixture.CreateMany<float>(count: 100).ToArray();
            float[] low = fixture.CreateMany<float>(count: 100).ToArray();
            float[] close = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.CdlIdentical3Crows(
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
