// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Strategies;

/// <summary>
/// A volatility breakout strategy: it trades <em>with</em> a close that escapes the Bollinger envelope, and
/// gives the position back when price returns to the middle band.
/// </summary>
/// <remarks>
/// <para><b>Entry (long).</b> On the bar where the close breaks above the upper band having been at or below
/// it on the previous bar — a move large enough to be unlikely under the recent volatility regime. Filled at
/// the next open.</para>
/// <para><b>Entry (short).</b> On the bar where the close breaks below the lower band having been at or above
/// it on the previous bar. Downgraded to a flat position when the account forbids shorting.</para>
/// <para><b>Exit (long).</b> When the close falls back to or below the middle band (the moving average), the
/// breakout is considered failed or spent.</para>
/// <para><b>Exit (short).</b> When the close rises back to or above the middle band.</para>
/// <para><b>Warm-up.</b> <c>timePeriod + 1</c> bars, because entries compare the close to the bands on two
/// consecutive bars.</para>
/// <para><b>Note.</b> This is the breakout reading of the bands, the opposite of the more common
/// "fade the band" mean-reversion reading. Running it alongside <see cref="RsiMeanReversionStrategy"/> in the
/// sample makes the difference between the two philosophies visible on the same data.</para>
/// </remarks>
public sealed class BollingerBreakoutStrategy : IStrategy
{
    private readonly int _timePeriod;
    private readonly double _deviations;
    private BollingerBandSeries? _bands;

    /// <summary>
    /// Initializes a new instance of the <see cref="BollingerBreakoutStrategy"/> class.
    /// </summary>
    /// <param name="timePeriod">The moving-average period of the bands, in bars. Defaults to <c>20</c>.</param>
    /// <param name="deviations">The number of standard deviations for both bands. Defaults to <c>2</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException">The period is below 2, or the deviation count is not strictly positive.</exception>
    public BollingerBreakoutStrategy(int timePeriod = 20, double deviations = 2.0)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 2);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(deviations);

        _timePeriod = timePeriod;
        _deviations = deviations;
    }

    /// <inheritdoc />
    public string Name => string.Format(CultureInfo.InvariantCulture, "BBands {0}/{1} breakout", _timePeriod, _deviations);

    /// <inheritdoc />
    public string Description => string.Format(
        CultureInfo.InvariantCulture,
        "Buy a close breaking above the upper {0}-sigma band of BBANDS({1}), sell short below the lower band, exit at the middle band.",
        _deviations,
        _timePeriod);

    /// <inheritdoc />
    public void Initialize(IIndicatorSource indicators)
    {
        ArgumentNullException.ThrowIfNull(indicators);

        _bands = indicators.BollingerBands(_timePeriod, _deviations, _deviations);
    }

    /// <inheritdoc />
    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        ArgumentNullException.ThrowIfNull(bars);

        if (_bands is null)
        {
            throw new InvalidOperationException("Initialize must be called before Evaluate.");
        }

        int i = bars.CurrentIndex;
        if (i < 1)
        {
            return Signal.Hold;
        }

        if (!_bands.Upper.TryGetPair(i, out double previousUpper, out double currentUpper)
            || !_bands.Lower.TryGetPair(i, out double previousLower, out double currentLower)
            || !_bands.Middle.TryGetValue(i, out double currentMiddle))
        {
            return Signal.Hold;
        }

        double previousClose = bars.Ago(1).Close;
        double currentClose = bars.Current.Close;

        if (previousClose <= previousUpper && currentClose > currentUpper)
        {
            return Signal.EnterLong;
        }

        if (previousClose >= previousLower && currentClose < currentLower)
        {
            return Signal.EnterShort;
        }

        if (position is null)
        {
            return Signal.Hold;
        }

        bool longFaded = position.IsLong && currentClose <= currentMiddle;
        bool shortFaded = position.IsShort && currentClose >= currentMiddle;

        return longFaded || shortFaded ? Signal.Exit : Signal.Hold;
    }
}
