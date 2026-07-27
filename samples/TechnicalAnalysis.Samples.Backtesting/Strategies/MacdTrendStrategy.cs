// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Strategies;

/// <summary>
/// A MACD trend follower with a volatility-scaled trailing stop, so that a trend that turns is exited on
/// price action rather than waiting for the slower momentum signal to reverse.
/// </summary>
/// <remarks>
/// <para><b>Entry (long).</b> On the bar where the MACD line closes above its signal line having been at or
/// below it on the previous bar. Filled at the next open.</para>
/// <para><b>Entry (short).</b> On the bar where the MACD line closes below its signal line having been at or
/// above it on the previous bar. Downgraded to a flat position when the account forbids shorting.</para>
/// <para><b>Exit — ATR trailing stop.</b> While long, the stop is <c>Close - atrMultiple * ATR(period)</c>
/// recomputed on every bar and ratcheted upwards only, so it never loosens. The position is closed on the
/// first bar whose close is at or below the stop. While short the stop is
/// <c>Close + atrMultiple * ATR(period)</c>, ratcheted downwards only, and the position is closed on the
/// first close at or above it. The stop is evaluated on closes, not intrabar, because the engine only fills
/// at the next open — an intrabar stop would be a look-ahead fiction at this bar granularity.</para>
/// <para><b>Warm-up.</b> Governed by the MACD (<c>slowPeriod + signalPeriod</c> bars) and by the ATR
/// (<c>atrPeriod</c> bars); the trailing stop simply stays inactive until the ATR has a value.</para>
/// </remarks>
public sealed class MacdTrendStrategy : IStrategy
{
    private readonly int _fastPeriod;
    private readonly int _slowPeriod;
    private readonly int _signalPeriod;
    private readonly int _atrPeriod;
    private readonly double _atrMultiple;
    private MacdSeries? _macd;
    private IndicatorSeries? _atr;
    private double _trailingStop;
    private bool _stopArmed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MacdTrendStrategy"/> class.
    /// </summary>
    /// <param name="fastPeriod">The fast EMA period of the MACD, in bars. Defaults to <c>12</c>.</param>
    /// <param name="slowPeriod">The slow EMA period of the MACD, in bars. Defaults to <c>26</c>.</param>
    /// <param name="signalPeriod">The signal EMA period of the MACD, in bars. Defaults to <c>9</c>.</param>
    /// <param name="atrPeriod">The ATR period driving the trailing stop, in bars. Defaults to <c>14</c>.</param>
    /// <param name="atrMultiple">The number of ATRs the trailing stop sits away from the close. Defaults to <c>3</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// A period is below 1, the fast period is not shorter than the slow one, or the ATR multiple is not
    /// strictly positive.
    /// </exception>
    public MacdTrendStrategy(
        int fastPeriod = 12,
        int slowPeriod = 26,
        int signalPeriod = 9,
        int atrPeriod = 14,
        double atrMultiple = 3.0)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(fastPeriod, 1);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(slowPeriod, fastPeriod);
        ArgumentOutOfRangeException.ThrowIfLessThan(signalPeriod, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(atrPeriod, 1);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(atrMultiple);

        _fastPeriod = fastPeriod;
        _slowPeriod = slowPeriod;
        _signalPeriod = signalPeriod;
        _atrPeriod = atrPeriod;
        _atrMultiple = atrMultiple;
    }

    /// <inheritdoc />
    public string Name => string.Format(
        CultureInfo.InvariantCulture,
        "MACD {0}/{1}/{2} + {3}xATR",
        _fastPeriod,
        _slowPeriod,
        _signalPeriod,
        _atrMultiple);

    /// <inheritdoc />
    public string Description => string.Format(
        CultureInfo.InvariantCulture,
        "Trade MACD({0},{1},{2}) signal-line crossings, exited early by a {3}x ATR({4}) trailing stop on closes.",
        _fastPeriod,
        _slowPeriod,
        _signalPeriod,
        _atrMultiple,
        _atrPeriod);

    /// <inheritdoc />
    public void Initialize(IIndicatorSource indicators)
    {
        ArgumentNullException.ThrowIfNull(indicators);

        _macd = indicators.Macd(_fastPeriod, _slowPeriod, _signalPeriod);
        _atr = indicators.Atr(_atrPeriod);
        _trailingStop = 0.0;
        _stopArmed = false;
    }

    /// <inheritdoc />
    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        ArgumentNullException.ThrowIfNull(bars);

        if (_macd is null || _atr is null)
        {
            throw new InvalidOperationException("Initialize must be called before Evaluate.");
        }

        int i = bars.CurrentIndex;
        double close = bars.Current.Close;

        if (position is null)
        {
            _stopArmed = false;
        }
        else if (UpdateTrailingStopAndCheckBreach(position, i, close))
        {
            return Signal.Exit;
        }

        if (!_macd.Line.TryGetPair(i, out double previousLine, out double currentLine)
            || !_macd.Signal.TryGetPair(i, out double previousSignal, out double currentSignal))
        {
            return Signal.Hold;
        }

        if (previousLine <= previousSignal && currentLine > currentSignal)
        {
            _stopArmed = false;
            return Signal.EnterLong;
        }

        if (previousLine >= previousSignal && currentLine < currentSignal)
        {
            _stopArmed = false;
            return Signal.EnterShort;
        }

        return Signal.Hold;
    }

    private bool UpdateTrailingStopAndCheckBreach(Position position, int barIndex, double close)
    {
        if (_atr is null || !_atr.TryGetValue(barIndex, out double atr) || atr <= 0.0)
        {
            return false;
        }

        double candidate = position.IsLong
            ? close - (_atrMultiple * atr)
            : close + (_atrMultiple * atr);

        if (!_stopArmed)
        {
            _trailingStop = candidate;
            _stopArmed = true;
        }
        else
        {
            // Ratchet only in the favourable direction: a trailing stop never gives ground.
            _trailingStop = position.IsLong
                ? Math.Max(_trailingStop, candidate)
                : Math.Min(_trailingStop, candidate);
        }

        bool breached = position.IsLong ? close <= _trailingStop : close >= _trailingStop;
        if (breached)
        {
            _stopArmed = false;
        }

        return breached;
    }
}
