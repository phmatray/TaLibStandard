// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleUnique3River;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlUnique3RiverTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], IndicatorBase> SUT { get; }
        = TACandle.CdlUnique3River;

    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlUnique3RiverFloatingPoint(Type floatingPointType)
    {
        InvokeGeneric(nameof(CdlUnique3River), floatingPointType);
    }

    private static void CdlUnique3River<T>()
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
        CandleUnique3RiverResult result = TACandle.CdlUnique3River(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
    }
}
