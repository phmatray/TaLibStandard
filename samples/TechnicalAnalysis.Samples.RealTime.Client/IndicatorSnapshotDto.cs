// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.RealTime.Client;

/// <summary>
/// The client's copy of the server's snapshot contract.
/// </summary>
/// <remarks>
/// The client deliberately does not reference the server project. A wire contract that only compiles
/// because both ends share an assembly is not a wire contract, and copying the shape here is what a real
/// third-party consumer would do. The SignalR JSON protocol matches names case-insensitively, so these
/// PascalCase members bind to the camelCase names on the wire.
/// </remarks>
/// <param name="Symbol">The instrument.</param>
/// <param name="Timestamp">The bar's UTC open instant.</param>
/// <param name="Close">The bar's close.</param>
/// <param name="Sequence">The per-symbol bar counter, used to spot dropped frames.</param>
/// <param name="SmaFast">Fast simple moving average, or null while warming up.</param>
/// <param name="SmaSlow">Slow simple moving average, or null while warming up.</param>
/// <param name="Ema">Exponential moving average, or null while warming up.</param>
/// <param name="Rsi">Relative strength index, or null while warming up.</param>
/// <param name="Macd">MACD line, or null while warming up.</param>
/// <param name="MacdSignal">MACD signal line, or null while warming up.</param>
/// <param name="MacdHistogram">MACD histogram, or null while warming up.</param>
/// <param name="BollingerUpper">Upper Bollinger band, or null while warming up.</param>
/// <param name="BollingerMiddle">Middle Bollinger band, or null while warming up.</param>
/// <param name="BollingerLower">Lower Bollinger band, or null while warming up.</param>
/// <param name="Atr">Average true range, or null while warming up.</param>
/// <param name="Signal">The server's combined read for this bar.</param>
/// <param name="BarsInWindow">Bars currently in the server's rolling window.</param>
/// <param name="BarsRequired">Bars the slowest indicator needs before it prints.</param>
public sealed record IndicatorSnapshotDto(
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
    string Signal,
    int BarsInWindow,
    int BarsRequired);
