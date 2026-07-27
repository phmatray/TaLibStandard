// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Strategies;

/// <summary>
/// The classic golden-cross / death-cross trend follower, built on two simple moving averages of the close.
/// </summary>
/// <remarks>
/// <para><b>Entry (long) — golden cross.</b> On the bar where the fast SMA closes above the slow SMA having
/// been at or below it on the previous bar, target a long position. The fill happens at the next bar's open.</para>
/// <para><b>Entry (short) — death cross.</b> On the bar where the fast SMA closes below the slow SMA having
/// been at or above it on the previous bar, target a short position. When the account forbids shorting the
/// engine downgrades this to a flat position, which turns the rule into the familiar long-only crossover.</para>
/// <para><b>Exit.</b> There is no separate exit rule: the position is always reversed by the opposite cross,
/// so the strategy is continuously in the market once the slow average has warmed up.</para>
/// <para><b>Warm-up.</b> No signal is produced until both averages have a value on the current <em>and</em>
/// the previous bar, which takes <c>slowPeriod</c> bars.</para>
/// </remarks>
public sealed class SmaCrossoverStrategy : IStrategy
{
    private readonly int _fastPeriod;
    private readonly int _slowPeriod;
    private IndicatorSeries? _fast;
    private IndicatorSeries? _slow;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmaCrossoverStrategy"/> class.
    /// </summary>
    /// <param name="fastPeriod">The period of the fast moving average, in bars. Defaults to <c>50</c>.</param>
    /// <param name="slowPeriod">The period of the slow moving average, in bars. Defaults to <c>200</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException">A period is below 1, or the fast period is not shorter than the slow one.</exception>
    public SmaCrossoverStrategy(int fastPeriod = 50, int slowPeriod = 200)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(fastPeriod, 1);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(slowPeriod, fastPeriod);

        _fastPeriod = fastPeriod;
        _slowPeriod = slowPeriod;
    }

    /// <inheritdoc />
    public string Name => string.Format(CultureInfo.InvariantCulture, "SMA {0}/{1}", _fastPeriod, _slowPeriod);

    /// <inheritdoc />
    public string Description => string.Format(
        CultureInfo.InvariantCulture,
        "Long on the golden cross (SMA{0} crossing above SMA{1}), short on the death cross. Always in the market after warm-up.",
        _fastPeriod,
        _slowPeriod);

    /// <inheritdoc />
    public void Initialize(IIndicatorSource indicators)
    {
        ArgumentNullException.ThrowIfNull(indicators);

        _fast = indicators.Sma(_fastPeriod);
        _slow = indicators.Sma(_slowPeriod);
    }

    /// <inheritdoc />
    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        ArgumentNullException.ThrowIfNull(bars);

        if (_fast is null || _slow is null)
        {
            throw new InvalidOperationException("Initialize must be called before Evaluate.");
        }

        int i = bars.CurrentIndex;
        if (!_fast.TryGetPair(i, out double previousFast, out double currentFast)
            || !_slow.TryGetPair(i, out double previousSlow, out double currentSlow))
        {
            return Signal.Hold;
        }

        bool crossedUp = previousFast <= previousSlow && currentFast > currentSlow;
        if (crossedUp)
        {
            return Signal.EnterLong;
        }

        bool crossedDown = previousFast >= previousSlow && currentFast < currentSlow;
        if (crossedDown)
        {
            return Signal.EnterShort;
        }

        return Signal.Hold;
    }
}
