// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class BetaTests
{
    [Fact]
    public void BetaDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] real0 = fixture.CreateMany<double>(100).ToArray();
        double[] real1 = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        BetaResult actualResult = TAMath.Beta(
            StartIdx,
            EndIdx,
            real0,
            real1);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void BetaFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] real0 = fixture.CreateMany<float>(100).ToArray();
        float[] real1 = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        BetaResult actualResult = TAMath.Beta(
            StartIdx,
            EndIdx,
            real0,
            real1);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}
