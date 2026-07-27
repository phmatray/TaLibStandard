// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using System.Text;

namespace TechnicalAnalysis.Samples.RealTime.Client;

/// <summary>
/// Draws incoming snapshots, either as a table that updates in place or as one line per bar.
/// </summary>
/// <remarks>
/// Which one it picks depends on <see cref="Console.IsOutputRedirected"/>. A terminal gets the table,
/// repainted from the top on every bar. A pipe or a log file gets append-only lines, because cursor
/// escapes in a captured log are unreadable and because a build server wants a diffable transcript.
/// </remarks>
public sealed class SnapshotRenderer
{
    private const string Home = "\u001b[H\u001b[J";
    private const string HideCursor = "\u001b[?25l";
    private const string ShowCursor = "\u001b[?25h";
    private const string Reset = "\u001b[0m";
    private const string Dim = "\u001b[2m";
    private const string Bold = "\u001b[1m";
    private const string Green = "\u001b[32m";
    private const string Red = "\u001b[31m";
    private const string Yellow = "\u001b[33m";

    private readonly bool _interactive;
    private readonly StringBuilder _buffer = new();
    private decimal? _firstClose;
    private long _lastSequence = -1;
    private long _dropped;
    private string _status = "connecting";

    /// <summary>
    /// Initializes a new instance of the <see cref="SnapshotRenderer"/> class.
    /// </summary>
    public SnapshotRenderer()
    {
        _interactive = !Console.IsOutputRedirected;
        if (_interactive)
        {
            Console.Write(HideCursor);
        }
    }

    /// <summary>
    /// Restores the terminal. Called on the way out, including after Ctrl+C.
    /// </summary>
    public void Restore()
    {
        if (_interactive)
        {
            Console.Write(ShowCursor);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Records a connection state change so the next frame shows it.
    /// </summary>
    /// <param name="status">The state to display, for example <c>streaming</c> or <c>reconnecting</c>.</param>
    public void SetStatus(string status)
    {
        _status = status;
        if (!_interactive)
        {
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"[{Timestamp()}] {status}"));
        }
    }

    /// <summary>
    /// Renders one snapshot.
    /// </summary>
    /// <param name="snapshot">The snapshot to render.</param>
    public void Render(IndicatorSnapshotDto snapshot)
    {
        ArgumentNullException.ThrowIfNull(snapshot);

        _firstClose ??= snapshot.Close;

        // The server's queues drop the oldest frame rather than stall the feed, so a gap in the sequence
        // is expected behaviour rather than a bug. Counting it is how a client notices.
        if (_lastSequence >= 0 && snapshot.Sequence > _lastSequence + 1)
        {
            _dropped += snapshot.Sequence - _lastSequence - 1;
        }

        _lastSequence = snapshot.Sequence;

        if (_interactive)
        {
            RenderTable(snapshot);
        }
        else
        {
            Console.WriteLine(RenderLine(snapshot));
        }
    }

    /// <summary>
    /// Builds the append-only form: everything about one bar on one greppable line.
    /// </summary>
    /// <param name="snapshot">The snapshot to render.</param>
    /// <returns>The formatted line.</returns>
    public static string RenderLine(IndicatorSnapshotDto snapshot)
    {
        ArgumentNullException.ThrowIfNull(snapshot);

        return string.Create(
            CultureInfo.InvariantCulture,
            $"{snapshot.Timestamp.ToLocalTime():HH:mm:ss} {snapshot.Symbol,-7} #{snapshot.Sequence,-3} "
            + $"close={snapshot.Close,8:0.00} "
            + $"smaFast={Number(snapshot.SmaFast, "0.00"),8} "
            + $"smaSlow={Number(snapshot.SmaSlow, "0.00"),8} "
            + $"ema={Number(snapshot.Ema, "0.00"),8} "
            + $"rsi={Number(snapshot.Rsi, "0.0"),6} "
            + $"macd={Number(snapshot.Macd, "0.0000"),8} "
            + $"macdSignal={Number(snapshot.MacdSignal, "0.0000"),8} "
            + $"macdHist={Number(snapshot.MacdHistogram, "0.0000"),8} "
            + $"bbUpper={Number(snapshot.BollingerUpper, "0.00"),8} "
            + $"bbLower={Number(snapshot.BollingerLower, "0.00"),8} "
            + $"atr={Number(snapshot.Atr, "0.0000"),8} "
            + $"signal={snapshot.Signal,-10} "
            + $"warm={snapshot.BarsInWindow}/{snapshot.BarsRequired}");
    }

