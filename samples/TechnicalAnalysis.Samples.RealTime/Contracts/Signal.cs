// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Text.Json.Serialization;

namespace TechnicalAnalysis.Samples.RealTime.Contracts;

/// <summary>
/// The coarse read the sample derives from a warmed-up <see cref="IndicatorSnapshot"/>.
/// </summary>
/// <remarks>
/// This is deliberately simplistic: it exists to show how several indicator outputs combine into one
/// decision, not to be traded. It is serialised as a string so the browser and console clients can render
/// it without sharing an enum definition.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter<Signal>))]
public enum Signal
{
    /// <summary>No opinion: the inputs disagree, or not enough indicators have warmed up yet.</summary>
    Neutral = 0,

    /// <summary>Fast average above slow average and the MACD histogram positive.</summary>
    Bullish = 1,

    /// <summary>Fast average below slow average and the MACD histogram negative.</summary>
    Bearish = 2,

    /// <summary>RSI at or above the configured overbought threshold.</summary>
    Overbought = 3,

    /// <summary>RSI at or below the configured oversold threshold.</summary>
    Oversold = 4
}
