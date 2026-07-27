// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests;

public class CommandLineOptionsTests
{
    [Fact]
    public void AnEmptyCommandLineYieldsTheDocumentedDefaults()
    {
        // Arrange / Act
        CommandLineOptions options = CommandLineOptions.Parse([]);

        // Assert
        options.ShowHelp.ShouldBeFalse();
        options.CsvPath.ShouldBeNull();
        options.BarCount.ShouldBe(1_500);
        options.Seed.ShouldBe(SyntheticSeriesGenerator.DefaultSeed);
        options.ShowTradeLog.ShouldBeFalse();
        options.Backtest.InitialCapital.ShouldBe(100_000.0);
        options.Backtest.CommissionBps.ShouldBe(5.0);
        options.Backtest.SlippageBps.ShouldBe(2.0);
        options.Backtest.BarsPerYear.ShouldBe(252);
        options.Backtest.AllowShort.ShouldBeFalse();
    }

    [Fact]
    public void EveryOptionIsParsedWithTheInvariantCulture()
    {
        // Arrange
        string[] args =
        [
            "--csv", "/tmp/prices.csv",
            "--bars", "3000",
            "--seed", "-17",
            "--capital", "250000.5",
            "--commission-bps", "12.5",
            "--slippage-bps", "0.75",
            "--bars-per-year", "365",
            "--allow-short",
            "--trade-log"
        ];

        // Act
        CommandLineOptions options = CommandLineOptions.Parse(args);

        // Assert
        options.CsvPath.ShouldBe("/tmp/prices.csv");
        options.BarCount.ShouldBe(3_000);
        options.Seed.ShouldBe(-17);
        options.ShowTradeLog.ShouldBeTrue();
        options.Backtest.InitialCapital.ShouldBe(250_000.5);
        options.Backtest.CommissionBps.ShouldBe(12.5);
        options.Backtest.SlippageBps.ShouldBe(0.75);
        options.Backtest.BarsPerYear.ShouldBe(365);
        options.Backtest.AllowShort.ShouldBeTrue();
    }

    [Theory]
    [InlineData("-h")]
    [InlineData("--help")]
    public void HelpShortCircuitsTheRestOfTheCommandLine(string flag)
    {
        // Arrange / Act - the trailing garbage must not be reported, because help wins.
        CommandLineOptions options = CommandLineOptions.Parse([flag, "--nonsense"]);

        // Assert
        options.ShowHelp.ShouldBeTrue();
    }

    [Fact]
    public void TheUsageTextDocumentsEveryOption()
    {
        // Arrange / Act
        string usage = CommandLineOptions.Usage;

        // Assert
        usage.ShouldContain("--csv");
        usage.ShouldContain("--capital");
        usage.ShouldContain("--commission-bps");
        usage.ShouldContain("--slippage-bps");
        usage.ShouldContain("--seed");
        usage.ShouldContain("--bars");
        usage.ShouldContain("--allow-short");
        usage.ShouldContain("--help");
    }

    [Fact]
    public void AnUnknownOptionIsRejected()
    {
        // Arrange / Act
        FormatException exception = Should.Throw<FormatException>(() => CommandLineOptions.Parse(["--turbo"]));

        // Assert
        exception.Message.ShouldContain("--turbo");
    }

    [Fact]
    public void AnOptionMissingItsValueIsRejected()
    {
        // Arrange / Act
        FormatException exception = Should.Throw<FormatException>(() => CommandLineOptions.Parse(["--capital"]));

        // Assert
        exception.Message.ShouldContain("requires a value");
    }

    [Theory]
    [InlineData("--bars", "not-a-number")]
    [InlineData("--capital", "lots")]
    [InlineData("--bars-per-year", "3.5")]
    public void AnUnparsableValueIsRejected(string option, string value)
    {
        // Arrange / Act / Assert
        Should.Throw<FormatException>(() => CommandLineOptions.Parse([option, value]));
    }

    [Theory]
    [InlineData("--bars", "0")]
    [InlineData("--bars-per-year", "0")]
    public void AValueBelowItsMinimumIsRejected(string option, string value)
    {
        // Arrange / Act
        FormatException exception = Should.Throw<FormatException>(() => CommandLineOptions.Parse([option, value]));

        // Assert
        exception.Message.ShouldContain("at least");
    }

    [Theory]
    [InlineData("--capital", "0")]
    [InlineData("--capital", "-1000")]
    [InlineData("--commission-bps", "-1")]
    [InlineData("--slippage-bps", "-1")]
    public void AnOutOfRangeBacktestSettingIsRejectedByValidation(string option, string value)
    {
        // Arrange / Act
        FormatException exception = Should.Throw<FormatException>(() => CommandLineOptions.Parse([option, value]));

        // Assert
        exception.Message.ShouldContain("BacktestOptions");
    }

    [Fact]
    public void ParseRejectsANullCommandLine()
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentNullException>(() => CommandLineOptions.Parse(null!));
    }
}
