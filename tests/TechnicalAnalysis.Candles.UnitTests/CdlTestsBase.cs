// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.UnitTests;

public abstract class CdlTestsBase
{
    protected abstract Func<int, int, float[], float[], float[], float[], CandleIndicatorResult> SUT { get; }

    protected void InvokeGeneric(string methodName, Type floatingPointType)
    {
        GetType()
            .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)?
            .MakeGenericMethod(floatingPointType)
            .Invoke(this, null);
    }
    
    protected static float[] InitializeArray(int length, params float[] values)
    {
        int zeros = length - values.Length;
        return
        [
            .. Enumerable
                        .Range(0, zeros)
                        .Select(_ => 0f)
,
            .. values,
        ];
    }
    
    [Theory]
    [InlineData("Open")]
    [InlineData("High")]
    [InlineData("Low")]
    [InlineData("Close")]
    public void NullPriceArray(string nullArray)
    {
        // Arrange
        float[]? open = nullArray == "Open" ? null : [];
        float[]? high = nullArray == "High" ? null : [];
        float[]? low = nullArray == "Low" ? null : [];
        float[]? close = nullArray == "Close" ? null :[];

        // Act
        Action act = () => SUT(0, 0, open, high, low, close);
        
        // Assert
        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage($"Value cannot be null. (Parameter '{nullArray}')");
    }

    [Fact]
    public void StartIdxGreaterThanEndIdx()
    {
        // Arrange
        Fixture fixture = new();
        float[] open = [.. fixture.CreateMany<float>(100)];
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        float[] close = [.. fixture.CreateMany<float>(100)];
    
        // Act
        Action act = () => SUT(10, 5, open, high, low, close);
    
        // Assert
        act.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("*endIdx - startIdx ('-5') must be a non-negative value.*");
    }
    
    [Fact]
    public void StartIdxLessThanZero()
    {
        // Arrange
        Fixture fixture = new();
        float[] open = [.. fixture.CreateMany<float>(100)];
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        float[] close = [.. fixture.CreateMany<float>(100)];

        // Act
        Action act = () => SUT(-1, 0, open, high, low, close);

        // Assert
        act.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("*startIdx ('-1') must be a non-negative value.*");
    }

    [Fact]
    public void InsufficientInitialData()
    {
        // Arrange
        Fixture fixture = new();
        float[] open = [.. fixture.CreateMany<float>(100)];
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        float[] close = [.. fixture.CreateMany<float>(100)];

        // Act
        IndicatorResult result = SUT(0, 0, open, high, low, close);

        // Assert
        result.RetCode.Should().Be(RetCode.Success);
    }
}
