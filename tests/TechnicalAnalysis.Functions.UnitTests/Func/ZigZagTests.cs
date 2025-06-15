// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class ZigZagTests
{
    [Fact]
    public void ZigZagDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        
        // Act
        ZigZagResult actualResult = TAMath.ZigZag(
            StartIdx,
            EndIdx,
            high,
            low,
            5.0); // 5% deviation

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
    
    [Fact]
    public void ZigZagFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        
        // Act
        ZigZagResult actualResult = TAMath.ZigZag(
            StartIdx,
            EndIdx,
            high,
            low,
            5.0f); // 5% deviation

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
    
    [Fact]
    public void ZigZagWithSpecificPattern()
    {
        // Arrange
        // Create a specific pattern that should trigger zigzag points
        double[] high = new double[20];
        double[] low = new double[20];
        
        // Create an uptrend then downtrend pattern
        for (int i = 0; i < 10; i++)
        {
            high[i] = 100 + i * 2; // Rising highs
            low[i] = 98 + i * 2;   // Rising lows
        }
        
        for (int i = 10; i < 20; i++)
        {
            high[i] = 120 - (i - 10) * 2; // Falling highs
            low[i] = 118 - (i - 10) * 2;  // Falling lows
        }
        
        // Act
        ZigZagResult actualResult = TAMath.ZigZag(
            0,
            19,
            high,
            low,
            5.0); // 5% deviation

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBe(19); // ZigZag starts at index 1, so we get 19 elements instead of 20
        actualResult.BegIdx.ShouldBe(1); // ZigZag has a lookback of 1
        
        // The output should have non-zero values at turning points
        actualResult.Real.ShouldNotBeNull();
        actualResult.Real.Length.ShouldBeGreaterThanOrEqualTo(20);
    }
    
    [Fact]
    public void ZigZagInvalidParameters()
    {
        // Arrange
        Fixture fixture = new();
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        
        // Act & Assert - negative deviation
        ZigZagResult result1 = TAMath.ZigZag(0, 99, high, low, -1.0);
        result1.RetCode.ShouldBe(RetCode.BadParam);
        
        // Act & Assert - deviation > 100%
        ZigZagResult result2 = TAMath.ZigZag(0, 99, high, low, 101.0);
        result2.RetCode.ShouldBe(RetCode.BadParam);
        
        // Act & Assert - null arrays
        ZigZagResult result3 = TAMath.ZigZag(0, 99, null!, low, 5.0);
        result3.RetCode.ShouldBe(RetCode.BadParam);
        
        ZigZagResult result4 = TAMath.ZigZag(0, 99, high, null!, 5.0);
        result4.RetCode.ShouldBe(RetCode.BadParam);
    }
    
    [Fact]
    public void ZigZagLookback()
    {
        // Act
        int lookback = TAFunc.ZigZagLookback(5.0);
        
        // Assert
        lookback.ShouldBe(1);
        
        // Test invalid parameters
        int invalidLookback1 = TAFunc.ZigZagLookback(-1.0);
        invalidLookback1.ShouldBe(-1);
        
        int invalidLookback2 = TAFunc.ZigZagLookback(101.0);
        invalidLookback2.ShouldBe(-1);
    }
}