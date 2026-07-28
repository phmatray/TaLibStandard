// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Func;

/// <summary>
/// Pins the directional movement family against the seeding off-by-one.
/// </summary>
/// <remarks>
/// <para>
/// The C reference seeds with <c>while (i-- &gt; 0)</c>, which runs its body <c>i</c> times. The C#
/// transcription was <c>while (true) { i--; if (i &lt;= 0) break; ... }</c>, which runs it <c>i - 1</c>
/// times. One term short, in the same shape as the EMA seed corrected in #105.
/// </para>
/// <para>
/// It surfaced two ways. The undercount left the cursor short of <c>startIdx</c>, so
/// <c>BegIdx + NBElement</c> came back as 102 over a 100-bar series — two values claimed for bars that
/// do not exist, which silently misaligns every consumer that maps an output element onto a bar. And
/// the ADX seed averaged 13 values while dividing by 14, so a series whose DX is a constant 100 read
/// 92.857 and crept towards 100 without arriving.
/// </para>
/// <para>
/// The existing AdxTests, DxTests, PlusDITests and MinusDITests assert only
/// <see cref="RetCode.Success"/>, so none of this was detectable by the suite. These fixtures assert
/// numbers.
/// </para>
/// </remarks>
public class DirectionalMovementRegressionTests
{
    private const int BarCount = 100;
    private const int Period = 14;

    /// <summary>
    /// A perfectly linear uptrend. Every bar gains exactly 2, so +DM is a constant 2 and -DM is zero;
    /// the true range is a constant 2.5 (the gap from the previous close to this high). Wilder's
    /// average of a constant is that constant, so +DI is exactly 100 * 2 / 2.5 = 80, -DI is exactly 0,
    /// DX is exactly 100, and ADX — the smoothed average of a constant 100 — is exactly 100.
    /// </summary>
    private static (double[] High, double[] Low, double[] Close) LinearUptrend()
    {
        double[] high = new double[BarCount];
        double[] low = new double[BarCount];
        double[] close = new double[BarCount];

        for (int i = 0; i < BarCount; i++)
        {
            high[i] = 100.0 + (2.0 * i);
            low[i] = 99.0 + (2.0 * i);
            close[i] = 99.5 + (2.0 * i);
        }

        return (high, low, close);
    }

    /// <summary>The mirror image of <see cref="LinearUptrend"/>: -DI is 80 and +DI is 0.</summary>
    private static (double[] High, double[] Low, double[] Close) LinearDowntrend()
    {
        double[] high = new double[BarCount];
        double[] low = new double[BarCount];
        double[] close = new double[BarCount];

        for (int i = 0; i < BarCount; i++)
        {
            high[i] = 100.0 - (2.0 * i);
            low[i] = 99.0 - (2.0 * i);
            close[i] = 99.5 - (2.0 * i);
        }

        return (high, low, close);
    }

    private static (RetCode RetCode, int BegIdx, int NBElement, double[] Real) Run(
        Func<int, int, double[], double[], double[], int, (RetCode, int, int, double[])> call,
        (double[] High, double[] Low, double[] Close) bars)
    {
        return call(0, BarCount - 1, bars.High, bars.Low, bars.Close, Period);
    }

    private static (RetCode, int, int, double[]) Adx(int s, int e, double[] h, double[] l, double[] c, int p)
    {
        int beg = 0;
        int nb = 0;
        double[] outReal = new double[BarCount];
        RetCode rc = TAFunc.Adx(s, e, h, l, c, p, ref beg, ref nb, ref outReal);
        return (rc, beg, nb, outReal);
    }

    private static (RetCode, int, int, double[]) Dx(int s, int e, double[] h, double[] l, double[] c, int p)
    {
        int beg = 0;
        int nb = 0;
        double[] outReal = new double[BarCount];
        RetCode rc = TAFunc.Dx(s, e, h, l, c, p, ref beg, ref nb, ref outReal);
        return (rc, beg, nb, outReal);
    }

    private static (RetCode, int, int, double[]) PlusDi(int s, int e, double[] h, double[] l, double[] c, int p)
    {
        int beg = 0;
        int nb = 0;
        double[] outReal = new double[BarCount];
        RetCode rc = TAFunc.PlusDI(s, e, h, l, c, p, ref beg, ref nb, ref outReal);
        return (rc, beg, nb, outReal);
    }

    private static (RetCode, int, int, double[]) MinusDi(int s, int e, double[] h, double[] l, double[] c, int p)
    {
        int beg = 0;
        int nb = 0;
        double[] outReal = new double[BarCount];
        RetCode rc = TAFunc.MinusDI(s, e, h, l, c, p, ref beg, ref nb, ref outReal);
        return (rc, beg, nb, outReal);
    }

