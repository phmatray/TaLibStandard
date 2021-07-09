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
            const int StartIdx = 0;
            const int EndIdx = 99;
            double[] real = fixture.CreateMany<double>(count: 100).ToArray();
            double[] periods = fixture.CreateMany<double>(count: 100).ToArray();
            
            // Act
            var actualResult = TAMath.MovingAverageVariablePeriod(
                StartIdx,
                EndIdx,
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
            const int StartIdx = 0;
            const int EndIdx = 99;
            float[] real = fixture.CreateMany<float>(count: 100).ToArray();
            float[] periods = fixture.CreateMany<float>(count: 100).ToArray();

            // Act
            var actualResult = TAMath.MovingAverageVariablePeriod(
                StartIdx,
                EndIdx,
                real,
                periods);

            // Assert
            actualResult.Should().NotBeNull();
            actualResult.RetCode.Should().Be(RetCode.Success);
        }
    }
}
