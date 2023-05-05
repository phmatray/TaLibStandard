// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleOnNeck;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlOnNeckTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlOnNeckFloatingPoint(Type floatingPointType)
    {
        // Arrange
        MethodInfo? genericMethod = GetType().GetMethod(
            nameof(CdlOnNeck), BindingFlags.NonPublic | BindingFlags.Static);
        MethodInfo method = genericMethod!.MakeGenericMethod(floatingPointType);
        CandleOnNeckResult? result = (CandleOnNeckResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }
    
    private static CandleOnNeckResult CdlOnNeck<T>()
        where T : IFloatingPoint<T>
    {
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        T[] open = fixture.CreateMany<T>(100).ToArray();
        T[] high = fixture.CreateMany<T>(100).ToArray();
        T[] low = fixture.CreateMany<T>(100).ToArray();
        T[] close = fixture.CreateMany<T>(100).ToArray();
            
        // Act
        CandleOnNeckResult actualResult = TACandle.CdlOnNeck(
            StartIdx,
            EndIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}
