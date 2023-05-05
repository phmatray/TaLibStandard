// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleStickSandwich;

namespace TechnicalAnalysis.Candles.UnitTests.Cdl;

public class CdlStickSandwichTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlStickSandwichFloatingPoint(Type floatingPointType)
    {
        // Arrange
        MethodInfo? genericMethod = GetType().GetMethod(
            nameof(CdlStickSandwich), BindingFlags.NonPublic | BindingFlags.Static);
        MethodInfo method = genericMethod!.MakeGenericMethod(floatingPointType);
        CandleStickSandwichResult? result = (CandleStickSandwichResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }
    
    private static CandleStickSandwichResult CdlStickSandwich<T>()
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
        CandleStickSandwichResult actualResult = TACandle.CdlStickSandwich(
            StartIdx,
            EndIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}