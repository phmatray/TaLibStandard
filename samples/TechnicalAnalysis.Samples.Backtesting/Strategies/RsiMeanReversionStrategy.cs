// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Strategies;

/// <summary>
/// A counter-trend strategy that fades exhaustion: it buys when the Relative Strength Index climbs back out
/// of oversold territory and sells when it falls back out of overbought territory.
/// </summary>
/// <remarks>
/// <para><b>Entry (long).</b> On the bar where the RSI closes above <c>oversoldLevel</c> having been at or
/// below it on the previous bar — the momentum of the sell-off has broken. Filled at the next open.</para>
/// <para><b>Entry (short).</b> On the bar where the RSI closes below <c>overboughtLevel</c> having been at or
/// above it on the previous bar. Downgraded to a flat position when the account forbids shorting.</para>
/// <para><b>Exit (long).</b> When the RSI closes at or above <c>exitLevel</c> (50 by default): the reversion
/// to the mean has played out. Long positions are also reversed by a short entry.</para>
/// <para><b>Exit (short).</b> When the RSI closes at or below <c>exitLevel</c>.</para>
/// <para><b>Warm-up.</b> <c>timePeriod + 1</c> bars, because the rules compare the RSI on two consecutive
/// bars.</para>
/// </remarks>
public sealed class RsiMeanReversionStrategy : IStrategy
{
    private readonly int _timePeriod;
    private readonly double _oversoldLevel;
    private readonly double _overboughtLevel;
    private readonly double _exitLevel;
    private IndicatorSeries? _rsi;

    /// <summary>
    /// Initializes a new instance of the <see cref="RsiMeanReversionStrategy"/> class.
    /// </summary>
    /// <param name="timePeriod">The RSI period in bars. Defaults to <c>14</c>.</param>
    /// <param name="oversoldLevel">The RSI level below which the market is considered oversold. Defaults to <c>30</c>.</param>
    /// <param name="overboughtLevel">The RSI level above which the market is considered overbought. Defaults to <c>70</c>.</param>
    /// <param name="exitLevel">The RSI level at which an open position is closed. Defaults to <c>50</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The period is below 1, or the levels are not ordered
    /// <c>0 &lt; oversold &lt; overbought &lt; 100</c>, or the exit level lies outside the two.
    /// </exception>
    public RsiMeanReversionStrategy(
        int timePeriod = 14,
        double oversoldLevel = 30.0,
        double overboughtLevel = 70.0,
        double exitLevel = 50.0)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 1);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(oversoldLevel);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(overboughtLevel, oversoldLevel);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(overboughtLevel, 100.0);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(exitLevel, oversoldLevel);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(exitLevel, overboughtLevel);

        _timePeriod = timePeriod;
        _oversoldLevel = oversoldLevel;
        _overboughtLevel = overboughtLevel;
        _exitLevel = exitLevel;
    }

    /// <inheritdoc />
    public string Name => string.Format(CultureInfo.InvariantCulture, "RSI {0} reversion", _timePeriod);

    /// <inheritdoc />
    public string Description => string.Format(
        CultureInfo.InvariantCulture,
        "Buy when RSI({0}) crosses back above {1}, sell short when it crosses back below {2}, flatten at {3}.",
        _timePeriod,
        _oversoldLevel,
        _overboughtLevel,
        _exitLevel);

    /// <inheritdoc />
    public void Initialize(IIndicatorSource indicators)
    {
        ArgumentNullException.ThrowIfNull(indicators);

        _rsi = indicators.Rsi(_timePeriod);
    }

    /// <inheritdoc />
    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        ArgumentNullException.ThrowIfNull(bars);

        if (_rsi is null)
        {
            throw new InvalidOperationException("Initialize must be called before Evaluate.");
        }

        int i = bars.CurrentIndex;
        if (!_rsi.TryGetPair(i, out double previous, out double current))
        {
            return Signal.Hold;
        }

        if (previous <= _oversoldLevel && current > _oversoldLevel)
        {
            return Signal.EnterLong;
        }

        if (previous >= _overboughtLevel && current < _overboughtLevel)
        {
            return Signal.EnterShort;
        }

        if (position is null)
        {
            return Signal.Hold;
        }

        bool longTargetReached = position.IsLong && current >= _exitLevel;
        bool shortTargetReached = position.IsShort && current <= _exitLevel;

        return longTargetReached || shortTargetReached ? Signal.Exit : Signal.Hold;
    }
}
