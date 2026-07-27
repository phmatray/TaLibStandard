// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Collections.Concurrent;

namespace TechnicalAnalysis.Benchmarks.Data;

/// <summary>
/// Produces deterministic, fully offline OHLCV series for benchmarking.
/// </summary>
/// <remarks>
/// <para>
/// The close price follows a discretised geometric Brownian motion
/// <c>C[i] = C[i-1] * exp((mu - sigma^2 / 2) * dt + sigma * sqrt(dt) * Z)</c> with a trading-day time step.
/// The open gaps away from the previous close, and the high / low extend beyond the candle body by an exponential
/// wick whose size is itself a random draw, so candlestick pattern recognisers see realistic bodies and shadows
/// instead of degenerate bars. Volume is log-normal and correlated with the absolute return of the bar.
/// </para>
/// <para>
/// Everything is driven by <see cref="DeterministicRandom"/> with a fixed default seed, so two runs on two machines
/// see byte-identical inputs. No network access, no market data provider, no files.
/// </para>
/// </remarks>
public static class MarketDataGenerator
{
    /// <summary>
    /// The default seed. Change it only if every published benchmark number is regenerated at the same time.
    /// </summary>
    public const int DefaultSeed = 20240217;

    /// <summary>
    /// The price the primary instrument starts from.
    /// </summary>
    private const double InitialPrice = 100.0;

    /// <summary>
    /// The price the correlated reference instrument starts from.
    /// </summary>
    private const double ReferenceInitialPrice = 250.0;

    /// <summary>
    /// The annualised drift of the geometric Brownian motion.
    /// </summary>
    private const double Drift = 0.08;

    /// <summary>
    /// The annualised volatility of the geometric Brownian motion.
    /// </summary>
    private const double Volatility = 0.25;

    /// <summary>
    /// The number of trading days per year, i.e. the inverse of the time step.
    /// </summary>
    private const double TradingDaysPerYear = 252.0;

    /// <summary>
    /// The instantaneous correlation between the primary and the reference instrument.
    /// </summary>
    private const double ReferenceCorrelation = 0.65;

    /// <summary>
    /// The median traded volume of a bar.
    /// </summary>
    private const double MedianVolume = 1_000_000.0;

    /// <summary>
    /// Number of decimal places every generated price is rounded to, so the decimal projection is lossless.
    /// </summary>
    private const int PriceDecimals = 4;

    private static readonly ConcurrentDictionary<(int Length, int Seed), MarketSeries> Cache = new();

