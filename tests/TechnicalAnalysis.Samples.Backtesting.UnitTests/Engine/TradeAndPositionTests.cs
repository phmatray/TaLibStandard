// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

public class TradeAndPositionTests
{
    [Fact]
    public void ALongTradeProfitsFromARisingExit()
    {
        // Arrange - 10 units bought at 100 and sold at 112, with 5 of total commission.
        Trade trade = new(OrderSide.Buy, 10.0, 0, TestBars.Origin, 100.0, 5, TestBars.Origin.AddDays(5), 112.0, 5.0);

        // Act / Assert
        trade.IsLong.ShouldBeTrue();
        trade.GrossProfit.ShouldBe(120.0, 1e-12);
        trade.NetProfit.ShouldBe(115.0, 1e-12);
        trade.ReturnOnNotional.ShouldBe(115.0 / 1_000.0, 1e-12);
        trade.BarsHeld.ShouldBe(5);
        trade.IsWin.ShouldBeTrue();
        trade.IsLoss.ShouldBeFalse();
    }

    [Fact]
    public void AShortTradeProfitsFromAFallingExit()
    {
        // Arrange - 10 units sold at 100 and bought back at 88.
        Trade trade = new(OrderSide.Sell, 10.0, 0, TestBars.Origin, 100.0, 3, TestBars.Origin.AddDays(3), 88.0, 5.0);

        // Act / Assert
        trade.IsLong.ShouldBeFalse();
        trade.GrossProfit.ShouldBe(120.0, 1e-12);
        trade.NetProfit.ShouldBe(115.0, 1e-12);
        trade.IsWin.ShouldBeTrue();
    }

    [Fact]
    public void ABreakEvenTradeIsNeitherAWinNorALoss()
    {
        // Arrange - the whole gross profit is eaten by commission.
        Trade trade = new(OrderSide.Buy, 10.0, 0, TestBars.Origin, 100.0, 1, TestBars.Origin.AddDays(1), 110.0, 100.0);

        // Act / Assert
        trade.NetProfit.ShouldBe(0.0, 1e-12);
        trade.IsWin.ShouldBeFalse();
        trade.IsLoss.ShouldBeFalse();
    }

    [Fact]
    public void AZeroNotionalTradeReportsAZeroReturnRatherThanNaN()
    {
        // Arrange
        Trade trade = new(OrderSide.Buy, 0.0, 0, TestBars.Origin, 100.0, 1, TestBars.Origin.AddDays(1), 110.0, 0.0);

        // Act / Assert
        trade.ReturnOnNotional.ShouldBe(0.0);
    }

    [Fact]
    public void ALongPositionHasPositiveSignedQuantity()
    {
        // Arrange
        Position position = new(OrderSide.Buy, 25.0, 40.0, 3, TestBars.Origin, 1.0);

        // Act / Assert
        position.IsLong.ShouldBeTrue();
        position.IsShort.ShouldBeFalse();
        position.SignedQuantity.ShouldBe(25.0);
        position.MarketValue(50.0).ShouldBe(1_250.0, 1e-12);
        position.UnrealizedProfit(50.0).ShouldBe(250.0, 1e-12);
    }

    [Fact]
    public void AShortPositionHasNegativeSignedQuantityAndInvertedProfit()
    {
        // Arrange
        Position position = new(OrderSide.Sell, 25.0, 40.0, 3, TestBars.Origin, 1.0);

        // Act / Assert
        position.IsShort.ShouldBeTrue();
        position.SignedQuantity.ShouldBe(-25.0);
        position.MarketValue(50.0).ShouldBe(-1_250.0, 1e-12);
        position.UnrealizedProfit(50.0).ShouldBe(-250.0, 1e-12);
        position.UnrealizedProfit(30.0).ShouldBe(250.0, 1e-12);
    }

    [Fact]
    public void AnEquityPointKnowsWhetherItWasExposed()
    {
        // Arrange
        EquityPoint flat = new(0, TestBars.Origin, 100.0, 1_000.0, 0.0, 1_000.0);
        EquityPoint longPoint = new(1, TestBars.Origin.AddDays(1), 100.0, 0.0, 10.0, 1_000.0);
        EquityPoint shortPoint = new(2, TestBars.Origin.AddDays(2), 100.0, 2_000.0, -10.0, 1_000.0);

        // Act / Assert
        flat.IsInPosition.ShouldBeFalse();
        longPoint.IsInPosition.ShouldBeTrue();
        shortPoint.IsInPosition.ShouldBeTrue();
    }

    [Theory]
    [InlineData(100, 105, 95, 102, 1000, true)]
    [InlineData(100, 99, 95, 98, 1000, false)]
    [InlineData(100, 105, 101, 102, 1000, false)]
    [InlineData(100, 105, 95, 102, -1, false)]
    [InlineData(-100, 105, 95, 102, 1000, false)]
    [InlineData(100, double.NaN, 95, 102, 1000, false)]
    public void ABarKnowsWhetherItIsInternallyConsistent(
        double open,
        double high,
        double low,
        double close,
        double volume,
        bool expected)
    {
        // Arrange
        Bar bar = new(TestBars.Origin, open, high, low, close, volume);

        // Act / Assert
        bar.IsWellFormed().ShouldBe(expected);
    }

    [Fact]
    public void ABarExposesItsTypicalPriceAndRange()
    {
        // Arrange
        Bar bar = new(TestBars.Origin, 100.0, 110.0, 90.0, 104.0, 1_000.0);

        // Act / Assert
        bar.TypicalPrice.ShouldBe((110.0 + 90.0 + 104.0) / 3.0, 1e-12);
        bar.Range.ShouldBe(20.0, 1e-12);
    }
}
