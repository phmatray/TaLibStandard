// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Data;

/// <summary>
/// Loads an OHLCV bar series from a comma-separated file, so the sample can be pointed at real data.
/// </summary>
/// <remarks>
/// <para>
/// The file must start with a header row naming the columns. Recognised names, matched case-insensitively,
/// are <c>Date</c> (or <c>Timestamp</c>, <c>Time</c>, <c>DateTime</c>), <c>Open</c>, <c>High</c>, <c>Low</c>,
/// <c>Close</c> and <c>Volume</c>. Column <em>order</em> does not matter and extra columns are ignored, so an
/// export carrying an <c>Adj Close</c> column loads unchanged. <c>Volume</c> is optional and defaults to zero.
/// </para>
/// <para>
/// Numbers and dates are parsed with <see cref="CultureInfo.InvariantCulture"/> — a decimal comma will be
/// rejected rather than silently misread. Blank lines are skipped. Rows are returned in file order and are
/// <em>not</em> re-sorted: an unsorted file is a data problem the caller should see, and
/// <see cref="Validate"/> reports it.
/// </para>
/// </remarks>
public static class CsvBarLoader
{
    private static readonly string[] DateHeaders = ["date", "timestamp", "time", "datetime"];

    /// <summary>
    /// Loads a bar series from a CSV file on disk.
    /// </summary>
    /// <param name="path">The path of the file to read.</param>
    /// <returns>The parsed bars, in file order.</returns>
    /// <exception cref="ArgumentException"><paramref name="path"/> is <see langword="null"/>, empty or blank.</exception>
    /// <exception cref="FileNotFoundException">The file does not exist.</exception>
    /// <exception cref="FormatException">The header is missing a required column, or a row is malformed.</exception>
    public static IReadOnlyList<Bar> LoadFile(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                string.Format(CultureInfo.InvariantCulture, "CSV file '{0}' was not found.", path),
                path);
        }

        using StreamReader reader = new(path);
        return Load(reader);
    }

    /// <summary>
    /// Loads a bar series from a reader. Useful for tests and for streaming from a non-file source.
    /// </summary>
    /// <param name="reader">The reader positioned at the header row.</param>
    /// <returns>The parsed bars, in reader order.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="reader"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException">The header is missing or malformed, or a row is malformed.</exception>
    public static IReadOnlyList<Bar> Load(TextReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        string? headerLine = ReadNonEmptyLine(reader, out int lineNumber);
        if (headerLine is null)
        {
            throw new FormatException("The CSV source is empty; a header row naming the columns is required.");
        }

        ColumnMap columns = ColumnMap.FromHeader(headerLine);
        List<Bar> bars = [];

        while (true)
        {
            string? line = reader.ReadLine();
            lineNumber++;

            if (line is null)
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            bars.Add(ParseRow(line, lineNumber, columns));
        }

        return bars;
    }

    /// <summary>
    /// Checks a loaded series for the two problems that quietly break a backtest: bars that are not ordered
    /// strictly ascending in time, and bars whose prices are inconsistent.
    /// </summary>
    /// <param name="bars">The series to check.</param>
    /// <returns>A human-readable description of the problems found, empty when the series is clean.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="bars"/> is <see langword="null"/>.</exception>
    public static IReadOnlyList<string> Validate(IReadOnlyList<Bar> bars)
    {
        ArgumentNullException.ThrowIfNull(bars);

        List<string> problems = [];
        for (int i = 0; i < bars.Count; i++)
        {
            if (!bars[i].IsWellFormed())
            {
                problems.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "Bar {0} ({1:yyyy-MM-dd}) is not well formed: O={2} H={3} L={4} C={5} V={6}.",
                    i,
                    bars[i].Timestamp,
                    bars[i].Open,
                    bars[i].High,
                    bars[i].Low,
                    bars[i].Close,
                    bars[i].Volume));
            }

            if (i > 0 && bars[i].Timestamp <= bars[i - 1].Timestamp)
            {
                problems.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "Bar {0} ({1:yyyy-MM-dd HH:mm:ss}) is not strictly after bar {2} ({3:yyyy-MM-dd HH:mm:ss}).",
                    i,
                    bars[i].Timestamp,
                    i - 1,
                    bars[i - 1].Timestamp));
            }
        }

        return problems;
    }

    private static string? ReadNonEmptyLine(TextReader reader, out int lineNumber)
    {
        lineNumber = 0;
        while (true)
        {
            string? line = reader.ReadLine();
            lineNumber++;

            if (line is null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(line))
            {
                return line;
            }
        }
    }

    private static Bar ParseRow(string line, int lineNumber, ColumnMap columns)
    {
        string[] fields = line.Split(',');
        if (fields.Length < columns.RequiredFieldCount)
        {
            throw new FormatException(string.Format(
                CultureInfo.InvariantCulture,
                "Line {0}: expected at least {1} comma-separated fields but found {2}.",
                lineNumber,
                columns.RequiredFieldCount,
                fields.Length));
        }

        DateTime timestamp = ParseDate(fields[columns.Date], lineNumber, "date");
        double open = ParseDouble(fields[columns.Open], lineNumber, "open");
        double high = ParseDouble(fields[columns.High], lineNumber, "high");
        double low = ParseDouble(fields[columns.Low], lineNumber, "low");
        double close = ParseDouble(fields[columns.Close], lineNumber, "close");
        double volume = columns.Volume >= 0 && columns.Volume < fields.Length
            ? ParseDouble(fields[columns.Volume], lineNumber, "volume")
            : 0.0;

        return new Bar(timestamp, open, high, low, close, volume);
    }

    private static DateTime ParseDate(string field, int lineNumber, string column)
    {
        string text = field.Trim().Trim('"');
        const DateTimeStyles styles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal;
        if (DateTime.TryParse(text, CultureInfo.InvariantCulture, styles, out DateTime value))
        {
            return value;
        }

        throw new FormatException(string.Format(
            CultureInfo.InvariantCulture,
            "Line {0}: '{1}' is not a valid invariant-culture {2}.",
            lineNumber,
            text,
            column));
    }

    private static double ParseDouble(string field, int lineNumber, string column)
    {
        string text = field.Trim().Trim('"');
        if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            return value;
        }

        throw new FormatException(string.Format(
            CultureInfo.InvariantCulture,
            "Line {0}: '{1}' is not a valid invariant-culture {2} value.",
            lineNumber,
            text,
            column));
    }

    private sealed record ColumnMap(int Date, int Open, int High, int Low, int Close, int Volume)
    {
        public int RequiredFieldCount => Math.Max(Math.Max(Date, Open), Math.Max(Math.Max(High, Low), Close)) + 1;

        public static ColumnMap FromHeader(string headerLine)
        {
            string[] headers = headerLine.Split(',');
            Dictionary<string, int> index = new(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < headers.Length; i++)
            {
                string name = headers[i].Trim().Trim('"');
                if (name.Length > 0)
                {
                    index.TryAdd(name, i);
                }
            }

            int date = -1;
            foreach (string candidate in DateHeaders)
            {
                if (index.TryGetValue(candidate, out int found))
                {
                    date = found;
                    break;
                }
            }

            if (date < 0)
            {
                throw new FormatException(
                    "The CSV header must contain a date column named 'Date', 'Timestamp', 'Time' or 'DateTime'.");
            }

            return new ColumnMap(
                date,
                Required(index, "Open"),
                Required(index, "High"),
                Required(index, "Low"),
                Required(index, "Close"),
                index.TryGetValue("Volume", out int volume) ? volume : -1);
        }

        private static int Required(Dictionary<string, int> index, string name)
        {
            if (index.TryGetValue(name, out int position))
            {
                return position;
            }

            throw new FormatException(string.Format(
                CultureInfo.InvariantCulture,
                "The CSV header must contain a '{0}' column.",
                name));
        }
    }
}
