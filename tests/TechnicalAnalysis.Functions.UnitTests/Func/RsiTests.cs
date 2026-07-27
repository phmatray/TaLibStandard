// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class RsiTests
{
    [Fact]
    public void RsiDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. fixture.CreateMany<double>(100)];
            
        // Act
        RsiResult actualResult = TAMath.Rsi(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void RsiFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] real = [.. fixture.CreateMany<float>(100)];
            
        // Act
        RsiResult actualResult = TAMath.Rsi(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void RsiOnFlatSeriesReturnsZeroRatherThanNaN()
    {
        // Arrange
        // A halted instrument produces a window with no price movement, so the average gain and the
        // average loss are both exactly zero and the ratio is 0 / 0. Unguarded that is NaN returned
        // next to RetCode.Success, which is worse than an error because it reads as a value.
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. Enumerable.Repeat(42.0, 100)];

        // Act
        RsiResult actualResult = TAMath.Rsi(StartIdx, EndIdx, real, 14);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBeGreaterThan(0);

        for (int k = 0; k < actualResult.NBElement; k++)
        {
            double rsi = actualResult.Real[k];
            double.IsNaN(rsi).ShouldBeFalse($"RSI was NaN at output element {k}.");
            rsi.ShouldBe(0.0, 1e-9);
        }
    }

    [Fact]
    public void RsiOnMonotonicallyRisingSeriesReturnsOneHundred()
    {
        // Arrange
        // Every bar gains and none loses, so the average loss stays zero and RSI is
        // 100 * gain / (gain + 0) = 100 exactly. This is the opposite boundary to the flat series
        // and confirms the zero guard did not swallow the legitimate zero-loss case.
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = new double[100];

        for (int i = 0; i < 100; i++)
        {
            real[i] = i + 1;
        }

        // Act
        RsiResult actualResult = TAMath.Rsi(StartIdx, EndIdx, real, 14);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBeGreaterThan(0);

        for (int k = 0; k < actualResult.NBElement; k++)
        {
            actualResult.Real[k].ShouldBe(100.0, 1e-9, $"RSI was not 100 at output element {k}.");
        }
    }
}
