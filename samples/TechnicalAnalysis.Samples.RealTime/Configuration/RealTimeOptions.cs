// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.RealTime.Configuration;

/// <summary>
/// Everything the sample can be tuned with, bound from the <c>RealTime</c> section of appsettings.json.
/// </summary>
/// <remarks>
/// Every value can also be overridden on the command line, for example
/// <c>dotnet run -- --RealTime:BarSeconds=1 --RealTime:TickIntervalMilliseconds=100</c>, which is how the
/// README's quick demo shortens the warm-up.
/// </remarks>
public sealed class RealTimeOptions
{
    /// <summary>The configuration section this class binds to.</summary>
    public const string SectionName = "RealTime";

    /// <summary>
    /// Gets or sets the symbols the synthetic feed publishes. The first entry is the page's default.
    /// </summary>
    /// <remarks>
    /// This deliberately starts empty and is filled from appsettings.json. The configuration binder
    /// <em>appends</em> to a collection that already has items rather than replacing it, so a code-side
    /// default of three symbols plus three in configuration binds to six — each one duplicated, each with
    /// its own price walk. Startup validation rejects an empty list, so a missing configuration file is a
    /// clear failure rather than a silent one.
    /// </remarks>
    public string[] Symbols { get; set; } = [];

    /// <summary>
    /// Gets or sets the interval between synthetic ticks, in milliseconds.
    /// </summary>
    public int TickIntervalMilliseconds { get; set; } = 250;

    /// <summary>
    /// Gets or sets the bar period, in seconds. Ticks are folded into bars aligned to this period.
    /// </summary>
    public int BarSeconds { get; set; } = 5;

    /// <summary>
    /// Gets or sets the seed for the synthetic price walk. The same seed always produces the same price
    /// path, which is what makes this sample reproducible offline.
    /// </summary>
    public int RandomSeed { get; set; } = 20240613;

    /// <summary>
    /// Gets or sets the number of closed bars the rolling indicator window keeps per symbol.
    /// </summary>
    /// <remarks>
    /// Must comfortably exceed the slowest indicator's lookback. See
    /// <c>RollingIndicatorEngine</c> for why "comfortably" and not "just barely".
    /// </remarks>
    public int WindowSize { get; set; } = 256;

    /// <summary>
    /// Gets or sets how many items a single subscriber may fall behind by before the oldest ones are
    /// dropped. See <c>BoundedFanout{T}</c> for the backpressure policy this feeds.
    /// </summary>
    public int SubscriberQueueCapacity { get; set; } = 64;

    /// <summary>
    /// Gets or sets the per-tick log-return standard deviation of the synthetic walk. Larger values make
    /// the chart livelier; 0.0015 is roughly "a busy small cap".
    /// </summary>
    public double Volatility { get; set; } = 0.0015;

    /// <summary>
    /// Gets or sets the strength of the pull back towards a symbol's base price, per tick. Zero gives a
    /// pure random walk, which tends to drift off screen; a small positive value keeps the series in a
    /// readable range without flattening it.
    /// </summary>
    public double MeanReversion { get; set; } = 0.0025;

    /// <summary>
    /// Gets or sets the indicator periods used by the rolling engine.
    /// </summary>
    public IndicatorOptions Indicators { get; set; } = new();
}

/// <summary>
/// The indicator periods the rolling engine recomputes on every closed bar.
/// </summary>
/// <remarks>
/// Every period is passed straight through to <c>TAMath</c>, which rejects anything below 2 with
/// <c>RetCode.BadParam</c>. Options validation catches that at startup rather than per bar.
/// </remarks>
public sealed class IndicatorOptions
{
    /// <summary>Gets or sets the fast simple moving average period.</summary>
    public int SmaFastPeriod { get; set; } = 10;

    /// <summary>Gets or sets the slow simple moving average period.</summary>
    public int SmaSlowPeriod { get; set; } = 30;

    /// <summary>Gets or sets the exponential moving average period.</summary>
    public int EmaPeriod { get; set; } = 20;

    /// <summary>Gets or sets the relative strength index period.</summary>
    public int RsiPeriod { get; set; } = 14;

    /// <summary>Gets or sets the MACD fast period.</summary>
    public int MacdFastPeriod { get; set; } = 12;

    /// <summary>Gets or sets the MACD slow period.</summary>
    public int MacdSlowPeriod { get; set; } = 26;

    /// <summary>Gets or sets the MACD signal period.</summary>
    public int MacdSignalPeriod { get; set; } = 9;

    /// <summary>Gets or sets the Bollinger band period.</summary>
    public int BollingerPeriod { get; set; } = 20;

    /// <summary>Gets or sets the Bollinger band standard deviation multiplier.</summary>
    public double BollingerDeviations { get; set; } = 2.0;

    /// <summary>Gets or sets the average true range period.</summary>
    public int AtrPeriod { get; set; } = 14;

    /// <summary>Gets or sets the RSI level at or above which the signal reads overbought.</summary>
    public double RsiOverbought { get; set; } = 70.0;

    /// <summary>Gets or sets the RSI level at or below which the signal reads oversold.</summary>
    public double RsiOversold { get; set; } = 30.0;
}
