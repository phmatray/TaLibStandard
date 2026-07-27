// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Data;

public class SyntheticSeriesGeneratorTests
{
    [Fact]
    public void TheSameSeedAlwaysProducesTheSameSeries()
    {
        // Arrange / Act
        IReadOnlyList<Bar> first = SyntheticSeriesGenerator.Generate(250, seed: 4242);
        IReadOnlyList<Bar> second = SyntheticSeriesGenerator.Generate(250, seed: 4242);

        // Assert - bit-for-bit, which is what makes the sample's printed numbers reproducible.
        first.Count.ShouldBe(second.Count);
        for (int i = 0; i < first.Count; i++)
        {
            first[i].ShouldBe(second[i]);
        }
    }

    [Fact]
    public void DifferentSeedsProduceDifferentSeries()
    {
        // Arrange / Act
        IReadOnlyList<Bar> first = SyntheticSeriesGenerator.Generate(250, seed: 1);
        IReadOnlyList<Bar> second = SyntheticSeriesGenerator.Generate(250, seed: 2);

        // Assert
        first.Select(bar => bar.Close).ShouldNotBe(second.Select(bar => bar.Close));
    }

    [Fact]
    public void EveryGeneratedBarIsWellFormed()
    {
        // Arrange / Act
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(2_000, seed: 7);

        // Assert
        bars.ShouldAllBe(bar => bar.IsWellFormed());
        CsvBarLoader.Validate(bars).ShouldBeEmpty();
    }

    [Fact]
    public void TimestampsAreStrictlyAscendingWeekdays()
    {
        // Arrange / Act
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(500, seed: 11);

        // Assert
        bars.ShouldAllBe(bar => bar.Timestamp.DayOfWeek != DayOfWeek.Saturday && bar.Timestamp.DayOfWeek != DayOfWeek.Sunday);
        for (int i = 1; i < bars.Count; i++)
        {
            bars[i].Timestamp.ShouldBeGreaterThan(bars[i - 1].Timestamp);
        }
    }

    [Fact]
    public void TheSeriesDriftsUpwardsOverTheLongRun()
    {
        // Arrange - a positive drift is what makes the trend-following comparisons interesting.
        // Averaged over ten seeds the drift must dominate the noise.
        List<double> totalReturns = [];

        // Act
        for (int seed = 0; seed < 10; seed++)
        {
            IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(2_520, seed: seed, annualDrift: 0.12);
            totalReturns.Add((bars[^1].Close / bars[0].Open) - 1.0);
        }

        // Assert - 10 years of 12% drift compounds to roughly +230%; require at least a doubling on average.
        totalReturns.Average().ShouldBeGreaterThan(1.0);
    }

    [Fact]
    public void ZeroBarsProducesAnEmptySeries()
    {
        // Arrange / Act
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(0);

        // Assert
        bars.ShouldBeEmpty();
    }

    [Fact]
    public void TheFirstBarOpensAtTheRequestedStartPrice()
    {
        // Arrange / Act
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(10, seed: 3, startPrice: 42.5);

        // Assert
        bars[0].Open.ShouldBe(42.5);
    }

    [Fact]
    public void TheRequestedStartDateIsHonoured()
    {
        // Arrange
        DateTime start = new(2021, 3, 15, 0, 0, 0, DateTimeKind.Utc);

        // Act
        IReadOnlyList<Bar> bars = SyntheticSeriesGenerator.Generate(5, seed: 3, startDate: start);

        // Assert
        bars[0].Timestamp.ShouldBe(start);
        bars.Count.ShouldBe(5);
    }

    [Theory]
    [InlineData(-1, 100.0, 0.2, 252)]
    [InlineData(10, 0.0, 0.2, 252)]
    [InlineData(10, 100.0, -0.1, 252)]
    [InlineData(10, 100.0, 0.2, 0)]
    public void AnInvalidConfigurationIsRejected(int barCount, double startPrice, double volatility, int barsPerYear)
    {
        // Arrange / Act / Assert
        Should.Throw<ArgumentOutOfRangeException>(
            () => SyntheticSeriesGenerator.Generate(barCount, 1, startPrice, 0.1, volatility, barsPerYear));
    }
}
