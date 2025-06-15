// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class MfiTests
{
    [Fact]
    public void MfiDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
        double[] volume = [.. fixture.CreateMany<double>(100)];
            
        // Act
        MfiResult actualResult = TAMath.Mfi(
            StartIdx,
            EndIdx,
            high,
            low,
            close,
            volume);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void MfiFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        float[] close = [.. fixture.CreateMany<float>(100)];
        float[] volume = [.. fixture.CreateMany<float>(100)];
            
        // Act
        MfiResult actualResult = TAMath.Mfi(
            StartIdx,
            EndIdx,
            high,
            low,
            close,
            volume);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}
