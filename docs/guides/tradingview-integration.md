# TradingView integration

TaLibStandard and TradingView meet in three places:

1. **You are porting a Pine Script strategy to C#** and need to know which `TAMath` call replaces
   which `ta.*` function — and where the two will legitimately disagree.
2. **You want a TradingView chart to display series that TaLibStandard computed**, which means
   implementing the UDF (Universal Data Feed) REST contract, or using Lightweight Charts.
3. **You want TradingView alerts to drive a .NET strategy**, which means receiving webhooks safely.

This guide covers all three. Read [Getting started](getting-started.md) first — in particular
§3 on `BegIdx` / `NBElement`, because every bar-index mistake in this guide's territory shows up as
a signal that fires one bar early or late.

---

## 0. Known library defects

**Read this before you reconcile anything.** Three defects in `src/TechnicalAnalysis.Functions` make
certain outputs impossible to match against a chart at *any* tolerance. If you are chasing one of
them, no amount of data provenance work will help. They are defects in the port, not differences in
convention, and none of them is Pine's fault.

| Defect | What you see | Location |
|---|---|---|
| **`Atr` never divides its running average** | `TAMath.Atr` grows by a factor of `period - 1` on every bar after the second output, reaching `+∞` within a few hundred bars. On a 1 500-bar series it reads `2.32` at bar 14, `29.97` at bar 16, `4.4e+110` at bar 114 and `+∞` from bar 300 onwards | `src/TechnicalAnalysis.Functions/Atr/TAFunc.cs`, main output loop |
| **`TA_INT_EMA` seeds itself low** | The seed sums `period - 1` values and divides by `period`, then smooths once more. The error decays with the smoothing factor, so it distorts the bars just after warm-up rather than the steady state. Blast radius: `Ema`, `Macd`, `MacdExt`, `MacdFix`, `Dema`, `Tema`, `T3`, `Apo`, `Ppo`, `Trix` | `src/TechnicalAnalysis.Functions/TAFunc.cs`, `TA_INT_EMA` seed loop |
| **`Rsi` returns `NaN` on a perfectly flat series** | `RetCode.Success`, a non-zero `NBElement`, and every element `NaN` — no zero guard on `prevGain + prevLoss`. Real-world trigger: a halted instrument, or any window with no price change | `src/TechnicalAnalysis.Functions/Rsi/TAFunc.cs` |

What this means for the rest of this guide:

