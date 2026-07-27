// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Data;

public class CsvBarLoaderTests
{
    private static IReadOnlyList<Bar> Load(string csv)
    {
        using StringReader reader = new(csv);
        return CsvBarLoader.Load(reader);
    }

    [Fact]
    public void TheDocumentedHeaderLayoutLoadsExactly()
    {
        // Arrange
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            2024-01-02,100.5,102.25,99.75,101.0,1500000
            2024-01-03,101.0,103.5,100.5,103.25,1750000
            """;

        // Act
        IReadOnlyList<Bar> bars = Load(Csv);

        // Assert
        bars.Count.ShouldBe(2);
        bars[0].Timestamp.ShouldBe(new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc));
        bars[0].Open.ShouldBe(100.5);
        bars[0].High.ShouldBe(102.25);
        bars[0].Low.ShouldBe(99.75);
        bars[0].Close.ShouldBe(101.0);
        bars[0].Volume.ShouldBe(1_500_000.0);
        bars[1].Close.ShouldBe(103.25);
        bars.ShouldAllBe(bar => bar.IsWellFormed());
    }

    [Fact]
    public void ColumnOrderDoesNotMatterAndExtraColumnsAreIgnored()
    {
        // Arrange - a typical broker export: shuffled columns plus an adjusted close.
        const string Csv = """
            Close,Adj Close,High,Timestamp,Low,Volume,Open
            101.0,100.9,102.0,2024-01-02,99.0,1000,100.0
            """;

        // Act
        IReadOnlyList<Bar> bars = Load(Csv);

        // Assert
        bars.Count.ShouldBe(1);
        bars[0].Open.ShouldBe(100.0);
        bars[0].High.ShouldBe(102.0);
        bars[0].Low.ShouldBe(99.0);
        bars[0].Close.ShouldBe(101.0);
        bars[0].Volume.ShouldBe(1_000.0);
    }

    [Fact]
    public void BlankLinesAndQuotedFieldsAreTolerated()
    {
        // Arrange
        const string Csv = """
            "Date","Open","High","Low","Close","Volume"

            "2024-01-02","100.0","101.0","99.0","100.5","1000"

            "2024-01-03","100.5","101.5","100.0","101.0","1100"
            """;

        // Act
        IReadOnlyList<Bar> bars = Load(Csv);

        // Assert
        bars.Count.ShouldBe(2);
        bars[1].Close.ShouldBe(101.0);
    }

    [Fact]
    public void AMissingVolumeColumnDefaultsToZero()
    {
        // Arrange
        const string Csv = """
            Date,Open,High,Low,Close
            2024-01-02,100.0,101.0,99.0,100.5
            """;

        // Act
        IReadOnlyList<Bar> bars = Load(Csv);

        // Assert
        bars[0].Volume.ShouldBe(0.0);
        bars[0].IsWellFormed().ShouldBeTrue();
    }

    [Fact]
    public void AMissingPriceColumnIsRejected()
    {
        // Arrange
        const string Csv = """
            Date,Open,High,Low,Volume
            2024-01-02,100.0,101.0,99.0,1000
            """;

        // Act
        FormatException exception = Should.Throw<FormatException>(() => Load(Csv));

        // Assert
        exception.Message.ShouldContain("Close");
    }

    [Fact]
    public void AMissingDateColumnIsRejected()
    {
        // Arrange
        const string Csv = """
            Open,High,Low,Close
            100.0,101.0,99.0,100.5
            """;

        // Act
        FormatException exception = Should.Throw<FormatException>(() => Load(Csv));

        // Assert
        exception.Message.ShouldContain("date column");
    }

    [Fact]
    public void AnUnparsableNumberIsReportedWithItsLineNumber()
    {
        // Arrange - line 3 carries a price that is not a number at all.
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            2024-01-02,100.0,101.0,99.0,100.5,1000
            2024-01-03,100.0,101.0,n/a,100.5,1000
            """;

        // Act
        FormatException exception = Should.Throw<FormatException>(() => Load(Csv));

        // Assert
        exception.Message.ShouldContain("Line 3");
    }

