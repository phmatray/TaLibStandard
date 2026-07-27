// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// Everything that describes the simulated market and account: starting capital, trading frictions, position
/// sizing policy and the annualisation constant used by the performance metrics.
/// </summary>
public sealed record BacktestOptions
{
    /// <summary>
    /// Gets the cash balance the account starts with, in account currency. Defaults to <c>100 000</c>.
    /// </summary>
    public double InitialCapital { get; init; } = 100_000.0;

    /// <summary>
    /// Gets the commission charged on every fill, in basis points of the traded notional
    /// (1 bp = 0.01% = 0.0001). A round trip therefore pays it twice. Defaults to <c>5</c> bp.
    /// </summary>
    public double CommissionBps { get; init; } = 5.0;

    /// <summary>
    /// Gets the slippage applied to every fill, in basis points of the quoted price
    /// (1 bp = 0.01% = 0.0001). Buys fill at <c>price * (1 + SlippageBps / 10000)</c> and sells at
    /// <c>price * (1 - SlippageBps / 10000)</c>, so slippage always works against the account.
    /// Defaults to <c>2</c> bp.
    /// </summary>
    public double SlippageBps { get; init; } = 2.0;

    /// <summary>
    /// Gets the policy used to turn a signal into a quantity. Defaults to
    /// <see cref="PositionSizing.FixedFraction"/>.
    /// </summary>
    public PositionSizing Sizing { get; init; } = PositionSizing.FixedFraction;

    /// <summary>
    /// Gets the fraction of current account equity committed to each new position when
    /// <see cref="Sizing"/> is <see cref="PositionSizing.FixedFraction"/>. Must lie in <c>(0, 1]</c>.
    /// Defaults to <c>1.0</c> (fully invested, no leverage).
    /// </summary>
    public double PositionFraction { get; init; } = 1.0;

    /// <summary>
    /// Gets the cash notional committed to each new position when <see cref="Sizing"/> is
    /// <see cref="PositionSizing.FixedCash"/>. It is capped by the current account equity, so the account
    /// can never take on leverage. Defaults to <c>10 000</c>.
    /// </summary>
    public double PositionCash { get; init; } = 10_000.0;

    /// <summary>
    /// Gets a value indicating whether short positions are permitted. When <see langword="false"/> the engine
    /// downgrades <see cref="Signal.EnterShort"/> to <see cref="Signal.Exit"/>, so a strategy designed to
    /// reverse simply goes flat. Defaults to <see langword="false"/>.
    /// </summary>
    public bool AllowShort { get; init; }

    /// <summary>
    /// Gets a value indicating whether a position still open on the last bar is liquidated at that bar's
    /// close, so that the trade list is complete and the final equity is fully realised. Defaults to
    /// <see langword="true"/>.
    /// </summary>
    public bool CloseOpenPositionAtEnd { get; init; } = true;

    /// <summary>
    /// Gets the number of bars in one year. This is the annualisation constant used by every annualised
    /// metric — CAGR, volatility, Sharpe, Sortino and Calmar — and it must match the bar interval of the
    /// data: <c>252</c> for daily bars on an equity calendar, <c>365</c> for daily crypto bars,
    /// <c>52</c> for weekly, <c>12</c> for monthly, <c>98 280</c> for one-minute equity bars.
    /// Defaults to <c>252</c>.
    /// </summary>
    public int BarsPerYear { get; init; } = 252;

    /// <summary>
    /// Gets the annual risk-free rate used as the benchmark in the Sharpe and Sortino ratios, expressed as a
    /// decimal fraction (<c>0.04</c> is 4% a year). It is de-annualised geometrically to a per-bar rate:
    /// <c>(1 + rate) ^ (1 / BarsPerYear) - 1</c>. Defaults to <c>0</c>.
    /// </summary>
    public double RiskFreeRate { get; init; }

    /// <summary>
    /// Gets the commission expressed as a decimal fraction of notional, that is <c>CommissionBps / 10000</c>.
    /// </summary>
    public double CommissionRate => CommissionBps / 10_000.0;

    /// <summary>
    /// Gets the slippage expressed as a decimal fraction of price, that is <c>SlippageBps / 10000</c>.
    /// </summary>
    public double SlippageRate => SlippageBps / 10_000.0;

    /// <summary>
    /// Throws when the option set is not usable for a simulation.
    /// </summary>
    /// <exception cref="ArgumentException">A value is out of range or not finite.</exception>
    public void Validate()
    {
        Require(double.IsFinite(InitialCapital) && InitialCapital > 0.0, nameof(InitialCapital), "must be finite and strictly positive.");
        Require(double.IsFinite(CommissionBps) && CommissionBps >= 0.0, nameof(CommissionBps), "must be finite and non-negative.");
        Require(double.IsFinite(SlippageBps) && SlippageBps >= 0.0, nameof(SlippageBps), "must be finite and non-negative.");
        Require(SlippageRate < 1.0, nameof(SlippageBps), "must be below 10000 bp, otherwise a sell would fill at or below zero.");
        Require(double.IsFinite(PositionFraction) && PositionFraction is > 0.0 and <= 1.0, nameof(PositionFraction), "must lie in (0, 1].");
        Require(double.IsFinite(PositionCash) && PositionCash > 0.0, nameof(PositionCash), "must be finite and strictly positive.");
        Require(BarsPerYear > 0, nameof(BarsPerYear), "must be strictly positive.");
        Require(double.IsFinite(RiskFreeRate) && RiskFreeRate > -1.0, nameof(RiskFreeRate), "must be finite and greater than -1.");
    }

    private static void Require(bool condition, string name, string requirement)
    {
        if (!condition)
        {
            throw new ArgumentException(
                string.Format(CultureInfo.InvariantCulture, "BacktestOptions.{0} {1}", name, requirement));
        }
    }
}
