using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func
{
    public class SqrtTests
    {
        [Fact]
        public void SqrtDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] real = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Sqrt(
                StartIdx,
                EndIdx,
                real);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void SqrtFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] real = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Sqrt(
                StartIdx,
                EndIdx,
                real);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
