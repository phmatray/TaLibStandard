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
/// Overlap studies: moving averages, envelopes and the parabolic SAR.
/// </summary>
/// <remarks>
/// <para>
/// Every indicator appears twice. The <c>_TAFunc</c> variant writes into buffers allocated in
/// <c>[GlobalSetup]</c> and therefore reports the pure algorithm cost with zero managed allocation. The
/// <c>_TAMath</c> variant calls the ergonomic API, which allocates one output array per output series plus one
/// result record per call; the delta between the two is the price of the convenient API.
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
[BenchmarkCategory(BenchmarkCategories.OverlapStudies)]
public class OverlapStudiesBenchmarks : MarketDataBenchmarkBase
{
    private const int TimePeriod = 30;
    private const int BollingerPeriod = 20;
    private const int MidPointPeriod = 14;
    private const int T3Period = 5;
    private const double T3VFactor = 0.7;

    /// <summary>
    /// Generates the market data and allocates the output buffers.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        InitializeMarketData();
    }

    /// <summary>
    /// Simple moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Sma_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Sma(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Simple moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public SmaResult Sma_TAMath()
    {
        return TAMath.Sma(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Exponential moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Ema_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Ema(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Exponential moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public EmaResult Ema_TAMath()
    {
        return TAMath.Ema(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Weighted moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Wma_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Wma(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Weighted moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public WmaResult Wma_TAMath()
    {
        return TAMath.Wma(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Double exponential moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Dema_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Dema(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Double exponential moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public DemaResult Dema_TAMath()
    {
        return TAMath.Dema(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Triple exponential moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Tema_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Tema(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Triple exponential moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public TemaResult Tema_TAMath()
    {
        return TAMath.Tema(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Triangular moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Trima_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Trima(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Triangular moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public TrimaResult Trima_TAMath()
    {
        return TAMath.Trima(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Kaufman adaptive moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Kama_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Kama(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Kaufman adaptive moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public KamaResult Kama_TAMath()
    {
        return TAMath.Kama(StartIdx, EndIdx, Series.Doubles.Close, TimePeriod);
    }

    /// <summary>
    /// Tillson T3 moving average, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode T3_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.T3(StartIdx, EndIdx, Series.Doubles.Close, T3Period, T3VFactor, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Tillson T3 moving average, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public T3Result T3_TAMath()
    {
        return TAMath.T3(StartIdx, EndIdx, Series.Doubles.Close, T3Period, T3VFactor);
    }

    /// <summary>
    /// Bollinger Bands, allocation-free path. Three output series are written into pre-allocated buffers.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode BollingerBands_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] upper = Output0;
        double[] middle = Output1;
        double[] lower = Output2;

        return TAFunc.BollingerBands(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            BollingerPeriod,
            2.0,
            2.0,
            MAType.Sma,
            ref begIdx,
            ref nbElement,
            ref upper,
            ref middle,
            ref lower);
    }

    /// <summary>
    /// Bollinger Bands, ergonomic path. Allocates three output arrays plus a result record.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public BollingerBandsResult BollingerBands_TAMath()
    {
        return TAMath.BollingerBands(StartIdx, EndIdx, Series.Doubles.Close, BollingerPeriod);
    }

    /// <summary>
    /// MidPoint over a period, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode MidPoint_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.MidPoint(StartIdx, EndIdx, Series.Doubles.Close, MidPointPeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// MidPoint over a period, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public MidPointResult MidPoint_TAMath()
    {
        return TAMath.MidPoint(StartIdx, EndIdx, Series.Doubles.Close, MidPointPeriod);
    }

    /// <summary>
    /// Parabolic SAR, allocation-free path. Note that the SAR implementation itself allocates a few tiny scratch
    /// arrays internally, so this variant is not literally zero-allocation.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Sar_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Sar(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            0.02,
            0.2,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Parabolic SAR, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public SarResult Sar_TAMath()
    {
        return TAMath.Sar(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low);
    }
}
