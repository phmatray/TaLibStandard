// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using Microsoft.AspNetCore.SignalR.Client;
using TechnicalAnalysis.Samples.RealTime.Client;

if (!ClientOptions.TryParse(args, out ClientOptions options, out string? parseError))
{
    if (!string.IsNullOrEmpty(parseError))
    {
        Console.Error.WriteLine(parseError);
        Console.Error.WriteLine();
    }

    Console.Error.WriteLine(ClientOptions.Usage);
    return string.IsNullOrEmpty(parseError) ? 0 : 64;
}

using CancellationTokenSource shutdown = new();

// Ctrl+C cancels rather than kills, so the hub connection gets to say goodbye and the terminal gets its
// cursor back. A second Ctrl+C falls through to the runtime default and ends the process outright.
Console.CancelKeyPress += (_, eventArgs) =>
{
    if (!shutdown.IsCancellationRequested)
    {
        eventArgs.Cancel = true;
        shutdown.Cancel();
    }
};

if (options.Duration is { } duration)
{
    shutdown.CancelAfter(duration);
}

SnapshotRenderer renderer = new();

HubConnection connection = new HubConnectionBuilder()
    .WithUrl(options.HubUrl)
    .WithAutomaticReconnect([TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10)])
    .Build();

string? symbol = options.Symbol;

connection.Closed += _ =>
{
    renderer.SetStatus("disconnected");
    return Task.CompletedTask;
};

connection.Reconnecting += _ =>
{
    renderer.SetStatus("reconnecting");
    return Task.CompletedTask;
};

connection.Reconnected += async _ =>
{
    renderer.SetStatus("streaming");

    // Group membership does not survive a reconnect: the server sees a brand new connection id, so the
    // subscription has to be re-established or the stream silently goes quiet.
    if (!options.UseStreaming && symbol is not null)
    {
        await connection.InvokeAsync("Subscribe", symbol, shutdown.Token);
    }
};

int exitCode = 0;

try
{
    renderer.SetStatus("connecting");
    await connection.StartAsync(shutdown.Token);

    IReadOnlyList<string> symbols = await connection.InvokeAsync<IReadOnlyList<string>>("GetSymbols", shutdown.Token);
    if (symbols.Count == 0)
    {
        throw new InvalidOperationException("The server publishes no symbols.");
    }

    symbol = symbol is null
        ? symbols[0]
        : symbols.FirstOrDefault(known => string.Equals(known, symbol, StringComparison.OrdinalIgnoreCase))
          ?? throw new InvalidOperationException(string.Create(
              CultureInfo.InvariantCulture,
              $"Unknown symbol '{symbol}'. This server publishes: {string.Join(", ", symbols)}."));

    renderer.SetStatus(string.Create(
        CultureInfo.InvariantCulture,
        $"streaming {symbol} from {options.HubUrl} ({(options.UseStreaming ? "streaming method" : "group push")})"));

    if (options.UseStreaming)
    {
        // Streaming transport: one server-to-client sequence scoped to this call.
        IAsyncEnumerable<IndicatorSnapshotDto> stream =
            connection.StreamAsync<IndicatorSnapshotDto>("StreamSnapshots", symbol, shutdown.Token);

        await foreach (IndicatorSnapshotDto snapshot in stream.WithCancellation(shutdown.Token))
        {
            renderer.Render(snapshot);
        }
    }
    else
    {
        // Push transport: join the symbol's group and handle the client method.
        using IDisposable handler = connection.On<IndicatorSnapshotDto>("snapshot", renderer.Render);
        await connection.InvokeAsync("Subscribe", symbol, shutdown.Token);
        await Task.Delay(Timeout.InfiniteTimeSpan, shutdown.Token);
    }
}
catch (OperationCanceledException)
{
    // Ctrl+C, or --seconds elapsed. Both are a clean exit.
}
catch (Exception exception) when (exception is HttpRequestException or InvalidOperationException)
{
    renderer.Restore();
    Console.Error.WriteLine(string.Create(
        CultureInfo.InvariantCulture,
        $"Could not stream from {options.HubUrl}: {exception.Message}"));
    Console.Error.WriteLine("Is the server running? Start it with: dotnet run --project samples/TechnicalAnalysis.Samples.RealTime");
    exitCode = 69;
}
finally
{
    await connection.DisposeAsync();
    renderer.Restore();
}

if (exitCode == 0)
{
    Console.WriteLine("Disconnected.");
}

return exitCode;
