// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.UnitTests;

public abstract class CdlTestsBase
{
    protected abstract Func<int, int, float[], float[], float[], float[], IndicatorBase> SUT { get; }

    protected void InvokeGeneric(string methodName, Type floatingPointType)
    {
        GetType()
            .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)?
            .MakeGenericMethod(floatingPointType)
            .Invoke(this, null);
    }
    
    [Fact]
    public void NullPriceArrays()
    {
        // Arrange
        float[] open = null!;
        float[] high = null!;
        float[] low = null!;
        float[] close = null!;

        // Act
        IndicatorBase result = SUT(0, 0, open, high, low, close);

        // Assert
        result.RetCode.Should().Be(RetCode.BadParam);
    }

    [Fact]
    public void StartIdxGreaterThanEndIdx()
    {
        // Arrange
        Fixture fixture = new();
        float[] open = fixture.CreateMany<float>(100).ToArray();
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
        float[] close = fixture.CreateMany<float>(100).ToArray();

        // Act
        IndicatorBase result = SUT(10, 5, open, high, low, close);

        // Assert
        result.RetCode.Should().Be(RetCode.OutOfRangeEndIndex);
    }
    
    [Fact]
    public void StartIdxLessThanZero()
    {
        // Arrange
        Fixture fixture = new();
        float[] open = fixture.CreateMany<float>(100).ToArray();
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
        float[] close = fixture.CreateMany<float>(100).ToArray();

        // Act
        IndicatorBase result = SUT(-1, 0, open, high, low, close);

        // Assert
        result.RetCode.Should().Be(RetCode.OutOfRangeStartIndex);
    }

    [Fact]
    public void InsufficientInitialData()
    {
        // Arrange
        Fixture fixture = new();
        float[] open = fixture.CreateMany<float>(100).ToArray();
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
        float[] close = fixture.CreateMany<float>(100).ToArray();

        // Act
        IndicatorBase result = SUT(0, 0, open, high, low, close);

        // Assert
        result.RetCode.Should().Be(RetCode.Success);
    }
}
