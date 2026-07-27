// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Text.Json.Serialization;

namespace TechnicalAnalysis.Samples.RealTime.Contracts;

/// <summary>
/// The System.Text.Json source generated contract for every type that crosses the wire.
/// </summary>
/// <remarks>
/// <para>
/// Source generation removes the reflection-based serializer from the hot path, which keeps the sample
/// trim and native-AOT friendly. The generated metadata is wired into three places in
/// <c>Program.cs</c>: the minimal API endpoints, the SignalR JSON hub protocol, and the raw WebSocket
/// handler.
/// </para>
/// <para>
/// The naming policy is camel case so the generated names line up with the SignalR JSON protocol
/// defaults and with idiomatic JavaScript on the page. Nulls are written explicitly rather than omitted:
/// an absent indicator is the most important thing a frame can say, so it is stated rather than implied.
/// </para>
/// </remarks>
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Tick))]
[JsonSerializable(typeof(Bar))]
[JsonSerializable(typeof(IndicatorSnapshot))]
[JsonSerializable(typeof(StreamMessage))]
[JsonSerializable(typeof(SessionInfo))]
[JsonSerializable(typeof(IndicatorPeriods))]
[JsonSerializable(typeof(HealthResponse))]
[JsonSerializable(typeof(IReadOnlyList<string>))]
[JsonSerializable(typeof(string[]))]
public sealed partial class RealTimeJsonContext : JsonSerializerContext;
