// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The default <see cref="IIndicatorSource"/>. It extracts the OHLC arrays once, calls the TA-Lib wrappers in
/// <c>TAMath</c> over the whole series, and re-indexes every output through <see cref="IndicatorSeries"/>.
/// </summary>
/// <remarks>
/// Requests are memoised by name and parameters, so a strategy asking twice for <c>SMA(50)</c> pays for one
/// computation. The price arrays are private and are never handed out — see <see cref="IIndicatorSource"/>
/// for why that matters.
/// </remarks>
public sealed class IndicatorSet : IIndicatorSource
{
    private readonly Dictionary<string, object> _cache = new(StringComparer.Ordinal);
    private readonly double[] _open;
    private readonly double[] _high;
    private readonly double[] _low;
    private readonly double[] _close;
    private readonly IBarWindow? _window;

    /// <summary>
    /// Initializes a new instance of the <see cref="IndicatorSet"/> class.
    /// </summary>
    /// <param name="bars">The full bar series the indicators are computed over.</param>
    /// <param name="window">
    /// The bar window every produced series is bound to, or <see langword="null"/> to produce unguarded
    /// series (unit tests only).
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="bars"/> is <see langword="null"/>.</exception>
    public IndicatorSet(IReadOnlyList<Bar> bars, IBarWindow? window)
    {
        ArgumentNullException.ThrowIfNull(bars);

        _window = window;
        BarCount = bars.Count;
        _open = new double[BarCount];
        _high = new double[BarCount];
        _low = new double[BarCount];
        _close = new double[BarCount];

        for (int i = 0; i < BarCount; i++)
        {
            Bar bar = bars[i];
            _open[i] = bar.Open;
            _high[i] = bar.High;
            _low[i] = bar.Low;
            _close[i] = bar.Close;
        }
    }

    /// <summary>
    /// Gets the number of bars the indicators span.
    /// </summary>
    public int BarCount { get; }

    /// <inheritdoc />
    public IndicatorSeries Sma(int timePeriod)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 1);

        return GetOrAdd(
            Key("SMA", timePeriod),
            key =>
            {
                if (BarCount == 0)
                {
                    return Empty(key);
                }

                SmaResult result = TAMath.Sma(0, BarCount - 1, _close, timePeriod);
                return Wrap(key, result, result.Real);
            });
    }

    /// <inheritdoc />
    public IndicatorSeries Ema(int timePeriod)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 1);

        return GetOrAdd(
            Key("EMA", timePeriod),
            key =>
            {
                if (BarCount == 0)
                {
                    return Empty(key);
                }

                EmaResult result = TAMath.Ema(0, BarCount - 1, _close, timePeriod);
                return Wrap(key, result, result.Real);
            });
    }

    /// <inheritdoc />
    public IndicatorSeries Rsi(int timePeriod)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 1);

        return GetOrAdd(
            Key("RSI", timePeriod),
            key =>
            {
                if (BarCount == 0)
                {
                    return Empty(key);
                }

                RsiResult result = TAMath.Rsi(0, BarCount - 1, _close, timePeriod);
                return Wrap(key, result, result.Real);
            });
    }

    /// <inheritdoc />
    public IndicatorSeries Atr(int timePeriod)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 1);

        return GetOrAdd(
            Key("ATR", timePeriod),
            key =>
            {
                if (BarCount == 0)
                {
                    return Empty(key);
                }

                AtrResult result = TAMath.Atr(0, BarCount - 1, _high, _low, _close, timePeriod);
                return Wrap(key, result, result.Real);
            });
    }

    /// <inheritdoc />
    public MacdSeries Macd(int fastPeriod, int slowPeriod, int signalPeriod)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(fastPeriod, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(slowPeriod, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(signalPeriod, 1);

        string key = Key("MACD", fastPeriod, slowPeriod, signalPeriod);
        if (_cache.TryGetValue(key, out object? cached))
        {
            return (MacdSeries)cached;
        }

        MacdSeries series;
        if (BarCount == 0)
        {
            series = new MacdSeries(Empty(key + ".line"), Empty(key + ".signal"), Empty(key + ".hist"));
        }
        else
        {
            MacdResult result = TAMath.Macd(0, BarCount - 1, _close, fastPeriod, slowPeriod, signalPeriod);
            series = new MacdSeries(
                Wrap(key + ".line", result, result.MacdValue),
                Wrap(key + ".signal", result, result.MacdSignal),
                Wrap(key + ".hist", result, result.MacdHist));
        }

        _cache[key] = series;
        return series;
    }

    /// <inheritdoc />
    public BollingerBandSeries BollingerBands(int timePeriod, double deviationsUp, double deviationsDown)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timePeriod, 1);

        string key = string.Format(
            CultureInfo.InvariantCulture,
            "BBANDS({0},{1},{2})",
            timePeriod,
            deviationsUp,
            deviationsDown);

        if (_cache.TryGetValue(key, out object? cached))
        {
            return (BollingerBandSeries)cached;
        }

        BollingerBandSeries series;
        if (BarCount == 0)
        {
            series = new BollingerBandSeries(Empty(key + ".upper"), Empty(key + ".middle"), Empty(key + ".lower"));
        }
        else
        {
            BollingerBandsResult result = TAMath.BollingerBands(
                0,
                BarCount - 1,
                _close,
                timePeriod,
                deviationsUp,
                deviationsDown,
                MAType.Sma);

            series = new BollingerBandSeries(
                Wrap(key + ".upper", result, result.RealUpperBand),
                Wrap(key + ".middle", result, result.RealMiddleBand),
                Wrap(key + ".lower", result, result.RealLowerBand));
        }

        _cache[key] = series;
        return series;
    }

    private static string Key(string name, params int[] parameters)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0}({1})",
            name,
            string.Join(',', parameters));
    }

    private IndicatorSeries Wrap(string name, IndicatorResult result, double[] output)
    {
        // A non-success return code means TA-Lib produced nothing usable. Modelling that as a series with
        // zero valid elements lets a strategy simply stay flat instead of trading on garbage.
        int nbElement = result.RetCode == RetCode.Success ? result.NBElement : 0;
        int begIdx = result.RetCode == RetCode.Success ? result.BegIdx : 0;

        return new IndicatorSeries(name, BarCount, begIdx, nbElement, output, _window);
    }

    private IndicatorSeries Empty(string name)
    {
        return new IndicatorSeries(name, BarCount, 0, 0, [], _window);
    }

    private IndicatorSeries GetOrAdd(string key, Func<string, IndicatorSeries> factory)
    {
        if (_cache.TryGetValue(key, out object? cached))
        {
            return (IndicatorSeries)cached;
        }

        IndicatorSeries series = factory(key);
        _cache[key] = series;
        return series;
    }
}
