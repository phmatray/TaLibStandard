// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.UnitTests.TestSupport;

/// <summary>
/// Builders for the small, fully hand-controlled bar series the tests reason about.
/// </summary>
internal static class TestBars
{
    internal static readonly DateTime Origin = new(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Builds bars from a close series. Each bar opens at the previous close (the first at its own close),
    /// and the high and low are widened by <paramref name="wick"/> so that every bar is well formed.
    /// </summary>
    internal static IReadOnlyList<Bar> FromCloses(IReadOnlyList<double> closes, double wick = 0.5)
    {
        List<Bar> bars = new(closes.Count);
        for (int i = 0; i < closes.Count; i++)
        {
            double open = i == 0 ? closes[0] : closes[i - 1];
            double close = closes[i];
            double high = Math.Max(open, close) + wick;
            double low = Math.Min(open, close) - wick;
            bars.Add(new Bar(Origin.AddDays(i), open, high, low, close, 1_000.0));
        }

        return bars;
    }

    /// <summary>
    /// Builds bars from explicit open/close pairs, keeping the wick tight around the body.
    /// </summary>
    internal static IReadOnlyList<Bar> FromOpenClose(IReadOnlyList<(double Open, double Close)> prices)
    {
        List<Bar> bars = new(prices.Count);
        for (int i = 0; i < prices.Count; i++)
        {
            (double open, double close) = prices[i];
            bars.Add(new Bar(
                Origin.AddDays(i),
                open,
                Math.Max(open, close),
                Math.Min(open, close),
                close,
                1_000.0));
        }

        return bars;
    }

    /// <summary>
    /// Builds a perfectly flat series: every price of every bar is <paramref name="price"/>.
    /// </summary>
    internal static IReadOnlyList<Bar> Flat(int count, double price = 100.0)
    {
        List<Bar> bars = new(count);
        for (int i = 0; i < count; i++)
        {
            bars.Add(new Bar(Origin.AddDays(i), price, price, price, price, 1_000.0));
        }

        return bars;
    }
}
