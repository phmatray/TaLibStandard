// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleBeltHold;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlBeltHoldTests : CdlTestsBase
{
    protected override Func<int, int, float[], float[], float[], float[], IndicatorBase> SUT { get; }
        = TACandle.CdlBeltHold;

    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlBeltHoldFloatingPoint(Type floatingPointType)
    {
        InvokeGeneric(nameof(CdlBeltHold), floatingPointType);
    }
    
    private static void CdlBeltHold<T>()
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
        CandleBeltHoldResult result = TACandle.CdlBeltHold(
            StartIdx, EndIdx, open, high, low, close);
        
        // Assert
        result.Should().NotBeNull();
        result.RetCode.Should().Be(RetCode.Success);
    }
}
