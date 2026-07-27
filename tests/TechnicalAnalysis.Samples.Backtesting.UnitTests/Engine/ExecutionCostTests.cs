// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

/// <summary>
/// Checks the fill and cost model of a single, fully hand-computable round trip.
/// </summary>
/// <remarks>
/// The fixture is three bars. A long signal is emitted on bar 0, filled at the open of bar 1 (<c>100</c>),
/// and the engine liquidates at the close of bar 2 (<c>110</c>). With capital <c>C</c>, slippage <c>s</c> and
/// commission <c>c</c> the closed-form final equity is
/// <code>
/// entry fill  = 100 * (1 + s)
/// quantity    = C / (entry fill * (1 + c))     -> the cash leg, commission included, consumes exactly C
/// exit fill   = 110 * (1 - s)
/// final       = quantity * exit fill * (1 - c)
///             = C * (110 * (1 - s) * (1 - c)) / (100 * (1 + s) * (1 + c))
/// </code>
/// </remarks>
public class ExecutionCostTests
{
    private const double Capital = 100_000.0;

    private static readonly IReadOnlyList<Bar> s_threeBars =
        TestBars.FromOpenClose([(99, 99.5), (100, 105), (105, 110)]);

    private static BacktestResult RunRoundTrip(double commissionBps, double slippageBps)
    {
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = commissionBps,
            SlippageBps = slippageBps,
            PositionFraction = 1.0
        };

        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal> { [0] = Signal.EnterLong });
        return new BacktestEngine(options).Run(strategy, s_threeBars);
    }

    [Fact]
    public void WithoutFrictionsTheRoundTripEarnsExactlyTheUnderlyingMove()
    {
        // Arrange / Act - buy at 100, sell at 110, no costs: the account must grow by exactly 10%.
        BacktestResult result = RunRoundTrip(commissionBps: 0, slippageBps: 0);

        // Assert
        result.Trades.Count.ShouldBe(1);
        result.Trades[0].EntryPrice.ShouldBe(100.0, 1e-12);
        result.Trades[0].ExitPrice.ShouldBe(110.0, 1e-12);
        result.Trades[0].Quantity.ShouldBe(1_000.0, 1e-9);
        result.Trades[0].Commission.ShouldBe(0.0, 1e-12);
        result.Trades[0].NetProfit.ShouldBe(10_000.0, 1e-9);
        result.FinalEquity.ShouldBe(110_000.0, 1e-9);
        result.Metrics.TotalReturn.ShouldBe(0.10, 1e-12);
    }

    [Fact]
    public void SlippageAloneMovesBothFillsAgainstTheAccountByTheExactAmount()
    {
        // Arrange - 25 bp of slippage, no commission.
        const double SlippageRate = 25.0 / 10_000.0;

        // Act
        BacktestResult result = RunRoundTrip(commissionBps: 0, slippageBps: 25);

        // Assert
        double expectedEntry = 100.0 * (1.0 + SlippageRate);
        double expectedExit = 110.0 * (1.0 - SlippageRate);
        double expectedFinal = Capital * expectedExit / expectedEntry;

        result.Trades[0].EntryPrice.ShouldBe(expectedEntry, 1e-12);
        result.Trades[0].ExitPrice.ShouldBe(expectedExit, 1e-12);
        result.Trades[0].Commission.ShouldBe(0.0, 1e-12);
        result.FinalEquity.ShouldBe(expectedFinal, 1e-8);

        // 25 bp on each of the two fills costs the account 2s / (1 + s) of its frictionless result,
        // which is just under the 50 bp a naive "two times 25 bp" estimate would suggest.
        const double FrictionlessFinal = 110_000.0;
        double drag = 1.0 - (result.FinalEquity / FrictionlessFinal);
        drag.ShouldBe(2.0 * SlippageRate / (1.0 + SlippageRate), 1e-12);
        drag.ShouldBeLessThan(2.0 * SlippageRate);
    }

    [Fact]
    public void CommissionAloneIsChargedOnBothFillsAtTheFilledNotional()
    {
        // Arrange - 30 bp of commission, no slippage.
        const double CommissionRate = 30.0 / 10_000.0;

        // Act
        BacktestResult result = RunRoundTrip(commissionBps: 30, slippageBps: 0);

        // Assert
        double expectedQuantity = Capital / (100.0 * (1.0 + CommissionRate));
        double expectedCommission = (expectedQuantity * 100.0 * CommissionRate) + (expectedQuantity * 110.0 * CommissionRate);
        double expectedFinal = expectedQuantity * 110.0 * (1.0 - CommissionRate);

        result.Trades[0].Quantity.ShouldBe(expectedQuantity, 1e-9);
        result.Trades[0].Commission.ShouldBe(expectedCommission, 1e-8);
        result.Trades[0].GrossProfit.ShouldBe(expectedQuantity * 10.0, 1e-8);
        result.Trades[0].NetProfit.ShouldBe((expectedQuantity * 10.0) - expectedCommission, 1e-8);
        result.FinalEquity.ShouldBe(expectedFinal, 1e-8);
    }

    [Fact]
    public void CommissionAndSlippageTogetherMatchTheClosedFormFinalEquity()
    {
        // Arrange
        const double CommissionRate = 20.0 / 10_000.0;
        const double SlippageRate = 10.0 / 10_000.0;

        // Act
        BacktestResult result = RunRoundTrip(commissionBps: 20, slippageBps: 10);

        // Assert
        double entryFill = 100.0 * (1.0 + SlippageRate);
        double exitFill = 110.0 * (1.0 - SlippageRate);
        double quantity = Capital / (entryFill * (1.0 + CommissionRate));
        double expectedFinal = quantity * exitFill * (1.0 - CommissionRate);

        result.FinalEquity.ShouldBe(expectedFinal, 1e-8);
        result.FinalEquity.ShouldBe(
            Capital * (110.0 * (1.0 - SlippageRate) * (1.0 - CommissionRate)) / (100.0 * (1.0 + SlippageRate) * (1.0 + CommissionRate)),
            1e-8);

        // And it is strictly worse than the frictionless run.
        result.FinalEquity.ShouldBeLessThan(110_000.0);
    }

    [Fact]
    public void CashNeverGoesNegativeWhenFullyInvested()
    {
        // Arrange - sizing consumes the whole account, commission included.
        BacktestResult result = RunRoundTrip(commissionBps: 50, slippageBps: 25);

        // Assert
        result.EquityCurve[1].Cash.ShouldBe(0.0, 1e-8);
        result.EquityCurve.ShouldAllBe(point => point.Cash >= -1e-8);
    }

    [Fact]
    public void AShortRoundTripEarnsTheInverseMoveAndPaysTheSameCosts()
    {
        // Arrange - price rises from 100 to 110, so a short must lose about 10%.
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = 0,
            SlippageBps = 0,
            AllowShort = true
        };

        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal> { [0] = Signal.EnterShort });

        // Act
        BacktestResult result = new BacktestEngine(options).Run(strategy, s_threeBars);

        // Assert
        result.Trades.Count.ShouldBe(1);
        result.Trades[0].Side.ShouldBe(OrderSide.Sell);
        result.Trades[0].Quantity.ShouldBe(1_000.0, 1e-9);
        result.Trades[0].GrossProfit.ShouldBe(-10_000.0, 1e-9);
        result.FinalEquity.ShouldBe(90_000.0, 1e-9);
    }

    [Fact]
    public void AShortSignalIsDowngradedToFlatWhenShortingIsDisabled()
    {
        // Arrange
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = 0,
            SlippageBps = 0,
            AllowShort = false
        };

        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal>
        {
            [0] = Signal.EnterLong,
            [1] = Signal.EnterShort
        });

        // Act
        BacktestResult result = new BacktestEngine(options).Run(strategy, s_threeBars);

        // Assert - the long is closed at the open of bar 2 and the account stays flat, never short.
        result.Trades.Count.ShouldBe(1);
        result.Trades[0].Side.ShouldBe(OrderSide.Buy);
        result.Trades[0].ExitIndex.ShouldBe(2);
        result.EquityCurve.ShouldAllBe(point => point.SignedQuantity >= 0.0);
    }

    [Fact]
    public void FixedCashSizingCommitsTheConfiguredNotionalOnly()
    {
        // Arrange
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = 0,
            SlippageBps = 0,
            Sizing = PositionSizing.FixedCash,
            PositionCash = 25_000.0
        };

        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal> { [0] = Signal.EnterLong });

        // Act
        BacktestResult result = new BacktestEngine(options).Run(strategy, s_threeBars);

        // Assert - 25 000 / 100 = 250 units, so the 10-point move earns 2 500.
        result.Trades[0].Quantity.ShouldBe(250.0, 1e-9);
        result.FinalEquity.ShouldBe(102_500.0, 1e-9);
        result.EquityCurve[1].Cash.ShouldBe(75_000.0, 1e-9);
    }

    [Fact]
    public void ReversingFromLongToShortClosesAndReopensAtTheSameFill()
    {
        // Arrange
        IReadOnlyList<Bar> bars = TestBars.FromOpenClose([(100, 100), (100, 100), (120, 120), (120, 120)]);
        BacktestOptions options = new()
        {
            InitialCapital = Capital,
            CommissionBps = 0,
            SlippageBps = 0,
            AllowShort = true
        };

        ScriptedStrategy strategy = ScriptedStrategy.At(new Dictionary<int, Signal>
        {
            [0] = Signal.EnterLong,
            [1] = Signal.EnterShort
        });

        // Act
        BacktestResult result = new BacktestEngine(options).Run(strategy, bars);

        // Assert - the long is closed at 120 on bar 2 and the short opens at 120 on the same bar.
        result.Trades.Count.ShouldBe(2);
        result.Trades[0].Side.ShouldBe(OrderSide.Buy);
        result.Trades[0].ExitIndex.ShouldBe(2);
        result.Trades[0].ExitPrice.ShouldBe(120.0, 1e-12);
        result.Trades[1].Side.ShouldBe(OrderSide.Sell);
        result.Trades[1].EntryIndex.ShouldBe(2);
        result.Trades[1].EntryPrice.ShouldBe(120.0, 1e-12);
    }

    [Fact]
    public void RepeatingTheSameEntrySignalDoesNotChurnThePosition()
    {
        // Arrange
        BacktestOptions options = new() { InitialCapital = Capital, CommissionBps = 50, SlippageBps = 25 };
        ScriptedStrategy strategy = new((_, _) => Signal.EnterLong);

        // Act
        BacktestResult result = new BacktestEngine(options).Run(strategy, s_threeBars);

        // Assert - one entry on bar 1 and one liquidation at the end, not one round trip per bar.
        result.Trades.Count.ShouldBe(1);
        result.Trades[0].EntryIndex.ShouldBe(1);
        result.Trades[0].ExitIndex.ShouldBe(2);
    }
}
