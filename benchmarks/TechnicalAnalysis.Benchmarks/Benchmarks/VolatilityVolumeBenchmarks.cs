// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using BenchmarkDotNet.Attributes;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

namespace TechnicalAnalysis.Benchmarks.Benchmarks;

/// <summary>
/// Volatility indicators, volume indicators and the two-series statistic functions.
/// </summary>
/// <remarks>
/// <para>
/// Correl and Beta consume the primary close series and the correlated reference close series produced by
/// <see cref="Data.MarketDataGenerator"/>, so the statistics they compute are meaningful rather than degenerate.
/// </para>
/// <para>
/// <strong>There is deliberately no <c>Ratio</c> column here.</strong> BenchmarkDotNet's default logical group
/// is (Job, Params), so a single <c>Baseline = true</c> would ratio <em>every</em> method in the class against
/// that one method — an EMA row would read as "3.7x slower" when what it measured was EMA against SMA, not
/// <c>TAMath</c> against <c>TAFunc</c>. Grouping per indicator cannot fix it either, because
/// <c>BenchmarkLogicalGroupRule.ByCategory</c> keys on the whole category set and the <c>TAFunc</c> /
/// <c>TAMath</c> categories put the two halves of a pair in different groups. Read the two rows of the same
/// indicator and divide the <c>Mean</c> column yourself; <see cref="NativeComparisonBenchmarks"/> is the one
/// suite whose categories do line up, and it is the one that carries baselines.
/// </para>
/// </remarks>
[MemoryDiagnoser]
[CategoriesColumn]
[BenchmarkCategory(BenchmarkCategories.VolatilityVolume)]
public class VolatilityVolumeBenchmarks : MarketDataBenchmarkBase
{
    private const int AtrPeriod = 14;
    private const int NatrPeriod = 14;
    private const int AdOscFast = 3;
    private const int AdOscSlow = 10;
    private const int StdDevPeriod = 20;
    private const int VariancePeriod = 20;
    private const int CorrelPeriod = 30;
    private const int BetaPeriod = 5;
    private const double NbDev = 1.0;

    /// <summary>
    /// Generates the market data and allocates the output buffers.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        InitializeMarketData();
    }

    /// <summary>
    /// Average true range, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Atr_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Atr(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            AtrPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Average true range, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public AtrResult Atr_TAMath()
    {
        return TAMath.Atr(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close, AtrPeriod);
    }

    /// <summary>
    /// Normalized average true range, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Natr_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Natr(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            NatrPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Normalized average true range, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public NatrResult Natr_TAMath()
    {
        return TAMath.Natr(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close, NatrPeriod);
    }

    /// <summary>
    /// True range, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode TrueRange_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.TrueRange(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// True range, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public TrueRangeResult TrueRange_TAMath()
    {
        return TAMath.TrueRange(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close);
    }

    /// <summary>
    /// On balance volume, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Obv_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Obv(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            Series.Doubles.Volume,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// On balance volume, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public ObvResult Obv_TAMath()
    {
        return TAMath.Obv(StartIdx, EndIdx, Series.Doubles.Close, Series.Doubles.Volume);
    }

    /// <summary>
    /// Chaikin accumulation / distribution line, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Ad_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Ad(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            Series.Doubles.Volume,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Chaikin accumulation / distribution line, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public AdResult Ad_TAMath()
    {
        return TAMath.Ad(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            Series.Doubles.Volume);
    }

    /// <summary>
    /// Chaikin accumulation / distribution oscillator, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode AdOsc_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.AdOsc(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            Series.Doubles.Volume,
            AdOscFast,
            AdOscSlow,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Chaikin accumulation / distribution oscillator, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public AdOscResult AdOsc_TAMath()
    {
        return TAMath.AdOsc(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            Series.Doubles.Volume,
            AdOscFast,
            AdOscSlow);
    }

    /// <summary>
    /// Rolling standard deviation, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode StdDev_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.StdDev(StartIdx, EndIdx, Series.Doubles.Close, StdDevPeriod, NbDev, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Rolling standard deviation, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public StdDevResult StdDev_TAMath()
    {
        return TAMath.StdDev(StartIdx, EndIdx, Series.Doubles.Close, StdDevPeriod, NbDev);
    }

    /// <summary>
    /// Rolling variance, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Variance_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Variance(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            VariancePeriod,
            NbDev,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Rolling variance, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public VarianceResult Variance_TAMath()
    {
        return TAMath.Variance(StartIdx, EndIdx, Series.Doubles.Close, VariancePeriod, NbDev);
    }

    /// <summary>
    /// Pearson correlation between the primary and the reference instrument, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Correl_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Correl(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            Series.ReferenceDoubles.Close,
            CorrelPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Pearson correlation between the primary and the reference instrument, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public CorrelResult Correl_TAMath()
    {
        return TAMath.Correl(StartIdx, EndIdx, Series.Doubles.Close, Series.ReferenceDoubles.Close, CorrelPeriod);
    }

    /// <summary>
    /// Beta of the primary instrument against the reference instrument, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Beta_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Beta(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            Series.ReferenceDoubles.Close,
            BetaPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Beta of the primary instrument against the reference instrument, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public BetaResult Beta_TAMath()
    {
        return TAMath.Beta(StartIdx, EndIdx, Series.Doubles.Close, Series.ReferenceDoubles.Close, BetaPeriod);
    }
}
