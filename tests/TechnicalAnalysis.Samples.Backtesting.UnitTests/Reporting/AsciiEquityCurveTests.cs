// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Reporting;

public class AsciiEquityCurveTests
{
    private static List<EquityPoint> Curve(params double[] equity)
    {
        List<EquityPoint> points = new(equity.Length);
        for (int i = 0; i < equity.Length; i++)
        {
            points.Add(new EquityPoint(i, TestBars.Origin.AddDays(i), equity[i], 0.0, 0.0, equity[i]));
        }

        return points;
    }

    [Fact]
    public void TheChartHasTheRequestedShape()
    {
        // Arrange
        IReadOnlyList<EquityPoint> curve = Curve(100, 105, 103, 110, 108, 120);

        // Act
        string chart = AsciiEquityCurve.Render(curve, width: 40, height: 8);

        // Assert - eight plot rows, one axis row and one date row.
        string[] lines = chart.Split(Environment.NewLine);
        lines.Length.ShouldBe(10);
        lines.Take(8).ShouldAllBe(line => line.Contains('|', StringComparison.Ordinal));
        lines[8].ShouldContain("+---");
    }

    [Fact]
    public void TheCurveIsNormalisedSoTheInitialCapitalReadsAsOneHundred()
    {
        // Arrange - the account doubles.
        IReadOnlyList<EquityPoint> curve = Curve(50_000, 75_000, 100_000);

        // Act
        string chart = AsciiEquityCurve.Render(curve, width: 20, height: 6);

        // Assert - the axis labels are the normalised extremes, not the raw currency amounts.
        chart.ShouldContain("200.0");
        chart.ShouldContain("100.0");
        chart.ShouldNotContain("50,000");
    }

    [Fact]
    public void RisingAndFallingSegmentsArePlottedInTheRightOrder()
    {
        // Arrange - a strictly rising curve must end higher on the canvas than it starts.
        IReadOnlyList<EquityPoint> curve = Curve(100, 110, 120, 130, 140, 150, 160, 170);

        // Act
        string chart = AsciiEquityCurve.Render(curve, width: 8, height: 8);
        string[] plotRows = [.. chart.Split(Environment.NewLine).Take(8)];

        // Assert - row 0 is the top of the chart, so the first plot must sit lower down than the last one.
        int firstColumnRow = Array.FindIndex(plotRows, row => row[^8] == '*');
        int lastColumnRow = Array.FindIndex(plotRows, row => row[^1] == '*');
        lastColumnRow.ShouldBeLessThan(firstColumnRow);
    }

    [Fact]
    public void AFlatCurveDoesNotDivideByZero()
    {
        // Arrange
        IReadOnlyList<EquityPoint> curve = Curve(100, 100, 100, 100);

        // Act
        string chart = AsciiEquityCurve.Render(curve, width: 20, height: 6);

        // Assert
        chart.ShouldContain('*');
        chart.ShouldNotContain("NaN");
        chart.Split(Environment.NewLine).Length.ShouldBe(8);
    }

    [Fact]
    public void ASinglePointCurveRenders()
    {
        // Arrange
        IReadOnlyList<EquityPoint> curve = Curve(100);

        // Act
        string chart = AsciiEquityCurve.Render(curve, width: 10, height: 4);

        // Assert
        chart.ShouldContain('*');
    }

    [Fact]
    public void AnEmptyCurveRendersAPlaceholder()
    {
        // Arrange / Act
        string chart = AsciiEquityCurve.Render([]);

        // Assert
        chart.ShouldContain("no equity curve");
    }

    [Fact]
    public void TheAxisCarriesTheFirstAndLastDates()
    {
        // Arrange
        IReadOnlyList<EquityPoint> curve = Curve(100, 110, 120, 130);

        // Act
        string chart = AsciiEquityCurve.Render(curve, width: 40, height: 6);

        // Assert
        chart.ShouldContain(TestBars.Origin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        chart.ShouldContain(TestBars.Origin.AddDays(3).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
    }

    [Theory]
    [InlineData(1, 10)]
    [InlineData(10, 1)]
    public void AnUnusableCanvasSizeIsRejected(int width, int height)
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => AsciiEquityCurve.Render(Curve(100, 110), width, height));
    }
}
