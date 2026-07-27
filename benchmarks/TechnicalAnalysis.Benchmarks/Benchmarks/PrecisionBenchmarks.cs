// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using BenchmarkDotNet.Attributes;
using TechnicalAnalysis.Functions;

namespace TechnicalAnalysis.Benchmarks.Benchmarks;

/// <summary>
/// Double versus float on the same indicators, so the cost of the <see cref="float"/> overloads is visible.
/// </summary>
/// <remarks>
/// <para>
/// The <c>TAFunc</c> kernels are written for <see cref="double"/> only. Every <c>float</c> overload on
/// <c>TAMath</c> therefore widens its inputs into freshly allocated <c>double[]</c> arrays and then calls the same
/// kernel. A float benchmark consequently measures <em>the double kernel plus one widening pass and one array
/// allocation per input series</em>; it can never be faster than its double counterpart, and the memory columns
/// show exactly how much extra it costs.
/// </para>
/// <para>
/// This suite intentionally uses the ergonomic <c>TAMath</c> API for both precisions, because that is the only API
/// where a float entry point exists at all. Use <see cref="OverlapStudiesBenchmarks"/> and friends for the
/// allocation-free comparison.
/// </para>
/// <para>
/// <strong>There is deliberately no <c>Ratio</c> column here.</strong> A single <c>Baseline = true</c> would
/// ratio every row against one method — the default logical group is (Job, Params), not (indicator) — so a
/// <c>float</c> row would appear to be compared against its own <c>double</c> counterpart when it was in fact
/// compared against <c>Sma_Double</c>. Compare the <c>Mean</c> and <c>Allocated</c> columns of the two rows
/// of the same indicator instead.
/// </para>
/// </remarks>
[MemoryDiagnoser]
[CategoriesColumn]
[BenchmarkCategory(BenchmarkCategories.Precision)]
public class PrecisionBenchmarks : MarketDataBenchmarkBase
{
    private const int MaPeriod = 30;
    private const int RsiPeriod = 14;
    private const int AtrPeriod = 14;
    private const int BollingerPeriod = 20;

    /// <summary>
    /// Generates the market data.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        InitializeMarketData();
    }

    /// <summary>
    /// Simple moving average over double inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public SmaResult Sma_Double()
    {
        return TAMath.Sma(StartIdx, EndIdx, Series.Doubles.Close, MaPeriod);
    }

    /// <summary>
    /// Simple moving average over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public SmaResult Sma_Float()
    {
        return TAMath.Sma(StartIdx, EndIdx, Series.Singles.Close, MaPeriod);
    }

    /// <summary>
    /// Exponential moving average over double inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public EmaResult Ema_Double()
    {
        return TAMath.Ema(StartIdx, EndIdx, Series.Doubles.Close, MaPeriod);
    }

    /// <summary>
    /// Exponential moving average over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public EmaResult Ema_Float()
    {
        return TAMath.Ema(StartIdx, EndIdx, Series.Singles.Close, MaPeriod);
    }

    /// <summary>
    /// Relative strength index over double inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public RsiResult Rsi_Double()
    {
        return TAMath.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod);
    }

    /// <summary>
    /// Relative strength index over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public RsiResult Rsi_Float()
    {
        return TAMath.Rsi(StartIdx, EndIdx, Series.Singles.Close, RsiPeriod);
    }

    /// <summary>
    /// MACD over double inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public MacdResult Macd_Double()
    {
        return TAMath.Macd(StartIdx, EndIdx, Series.Doubles.Close);
    }

    /// <summary>
    /// MACD over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public MacdResult Macd_Float()
    {
        return TAMath.Macd(StartIdx, EndIdx, Series.Singles.Close);
    }

    /// <summary>
    /// Bollinger Bands over double inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public BollingerBandsResult BollingerBands_Double()
    {
        return TAMath.BollingerBands(StartIdx, EndIdx, Series.Doubles.Close, BollingerPeriod);
    }

    /// <summary>
    /// Bollinger Bands over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public BollingerBandsResult BollingerBands_Float()
    {
        return TAMath.BollingerBands(StartIdx, EndIdx, Series.Singles.Close, BollingerPeriod);
    }

    /// <summary>
    /// Average true range over double inputs. Three input series must be widened on the float path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public AtrResult Atr_Double()
    {
        return TAMath.Atr(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close, AtrPeriod);
    }

    /// <summary>
    /// Average true range over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public AtrResult Atr_Float()
    {
        return TAMath.Atr(StartIdx, EndIdx, Series.Singles.High, Series.Singles.Low, Series.Singles.Close, AtrPeriod);
    }

    /// <summary>
    /// Correlation over double inputs. Two input series must be widened on the float path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CorrelResult Correl_Double()
    {
        return TAMath.Correl(StartIdx, EndIdx, Series.Doubles.Close, Series.ReferenceDoubles.Close, MaPeriod);
    }

    /// <summary>
    /// Correlation over float inputs.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CorrelResult Correl_Float()
    {
        return TAMath.Correl(StartIdx, EndIdx, Series.Singles.Close, Series.ReferenceSingles.Close, MaPeriod);
    }
}
