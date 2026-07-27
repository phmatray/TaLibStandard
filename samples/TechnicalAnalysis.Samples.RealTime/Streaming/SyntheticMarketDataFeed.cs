// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using Microsoft.Extensions.Options;
using TechnicalAnalysis.Samples.RealTime.Configuration;
using TechnicalAnalysis.Samples.RealTime.Contracts;
using TechnicalAnalysis.Samples.RealTime.Diagnostics;

namespace TechnicalAnalysis.Samples.RealTime.Streaming;

/// <summary>
/// Generates a deterministic synthetic tick stream and fans it out to every subscriber.
/// </summary>
/// <remarks>
/// <para>
/// The sample must run offline, in CI, on a plane, with no API key and no market open, and it must
/// produce the same prices every time so a reader can compare their output with the README's. Every
/// symbol therefore walks a seeded mean-reverting geometric random walk: the log price takes a Gaussian
/// step and is pulled gently back towards a base level derived from the symbol name. Seeded
/// <see cref="Random"/> is stable across runs, machines and platforms, so
/// <see cref="RealTimeOptions.RandomSeed"/> fully determines the price path.
/// </para>
/// <para>
/// Determinism covers prices, not wall-clock timing. Tick timestamps come from the real clock, so which
/// ticks land in which bar depends on timer jitter and machine load. If you need bar contents to be
/// reproducible to the cent, drive the aggregator from a virtual clock instead.
/// </para>
/// <para>
/// The feed is registered once as a singleton and again as a hosted service, so callers can
/// <see cref="Subscribe"/> to the very same instance the background loop publishes into.
/// </para>
/// </remarks>
public sealed class SyntheticMarketDataFeed : BackgroundService
{
    private readonly BoundedFanout<Tick> _fanout;
    private readonly SymbolWalk[] _walks;
    private readonly TimeSpan _interval;
    private readonly ILogger<SyntheticMarketDataFeed> _logger;
    private long _publishedTicks;

    /// <summary>
    /// Initializes a new instance of the <see cref="SyntheticMarketDataFeed"/> class.
    /// </summary>
    /// <param name="options">The bound sample options.</param>
    /// <param name="logger">The logger used for lifecycle messages.</param>
    public SyntheticMarketDataFeed(IOptions<RealTimeOptions> options, ILogger<SyntheticMarketDataFeed> logger)
    {
        ArgumentNullException.ThrowIfNull(options);

        RealTimeOptions value = options.Value;
        _logger = logger;
        _interval = TimeSpan.FromMilliseconds(value.TickIntervalMilliseconds);
        _fanout = new BoundedFanout<Tick>(value.SubscriberQueueCapacity);
        Symbols = [.. value.Symbols];
        _walks = new SymbolWalk[Symbols.Count];

        for (int i = 0; i < Symbols.Count; i++)
        {
            _walks[i] = new SymbolWalk(Symbols[i], value);
        }
    }

    /// <summary>
    /// Gets the symbols this feed publishes, in configuration order.
    /// </summary>
    public IReadOnlyList<string> Symbols { get; }

    /// <summary>
    /// Gets the number of ticks generated since the process started.
    /// </summary>
    public long PublishedTicks => Interlocked.Read(ref _publishedTicks);

    /// <summary>
    /// Gets the number of live tick subscribers.
    /// </summary>
    public int SubscriberCount => _fanout.SubscriberCount;

    /// <summary>
    /// Subscribes to the tick stream.
    /// </summary>
    /// <returns>A subscription the caller must dispose when it stops reading.</returns>
    public FanoutSubscription<Tick> Subscribe() => _fanout.Subscribe();

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        SampleLog.FeedStarting(_logger, Symbols.Count, _interval.TotalMilliseconds);

        using PeriodicTimer timer = new(_interval);

        try
        {
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                DateTimeOffset timestamp = DateTimeOffset.UtcNow;
                foreach (SymbolWalk walk in _walks)
                {
                    _fanout.Publish(walk.Next(timestamp));
                    Interlocked.Increment(ref _publishedTicks);
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Expected on shutdown.
        }

        SampleLog.FeedStopped(_logger, PublishedTicks);
    }

    /// <summary>
    /// One symbol's seeded price process.
    /// </summary>
    private sealed class SymbolWalk
    {
        private readonly Random _random;
        private readonly string _symbol;
        private readonly double _basePrice;
        private readonly double _volatility;
        private readonly double _meanReversion;
        private double _price;
        private double? _spareGaussian;

        public SymbolWalk(string symbol, RealTimeOptions options)
        {
            _symbol = symbol;
            _volatility = options.Volatility;
            _meanReversion = options.MeanReversion;

            // Mixing the seed with a stable hash of the symbol gives every instrument its own path while
            // keeping the whole feed reproducible from one number. string.GetHashCode is randomised per
            // process, so it deliberately is not used here.
            int symbolSeed = unchecked((options.RandomSeed * 397) ^ (int)StableHash(symbol));
            _random = new Random(symbolSeed);

            // Base prices land in [40, 360) so the symbols are visually distinct on a shared axis.
            _basePrice = 40.0 + (StableHash(symbol) % 320u);
            _price = _basePrice;
        }

        public Tick Next(DateTimeOffset timestamp)
        {
            double pull = _meanReversion * Math.Log(_basePrice / _price);
            double shock = _volatility * NextGaussian();
            _price *= Math.Exp(pull - (0.5 * _volatility * _volatility) + shock);
            _price = Math.Clamp(_price, 1.0, 1_000_000.0);

            decimal price = Math.Round((decimal)_price, 2, MidpointRounding.AwayFromZero);
            long volume = _random.Next(50, 5_000);

            return new Tick(_symbol, timestamp, price, volume);
        }

        /// <summary>
        /// FNV-1a over the symbol's characters: a stable, process-independent hash.
        /// </summary>
        private static uint StableHash(string value)
        {
            uint hash = 2166136261u;
            foreach (char character in value.ToUpperInvariant())
            {
                hash = unchecked((hash ^ character) * 16777619u);
            }

            return hash;
        }

        /// <summary>
        /// Box-Muller transform, caching the second variate the polar form produces for free.
        /// </summary>
        private double NextGaussian()
        {
            if (_spareGaussian is { } spare)
            {
                _spareGaussian = null;
                return spare;
            }

            double u1 = 1.0 - _random.NextDouble();
            double u2 = _random.NextDouble();
            double magnitude = Math.Sqrt(-2.0 * Math.Log(u1));

            _spareGaussian = magnitude * Math.Sin(2.0 * Math.PI * u2);
            return magnitude * Math.Cos(2.0 * Math.PI * u2);
        }
    }
}