    [Fact]
    public void AnUnparsableDateIsReportedWithItsLineNumber()
    {
        // Arrange
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            not-a-date,100.0,101.0,99.0,100.5,1000
            """;

        // Act
        FormatException exception = Should.Throw<FormatException>(() => Load(Csv));

        // Assert
        exception.Message.ShouldContain("Line 2");
        exception.Message.ShouldContain("date");
    }

    [Fact]
    public void ATruncatedRowIsRejected()
    {
        // Arrange
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            2024-01-02,100.0,101.0
            """;

        // Act
        FormatException exception = Should.Throw<FormatException>(() => Load(Csv));

        // Assert
        exception.Message.ShouldContain("Line 2");
        exception.Message.ShouldContain("fields");
    }

    [Fact]
    public void AnEmptySourceIsRejected()
    {
        // Arrange / Act / Assert
        Should.Throw<FormatException>(() => Load(string.Empty));
    }

    [Fact]
    public void AHeaderWithNoRowsLoadsAnEmptySeries()
    {
        // Arrange
        const string Csv = "Date,Open,High,Low,Close,Volume";

        // Act
        IReadOnlyList<Bar> bars = Load(Csv);

        // Assert
        bars.ShouldBeEmpty();
    }

    [Fact]
    public void ValidateFlagsOutOfOrderTimestamps()
    {
        // Arrange
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            2024-01-03,100.0,101.0,99.0,100.5,1000
            2024-01-02,100.0,101.0,99.0,100.5,1000
            """;

        // Act
        IReadOnlyList<string> problems = CsvBarLoader.Validate(Load(Csv));

        // Assert
        problems.Count.ShouldBe(1);
        problems[0].ShouldContain("not strictly after");
    }

    [Fact]
    public void ValidateFlagsAnInconsistentBar()
    {
        // Arrange - the high is below the close, which is impossible.
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            2024-01-02,100.0,100.5,99.0,120.0,1000
            """;

        // Act
        IReadOnlyList<string> problems = CsvBarLoader.Validate(Load(Csv));

        // Assert
        problems.Count.ShouldBe(1);
        problems[0].ShouldContain("not well formed");
    }

    [Fact]
    public void ValidateAcceptsACleanSeries()
    {
        // Arrange
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(200, seed: 99);

        // Act
        IReadOnlyList<string> problems = CsvBarLoader.Validate(bars);

        // Assert
        problems.ShouldBeEmpty();
    }

    [Fact]
    public void LoadFileReadsFromDiskAndReportsAMissingFile()
    {
        // Arrange
        string path = Path.Combine(Path.GetTempPath(), $"talib-backtest-{Guid.NewGuid():N}.csv");
        File.WriteAllText(path, "Date,Open,High,Low,Close,Volume\n2024-01-02,100.0,101.0,99.0,100.5,1000\n");

        try
        {
            // Act
            IReadOnlyList<Bar> bars = CsvBarLoader.LoadFile(path);

            // Assert
            bars.Count.ShouldBe(1);
            bars[0].Close.ShouldBe(100.5);
        }
        finally
        {
            File.Delete(path);
        }

        Should.Throw<FileNotFoundException>(() => CsvBarLoader.LoadFile(path));
        Should.Throw<ArgumentException>(() => CsvBarLoader.LoadFile("  "));
    }

    [Fact]
    public void ALoadedSeriesCanBeBacktestedEndToEnd()
    {
        // Arrange - the whole point of the loader: user data flows straight into the engine.
        const string Csv = """
            Date,Open,High,Low,Close,Volume
            2024-01-02,100.0,101.0,99.0,100.0,1000
            2024-01-03,100.0,111.0,99.0,110.0,1000
            2024-01-04,110.0,121.0,109.0,120.0,1000
            """;

        BacktestOptions options = new() { InitialCapital = 10_000, CommissionBps = 0, SlippageBps = 0 };

        // Act
        BacktestResult result = new BacktestEngine(options).Run(new BuyAndHoldStrategy(), Load(Csv));

        // Assert - bought at 100 on 2024-01-03, liquidated at 120 on 2024-01-04.
        result.Trades.Count.ShouldBe(1);
        result.FinalEquity.ShouldBe(12_000.0, 1e-9);
    }
}
