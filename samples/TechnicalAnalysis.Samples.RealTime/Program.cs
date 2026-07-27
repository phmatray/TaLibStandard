// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Net.WebSockets;
using TechnicalAnalysis.Samples.RealTime.Configuration;
using TechnicalAnalysis.Samples.RealTime.Contracts;
using TechnicalAnalysis.Samples.RealTime.Hubs;
using TechnicalAnalysis.Samples.RealTime.Indicators;
using TechnicalAnalysis.Samples.RealTime.Streaming;
using TechnicalAnalysis.Samples.RealTime.WebSockets;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------------------------
// Options. Everything the sample can be tuned with lives in the RealTime
// section and can be overridden on the command line, for example:
//   dotnet run -- --RealTime:BarSeconds=1 --RealTime:TickIntervalMilliseconds=100
// ---------------------------------------------------------------------------
builder.Services
    .AddOptions<RealTimeOptions>()
    .Bind(builder.Configuration.GetSection(RealTimeOptions.SectionName))
    .Validate(RealTimeOptionsValidation.IsValid, RealTimeOptionsValidation.Message)
    .ValidateOnStart();

// ---------------------------------------------------------------------------
// Serialization. The source generated context is wired into all three exits:
// minimal API responses, the SignalR JSON protocol, and the raw socket handler
// (which references RealTimeJsonContext.Default directly).
// ---------------------------------------------------------------------------
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, RealTimeJsonContext.Default));

builder.Services
    .AddSignalR()
    .AddJsonProtocol(options =>
        options.PayloadSerializerOptions.TypeInfoResolverChain.Insert(0, RealTimeJsonContext.Default));

// ---------------------------------------------------------------------------
// The pipeline. The feed is registered twice on purpose: once as the singleton
// everything subscribes to, once as the hosted service that drives it.
// ---------------------------------------------------------------------------
builder.Services.AddSingleton<SyntheticMarketDataFeed>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<SyntheticMarketDataFeed>());
builder.Services.AddSingleton<SnapshotBroadcaster>();
builder.Services.AddSingleton<IndicatorWebSocketHandler>();
builder.Services.AddSingleton<IndicatorPipeline>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<IndicatorPipeline>());

WebApplication app = builder.Build();

app.UseWebSockets();
app.UseDefaultFiles();
app.UseStaticFiles();

// SignalR transport: push via per-symbol groups, plus a server-to-client streaming method.
app.MapHub<IndicatorHub>("/hubs/indicators");

// Raw WebSocket transport, for clients that would rather not take a SignalR dependency.
app.Map("/ws/indicators", async (HttpContext context, IndicatorWebSocketHandler handler) =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(
            "This endpoint speaks WebSocket. Open / in a browser for the live dashboard, "
            + "or connect a client to ws://<host>/ws/indicators?symbol=<symbol>.");
        return;
    }

    string? symbol = context.Request.Query["symbol"];
    using WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();
    await handler.HandleAsync(socket, symbol, context.RequestAborted);
});

DateTimeOffset startedAt = DateTimeOffset.UtcNow;

app.MapGet("/health", (SyntheticMarketDataFeed feed, SnapshotBroadcaster broadcaster, IndicatorPipeline pipeline)
    => new HealthResponse(
        "healthy",
        DateTimeOffset.UtcNow,
        Math.Round((DateTimeOffset.UtcNow - startedAt).TotalSeconds, 1),
        feed.Symbols,
        feed.PublishedTicks,
        pipeline.BarsClosed,
        feed.SubscriberCount,
        broadcaster.ChannelSubscriberCount,
        broadcaster.GroupSubscriberCount,
        pipeline.PushesDropped));

app.MapGet("/api/symbols", (SnapshotBroadcaster broadcaster) => broadcaster.Symbols);

await app.RunAsync();

/// <summary>
/// Startup validation for <see cref="RealTimeOptions"/>. Catching a bad period here turns a per-bar
/// <c>RetCode.BadParam</c> — which would silently null an indicator forever — into a loud failure at boot.
/// </summary>
internal static class RealTimeOptionsValidation
{
    /// <summary>The message shown when validation fails.</summary>
    public const string Message =
        "RealTime options are invalid: need at least one symbol, a positive tick interval, bar period and "
        + "queue capacity, indicator periods of at least 2, and a window size larger than the slowest "
        + "indicator's lookback.";

    /// <summary>
    /// Checks that the bound options can actually drive the pipeline.
    /// </summary>
    /// <param name="options">The bound options.</param>
    /// <returns><see langword="true"/> when the options are usable.</returns>
    public static bool IsValid(RealTimeOptions options)
    {
        if (options.Symbols.Length == 0 || options.Symbols.Any(string.IsNullOrWhiteSpace))
        {
            return false;
        }

        if (options.TickIntervalMilliseconds <= 0 || options.BarSeconds <= 0 || options.SubscriberQueueCapacity <= 0)
        {
            return false;
        }

        IndicatorOptions indicators = options.Indicators;
        int[] periods =
        [
            indicators.SmaFastPeriod,
            indicators.SmaSlowPeriod,
            indicators.EmaPeriod,
            indicators.RsiPeriod,
            indicators.MacdFastPeriod,
            indicators.MacdSlowPeriod,
            indicators.MacdSignalPeriod,
            indicators.BollingerPeriod,
            indicators.AtrPeriod
        ];

        // TAMath rejects any period below 2 with RetCode.BadParam.
        if (periods.Any(period => period < 2))
        {
            return false;
        }

        return options.WindowSize > RollingIndicatorEngine.LargestLookback(indicators);
    }
}
