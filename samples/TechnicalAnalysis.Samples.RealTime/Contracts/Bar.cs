// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.RealTime.Contracts;

/// <summary>
/// A closed OHLCV bar aggregated from a run of <see cref="Tick"/> values.
/// </summary>
/// <param name="Symbol">The instrument the bar belongs to.</param>
/// <param name="Timestamp">The UTC instant the bar period opened. A bar labelled 12:00:05 with a five second
/// period covers the half-open interval [12:00:05, 12:00:10).</param>
/// <param name="Open">The first traded price of the period.</param>
/// <param name="High">The highest traded price of the period.</param>
/// <param name="Low">The lowest traded price of the period.</param>
/// <param name="Close">The last traded price of the period.</param>
/// <param name="Volume">The summed traded size of the period.</param>
/// <param name="TickCount">How many ticks were folded into the bar. Useful when diagnosing a thin period.</param>
public sealed record Bar(
    string Symbol,
    DateTimeOffset Timestamp,
    decimal Open,
    decimal High,
    decimal Low,
    decimal Close,
    long Volume,
    int TickCount);
