// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Metrics;

/// <summary>
/// The performance statistics of one backtest run.
/// </summary>
/// <remarks>
/// <para>
/// <b>Notation.</b> <c>E(0..n-1)</c> is the equity curve, one point per bar, sampled at the close of each bar
/// after that bar's fills. The per-bar simple returns are
/// <c>r(t) = E(t) / E(t-1) - 1</c> for <c>t = 1..n-1</c>, so there are <c>n - 1</c> of them.
/// </para>
/// <para>
/// <b>Annualisation.</b> Every annualised figure uses the constant <see cref="BarsPerYear"/>, which must
/// match the bar interval of the data (252 for daily equity bars, 365 for daily crypto bars, 52 weekly,
/// 12 monthly). Rates are scaled by <c>BarsPerYear</c> and standard deviations by
/// <c>sqrt(BarsPerYear)</c> — the usual i.i.d. square-root-of-time assumption, which understates risk when
/// returns are autocorrelated. The horizon in years is <c>(n - 1) / BarsPerYear</c>: it counts <em>bar
/// intervals</em>, not equity points.
/// </para>
/// <para>
/// <b>Degenerate inputs.</b> No member ever returns <see cref="double.NaN"/>. An empty or single-point
/// equity curve, a curve with zero volatility, a run with no trades and a run with no winning trades all
/// produce defined values; the individual members document which. The only non-finite value that can be
/// produced is <see cref="double.PositiveInfinity"/> from <see cref="ProfitFactor"/>, which is the
/// conventional reading of "wins and no losses".
/// </para>
/// </remarks>
public sealed record PerformanceMetrics
{
    private PerformanceMetrics()
    {
    }

    /// <summary>
    /// Gets the metrics of a run that never happened: every figure zero. Used for an empty bar series.
    /// </summary>
    public static PerformanceMetrics Empty { get; } = new();

    /// <summary>
    /// Gets the number of equity points, which equals the number of bars simulated.
    /// </summary>
    public int BarCount { get; private init; }

    /// <summary>
    /// Gets the annualisation constant used by every annualised figure in this record: the number of bars
    /// that make up one year.
    /// </summary>
    public int BarsPerYear { get; private init; }

    /// <summary>
    /// Gets the starting equity of the account.
    /// </summary>
    public double InitialCapital { get; private init; }

    /// <summary>
    /// Gets the equity at the close of the last bar.
    /// </summary>
    public double FinalEquity { get; private init; }

    /// <summary>
    /// Gets the total return over the whole run: <c>FinalEquity / InitialCapital - 1</c>.
    /// A value of <c>0.25</c> means the account grew by 25%. Zero when the curve is empty.
    /// </summary>
    public double TotalReturn { get; private init; }

    /// <summary>
    /// Gets the compound annual growth rate:
    /// <c>(FinalEquity / InitialCapital) ^ (1 / years) - 1</c> with <c>years = (BarCount - 1) / BarsPerYear</c>.
    /// Zero when fewer than two bars were simulated (no elapsed time to compound over);
    /// <c>-1</c> (total loss) when the account was wiped out.
    /// </summary>
    public double Cagr { get; private init; }

    /// <summary>
    /// Gets the annualised volatility of the per-bar returns:
    /// <c>stdev(r) * sqrt(BarsPerYear)</c>, where <c>stdev</c> is the <em>sample</em> standard deviation
    /// (Bessel-corrected, divisor <c>n - 2</c> for <c>n - 1</c> returns). Zero when fewer than two returns
    /// exist, and zero for a perfectly flat curve.
    /// </summary>
    public double AnnualizedVolatility { get; private init; }

    /// <summary>
    /// Gets the maximum peak-to-trough decline of the equity curve, as a positive fraction:
    /// <c>max over t of (peak(t) - E(t)) / peak(t)</c> where <c>peak(t) = max(E(0..t))</c>.
    /// A value of <c>0.30</c> means the account was once 30% below its running high. Zero for a curve that
    /// never declines.
    /// </summary>
    public double MaxDrawdown { get; private init; }

    /// <summary>
    /// Gets the length in bars of the longest drawdown: the greatest number of bars between the bar that set
    /// a running peak and the first later bar whose equity reaches that peak again. A drawdown still open on
    /// the last bar is measured up to that last bar. Zero when the curve never declines.
    /// </summary>
    public int MaxDrawdownDurationBars { get; private init; }

