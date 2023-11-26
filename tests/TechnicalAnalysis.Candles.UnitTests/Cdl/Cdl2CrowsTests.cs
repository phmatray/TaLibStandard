// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class Cdl2CrowsTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], CandleIndicatorResult> SUT { get; }
        = TACandle.Cdl2Crows;

    [Fact]
    public void GetPatternRecognitionPatternDetected()
    {
        // Arrange
        float[] open = [100f, 135f, 130f];
        float[] close = [120f, 125f, 110f];
        Candle2Crows<float> crows = new(open, null!, null!, close);
        
        // Act
        bool isPatternDetected = crows.GetPatternRecognition(2);

        // Assert
        isPatternDetected.Should().BeTrue();
    }

    [Fact]
    public void GetPatternRecognitionPatternDetectedFull()
    {
        // Arrange
        const int ArraySize = 15;
        const int StartIdx = ArraySize - 3;
        const int EndIdx = ArraySize - 1;
        float[] open = InitializeArray(ArraySize, 100f, 135f, 130f);
        float[] close = InitializeArray(ArraySize, 120f, 125f, 110f);
        float[] high = InitializeArray(ArraySize, 120f, 135f, 130f);
        float[] low = InitializeArray(ArraySize, 100f, 125f, 110f);
        
        // Act
        CandleIndicatorResult result = TACandle.Cdl2Crows(
            StartIdx, EndIdx, open, high, low, close);

        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
        result.Integers.Length.Should().Be(3);
        result.Integers[0].Should().Be(0);
        result.Integers[1].Should().Be(0);
        result.Integers[2].Should().Be(-100);
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
        CandleIndicatorResult result = TACandle.Cdl2Crows(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
    }
}
