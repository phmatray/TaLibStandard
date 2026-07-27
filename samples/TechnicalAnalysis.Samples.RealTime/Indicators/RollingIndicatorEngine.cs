// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;
using TechnicalAnalysis.Samples.RealTime.Configuration;
using TechnicalAnalysis.Samples.RealTime.Contracts;

namespace TechnicalAnalysis.Samples.RealTime.Indicators;

/// <summary>
/// Keeps the last N closed bars for one symbol and, on every new bar, recomputes each indicator over that
/// window and publishes the latest value of each.
/// </summary>
/// <remarks>
/// <para><strong>Why recompute a window instead of updating incrementally</strong></para>
/// <para>
/// TA-Lib is a batch API: every function takes a whole array and returns a whole array. Streaming code has
/// two ways to live with that.
/// </para>
/// <para>
/// The first is a true incremental update: keep each indicator's internal state — a running sum for SMA,
/// the previous value and smoothing factor for EMA, Wilder's averages for RSI and ATR — and advance it by
/// one bar. That is O(1) per bar and per indicator, and it is what a production feed handler does. It also
/// means reimplementing, and then keeping in step with, the exact arithmetic of every indicator you use.
/// The moment your EMA seeding or your RSI smoothing differs from TA-Lib's by an epsilon, your live values
/// and your backtest values quietly disagree, and that difference is very hard to find later.
/// </para>
/// <para>
/// The second, used here, is to recompute over a fixed trailing window. It costs O(window) per indicator
/// per bar, which for a 256-bar window and seven indicators is a few microseconds — nothing next to one
/// bar per second, and nothing next to the network hop that follows. In exchange, the number a client sees
/// is produced by the same library, on the same code path, as the number a backtest sees. For a sample
/// whose entire point is showing TaLibStandard used correctly, that equivalence is worth far more than
/// the saved cycles. Reach for incremental state when the bar rate or the symbol count makes the window
/// recompute show up in a profile, and then pin it with tests against these values.
/// </para>
/// <para><strong>Window size versus the largest lookback</strong></para>
/// <para>
/// The window must be strictly larger than the slowest indicator's lookback, or that indicator never
/// produces a value. With the defaults the lookbacks are: SMA(30) needs 30 bars, EMA(20) 20, RSI(14) 15,
/// Bollinger(20) 20, ATR(14) 15, and MACD(12,26,9) 34 — the slow EMA's 26 bars plus the signal EMA's 9,
/// less one. So 34 bars is the floor, exposed as <see cref="BarsRequired"/>.
/// </para>
/// <para>
/// The default window is 256, roughly seven times that floor, and the margin is deliberate. Indicators
/// with exponential smoothing have no exact finite lookback: TA-Lib's EMA seeds itself with a simple
/// average of the first period and then decays, so an EMA computed over the last 34 bars is not the same
/// number as an EMA computed over the last 5000 — the difference is the seed's residual weight, which
/// decays by a factor of (1 - 2/(n+1)) per bar. At 256 bars an EMA(20) retains about
/// (1 - 2/21)^236 ≈ 4e-11 of its seed, which is far below display precision. A window of 40 would not be:
/// it would produce plausible-looking values that drift from the batch answer. Choose the window from the
/// slowest smoothed indicator's decay, not from its nominal period.
/// </para>
/// <para>This type is not thread safe; each symbol gets its own instance driven by the pipeline loop.</para>
/// </remarks>
public sealed class RollingIndicatorEngine
{
    private readonly string _symbol;
    private readonly IndicatorOptions _settings;
    private readonly int _capacity;

    // Ring storage. _next is where the following bar is written; _count saturates at _capacity.
    private readonly double[] _ringHigh;
    private readonly double[] _ringLow;
    private readonly double[] _ringClose;
    private int _next;
    private int _count;

    // Chronological scratch buffers handed to TA-Lib. They stay at capacity length for the life of the
    // engine, so the steady state allocates nothing here; TA-Lib only ever reads indices [0, endIdx].
    private readonly double[] _windowHigh;
    private readonly double[] _windowLow;
    private readonly double[] _windowClose;

    private long _sequence;

    /// <summary>
    /// Initializes a new instance of the <see cref="RollingIndicatorEngine"/> class.
    /// </summary>
    /// <param name="symbol">The symbol this engine tracks.</param>
    /// <param name="windowSize">How many closed bars to keep.</param>
    /// <param name="settings">The indicator periods to use.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The window is not larger than the slowest indicator's lookback.
    /// </exception>
    public RollingIndicatorEngine(string symbol, int windowSize, IndicatorOptions settings)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        ArgumentNullException.ThrowIfNull(settings);

        _symbol = symbol;
        _settings = settings;
        _capacity = windowSize;
        BarsRequired = LargestLookback(settings) + 1;

        ArgumentOutOfRangeException.ThrowIfLessThan(windowSize, BarsRequired);