    /// <summary>
    /// Gets the annualised Sharpe ratio:
    /// <c>mean(r - rf) / stdev(r) * sqrt(BarsPerYear)</c>, where <c>rf</c> is the per-bar risk-free rate
    /// obtained by de-annualising <see cref="RiskFreeRate"/> geometrically
    /// (<c>(1 + rate) ^ (1 / BarsPerYear) - 1</c>) and <c>stdev</c> is the sample standard deviation of the
    /// raw returns. Zero when volatility is zero or fewer than two returns exist.
    /// </summary>
    public double Sharpe { get; private init; }

    /// <summary>
    /// Gets the annualised Sortino ratio:
    /// <c>mean(r - rf) / downside(r) * sqrt(BarsPerYear)</c>, where the downside deviation is the
    /// root-mean-square of the shortfalls against the risk-free rate, averaged over <em>all</em> returns
    /// rather than only the negative ones:
    /// <c>downside(r) = sqrt( sum over t of min(r(t) - rf, 0)^2 / count(r) )</c>.
    /// Zero when no return falls below the risk-free rate (no downside to divide by).
    /// </summary>
    public double Sortino { get; private init; }

    /// <summary>
    /// Gets the Calmar ratio: <c>Cagr / MaxDrawdown</c>, using the same annualisation as
    /// <see cref="Cagr"/>. Zero when the maximum drawdown is zero.
    /// </summary>
    public double Calmar { get; private init; }

    /// <summary>
    /// Gets the annual risk-free rate that <see cref="Sharpe"/> and <see cref="Sortino"/> were measured
    /// against, as a decimal fraction.
    /// </summary>
    public double RiskFreeRate { get; private init; }

    /// <summary>
    /// Gets the number of completed round trips. A position still open on the last bar is liquidated by the
    /// engine, so it is counted here too.
    /// </summary>
    public int TradeCount { get; private init; }

    /// <summary>
    /// Gets the number of round trips with a strictly positive net profit.
    /// </summary>
    public int WinCount { get; private init; }

    /// <summary>
    /// Gets the number of round trips with a strictly negative net profit. Break-even trades count as
    /// neither a win nor a loss.
    /// </summary>
    public int LossCount { get; private init; }

    /// <summary>
    /// Gets the fraction of round trips that made money: <c>WinCount / TradeCount</c>.
    /// Zero when there were no trades.
    /// </summary>
    public double WinRate { get; private init; }

    /// <summary>
    /// Gets the ratio of gross profit to gross loss:
    /// <c>sum of positive net profits / |sum of negative net profits|</c>, both after commission.
    /// Zero when there were no trades; <see cref="double.PositiveInfinity"/> when there were winning trades
    /// and no losing ones.
    /// </summary>
    public double ProfitFactor { get; private init; }

    /// <summary>
    /// Gets the mean net profit of the winning round trips, in account currency. Zero when there were none.
    /// </summary>
    public double AverageWin { get; private init; }

    /// <summary>
    /// Gets the mean net profit of the losing round trips, in account currency. Reported as a
    /// <em>negative</em> number. Zero when there were none.
    /// </summary>
    public double AverageLoss { get; private init; }

    /// <summary>
    /// Gets the expected net profit per round trip, in account currency:
    /// <c>sum of net profits / TradeCount</c>. This is identical to the textbook
    /// <c>WinRate * AverageWin + (1 - WinRate) * AverageLoss</c> whenever no trade is exactly break-even.
    /// Zero when there were no trades.
    /// </summary>
    public double Expectancy { get; private init; }

    /// <summary>
    /// Gets the fraction of bars on which a position was open at the close:
    /// <c>count(bars with a non-zero position) / BarCount</c>. A value of <c>0.40</c> means the account was
    /// exposed to the market 40% of the time. Zero when the curve is empty.
    /// </summary>
    public double Exposure { get; private init; }

    /// <summary>
    /// Gets the highest equity ever reached during the run. Equals the initial capital when the curve is
    /// empty.
    /// </summary>
    public double PeakEquity { get; private init; }

