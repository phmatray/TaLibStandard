// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The factory a strategy uses to declare the indicators it needs, once, before the backtest starts.
/// </summary>
/// <remarks>
/// <para>
/// Indicators are computed a single time over the <em>whole</em> series — which is both far faster than a
/// rolling recomputation and numerically identical to what TA-Lib would produce on a live feed, because every
/// function in the library is causal. The results are then handed back as <see cref="IndicatorSeries"/>
/// instances that are bound to the engine's bar cursor, so reading them ahead of the current bar throws.
/// </para>
/// <para>
/// Note what this interface deliberately does <em>not</em> offer: any way to obtain the raw price arrays.
/// A strategy is given indicator series and an <see cref="IBarWindow"/>, and neither of them can be
/// persuaded to reveal a future bar. That is what makes the no-look-ahead guarantee structural.
/// </para>
/// </remarks>
public interface IIndicatorSource
{
    /// <summary>
    /// Creates a Simple Moving Average of the close prices.
    /// </summary>
    /// <param name="timePeriod">The averaging period in bars.</param>
    /// <returns>The aligned SMA series.</returns>
    IndicatorSeries Sma(int timePeriod);

    /// <summary>
    /// Creates an Exponential Moving Average of the close prices.
    /// </summary>
    /// <param name="timePeriod">The smoothing period in bars.</param>
    /// <returns>The aligned EMA series.</returns>
    IndicatorSeries Ema(int timePeriod);

    /// <summary>
    /// Creates a Relative Strength Index of the close prices.
    /// </summary>
    /// <param name="timePeriod">The RSI period in bars.</param>
    /// <returns>The aligned RSI series, valued in <c>[0, 100]</c>.</returns>
    IndicatorSeries Rsi(int timePeriod);

    /// <summary>
    /// Creates an Average True Range from the high, low and close prices.
    /// </summary>
    /// <param name="timePeriod">The ATR period in bars.</param>
    /// <returns>The aligned ATR series, expressed in price units.</returns>
    IndicatorSeries Atr(int timePeriod);

    /// <summary>
    /// Creates a Moving Average Convergence Divergence of the close prices.
    /// </summary>
    /// <param name="fastPeriod">The fast EMA period in bars.</param>
    /// <param name="slowPeriod">The slow EMA period in bars.</param>
    /// <param name="signalPeriod">The signal EMA period in bars.</param>
    /// <returns>The aligned MACD line, signal line and histogram.</returns>
    MacdSeries Macd(int fastPeriod, int slowPeriod, int signalPeriod);

    /// <summary>
    /// Creates Bollinger Bands around a simple moving average of the close prices.
    /// </summary>
    /// <param name="timePeriod">The moving-average period in bars.</param>
    /// <param name="deviationsUp">The number of standard deviations for the upper band.</param>
    /// <param name="deviationsDown">The number of standard deviations for the lower band.</param>
    /// <returns>The aligned upper, middle and lower bands.</returns>
    BollingerBandSeries BollingerBands(int timePeriod, double deviationsUp, double deviationsDown);
}
