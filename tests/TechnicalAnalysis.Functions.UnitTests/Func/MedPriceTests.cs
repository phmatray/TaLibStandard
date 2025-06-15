// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class MedPriceTests
{
    [Fact]
    public void MedPriceDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
            
        // Act
        MedPriceResult actualResult = TAMath.MedPrice(
            StartIdx,
            EndIdx,
            high,
            low);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void MedPriceFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
            
        // Act
        MedPriceResult actualResult = TAMath.MedPrice(
            StartIdx,
            EndIdx,
            high,
            low);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
}
