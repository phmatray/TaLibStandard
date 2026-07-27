// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Metrics;

/// <summary>
/// Every formula is checked against a fixture small enough to be computed by hand in the comments.
/// </summary>
/// <remarks>
/// <para>
/// The reference equity curve is <c>[100, 110, 99, 108.9]</c> (four bars, three returns):
/// </para>
/// <code>
/// r        = [+0.10, -0.10, +0.10]
/// mean(r)  = 0.10 / 3                          = 0.0333333...
/// var(r)   = ((0.0666667)^2 + (-0.1333333)^2 + (0.0666667)^2) / 2 = 0.01333333...
/// stdev(r) = sqrt(0.0133333...)                = 0.115470053837925
/// downside = sqrt((0 + 0.01 + 0) / 3)          = 0.057735026918963
/// maxDD    = (110 - 99) / 110                  = 0.10
/// ddBars   = peak at bar 1, still under water at bar 3 -> 3 - 1 = 2
/// </code>
/// <para>
/// Annualisation constant: 252 bars per year, so the scale factor is <c>sqrt(252) = 15.874507866...</c>
/// and the horizon is <c>(4 - 1) / 252</c> years. A tolerance of <c>1e-9</c> is used throughout: the
/// quantities are O(1)–O(10), so that is roughly seven orders of magnitude above double rounding noise while
/// still catching any real formula change.
/// </para>
/// </remarks>
public class PerformanceMetricsTests
{
    private const double Tolerance = 1e-9;
    private const int BarsPerYear = 252;

    private static readonly double[] s_referenceEquity = [100.0, 110.0, 99.0, 108.9];

    private static List<EquityPoint> Curve(double[] equity, bool inPosition = true)
    {
        List<EquityPoint> points = new(equity.Length);
        for (int i = 0; i < equity.Length; i++)
        {
            points.Add(new EquityPoint(i, TestBars.Origin.AddDays(i), equity[i], 0.0, inPosition ? 1.0 : 0.0, equity[i]));
        }

        return points;
    }

    private static PerformanceMetrics Reference()
    {
        return PerformanceMetrics.Compute(Curve(s_referenceEquity), [], 100.0, BarsPerYear);
    }

