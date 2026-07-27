// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Data;

/// <summary>
/// Generates a deterministic synthetic OHLCV series so the sample runs offline, with no market-data feed,
/// no API key and no network access, and prints the same numbers on every machine.
/// </summary>
/// <remarks>
/// <para>
/// Closes follow a geometric Brownian motion,
/// <c>C(t) = C(t-1) * exp((mu - sigma^2 / 2) + sigma * z)</c>, with a mild positive drift so the series
/// trends upwards over the long run — trend followers need trends to be worth comparing — while remaining
/// noisy enough at short horizons for mean-reversion rules to find something to do.
/// </para>
/// <para>
/// The open gaps away from the previous close, and the high and low are pushed beyond the open/close range by
/// half-normal shocks, so the bars are well formed (<c>Low &lt;= min(Open, Close)</c> and
/// <c>High &gt;= max(Open, Close)</c>) and have a realistic true range for ATR-based rules. Timestamps step
/// one weekday at a time, matching the default annualisation constant of 252 bars per year.
/// </para>
/// <para>
/// This is synthetic data, not market data. It has no fat tails, no volatility clustering and no regime
/// changes, so it is fine for exercising and testing an engine and hopeless as evidence that a strategy works.
/// </para>
/// </remarks>
public static class SyntheticSeriesGenerator
{
    /// <summary>
    /// The default seed used by the sample. Chosen only for readability of the output.
    /// </summary>
    public const int DefaultSeed = 20_240_101;

    private static readonly DateTime DefaultStartDate = new(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Generates a synthetic OHLCV series.
    /// </summary>
    /// <param name="barCount">The number of bars to generate. Zero produces an empty series.</param>
    /// <param name="seed">The PRNG seed. Identical seeds produce identical series. Defaults to <see cref="DefaultSeed"/>.</param>
    /// <param name="startPrice">The price the first bar opens at. Defaults to <c>100</c>.</param>
    /// <param name="annualDrift">The annual drift of the log price, as a decimal fraction. Defaults to <c>0.12</c> (12% a year).</param>
    /// <param name="annualVolatility">
    /// The annual volatility of the log price, as a decimal fraction. Defaults to <c>0.22</c> (22% a year).
    /// </param>
    /// <param name="barsPerYear">
    /// The number of bars in a year, used to de-annualise the drift and volatility. Defaults to <c>252</c>.
    /// </param>
    /// <param name="startDate">The timestamp of the first bar. Defaults to 2015-01-01 UTC.</param>
    /// <returns>A well-formed bar series of length <paramref name="barCount"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">An argument is negative, non-finite or otherwise out of range.</exception>
    public static IReadOnlyList<Bar> Generate(
        int barCount,
        int seed = DefaultSeed,
        double startPrice = 100.0,
        double annualDrift = 0.12,
        double annualVolatility = 0.22,
        int barsPerYear = 252,
        DateTime? startDate = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(barCount);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(startPrice);
        ArgumentOutOfRangeException.ThrowIfNegative(annualVolatility);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(barsPerYear);

        if (barCount == 0)
        {
            return [];
        }

        DeterministicRandom random = new(seed);
        double drift = annualDrift / barsPerYear;
        double volatility = annualVolatility / Math.Sqrt(barsPerYear);
        double gapVolatility = volatility * 0.30;
        double wickVolatility = volatility * 0.55;

        List<Bar> bars = new(barCount);
        DateTime timestamp = startDate ?? DefaultStartDate;
        double previousClose = startPrice;

        for (int i = 0; i < barCount; i++)
        {
            double open = i == 0
                ? startPrice
                : previousClose * Math.Exp(gapVolatility * random.NextGaussian());

            double close = open * Math.Exp(drift - (0.5 * volatility * volatility) + (volatility * random.NextGaussian()));

            double bodyHigh = Math.Max(open, close);
            double bodyLow = Math.Min(open, close);
            double high = bodyHigh * Math.Exp(Math.Abs(random.NextGaussian()) * wickVolatility);
            double low = bodyLow * Math.Exp(-Math.Abs(random.NextGaussian()) * wickVolatility);
            double volume = Math.Round(1_000_000.0 * Math.Exp(0.35 * random.NextGaussian()));

            bars.Add(new Bar(timestamp, open, high, low, close, volume));

            previousClose = close;
            timestamp = NextWeekday(timestamp);
        }

        return bars;
    }

    private static DateTime NextWeekday(DateTime timestamp)
    {
        DateTime next = timestamp.AddDays(1);
        while (next.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
        {
            next = next.AddDays(1);
        }

        return next;
    }
}
