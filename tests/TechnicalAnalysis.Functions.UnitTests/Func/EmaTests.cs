// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class EmaTests
{
    [Fact]
    public void EmaDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. fixture.CreateMany<double>(100)];
            
        // Act
        EmaResult actualResult = TAMath.Ema(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void EmaFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] real = [.. fixture.CreateMany<float>(100)];
            
        // Act
        EmaResult actualResult = TAMath.Ema(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void EmaSeedIsTheSimpleAverageOfTheFirstPeriodValues()
    {
        // Arrange
        // The EMA seed is the SMA of the first `timePeriod` closes. Here that is
        // (0 + 0 + 0 + 0 + 100) / 5 = 20, and with exactly five bars the seed IS the only output,
        // so nothing downstream can mask a wrong seed. Dropping the last term from the sum while
        // still dividing by 5 seeds 0 and then smooths once to 100 / 3 = 33.33, which this pins.
        const int StartIdx = 0;
        const int EndIdx = 4;
        double[] real = [0.0, 0.0, 0.0, 0.0, 100.0];

        // Act
        EmaResult actualResult = TAMath.Ema(StartIdx, EndIdx, real, 5);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBe(1);
        actualResult.Real[0].ShouldBe(20.0, 1e-9);
    }

    [Fact]
    public void EmaOnConstantSeriesReturnsThatConstant()
    {
        // Arrange
        // Smoothing a constant can only ever return that constant: the seed is the mean of twenty
        // 100s, and every later bar is prev + k * (100 - prev) with prev already 100. A seed that
        // averages nineteen values over a divisor of twenty starts at 95 and smooths to 95.476190,
        // which is what this asserts against.
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. Enumerable.Repeat(100.0, 100)];

        // Act
        EmaResult actualResult = TAMath.Ema(StartIdx, EndIdx, real, 20);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBe(81);

        for (int k = 0; k < actualResult.NBElement; k++)
        {
            actualResult.Real[k].ShouldBe(100.0, 1e-9, $"EMA drifted at output element {k}.");
        }
    }
}
