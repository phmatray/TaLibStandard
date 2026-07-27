using Demo.BlazorWasm.Models;

namespace Demo.BlazorWasm.Services;

/// <summary>
/// Supplies the demo's price history from a deterministic generator that runs entirely in the browser.
/// </summary>
/// <remarks>
/// The previous implementation fetched Yahoo Finance through a third-party CORS proxy, so the demo
/// showed nothing whenever that proxy was rate-limited, blocked or offline - which is most of the time.
/// This library computes indicators; it does not need a live market to demonstrate that, and a page that
/// renders reliably is worth more than one that occasionally renders real quotes.
///
/// The instruments are openly fictional and named so, because presenting generated numbers under a real
/// ticker would be a lie the reader has no way to detect. Each series is seeded, so a given instrument
/// looks identical on every visit and in every browser, which also makes the indicator values quotable.
/// </remarks>
public sealed class SyntheticMarketDataService : IMarketDataService
{
    private static readonly Instrument[] Catalogue =
    [
        new("ARC", "Arcadia Composite", Seed: 20260727, Start: 184.00, Drift: 0.11, Volatility: 0.22),
        new("HLX", "Helix Materials", Seed: 81423, Start: 42.50, Drift: -0.06, Volatility: 0.34),
        new("MRD", "Meridian Freight", Seed: 5150, Start: 96.25, Drift: 0.03, Volatility: 0.15),
        new("VNT", "Vantage Semiconductor", Seed: 90210, Start: 310.75, Drift: 0.24, Volatility: 0.47),
    ];

    /// <summary>
    /// Gets the instruments the demo can chart, in display order.
    /// </summary>
    public static IReadOnlyList<Instrument> Instruments => Catalogue;

    /// <inheritdoc />
    public Task<List<StockData>> GetHistoricalDataAsync(string symbol, int days = 100)
    {
        Instrument instrument = Resolve(symbol);
        return Task.FromResult(Generate(instrument, days));
    }

