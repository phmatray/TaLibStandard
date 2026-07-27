// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using BenchmarkDotNet.Attributes;
using TechnicalAnalysis.Candles;
using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Benchmarks.Benchmarks;

/// <summary>
/// A representative dozen candlestick pattern recognisers, each exercised over <see cref="double"/>,
/// <see cref="float"/> and <see cref="decimal"/> inputs.
/// </summary>
/// <remarks>
/// <para>
/// <c>TACandle</c> is generic over <c>T : IFloatingPoint&lt;T&gt;</c>, so the JIT produces a dedicated, fully
/// devirtualised body for each value type. The three variants of every benchmark expose the real cost of that
/// generic-math design: <c>double</c> and <c>float</c> compile down to hardware floating point, whereas
/// <c>decimal</c> falls back to the software 128-bit decimal implementation, which is typically one to two orders
/// of magnitude slower and is the reason a decimal-based pipeline should be a deliberate choice.
/// </para>
/// <para>
/// There is no allocation-free path here: <c>TACandle</c> always allocates the <c>int[]</c> output and a
/// <see cref="CandleIndicatorResult"/> record. The memory columns therefore measure the ergonomic API only.
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
[BenchmarkCategory(BenchmarkCategories.CandlePatterns)]
public class CandlePatternBenchmarks : MarketDataBenchmarkBase
{
    private const double PenetrationDouble = 0.3;
    private const float PenetrationSingle = 0.3f;
    private const decimal PenetrationDecimal = 0.3m;

    /// <summary>
    /// Generates the market data.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        InitializeMarketData();
    }

    /// <summary>
    /// Doji over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult Doji_Double()
    {
        return TACandle.CdlDoji(StartIdx, EndIdx, Series.Doubles.Open, Series.Doubles.High, Series.Doubles.Low, Series.Doubles.Close);
    }

    /// <summary>
    /// Doji over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult Doji_Float()
    {
        return TACandle.CdlDoji(StartIdx, EndIdx, Series.Singles.Open, Series.Singles.High, Series.Singles.Low, Series.Singles.Close);
    }

    /// <summary>
    /// Doji over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult Doji_Decimal()
    {
        return TACandle.CdlDoji(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Engulfing pattern over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult Engulfing_Double()
    {
        return TACandle.CdlEngulfing(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Engulfing pattern over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult Engulfing_Float()
    {
        return TACandle.CdlEngulfing(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Engulfing pattern over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult Engulfing_Decimal()
    {
        return TACandle.CdlEngulfing(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Hammer over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult Hammer_Double()
    {
        return TACandle.CdlHammer(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Hammer over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult Hammer_Float()
    {
        return TACandle.CdlHammer(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Hammer over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult Hammer_Decimal()
    {
        return TACandle.CdlHammer(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Hanging man over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult HangingMan_Double()
    {
        return TACandle.CdlHangingMan(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Hanging man over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult HangingMan_Float()
    {
        return TACandle.CdlHangingMan(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Hanging man over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult HangingMan_Decimal()
    {
        return TACandle.CdlHangingMan(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Harami over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult Harami_Double()
    {
        return TACandle.CdlHarami(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Harami over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult Harami_Float()
    {
        return TACandle.CdlHarami(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Harami over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult Harami_Decimal()
    {
        return TACandle.CdlHarami(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Marubozu over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult Marubozu_Double()
    {
        return TACandle.CdlMarubozu(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Marubozu over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult Marubozu_Float()
    {
        return TACandle.CdlMarubozu(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Marubozu over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult Marubozu_Decimal()
    {
        return TACandle.CdlMarubozu(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Spinning top over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult SpinningTop_Double()
    {
        return TACandle.CdlSpinningTop(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Spinning top over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult SpinningTop_Float()
    {
        return TACandle.CdlSpinningTop(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Spinning top over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult SpinningTop_Decimal()
    {
        return TACandle.CdlSpinningTop(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Shooting star over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult ShootingStar_Double()
    {
        return TACandle.CdlShootingStar(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Shooting star over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult ShootingStar_Float()
    {
        return TACandle.CdlShootingStar(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Shooting star over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult ShootingStar_Decimal()
    {
        return TACandle.CdlShootingStar(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Three white soldiers over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult ThreeWhiteSoldiers_Double()
    {
        return TACandle.Cdl3WhiteSoldiers(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Three white soldiers over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult ThreeWhiteSoldiers_Float()
    {
        return TACandle.Cdl3WhiteSoldiers(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Three white soldiers over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult ThreeWhiteSoldiers_Decimal()
    {
        return TACandle.Cdl3WhiteSoldiers(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Three black crows over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult ThreeBlackCrows_Double()
    {
        return TACandle.Cdl3BlackCrows(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Three black crows over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult ThreeBlackCrows_Float()
    {
        return TACandle.Cdl3BlackCrows(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Three black crows over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult ThreeBlackCrows_Decimal()
    {
        return TACandle.Cdl3BlackCrows(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Piercing pattern over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult Piercing_Double()
    {
        return TACandle.CdlPiercing(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// Piercing pattern over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult Piercing_Float()
    {
        return TACandle.CdlPiercing(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// Piercing pattern over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult Piercing_Decimal()
    {
        return TACandle.CdlPiercing(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// High wave candle over double inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult HighWave_Double()
    {
        return TACandle.CdlHighWave(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close);
    }

    /// <summary>
    /// High wave candle over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult HighWave_Float()
    {
        return TACandle.CdlHighWave(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close);
    }

    /// <summary>
    /// High wave candle over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult HighWave_Decimal()
    {
        return TACandle.CdlHighWave(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close);
    }

    /// <summary>
    /// Morning star over double inputs. This is the one pattern in the set that takes a penetration argument.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DoublePrecision)]
    public CandleIndicatorResult MorningStar_Double()
    {
        return TACandle.CdlMorningStar(
            StartIdx,
            EndIdx,
            Series.Doubles.Open,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            PenetrationDouble);
    }

    /// <summary>
    /// Morning star over float inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.SinglePrecision)]
    public CandleIndicatorResult MorningStar_Float()
    {
        return TACandle.CdlMorningStar(
            StartIdx,
            EndIdx,
            Series.Singles.Open,
            Series.Singles.High,
            Series.Singles.Low,
            Series.Singles.Close,
            PenetrationSingle);
    }

    /// <summary>
    /// Morning star over decimal inputs.
    /// </summary>
    /// <returns>The pattern result.</returns>
    [Benchmark]
    [BenchmarkCategory(BenchmarkCategories.DecimalPrecision)]
    public CandleIndicatorResult MorningStar_Decimal()
    {
        return TACandle.CdlMorningStar(
            StartIdx,
            EndIdx,
            Series.Decimals.Open,
            Series.Decimals.High,
            Series.Decimals.Low,
            Series.Decimals.Close,
            PenetrationDecimal);
    }
}
