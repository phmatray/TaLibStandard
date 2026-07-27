// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using BenchmarkDotNet.Attributes;
using TechnicalAnalysis.Benchmarks.Data;

namespace TechnicalAnalysis.Benchmarks.Benchmarks;

/// <summary>
/// Shared plumbing for every indicator benchmark: the series length parameter, the generated market data and the
/// pre-allocated output buffers used by the allocation-free <c>TAFunc</c> path.
/// </summary>
/// <remarks>
/// <para>
/// Three output buffers are provided because no bound indicator writes more than three output series
/// (MACD and Bollinger Bands are the widest at three).
/// </para>
/// <para>
/// The buffers are allocated once in <c>[GlobalSetup]</c>, i.e. outside the measured region. A benchmark named
/// <c>*_TAFunc</c> therefore measures the algorithm only; a benchmark named <c>*_TAMath</c> measures the algorithm
/// plus the result-object and output-array allocations that the ergonomic API performs on every call.
/// </para>
/// </remarks>
public abstract class MarketDataBenchmarkBase
{
    /// <summary>
    /// Gets or sets the number of bars fed to the indicator.
    /// </summary>
    [Params(1_000, 10_000, 100_000)]
    public int Length { get; set; }

    /// <summary>
    /// Gets the generated market data for the current <see cref="Length"/>.
    /// </summary>
    protected MarketSeries Series { get; private set; } = MarketDataGenerator.Generate(2);

    /// <summary>
    /// The first index handed to the indicator. Always zero: benchmarks always run the whole series.
    /// </summary>
    protected const int StartIdx = 0;

    /// <summary>
    /// Gets the last index handed to the indicator, i.e. <see cref="Length"/> minus one.
    /// </summary>
    protected int EndIdx => Length - 1;

    /// <summary>
    /// Gets the first pre-allocated output buffer.
    /// </summary>
    protected double[] Output0 { get; private set; } = [];

    /// <summary>
    /// Gets the second pre-allocated output buffer.
    /// </summary>
    protected double[] Output1 { get; private set; } = [];

    /// <summary>
    /// Gets the third pre-allocated output buffer.
    /// </summary>
    protected double[] Output2 { get; private set; } = [];

    /// <summary>
    /// Generates the market data and allocates the output buffers. Call this from a <c>[GlobalSetup]</c> method.
    /// </summary>
    protected void InitializeMarketData()
    {
        Series = MarketDataGenerator.Generate(Length);
        Output0 = new double[Length];
        Output1 = new double[Length];
        Output2 = new double[Length];
    }
}
