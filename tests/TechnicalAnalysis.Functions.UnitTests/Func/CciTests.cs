// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class CciTests
{
    [Fact]
    public void CciDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
            
        // Act
        CciResult actualResult = TAMath.Cci(
            StartIdx,
            EndIdx,
            high,
            low,
            close);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void CciFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        float[] close = [.. fixture.CreateMany<float>(100)];
            
        // Act
        CciResult actualResult = TAMath.Cci(
            StartIdx,
            EndIdx,
            high,
            low,
            close);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
}
