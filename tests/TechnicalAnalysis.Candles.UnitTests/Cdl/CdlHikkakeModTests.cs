// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleHikkakeMod;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlHikkakeModTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], IndicatorBase> SUT { get; }
        = TACandle.CdlHikkakeMod;

    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlHikkakeModFloatingPoint(Type floatingPointType)
    {
        InvokeGeneric(nameof(CdlHikkakeMod), floatingPointType);
    }
    
    private static void CdlHikkakeMod<T>()
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
        CandleHikkakeModResult result = TACandle.CdlHikkakeMod(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
    }
}
