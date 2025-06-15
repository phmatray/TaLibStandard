// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class MovingAverageVariablePeriodTests
{
    [Fact]
    public void MovingAverageVariablePeriodDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. fixture.CreateMany<double>(100)];
        double[] periods = [.. fixture.CreateMany<double>(100)];
            
        // Act
        MovingAverageVariablePeriodResult actualResult = TAMath.MovingAverageVariablePeriod(
            StartIdx,
            EndIdx,
            real,
            periods);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void MovingAverageVariablePeriodFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] real = [.. fixture.CreateMany<float>(100)];
        float[] periods = [.. fixture.CreateMany<float>(100)];

        // Act
        MovingAverageVariablePeriodResult actualResult = TAMath.MovingAverageVariablePeriod(
            StartIdx,
            EndIdx,
            real,
            periods);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
}
