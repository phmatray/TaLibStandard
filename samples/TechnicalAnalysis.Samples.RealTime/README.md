# Real-time indicators over WebSocket and SignalR

A streaming server that turns a synthetic tick feed into OHLCV bars, recomputes seven TaLibStandard
indicators — SMA fast, SMA slow, EMA, RSI, ATR, MACD and Bollinger Bands, eleven output series in all —
on every closed bar, and pushes the results to browsers and .NET clients over **both**
transports the issue asks for: raw WebSocket and SignalR.

Everything runs offline. There is no market data provider, no API key, and no network call — the price
path comes from a seeded random walk, so the same seed always produces the same prices.

```
ticks ──► BarAggregator ──► RollingIndicatorEngine ──► IndicatorSnapshot ──┬──► SignalR /hubs/indicators
 (feed)     1s..Ns bars        window recompute          nullable values   └──► WebSocket /ws/indicators
```

## Run it

```bash
# server, with the default 5-second bars
dotnet run --project samples/TechnicalAnalysis.Samples.RealTime

# then open http://localhost:5199
```

The port comes from `"Urls"` in `appsettings.json` rather than a launch profile, because
`Properties/launchSettings.json` is gitignored repo-wide and would not survive a clone. Override it with
`--urls http://127.0.0.1:8080` like any other host setting.

Five-second bars take about three minutes before every indicator is warm. For a quicker look, shorten
the bar period:

```bash
dotnet run --project samples/TechnicalAnalysis.Samples.RealTime -- \
  --urls http://127.0.0.1:5199 \
  --RealTime:BarSeconds=1 \
  --RealTime:TickIntervalMilliseconds=100
```

The console client lives in the sibling project:

```bash
# push transport (SignalR groups), default symbol
dotnet run --project samples/TechnicalAnalysis.Samples.RealTime.Client

# a specific symbol, the hub's streaming method, and a time limit
dotnet run --project samples/TechnicalAnalysis.Samples.RealTime.Client -- \
  http://127.0.0.1:5199 --symbol GLOBEX --stream --seconds 30
```

## Endpoints

| Endpoint | What it does |
| --- | --- |
| `GET /` | The live dashboard. One file, no CDN, no npm, no build step. |
| `GET /health` | Uptime, symbols, ticks published, bars closed, `snapshotSubscribers` (channel subscribers: raw WebSocket and hub streaming), `groupSubscribers` (SignalR push subscriptions) and `pushesDropped`. |
| `GET /api/symbols` | The symbols this server publishes. |
| `WS /ws/indicators?symbol=ACME` | Raw socket. Omit `symbol` for the first configured one. |
| `/hubs/indicators` | SignalR hub. |

### SignalR hub methods

| Method | Kind | Notes |
| --- | --- | --- |
| `GetSymbols()` | invoke | Returns the symbol list. |
| `Subscribe(symbol)` | invoke | Joins the symbol's group; the latest snapshot is replayed immediately. |
| `Unsubscribe(symbol)` | invoke | Leaves the group. |
| `StreamSnapshots(symbol)` | stream | `IAsyncEnumerable<IndicatorSnapshot>`, honours the caller's cancellation token. |
| `snapshot` | client method | Invoked by the server with each closed bar's snapshot. |

Group membership is per connection, so a client that reconnects must call `Subscribe` again — the
console client shows how.

### Raw socket frames

One `session` frame on connect, then one `snapshot` frame per closed bar. Real frames captured from a
running server, wrapped for width and with the always-null sibling properties elided:

```json
{"type":"session","session":{"symbol":"ACME","symbols":["ACME","GLOBEX","INITECH"],"barSeconds":1,
 "tickIntervalMilliseconds":100,"windowSize":256,"periods":{"smaFast":10,"smaSlow":30,"ema":20,"rsi":14,
 "macdFast":12,"macdSlow":26,"macdSignal":9,"bollinger":20,"bollingerDeviations":2,"atr":14}}}

{"type":"snapshot","snapshot":{"symbol":"ACME","timestamp":"2026-07-27T12:18:36+00:00","close":343.65,
 "sequence":308,"smaFast":343.964,"smaSlow":347.01933333333307,"ema":345.0055987766077,
 "rsi":43.62551333468498,"macd":-1.3233998227737516,"macdSignal":-1.127486559231894,
 "macdHistogram":-0.19591326354185767,"bollingerUpper":348.25611962208296,
 "bollingerMiddle":344.9424999999999,"bollingerLower":341.6288803779168,"atr":4.706082652336289E+267,
 "signal":"Bearish","barsInWindow":256,"barsRequired":34,"isWarmedUp":true}}
```

