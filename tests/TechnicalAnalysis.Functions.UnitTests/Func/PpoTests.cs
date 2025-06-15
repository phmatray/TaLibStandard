// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class PpoTests
{
    [Fact]
    public void PpoDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real = [.. fixture.CreateMany<double>(100)];
            
        // Act
        PpoResult actualResult = TAMath.Ppo(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void PpoFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] real = [.. fixture.CreateMany<float>(100)];
            
        // Act
        PpoResult actualResult = TAMath.Ppo(
            StartIdx,
            EndIdx,
            real);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
}
