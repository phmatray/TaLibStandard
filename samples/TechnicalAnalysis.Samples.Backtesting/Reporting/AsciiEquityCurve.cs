// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Text;

namespace TechnicalAnalysis.Samples.Backtesting.Reporting;

/// <summary>
/// Renders an equity curve as a compact ASCII chart that survives being pasted into an issue, a log file or a
/// terminal without a graphics stack.
/// </summary>
/// <remarks>
/// The curve is resampled to the requested width by nearest-neighbour, normalised so that the initial capital
/// reads as 100, and drawn with vertical connectors between consecutive columns so that a steep move is a
/// visible line rather than two disconnected dots.
/// </remarks>
public static class AsciiEquityCurve
{
    private const char Plot = '*';
    private const char Connector = '|';
    private const char Blank = ' ';
    private const int LabelWidth = 8;

    /// <summary>
    /// Renders an equity curve.
    /// </summary>
    /// <param name="equityCurve">The curve to draw. An empty curve renders a short placeholder.</param>
    /// <param name="width">The number of plot columns, excluding the axis labels. Defaults to <c>78</c>.</param>
    /// <param name="height">The number of plot rows. Defaults to <c>14</c>.</param>
    /// <returns>The chart, as lines separated by <see cref="Environment.NewLine"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="equityCurve"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="width"/> is below 2 or <paramref name="height"/> is below 2.
    /// </exception>
    public static string Render(IReadOnlyList<EquityPoint> equityCurve, int width = 78, int height = 14)
    {
        ArgumentNullException.ThrowIfNull(equityCurve);
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 2);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 2);

        if (equityCurve.Count == 0)
        {
            return "(no equity curve: the bar series was empty)";
        }

        double baseline = equityCurve[0].Equity;
        if (baseline <= 0.0)
        {
            baseline = 1.0;
        }

        double[] samples = Resample(equityCurve, width, baseline);
        double minimum = samples[0];
        double maximum = samples[0];
        foreach (double sample in samples)
        {
            minimum = Math.Min(minimum, sample);
            maximum = Math.Max(maximum, sample);
        }

        // A perfectly flat curve would divide by zero; open a symmetric window around it instead.
        if (maximum - minimum < 1e-9)
        {
            maximum += 1.0;
            minimum -= 1.0;
        }

        char[][] canvas = new char[height][];
        for (int row = 0; row < height; row++)
        {
            canvas[row] = new char[width];
            Array.Fill(canvas[row], Blank);
        }

        int previousRow = -1;
        for (int column = 0; column < width; column++)
        {
            int row = ToRow(samples[column], minimum, maximum, height);
            canvas[row][column] = Plot;

            if (previousRow >= 0)
            {
                int from = Math.Min(previousRow, row);
                int to = Math.Max(previousRow, row);
                for (int fill = from + 1; fill < to; fill++)
                {
                    canvas[fill][column] = Connector;
                }
            }

            previousRow = row;
        }

        return Compose(canvas, equityCurve, minimum, maximum, width, height);
    }

    private static double[] Resample(IReadOnlyList<EquityPoint> equityCurve, int width, double baseline)
    {
        double[] samples = new double[width];
        for (int column = 0; column < width; column++)
        {
            int index = width == 1
                ? equityCurve.Count - 1
                : (int)Math.Round((double)column * (equityCurve.Count - 1) / (width - 1), MidpointRounding.AwayFromZero);

            index = Math.Clamp(index, 0, equityCurve.Count - 1);
            samples[column] = equityCurve[index].Equity / baseline * 100.0;
        }

        return samples;
    }

    private static int ToRow(double value, double minimum, double maximum, int height)
    {
        double normalised = (value - minimum) / (maximum - minimum);
        int fromBottom = (int)Math.Round(normalised * (height - 1), MidpointRounding.AwayFromZero);
        return height - 1 - Math.Clamp(fromBottom, 0, height - 1);
    }

    private static string Compose(
        char[][] canvas,
        IReadOnlyList<EquityPoint> equityCurve,
        double minimum,
        double maximum,
        int width,
        int height)
    {
        StringBuilder builder = new();
        for (int row = 0; row < height; row++)
        {
            string label = row switch
            {
                0 => maximum.ToString("F1", CultureInfo.InvariantCulture),
                _ when row == height - 1 => minimum.ToString("F1", CultureInfo.InvariantCulture),
                _ when row == height / 2 => ((maximum + minimum) / 2.0).ToString("F1", CultureInfo.InvariantCulture),
                _ => string.Empty
            };

            builder.Append(label.PadLeft(LabelWidth)).Append(" |").Append(canvas[row]).Append('\n');
        }

        builder.Append(new string(Blank, LabelWidth)).Append(" +").Append(new string('-', width)).Append('\n');

        string firstDate = equityCurve[0].Timestamp.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        string lastDate = equityCurve[^1].Timestamp.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        string axis = firstDate.Length + lastDate.Length + 1 <= width
            ? firstDate + new string(Blank, width - firstDate.Length - lastDate.Length) + lastDate
            : firstDate;

        builder.Append(new string(Blank, LabelWidth)).Append("  ").Append(axis);

        return builder
            .ToString()
            .Replace("\r\n", "\n", StringComparison.Ordinal)
            .Replace("\n", Environment.NewLine, StringComparison.Ordinal);
    }
}