That `atr` is not a typo — see [Known library defects](#known-library-defects-that-show-up-here).

An unknown symbol gets an `error` frame followed by a `PolicyViolation` close.

## The part worth reading: output alignment

`RollingIndicatorEngine` is where a streaming integration usually goes wrong, and the whole sample
exists to get it right.

TA-Lib is a batch API. `TAMath.Sma(0, lastIndex, close, 30)` allocates an output array of
`lastIndex + 1` elements and fills it **from index zero** — the output is not parallel to the input.
The mapping is:

```
output[k]  describes  input index (BegIdx + k),  for k in [0, NBElement)
```

Everything from `NBElement` onwards is an uninitialised zero that means nothing. So the newest value is
`output[NBElement - 1]`, never `output[lastIndex]`. Reading `output[lastIndex]` with a 256-bar window and
a 30-bar lookback lands 29 elements past the real data and returns a zero dressed up as a price — and
because zero is a plausible-looking number, nothing downstream notices.

The engine asserts the mapping instead of assuming it: it computes `BegIdx + NBElement - 1` and returns
the value only if that really is the newest bar's index. Otherwise it returns `null`.

**Null means null.** An indicator that has not warmed up is reported as `null`, never as `0` and never as
the previous bar's value. Both of those substitutions are indistinguishable from a real reading once the
number leaves the process. The dashboard renders a null as a dashed rule with a warm-up hairline, so you
can watch each indicator switch on.

## Window recompute versus incremental state

The engine keeps a fixed-size ring buffer of the last N closed bars and recomputes every indicator over
that window on each new bar. The alternative — keeping each indicator's internal state and advancing it
by one bar — is O(1) instead of O(window), and it is what a production feed handler does at scale. It
also means reimplementing the exact arithmetic of every indicator you use and keeping it in step with the
library forever; the day your EMA seeding differs by an epsilon, your live values and your backtest values
disagree and the difference is very hard to find.

Recomputing costs a few microseconds per bar and buys you the guarantee that the number a client sees
came from the same library, on the same code path, as the number a backtest sees.

**Window size.** With the defaults the largest lookback is MACD(12,26,9) at 34 bars, exposed as
`barsRequired`. The window defaults to 256, roughly seven times that, and the margin is deliberate:
exponentially smoothed indicators have no exact finite lookback. TA-Lib seeds an EMA with a simple
average and then decays it, so the seed's residual weight falls by `(1 - 2/(n+1))` per bar. At 256 bars an
EMA(20) retains about 4e-11 of its seed — invisible. A 40-bar window would produce plausible values that
quietly drift from the batch answer. Size the window from the slowest smoothed indicator's decay, not
from its nominal period.

## Backpressure

Every subscriber — each browser tab, each console client, each hub stream — gets its own bounded channel
created with `BoundedChannelFullMode.DropOldest`. A consumer that stops reading loses its oldest queued
frames; it never stalls the producer.

That is the right policy for a market feed and the wrong one for an order feed. A price that is 40 bars
late is worth nothing: a slow consumer wants the current bar, not a replay of the last forty. `Wait`
would let the slowest subscriber throttle every other subscriber, which is how one wedged client takes
down a whole feed; an unbounded channel trades that stall for unbounded memory. Dropping is not silent —
`sequence` increments by one per bar, so a client can see the gap, and the console client counts them.

Anything that must not be lost belongs on a different, acknowledged channel.

## Configuration

All of it binds from the `RealTime` section of `appsettings.json` and can be overridden on the command
line (`--RealTime:BarSeconds=1`) or by environment variable (`RealTime__BarSeconds=1`).

| Key | Default | Meaning |
| --- | --- | --- |
| `Symbols` | `ACME`, `GLOBEX`, `INITECH` | Instruments to publish. The first is the page's default. |
| `TickIntervalMilliseconds` | `250` | Time between synthetic ticks. |
| `BarSeconds` | `5` | Bar period. Bars align to absolute time, not to server start. |
| `RandomSeed` | `20240613` | Seeds the price walk. Same seed, same prices. |
| `WindowSize` | `256` | Bars kept per symbol. Must exceed the largest lookback. |
| `SubscriberQueueCapacity` | `64` | Frames a subscriber may buffer before the oldest is dropped. |
| `Volatility` | `0.0015` | Per-tick log-return standard deviation. |
| `MeanReversion` | `0.0025` | Pull back towards each symbol's base price, per tick. |
| `Indicators:*` | see file | Periods for SMA fast/slow, EMA, RSI, MACD, Bollinger, ATR. |

Options are validated at startup with `ValidateOnStart`, so a period below 2 — which `TAMath` rejects
with `RetCode.BadParam` and which would therefore null an indicator forever — fails the boot instead.

`Symbols` deliberately has no code-side default. The configuration binder *appends* to a collection that
already holds items, so three defaults plus three in `appsettings.json` bind to six duplicated symbols.
Startup validation rejects an empty list, which turns a missing configuration file into a clear error.

## Determinism

The seed fixes the price path exactly. It does not fix bar contents: tick timestamps come from the real
clock, so which ticks land in which bar depends on timer jitter and machine load. Drive the aggregator
from a virtual clock if you need bars reproducible to the cent.

## Known library defects that show up here

Two bugs in `src/TechnicalAnalysis.Functions` are visible in this sample's output. They are library
issues, not sample issues, and the sample deliberately calls the library the recommended way rather than
working around them. The same list, with the full blast radius, is in
[Known library defects](../../docs/guides/getting-started.md#10-known-library-defects).

1. **`ATR` diverges.** `Atr/TAFunc.cs` multiplies the running average by `period - 1` and adds the new
   true range, but only divides the *stored* value by `period` — the accumulator itself is never
   normalised, so it grows by a factor of `period - 1` every bar. On a constant series with true range
   2.0 and `period` 14, ATR reads `2, 2, 26.14, 340, 4420, …` and reaches 1e27 within 40 bars. Only the
   first two output elements are correct. Until it is fixed, ignore the ATR column.

2. **`EMA` seeds itself low.** `TAFunc.cs`'s `TA_INT_EMA` seed loop sums `period - 1` values and then
   divides by `period`, so the seed is the true average scaled by `(period - 1) / period`. On a constant
   series of 100, EMA(20) starts at 95.48 instead of 100. The error decays with the smoothing factor, so
   a long window hides it in steady state — but it distorts every value for the first few dozen bars, and
   it propagates to MACD, DEMA, TEMA, T3, APO, PPO and TRIX. MACD over a constant series returns 0.53
   where it should return 0.

A third, milder one: `Rsi/TAFunc.cs` divides by `prevGain + prevLoss` without the zero guard TA-Lib has,
so a perfectly flat series yields `NaN` rather than `0`. The engine's `double.IsFinite` check converts
that to `null`, which is why the dashboard shows a dash rather than `NaN`.

## Files

| Path | Role |
| --- | --- |
| `Contracts/` | Wire types plus the `JsonSerializerContext` used by all three exits. |
| `Configuration/RealTimeOptions.cs` | Everything tunable, bound via `IOptions`. |
| `Streaming/SyntheticMarketDataFeed.cs` | Seeded tick generator, `BackgroundService`, fans out to N subscribers. |
| `Streaming/BarAggregator.cs` | Ticks to OHLCV bars on absolute time boundaries. |
| `Streaming/BoundedFanout.cs` | The drop-oldest fanout and its race-free subscription handle. |
| `Streaming/SnapshotBroadcaster.cs` | Per-symbol distribution plus last-snapshot replay. |
| `Streaming/IndicatorPipeline.cs` | The single loop: tick in, bar out, snapshot out, both transports. The SignalR group send runs on its own bounded pump so a wedged subscriber cannot stall the loop. |
| `Indicators/RollingIndicatorEngine.cs` | Ring buffer, window recompute, alignment, warm-up nulls. |
| `Hubs/IndicatorHub.cs` | SignalR push and streaming. |
| `WebSockets/IndicatorWebSocketHandler.cs` | Raw socket, close handshake, cancellation. |
| `wwwroot/index.html` | The dashboard. Vanilla JS and canvas, zero dependencies. |