    private static string Number(double? value, string format)
        => value.HasValue ? value.Value.ToString(format, CultureInfo.InvariantCulture) : "null";

    private static string Timestamp() => DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

    private void RenderTable(IndicatorSnapshotDto snapshot)
    {
        decimal change = _firstClose is { } first && first > 0m
            ? (snapshot.Close - first) / first * 100m
            : 0m;

        string rule = new('─', 62);

        _buffer.Clear();
        _buffer.Append(Home);
        _buffer.Append(Bold).Append("  TaLibStandard · live tape").Append(Reset);
        _buffer.Append(Dim).Append("      ").Append(snapshot.Symbol).Append("   ").Append(_status).Append(Reset).Append('\n');
        _buffer.Append("  ").Append(rule).Append('\n');

        _buffer.Append(string.Create(
            CultureInfo.InvariantCulture,
            $"  bar {snapshot.Timestamp.ToLocalTime():HH:mm:ss}   seq {snapshot.Sequence,-6} close {snapshot.Close,10:0.00}   "))
            .Append(change >= 0 ? Green : Red)
            .Append(string.Create(CultureInfo.InvariantCulture, $"{(change >= 0 ? "+" : string.Empty)}{change:0.00}%"))
            .Append(Reset)
            .Append('\n');

        _buffer.Append(Dim)
            .Append(string.Create(
                CultureInfo.InvariantCulture,
                $"  window {snapshot.BarsInWindow}/{snapshot.BarsRequired} bars until every indicator is warm"))
            .Append(_dropped > 0 ? string.Create(CultureInfo.InvariantCulture, $"   ·   {_dropped} frame(s) dropped") : string.Empty)
            .Append(Reset)
            .Append('\n');

        _buffer.Append("  ").Append(rule).Append('\n');

        AppendPair(snapshot.SmaFast, "SMA fast", "0.00", snapshot.Macd, "MACD", "0.0000");
        AppendPair(snapshot.SmaSlow, "SMA slow", "0.00", snapshot.MacdSignal, "MACD signal", "0.0000");
        AppendPair(snapshot.Ema, "EMA", "0.00", snapshot.MacdHistogram, "MACD hist", "0.0000");
        AppendPair(snapshot.Rsi, "RSI", "0.0", snapshot.BollingerUpper, "BB upper", "0.00");
        AppendPair(snapshot.Atr, "ATR", "0.0000", snapshot.BollingerMiddle, "BB middle", "0.00");
        AppendPair(null, string.Empty, "0.00", snapshot.BollingerLower, "BB lower", "0.00");

        _buffer.Append("  ").Append(rule).Append('\n');
        _buffer.Append("  signal   ")
            .Append(SignalColour(snapshot.Signal))
            .Append(snapshot.Signal.ToUpperInvariant())
            .Append(Reset)
            .Append('\n');
        _buffer.Append(Dim).Append("  a dashed value has not warmed up: the server sends null, not zero.").Append(Reset).Append('\n');
        _buffer.Append(Dim).Append("  Ctrl+C to leave.").Append(Reset).Append('\n');

        Console.Out.Write(_buffer.ToString());
        Console.Out.Flush();
    }

    private void AppendPair(double? left, string leftLabel, string leftFormat, double? right, string rightLabel, string rightFormat)
    {
        _buffer.Append("  ");
        AppendCell(left, leftLabel, leftFormat);
        _buffer.Append("   ");
        AppendCell(right, rightLabel, rightFormat);
        _buffer.Append('\n');
    }

    private void AppendCell(double? value, string label, string format)
    {
        if (label.Length == 0)
        {
            _buffer.Append(new string(' ', 26));
            return;
        }

        _buffer.Append(Dim).Append(label.PadRight(12)).Append(Reset);

        if (value.HasValue)
        {
            _buffer.Append(value.Value.ToString(format, CultureInfo.InvariantCulture).PadLeft(12));
        }
        else
        {
            _buffer.Append(Yellow).Append("–––".PadLeft(12)).Append(Reset);
        }

        _buffer.Append(new string(' ', 2));
    }

    private static string SignalColour(string signal) => signal switch
    {
        "Bullish" or "Oversold" => Green,
        "Bearish" or "Overbought" => Red,
        _ => Dim
    };
}
