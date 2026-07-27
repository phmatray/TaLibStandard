// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Engine;

public class BacktestOptionsTests
{
    [Fact]
    public void BasisPointsAreConvertedToDecimalRates()
    {
        // Arrange
        BacktestOptions options = new() { CommissionBps = 12.5, SlippageBps = 3.0 };

        // Act / Assert - 1 bp = 0.01% = 0.0001.
        options.CommissionRate.ShouldBe(0.00125, 1e-15);
        options.SlippageRate.ShouldBe(0.0003, 1e-15);
    }

    [Fact]
    public void TheDefaultsAreValid()
    {
        // Arrange
        BacktestOptions options = new();

        // Act / Assert
        Should.NotThrow(options.Validate);
        options.InitialCapital.ShouldBe(100_000.0);
        options.BarsPerYear.ShouldBe(252);
        options.CloseOpenPositionAtEnd.ShouldBeTrue();
        options.Sizing.ShouldBe(PositionSizing.FixedFraction);
    }

    [Theory]
    [InlineData(0.0, 5.0, 2.0, 1.0, 252)]
    [InlineData(-1.0, 5.0, 2.0, 1.0, 252)]
    [InlineData(100.0, -1.0, 2.0, 1.0, 252)]
    [InlineData(100.0, 5.0, -1.0, 1.0, 252)]
    [InlineData(100.0, 5.0, 20_000.0, 1.0, 252)]
    [InlineData(100.0, 5.0, 2.0, 0.0, 252)]
    [InlineData(100.0, 5.0, 2.0, 1.5, 252)]
    [InlineData(100.0, 5.0, 2.0, 1.0, 0)]
    [InlineData(double.NaN, 5.0, 2.0, 1.0, 252)]
    public void AnImpossibleConfigurationIsRejected(
        double capital,
        double commissionBps,
        double slippageBps,
        double fraction,
        int barsPerYear)
    {
        // Arrange
        BacktestOptions options = new()
        {
            InitialCapital = capital,
            CommissionBps = commissionBps,
            SlippageBps = slippageBps,
            PositionFraction = fraction,
            BarsPerYear = barsPerYear
        };

        // Act / Assert
        Should.Throw<ArgumentException>(options.Validate);
    }

    [Fact]
    public void TheEngineValidatesItsOptionsOnConstruction()
    {
        // Arrange
        BacktestOptions options = new() { InitialCapital = -1.0 };

        // Act / Assert
        Should.Throw<ArgumentException>(() => new BacktestEngine(options));
        Should.Throw<ArgumentNullException>(() => new BacktestEngine(null!));
    }

    [Fact]
    public void TheEngineRejectsNullArguments()
    {
        // Arrange
        BacktestEngine engine = new();

        // Act / Assert
        Should.Throw<ArgumentNullException>(() => engine.Run(null!, []));
        Should.Throw<ArgumentNullException>(() => engine.Run(new BuyAndHoldStrategy(), null!));
    }

    [Fact]
    public void SlippageAtOrAboveOneHundredPercentIsRejectedBecauseASellWouldFillAtZero()
    {
        // Arrange
        BacktestOptions options = new() { SlippageBps = 10_000.0 };

        // Act
        ArgumentException exception = Should.Throw<ArgumentException>(options.Validate);

        // Assert
        exception.Message.ShouldContain("SlippageBps");
    }
}