- **`Atr`** — do not compare it to `ta.atr` at all. If you need ATR today, compute Wilder smoothing
  yourself over `TAMath.TrueRange`; the `Rma` helper in [§2.1](#21-wilder-smoothing-tarma) is
  exactly that recurrence and it is a dozen lines.
- **The EMA family** — expect a discrepancy against Pine that is *larger* than the seeding
  convention of [§2.2](#22-seeding-and-warm-up) explains, and that shrinks as you move away from the
  start of the series. Raising the unstable period ([§2.2](#22-seeding-and-warm-up)) discards the
  contaminated bars and is the practical mitigation.
- **`Rsi`** — guard your consumer with `double.IsFinite` before charting or comparing. `TAMath.Rsi`
  is otherwise structurally exact against `ta.rsi` (see [§2.1](#21-wilder-smoothing-tarma)).

`Natr`, `Adx`, `Adxr`, `Dx`, `Cmo`, `PlusDM` and `MinusDM` were checked against the same inputs and
are **not** affected — they are reconcilable in the normal way.

The same list appears in
[Backtesting → Limitations](backtesting.md#-limitations--read-before-believing-any-number) and in
[Real-time streaming → Known library defects](real-time-streaming.md#-known-library-defects-visible-in-this-sample),
which show what each defect does to a running strategy.

---

## 1. Pine Script `ta.*` → TaLibStandard

Signatures below are the `double[]` overloads. `last` means `close.Length - 1`. Every call also has
a `float[]` overload. See the [indicator reference](../indicators/README.md) for the full parameter
lists and defaults.

### Moving averages and overlays

| Pine Script | TaLibStandard | Notes |
| --- | --- | --- |
| `ta.sma(src, len)` | `TAMath.Sma(0, last, src, timePeriod: len)` | Exact structural match. |
| `ta.ema(src, len)` | `TAMath.Ema(0, last, src, timePeriod: len)` | Different seeding, and TaLibStandard's seed is also wrong — see [§0](#0-known-library-defects) and [§2.2](#22-seeding-and-warm-up). |
| `ta.wma(src, len)` | `TAMath.Wma(0, last, src, timePeriod: len)` | Exact structural match. |
| `ta.rma(src, len)` | *no direct entry point* | Wilder smoothing. Used internally by `Rsi`, `Atr`, `Adx`, `Dx`, `Cmo`, `Natr`, `PlusDM`, `MinusDM`. Roll your own if you need it standalone — see [§2.1](#21-wilder-smoothing-tarma). |
| *(no Pine builtin)* | `TAMath.Dema`, `TAMath.Tema`, `TAMath.Trima`, `TAMath.Kama`, `TAMath.T3`, `TAMath.Mama` | Pine users normally hand-roll these; TaLibStandard ships them. |
| `ta.vwma(src, len)` | *no equivalent* | Compose: `TAMath.Sma` of `src * volume` divided by `TAMath.Sma` of `volume`. |
| `ta.hma`, `ta.alma`, `ta.swma`, `ta.linreg`-based bands | *no equivalent* | `ta.hma` is composable from three `TAMath.Wma` calls. |
| `ta.bb(src, len, mult)` | `TAMath.BollingerBands(0, last, src, timePeriod: len, nbDevUp: mult, nbDevDn: mult, maType: MAType.Sma)` | **Tuple order differs**: Pine returns `[middle, upper, lower]`; the result exposes `RealUpperBand`, `RealMiddleBand`, `RealLowerBand`. |
| `ta.bbw(src, len, mult)` | *no equivalent* | `(RealUpperBand[k] - RealLowerBand[k]) / RealMiddleBand[k]`. |
| `ta.kc` (Keltner) | *no equivalent* | Compose from `TAMath.Ema` + `TAMath.Atr`. |
| `ta.sar(start, inc, max)` | `TAMath.Sar(0, last, high, low, acceleration: start, maximum: max)` | Pine exposes `start` **and** `increment` separately; TA-Lib's `acceleration` is both. Use `TAMath.SarExt` for independent long/short acceleration control. |
| `ta.supertrend(factor, atrPeriod)` | *no equivalent* | Compose from `TAMath.Atr`. |
| `ta.vwap` | *no equivalent* | See [§2.7](#27-vwap-has-no-ta-lib-equivalent). |
| *(no Pine builtin)* | `TAMath.ZigZag(0, last, high, low, deviation: 5.0)` | TaLibStandard extension, not part of TA-Lib. |

### Momentum and oscillators

| Pine Script | TaLibStandard | Notes |
| --- | --- | --- |
| `ta.rsi(src, len)` | `TAMath.Rsi(0, last, src, timePeriod: len)` | Same recurrence and same seeding — the closest thing to exact parity in this table. |
| `ta.macd(src, fast, slow, signal)` | `TAMath.Macd(0, last, src, optInFastPeriod: fast, optInSlowPeriod: slow, optInSignalPeriod: signal)` | Returns `MacdValue`, `MacdSignal`, `MacdHist`, matching Pine's `[macdLine, signalLine, histLine]`. Inherits EMA seeding differences. |
| `ta.stoch(src, high, low, len)` | `TAMath.StochF(0, last, high, low, close, fastKPeriod: len, fastDPeriod: 3, fastDMAType: MAType.Sma).FastK` | `ta.stoch` is **raw %K, unsmoothed**. Use `StochF.FastK`, not `TAMath.Stoch`. |
| TradingView "Stochastic" indicator (`%K` smoothing 3, `%D` 3) | `TAMath.Stoch(0, last, high, low, close, fastKPeriod: 14, slowKPeriod: 3, slowKMAType: MAType.Sma, slowDPeriod: 3, slowDMAType: MAType.Sma)` | `SlowK`, `SlowD`. |
| `ta.stoch` on `ta.rsi` (Stoch RSI) | `TAMath.StochRsi(0, last, src, timePeriod: 14, fastKPeriod: 5, fastDPeriod: 3, fastDMAType: MAType.Sma)` | `FastK`, `FastD`. |
| `ta.cci(src, len)` | `TAMath.Cci(0, last, high, low, close, timePeriod: len)` | Pine takes an arbitrary `src`; TA-Lib always uses typical price `(H+L+C)/3` internally. Compare against `ta.cci(hlc3, len)`. |
| `ta.mfi(src, len)` | `TAMath.Mfi(0, last, high, low, close, volume, timePeriod: len)` | Same typical-price caveat; compare against `ta.mfi(hlc3, len)`. |
| `ta.dmi(diLen, adxSmoothing)` | `TAMath.PlusDI(...)`, `TAMath.MinusDI(...)`, `TAMath.Adx(0, last, high, low, close, timePeriod: len)` | TA-Lib uses **one** period for both DI and ADX smoothing. `ta.dmi(14, 14)` is the comparable call. |
| `ta.mom(src, len)` / `ta.change(src, len)` | `TAMath.Mom(0, last, src, timePeriod: len)` | `ta.change(src)` with no length is `TAMath.Mom(..., timePeriod: 1)`. |
| `ta.roc(src, len)` | `TAMath.Roc(0, last, src, timePeriod: len)` | Percent change. `TAMath.RocP`, `TAMath.RocR`, `TAMath.RocR100` are the other three TA-Lib conventions. |
| `ta.cmo(src, len)` | `TAMath.Cmo(0, last, src, timePeriod: len)` | |
| `ta.wpr(len)` | `TAMath.WillR(0, last, high, low, close, timePeriod: len)` | Williams %R. |
| `ta.tsi(src, short, long)` | *no equivalent* | Compose from nested `TAMath.Ema`. |
| *(no Pine builtin)* | `TAMath.Apo`, `TAMath.Ppo`, `TAMath.UltOsc`, `TAMath.Bop`, `TAMath.Aroon`, `TAMath.AroonOsc`, `TAMath.Adxr`, `TAMath.Trix`, `TAMath.MacdExt`, `TAMath.MacdFix` | |

### Volatility and volume

| Pine Script | TaLibStandard | Notes |
| --- | --- | --- |
| `ta.atr(len)` | `TAMath.Atr(0, last, high, low, close, timePeriod: len)` | **Do not reconcile this one.** `TAMath.Atr` diverges to `+∞`; see [§0](#0-known-library-defects). Compose from `TAMath.TrueRange` instead. |
| `ta.tr(handle_na)` | `TAMath.TrueRange(0, last, high, low, close)` | `TrueRange` has lookback 1 (`BegIdx == 1`), so there is no bar-0 value. `ta.tr(true)` substitutes `high - low` on bar 0; `ta.tr(false)` returns `na`. TaLibStandard behaves like `ta.tr(false)`. |
| *(no Pine builtin)* | `TAMath.Natr(0, last, high, low, close, timePeriod: len)` | ATR normalised as a percentage of close. |
| `ta.obv` | `TAMath.Obv(0, last, close, volume)` | `ObvLookback()` is `0`, so `BegIdx == startIdx`. Absolute level is arbitrary in both (only the slope matters). |
| `ta.accdist` | `TAMath.Ad(0, last, high, low, close, volume)` | Chaikin Accumulation/Distribution line. |
| *(no Pine builtin)* | `TAMath.AdOsc(0, last, high, low, close, volume, fastPeriod: 3, slowPeriod: 10)` | Chaikin A/D Oscillator. |
| `ta.pvt`, `ta.nvi`, `ta.pvi`, `ta.wad` | *no equivalent* | |

### Statistics and array helpers

| Pine Script | TaLibStandard | Notes |
| --- | --- | --- |
| `ta.stdev(src, len)` | `TAMath.StdDev(0, last, src, timePeriod: len, nbDev: 1.0)` | Both are **population** (biased) standard deviation, matching Pine's `biased = true` default. |
| `ta.variance(src, len)` | `TAMath.Variance(0, last, src, timePeriod: len, nbDev: 1.0)` | Same. |
| `ta.correlation(a, b, len)` | `TAMath.Correl(0, last, a, b, timePeriod: len)` | |
| `ta.linreg(src, len, offset)` | `TAMath.LinearReg(0, last, src, timePeriod: len)` | Only `offset = 0`. `TAMath.LinearRegSlope`, `LinearRegAngle`, `LinearRegIntercept` expose the components; `TAMath.Tsf` is the one-bar-ahead forecast. |
| `ta.highest(src, len)` / `ta.lowest(src, len)` | `TAMath.Max(0, last, src, timePeriod: len)` / `TAMath.Min(0, last, src, timePeriod: len)` | |
| `ta.highestbars(...)` / `ta.lowestbars(...)` | `TAMath.MaxIndex(...)` / `TAMath.MinIndex(...)` | These return **absolute input indices** in `Integers`; Pine returns a negative bar offset. Convert with `Integers[k] - (BegIdx + k)`. |
| `ta.sum(src, len)` | `TAMath.Sum(0, last, src, timePeriod: len)` | Rolling sum. `ta.cum` (running total from bar 0) has no equivalent. |
| `ta.percentrank`, `ta.percentile_*`, `ta.median`, `ta.mode`, `ta.dev`, `ta.range` | *no equivalent* | |
| `ta.crossover(a, b)` / `ta.crossunder(a, b)` | *no equivalent* | Two-line C#; see the snippet below. |
| `ta.barssince`, `ta.valuewhen`, `ta.pivothigh`, `ta.pivotlow` | *no equivalent* | State machines, not indicators. |

```csharp
// ta.crossover / ta.crossunder over two aligned (NaN-padded) series.
static bool CrossedOver(double[] a, double[] b, int i)
    => i > 0 && !double.IsNaN(a[i - 1]) && !double.IsNaN(b[i - 1])
       && a[i - 1] <= b[i - 1] && a[i] > b[i];

static bool CrossedUnder(double[] a, double[] b, int i)
    => i > 0 && !double.IsNaN(a[i - 1]) && !double.IsNaN(b[i - 1])
       && a[i - 1] >= b[i - 1] && a[i] < b[i];
```

### Math transforms and operators

Pine exposes these as `math.*` (`math.abs`, `math.log`, `math.sqrt`, …) operating on a single value
per bar. TaLibStandard's equivalents operate on the whole array in one call: `TAMath.Acos`, `Asin`,
`Atan`, `Ceil`, `Cos`, `Cosh`, `Exp`, `Floor`, `Ln`, `Log10`, `Sin`, `Sinh`, `Sqrt`, `Tan`, `Tanh`,
plus the element-wise operators `Add`, `Sub`, `Mult`, `Div`.

Those have lookback 0, so `BegIdx == startIdx` and `NBElement == endIdx - startIdx + 1`. The rolling
operators `Max`, `Min`, `MinMax`, `MaxIndex`, `MinIndex`, `MinMaxIndex` and `Sum` take a
`timePeriod` and therefore have lookback `timePeriod - 1` like any other windowed indicator.

### Candlestick patterns

Pine has no built-in candlestick-pattern functions (TradingView ships them as a closed built-in
script). TaLibStandard exposes all 61 TA-Lib patterns through `TACandle`, generic over
`IFloatingPoint<T>`:

```csharp
CandleIndicatorResult engulfing = TACandle.CdlEngulfing(0, last, open, high, low, close);
// Integers[k] is bar (BegIdx + k): 0 = none, +100 = bullish, -100 = bearish
```

See the [Pattern Recognition section of the indicator reference](../indicators/README.md#pattern-recognition).

---

## 2. Parity caveats

**Do not expect bit-for-bit equality with a TradingView chart.** Some differences are algorithmic,
some are data-provenance, and some are a property of how TradingView evaluates scripts in realtime.
Know which is which before you spend a day chasing a 0.3% discrepancy.

### 2.1 Wilder smoothing (`ta.rma`)

Pine's `ta.rma(src, len)` is the recurrence `rma = (src + (len - 1) * rma[1]) / len`, seeded with
`ta.sma(src, len)`. TaLibStandard's RSI implementation
(`src/TechnicalAnalysis.Functions/Rsi/TAFunc.cs`) uses exactly that recurrence
(`prev *= len - 1; prev += delta; prev /= len`) with exactly that seed — the simple average of the
first `len` gains and losses. The same smoothing is *intended* to drive `Atr`, `Adx`, `Dx`, `Cmo`,
`Natr`, `PlusDM` and `MinusDM`.

So `ta.rsi` and `TAMath.Rsi` agree structurally; what is left between them is history dependence
(§2.3) and the data itself (§2.5–2.8). `TAMath.Adx` and `TAMath.Natr` were checked and are fine too.

**`ta.atr` and `TAMath.Atr` do not agree, and cannot be reconciled at any tolerance.** `TAFunc.Atr`'s
main output loop divides the *emitted* value by `len` but never the accumulator, so the running
average is multiplied by `len - 1` on every bar. Measured in this repository on a series whose true
range is exactly `2.0` every bar:

```text
TAMath.Atr(0, 29, high, low, close, timePeriod: 14)
  BegIdx=14  NBElement=16
  Real[0..7] = 2, 2, 26.142857, 340, 4420.142857, 57462, 747006.142857, 9711080
```

Each value after the second is exactly 13× (`len - 1`) the previous one. See
[§0](#0-known-library-defects).

Measured, for the reference series
`44.34, 44.09, 44.15, 43.61, 44.33, 44.83, 45.10, 45.42, 45.84, 46.08, 45.89, 46.03, 45.61, 46.28, 46.28, 46.00, …`:

```text
TAMath.Rsi(0, 29, px, timePeriod: 14)
  BegIdx=14  NBElement=16
  Real[0..4] = 70.4641, 66.2496, 66.4809, 69.3469, 66.2947
```

`Real[0]` is bar 14, i.e. the fifteenth close. Pine's `ta.rsi(close, 14)` on the same 30 closes
produces its first non-`na` value on the same bar.

If you need `ta.rma` standalone, it is a dozen lines:

```csharp
static double[] Rma(double[] src, int length)
{
    double[] result = new double[src.Length];
    Array.Fill(result, double.NaN);

    double seed = 0.0;
    for (int i = 0; i < length; i++)
    {
        seed += src[i];
    }

    result[length - 1] = seed / length;
    for (int i = length; i < src.Length; i++)
    {
        result[i] = ((result[i - 1] * (length - 1)) + src[i]) / length;
    }

    return result;
}
```

### 2.2 Seeding and warm-up

Two distinct issues:

**Seeding.** There are two separate things going on here, and only one of them is a convention.

*The convention.* Upstream TA-Lib seeds `prevMA` with the simple average of the first `timePeriod`
inputs. Pine documents `ta.ema` with a reference implementation that seeds from the first source
value. **A seeding difference produces a transient that is multiplied by `1 - 2/(len + 1)` on every
bar and never reaches exactly zero.** For `len = 26` that factor is `0.926` — a 7.4% reduction per
bar — so after 100 bars the residual is ~0.05% of the initial gap and after 300 bars it is
numerically invisible.

*The defect.* TaLibStandard does not implement the upstream seed. `TA_INT_EMA`
(`src/TechnicalAnalysis.Functions/TAFunc.cs`) accumulates only `timePeriod - 1` inputs and then
divides by `timePeriod`, and the loop that follows applies one extra smoothing step. The seed is
therefore *(sum of the first `timePeriod - 1` inputs) / `timePeriod`*, smoothed once with the
`timePeriod`-th input — not the simple average the C library uses. Measured here:

```text
TAMath.Ema(0, 7, [100, 102, 101, 105, 107, 106, 110, 111], timePeriod: 3)
  BegIdx=2  Real[0] = 84.166667      (upstream TA-Lib: 101, the SMA of the first three closes)

TAMath.Ema(0, 9, [10, 10, 10, 10, 10, 10, 10, 10, 10, 10], timePeriod: 5)
  Real[0] = 8.666667, Real[1] = 9.111111       (both should be exactly 10)
```

A linear ramp such as `[10, 20, 30, …]` happens to return the right answer by coincidence, which is
why this survives a casual check. So **the gap against Pine is larger than a seeding convention
would explain**, and the residual it leaves behind decays at the same rate but from a bigger start.
The affected entry points are `Ema`, `Macd`, `MacdExt`, `MacdFix`, `Dema`, `Tema`, `T3`, `Apo`,
`Ppo` and `Trix` — see [§0](#0-known-library-defects).

**Warm-up representation.** Pine emits `na` for bars it cannot compute and keeps the series
bar-aligned. TaLibStandard emits a *shorter* array and tells you where it starts via `BegIdx`. When
you diff a TaLibStandard series against a TradingView CSV export, align on **timestamps**, never on
array position.

**Mitigation.** Raise the unstable period so the transient is discarded rather than plotted:

```csharp
using TechnicalAnalysis;
using TechnicalAnalysis.Common;

TACore.Globals.UnstablePeriod[FuncUnstId.Ema] = 200;
TACore.Globals.UnstablePeriod[FuncUnstId.Rsi] = 200;
TACore.Globals.UnstablePeriod[FuncUnstId.Adx] = 200;
TACore.Globals.UnstablePeriod[FuncUnstId.Atr] = 200;
```

This costs you 200 bars of output but makes results independent of where your history starts. Set it
once at start-up; it is process-wide mutable state.

### 2.3 Recursive indicators depend on how far back your history goes

TradingView computes a chart's indicators over *all* the history the data provider has for that
symbol and resolution. If your database starts in 2020 and the chart starts in 2012, your RSI(14),
ATR(14), ADX(14), EMA(200) and every Hilbert Transform output will differ from the chart's — forever,
by an amount that shrinks the further you get from your start date but is never zero.

This is not a bug in either implementation. It is the definition of an infinite-impulse-response
filter. Fetch more history, or raise the unstable period, or accept the difference.

### 2.4 Realtime bars and repainting

On the realtime (rightmost, still-forming) bar, TradingView re-evaluates the script on every tick.
An indicator value you read at 10:31:07 is not the value the same bar will have at close.

- A signal computed on an unconfirmed bar can appear and disappear. That is *repainting*.
- Pine scripts guard with `barstate.isconfirmed`; a strategy alert configured
  "Once Per Bar Close" is the equivalent at the alert level.
- TaLibStandard has no notion of bar state. **You** decide what goes into the array. If you append
  the forming bar's current close, every recursive indicator's tail repaints on the next tick.

The safe pattern is: compute on closed bars only, and treat the forming bar separately.

```csharp
// bars[^1] is still forming; exclude it from the signal calculation.
int lastClosed = bars.Count - 2;
RsiResult rsi = TAMath.Rsi(0, lastClosed, closes, timePeriod: 14);
```

Two further asymmetries worth knowing: TradingView's historical bars are evaluated once per bar
(intrabar order of events inside a historical bar is unknown to the script), whereas realtime bars
are evaluated many times. Strategies that behave differently on historical vs realtime data are
usually falling into this gap, not into a TaLibStandard bug.

### 2.5 Session, timezone and bar-boundary alignment

A "daily bar" is not a universal concept.

- TradingView aggregates by the **exchange's** session and timezone. Your database probably
  aggregates by UTC midnight.
- Regular-hours vs extended-hours: TradingView's `Extended hours` toggle changes which trades form
  the bar. Two different OHLC series, two different indicator series.
- Intraday bars align to the session open, not to the hour. A 4-hour chart of a market that opens at
  09:30 has bars at 09:30/13:30/…, not 08:00/12:00/….
- Holiday calendars and half-days shift bar counts, which shifts every `length`-based window.

Before comparing numbers, confirm both sides produce **identical OHLCV** for the overlapping range.
If the inputs differ, the indicators must differ, and nothing about the indicator code is at fault.

### 2.6 Dividend and split adjustment

TradingView's `Adjust data for dividends` setting (and its split adjustment, which is always on for
most feeds) rewrites historical prices. A back-adjusted series and a raw series have different
returns, therefore different RSI, different ATR, different everything.

Decide explicitly which convention you want, apply it on both sides, and record the choice. Also
note that back-adjustment is *retroactive*: a series recomputed after a corporate action is not the
series you computed yesterday.

### 2.7 VWAP has no TA-Lib equivalent

There is no `TAMath.Vwap`. TA-Lib never had one, and TaLibStandard is a faithful port.

More importantly, VWAP is **anchored**, not rolling: Pine's `ta.vwap` resets at the start of each
session (or at a user-chosen anchor). A rolling `Sum(price * volume) / Sum(volume)` is a different
indicator with a similar name. If you need Pine-compatible VWAP, implement the session reset
yourself:

```csharp
static double[] SessionVwap(DateTime[] barTimes, double[] typicalPrice, double[] volume, TimeZoneInfo exchangeTz)
{
    ArgumentNullException.ThrowIfNull(exchangeTz);

    double[] vwap = new double[typicalPrice.Length];
    double cumulativePv = 0.0;
    double cumulativeVolume = 0.0;
    DateOnly currentSession = default;

    for (int i = 0; i < typicalPrice.Length; i++)
    {
        DateTime local = TimeZoneInfo.ConvertTimeFromUtc(barTimes[i], exchangeTz);
        DateOnly session = DateOnly.FromDateTime(local);
        if (session != currentSession)
        {
            currentSession = session;
            cumulativePv = 0.0;
            cumulativeVolume = 0.0;
        }

        cumulativePv += typicalPrice[i] * volume[i];
        cumulativeVolume += volume[i];
        vwap[i] = cumulativeVolume > 0.0 ? cumulativePv / cumulativeVolume : double.NaN;
    }

    return vwap;
}
```

Feed it `TAMath.TypPrice(0, last, high, low, close).Real` for the `(H+L+C)/3` convention that
TradingView uses by default.

### 2.8 Parameter-shape mismatches

Collected from §1, because these produce *large* differences that look like bugs:

| Symptom | Cause |
| --- | --- |
| Stochastic is far noisier than the chart | `ta.stoch` is raw %K. Use `StochF.FastK`, or `TAMath.Stoch` for the smoothed version. |
| Bollinger bands look inverted | Pine's `ta.bb` tuple is `[middle, upper, lower]`. |
| CCI / MFI drift from the chart | Pine takes an arbitrary `src`; TA-Lib hard-codes typical price. Compare against `ta.cci(hlc3, len)`. |
| ADX differs | Pine's `ta.dmi` has separate `diLength` and `adxSmoothing`; TA-Lib uses one period for both. |
| Parabolic SAR differs | Pine has `start`, `increment` **and** `maximum`; `TAMath.Sar` has `acceleration` (= start = increment) and `maximum`. Use `TAMath.SarExt` for independent control. |
| `highestbars` sign is wrong | `MaxIndex` returns an absolute index, Pine a negative offset. |
| True range has no bar-0 value | `TAMath.TrueRange` behaves like `ta.tr(false)`. |

### 2.9 A parity checklist

1. Export the chart's data and indicator via TradingView's *Export chart data…* (CSV).
2. Load the CSV's OHLCV into your test and assert it matches your own bars **exactly** on the
   overlapping timestamps. Fix the data before looking at the indicator.
3. Compute the indicator with TaLibStandard over the **same** bar array.
4. Join on timestamp, not on index — remember `BegIdx`.
5. Compare with a tolerance that reflects the mechanism: `1e-9` relative for `Sma`/`Wma`/`StdDev`
   (non-recursive), `1e-4` relative for `Rsi`/`Adx`/`Natr` after a few hundred bars, and looser near
   the start of the series.
6. If a recursive indicator is off by more than that, extend history or raise its unstable period
   before suspecting the port.
7. **Skip `Atr` and the EMA family entirely.** No tolerance reconciles them today; see
   [§0](#0-known-library-defects). Reconciling anything else first is the fastest way to find out
   whether your data is the problem.

---

## 3. Serving TaLibStandard series to a chart

### 3.1 Licensing, up front

| Product | Licence | What it costs you |
| --- | --- | --- |
| **Lightweight Charts** | Apache-2.0, public npm package | Free for commercial use. Attribution notice required. No TradingView agreement. |
| **Advanced Charts / Charting Library** | Proprietary; free of charge but requires signing TradingView's licence agreement and being granted repository access | You must apply to TradingView. Do **not** vendor it into a public repo. |
| **UDF protocol itself** | A documented HTTP contract | Nothing. You can implement and publish a UDF server freely; it is only *useful* to a Charting Library client. |

The sections below implement the UDF contract (useful if you have a Charting Library licence) and
show the Lightweight Charts path (useful to everyone).

### 3.2 The UDF REST contract

The Charting Library's UDF adapter calls a small set of endpoints. The three that matter:

#### `GET /config`

Advertises capabilities. Returned once at start-up.

```json
{
  "supported_resolutions": ["1", "5", "15", "60", "D"],
  "supports_group_request": false,
  "supports_marks": false,
  "supports_search": true,
  "supports_timescale_marks": false,
  "supports_time": true
}
```

#### `GET /symbols?symbol=<ticker>`

Resolves one symbol.

```json
{
  "name": "SYNTH",
  "ticker": "SYNTH",
  "description": "SYNTH (synthetic)",
  "type": "crypto",
  "session": "24x7",
  "timezone": "Etc/UTC",
  "exchange": "TALIB",
  "listed_exchange": "TALIB",
  "minmov": 1,
  "pricescale": 100,
  "has_intraday": true,
  "supported_resolutions": ["1", "5", "15", "60", "D"],
  "volume_precision": 0,
  "data_status": "streaming"
}
```

`session` and `timezone` are the fields that decide bar-boundary alignment on the chart — get them
wrong and every parity comparison from §2.5 fails.

#### `GET /history?symbol=&resolution=&from=&to=`

Column-oriented OHLCV. `from`/`to` are **UNIX seconds**, and `t` is a UNIX-seconds array.

```json
{
  "s": "ok",
  "t": [1704153600, 1704240000, 1704326400],
  "o": [100.0, 102.0, 101.0],
  "h": [101.5, 103.0, 102.2],
  "l": [ 99.2, 101.1, 100.4],
  "c": [102.0, 101.0, 105.0],
  "v": [1200, 900, 1500]
}
```

When the requested window is empty, the shape changes — this is not an error:

```json
{ "s": "no_data", "nextTime": 1704412800 }
```

`nextTime` is the timestamp of the closest bar **after** `to`, so the client can jump instead of
paging blindly. On a genuine failure return `{ "s": "error", "errmsg": "..." }`.

#### Minimal API implementation

```csharp
using System.Text.Json.Serialization;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IBarStore, InMemoryBarStore>();
WebApplication app = builder.Build();

app.MapGet("/udf/config", () => Results.Json(new UdfConfig(
    Supported_Resolutions: ["1", "5", "15", "60", "D"],
    Supports_Group_Request: false,
    Supports_Marks: false,
    Supports_Search: true,
    Supports_Timescale_Marks: false,
    Supports_Time: true)));

app.MapGet("/udf/symbols", (string symbol) => Results.Json(new UdfSymbolInfo(
    Name: symbol,
    Ticker: symbol,
    Description: $"{symbol} (synthetic)",
    Type: "crypto",
    Session: "24x7",
    Timezone: "Etc/UTC",
    Exchange: "TALIB",
    Listed_Exchange: "TALIB",
    Minmov: 1,
    Pricescale: 100,
    Has_Intraday: true,
    Supported_Resolutions: ["1", "5", "15", "60", "D"],
    Volume_Precision: 0,
    Data_Status: "streaming")));

app.MapGet("/udf/history", (string symbol, string resolution, long from, long to, IBarStore store) =>
{
    IReadOnlyList<Bar> bars = store.GetBars(symbol, resolution, from, to);
    if (bars.Count == 0)
    {
        return Results.Json(new UdfHistoryNoData("no_data", store.NextBarTime(symbol, resolution, to)));
    }

    return Results.Json(new UdfHistory(
        S: "ok",
        T: bars.Select(b => b.Time).ToArray(),
        O: bars.Select(b => b.Open).ToArray(),
        H: bars.Select(b => b.High).ToArray(),
        L: bars.Select(b => b.Low).ToArray(),
        C: bars.Select(b => b.Close).ToArray(),
        V: bars.Select(b => b.Volume).ToArray()));
});

app.Run();

internal sealed record Bar(long Time, double Open, double High, double Low, double Close, double Volume);

internal sealed record UdfConfig(
    [property: JsonPropertyName("supported_resolutions")] string[] Supported_Resolutions,
    [property: JsonPropertyName("supports_group_request")] bool Supports_Group_Request,
    [property: JsonPropertyName("supports_marks")] bool Supports_Marks,
    [property: JsonPropertyName("supports_search")] bool Supports_Search,
    [property: JsonPropertyName("supports_timescale_marks")] bool Supports_Timescale_Marks,
    [property: JsonPropertyName("supports_time")] bool Supports_Time);

internal sealed record UdfSymbolInfo(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("ticker")] string Ticker,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("session")] string Session,
    [property: JsonPropertyName("timezone")] string Timezone,
    [property: JsonPropertyName("exchange")] string Exchange,
    [property: JsonPropertyName("listed_exchange")] string Listed_Exchange,
    [property: JsonPropertyName("minmov")] int Minmov,
    [property: JsonPropertyName("pricescale")] int Pricescale,
    [property: JsonPropertyName("has_intraday")] bool Has_Intraday,
    [property: JsonPropertyName("supported_resolutions")] string[] Supported_Resolutions,
    [property: JsonPropertyName("volume_precision")] int Volume_Precision,
    [property: JsonPropertyName("data_status")] string Data_Status);

internal sealed record UdfHistory(
    [property: JsonPropertyName("s")] string S,
    [property: JsonPropertyName("t")] long[] T,
    [property: JsonPropertyName("o")] double[] O,
    [property: JsonPropertyName("h")] double[] H,
    [property: JsonPropertyName("l")] double[] L,
    [property: JsonPropertyName("c")] double[] C,
    [property: JsonPropertyName("v")] double[] V);

internal sealed record UdfHistoryNoData(
    [property: JsonPropertyName("s")] string S,
    [property: JsonPropertyName("nextTime")] long? NextTime);

internal interface IBarStore
{
    IReadOnlyList<Bar> GetBars(string symbol, string resolution, long from, long to);

    long? NextBarTime(string symbol, string resolution, long to);
}
```

The UDF contract has no slot for custom indicator series — the Charting Library expects indicators
to be computed client-side by its own study engine. To plot a **TaLibStandard-computed** series you
either register a custom study that fetches from your own endpoint, or (far simpler) use
Lightweight Charts.

### 3.3 Serving an indicator series

This is where `BegIdx` earns its keep. One endpoint, one loop, no off-by-one:

```csharp
app.MapGet("/indicators/rsi", (string symbol, string resolution, int period, IBarStore store) =>
{
    IReadOnlyList<Bar> bars = store.GetBars(symbol, resolution, long.MinValue, long.MaxValue);
    double[] close = bars.Select(b => b.Close).ToArray();

    RsiResult rsi = TAMath.Rsi(0, close.Length - 1, close, period);
    if (rsi.RetCode != RetCode.Success)
    {
        return Results.Problem($"RSI failed: {rsi.RetCode}", statusCode: StatusCodes.Status422UnprocessableEntity);
    }

    // Output element k belongs to input bar rsi.BegIdx + k.
    LinePoint[] points = new LinePoint[rsi.NBElement];
    for (int k = 0; k < rsi.NBElement; k++)
    {
        Bar bar = bars[rsi.BegIdx + k];
        points[k] = new LinePoint(bar.Time, rsi.Real[k]);
    }

    return Results.Json(points);
});

internal sealed record LinePoint(
    [property: JsonPropertyName("time")] long Time,
    [property: JsonPropertyName("value")] double Value);
```

Note what this does **not** do: it does not emit points for the warm-up bars. Lightweight Charts
draws a line series from a sparse, ascending-by-time array, so simply omitting them is correct and
cheaper than sending `null`s. The warm-up region is `[0, BegIdx)` — never send `0.0` there.

### 3.4 Lightweight Charts

Apache-2.0, no licence agreement, and small enough to ship in a dashboard. It renders candles and
line series from plain JSON, which is exactly what §3.3 produces.

The snippet below uses the v5 series API (`chart.addSeries(CandlestickSeries)`) and assumes a
bundler resolves the bare `lightweight-charts` specifier. On v4 the calls are
`chart.addCandlestickSeries()` and `chart.addLineSeries()`; without a bundler, load the standalone
build and use the `LightweightCharts` global instead.

```html
<div id="chart" style="height: 480px"></div>
<script type="module">
  import { createChart, CandlestickSeries, LineSeries } from 'lightweight-charts';

  const chart = createChart(document.getElementById('chart'), { height: 480 });
  const candles = chart.addSeries(CandlestickSeries);
  const rsi = chart.addSeries(LineSeries, { priceScaleId: 'rsi' });

  const bars = await (await fetch('/udf/history?symbol=SYNTH&resolution=60&from=0&to=9999999999')).json();
  candles.setData(bars.t.map((t, i) => ({
    time: t, open: bars.o[i], high: bars.h[i], low: bars.l[i], close: bars.c[i],
  })));

  // { time, value } pairs straight from /indicators/rsi - already BegIdx-aligned server-side.
  rsi.setData(await (await fetch('/indicators/rsi?symbol=SYNTH&resolution=60&period=14')).json());
</script>
```

`time` is UNIX seconds for intraday series and `"YYYY-MM-DD"` for daily series — the same convention
as the UDF `t` array, which is why the two endpoints compose without a translation layer.

For streaming updates, push new bars over SignalR and call `series.update(bar)` — see the
[real-time sample](../../samples/TechnicalAnalysis.Samples.RealTime).

---

## 4. Consuming TradingView webhook alerts

TradingView alerts can POST a body to a URL. That is the standard way to let a TradingView-authored
signal trigger a .NET strategy.

### 4.1 The alert payload

The alert message is a free-text field; make it JSON and template it with Pine placeholders:

```json
{
  "id": "{{timenow}}-{{ticker}}-{{interval}}",
  "secret": "REPLACE_WITH_YOUR_SHARED_SECRET",
  "ticker": "{{ticker}}",
  "interval": "{{interval}}",
  "action": "{{strategy.order.action}}",
  "price": {{close}},
  "time": "{{timenow}}"
}
```

TradingView substitutes the `{{…}}` placeholders and POSTs the result with
`Content-Type: text/plain` (not `application/json`), so read the raw body rather than relying on
model binding.

### 4.2 The endpoint

```csharp
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

app.MapPost("/webhooks/tradingview", async (
    HttpRequest request,
    IReplayGuard replayGuard,
    IConfiguration configuration,
    CancellationToken cancellationToken) =>
{
    string expectedSecret = configuration["TradingView:WebhookSecret"]
                            ?? throw new InvalidOperationException("TradingView:WebhookSecret is not configured.");

    using StreamReader reader = new(request.Body, Encoding.UTF8);
    string body = await reader.ReadToEndAsync(cancellationToken);

    TradingViewAlert? alert = JsonSerializer.Deserialize<TradingViewAlert>(body);
    if (alert is null)
    {
        return Results.BadRequest();
    }

    // 1. Shared secret, compared in constant time.
    if (!CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(alert.Secret),
            Encoding.UTF8.GetBytes(expectedSecret)))
    {
        return Results.Unauthorized();
    }

    // 2. Freshness: reject anything older than the alert's useful life.
    if (DateTimeOffset.UtcNow - alert.Time > TimeSpan.FromMinutes(2))
    {
        return Results.StatusCode(StatusCodes.Status408RequestTimeout);
    }

    // 3. Replay protection: each alert id may be consumed exactly once.
    if (!replayGuard.TryConsume(alert.Id))
    {
        return Results.Conflict();
    }

    // 4. Hand off to the strategy. Return fast; do the work in the background.
    return Results.Accepted();
});

internal sealed record TradingViewAlert(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("secret")] string Secret,
    [property: JsonPropertyName("ticker")] string Ticker,
    [property: JsonPropertyName("interval")] string Interval,
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("price")] decimal Price,
    [property: JsonPropertyName("time")] DateTimeOffset Time);

internal interface IReplayGuard
{
    bool TryConsume(string alertId);
}
```

### 4.3 Security notes

TradingView webhooks are **unauthenticated HTTP POSTs to a public URL**. Treat the endpoint as
hostile-facing.

- **HTTPS only.** TradingView will not call plain HTTP endpoints, and the shared secret travels in
  the body.
- **Shared secret in the body, compared in constant time.** There is no signature header and no HMAC
  from TradingView, so a secret in the payload is what you have. Compare with
  `CryptographicOperations.FixedTimeEquals`, never with `==` or `string.Equals`.
- **Never log the raw body.** It contains the secret.
- **Unguessable path.** `/webhooks/tradingview/8f3c…` costs nothing and removes you from
  opportunistic scanning.
- **IP allowlist.** TradingView publishes the egress IPs its alert servers use. Put them in
  configuration — they change, and a hard-coded list becomes an outage:

  ```csharp
  string[] allowed = configuration.GetSection("TradingView:AllowedIPs").Get<string[]>() ?? [];
  IPAddress? remote = request.HttpContext.Connection.RemoteIpAddress;
  if (allowed.Length > 0 && (remote is null || !allowed.Contains(remote.ToString())))
  {
      return Results.Forbid();
  }
  ```

  Behind a reverse proxy or CDN you must configure `ForwardedHeadersOptions` (and its
  `KnownProxies`/`KnownNetworks`) first, or `RemoteIpAddress` will be your proxy. Check TradingView's
  current published list before deploying; do not copy an IP list out of a blog post.
- **Replay protection.** Alerts are retried and can be duplicated. Give each alert a unique `id`
  (the `{{timenow}}-{{ticker}}-{{interval}}` template above works) and consume it exactly once —
  a `MemoryCache` with the freshness window as TTL is sufficient for a single instance; use Redis
  with `SET key value NX EX 120` for a cluster.
- **Timestamp freshness.** Reject anything older than a couple of minutes so a captured request
  cannot be replayed later, even against a fresh replay-guard store.
- **Rate limit.** Use ASP.NET Core's built-in rate limiting on this endpoint; a fixed window of a
  few requests per second per IP is generous for alerts and stops floods.
- **Return fast, act asynchronously.** TradingView times out quickly and retries. Enqueue the order
  intent and return `202 Accepted`; do not place the order inside the request.
- **Never trust the payload's prices for execution.** `{{close}}` is TradingView's view of the
  market, possibly from a different feed than your broker's. Re-validate against your own data
  before sending an order — and recompute the confirming indicator with TaLibStandard on your own
  bars.

---

## 5. Samples

Two runnable samples in this repository put the pieces together. Both use deterministic, seeded
synthetic data and run fully offline:

- [`samples/TechnicalAnalysis.Samples.RealTime`](../../samples/TechnicalAnalysis.Samples.RealTime) —
  streaming bar ingestion, incremental recomputation, and pushing series to a browser chart.
- [`samples/TechnicalAnalysis.Samples.Backtesting`](../../samples/TechnicalAnalysis.Samples.Backtesting) —
  bar-by-bar strategy evaluation with correct `BegIdx` alignment and no look-ahead.

---

## See also

- [Getting started](getting-started.md) — installation, `RetCode`/`BegIdx`/`NBElement`, pitfalls.
- [Complete indicator reference](../indicators/README.md) — all 159 entry points.
- [`Atypical.TechnicalAnalysis.Functions` API reference](../functions/Atypical.TechnicalAnalysis.Functions.md)
- [`Atypical.TechnicalAnalysis.Candles` API reference](../candles/Atypical.TechnicalAnalysis.Candles.md)