    [Fact]
    public void OutputNeverClaimsMoreBarsThanTheInputHas()
    {
        // Arrange
        (double[] High, double[] Low, double[] Close) bars = LinearUptrend();

        // Act
        (RetCode _, int adxBeg, int adxNb, double[] _) = Run(Adx, bars);
        (RetCode _, int dxBeg, int dxNb, double[] _) = Run(Dx, bars);
        (RetCode _, int plusBeg, int plusNb, double[] _) = Run(PlusDi, bars);
        (RetCode _, int minusBeg, int minusNb, double[] _) = Run(MinusDi, bars);

        // Assert
        // Computing over the whole series, the last described bar is the last bar, so
        // BegIdx + NBElement is exactly the bar count. The defect reported 102 for all four.
        (adxBeg + adxNb).ShouldBe(BarCount, "Adx claimed values for bars that do not exist.");
        (dxBeg + dxNb).ShouldBe(BarCount, "Dx claimed values for bars that do not exist.");
        (plusBeg + plusNb).ShouldBe(BarCount, "PlusDI claimed values for bars that do not exist.");
        (minusBeg + minusNb).ShouldBe(BarCount, "MinusDI claimed values for bars that do not exist.");
    }

    [Fact]
    public void AdxOnAConstantTrendIsExactlyOneHundredFromItsFirstValue()
    {
        // Arrange
        // DX is a constant 100 on this series, and Wilder's average of a constant is that constant,
        // so every ADX output is exactly 100 — including the first. Seeding one term short produced
        // 100 * 13 / 14 = 92.857 and then crept upward without ever arriving.
        (double[] High, double[] Low, double[] Close) bars = LinearUptrend();

        // Act
        (RetCode retCode, int begIdx, int nbElement, double[] real) = Run(Adx, bars);

        // Assert
        retCode.ShouldBe(RetCode.Success);
        nbElement.ShouldBeGreaterThan(0);
        (begIdx + nbElement).ShouldBe(BarCount);

        real[0].ShouldBe(100.0, 1e-9, "the ADX seed averaged one value too few");

        // Named separately so the failure message points at the historical value rather than just
        // reporting a mismatch: 100 * 13 / 14 is what seeding one term short produced.
        Math.Abs(real[0] - 92.857142857142861).ShouldBeGreaterThan(1e-9);

        for (int k = 0; k < nbElement; k++)
        {
            real[k].ShouldBe(100.0, 1e-9, $"ADX drifted at output element {k}.");
        }
    }

    [Fact]
    public void DirectionalIndicatorsSeparateAPureUptrend()
    {
        // Arrange
        (double[] High, double[] Low, double[] Close) bars = LinearUptrend();

        // Act
        (RetCode plusCode, int _, int plusNb, double[] plus) = Run(PlusDi, bars);
        (RetCode minusCode, int _, int minusNb, double[] minus) = Run(MinusDi, bars);
        (RetCode dxCode, int _, int dxNb, double[] dx) = Run(Dx, bars);

        // Assert
        plusCode.ShouldBe(RetCode.Success);
        minusCode.ShouldBe(RetCode.Success);
        dxCode.ShouldBe(RetCode.Success);

        for (int k = 0; k < plusNb; k++)
        {
            plus[k].ShouldBe(80.0, 1e-9, $"+DI was not 80 at output element {k}.");
        }

        for (int k = 0; k < minusNb; k++)
        {
            minus[k].ShouldBe(0.0, 1e-9, $"-DI was not 0 at output element {k}.");
        }

        for (int k = 0; k < dxNb; k++)
        {
            dx[k].ShouldBe(100.0, 1e-9, $"DX was not 100 at output element {k}.");
        }
    }

    [Fact]
    public void DirectionalIndicatorsSeparateAPureDowntrend()
    {
        // Arrange
        // The mirror of the uptrend: the roles of +DI and -DI swap and nothing else changes.
        (double[] High, double[] Low, double[] Close) bars = LinearDowntrend();

        // Act
        (RetCode _, int _, int plusNb, double[] plus) = Run(PlusDi, bars);
        (RetCode _, int _, int minusNb, double[] minus) = Run(MinusDi, bars);

        // Assert
        for (int k = 0; k < plusNb; k++)
        {
            plus[k].ShouldBe(0.0, 1e-9, $"+DI was not 0 at output element {k}.");
        }

        for (int k = 0; k < minusNb; k++)
        {
            minus[k].ShouldBe(80.0, 1e-9, $"-DI was not 80 at output element {k}.");
        }
    }
}