    /// <inheritdoc />
    public Task<List<string>> SearchSymbolsAsync(string query)
    {
        IEnumerable<Instrument> matches = string.IsNullOrWhiteSpace(query)
            ? Catalogue
            : Catalogue.Where(i =>
                i.Symbol.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                i.Name.Contains(query, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(matches.Select(i => i.Symbol).ToList());
    }

    /// <summary>
    /// Finds an instrument by symbol, falling back to the first one for an unknown symbol.
    /// </summary>
    /// <param name="symbol">The instrument symbol, case-insensitive.</param>
    /// <returns>The matching instrument, or the default instrument when there is no match.</returns>
    public static Instrument Resolve(string? symbol)
    {
        return Catalogue.FirstOrDefault(
            i => string.Equals(i.Symbol, symbol, StringComparison.OrdinalIgnoreCase),
            Catalogue[0]);
    }

    /// <summary>
    /// Builds one instrument's daily bars.
    /// </summary>
    /// <remarks>
    /// A discretised geometric Brownian motion drives the close, an overnight gap opens each bar, and the
    /// high and low extend beyond the body by independent exponential draws. Bars land on weekdays only,
    /// counting back from a fixed date so the axis never shifts under the reader.
    /// </remarks>
    private static List<StockData> Generate(Instrument instrument, int days)
    {
        int count = Math.Clamp(days, 30, 750);
        DeterministicRandom random = new(instrument.Seed);
        List<StockData> bars = new(count);

        const double tradingDaysPerYear = 252.0;
        double dt = 1.0 / tradingDaysPerYear;
        double drift = (instrument.Drift - (0.5 * instrument.Volatility * instrument.Volatility)) * dt;
        double diffusion = instrument.Volatility * Math.Sqrt(dt);

        double close = instrument.Start;
        DateTime date = WeekdaysBefore(new DateTime(2026, 7, 24, 0, 0, 0, DateTimeKind.Utc), count);

        for (int i = 0; i < count; i++)
        {
            double previousClose = close;
            close = previousClose * Math.Exp(drift + (diffusion * random.NextGaussian()));

            double gap = previousClose * instrument.Volatility * 0.02 * random.NextGaussian();
            double open = i == 0 ? previousClose : previousClose + gap;

            double body = Math.Abs(close - open);
            double wick = (body * 0.6) + (previousClose * instrument.Volatility * 0.015 * random.NextExponential());
            double high = Math.Max(open, close) + (wick * random.NextDouble());
            double low = Math.Min(open, close) - (wick * random.NextDouble());

            // A quiet bar still trades; volume rises with the size of the move.
            double intensity = 1.0 + (12.0 * (body / Math.Max(previousClose, 1e-9)));
            long volume = (long)(random.NextLogNormal(14.2, 0.45) * intensity);

            bars.Add(new StockData
            {
                Date = date,
                Open = Round(open),
                High = Round(Math.Max(high, Math.Max(open, close))),
                Low = Round(Math.Min(low, Math.Min(open, close))),
                Close = Round(close),
                Volume = volume,
            });

            date = NextWeekday(date);
        }

        return bars;
    }

    private static decimal Round(double value)
    {
        return Math.Round((decimal)value, 2, MidpointRounding.AwayFromZero);
    }

    private static DateTime NextWeekday(DateTime date)
    {
        DateTime next = date.AddDays(1);
        while (next.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
        {
            next = next.AddDays(1);
        }

        return next;
    }

    private static DateTime WeekdaysBefore(DateTime end, int count)
    {
        DateTime cursor = end;
        for (int i = 0; i < count; i++)
        {
            cursor = cursor.AddDays(-1);
            while (cursor.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            {
                cursor = cursor.AddDays(-1);
            }
        }

        return cursor;
    }

    /// <summary>
    /// A synthetic instrument the demo can chart.
    /// </summary>
    /// <param name="Symbol">The short ticker shown in the interface.</param>
    /// <param name="Name">The full instrument name.</param>
    /// <param name="Seed">The seed that fixes this instrument's price path.</param>
    /// <param name="Start">The first close, in currency units.</param>
    /// <param name="Drift">Annualised expected return, as a fraction.</param>
    /// <param name="Volatility">Annualised volatility, as a fraction.</param>
    public sealed record Instrument(string Symbol, string Name, int Seed, double Start, double Drift, double Volatility);

    /// <summary>
    /// A small seeded generator, so the demo draws the same series on every visit and in every browser.
    /// </summary>
    /// <remarks>
    /// <see cref="System.Random"/> does not guarantee that a given seed produces the same sequence across
    /// runtime versions, which would let the charted numbers drift between releases. splitmix64 feeding
    /// xoshiro256** is short, fast and fully specified, so the output is reproducible by construction.
    /// </remarks>
    private sealed class DeterministicRandom
    {
        private ulong _s0;
        private ulong _s1;
        private ulong _s2;
        private ulong _s3;
        private double? _spareGaussian;

        public DeterministicRandom(int seed)
        {
            ulong state = (ulong)seed + 0x9E3779B97F4A7C15UL;
            _s0 = SplitMix64(ref state);
            _s1 = SplitMix64(ref state);
            _s2 = SplitMix64(ref state);
            _s3 = SplitMix64(ref state);
        }

        /// <summary>Returns a value in [0, 1).</summary>
        public double NextDouble()
        {
            return (NextUInt64() >> 11) * (1.0 / 9007199254740992.0);
        }

        /// <summary>Returns a standard normal draw using the Marsaglia polar method.</summary>
        public double NextGaussian()
        {
            if (_spareGaussian is { } spare)
            {
                _spareGaussian = null;
                return spare;
            }

            double u;
            double v;
            double s;
            do
            {
                u = (2.0 * NextDouble()) - 1.0;
                v = (2.0 * NextDouble()) - 1.0;
                s = (u * u) + (v * v);
            }
            while (s is >= 1.0 or 0.0);

            double factor = Math.Sqrt(-2.0 * Math.Log(s) / s);
            _spareGaussian = v * factor;
            return u * factor;
        }

        /// <summary>Returns an exponential draw with unit mean.</summary>
        public double NextExponential()
        {
            return -Math.Log(1.0 - NextDouble());
        }

        /// <summary>Returns a log-normal draw with the given underlying mean and standard deviation.</summary>
        public double NextLogNormal(double mu, double sigma)
        {
            return Math.Exp(mu + (sigma * NextGaussian()));
        }

        private ulong NextUInt64()
        {
            ulong result = ulong.RotateLeft(_s1 * 5, 7) * 9;
            ulong t = _s1 << 17;

            _s2 ^= _s0;
            _s3 ^= _s1;
            _s1 ^= _s2;
            _s0 ^= _s3;
            _s2 ^= t;
            _s3 = ulong.RotateLeft(_s3, 45);

            return result;
        }

        private static ulong SplitMix64(ref ulong state)
        {
            state += 0x9E3779B97F4A7C15UL;
            ulong z = state;
            z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
            z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
            return z ^ (z >> 31);
        }
    }
}
