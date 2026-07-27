// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;

namespace TechnicalAnalysis.Samples.RealTime.Client;

/// <summary>
/// The command line surface of the console client.
/// </summary>
/// <param name="HubUrl">The absolute URL of the SignalR hub.</param>
/// <param name="Symbol">The symbol to subscribe to, or null to take the server's first symbol.</param>
/// <param name="UseStreaming">
/// When true, consume the hub's <c>StreamSnapshots</c> method instead of the group push. Both deliver
/// the same snapshots; the flag exists so one binary can exercise both server paths.
/// </param>
/// <param name="Duration">How long to run before exiting on its own, or null to run until Ctrl+C.</param>
public sealed record ClientOptions(Uri HubUrl, string? Symbol, bool UseStreaming, TimeSpan? Duration)
{
    private const string DefaultServer = "http://localhost:5199";
    private const string HubPath = "/hubs/indicators";

    /// <summary>The usage text shown for <c>--help</c> and for a bad argument.</summary>
    public const string Usage = """
        Usage: dotnet run [-- <server-url>] [options]

          <server-url>        Server root or full hub URL. Default: http://localhost:5199
          --symbol <symbol>   Symbol to follow. Default: the server's first symbol.
          --stream            Use the hub's streaming method instead of the group push.
          --seconds <n>       Exit after n seconds instead of running until Ctrl+C.
          --help              Show this text.
        """;

    /// <summary>
    /// Parses the command line.
    /// </summary>
    /// <param name="args">The raw arguments.</param>
    /// <param name="options">The parsed options, when parsing succeeded.</param>
    /// <param name="error">The reason parsing failed, otherwise null.</param>
    /// <returns><see langword="true"/> when the arguments are usable.</returns>
    public static bool TryParse(string[] args, out ClientOptions options, out string? error)
    {
        options = null!;
        error = null;

        string server = DefaultServer;
        string? symbol = null;
        bool streaming = false;
        TimeSpan? duration = null;

        for (int i = 0; i < args.Length; i++)
        {
            string argument = args[i];
            switch (argument)
            {
                case "--help" or "-h":
                    error = string.Empty;
                    return false;

                case "--stream":
                    streaming = true;
                    break;

                case "--symbol":
                    if (!TryTakeValue(args, ref i, out symbol))
                    {
                        error = "--symbol needs a value.";
                        return false;
                    }

                    break;

                case "--seconds":
                    if (!TryTakeValue(args, ref i, out string? seconds)
                        || !double.TryParse(seconds, CultureInfo.InvariantCulture, out double parsed)
                        || parsed <= 0)
                    {
                        error = "--seconds needs a positive number.";
                        return false;
                    }

                    duration = TimeSpan.FromSeconds(parsed);
                    break;

                default:
                    if (argument.StartsWith('-'))
                    {
                        error = $"Unknown option '{argument}'.";
                        return false;
                    }

                    server = argument;
                    break;
            }
        }

        if (!Uri.TryCreate(server, UriKind.Absolute, out Uri? uri))
        {
            error = $"'{server}' is not an absolute URL.";
            return false;
        }

        // Accept either a server root or a full hub URL, so both of these work:
        //   dotnet run -- http://localhost:5199
        //   dotnet run -- http://localhost:5199/hubs/indicators
        if (!uri.AbsolutePath.TrimEnd('/').EndsWith(HubPath, StringComparison.OrdinalIgnoreCase))
        {
            uri = new Uri(uri, HubPath);
        }

        options = new ClientOptions(uri, symbol, streaming, duration);
        return true;
    }

    private static bool TryTakeValue(string[] args, ref int index, out string? value)
    {
        if (index + 1 >= args.Length)
        {
            value = null;
            return false;
        }

        index++;
        value = args[index];
        return true;
    }
}
