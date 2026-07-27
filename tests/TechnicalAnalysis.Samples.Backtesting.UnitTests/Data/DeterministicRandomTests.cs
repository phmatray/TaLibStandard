// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.Data;

public class DeterministicRandomTests
{
    [Fact]
    public void TheSameSeedReplaysTheSameSequence()
    {
        // Arrange
        DeterministicRandom first = new(2024);
        DeterministicRandom second = new(2024);

        // Act
        ulong[] a = [.. Enumerable.Range(0, 100).Select(_ => first.NextUInt64())];
        ulong[] b = [.. Enumerable.Range(0, 100).Select(_ => second.NextUInt64())];

        // Assert
        a.ShouldBe(b);
    }

    [Fact]
    public void DifferentSeedsDiverge()
    {
        // Arrange
        DeterministicRandom first = new(1);
        DeterministicRandom second = new(2);

        // Act
        ulong[] a = [.. Enumerable.Range(0, 100).Select(_ => first.NextUInt64())];
        ulong[] b = [.. Enumerable.Range(0, 100).Select(_ => second.NextUInt64())];

        // Assert
        a.ShouldNotBe(b);
    }

    [Fact]
    public void UniformDeviatesStayInTheHalfOpenUnitInterval()
    {
        // Arrange
        DeterministicRandom random = new(31);

        // Act
        double[] samples = [.. Enumerable.Range(0, 200_000).Select(_ => random.NextDouble())];

        // Assert
        samples.ShouldAllBe(value => value >= 0.0 && value < 1.0);
        samples.Average().ShouldBe(0.5, 0.01);
    }

    [Fact]
    public void GaussianDeviatesHaveTheExpectedShape()
    {
        // Arrange
        DeterministicRandom random = new(97);
        double[] samples = [.. Enumerable.Range(0, 200_000).Select(_ => random.NextGaussian())];

        // Act
        double mean = samples.Average();
        double variance = samples.Sum(value => (value - mean) * (value - mean)) / (samples.Length - 1);

        // Assert - 200k draws puts the standard error of the mean near 0.0022, so 0.02 is a safe band.
        mean.ShouldBe(0.0, 0.02);
        Math.Sqrt(variance).ShouldBe(1.0, 0.02);
        samples.ShouldAllBe(value => double.IsFinite(value));

        // Roughly two thirds of the mass must lie within one standard deviation.
        (samples.Count(value => Math.Abs(value) <= 1.0) / (double)samples.Length).ShouldBe(0.6827, 0.01);
    }
}
