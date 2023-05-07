// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleEngulfing;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlEngulfingTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], IndicatorBase> SUT { get; }
        = TACandle.CdlEngulfing;

    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlEngulfingFloatingPoint(Type floatingPointType)
    {
        InvokeGeneric(nameof(CdlEngulfing), floatingPointType);
    }
    
    private static void CdlEngulfing<T>()
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
        CandleEngulfingResult result = TACandle.CdlEngulfing(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
    }
}
