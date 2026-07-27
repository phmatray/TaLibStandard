// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using TechnicalAnalysis.Benchmarks.Interop;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

namespace TechnicalAnalysis.Benchmarks.Benchmarks;

/// <summary>
/// Head-to-head comparison between the managed TaLibStandard kernels and the original TA-Lib C library.
/// </summary>
/// <remarks>
/// <para>
/// This class only runs when <see cref="NativeTaLib.IsAvailable"/> is <see langword="true"/>. <c>Program</c>
/// removes it from the runnable set otherwise, so the suite has no native dependency by default.
/// </para>
/// <para>
/// Both sides use caller-supplied output buffers allocated in <c>[GlobalSetup]</c>, so the comparison is
/// algorithm against algorithm with no allocation noise on either side. The managed side deliberately uses
/// <c>TAFunc</c> rather than <c>TAMath</c> for exactly that reason.
/// </para>
/// <para>
/// <c>[GlobalSetup]</c> runs both implementations once and asserts they agree, so a "faster" result can never come
/// from computing the wrong thing. Benchmarks are grouped per indicator with the managed implementation as the
/// baseline, so the Ratio column reads directly as "native time / managed time".
/// </para>
/// </remarks>
[MemoryDiagnoser]
[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[BenchmarkCategory(BenchmarkCategories.NativeComparison)]
public class NativeComparisonBenchmarks : MarketDataBenchmarkBase
{
    private const int SmaPeriod = 30;
    private const int EmaPeriod = 30;
    private const int RsiPeriod = 14;
    private const int MacdFast = 12;
    private const int MacdSlow = 26;
    private const int MacdSignal = 9;
    private const int BbandsPeriod = 20;
    private const int AtrPeriod = 14;
    private const int AdxPeriod = 14;
    private const int StochFastK = 5;
    private const int StochSlowK = 3;
    private const int StochSlowD = 3;

    private double[] _native0 = [];
    private double[] _native1 = [];
    private double[] _native2 = [];

    /// <summary>
    /// Generates the market data, allocates every output buffer and proves managed and native agree.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the native library is unavailable, when either implementation reports a failure, or when the two
    /// implementations disagree.
    /// </exception>
    [GlobalSetup]
    public void Setup()
    {
        if (!NativeTaLib.IsAvailable)
        {
            throw new InvalidOperationException(
                "Native TA-Lib is not available. NativeComparisonBenchmarks must not be scheduled in that case. " +
                NativeTaLib.Diagnostics);
        }

        InitializeMarketData();

        _native0 = new double[Length];
        _native1 = new double[Length];
        _native2 = new double[Length];

        VerifyEquivalence();
    }

    /// <summary>
    /// Simple moving average, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Sma")]
    public RetCode Sma_Managed()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Sma(StartIdx, EndIdx, Series.Doubles.Close, SmaPeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Simple moving average, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Sma")]
    public int Sma_Native()
    {
        return NativeTaLib.Sma(StartIdx, EndIdx, Series.Doubles.Close, SmaPeriod, out _, out _, _native0);
    }

    /// <summary>
    /// Exponential moving average, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Ema")]
    public RetCode Ema_Managed()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Ema(StartIdx, EndIdx, Series.Doubles.Close, EmaPeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Exponential moving average, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Ema")]
    public int Ema_Native()
    {
        return NativeTaLib.Ema(StartIdx, EndIdx, Series.Doubles.Close, EmaPeriod, out _, out _, _native0);
    }

    /// <summary>
    /// Relative strength index, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Rsi")]
    public RetCode Rsi_Managed()
    {
        int begIdx = 0;
        int nbElement = 0;
        double[] output = Output0;
        return TAFunc.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod, ref begIdx, ref nbElement, ref output);
    }

    /// <summary>
    /// Relative strength index, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Rsi")]
    public int Rsi_Native()
    {
        return NativeTaLib.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod, out _, out _, _native0);
    }

    /// <summary>
    /// MACD, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Macd")]
    public RetCode Macd_Managed()
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
    /// MACD, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Macd")]
    public int Macd_Native()
    {
        return NativeTaLib.Macd(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            MacdFast,
            MacdSlow,
            MacdSignal,
            out _,
            out _,
            _native0,
            _native1,
            _native2);
    }

    /// <summary>
    /// Bollinger Bands, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Bbands")]
    public RetCode Bbands_Managed()
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
            BbandsPeriod,
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
    /// Bollinger Bands, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Bbands")]
    public int Bbands_Native()
    {
        return NativeTaLib.Bbands(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            BbandsPeriod,
            2.0,
            2.0,
            (int)MAType.Sma,
            out _,
            out _,
            _native0,
            _native1,
            _native2);
    }

    /// <summary>
    /// Average true range, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Atr")]
    public RetCode Atr_Managed()
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
    /// Average true range, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Atr")]
    public int Atr_Native()
    {
        return NativeTaLib.Atr(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            AtrPeriod,
            out _,
            out _,
            _native0);
    }

    /// <summary>
    /// Average directional movement index, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Adx")]
    public RetCode Adx_Managed()
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
    /// Average directional movement index, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Adx")]
    public int Adx_Native()
    {
        return NativeTaLib.Adx(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            AdxPeriod,
            out _,
            out _,
            _native0);
    }

    /// <summary>
    /// Slow stochastic, managed kernel.
    /// </summary>
    /// <returns>The return code of the calculation.</returns>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Stoch")]
    public RetCode Stoch_Managed()
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
    /// Slow stochastic, native TA-Lib C.
    /// </summary>
    /// <returns>The native return code.</returns>
    [Benchmark]
    [BenchmarkCategory("Stoch")]
    public int Stoch_Native()
    {
        return NativeTaLib.Stoch(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            StochFastK,
            StochSlowK,
            (int)MAType.Sma,
            StochSlowD,
            (int)MAType.Sma,
            out _,
            out _,
            _native0,
            _native1);
    }

    private void VerifyEquivalence()
    {
        VerifySingleOutput(
            "SMA",
            (out int beg, out int count, double[] buffer) =>
            {
                int b = 0;
                int n = 0;
                double[] local = buffer;
                RetCode code = TAFunc.Sma(StartIdx, EndIdx, Series.Doubles.Close, SmaPeriod, ref b, ref n, ref local);
                beg = b;
                count = n;
                return code == RetCode.Success;
            },
            (out int beg, out int count, double[] buffer) =>
                NativeTaLib.Sma(StartIdx, EndIdx, Series.Doubles.Close, SmaPeriod, out beg, out count, buffer)
                == NativeTaLib.Success);

        VerifySingleOutput(
            "EMA",
            (out int beg, out int count, double[] buffer) =>
            {
                int b = 0;
                int n = 0;
                double[] local = buffer;
                RetCode code = TAFunc.Ema(StartIdx, EndIdx, Series.Doubles.Close, EmaPeriod, ref b, ref n, ref local);
                beg = b;
                count = n;
                return code == RetCode.Success;
            },
            (out int beg, out int count, double[] buffer) =>
                NativeTaLib.Ema(StartIdx, EndIdx, Series.Doubles.Close, EmaPeriod, out beg, out count, buffer)
                == NativeTaLib.Success);

        VerifySingleOutput(
            "RSI",
            (out int beg, out int count, double[] buffer) =>
            {
                int b = 0;
                int n = 0;
                double[] local = buffer;
                RetCode code = TAFunc.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod, ref b, ref n, ref local);
                beg = b;
                count = n;
                return code == RetCode.Success;
            },
            (out int beg, out int count, double[] buffer) =>
                NativeTaLib.Rsi(StartIdx, EndIdx, Series.Doubles.Close, RsiPeriod, out beg, out count, buffer)
                == NativeTaLib.Success);

        VerifySingleOutput(
            "ATR",
            (out int beg, out int count, double[] buffer) =>
            {
                int b = 0;
                int n = 0;
                double[] local = buffer;
                RetCode code = TAFunc.Atr(
                    StartIdx,
                    EndIdx,
                    Series.Doubles.High,
                    Series.Doubles.Low,
                    Series.Doubles.Close,
                    AtrPeriod,
                    ref b,
                    ref n,
                    ref local);
                beg = b;
                count = n;
                return code == RetCode.Success;
            },
            (out int beg, out int count, double[] buffer) =>
                NativeTaLib.Atr(
                    StartIdx,
                    EndIdx,
                    Series.Doubles.High,
                    Series.Doubles.Low,
                    Series.Doubles.Close,
                    AtrPeriod,
                    out beg,
                    out count,
                    buffer)
                == NativeTaLib.Success);

        VerifySingleOutput(
            "ADX",
            (out int beg, out int count, double[] buffer) =>
            {
                int b = 0;
                int n = 0;
                double[] local = buffer;
                RetCode code = TAFunc.Adx(
                    StartIdx,
                    EndIdx,
                    Series.Doubles.High,
                    Series.Doubles.Low,
                    Series.Doubles.Close,
                    AdxPeriod,
                    ref b,
                    ref n,
                    ref local);
                beg = b;
                count = n;
                return code == RetCode.Success;
            },
            (out int beg, out int count, double[] buffer) =>
                NativeTaLib.Adx(
                    StartIdx,
                    EndIdx,
                    Series.Doubles.High,
                    Series.Doubles.Low,
                    Series.Doubles.Close,
                    AdxPeriod,
                    out beg,
                    out count,
                    buffer)
                == NativeTaLib.Success);

        VerifyMacd();
        VerifyBbands();
        VerifyStoch();
    }

    private void VerifyMacd()
    {
        int managedBeg = 0;
        int managedCount = 0;
        double[] managedMacd = new double[Length];
        double[] managedSignal = new double[Length];
        double[] managedHist = new double[Length];

        RetCode managedCode = TAFunc.Macd(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            MacdFast,
            MacdSlow,
            MacdSignal,
            ref managedBeg,
            ref managedCount,
            ref managedMacd,
            ref managedSignal,
            ref managedHist);

        EnsureSucceeded("MACD", managedCode == RetCode.Success, isManaged: true);

        double[] nativeMacd = new double[Length];
        double[] nativeSignal = new double[Length];
        double[] nativeHist = new double[Length];

        int nativeCode = NativeTaLib.Macd(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            MacdFast,
            MacdSlow,
            MacdSignal,
            out int nativeBeg,
            out int nativeCount,
            nativeMacd,
            nativeSignal,
            nativeHist);

        EnsureSucceeded("MACD", nativeCode == NativeTaLib.Success, isManaged: false);

        NativeEquivalence.AssertEquivalent("MACD (line)", managedBeg, managedCount, managedMacd, nativeBeg, nativeCount, nativeMacd);
        NativeEquivalence.AssertEquivalent(
            "MACD (signal)",
            managedBeg,
            managedCount,
            managedSignal,
            nativeBeg,
            nativeCount,
            nativeSignal);
        NativeEquivalence.AssertEquivalent("MACD (hist)", managedBeg, managedCount, managedHist, nativeBeg, nativeCount, nativeHist);
    }

    private void VerifyBbands()
    {
        int managedBeg = 0;
        int managedCount = 0;
        double[] managedUpper = new double[Length];
        double[] managedMiddle = new double[Length];
        double[] managedLower = new double[Length];

        RetCode managedCode = TAFunc.BollingerBands(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            BbandsPeriod,
            2.0,
            2.0,
            MAType.Sma,
            ref managedBeg,
            ref managedCount,
            ref managedUpper,
            ref managedMiddle,
            ref managedLower);

        EnsureSucceeded("BBANDS", managedCode == RetCode.Success, isManaged: true);

        double[] nativeUpper = new double[Length];
        double[] nativeMiddle = new double[Length];
        double[] nativeLower = new double[Length];

        int nativeCode = NativeTaLib.Bbands(
            StartIdx,
            EndIdx,
            Series.Doubles.Close,
            BbandsPeriod,
            2.0,
            2.0,
            (int)MAType.Sma,
            out int nativeBeg,
            out int nativeCount,
            nativeUpper,
            nativeMiddle,
            nativeLower);

        EnsureSucceeded("BBANDS", nativeCode == NativeTaLib.Success, isManaged: false);

        NativeEquivalence.AssertEquivalent(
            "BBANDS (upper)",
            managedBeg,
            managedCount,
            managedUpper,
            nativeBeg,
            nativeCount,
            nativeUpper);
        NativeEquivalence.AssertEquivalent(
            "BBANDS (middle)",
            managedBeg,
            managedCount,
            managedMiddle,
            nativeBeg,
            nativeCount,
            nativeMiddle);
        NativeEquivalence.AssertEquivalent(
            "BBANDS (lower)",
            managedBeg,
            managedCount,
            managedLower,
            nativeBeg,
            nativeCount,
            nativeLower);
    }

    private void VerifyStoch()
    {
        int managedBeg = 0;
        int managedCount = 0;
        double[] managedSlowK = new double[Length];
        double[] managedSlowD = new double[Length];

        RetCode managedCode = TAFunc.Stoch(
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
            ref managedBeg,
            ref managedCount,
            ref managedSlowK,
            ref managedSlowD);

        EnsureSucceeded("STOCH", managedCode == RetCode.Success, isManaged: true);

        double[] nativeSlowK = new double[Length];
        double[] nativeSlowD = new double[Length];

        int nativeCode = NativeTaLib.Stoch(
            StartIdx,
            EndIdx,
            Series.Doubles.High,
            Series.Doubles.Low,
            Series.Doubles.Close,
            StochFastK,
            StochSlowK,
            (int)MAType.Sma,
            StochSlowD,
            (int)MAType.Sma,
            out int nativeBeg,
            out int nativeCount,
            nativeSlowK,
            nativeSlowD);

        EnsureSucceeded("STOCH", nativeCode == NativeTaLib.Success, isManaged: false);

        NativeEquivalence.AssertEquivalent(
            "STOCH (slowK)",
            managedBeg,
            managedCount,
            managedSlowK,
            nativeBeg,
            nativeCount,
            nativeSlowK);
        NativeEquivalence.AssertEquivalent(
            "STOCH (slowD)",
            managedBeg,
            managedCount,
            managedSlowD,
            nativeBeg,
            nativeCount,
            nativeSlowD);
    }

    private void VerifySingleOutput(string indicator, SingleOutputInvoker managed, SingleOutputInvoker @native)
    {
        double[] managedBuffer = new double[Length];
        double[] nativeBuffer = new double[Length];

        EnsureSucceeded(indicator, managed(out int managedBeg, out int managedCount, managedBuffer), isManaged: true);
        EnsureSucceeded(indicator, @native(out int nativeBeg, out int nativeCount, nativeBuffer), isManaged: false);

        NativeEquivalence.AssertEquivalent(
            indicator,
            managedBeg,
            managedCount,
            managedBuffer,
            nativeBeg,
            nativeCount,
            nativeBuffer);
    }

    private static void EnsureSucceeded(string indicator, bool succeeded, bool isManaged)
    {
        if (succeeded)
        {
            return;
        }

        throw new InvalidOperationException(
            $"{indicator}: the {(isManaged ? "managed" : "native")} implementation reported a failure during the " +
            "equivalence check, so no timing can be trusted.");
    }

    /// <summary>
    /// Invokes one single-output indicator into the supplied buffer.
    /// </summary>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="buffer">The caller-allocated output buffer.</param>
    /// <returns><see langword="true"/> when the call succeeded.</returns>
    private delegate bool SingleOutputInvoker(out int outBegIdx, out int outNbElement, double[] buffer);
}
