using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Cdl
{
    public class CdlRiseFall3MethodsTests
    {
        [Fact]
        public void CdlRiseFall3MethodsDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int startIdx = 0;
            const int endIdx = 99;
            double[] open = fixture.CreateMany<double>(count: 100).ToArray();
            double[] high = fixture.CreateMany<double>(count: 100).ToArray();
            double[] low = fixture.CreateMany<double>(count: 100).ToArray();
            double[] close = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.CdlRiseFall3Methods(
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
        public void CdlRiseFall3MethodsFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int startIdx = 0;
            const int endIdx = 99;
            float[] open = fixture.CreateMany<float>(count: 100).ToArray();
            float[] high = fixture.CreateMany<float>(count: 100).ToArray();
            float[] low = fixture.CreateMany<float>(count: 100).ToArray();
            float[] close = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.CdlRiseFall3Methods(
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
