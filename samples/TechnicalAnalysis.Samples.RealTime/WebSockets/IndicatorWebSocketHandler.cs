// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Channels;
using Microsoft.Extensions.Options;
using TechnicalAnalysis.Samples.RealTime.Configuration;
using TechnicalAnalysis.Samples.RealTime.Contracts;
using TechnicalAnalysis.Samples.RealTime.Diagnostics;
using TechnicalAnalysis.Samples.RealTime.Streaming;

namespace TechnicalAnalysis.Samples.RealTime.WebSockets;

/// <summary>
/// Serves the raw <c>/ws/indicators</c> socket: the same snapshots as the hub, with no SignalR client
/// required.
/// </summary>
/// <remarks>
/// <para>
/// SignalR is the better default for .NET clients, but a raw socket is the lowest common denominator —
/// it is what the sample's own page uses, what a Python or Go consumer would reach for, and what you
/// fall back to when a proxy mangles the SignalR negotiate request. Frames are newline-free JSON objects
/// of <see cref="StreamMessage"/>: one <c>session</c> frame, then a <c>snapshot</c> frame per closed bar.
/// </para>
/// <para>
/// The two halves of a socket are independent, so this runs a receive loop concurrently with a send loop.
/// The receive loop exists even though the protocol is server-to-client only: without it the close
/// handshake never completes, and a "read-only" socket is exactly how a server leaks connections that
/// look alive to it and dead to everyone else.
/// </para>
/// </remarks>
public sealed class IndicatorWebSocketHandler
{
    private const int ReceiveBufferSize = 1024;

    private static readonly TimeSpan CloseHandshakeTimeout = TimeSpan.FromSeconds(5);

    private readonly SnapshotBroadcaster _broadcaster;
    private readonly RealTimeOptions _options;
    private readonly ILogger<IndicatorWebSocketHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="IndicatorWebSocketHandler"/> class.
    /// </summary>
    /// <param name="broadcaster">The snapshot distribution point.</param>
    /// <param name="options">The bound sample options.</param>
    /// <param name="logger">The logger used for connection lifecycle messages.</param>
    public IndicatorWebSocketHandler(
        SnapshotBroadcaster broadcaster,
        IOptions<RealTimeOptions> options,
        ILogger<IndicatorWebSocketHandler> logger)
    {
        ArgumentNullException.ThrowIfNull(options);

        _broadcaster = broadcaster;
        _options = options.Value;
        _logger = logger;
    }

    /// <summary>
    /// Runs one client connection to completion.
    /// </summary>
    /// <param name="socket">The accepted socket.</param>
    /// <param name="requestedSymbol">
    /// The <c>symbol</c> query string value. Omitting it subscribes to the server's first symbol, so
    /// <c>/ws/indicators</c> works with no query string at all; supplying an unknown one is an error.
    /// </param>
    /// <param name="requestAborted">The request's abort token, which fires if the connection drops.</param>
    /// <returns>A task that completes once the socket is closed.</returns>
    public async Task HandleAsync(WebSocket socket, string? requestedSymbol, CancellationToken requestAborted)
    {
        ArgumentNullException.ThrowIfNull(socket);

        string requested = string.IsNullOrWhiteSpace(requestedSymbol) ? _broadcaster.Symbols[0] : requestedSymbol;

        if (!_broadcaster.TryResolveSymbol(requested, out string symbol))
        {
            string known = string.Join(", ", _broadcaster.Symbols);
            await SendAsync(socket, StreamMessage.ForError($"Unknown symbol. This server publishes: {known}."), requestAborted);

            // Nothing else owns the read side on this path, so the full handshake is safe here.
            await CloseSafeAsync(socket, WebSocketCloseStatus.PolicyViolation, "Unknown symbol");
            return;
        }

        // One token covers both loops: whichever finishes first cancels the other, so a client that goes
        // away mid-bar tears the whole connection down instead of leaving a send loop parked on a read.
        using CancellationTokenSource connection = CancellationTokenSource.CreateLinkedTokenSource(requestAborted);
        using FanoutSubscription<IndicatorSnapshot> subscription = _broadcaster.Subscribe(symbol);

        SampleLog.WebSocketSubscribed(_logger, symbol);

        Task receiveLoop = ReceiveLoopAsync(socket, connection);
        try
        {
            await SendAsync(socket, StreamMessage.ForSession(BuildSession(symbol)), connection.Token);

            // Subscribing before the replay closes the loss window and opens a duplication one: a publish
            // that interleaves between the broadcaster storing "latest" and fanning out would deliver the
            // same bar twice, with the same Sequence. The send loop skips anything not strictly newer.
            long lastSequence = -1;

            if (_broadcaster.Latest(symbol) is { } latest)
            {
                lastSequence = latest.Sequence;
                await SendAsync(socket, StreamMessage.ForSnapshot(latest), connection.Token);
            }

            await SendLoopAsync(socket, subscription.Reader, lastSequence, connection.Token);
        }
        catch (OperationCanceledException)
        {
            // The client left, or the host is shutting down.
        }
        catch (WebSocketException exception)
        {
            SampleLog.WebSocketDropped(_logger, symbol, exception.Message);
        }
        finally
        {
            // Send our half of the close handshake without touching the read side, which the receive loop
            // owns: WebSocket.CloseAsync would issue its own receive and collide with it.
            await CloseOutputSafeAsync(socket, WebSocketCloseStatus.NormalClosure, "Stream finished");

            // Give the client a moment to answer with its close frame, then stop waiting for a peer that
            // is evidently not coming back.
            if (await Task.WhenAny(receiveLoop, Task.Delay(CloseHandshakeTimeout, CancellationToken.None)) != receiveLoop)
            {
                await connection.CancelAsync();
            }

            await receiveLoop;
            SampleLog.WebSocketDisconnected(_logger, symbol);
        }
    }

