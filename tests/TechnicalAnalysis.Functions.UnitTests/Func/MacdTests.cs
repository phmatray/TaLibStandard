// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class MacdTests
{
    [Fact]
    public void MacdDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. fixture.CreateMany<double>(100)];
            
        // Act
        MacdResult actualResult = TAMath.Macd(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void MacdFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] real = [.. fixture.CreateMany<float>(100)];
            
        // Act
        MacdResult actualResult = TAMath.Macd(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void MacdOnConstantSeriesIsZero()
    {
        // Arrange
        // MACD is the difference of two EMAs of the same series, so on a constant series both legs
        // are that constant and all three outputs must be exactly zero. This is the propagation
        // guard for the shared EMA seed: when the seed was scaled by (period - 1) / period the two
        // legs were mis-seeded by *different* amounts (12 versus 26), and the difference did not
        // cancel -- MACD read 0.53 on a series that never moved.
        const int StartIdx = 0;
        const int EndIdx = 199;
        double[] real = [.. Enumerable.Repeat(100.0, 200)];

        // Act
        MacdResult actualResult = TAMath.Macd(StartIdx, EndIdx, real, 12, 26, 9);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBeGreaterThan(0);

        for (int k = 0; k < actualResult.NBElement; k++)
        {
            actualResult.MacdValue[k].ShouldBe(0.0, 1e-9, $"MACD line was non-zero at element {k}.");
            actualResult.MacdSignal[k].ShouldBe(0.0, 1e-9, $"MACD signal was non-zero at element {k}.");
            actualResult.MacdHist[k].ShouldBe(0.0, 1e-9, $"MACD histogram was non-zero at element {k}.");
        }
    }
}
