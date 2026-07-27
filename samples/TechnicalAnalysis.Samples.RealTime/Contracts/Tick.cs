// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.RealTime.Contracts;

/// <summary>
/// A single trade print produced by the synthetic market data feed.
/// </summary>
/// <param name="Symbol">The instrument the print belongs to, for example <c>ACME</c>.</param>
/// <param name="Timestamp">The UTC instant the print was produced.</param>
/// <param name="Price">The traded price. Money is modelled with <see cref="decimal"/> so the wire value is exact.</param>
/// <param name="Volume">The traded size, in whole units.</param>
public sealed record Tick(string Symbol, DateTimeOffset Timestamp, decimal Price, long Volume);
