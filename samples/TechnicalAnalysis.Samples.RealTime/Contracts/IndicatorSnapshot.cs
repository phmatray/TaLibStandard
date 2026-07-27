// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.RealTime.Contracts;

/// <summary>
/// The latest value of every indicator the sample tracks, for one closed bar of one symbol.
/// </summary>
/// <remarks>
/// Every indicator value is nullable and every null means the same thing: <em>that indicator has not
/// produced a value for this bar yet</em>. A null is never replaced by zero and never by the previous
/// bar's value, because both of those lies are indistinguishable from a real reading downstream.
/// </remarks>
/// <param name="Symbol">The instrument the snapshot describes.</param>
/// <param name="Timestamp">The UTC open instant of the bar the snapshot was computed from.</param>
/// <param name="Close">The close of that bar.</param>
/// <param name="Sequence">A monotonically increasing bar counter per symbol, starting at 1. Lets a client
/// detect frames it dropped, which a bounded stream is allowed to do.</param>
/// <param name="SmaFast">Latest fast simple moving average, or null while warming up.</param>
/// <param name="SmaSlow">Latest slow simple moving average, or null while warming up.</param>
/// <param name="Ema">Latest exponential moving average, or null while warming up.</param>
/// <param name="Rsi">Latest relative strength index, or null while warming up.</param>
/// <param name="Macd">Latest MACD line, or null while warming up.</param>
/// <param name="MacdSignal">Latest MACD signal line, or null while warming up.</param>
/// <param name="MacdHistogram">Latest MACD histogram, or null while warming up.</param>
/// <param name="BollingerUpper">Latest upper Bollinger band, or null while warming up.</param>
/// <param name="BollingerMiddle">Latest middle Bollinger band, or null while warming up.</param>
/// <param name="BollingerLower">Latest lower Bollinger band, or null while warming up.</param>
/// <param name="Atr">Latest average true range, or null while warming up.</param>
/// <param name="Signal">The combined read for this bar. <see cref="Contracts.Signal.Neutral"/> while warming up.</param>
/// <param name="BarsInWindow">How many bars the rolling window currently holds.</param>
/// <param name="BarsRequired">How many bars the slowest configured indicator needs before it can produce a value.</param>
public sealed record IndicatorSnapshot(
    string Symbol,
    DateTimeOffset Timestamp,
    decimal Close,
    long Sequence,
    double? SmaFast,
    double? SmaSlow,
    double? Ema,
    double? Rsi,
    double? Macd,
    double? MacdSignal,
    double? MacdHistogram,
    double? BollingerUpper,
    double? BollingerMiddle,
    double? BollingerLower,
    double? Atr,
    Signal Signal,
    int BarsInWindow,
    int BarsRequired)
{
    /// <summary>
    /// Gets a value indicating whether every tracked indicator has produced a value for this bar.
    /// </summary>
    public bool IsWarmedUp =>
        SmaFast.HasValue
        && SmaSlow.HasValue
        && Ema.HasValue
        && Rsi.HasValue
        && Macd.HasValue
        && MacdSignal.HasValue
        && MacdHistogram.HasValue
        && BollingerUpper.HasValue
        && Atr.HasValue;
}