        _ringHigh = new double[windowSize];
        _ringLow = new double[windowSize];
        _ringClose = new double[windowSize];
        _windowHigh = new double[windowSize];
        _windowLow = new double[windowSize];
        _windowClose = new double[windowSize];
    }

    /// <summary>
    /// Gets the number of bars the slowest configured indicator needs before it yields its first value.
    /// </summary>
    public int BarsRequired { get; }

    /// <summary>
    /// Computes the number of bars of history the slowest configured indicator consumes before producing
    /// a value, expressed as a TA-Lib lookback (values start at input index <c>lookback</c>).
    /// </summary>
    /// <param name="settings">The indicator periods.</param>
    /// <returns>The largest lookback across the configured indicators.</returns>
    public static int LargestLookback(IndicatorOptions settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        // TA-Lib swaps the two MACD periods internally when the "fast" one is the longer of the pair, so the
        // lookback is driven by the larger period, not by whichever field is named Slow. Reading the field
        // name instead would under-report BarsRequired for a swapped configuration and let the startup
        // window check pass with a window too small for MACD ever to print.
        int macdSlow = Math.Max(settings.MacdFastPeriod, settings.MacdSlowPeriod);

        // These mirror TA-Lib's own lookback functions: a moving average consumes period - 1 bars, while
        // Wilder-smoothed RSI and ATR consume a full period, and MACD stacks the slow EMA's lookback on
        // top of the signal EMA's.
        int[] lookbacks =
        [
            settings.SmaFastPeriod - 1,
            settings.SmaSlowPeriod - 1,
            settings.EmaPeriod - 1,
            settings.RsiPeriod,
            macdSlow - 1 + (settings.MacdSignalPeriod - 1),
            settings.BollingerPeriod - 1,
            settings.AtrPeriod
        ];

        return lookbacks.Max();
    }

    /// <summary>
    /// Adds a closed bar and recomputes every indicator over the resulting window.
    /// </summary>
    /// <param name="bar">The bar that just closed.</param>
    /// <returns>The snapshot describing that bar.</returns>
    public IndicatorSnapshot Update(Bar bar)
    {
        ArgumentNullException.ThrowIfNull(bar);

        Append(bar);
        Materialize();

        // The window is a plain chronological array now, so the newest bar sits at index _count - 1 and
        // every TA-Lib call below runs over [0, lastIndex].
        int lastIndex = _count - 1;
        _sequence++;

        double? smaFast = Latest(TAMath.Sma(0, lastIndex, _windowClose, _settings.SmaFastPeriod), lastIndex);
        double? smaSlow = Latest(TAMath.Sma(0, lastIndex, _windowClose, _settings.SmaSlowPeriod), lastIndex);
        double? ema = Latest(TAMath.Ema(0, lastIndex, _windowClose, _settings.EmaPeriod), lastIndex);
        double? rsi = Latest(TAMath.Rsi(0, lastIndex, _windowClose, _settings.RsiPeriod), lastIndex);
        double? atr = Latest(
            TAMath.Atr(0, lastIndex, _windowHigh, _windowLow, _windowClose, _settings.AtrPeriod),
            lastIndex);

        MacdResult macd = TAMath.Macd(
            0,
            lastIndex,
            _windowClose,
            _settings.MacdFastPeriod,
            _settings.MacdSlowPeriod,
            _settings.MacdSignalPeriod);

        double? macdValue = Latest(macd, macd.MacdValue, lastIndex);
        double? macdSignal = Latest(macd, macd.MacdSignal, lastIndex);
        double? macdHistogram = Latest(macd, macd.MacdHist, lastIndex);

        BollingerBandsResult bands = TAMath.BollingerBands(
            0,
            lastIndex,
            _windowClose,
            _settings.BollingerPeriod,
            _settings.BollingerDeviations,
            _settings.BollingerDeviations);

        double? upper = Latest(bands, bands.RealUpperBand, lastIndex);
        double? middle = Latest(bands, bands.RealMiddleBand, lastIndex);
        double? lower = Latest(bands, bands.RealLowerBand, lastIndex);

        Signal signal = Classify(rsi, smaFast, smaSlow, macdHistogram);

        return new IndicatorSnapshot(
            _symbol,
            bar.Timestamp,
            bar.Close,
            _sequence,
            smaFast,
            smaSlow,
            ema,
            rsi,
            macdValue,
            macdSignal,
            macdHistogram,
            upper,
            middle,
            lower,
            atr,
            signal,
            _count,
            BarsRequired);
    }

    /// <summary>
    /// Extracts the value a single-output TA-Lib result holds for the newest input bar.
    /// </summary>
    /// <param name="result">The result returned by TAMath.</param>
    /// <param name="lastInputIndex">The index, in the input array, of the newest bar.</param>
    /// <returns>The newest value, or <see langword="null"/> if the indicator has not warmed up.</returns>
    private static double? Latest(SingleOutputResult result, int lastInputIndex)
        => Latest(result, result.Real, lastInputIndex);

    /// <summary>
    /// Extracts the value one output array of a TA-Lib result holds for the newest input bar.
    /// </summary>
    /// <remarks>
    /// <para><strong>This is the alignment rule, and getting it wrong shifts every signal in time.</strong></para>
    /// <para>
    /// TAMath allocates an output array of <c>endIdx - startIdx + 1</c> elements and fills it from index
    /// zero. The output is not parallel to the input. Output element <c>k</c> describes input index
    /// <c>BegIdx + k</c>, for <c>k</c> in <c>[0, NBElement)</c>; every element from <c>NBElement</c>
    /// onwards is an uninitialised zero that means nothing.
    /// </para>
    /// <para>
    /// So the newest value is <c>output[NBElement - 1]</c> — never <c>output[lastInputIndex]</c>, which
    /// with a 256-bar window and a 30-bar lookback would read 29 elements past the end of the real data
    /// and hand back a zero dressed up as a price. The mapping is asserted rather than assumed: the value
    /// is returned only when <c>BegIdx + NBElement - 1</c> really is the newest bar's index.
    /// </para>
    /// </remarks>
    /// <param name="result">The result returned by TAMath.</param>
    /// <param name="output">The specific output array to read.</param>
    /// <param name="lastInputIndex">The index, in the input array, of the newest bar.</param>
    /// <returns>The newest value, or <see langword="null"/> if the indicator has not warmed up.</returns>
    private static double? Latest(IndicatorResult result, double[] output, int lastInputIndex)
    {
        if (result.RetCode != RetCode.Success || result.NBElement <= 0)
        {
            return null;
        }

        int newestOutputIndex = result.NBElement - 1;
        int newestInputIndex = result.BegIdx + newestOutputIndex;

        if (newestInputIndex != lastInputIndex || newestOutputIndex >= output.Length)
        {
            // The indicator did not cover the newest bar. Returning the previous bar's value here is the
            // classic streaming bug: it looks like data and is silently one bar stale.
            return null;
        }

        double value = output[newestOutputIndex];
        return double.IsFinite(value) ? value : null;
    }

    /// <summary>
    /// Derives the sample's combined read. Every input is optional, and any missing input degrades the
    /// answer to <see cref="Signal.Neutral"/> rather than guessing.
    /// </summary>
    private Signal Classify(double? rsi, double? smaFast, double? smaSlow, double? macdHistogram)
    {
        if (rsi is { } rsiValue)
        {
            if (rsiValue >= _settings.RsiOverbought)
            {
                return Signal.Overbought;
            }

            if (rsiValue <= _settings.RsiOversold)
            {
                return Signal.Oversold;
            }
        }

        if (smaFast is not { } fast || smaSlow is not { } slow || macdHistogram is not { } histogram)
        {
            return Signal.Neutral;
        }

        if (fast > slow && histogram > 0.0)
        {
            return Signal.Bullish;
        }

        if (fast < slow && histogram < 0.0)
        {
            return Signal.Bearish;
        }

        return Signal.Neutral;
    }

    /// <summary>
    /// Writes a bar into the ring, overwriting the oldest once the window is full.
    /// </summary>
    private void Append(Bar bar)
    {
        _ringHigh[_next] = (double)bar.High;
        _ringLow[_next] = (double)bar.Low;
        _ringClose[_next] = (double)bar.Close;

        _next = (_next + 1) % _capacity;
        if (_count < _capacity)
        {
            _count++;
        }
    }

    /// <summary>
    /// Copies the ring into the scratch buffers in chronological order, oldest first.
    /// </summary>
    /// <remarks>
    /// TA-Lib needs contiguous ascending input, so the ring is unrolled with at most two block copies:
    /// the tail of the ring, then its head. Both are <c>Array.Copy</c>, which is a memmove.
    /// </remarks>
    private void Materialize()
    {
        if (_count < _capacity)
        {
            // Not wrapped yet: the ring is already chronological from index 0.
            Array.Copy(_ringHigh, _windowHigh, _count);
            Array.Copy(_ringLow, _windowLow, _count);
            Array.Copy(_ringClose, _windowClose, _count);
            return;
        }

        int oldest = _next;
        int tail = _capacity - oldest;

        Array.Copy(_ringHigh, oldest, _windowHigh, 0, tail);
        Array.Copy(_ringLow, oldest, _windowLow, 0, tail);
        Array.Copy(_ringClose, oldest, _windowClose, 0, tail);

        Array.Copy(_ringHigh, 0, _windowHigh, tail, oldest);
        Array.Copy(_ringLow, 0, _windowLow, tail, oldest);
        Array.Copy(_ringClose, 0, _windowClose, tail, oldest);
    }
}
