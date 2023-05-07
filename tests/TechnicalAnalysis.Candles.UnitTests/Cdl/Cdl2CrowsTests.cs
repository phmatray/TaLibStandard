// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.Candle2Crows;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class Cdl2CrowsTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], Candle2CrowsResult> SUT { get; }
        = TACandle.Cdl2Crows;

    [Fact]
    public void GetPatternRecognitionPatternDetected()
    {
        // Arrange
        float[] open = { 100f, 135f, 130f };
        float[] close = { 120f, 125f, 110f };
        Candle2Crows<float> crows = new(open, null!, null!, close);
        
        // Act
        bool isPatternDetected = crows.GetPatternRecognition(2);

        // Assert
        isPatternDetected.Should().BeTrue();
    }

    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void Cdl2CrowsFloatingPoint(Type floatingPointType)
    {
        InvokeGeneric(nameof(Cdl2Crows), floatingPointType);
    }

    private static void Cdl2Crows<T>()
        where T : IFloatingPoint<T>
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        T[] open = fixture.CreateMany<T>(100).ToArray();
        T[] high = fixture.CreateMany<T>(100).ToArray();
        T[] low = fixture.CreateMany<T>(100).ToArray();
        T[] close = fixture.CreateMany<T>(100).ToArray();
            
        // Act
        Candle2CrowsResult result = TACandle.Cdl2Crows(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
    }
}