    /// <summary>
    /// Generates (or returns a cached) market series of the requested length.
    /// </summary>
    /// <param name="length">The number of bars to generate. Must be at least two.</param>
    /// <param name="seed">The seed. Defaults to <see cref="DefaultSeed"/>.</param>
    /// <returns>A deterministic <see cref="MarketSeries"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="length"/> is less than two.</exception>
    /// <remarks>
    /// Results are cached per (length, seed) pair. Generation happens in <c>[GlobalSetup]</c>, never inside a measured
    /// method, so caching does not influence any timing; it only keeps repeated setups cheap.
    /// </remarks>
    public static MarketSeries Generate(int length, int seed = DefaultSeed)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 2);

        return Cache.GetOrAdd((length, seed), static key => GenerateCore(key.Length, key.Seed));
    }

    private static MarketSeries GenerateCore(int length, int seed)
    {
        DeterministicRandom random = new(seed);

        double dt = 1.0 / TradingDaysPerYear;
        double barDrift = (Drift - (0.5 * Volatility * Volatility)) * dt;
        double barVolatility = Volatility * Math.Sqrt(dt);
        double crossVolatility = Math.Sqrt(1.0 - (ReferenceCorrelation * ReferenceCorrelation));

        double[] open = new double[length];
        double[] high = new double[length];
        double[] low = new double[length];
        double[] close = new double[length];
        double[] volume = new double[length];

        double[] refOpen = new double[length];
        double[] refHigh = new double[length];
        double[] refLow = new double[length];
        double[] refClose = new double[length];
        double[] refVolume = new double[length];

        double price = InitialPrice;
        double referencePrice = ReferenceInitialPrice;

        for (int i = 0; i < length; i++)
        {
            double shock = random.NextGaussian();
            double referenceShock = (ReferenceCorrelation * shock) + (crossVolatility * random.NextGaussian());

            BuildBar(random, ref price, barDrift, barVolatility, shock, i, open, high, low, close, volume);
            BuildBar(
                random,
                ref referencePrice,
                barDrift,
                barVolatility * 0.8,
                referenceShock,
                i,
                refOpen,
                refHigh,
                refLow,
                refClose,
                refVolume);
        }

        OhlcvSeries<double> doubles = new(open, high, low, close, volume);
        OhlcvSeries<double> referenceDoubles = new(refOpen, refHigh, refLow, refClose, refVolume);

        return new MarketSeries(
            seed,
            doubles,
            ToSingle(doubles),
            ToDecimal(doubles),
            referenceDoubles,
            ToSingle(referenceDoubles));
    }

    private static void BuildBar(
        DeterministicRandom random,
        ref double price,
        double barDrift,
        double barVolatility,
        double shock,
        int index,
        double[] open,
        double[] high,
        double[] low,
        double[] close,
        double[] volume)
    {
        double previousClose = price;

        // Overnight gap: a fraction of a daily move, so the open is close to but rarely equal to the previous close.
        double gap = 0.20 * barVolatility * random.NextGaussian();
        double barOpen = previousClose * Math.Exp(gap);
        double barClose = previousClose * Math.Exp(barDrift + (barVolatility * shock));

        double bodyHigh = Math.Max(barOpen, barClose);
        double bodyLow = Math.Min(barOpen, barClose);

        // Wicks are always non-negative and independent of the body direction.
        double upperWick = Math.Abs(random.NextGaussian()) * barVolatility * 0.6;
        double lowerWick = Math.Abs(random.NextGaussian()) * barVolatility * 0.6;

        double barHigh = bodyHigh * Math.Exp(upperWick);
        double barLow = bodyLow * Math.Exp(-lowerWick);

        // Volume is log-normal and grows with the magnitude of the bar's return.
        double relativeMove = Math.Abs((barClose / previousClose) - 1.0);
        double barVolume = MedianVolume * Math.Exp(0.35 * random.NextGaussian()) * (1.0 + (8.0 * relativeMove));

        barOpen = Math.Round(barOpen, PriceDecimals, MidpointRounding.AwayFromZero);
        barClose = Math.Round(barClose, PriceDecimals, MidpointRounding.AwayFromZero);
        barHigh = Math.Round(barHigh, PriceDecimals, MidpointRounding.AwayFromZero);
        barLow = Math.Round(barLow, PriceDecimals, MidpointRounding.AwayFromZero);

        // Rounding must never break the OHLC invariants that every candlestick recogniser relies upon.
        barHigh = Math.Max(barHigh, Math.Max(barOpen, barClose));
        barLow = Math.Min(barLow, Math.Min(barOpen, barClose));

        open[index] = barOpen;
        high[index] = barHigh;
        low[index] = barLow;
        close[index] = barClose;
        volume[index] = Math.Round(barVolume / 100.0, MidpointRounding.AwayFromZero) * 100.0;

        price = barClose;
    }

    private static OhlcvSeries<float> ToSingle(OhlcvSeries<double> source)
    {
        return new OhlcvSeries<float>(
            ToSingle(source.Open),
            ToSingle(source.High),
            ToSingle(source.Low),
            ToSingle(source.Close),
            ToSingle(source.Volume));
    }

    private static OhlcvSeries<decimal> ToDecimal(OhlcvSeries<double> source)
    {
        return new OhlcvSeries<decimal>(
            ToDecimal(source.Open),
            ToDecimal(source.High),
            ToDecimal(source.Low),
            ToDecimal(source.Close),
            ToDecimal(source.Volume));
    }

    private static float[] ToSingle(double[] source)
    {
        float[] result = new float[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = (float)source[i];
        }

        return result;
    }

    private static decimal[] ToDecimal(double[] source)
    {
        decimal[] result = new decimal[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = (decimal)source[i];
        }

        return result;
    }
}
