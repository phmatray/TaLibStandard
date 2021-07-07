using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func
{
    public class MultTests
    {
        [Fact]
        public void MultDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] real0 = fixture.CreateMany<double>(count: 100).ToArray();
            double[] real1 = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Mult(
                StartIdx,
                EndIdx,
                real0,
                real1);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void MultFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] real0 = fixture.CreateMany<float>(count: 100).ToArray();
            float[] real1 = fixture.CreateMany<float>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.Mult(
                StartIdx,
                EndIdx,
                real0,
                real1);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