    [Fact]
    public void TotalReturnIsFinalOverInitialMinusOne()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert - 108.9 / 100 - 1 = 0.089
        metrics.FinalEquity.ShouldBe(108.9, Tolerance);
        metrics.TotalReturn.ShouldBe(0.089, Tolerance);
    }

    [Fact]
    public void CagrCompoundsOverBarIntervalsNotOverEquityPoints()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert - four points span three bar intervals, so years = 3 / 252.
        double years = 3.0 / BarsPerYear;
        double expected = Math.Pow(1.089, 1.0 / years) - 1.0;

        metrics.Cagr.ShouldBe(expected, Tolerance);
        metrics.BarsPerYear.ShouldBe(BarsPerYear);
    }

    [Fact]
    public void AnnualisedVolatilityIsTheSampleStandardDeviationScaledBySqrtBarsPerYear()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert - stdev = sqrt(0.04 / 3) = 0.2 / sqrt(3), so the annualised figure is
        // (0.2 / sqrt(3)) * sqrt(252) = 0.2 * sqrt(84) = 1.83303027798...
        double sampleStdDev = 0.2 / Math.Sqrt(3.0);
        metrics.AnnualizedVolatility.ShouldBe(sampleStdDev * Math.Sqrt(BarsPerYear), Tolerance);
        metrics.AnnualizedVolatility.ShouldBe(0.2 * Math.Sqrt(84.0), Tolerance);
    }

    [Fact]
    public void MaxDrawdownIsThePeakToTroughDeclineAndItsDurationIsMeasuredInBars()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert - the peak is 110 at bar 1, the trough 99 at bar 2, and 108.9 never regains 110.
        metrics.PeakEquity.ShouldBe(110.0, Tolerance);
        metrics.MaxDrawdown.ShouldBe(11.0 / 110.0, Tolerance);
        metrics.MaxDrawdown.ShouldBe(0.10, Tolerance);
        metrics.MaxDrawdownDurationBars.ShouldBe(2);
    }

    [Fact]
    public void MaxDrawdownDurationCountsTheRecoveryBar()
    {
        // Arrange - 100, 110, 99, 110: the peak is set at bar 1 and regained at bar 3. The documented measure
        // runs from the peak bar to the first later bar that reaches it again, so the answer is 3 - 1 = 2.
        // Measuring only while under water would stop at bar 2 and report 1 for every recovered drawdown.
        double[] equity = [100.0, 110.0, 99.0, 110.0];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(equity), [], 100.0, BarsPerYear);

        // Assert
        metrics.MaxDrawdownDurationBars.ShouldBe(2);
        metrics.MaxDrawdown.ShouldBe(11.0 / 110.0, Tolerance);
    }

    [Fact]
    public void AMonotonicallyRisingCurveHasNoDrawdownDuration()
    {
        // Arrange - a curve that only ever sets new peaks. Counting the length on the recovery branch must
        // not mistake "reached a new high" for "recovered from a drawdown".
        double[] equity = [100.0, 110.0, 120.0, 130.0];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(equity), [], 100.0, BarsPerYear);

        // Assert
        metrics.MaxDrawdown.ShouldBe(0.0);
        metrics.MaxDrawdownDurationBars.ShouldBe(0);
    }

    [Fact]
    public void SharpeIsTheMeanReturnOverItsStandardDeviationAnnualised()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert - mean / stdev = (0.1 / 3) / (0.2 / sqrt(3)) = sqrt(3) / 6, and
        // (sqrt(3) / 6) * sqrt(252) = sqrt(84) / 2 = 4.58257569495584.
        const double Mean = 0.1 / 3.0;
        double sampleStdDev = 0.2 / Math.Sqrt(3.0);
        metrics.Sharpe.ShouldBe(Mean / sampleStdDev * Math.Sqrt(BarsPerYear), Tolerance);
        metrics.Sharpe.ShouldBe(Math.Sqrt(84.0) / 2.0, Tolerance);
    }

    [Fact]
    public void SortinoDividesByTheDownsideDeviationTakenOverAllReturns()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert - downside = sqrt((0 + 0.01 + 0) / 3) = 0.0577350269, exactly half the sample stdev here,
        // so Sortino must be exactly twice Sharpe for this fixture.
        const double Mean = 0.1 / 3.0;
        double downside = Math.Sqrt(0.01 / 3.0);

        metrics.Sortino.ShouldBe(Mean / downside * Math.Sqrt(BarsPerYear), Tolerance);
        metrics.Sortino.ShouldBe(2.0 * metrics.Sharpe, 1e-9);
    }

    [Fact]
    public void CalmarIsCagrOverMaxDrawdown()
    {
        // Arrange / Act
        PerformanceMetrics metrics = Reference();

        // Assert
        metrics.Calmar.ShouldBe(metrics.Cagr / 0.10, Tolerance);
    }

    [Fact]
    public void ARiskFreeRateIsDeAnnualisedGeometricallyBeforeBeingSubtracted()
    {
        // Arrange - 4% a year over 252 bars.
        const double AnnualRate = 0.04;

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(s_referenceEquity), [], 100.0, BarsPerYear, AnnualRate);

        // Assert
        double perBar = Math.Pow(1.0 + AnnualRate, 1.0 / BarsPerYear) - 1.0;
        const double Mean = 0.1 / 3.0;
        double sampleStdDev = 0.2 / Math.Sqrt(3.0);

        metrics.RiskFreeRate.ShouldBe(AnnualRate);
        metrics.Sharpe.ShouldBe((Mean - perBar) / sampleStdDev * Math.Sqrt(BarsPerYear), Tolerance);
        metrics.Sharpe.ShouldBeLessThan(Math.Sqrt(84.0) / 2.0);
    }

    [Fact]
    public void ExposureCountsTheBarsWithAnOpenPosition()
    {
        // Arrange - flat on bars 0 and 3, in the market on bars 1 and 2.
        List<EquityPoint> points =
        [
            new(0, TestBars.Origin, 100.0, 100.0, 0.0, 100.0),
            new(1, TestBars.Origin.AddDays(1), 110.0, 0.0, 1.0, 110.0),
            new(2, TestBars.Origin.AddDays(2), 99.0, 0.0, 1.0, 99.0),
            new(3, TestBars.Origin.AddDays(3), 108.9, 108.9, 0.0, 108.9)
        ];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(points, [], 100.0, BarsPerYear);

        // Assert
        metrics.Exposure.ShouldBe(0.5, Tolerance);
        metrics.BarCount.ShouldBe(4);
    }

    [Fact]
    public void TradeStatisticsAreComputedFromNetProfitAfterCommission()
    {
        // Arrange - four long round trips of 10 units: +200, -100, +100, -50 net.
        IReadOnlyList<Trade> trades =
        [
            LongTrade(entry: 100, exit: 120, quantity: 10),
            LongTrade(entry: 100, exit: 90, quantity: 10),
            LongTrade(entry: 100, exit: 110, quantity: 10),
            LongTrade(entry: 100, exit: 95, quantity: 10)
        ];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(s_referenceEquity), trades, 100.0, BarsPerYear);

        // Assert - gross profit 300, gross loss 150.
        metrics.TradeCount.ShouldBe(4);
        metrics.WinCount.ShouldBe(2);
        metrics.LossCount.ShouldBe(2);
        metrics.WinRate.ShouldBe(0.5, Tolerance);
        metrics.ProfitFactor.ShouldBe(2.0, Tolerance);
        metrics.AverageWin.ShouldBe(150.0, Tolerance);
        metrics.AverageLoss.ShouldBe(-75.0, Tolerance);
        metrics.Expectancy.ShouldBe(37.5, Tolerance);

        // The textbook expectancy identity holds when no trade is exactly break-even.
        double textbook = (metrics.WinRate * metrics.AverageWin) + ((1.0 - metrics.WinRate) * metrics.AverageLoss);
        metrics.Expectancy.ShouldBe(textbook, Tolerance);
    }

    [Fact]
    public void CommissionIsSubtractedBeforeATradeIsClassified()
    {
        // Arrange - a 10-point gain on 10 units is +100 gross but -20 net after 120 of commission.
        IReadOnlyList<Trade> trades = [LongTrade(entry: 100, exit: 110, quantity: 10, commission: 120)];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(s_referenceEquity), trades, 100.0, BarsPerYear);

        // Assert
        trades[0].GrossProfit.ShouldBe(100.0, Tolerance);
        trades[0].NetProfit.ShouldBe(-20.0, Tolerance);
        metrics.WinCount.ShouldBe(0);
        metrics.LossCount.ShouldBe(1);
        metrics.WinRate.ShouldBe(0.0);
        metrics.ProfitFactor.ShouldBe(0.0);
        metrics.Expectancy.ShouldBe(-20.0, Tolerance);
    }

    [Fact]
    public void ProfitFactorIsInfiniteWhenThereAreWinsAndNoLosses()
    {
        // Arrange
        IReadOnlyList<Trade> trades = [LongTrade(entry: 100, exit: 110, quantity: 10)];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(s_referenceEquity), trades, 100.0, BarsPerYear);

        // Assert - documented convention: wins and no losses reads as an infinite profit factor.
        metrics.ProfitFactor.ShouldBe(double.PositiveInfinity);
        metrics.WinRate.ShouldBe(1.0);
        double.IsNaN(metrics.ProfitFactor).ShouldBeFalse();
    }

    [Fact]
    public void AnAllLosingSeriesProducesDefinedNegativeStatistics()
    {
        // Arrange - three losing round trips and a monotonically falling curve.
        IReadOnlyList<Trade> trades =
        [
            LongTrade(entry: 100, exit: 90, quantity: 10),
            LongTrade(entry: 100, exit: 80, quantity: 10),
            LongTrade(entry: 100, exit: 70, quantity: 10)
        ];

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve([100.0, 90.0, 80.0, 70.0]), trades, 100.0, BarsPerYear);

        // Assert
        metrics.WinCount.ShouldBe(0);
        metrics.LossCount.ShouldBe(3);
        metrics.WinRate.ShouldBe(0.0);
        metrics.ProfitFactor.ShouldBe(0.0);
        metrics.AverageWin.ShouldBe(0.0);
        metrics.AverageLoss.ShouldBe(-200.0, Tolerance);
        metrics.Expectancy.ShouldBe(-200.0, Tolerance);
        metrics.TotalReturn.ShouldBe(-0.30, Tolerance);
        metrics.Cagr.ShouldBeLessThan(0.0);
        metrics.Sharpe.ShouldBeLessThan(0.0);
        metrics.MaxDrawdown.ShouldBe(0.30, Tolerance);
        AssertNoNaN(metrics);
    }

    [Fact]
    public void NoTradesProducesZeroesRatherThanNaN()
    {
        // Arrange / Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve(s_referenceEquity), [], 100.0, BarsPerYear);

        // Assert
        metrics.TradeCount.ShouldBe(0);
        metrics.WinRate.ShouldBe(0.0);
        metrics.ProfitFactor.ShouldBe(0.0);
        metrics.AverageWin.ShouldBe(0.0);
        metrics.AverageLoss.ShouldBe(0.0);
        metrics.Expectancy.ShouldBe(0.0);
        AssertNoNaN(metrics);
    }

    [Fact]
    public void AFlatCurveHasZeroVolatilityAndZeroRatiosRatherThanNaN()
    {
        // Arrange - constant equity: every return is zero, so both denominators vanish.
        IReadOnlyList<EquityPoint> curve = Curve([100.0, 100.0, 100.0, 100.0, 100.0]);

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(curve, [], 100.0, BarsPerYear);

        // Assert
        metrics.AnnualizedVolatility.ShouldBe(0.0);
        metrics.Sharpe.ShouldBe(0.0);
        metrics.Sortino.ShouldBe(0.0);
        metrics.Calmar.ShouldBe(0.0);
        metrics.MaxDrawdown.ShouldBe(0.0);
        metrics.MaxDrawdownDurationBars.ShouldBe(0);
        metrics.Cagr.ShouldBe(0.0, Tolerance);
        AssertNoNaN(metrics);
    }

    [Fact]
    public void ASingleEquityPointHasNoReturnsAndNoElapsedTime()
    {
        // Arrange / Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(Curve([100.0]), [], 100.0, BarsPerYear);

        // Assert
        metrics.BarCount.ShouldBe(1);
        metrics.TotalReturn.ShouldBe(0.0, Tolerance);
        metrics.Cagr.ShouldBe(0.0);
        metrics.AnnualizedVolatility.ShouldBe(0.0);
        metrics.Sharpe.ShouldBe(0.0);
        AssertNoNaN(metrics);
    }

    [Fact]
    public void AnEmptyCurveFallsBackToTheInitialCapital()
    {
        // Arrange / Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute([], [], 100.0, BarsPerYear);

        // Assert
        metrics.BarCount.ShouldBe(0);
        metrics.FinalEquity.ShouldBe(100.0);
        metrics.PeakEquity.ShouldBe(100.0);
        metrics.TotalReturn.ShouldBe(0.0);
        AssertNoNaN(metrics);
    }

    [Fact]
    public void AWipedOutAccountReportsATotalLossInsteadOfPoisoningEveryStatistic()
    {
        // Arrange - equity reaches exactly zero, which would make the next percentage return undefined.
        IReadOnlyList<EquityPoint> curve = Curve([100.0, 50.0, 0.0, 0.0]);

        // Act
        PerformanceMetrics metrics = PerformanceMetrics.Compute(curve, [], 100.0, BarsPerYear);

        // Assert
        metrics.TotalReturn.ShouldBe(-1.0, Tolerance);
        metrics.Cagr.ShouldBe(-1.0);
        metrics.MaxDrawdown.ShouldBe(1.0, Tolerance);
        AssertNoNaN(metrics);
    }

    [Fact]
    public void ChangingBarsPerYearRescalesOnlyTheAnnualisedFigures()
    {
        // Arrange
        PerformanceMetrics daily = PerformanceMetrics.Compute(Curve(s_referenceEquity), [], 100.0, 252);
        PerformanceMetrics monthly = PerformanceMetrics.Compute(Curve(s_referenceEquity), [], 100.0, 12);

        // Act
        double ratio = Math.Sqrt(252.0 / 12.0);

        // Assert - the per-bar statistics are identical; only the annualisation differs.
        daily.TotalReturn.ShouldBe(monthly.TotalReturn, Tolerance);
        daily.MaxDrawdown.ShouldBe(monthly.MaxDrawdown, Tolerance);
        daily.AnnualizedVolatility.ShouldBe(monthly.AnnualizedVolatility * ratio, Tolerance);
        daily.Sharpe.ShouldBe(monthly.Sharpe * ratio, Tolerance);
    }

    [Fact]
    public void ComputeRejectsAnImpossibleConfiguration()
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(() => PerformanceMetrics.Compute([], [], 0.0, 252));
        Should.Throw<ArgumentOutOfRangeException>(() => PerformanceMetrics.Compute([], [], 100.0, 0));
        Should.Throw<ArgumentNullException>(() => PerformanceMetrics.Compute(null!, [], 100.0, 252));
    }

    private static Trade LongTrade(double entry, double exit, double quantity, double commission = 0.0)
    {
        return new Trade(
            OrderSide.Buy,
            quantity,
            0,
            TestBars.Origin,
            entry,
            1,
            TestBars.Origin.AddDays(1),
            exit,
            commission);
    }

    private static void AssertNoNaN(PerformanceMetrics metrics)
    {
        double.IsNaN(metrics.TotalReturn).ShouldBeFalse(nameof(metrics.TotalReturn));
        double.IsNaN(metrics.Cagr).ShouldBeFalse(nameof(metrics.Cagr));
        double.IsNaN(metrics.AnnualizedVolatility).ShouldBeFalse(nameof(metrics.AnnualizedVolatility));
        double.IsNaN(metrics.MaxDrawdown).ShouldBeFalse(nameof(metrics.MaxDrawdown));
        double.IsNaN(metrics.Sharpe).ShouldBeFalse(nameof(metrics.Sharpe));
        double.IsNaN(metrics.Sortino).ShouldBeFalse(nameof(metrics.Sortino));
        double.IsNaN(metrics.Calmar).ShouldBeFalse(nameof(metrics.Calmar));
        double.IsNaN(metrics.WinRate).ShouldBeFalse(nameof(metrics.WinRate));
        double.IsNaN(metrics.ProfitFactor).ShouldBeFalse(nameof(metrics.ProfitFactor));
        double.IsNaN(metrics.AverageWin).ShouldBeFalse(nameof(metrics.AverageWin));
        double.IsNaN(metrics.AverageLoss).ShouldBeFalse(nameof(metrics.AverageLoss));
        double.IsNaN(metrics.Expectancy).ShouldBeFalse(nameof(metrics.Expectancy));
        double.IsNaN(metrics.Exposure).ShouldBeFalse(nameof(metrics.Exposure));
    }
}
