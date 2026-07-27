# ✨ The fluent API

`TAMath` and `TAFunc` are faithful. They give you exactly what TA-Lib gives you: an output array filled
from index `0`, a `BegIdx` telling you which bar element `0` belongs to, and an `NBElement` telling you
how many elements are real. Everything after that is your arithmetic, and
[§3 of the getting started guide](getting-started.md#3-retcode-begidx-nbelement--the-part-that-actually-matters)
exists because that arithmetic is easy to get wrong in a way that never throws.

The fluent API is the same indicators with the arithmetic already done. You build a `PriceSeries`, you
call an indicator on it, and you get back an `IndicatorSeries` in which **every index is a bar index** and
a bar that has not warmed up yet is `null`. There is no second index space to confuse with the first,
because the type does not expose one.

```csharp
using TechnicalAnalysis.Functions;

PriceSeries prices = PriceSeries.FromClose(closes);
IndicatorSeries sma = prices.Sma(30);

Console.WriteLine(sma.Latest);
```

Real output, with `closes` set to `1, 2, 3, … 100`:

```text
85.5
```

> Every code block below was compiled and executed against the source in this repository. The numbers
> printed in the worked examples are real program output, not illustrations.

---

## 📝 Table of contents

<!-- TOC -->
* [✨ The fluent API](#-the-fluent-api)
  * [📝 Table of contents](#-table-of-contents)
  * [🧨 The problem it solves](#-the-problem-it-solves)
    * [Two index spaces](#two-index-spaces)
    * [The measured proof](#the-measured-proof)
    * [One type owns the conversion](#one-type-owns-the-conversion)
  * [🧱 `PriceSeries` — the input](#-priceseries--the-input)
    * [The four factories](#the-four-factories)
    * [Missing components are never fabricated](#missing-components-are-never-fabricated)
    * [Non-finite prices are refused at the boundary](#non-finite-prices-are-refused-at-the-boundary)
    * [There is no `startIdx` or `endIdx`](#there-is-no-startidx-or-endidx)
  * [📐 `IndicatorSeries` — the output](#-indicatorseries--the-output)
    * [The full surface](#the-full-surface)
    * [Warm-up: absence is `null`](#warm-up-absence-is-null)
    * [Reading a whole series](#reading-a-whole-series)
    * [Projections onto the bar axis](#projections-onto-the-bar-axis)
    * [Crossings](#crossings)
    * [`AsOf` — windowing without look-ahead](#asof--windowing-without-look-ahead)
  * [📊 The indicators](#-the-indicators)
    * [Overlap studies](#overlap-studies)
    * [Momentum](#momentum)
    * [Volatility](#volatility)
    * [Volume](#volume)
    * [Defaults are TA-Lib's, not the conventional ones](#defaults-are-ta-libs-not-the-conventional-ones)
    * [The measured warm-up ladder](#the-measured-warm-up-ladder)
  * [🚪 `Align` — the escape hatch to the other 89 indicators](#-align--the-escape-hatch-to-the-other-89-indicators)
  * [⚠️ Error handling](#-error-handling)
    * [What throws](#what-throws)
    * [What quietly produces nothing](#what-quietly-produces-nothing)
    * [`RetCode` is not warmth](#retcode-is-not-warmth)
  * [🙅 What the fluent API deliberately does not do](#-what-the-fluent-api-deliberately-does-not-do)
  * [🔁 When to prefer `TAMath`](#-when-to-prefer-tamath)
  * [🧩 Composing with the samples](#-composing-with-the-samples)
    * [Backtesting](#backtesting)
    * [Real-time streaming](#real-time-streaming)
  * [Related](#related)
<!-- TOC -->

---

## 🧨 The problem it solves

### Two index spaces

There are two, and they are not the same.

An **array index** is a subscript into the raw `double[]` a `TAMath` call returned. TA-Lib fills that
array from index `0` and writes exactly `NBElement` elements, so the last valid array index is
`NBElement - 1`.

A **bar index** is a position in your price series, with domain `[0, BarCount)`. `BegIdx` is a *bar*
index: output element `k` describes bar `BegIdx + k`, so the last valid bar index is
`BegIdx + NBElement - 1`.

```text
NBElement - 1            <- last valid ARRAY index
BegIdx + NBElement - 1   <- last valid BAR index
```

Those are two different numbers whenever `BegIdx > 0`, which is every indicator with a lookback, which is
almost all of them.

### The measured proof

Subscripting the output array with the *bar* index is the classic bug. Here it is, on a 30-period SMA over
closes `1, 2, 3, … 100`, where the correct answer is the mean of `71 … 100`, which is `85.5`:

```csharp
using TechnicalAnalysis.Functions;

double[] closes = [.. Enumerable.Range(1, 100).Select(i => (double)i)];
SmaResult sma = TAMath.Sma(0, closes.Length - 1, closes, timePeriod: 30);

Console.WriteLine($"BegIdx={sma.BegIdx} NBElement={sma.NBElement} Real.Length={sma.Real.Length}");
Console.WriteLine($"Real[NBElement - 1]          = {sma.Real[sma.NBElement - 1]}");
Console.WriteLine($"Real[BegIdx + NBElement - 1] = {sma.Real[sma.BegIdx + sma.NBElement - 1]}");
```

Real output:

```text
BegIdx=29 NBElement=71 Real.Length=100
Real[NBElement - 1]          = 85.5
Real[BegIdx + NBElement - 1] = 0
```

The wrong expression does not throw. `BegIdx + NBElement - 1` is `99`, the array holds `100` elements, and
element `99` is one of the untouched zeros past `NBElement`. It returns `0.0` — a number that looks like a
number. An RSI read that way is pinned at `0` and reports "oversold" on every bar of every input, forever,
with `RetCode.Success`.

The same question through the fluent API:

```csharp
using TechnicalAnalysis.Functions;

double[] closes = [.. Enumerable.Range(1, 100).Select(i => (double)i)];
IndicatorSeries sma = PriceSeries.FromClose(closes).Sma(30);

Console.WriteLine($"BarCount={sma.BarCount} WarmCount={sma.WarmCount} FirstBar={sma.FirstBar} LastBar={sma.LastBar}");
Console.WriteLine($"Latest  = {sma.Latest}");
Console.WriteLine($"sma[99] = {sma[99]}");
Console.WriteLine($"sma[29] = {sma[29]}");
Console.WriteLine($"sma[28] = {sma[28]}");
```

Real output:

```text
BarCount=100 WarmCount=71 FirstBar=29 LastBar=99
Latest  = 85.5
sma[99] = 85.5
sma[29] = 15.5
sma[28] =
```

`sma[28]` prints as empty because it is `null` — bar 28 is inside the series but before the indicator
warmed up. `sma[29]` is `15.5`, the mean of `1 … 30`, which you can check by hand.

### One type owns the conversion

The whole point is that the conversion between the two index spaces happens in exactly **one** private
expression, inside `IndicatorSeries`, covered by a regression suite — not once per property, not once per
call site. Every fluent indicator, every projection, every crossing and the escape hatch all route through
it.

That is why the surface has no member that takes or returns a raw output-array index, with one deliberate,
explicitly-named exception (`WarmValues`). The historic wrong expression is not merely discouraged; on a
`WarmValues` span it is out of range:

```csharp
double[] close = [100.0, 102.0, 101.0, 105.0, 107.0, 106.0, 110.0, 111.0];
IndicatorSeries sma = PriceSeries.FromClose(close).Sma(3);

ReadOnlySpan<double> warm = sma.WarmValues;
Console.WriteLine($"warm.Length={warm.Length} warm[0]={warm[0]} warm[^1]={warm[^1]}");
_ = warm[sma.FirstBar!.Value + sma.WarmCount - 1];   // throws
```

Real output:

```text
warm.Length=6 warm[0]=101 warm[^1]=109
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
```

The span is sliced to `WarmCount`, so the zero padding is unreachable. A loud failure replaces a silent
`0.0`.

---

## 🧱 `PriceSeries` — the input

`PriceSeries` is an immutable `readonly struct` in `TechnicalAnalysis.Functions`. Its factories **copy**,
so immutability is unconditional rather than a promise you have to keep, and both `PriceSeries` and every
`IndicatorSeries` derived from it are safe for unrestricted concurrent use.

### The four factories

All four take `ReadOnlySpan<double>`, so an oversized scratch buffer costs only its valid region:
`PriceSeries.FromHlc(high.AsSpan(0, n), low.AsSpan(0, n), close.AsSpan(0, n))`.

| Factory | Signature | Unlocks |
| --- | --- | --- |
| `FromClose` | `(ReadOnlySpan<double> close)` | `Sma`, `Ema`, `BollingerBands`, `Rsi`, `Macd` |
| `FromHlc` | `(high, low, close)` | …plus `Atr`, `Adx`, `Stoch` |
| `FromOhlc` | `(open, high, low, close)` | …plus the `Open` span |
| `FromOhlcv` | `(open, high, low, close, volume)` | …plus `Obv` |

`close` defines `BarCount`; every other component must have the same length or the factory throws
`ArgumentException`.

```csharp
using TechnicalAnalysis.Functions;

PriceSeries c     = PriceSeries.FromClose(close);
PriceSeries hlc   = PriceSeries.FromHlc(high, low, close);
PriceSeries ohlcv = PriceSeries.FromOhlcv(open, high, low, close, volume);

Console.WriteLine($"FromClose : BarCount={c.BarCount} HasOpen={c.HasOpen} HasHighLow={c.HasHighLow} HasVolume={c.HasVolume}");
Console.WriteLine($"FromHlc   : BarCount={hlc.BarCount} HasOpen={hlc.HasOpen} HasHighLow={hlc.HasHighLow} HasVolume={hlc.HasVolume}");
Console.WriteLine($"FromOhlcv : BarCount={ohlcv.BarCount} HasOpen={ohlcv.HasOpen} HasHighLow={ohlcv.HasHighLow} HasVolume={ohlcv.HasVolume}");
```

Real output on a 60-bar series:

```text
FromClose : BarCount=60 HasOpen=False HasHighLow=False HasVolume=False
FromHlc   : BarCount=60 HasOpen=False HasHighLow=True HasVolume=False
FromOhlcv : BarCount=60 HasOpen=True HasHighLow=True HasVolume=True
```

The rest of the surface is `BarCount`, `IsEmpty`, the three `Has*` flags, the five component spans
(`Open`, `High`, `Low`, `Close`, `Volume`, each `ReadOnlySpan<double>` of exactly `BarCount` elements),
`AsOf`, the two `Align` overloads, and `PriceSeries.Empty` — which is `default(PriceSeries)`, a zero-bar
series carrying no components at all.

### Missing components are never fabricated

A close-only series does not pretend that high and low equal the close. Asking anyway throws
`InvalidOperationException` and names the factory that would have supplied what is missing:

```csharp
PriceSeries closeOnly = PriceSeries.FromClose(close);
closeOnly.Atr(14);
```

Real output:

```text
System.InvalidOperationException: Atr needs the high and low of each bar, which this price series does
not carry. Build it with PriceSeries.FromHlc, FromOhlc or FromOhlcv; the closing price alone is never
substituted for a bar's range.
```

This matters more than it looks. Substituting the close for high and low would turn a true range into the
absolute change in close and an ATR into something that is *nearly* right — the worst possible failure
mode, because it charts plausibly.

### Non-finite prices are refused at the boundary

One `NaN` close — a gapped tick, a provider sentinel, a bad CSV parse — does not spoil only the bars it
touches. TA-Lib's simple moving average carries a running sum, and `NaN - finite` is `NaN` for ever after;
the EMA, ATR and RSI recursions behave the same way. So the factories refuse:

```csharp
PriceSeries.FromClose([100.0, 101.0, double.NaN, 103.0]);
```

Real output:

```text
System.ArgumentException: 'close' holds NaN at bar 2. A price series must be finite throughout: a single
non-finite bar propagates through every running sum and every recursion in TA-Lib and silently corrupts
the whole indicator. Clean or drop the bar before building the series. (Parameter 'close')
```

The exception names the component and the first offending bar. The factories already walk the data to copy
it, so the check is free.

### There is no `startIdx` or `endIdx`

There is nowhere on this surface to pass them. Indicators always analyse the whole series, which has three
consequences:

* `FirstBar` is always the indicator's true lookback, never an artefact of where you asked output to start.
* You cannot trigger the unguarded end-index buffer overrun a raw call permits — `TAMath.Sma(0, 100, eightBars, 3)`
  throws `IndexOutOfRangeException`, and there is no way to write that here.
* Windowing is [`AsOf`](#asof--windowing-without-look-ahead), which keeps bar indices absolute instead of
  rebasing them.

---

## 📐 `IndicatorSeries` — the output

### The full surface

`IndicatorSeries` is an immutable `readonly struct`. **Every `int` on it that names a position is a bar
index.**

| Member | Type | Meaning |
| --- | --- | --- |
| `this[int bar]` | `double?` | The value at that **bar**, or `null` if the bar has no value |
| `Latest` | `double?` | The value at `LastBar`, or `null` if no bar has one |
| `FirstBar` | `int?` | Bar index of the first value — TA-Lib's `BegIdx`, reinterpreted |
| `LastBar` | `int?` | Bar index of the last value, i.e. `FirstBar + WarmCount - 1` |
| `BarCount` | `int` | Bars in the source series. **This, not `WarmCount`, bounds a loop over the indexer** |
| `WarmCount` | `int` | How many bars carry a value — TA-Lib's `NBElement`. A count in array space |
| `HasValues` | `bool` | `WarmCount > 0`. The only warmth test |
| `RetCode` | `RetCode` | The raw status. Says nothing about whether there are values |
| `WarmValues` | `ReadOnlySpan<double>` | The one array-indexed view, sliced to `WarmCount` |
| `IsWarmAt(int bar)` | `bool` | Equivalent to `this[bar] is not null`, without the nullable |
| `AsOf(int bar)` | `IndicatorSeries` | The same series truncated to end at `bar` |
| `CrossedAbove(double level, int bar)` | `bool` | Crossed up through a fixed level at `bar` |
| `CrossedBelow(double level, int bar)` | `bool` | Crossed down through a fixed level at `bar` |
| `CrossedAbove(IndicatorSeries other, int bar)` | `bool` | Crossed up through another series at `bar` |
| `CrossedBelow(IndicatorSeries other, int bar)` | `bool` | Crossed down through another series at `bar` |
| `ToBarAlignedArray()` | `double[]` | `BarCount` elements, bar-indexed, `NaN` where there is no value |
| `ToBarAlignedNullableArray()` | `double?[]` | `BarCount` elements, bar-indexed, `null` where there is none |
| `WarmValuesToArray()` | `double[]` | `WarmCount` elements, array-indexed like `WarmValues` |
| `CopyBarAligned(Span<double>)` | `void` | Writes the bar-aligned projection into a buffer you own |
| `GetEnumerator()` | `Enumerator` | Allocation-free `foreach` over `(int Bar, double Value)` pairs |
| `IndicatorSeries.Empty(int barCount)` | `static` | A series of `barCount` bars in which nothing has a value |
| `IndicatorSeries.Create(…)` | `static` | The only public door for raw TA-Lib metadata; see [`Align`](#-align--the-escape-hatch-to-the-other-89-indicators) |

Two names are worth dwelling on. `WarmCount` is deliberately not called `Count`, because on a type with an
indexer `Count` reads as "the number of valid indices", and it is not: the indexer's domain is
`[0, BarCount)`. `for (int i = 0; i < s.WarmCount; i++) s[i]` would read the wrong bars and silently drop
the most recent ones. And `WarmValues` is not called `Values`, because it is the only array-indexed thing
on the type and its name has to say so.

### Warm-up: absence is `null`

A bar inside the series but before the indicator warmed up has no value, and that is reported as `null` —
never `0.0`, never `NaN`, never an exception.

```csharp
using TechnicalAnalysis.Functions;

double[] close = [100.0, 102.0, 101.0, 105.0, 107.0, 106.0, 110.0, 111.0];
IndicatorSeries sma = PriceSeries.FromClose(close).Sma(3);

Console.WriteLine($"BarCount={sma.BarCount} WarmCount={sma.WarmCount} FirstBar={sma.FirstBar} LastBar={sma.LastBar}");

for (int bar = 0; bar < sma.BarCount; bar++)
{
    Console.WriteLine($"bar {bar}: close={close[bar]} sma={(sma[bar] is { } v ? v.ToString("0.####") : "null")}");
}
```

Real output:

```text
BarCount=8 WarmCount=6 FirstBar=2 LastBar=7
bar 0: close=100 sma=null
bar 1: close=102 sma=null
bar 2: close=101 sma=101
bar 3: close=105 sma=102.6667
bar 4: close=107 sma=104.3333
bar 5: close=106 sma=106
bar 6: close=110 sma=107.6667
bar 7: close=111 sma=109
```

That is the same eight-bar series and the same numbers as
[§3.2 of the getting started guide](getting-started.md#32-a-fully-worked-example), where they were obtained
by projecting `Real[k]` onto bar `BegIdx + k` by hand.

The idiomatic read is a pattern match, which gets you a non-nullable `double` and skips the warm-up in one
step:

```csharp
if (sma[bar] is { } value && value > threshold)
{
    // ...
}
```

Asking about a bar **outside** `[0, BarCount)` is a different thing entirely and throws
`ArgumentOutOfRangeException`. "Bar 5 of a 30-period SMA" is a legitimate question whose answer is "no
value"; "bar 5000 of a 100-bar series" is not a question. Keeping those two apart is what makes `AsOf` a
guarantee rather than a convention.

### Reading a whole series

`foreach` yields only the bars that have a value, as `(Bar, Value)` pairs, and allocates nothing:

```csharp
foreach ((int bar, double value) in sma)
{
    Console.WriteLine($"bar {bar} -> {value:0.####}");
}
```

Real output:

```text
bar 2 -> 101
bar 3 -> 102.6667
bar 4 -> 104.3333
bar 5 -> 106
bar 6 -> 107.6667
bar 7 -> 109
```

`IEnumerable<T>` is deliberately not implemented — `foreach` binds to the enumerator pattern directly, and
implementing the interface would box the enumerator on every loop. Use `WarmValuesToArray()` or
`ToBarAlignedNullableArray()` when you need something LINQ can consume.

### Projections onto the bar axis

Three projections, for three different consumers:

```csharp
double[]  padded   = sma.ToBarAlignedArray();
double?[] nullable = sma.ToBarAlignedNullableArray();
double[]  warm     = sma.WarmValuesToArray();
```

Real output:

```text
ToBarAlignedArray()         : NaN, NaN, 101, 102.6667, 104.3333, 106, 107.6667, 109
ToBarAlignedNullableArray() : null, null, 101, 102.6667, 104.3333, 106, 107.6667, 109
WarmValuesToArray()         : 101, 102.6667, 104.3333, 106, 107.6667, 109
lengths: 8, 8, 6
```

`ToBarAlignedArray` pads with `NaN` and the padding is **not** configurable, because padding with `0.0`
reinstates exactly the corruption this whole type exists to prevent. It is the one place on the surface
where absence is a sentinel rather than `null`, so it cannot distinguish "no value here" from "a value
that is not finite"; `ToBarAlignedNullableArray` is the projection that keeps the promise. And because
every indicator has a warm-up, `ToBarAlignedArray().Average()` is `NaN` for a typical series — a chart fed
the raw array has to be told how to skip them.

`CopyBarAligned(Span<double>)` writes the same projection into a buffer you already own, which is what a
per-frame rendering loop wants:

```csharp
double[] buffer = new double[prices.BarCount];
prices.Sma(3).CopyBarAligned(buffer);
```

Real output:

```text
NaN, NaN, 101, 102.6667, 104.3333, 106, 107.6667, 109
```

It throws `ArgumentException` if the destination is shorter than `BarCount`; anything beyond `BarCount` is
left untouched.

### Crossings

A crossing is a **transition between two bars**, not a state. A series already above a level does not keep
reporting a crossing, and a crossing at bar `0` is always `false` because there is no previous bar. If any
of the values involved is missing, the answer is `false` — which is what makes a fast/slow pair with
different warm-ups work with no reasoning at the call site.

```csharp
using TechnicalAnalysis.Functions;

PriceSeries prices = PriceSeries.FromClose(close);
IndicatorSeries fast = prices.Sma(5);
IndicatorSeries slow = prices.Sma(20);

for (int bar = 0; bar < prices.BarCount; bar++)
{
    if (fast.CrossedAbove(slow, bar))
    {
        Console.WriteLine($"bar {bar}: golden cross  (fast={fast[bar]:0.####} slow={slow[bar]:0.####})");
    }
    else if (fast.CrossedBelow(slow, bar))
    {
        Console.WriteLine($"bar {bar}: death cross   (fast={fast[bar]:0.####} slow={slow[bar]:0.####})");
    }
}
```

Real output on the 60-bar demo series:

```text
bar 35: golden cross  (fast=102.7612 slow=102.0938)
bar 57: death cross   (fast=115.7357 slow=116.6491)
```

The fixed-level overloads read the same way. Note that they test a *transition*, so a persistently
overbought RSI fires once, not on every bar:

```csharp
IndicatorSeries rsi = prices.Rsi(14);

for (int bar = 0; bar < prices.BarCount; bar++)
{
    if (rsi.CrossedBelow(70.0, bar))
    {
        Console.WriteLine($"bar {bar}: RSI fell back through 70 ({rsi[bar]:0.####})");
    }
}
```

Real output:

```text
bar 18: RSI fell back through 70 (64.9599)
bar 54: RSI fell back through 70 (66.6238)
```

Crossing two series computed over price series of different lengths is a caller bug and throws
`ArgumentException`, because a bar index would not mean the same thing in both.

### `AsOf` — windowing without look-ahead

`AsOf(bar)` returns the same series truncated so that it ends at `bar`. Bar indices are **not** rebased:
they stay absolute positions in the original price series. Asking the narrowed series about a later bar
throws, because that bar is not part of the value at all — the future is not merely guarded, it is absent.

Both `PriceSeries` and `IndicatorSeries` have it, and because every shipped indicator is causal the two
routes agree exactly:

```csharp
IndicatorSeries whole = prices.Sma(20);

double? narrowed   = whole.AsOf(40).Latest;
double? recomputed = prices.AsOf(40).Sma(20).Latest;

Console.WriteLine($"whole.AsOf(40).Latest          = {narrowed}");
Console.WriteLine($"prices.AsOf(40).Sma(20).Latest = {recomputed}");
Console.WriteLine($"equal = {narrowed == recomputed}");
Console.WriteLine($"whole.AsOf(40).BarCount={whole.AsOf(40).BarCount} FirstBar={whole.AsOf(40).FirstBar}");
whole.AsOf(40)[41];   // throws
```

Real output:

```text
whole.AsOf(40).Latest          = 103.16686499999994
prices.AsOf(40).Sma(20).Latest = 103.16686499999994
equal = True
whole.AsOf(40).BarCount=41 FirstBar=19
System.ArgumentOutOfRangeException: The bar index must lie in [0, 41). A bar inside that range that has
no value is reported as null rather than as an exception. (Parameter 'bar')
Actual value was 41.
```

Prefer the first route. `IndicatorSeries.AsOf` is allocation-free and `O(1)`; recomputing the indicator
inside a per-bar loop is `O(n²)` for the identical answer. `MacdSeries`, `BollingerBandsSeries` and
`StochSeries` each expose an `AsOf` that narrows all of their components at once.

---

## 📊 The indicators

Nine indicators ship as extension methods on `PriceSeries`, in the same
`TechnicalAnalysis.Functions` namespace. The declaring classes (`OverlapStudyIndicators`,
`MomentumIndicators`, `VolatilityIndicators`, `VolumeIndicators`) are TA-Lib's own function groups and
never appear at a call site.

The examples below all run against a deterministic 60-bar series, so you can reproduce every number:

```csharp
static (double[] Open, double[] High, double[] Low, double[] Close, double[] Volume) Demo(int bars = 60)
{
    double[] open = new double[bars];
    double[] high = new double[bars];
    double[] low = new double[bars];
    double[] close = new double[bars];
    double[] volume = new double[bars];

    for (int i = 0; i < bars; i++)
    {
        double mid = 100.0 + (i * 0.25) + (8.0 * Math.Sin(i / 6.0));
        close[i] = Math.Round(mid, 4);
        high[i] = Math.Round(mid + 1.5, 4);
        low[i] = Math.Round(mid - 1.5, 4);
        open[i] = i == 0 ? close[0] : close[i - 1];
        volume[i] = 1000 + (i * 10);
    }

    return (open, high, low, close, volume);
}
```

It is referenced below as `var (open, high, low, close, volume) = Demo();`.

### Overlap studies

```csharp
public static IndicatorSeries Sma(this PriceSeries prices, int timePeriod = 30);
public static IndicatorSeries Ema(this PriceSeries prices, int timePeriod = 30);
public static BollingerBandsSeries BollingerBands(
    this PriceSeries prices,
    int timePeriod = 5,
    double nbDevUp = 2.0,
    double nbDevDn = 2.0,
    MAType maType = MAType.Sma);
```

All three read closes only, so `FromClose` is enough. `BollingerBandsSeries` is a
`readonly record struct (IndicatorSeries Upper, IndicatorSeries Middle, IndicatorSeries Lower)` with an
`AsOf`.

```csharp
using TechnicalAnalysis.Functions;

var (open, high, low, close, volume) = Demo();
PriceSeries prices = PriceSeries.FromClose(close);

IndicatorSeries sma = prices.Sma(20);
IndicatorSeries ema = prices.Ema(20);
BollingerBandsSeries bb = prices.BollingerBands(timePeriod: 20, nbDevUp: 2.0, nbDevDn: 2.0);

Console.WriteLine($"Sma(20) FirstBar={sma.FirstBar} Latest={sma.Latest:0.####}");
Console.WriteLine($"Ema(20) FirstBar={ema.FirstBar} Latest={ema.Latest:0.####}");
Console.WriteLine($"BB      FirstBar={bb.Middle.FirstBar} Upper={bb.Upper.Latest:0.####} Middle={bb.Middle.Latest:0.####} Lower={bb.Lower.Latest:0.####}");
Console.WriteLine($"BB default period FirstBar={prices.BollingerBands().Middle.FirstBar}");
```

Real output:

```text
Sma(20) FirstBar=19 Latest=116.7883
Ema(20) FirstBar=19 Latest=114.5205
BB      FirstBar=19 Upper=122.0419 Middle=116.7883 Lower=111.5346
BB default period FirstBar=4
```

That last line is the point of [the defaults section below](#defaults-are-ta-libs-not-the-conventional-ones):
`prices.BollingerBands()` is a **5**-period band, not a 20-period one.

### Momentum

```csharp
public static IndicatorSeries Rsi(this PriceSeries prices, int timePeriod = 14);
public static IndicatorSeries Adx(this PriceSeries prices, int timePeriod = 14);
public static MacdSeries Macd(
    this PriceSeries prices,
    int fastPeriod = 12,
    int slowPeriod = 26,
    int signalPeriod = 9);
public static StochSeries Stoch(
    this PriceSeries prices,
    int fastKPeriod = 5,
    int slowKPeriod = 3,
    MAType slowKMAType = MAType.Sma,
    int slowDPeriod = 3,
    MAType slowDMAType = MAType.Sma);
```

`Rsi` and `Macd` need closes only. `Adx` and `Stoch` need high and low as well, because directional
movement and "where the close sits in the recent range" are both properties of a bar's range.

`MacdSeries` is `(Line, Signal, Histogram)`; `StochSeries` is `(SlowK, SlowD)` — the same component names
as `StochResult`, so moving between the two layers costs nothing. Each component is a full
`IndicatorSeries`, which is why a signal-line crossing needs no dedicated member:
`macd.Line.CrossedAbove(macd.Signal, bar)` already says it.

```csharp
PriceSeries prices = PriceSeries.FromHlc(high, low, close);

IndicatorSeries rsi = prices.Rsi(14);
IndicatorSeries adx = prices.Adx(14);
MacdSeries macd = prices.Macd();
StochSeries stoch = prices.Stoch();

Console.WriteLine($"Rsi(14)  FirstBar={rsi.FirstBar} Latest={rsi.Latest:0.####}");
Console.WriteLine($"Adx(14)  FirstBar={adx.FirstBar} Latest={adx.Latest:0.####}");
Console.WriteLine($"Macd     Line.FirstBar={macd.Line.FirstBar} Signal.FirstBar={macd.Signal.FirstBar} Hist.FirstBar={macd.Histogram.FirstBar}");
Console.WriteLine($"Macd     Line={macd.Line.Latest:0.####} Signal={macd.Signal.Latest:0.####} Histogram={macd.Histogram.Latest:0.####}");
Console.WriteLine($"Stoch    SlowK.FirstBar={stoch.SlowK.FirstBar} SlowK={stoch.SlowK.Latest:0.####} SlowD={stoch.SlowD.Latest:0.####}");
```

Real output:

```text
Rsi(14)  FirstBar=14 Latest=41.9323
Adx(14)  FirstBar=27 Latest=40.6353
Macd     Line.FirstBar=33 Signal.FirstBar=33 Hist.FirstBar=33
Macd     Line=1.1881 Signal=2.4023 Histogram=-1.2142
Stoch    SlowK.FirstBar=8 SlowK=20.9371 SlowD=21.56
```

All three MACD components share a `FirstBar`, as do the three Bollinger bands and the two stochastic
lines: a multi-output indicator emits nothing until all of its outputs exist.

`Rsi` is bounded to `0 … 100`. A strictly rising series pins it at `100`, and a perfectly flat series
reads `0`, matching the reference C implementation. Because a series with no values answers `null` rather
than `0`, an RSI that has not warmed up can never be mistaken for an oversold one.

### Volatility

```csharp
public static IndicatorSeries Atr(this PriceSeries prices, int timePeriod = 14);
```

Needs high and low. Its `FirstBar` is `timePeriod`, not `timePeriod - 1`, because the first true range
needs a previous close.

```csharp
IndicatorSeries atr = PriceSeries.FromHlc(high, low, close).Atr(14);
Console.WriteLine($"Atr(14) FirstBar={atr.FirstBar} Latest={atr.Latest:0.####}");

// A series whose true range is exactly 4.0 on every bar.
double[] h = [.. Enumerable.Repeat(102.0, 40)];
double[] l = [.. Enumerable.Repeat(98.0, 40)];
double[] c = [.. Enumerable.Repeat(100.0, 40)];
IndicatorSeries flat = PriceSeries.FromHlc(h, l, c).Atr(14);
Console.WriteLine($"Atr over a constant true range of 4.0: FirstBar={flat.FirstBar} Latest={flat.Latest}");
```

Real output:

```text
Atr(14) FirstBar=14 Latest=3.0038
Atr over a constant true range of 4.0: FirstBar=14 Latest=4
```

### Volume

```csharp
public static IndicatorSeries Obv(this PriceSeries prices);
```

Needs volumes, which only `FromOhlcv` supplies. It has no lookback, so it is warm from bar `0`:

```csharp
IndicatorSeries obv = PriceSeries.FromOhlcv(close, high, low, close, volume).Obv();
Console.WriteLine($"Obv FirstBar={obv.FirstBar} WarmCount={obv.WarmCount} Latest={obv.Latest}");
```

Real output:

```text
Obv FirstBar=0 WarmCount=60 Latest=5580
```

The absolute level of OBV carries no meaning — it depends on where your series happens to start — so only
its direction and its divergence from price are read.

### Defaults are TA-Lib's, not the conventional ones

Every default in the table below is copied verbatim from the corresponding raw entry point. The fluent
layer never invents a number, so a fluent call and a raw call with the same arguments cannot disagree.

| Indicator | Defaults | Note |
| --- | --- | --- |
| `Sma` / `Ema` | `timePeriod: 30` | |
| `BollingerBands` | `timePeriod: 5`, `nbDevUp: 2.0`, `nbDevDn: 2.0`, `maType: MAType.Sma` | **20 is the conventional choice — pass it explicitly** |
| `Rsi` | `timePeriod: 14` | |
| `Adx` | `timePeriod: 14` | |
| `Macd` | `fastPeriod: 12`, `slowPeriod: 26`, `signalPeriod: 9` | |
| `Stoch` | `fastKPeriod: 5`, `slowKPeriod: 3`, `slowKMAType: Sma`, `slowDPeriod: 3`, `slowDMAType: Sma` | |
| `Atr` | `timePeriod: 14` | |
| `Obv` | *none* | |

`nbDevUp` and `nbDevDn` are not validated — any finite deviation is meaningful. Every `int` period is,
and the rule is uniform: **2 to 100000**, on every indicator. That is deliberately stricter than parts of
the raw layer, where a handful of entry points accept `1`; one rule that cannot be got wrong is worth more
than per-indicator fidelity to an inconsistency, and it is what stops a MACD signal period of `1` from
failing inside an internal array copy.

### The measured warm-up ladder

`FirstBar` for the default parameters, measured on the 60-bar demo series:

| Call | `FirstBar` | Why |
| --- | ---: | --- |
| `Obv()` | 0 | A running total needs no history |
| `BollingerBands()` | 4 | `timePeriod - 1`, with TA-Lib's default period of 5 |
| `Stoch()` | 8 | `fastK - 1 + slowK - 1 + slowD - 1` |
| `Atr(14)` | 14 | The first true range needs a previous close |
| `Rsi(14)` | 14 | |
| `Sma(20)` / `Ema(20)` | 19 | `timePeriod - 1` |
| `Adx(14)` | 27 | A smoothed average of a smoothed average — the longest on this surface |
| `Macd()` | 33 | Slow EMA, then the signal EMA on top of it |

Raising `TACore.Globals.UnstablePeriod[…]` pushes these out further; see
[§7.1 of the getting started guide](getting-started.md#71-unstable-periods). Read `FirstBar` from the
result rather than hard-coding any of these.

---

## 🚪 `Align` — the escape hatch to the other 89 indicators

Nine indicators have a fluent wrapper. The catalog has [98](../indicators/README.md). `PriceSeries.Align`
reaches the rest through the *same* primitive the shipped wrappers use, so an indicator aligned this way is
aligned exactly as carefully as one that ships:

```csharp
public IndicatorSeries Align(SingleOutputResult result);
public IndicatorSeries Align<TResult>(TResult result, Func<TResult, double[]> output)
    where TResult : IndicatorResult;
```

The raw result must have been computed over the same prices with `startIdx: 0` and
`endIdx: BarCount - 1`, otherwise its metadata does not describe these bars. The bar count is supplied by
the series itself, so it can never be mismatched.

```csharp
using TechnicalAnalysis.Functions;

var (_, high, low, close, _) = Demo();
PriceSeries prices = PriceSeries.FromHlc(high, low, close);
int last = prices.BarCount - 1;

IndicatorSeries cci     = prices.Align(TAMath.Cci(0, last, high, low, close, timePeriod: 20));
IndicatorSeries aroonUp = prices.Align(TAMath.Aroon(0, last, high, low, timePeriod: 14), r => r.AroonUp);

Console.WriteLine($"Cci(20)  FirstBar={cci.FirstBar} Latest={cci.Latest:0.####}");
Console.WriteLine($"AroonUp  FirstBar={aroonUp.FirstBar} Latest={aroonUp.Latest:0.####}");
```

Real output:

```text
Cci(20)  FirstBar=19 Latest=-152.5456
AroonUp  FirstBar=14 Latest=21.4286
```

Three things about that call worth knowing:

* **The multi-output overload takes a selector, not an array.** Passing
  `Align(result, r => r.AroonUp)` guarantees the metadata and the values come from the same result.
  Handing it a bare `double[]` would have opened a brand new way to pair one result's `BegIdx` with
  another result's numbers.
* **The values are copied**, so `result.Real` stays yours and may be post-processed in place afterwards.
  The copy is `O(NBElement)` against an `O(n)` computation.
* **You still need your own arrays.** `prices.Close` is a `ReadOnlySpan<double>` and `TAMath` wants
  `double[]`, so pass the arrays you already had when you built the series.

If a result's metadata does not fit the series — `BegIdx + NBElement` past `BarCount`, or `NBElement` past
its own array — `Align` throws `ArgumentException` naming `result`. It does not clamp. Clamping would hand
back a silently shifted series, which is the failure this whole design exists to prevent.

> **Naming your own extensions.** The shipped indicators are extension methods on `PriceSeries` in the
> `TechnicalAnalysis.Functions` namespace, and that set will grow towards the full TA-Lib surface. A
> user-authored `public static IndicatorSeries Cci(this PriceSeries, int)` becomes ambiguous (`CS0121`)
> the day the library ships its own `Cci`. Give your own extensions names the library will never take — a
> prefix, or a receiver type of your own.

---

## ⚠️ Error handling

The rule is: **a bad call throws, a short series does not.**

### What throws

| Situation | Exception |
| --- | --- |
| A period outside `2 … 100000` | `ArgumentOutOfRangeException`, naming the parameter |
| A bar index outside `[0, BarCount)` | `ArgumentOutOfRangeException` |
| A component array whose length differs from `close` | `ArgumentException`, naming the component |
| A non-finite price in any component | `ArgumentException`, naming the component and the first bad bar |
| `Atr` / `Adx` / `Stoch` on a series with no high and low | `InvalidOperationException`, naming the factory to use |
| `Obv` on a series with no volume | `InvalidOperationException` |
| Crossing two series with different `BarCount` | `ArgumentException` |
| A `CopyBarAligned` destination shorter than `BarCount` | `ArgumentException` |
| An `Align` result whose metadata does not fit the series | `ArgumentException`, naming `result` |

```csharp
prices.Sma(1);
```

```text
System.ArgumentOutOfRangeException: The period must lie between 2 and 100000. (Parameter 'timePeriod')
Actual value was 1.
```

```csharp
IndicatorSeries sixty = PriceSeries.FromClose(close).Sma(20);              // 60 bars
IndicatorSeries thirty = PriceSeries.FromClose(close[..30]).Sma(20);       // 30 bars
sixty.CrossedAbove(thirty, 40);
```

```text
System.ArgumentException: The other series covers 30 bar(s) but this one covers 60. Two series can only
be crossed when a bar index means the same thing in both. (Parameter 'other')
```

Note that periods and price components are validated **before** the series is checked for emptiness, so a
bad period is reported even when there is no data to compute over.

### What quietly produces nothing

Not enough data is not an error. It is a series with `BarCount` bars and no values:

```csharp
IndicatorSeries sma = PriceSeries.FromClose([1.0, 2.0, 3.0]).Sma(30);

Console.WriteLine($"RetCode={sma.RetCode} HasValues={sma.HasValues} WarmCount={sma.WarmCount} BarCount={sma.BarCount}");
Console.WriteLine($"FirstBar={sma.FirstBar} Latest={sma.Latest} sma[2]={sma[2]}");
```

Real output:

```text
RetCode=Success HasValues=False WarmCount=0 BarCount=3
FirstBar= Latest= sma[2]=
```

`FirstBar`, `Latest` and `sma[2]` are all `null`. Nothing is `0.0`; nothing throws.

`PriceSeries.Empty` (which is `default(PriceSeries)`) is the same idea at zero bars, with one wrinkle
worth knowing: it carries no high, low or volume, so the indicators that need them throw rather than
returning nothing. A feed that must answer every indicator before it has any bars wants
`PriceSeries.FromOhlcv([], [], [], [], [])`, where the components are present and merely empty:

```text
PriceSeries.Empty: BarCount=0 IsEmpty=True HasHighLow=False
empty.Sma(20): RetCode=Success BarCount=0 HasValues=False Latest=
empty.Atr(14) -> InvalidOperationException (no high/low component)
FromOhlcv([],[],[],[],[]): BarCount=0 Atr HasValues=False Obv HasValues=False
```

### `RetCode` is not warmth

`IndicatorSeries.RetCode` is carried through from the raw call, and it answers only "were the parameters
acceptable". It never answers "are there values" — a period longer than the available data is a *success*
that produces nothing, as the block above shows.

**`HasValues` is the only warmth test.** Note also that `default(IndicatorSeries)` is a valid empty series
reporting `RetCode.Success`, because `Success == 0`.

In practice you rarely touch `RetCode` at all: the fluent layer validates every parameter the raw layer
could refuse *before* computing, so a non-`Success` code would indicate a library defect and is raised as
`InvalidOperationException` rather than returned. It is exposed so that a series can still be inspected,
not so that you have to branch on it.

---

## 🙅 What the fluent API deliberately does not do

* **No thresholded verdicts.** There is no `IsOverbought`, `IsBullish`, `IsStrongTrend` or `IsSqueeze`. A
  wrong number looks wrong; a wrong `bool` looks authoritative and has already destroyed the evidence that
  would have shown it was wrong. The conventional levels are conventions anyway — 70 and 30 come from a
  1978 book about daily bars — so they belong in your source file, under your review.
* **No derived measures.** No `%B`, no bandwidth. They are arithmetic on three numbers you already have,
  and every convention for computing them is an opinion.
* **No caching.** `prices.Sma(20)` twice computes twice. Because these are value types with no lazy state,
  caching is one field at your composition root when you want it, and there is no shared mutable state and
  no locking when you do not.
* **No incremental/streaming update.** There is no "append one bar" path; recompute over the whole series,
  which is what the [real-time sample](real-time-streaming.md#when-to-move-to-a-true-incremental-indicator)
  does and discusses.
* **No `float` or `decimal` overloads.** The fluent surface is `double` only. `TAMath`'s `float[]`
  overloads widen to `double[]` and compute in `double` anyway — see
  [§5 of the getting started guide](getting-started.md#5-choosing-double-vs-float).
* **No candlestick patterns yet.** `TACandle` remains the way to detect those.

---

## 🔁 When to prefer `TAMath`

The fluent API is the right default for application code. Reach past it when:

* **You need one of the other 89 indicators** and would rather not write the `Align` call — though `Align`
  is one line and gives you the alignment guarantee for free, so this is rarely the right reason.
* **You need `float[]` or `decimal[]` inputs.** `TAMath` has `float[]` overloads and `TACandle` is generic
  over `IFloatingPoint<T>`.
* **You need a genuine sub-range.** The fluent layer always analyses the whole series; `TAMath` lets you
  set `startIdx`/`endIdx` explicitly.
* **You are counting allocations in a hot loop.** `TAFunc` lets you own and reuse the output buffer;
  `PriceSeries` factories copy their inputs, and each fluent call allocates one output array. The
  [benchmarks guide](benchmarks.md#-measured-results) prices the `TAFunc`-versus-`TAMath` gap.
* **You are porting existing code** that already handles `BegIdx`/`NBElement` correctly and you have no
  reason to touch it.

The two layers are not exclusive and produce identical numbers, because the fluent layer *calls* `TAMath`.
Mixing them in one file is fine.

---

## 🧩 Composing with the samples

Both runnable samples were written before this API landed, and each solved the alignment problem for
itself. They are worth reading as two independent statements of the same rule — and as a measure of how
much the fluent API removes.

### Backtesting

[`samples/TechnicalAnalysis.Samples.Backtesting`](../../samples/TechnicalAnalysis.Samples.Backtesting)
carries its own `IndicatorSeries`, `MacdSeries` and `BollingerBandSeries` in
`TechnicalAnalysis.Samples.Backtesting.Engine`. **They are different types with the same names as the
library's**, so a file that uses both needs an alias; the sample's versions add a look-ahead guard the
library's do not have.

The shapes line up closely, which makes the mapping easy to read:

| Sample engine | Fluent API |
| --- | --- |
| `TryGetValue(bar, out value)` | `series[bar] is { } value` |
| `HasValueAt(bar)` / `HasCurrent` | `series.IsWarmAt(bar)` / `series.Latest is not null` |
| `this[bar]` (throws while warming up) | `series[bar]` (`null` while warming up) |
| `TryGetPair(bar, out prev, out cur)` | `series.CrossedAbove(other, bar)` and friends |
| the window bound that raises `LookAheadException` | `series.AsOf(bar)`, where later bars are simply absent |

The one thing the sample has that the library does not is causality *enforcement*: reading a future bar
throws `LookAheadException`. `AsOf` gets there differently — instead of guarding an index it hands over a
value that does not contain the future, so `prices.AsOf(bar)` given to a strategy makes look-ahead
unrepresentable rather than detectable. The sample's
[no-look-ahead section](backtesting.md#-the-no-look-ahead-guarantee) is worth reading for why that
distinction matters.

A per-bar strategy loop in fluent terms — compute once outside the loop, narrow or index inside it:

```csharp
using TechnicalAnalysis.Functions;

PriceSeries prices = PriceSeries.FromHlc(high, low, close);

IndicatorSeries fast = prices.Sma(5);
IndicatorSeries slow = prices.Sma(20);
IndicatorSeries atr  = prices.Atr(14);

for (int bar = 0; bar < prices.BarCount; bar++)
{
    if (!fast.IsWarmAt(bar) || !slow.IsWarmAt(bar) || !atr.IsWarmAt(bar))
    {
        continue;
    }

    if (fast.CrossedAbove(slow, bar))
    {
        double stop = close[bar] - (3.0 * atr[bar]!.Value);
        Console.WriteLine($"bar {bar}: long at {close[bar]:0.####}, stop {stop:0.####}");
    }
}
```

Real output on the 60-bar demo series:

```text
bar 35: long at 105.2713, stop 96.266
```

Computing the three indicators once and indexing per bar is `O(n)`; calling `prices.AsOf(bar).Sma(5)`
inside the loop would be `O(n²)` for the same answer, because every shipped indicator is causal.

### Real-time streaming

[`samples/TechnicalAnalysis.Samples.RealTime`](../../samples/TechnicalAnalysis.Samples.RealTime) recomputes
over a rolling window on every closed bar and publishes one nullable field per indicator, where **null
means "no value for this bar"** — the same contract as `IndicatorSeries`, expressed on the wire. Its
`RollingIndicatorEngine.Latest` helper does by hand precisely what `IndicatorSeries.Latest` does: read
array index `NBElement - 1`, and refuse to hand back a value whose bar is not the bar being reported.

In fluent terms, that helper is:

```csharp
double? latest = PriceSeries.FromHlc(windowHigh, windowLow, windowClose).Rsi(14).Latest;
```

with two differences worth naming. The sample additionally returns `null` for a non-finite value, which the
fluent layer reaches from the other end by rejecting non-finite *inputs* at the factory. And the sample
checks that the newest output really belongs to the newest input bar; `IndicatorSeries` gets that for free,
because `Latest` is `LastBar`'s value and `Create` refuses metadata that does not fit the series at all.

Its [warm-up and null semantics section](real-time-streaming.md#-warm-up-and-null-semantics) has the
measured warm-up ladder against a live feed, and its
[incremental-versus-recompute discussion](real-time-streaming.md#when-to-move-to-a-true-incremental-indicator)
applies unchanged to the fluent API, which is also a full recompute.

---

## Related

* [Getting started](getting-started.md) — installation, `RetCode`/`BegIdx`/`NBElement` from first
  principles, `TACore.Globals`, the low-level `TAFunc` API and the common pitfalls.
* [Indicator catalog](../indicators/README.md) — all 159 entry points with signatures, defaults and
  outputs, for everything `Align` reaches.
* [Backtesting](backtesting.md) — the engine model and the structurally enforced no-look-ahead guarantee.
* [Real-time streaming](real-time-streaming.md) — the same alignment rule against a live feed.
* [TradingView integration](tradingview-integration.md) — parity caveats when reconciling against a chart.