    /// <summary>
    /// Computes the metrics of a run.
    /// </summary>
    /// <param name="equityCurve">The equity curve, one point per bar. May be empty.</param>
    /// <param name="trades">The completed round trips. May be empty.</param>
    /// <param name="initialCapital">The starting equity. Must be strictly positive.</param>
    /// <param name="barsPerYear">
    /// The annualisation constant: the number of bars in one year. Must be strictly positive.
    /// </param>
    /// <param name="riskFreeRate">
    /// The annual risk-free rate as a decimal fraction, used by Sharpe and Sortino. Defaults to <c>0</c>.
    /// </param>
    /// <returns>The computed metrics, or <see cref="Empty"/> when the equity curve holds no points.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="equityCurve"/> or <paramref name="trades"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="initialCapital"/> or <paramref name="barsPerYear"/> is not strictly positive.
    /// </exception>
    public static PerformanceMetrics Compute(
        IReadOnlyList<EquityPoint> equityCurve,
        IReadOnlyList<Trade> trades,
        double initialCapital,
        int barsPerYear,
        double riskFreeRate = 0.0)
    {
        ArgumentNullException.ThrowIfNull(equityCurve);
        ArgumentNullException.ThrowIfNull(trades);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initialCapital);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(barsPerYear);

        if (equityCurve.Count == 0)
        {
            return Empty with
            {
                BarsPerYear = barsPerYear,
                InitialCapital = initialCapital,
                FinalEquity = initialCapital,
                PeakEquity = initialCapital,
                RiskFreeRate = riskFreeRate
            };
        }

        int barCount = equityCurve.Count;
        double finalEquity = equityCurve[^1].Equity;
        double totalReturn = (finalEquity / initialCapital) - 1.0;

        double[] returns = ComputeReturns(equityCurve);
        DrawdownStatistics drawdown = ComputeDrawdown(equityCurve);
        TradeStatistics tradeStats = ComputeTradeStatistics(trades);

        double riskFreePerBar = Math.Pow(1.0 + riskFreeRate, 1.0 / barsPerYear) - 1.0;
        double meanReturn = Mean(returns);
        double sampleStdDev = SampleStandardDeviation(returns, meanReturn);
        double downsideDeviation = DownsideDeviation(returns, riskFreePerBar);
        double annualizationFactor = Math.Sqrt(barsPerYear);
        double meanExcess = returns.Length > 0 ? meanReturn - riskFreePerBar : 0.0;

        double years = (barCount - 1) / (double)barsPerYear;
        double cagr = ComputeCagr(initialCapital, finalEquity, years);

        int exposedBars = 0;
        foreach (EquityPoint point in equityCurve)
        {
            if (point.IsInPosition)
            {
                exposedBars++;
            }
        }

