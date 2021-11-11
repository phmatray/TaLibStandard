using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Cdl
{
    public class CdlSpinningTopTests
    {
        [Fact]
        public void CdlSpinningTopDouble()
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
            var actualResult = TAMath.CdlSpinningTop(
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
        public void CdlSpinningTopFloat()
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
            var actualResult = TAMath.CdlSpinningTop(
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
}
