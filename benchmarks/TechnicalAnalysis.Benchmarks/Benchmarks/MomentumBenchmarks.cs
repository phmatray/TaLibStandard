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
/// Momentum oscillators.
/// </summary>
/// <remarks>
/// <para>
/// As in the other suites, <c>_TAFunc</c> measures the algorithm with caller-supplied output buffers and
/// <c>_TAMath</c> measures the ergonomic API including its per-call allocations. Several of these indicators are
/// composites (MACD, StochRsi, Ppo, UltOsc) and allocate internal scratch arrays even on the <c>TAFunc</c> path;
/// the memory columns make that visible.
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
[BenchmarkCategory(BenchmarkCategories.Momentum)]
public class MomentumBenchmarks : MarketDataBenchmarkBase
{
    private const int RsiPeriod = 14;
    private const int MacdFast = 12;
    private const int MacdSlow = 26;
    private const int MacdSignal = 9;
    private const int StochFastK = 5;
    private const int StochSlowK = 3;
    private const int StochSlowD = 3;
    private const int StochRsiPeriod = 14;
    private const int StochRsiFastK = 5;
    private const int StochRsiFastD = 3;
    private const int AdxPeriod = 14;
    private const int CciPeriod = 14;
    private const int MfiPeriod = 14;
    private const int WillRPeriod = 14;
    private const int PpoFast = 12;
    private const int PpoSlow = 26;
    private const int RocPeriod = 10;
    private const int UltOscPeriod1 = 7;
    private const int UltOscPeriod2 = 14;
    private const int UltOscPeriod3 = 28;
    private const int AroonPeriod = 14;

    /// <summary>
    /// Generates the market data and allocates the output buffers.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        InitializeMarketData();
    }

    /// <summary>
    /// Relative strength index, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Rsi_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Relative strength index, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public RsiResult Rsi_TAMath()
    {
        return TAMath.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod);
    }

    /// <summary>
    /// Moving average convergence divergence, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Macd_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] macd = Output0;
        double[] signal = Output1;
        double[] histogram = Output2;

        return TAFunc.Macd(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            MacdFast,
            MacdSlow,
            MacdSignal,
            ref begIdx,
            ref nbElement,
            ref macd,
            ref signal,
            ref histogram);
    }

    /// <summary>
    /// Moving average convergence divergence, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public MacdResult Macd_TAMath()
    {
        return TAMath.Macd(StartIdx, EndIdx, Series.Doubles.Close, MacdFast, MacdSlow, MacdSignal);
    }

    /// <summary>
    /// Slow stochastic, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Stoch_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] slowK = Output0;
        double[] slowD = Output1;

        return TAFunc.Stoch(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            StochFastK,
            StochSlowK,
            MAType.Sma,
            StochSlowD,
            MAType.Sma,
            ref begIdx,
            ref nbElement,
            ref slowK,
            ref slowD);
    }

    /// <summary>
    /// Slow stochastic, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public StochResult Stoch_TAMath()
    {
        return TAMath.Stoch(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            StochFastK,
            StochSlowK,
            MAType.Sma,
            StochSlowD,
            MAType.Sma);
    }

    /// <summary>
    /// Stochastic RSI, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode StochRsi_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] fastK = Output0;
        double[] fastD = Output1;

        return TAFunc.StochRsi(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            StochRsiPeriod,
            StochRsiFastK,
            StochRsiFastD,
            MAType.Sma,
            ref begIdx,
            ref nbElement,
            ref fastK,
            ref fastD);
    }

    /// <summary>
    /// Stochastic RSI, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public StochRsiResult StochRsi_TAMath()
    {
        return TAMath.StochRsi(StartIdx, EndIdx, Series.Doubles.Close, StochRsiPeriod, StochRsiFastK, StochRsiFastD);
    }

    /// <summary>
    /// Average directional movement index, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Adx_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Adx(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            AdxPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Average directional movement index, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public AdxResult Adx_TAMath()
    {
        return TAMath.Adx(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close, AdxPeriod);
    }

    /// <summary>
    /// Commodity channel index, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Cci_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Cci(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            CciPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Commodity channel index, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public CciResult Cci_TAMath()
    {
        return TAMath.Cci(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close, CciPeriod);
    }

    /// <summary>
    /// Money flow index, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Mfi_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Mfi(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            Series.Doubles.Volume,
            MfiPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Money flow index, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public MfiResult Mfi_TAMath()
    {
        return TAMath.Mfi(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            Series.Doubles.Volume,
            MfiPeriod);
    }

    /// <summary>
    /// Williams %R, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode WillR_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.WillR(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            WillRPeriod,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Williams %R, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public WillRResult WillR_TAMath()
    {
        return TAMath.WillR(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close, WillRPeriod);
    }

    /// <summary>
    /// Percentage price oscillator, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Ppo_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Ppo(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            PpoFast,
            PpoSlow,
            MAType.Sma,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Percentage price oscillator, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public PpoResult Ppo_TAMath()
    {
        return TAMath.Ppo(StartIdx, EndIdx, Series.Doubles.Close, PpoFast, PpoSlow);
    }

    /// <summary>
    /// Rate of change, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Roc_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Roc(StartIdx, EndIdx, Series.Doubles.Close, RocPeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Rate of change, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public RocResult Roc_TAMath()
    {
        return TAMath.Roc(StartIdx, EndIdx, Series.Doubles.Close, RocPeriod);
    }

    /// <summary>
    /// Ultimate oscillator, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode UltOsc_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.UltOsc(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            UltOscPeriod1,
            UltOscPeriod2,
            UltOscPeriod3,
            ref begIdx,
            ref nbElement,
            ref output);
    }

    /// <summary>
    /// Ultimate oscillator, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public UltOscResult UltOsc_TAMath()
    {
        return TAMath.UltOsc(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            UltOscPeriod1,
            UltOscPeriod2,
            UltOscPeriod3);
    }

    /// <summary>
    /// Aroon, allocation-free path.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaFunc)]
    public RetCode Aroon_TAFunc()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] aroonDown = Output0;
        double[] aroonUp = Output1;

        return TAFunc.Aroon(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            AroonPeriod,
            ref begIdx,
            ref nbElement,
            ref aroonDown,
            ref aroonUp);
    }

    /// <summary>
    /// Aroon, ergonomic path.
    /// </summary>
    /// <returns>The calculated result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.TaMath)]
    public AroonResult Aroon_TAMath()
    {
        return TAMath.Aroon(StartIdx, EndIdx, Series.Doubles.High, Series.Doubles.Low, AroonPeriod);
    }
}