        return new PerformanceMetrics
        {
            BarCount = barCount,
            BarsPerYear = barsPerYear,
            InitialCapital = initialCapital,
            FinalEquity = finalEquity,
            TotalReturn = totalReturn,
            Cagr = cagr,
            AnnualizedVolatility = sampleStdDev * annualizationFactor,
            MaxDrawdown = drawdown.MaxDrawdown,
            MaxDrawdownDurationBars = drawdown.MaxDurationBars,
            PeakEquity = drawdown.PeakEquity,
            Sharpe = sampleStdDev > 0.0 ? meanExcess / sampleStdDev * annualizationFactor : 0.0,
            Sortino = downsideDeviation > 0.0 ? meanExcess / downsideDeviation * annualizationFactor : 0.0,
            Calmar = drawdown.MaxDrawdown > 0.0 ? cagr / drawdown.MaxDrawdown : 0.0,
            RiskFreeRate = riskFreeRate,
            TradeCount = tradeStats.Count,
            WinCount = tradeStats.Wins,
            LossCount = tradeStats.Losses,
            WinRate = tradeStats.WinRate,
            ProfitFactor = tradeStats.ProfitFactor,
            AverageWin = tradeStats.AverageWin,
            AverageLoss = tradeStats.AverageLoss,
            Expectancy = tradeStats.Expectancy,
            Exposure = (double)exposedBars / barCount
        };
    }

    private static double ComputeCagr(double initialCapital, double finalEquity, double years)
    {
        if (years <= 0.0)
        {
            return 0.0;
        }

        if (finalEquity <= 0.0)
        {
            return -1.0;
        }

        return Math.Pow(finalEquity / initialCapital, 1.0 / years) - 1.0;
    }

    private static double[] ComputeReturns(IReadOnlyList<EquityPoint> equityCurve)
    {
        if (equityCurve.Count < 2)
        {
            return [];
        }

        double[] returns = new double[equityCurve.Count - 1];
        for (int t = 1; t < equityCurve.Count; t++)
        {
            double previous = equityCurve[t - 1].Equity;

            // A wiped-out account has no meaningful percentage return; treat the step as flat rather than
            // letting a division by zero poison every downstream statistic with NaN or infinity.
            returns[t - 1] = previous > 0.0 ? (equityCurve[t].Equity / previous) - 1.0 : 0.0;
        }

        return returns;
    }

    private static DrawdownStatistics ComputeDrawdown(IReadOnlyList<EquityPoint> equityCurve)
    {
        double peak = equityCurve[0].Equity;
        int peakIndex = 0;
        double maxDrawdown = 0.0;
        int maxDuration = 0;
        bool belowPeak = false;

        for (int i = 0; i < equityCurve.Count; i++)
        {
            double equity = equityCurve[i].Equity;

            if (equity >= peak)
            {
                // The recovery bar is part of the drawdown's length: the documented measure runs from the
                // bar that set the peak to the first later bar that reaches it again. Measuring only while
                // still under water would report every recovered drawdown one bar short.
                if (belowPeak)
                {
                    maxDuration = Math.Max(maxDuration, i - peakIndex);
                    belowPeak = false;
                }

                peak = equity;
                peakIndex = i;
                continue;
            }

            belowPeak = true;

            if (peak > 0.0)
            {
                maxDrawdown = Math.Max(maxDrawdown, (peak - equity) / peak);
            }

            // A drawdown still open on the last bar is measured up to that last bar.
            maxDuration = Math.Max(maxDuration, i - peakIndex);
        }

        return new DrawdownStatistics(maxDrawdown, maxDuration, peak);
    }

    private static TradeStatistics ComputeTradeStatistics(IReadOnlyList<Trade> trades)
    {
        if (trades.Count == 0)
        {
            return new TradeStatistics(0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0);
        }

        int wins = 0;
        int losses = 0;
        double grossProfit = 0.0;
        double grossLoss = 0.0;
        double netTotal = 0.0;

        foreach (Trade trade in trades)
        {
            double net = trade.NetProfit;
            netTotal += net;

            if (net > 0.0)
            {
                wins++;
                grossProfit += net;
            }
            else if (net < 0.0)
            {
                losses++;
                grossLoss += -net;
            }
        }

        double profitFactor;
        if (grossLoss > 0.0)
        {
            profitFactor = grossProfit / grossLoss;
        }
        else
        {
            profitFactor = grossProfit > 0.0 ? double.PositiveInfinity : 0.0;
        }

        return new TradeStatistics(
            trades.Count,
            wins,
            losses,
            (double)wins / trades.Count,
            profitFactor,
            wins > 0 ? grossProfit / wins : 0.0,
            losses > 0 ? -grossLoss / losses : 0.0,
            netTotal / trades.Count);
    }

    private static double Mean(double[] values)
    {
        if (values.Length == 0)
        {
            return 0.0;
        }

        double sum = 0.0;
        foreach (double value in values)
        {
            sum += value;
        }

        return sum / values.Length;
    }

    private static double SampleStandardDeviation(double[] values, double mean)
    {
        if (values.Length < 2)
        {
            return 0.0;
        }

        double sumSquares = 0.0;
        foreach (double value in values)
        {
            double deviation = value - mean;
            sumSquares += deviation * deviation;
        }

        return Math.Sqrt(sumSquares / (values.Length - 1));
    }

    private static double DownsideDeviation(double[] values, double minimumAcceptableReturn)
    {
        if (values.Length == 0)
        {
            return 0.0;
        }

        double sumSquares = 0.0;
        foreach (double value in values)
        {
            double shortfall = Math.Min(value - minimumAcceptableReturn, 0.0);
            sumSquares += shortfall * shortfall;
        }

        return Math.Sqrt(sumSquares / values.Length);
    }

    private readonly record struct DrawdownStatistics(double MaxDrawdown, int MaxDurationBars, double PeakEquity);

    private readonly record struct TradeStatistics(
        int Count,
        int Wins,
        int Losses,
        double WinRate,
        double ProfitFactor,
        double AverageWin,
        double AverageLoss,
        double Expectancy);
}