    /// <summary>
    /// Pumps snapshots to the client. The only writer to the socket, so sends never overlap.
    /// </summary>
    /// <param name="socket">The client socket.</param>
    /// <param name="reader">This client's snapshot queue.</param>
    /// <param name="lastSequence">
    /// The highest sequence already sent during the replay, or <c>-1</c> when nothing was replayed.
    /// </param>
    /// <param name="cancellationToken">Fires when the client leaves or the host shuts down.</param>
    private static async Task SendLoopAsync(
        WebSocket socket,
        ChannelReader<IndicatorSnapshot> reader,
        long lastSequence,
        CancellationToken cancellationToken)
    {
        await foreach (IndicatorSnapshot snapshot in reader.ReadAllAsync(cancellationToken))
        {
            if (socket.State != WebSocketState.Open)
            {
                return;
            }

            // Strictly increasing, so the replayed snapshot is never sent twice. A gap still means a
            // genuine drop-oldest discard, which is what the client's gap counter is for.
            if (snapshot.Sequence <= lastSequence)
            {
                continue;
            }

            lastSequence = snapshot.Sequence;
            await SendAsync(socket, StreamMessage.ForSnapshot(snapshot), cancellationToken);
        }
    }

    /// <summary>
    /// Drains whatever the client sends and, more importantly, notices when it sends a close frame.
    /// </summary>
    /// <remarks>
    /// The sample's protocol is one-way, so any payload is discarded; a real feed would parse subscribe
    /// and unsubscribe commands here. Receiving the close frame is what lets
    /// <see cref="WebSocket.CloseAsync"/> complete the handshake rather than time out.
    /// </remarks>
    private static async Task ReceiveLoopAsync(WebSocket socket, CancellationTokenSource connection)
    {
        byte[] buffer = new byte[ReceiveBufferSize];

        try
        {
            while (socket.State == WebSocketState.Open && !connection.Token.IsCancellationRequested)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, connection.Token);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    return;
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Expected once the send side finishes or the request is aborted.
        }
        catch (WebSocketException)
        {
            // The peer vanished without a close frame. Nothing to salvage.
        }
        finally
        {
            await connection.CancelAsync();
        }
    }

    private static async Task SendAsync(WebSocket socket, StreamMessage message, CancellationToken cancellationToken)
    {
        if (socket.State != WebSocketState.Open)
        {
            return;
        }

        byte[] payload = JsonSerializer.SerializeToUtf8Bytes(message, RealTimeJsonContext.Default.StreamMessage);
        await socket.SendAsync(payload, WebSocketMessageType.Text, endOfMessage: true, cancellationToken);
    }

    /// <summary>
    /// Sends the server's close frame. Safe to call in any state and never throws.
    /// </summary>
    /// <remarks>
    /// This is the send half only. It works whether the client closed first (state
    /// <see cref="WebSocketState.CloseReceived"/>) or the server did (state <see cref="WebSocketState.Open"/>),
    /// and it never competes with the receive loop for the read side.
    /// </remarks>
    private static async Task CloseOutputSafeAsync(WebSocket socket, WebSocketCloseStatus status, string description)
    {
        if (socket.State is not (WebSocketState.Open or WebSocketState.CloseReceived))
        {
            return;
        }

        try
        {
            await socket.CloseOutputAsync(status, description, CancellationToken.None);
        }
        catch (WebSocketException)
        {
            // The peer is already gone; there is nothing left to hand shake with.
        }
        catch (ObjectDisposedException)
        {
            // The host tore the connection down first.
        }
    }

    /// <summary>
    /// Performs the full close handshake. Only safe when nothing else is reading the socket.
    /// </summary>
    private static async Task CloseSafeAsync(WebSocket socket, WebSocketCloseStatus status, string description)
    {
        if (socket.State is not (WebSocketState.Open or WebSocketState.CloseReceived))
        {
            return;
        }

        try
        {
            await socket.CloseAsync(status, description, CancellationToken.None);
        }
        catch (WebSocketException)
        {
            // The peer is already gone; there is nothing left to hand shake with.
        }
        catch (ObjectDisposedException)
        {
            // The host tore the connection down first.
        }
    }

    private SessionInfo BuildSession(string symbol)
        => new(
            symbol,
            _broadcaster.Symbols,
            _options.BarSeconds,
            _options.TickIntervalMilliseconds,
            _options.WindowSize,
            new IndicatorPeriods(
                _options.Indicators.SmaFastPeriod,
                _options.Indicators.SmaSlowPeriod,
                _options.Indicators.EmaPeriod,
                _options.Indicators.RsiPeriod,
                _options.Indicators.MacdFastPeriod,
                _options.Indicators.MacdSlowPeriod,
                _options.Indicators.MacdSignalPeriod,
                _options.Indicators.BollingerPeriod,
                _options.Indicators.BollingerDeviations,
                _options.Indicators.AtrPeriod));
}
