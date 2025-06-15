// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlShortLineTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], CandleIndicatorResult> SUT { get; }
        = TACandle.CdlShortLine;

    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlShortLineFloatingPoint(Type floatingPointType)
    {
        InvokeGeneric(nameof(CdlShortLine), floatingPointType);
    }
    
    private static void CdlShortLine<T>()
        where T : IFloatingPoint<T>
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        T[] open = [.. fixture.CreateMany<T>(100)];
        T[] high = [.. fixture.CreateMany<T>(100)];
        T[] low = [.. fixture.CreateMany<T>(100)];
        T[] close = [.. fixture.CreateMany<T>(100)];
            
        // Act
        CandleIndicatorResult result = TACandle.CdlShortLine(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.ShouldNotBeNull();
        result.RetCode.ShouldBe(RetCode.Success);
    }
}
