using System.Linq;
using AutoFixture;
using FluentAssertions;
using TechnicalAnalysis.Common;
using Xunit;

namespace TechnicalAnalysis.Tests.Indicators.Func
{
    public class MovingAverageVariablePeriodTests
    {
        [Fact]
        public void MovingAverageVariablePeriodDouble()
        {
            // Arrange
            Fixture fixture = new();
            const int startIdx = 0;
            const int endIdx = 99;
            double[] real = fixture.CreateMany<double>(100).ToArray();
            double[] periods = fixture.CreateMany<double>(100).ToArray();
            
            // Act
            var actualResult = TAMath.MovingAverageVariablePeriod(
                startIdx,
                endIdx,
                real,
                periods);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
        
        [Fact]
        public void MovingAverageVariablePeriodFloat()
        {
            // Arrange
            Fixture fixture = new();
            const int startIdx = 0;
            const int endIdx = 99;
            float[] real = fixture.CreateMany<float>(100).ToArray();
            float[] periods = fixture.CreateMany<float>(100).ToArray();

            // Act
            var actualResult = TAMath.MovingAverageVariablePeriod(
                startIdx,
                endIdx,
                real,
                periods);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
