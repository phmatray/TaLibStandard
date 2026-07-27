// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

public class AtrTests
{
    [Fact]
    public void AtrDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        double[] high = [.. fixture.CreateMany<double>(100)];
        double[] low = [.. fixture.CreateMany<double>(100)];
        double[] close = [.. fixture.CreateMany<double>(100)];
            
        // Act
        AtrResult actualResult = TAMath.Atr(
            StartIdx,
            EndIdx,
            high,
            low,
            close);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }
        
    [Fact]
    public void AtrFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int StartIdx = 0;
        const int EndIdx = 99;
        float[] high = [.. fixture.CreateMany<float>(100)];
        float[] low = [.. fixture.CreateMany<float>(100)];
        float[] close = [.. fixture.CreateMany<float>(100)];
            
        // Act
        AtrResult actualResult = TAMath.Atr(
            StartIdx,
            EndIdx,
            high,
            low,
            close);

        // Assert
        actualResult.ShouldNotBeNull();
        actualResult.RetCode.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void AtrOnConstantTrueRangeEqualsThatTrueRange()
    {
        // Arrange
        // Every bar is identical, so the true range is max(104 - 100, |104 - 102|, |100 - 102|) = 4
        // on every bar. Wilder's average of a constant is that constant, so ATR(14) must read
        // exactly 4.0 for every output element -- the seed is the mean of fourteen 4s, and each
        // later bar is (4 * 13 + 4) / 14 = 4.
        const int StartIdx = 0;
        const int EndIdx = 199;
        const double ExpectedAtr = 4.0;
        double[] high = [.. Enumerable.Repeat(104.0, 200)];
        double[] low = [.. Enumerable.Repeat(100.0, 200)];
        double[] close = [.. Enumerable.Repeat(102.0, 200)];

        // Act
        AtrResult actualResult = TAMath.Atr(StartIdx, EndIdx, high, low, close, 14);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);
        actualResult.NBElement.ShouldBeGreaterThan(100);

        for (int k = 0; k < actualResult.NBElement; k++)
        {
            actualResult.Real[k].ShouldBe(ExpectedAtr, 1e-9, $"ATR drifted at output element {k}.");
        }
    }

    [Fact]
    public void AtrDoesNotDivergeOverALongSeries()
    {
        // Arrange
        // Regression guard for the accumulator that was never normalised: it grew by a factor of
        // (period - 1) every bar, so ATR reached +Infinity a few hundred bars in. A sane ATR here
        // is on the order of the bar range, never astronomically above it.
        const int StartIdx = 0;
        const int EndIdx = 1499;
        double[] high = new double[1500];
        double[] low = new double[1500];
        double[] close = new double[1500];

        for (int i = 0; i < 1500; i++)
        {
            double mid = 100.0 + (Math.Sin(i / 10.0) * 5.0);
            high[i] = mid + 1.0;
            low[i] = mid - 1.0;
            close[i] = mid;
        }

        // Act
        AtrResult actualResult = TAMath.Atr(StartIdx, EndIdx, high, low, close, 14);

        // Assert
        actualResult.RetCode.ShouldBe(RetCode.Success);

        for (int k = 0; k < actualResult.NBElement; k++)
        {
            double atr = actualResult.Real[k];
            double.IsFinite(atr).ShouldBeTrue($"ATR was {atr} at output element {k}.");
            atr.ShouldBeInRange(0.0, 20.0);
        }
    }
}
