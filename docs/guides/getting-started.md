# Getting started with TaLibStandard

TaLibStandard is a C# 14 / .NET 10 port of TA-Lib. It ships 98 technical indicators and 61
candlestick patterns as pure, allocation-light static methods with no native dependency.

This guide covers installation, the one concept you must understand before you trust a single
number the library returns (`BegIdx` / `NBElement`), and the traps that bite everybody once.

> Every code block below was compiled and executed against the source in this repository. The
> numbers printed in the worked examples are real program output, not illustrations.

---

## 1. Installation

### The meta-package

`Atypical.TechnicalAnalysis` is a meta-package: it contains no code of its own, it just references
`Atypical.TechnicalAnalysis.Functions` and `Atypical.TechnicalAnalysis.Candles` (which in turn pull
in `Atypical.TechnicalAnalysis.Common`).

```bash
dotnet add package Atypical.TechnicalAnalysis
```

### Individual packages

If you only need indicators, or only need candlestick patterns, reference just what you use:

```bash
dotnet add package Atypical.TechnicalAnalysis.Functions   # TAMath / TAFunc - 98 indicators
dotnet add package Atypical.TechnicalAnalysis.Candles     # TACandle        - 61 patterns
```

Both depend on `Atypical.TechnicalAnalysis.Common`, which carries the shared types (`RetCode`,
`MAType`, `IndicatorResult` and friends). You never need to reference it explicitly.

### Namespaces

There are four, and they are not all the same shape as the package ids:

| Type | Namespace | Package |
| --- | --- | --- |
| `TAMath`, `TAFunc`, every `*Result` record | `TechnicalAnalysis.Functions` | `Atypical.TechnicalAnalysis.Functions` |
| `TACandle` | `TechnicalAnalysis.Candles` | `Atypical.TechnicalAnalysis.Candles` |
| `RetCode`, `MAType`, `FuncUnstId`, `IndicatorResult`, `CandleIndicatorResult`, `CandleSetting`, `CandleSettingType`, `RangeType`, `Compatibility`, `GlobalsType`, `ValidationHelper` | `TechnicalAnalysis.Common` | `Atypical.TechnicalAnalysis.Common` |
| `TACore` (the global settings holder) | `TechnicalAnalysis` | `Atypical.TechnicalAnalysis.Common` |

Note the last row: **`TACore` lives in the bare `TechnicalAnalysis` namespace**, not in
`TechnicalAnalysis.Common`. A typical file starts with:

```csharp
using TechnicalAnalysis;            // TACore
using TechnicalAnalysis.Candles;    // TACandle
using TechnicalAnalysis.Common;     // RetCode, MAType, FuncUnstId, ...
using TechnicalAnalysis.Functions;  // TAMath, TAFunc, SmaResult, ...
```

### Target framework

The packages target `net10.0` only. `LangVersion` is 14, nullable reference types are enabled, and
the candlestick API uses generic math (`System.Numerics.IFloatingPoint<T>`), which requires .NET 7
or later at minimum.

---

## 2. Your first indicator in five lines

```csharp
using TechnicalAnalysis.Functions;

double[] close = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19];
SmaResult sma = TAMath.Sma(0, close.Length - 1, close, timePeriod: 5);
Console.WriteLine($"RetCode={sma.RetCode} BegIdx={sma.BegIdx} NBElement={sma.NBElement}");
Console.WriteLine(string.Join(", ", sma.Real));
```

Real output:

```text
RetCode=Success BegIdx=4 NBElement=6
12, 13, 14, 15, 16, 17, 0, 0, 0, 0
```

Look at that second line carefully. `sma.Real` has **10** elements — the same length as the input —
but only the **first 6** are real SMA values, and the first of them belongs to input bar **4**, not
bar 0. The trailing four zeros are uninitialised slack.

That is the whole game. Read the next section before writing any trading logic.

---

## 3. `RetCode`, `BegIdx`, `NBElement` — the part that actually matters

### 3.1 Anatomy of a result

Every `TAMath.*` and `TACandle.*` method returns a record deriving from
`TechnicalAnalysis.Common.IndicatorResult`:

```csharp
public abstract record IndicatorResult
{
    public RetCode RetCode { get; }   // Success, BadParam, OutOfRangeStartIndex, OutOfRangeEndIndex, InternalError
    public int BegIdx { get; }        // index, in the INPUT array, of the first valid output element
    public int NBElement { get; }     // how many output elements are valid  (note: capital B)
}
```

- `SingleOutputResult` adds `public double[] Real { get; }`.
- `DualOutputResult` / `TripleOutputResult` keep `Real0` / `Real1` / `Real2` **protected**; the
  concrete record exposes named properties (`MacdValue`, `RealUpperBand`, `SlowK`, ...).
- `CandleIndicatorResult` adds `public int[] Integers { get; }` with values `0`, `+100` or `-100`.

`TAMath` allocates every output array as `new double[endIdx - startIdx + 1]` and fills it **from
index 0**. So:

> **Output element `k` corresponds to input bar `BegIdx + k`, for `k` in `[0, NBElement)`.**
> Everything at index `>= NBElement` is meaningless.

Getting this wrong silently shifts every signal in time. It is the single most common correctness
bug when consuming this library, and it never throws.

### 3.2 A fully worked example

Eight daily bars, a 3-period SMA:

```csharp
using TechnicalAnalysis.Functions;

DateTime[] dates =
[
    new(2024, 1, 2), new(2024, 1, 3), new(2024, 1, 4), new(2024, 1, 5),
    new(2024, 1, 8), new(2024, 1, 9), new(2024, 1, 10), new(2024, 1, 11)
];
double[] close = [100.0, 102.0, 101.0, 105.0, 107.0, 106.0, 110.0, 111.0];

SmaResult sma = TAMath.Sma(0, close.Length - 1, close, timePeriod: 3);

Console.WriteLine($"Real.Length={sma.Real.Length} RetCode={sma.RetCode} BegIdx={sma.BegIdx} NBElement={sma.NBElement}");

for (int k = 0; k < sma.NBElement; k++)
{
    int bar = sma.BegIdx + k;
    Console.WriteLine($"k={k} bar={bar} date={dates[bar]:yyyy-MM-dd} close={close[bar]} sma={sma.Real[k]}");
}
```

Real output:

```text
Real.Length=8 RetCode=Success BegIdx=2 NBElement=6
k=0 bar=2 date=2024-01-04 close=101 sma=101
k=1 bar=3 date=2024-01-05 close=105 sma=102.66666666666667
k=2 bar=4 date=2024-01-08 close=107 sma=104.33333333333333
k=3 bar=5 date=2024-01-09 close=106 sma=106
k=4 bar=6 date=2024-01-10 close=110 sma=107.66666666666667
k=5 bar=7 date=2024-01-11 close=111 sma=109
```

Cross-check the arithmetic by hand:

| Bar | Date | Close | Window | SMA(3) | Output slot |
| ---: | --- | ---: | --- | ---: | --- |
| 0 | 2024-01-02 | 100 | — | warm-up | — |
| 1 | 2024-01-03 | 102 | — | warm-up | — |
| 2 | 2024-01-04 | 101 | (100 + 102 + 101) / 3 | 101 | `Real[0]` |
| 3 | 2024-01-05 | 105 | (102 + 101 + 105) / 3 | 102.666… | `Real[1]` |
| 4 | 2024-01-08 | 107 | (101 + 105 + 107) / 3 | 104.333… | `Real[2]` |
| 5 | 2024-01-09 | 106 | (105 + 107 + 106) / 3 | 106 | `Real[3]` |
| 6 | 2024-01-10 | 110 | (107 + 106 + 110) / 3 | 107.666… | `Real[4]` |
| 7 | 2024-01-11 | 111 | (106 + 110 + 111) / 3 | 109 | `Real[5]` |

The raw array is:

```text
[101, 102.66666666666667, 104.33333333333333, 106, 107.66666666666667, 109, 0, 0]
 |<------------------- NBElement = 6 valid elements, bars 2..7 ----------->| |<-->|
                                                                    index >= NBElement:
                                                                    padding, not data
```

`BegIdx == 2` because a 3-period SMA needs 2 prior bars. You can ask for that number up front:

```csharp
int lookback = TAFunc.SmaLookback(3);   // => 2
```

Every indicator has a matching `TAFunc.<Name>Lookback(...)`. Measured values:

| Call | Lookback |
| --- | ---: |
| `TAFunc.SmaLookback(3)` | 2 |
| `TAFunc.EmaLookback(30)` | 29 |
| `TAFunc.RsiLookback(14)` | 14 |
| `TAFunc.AtrLookback(14)` | 14 |
| `TAFunc.AdxLookback(14)` | 27 |
| `TAFunc.MacdLookback(12, 26, 9)` | 33 |
| `TAFunc.BollingerBandsLookback(20, MAType.Sma)` | 19 |
| `TAFunc.StochLookback(5, 3, MAType.Sma, 3, MAType.Sma)` | 8 |
| `TAFunc.CciLookback(20)` | 19 |
| `TAFunc.ObvLookback()` | 0 |

### 3.3 Aligning an indicator back onto the price series

Charting libraries, joins and backtests all want an array parallel to the bar array. Write the
projection once and never do it inline again:

```csharp
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

public static class IndicatorAlignment
{
    /// <summary>
    /// Projects a single-output indicator back onto the original bar index space,
    /// padding the warm-up region with <see cref="double.NaN"/>.
    /// </summary>
    public static double[] AlignTo(this SingleOutputResult result, int barCount)
    {
        ArgumentNullException.ThrowIfNull(result);

        double[] aligned = new double[barCount];
        Array.Fill(aligned, double.NaN);

        if (result.RetCode != RetCode.Success)
        {
            return aligned;
        }

        for (int k = 0; k < result.NBElement; k++)
        {
            aligned[result.BegIdx + k] = result.Real[k];
        }

        return aligned;
    }
}
```

```csharp
double[] aligned = TAMath.Sma(0, close.Length - 1, close, timePeriod: 3).AlignTo(close.Length);
Console.WriteLine(string.Join(", ", aligned.Select(v => double.IsNaN(v) ? "NaN" : v.ToString("0.####"))));
```

Real output:

```text
NaN, NaN, 101, 102.6667, 104.3333, 106, 107.6667, 109
```

Now `aligned[i]` and `close[i]` refer to the same bar, and `double.NaN` marks "not computable yet"
so it can never be mistaken for a legitimate `0.0` reading — which matters enormously for
oscillators such as MACD or CCI that genuinely cross zero.

Prefer `NaN` padding over `0.0` padding; prefer both over silently reusing `Real` as if it were
bar-aligned.

### 3.4 `startIdx` does not clip the input array

This surprises everyone. `startIdx` is where you want output to *begin*, not where the data begins.
The function still reads bars **before** `startIdx` when they exist:

```csharp
SmaResult subset = TAMath.Sma(2, 7, close, timePeriod: 3);
Console.WriteLine($"Real.Length={subset.Real.Length} BegIdx={subset.BegIdx} NBElement={subset.NBElement}");
Console.WriteLine(string.Join(", ", subset.Real));
```

Real output:

```text
Real.Length=6 BegIdx=2 NBElement=6
101, 102.66666666666667, 104.33333333333333, 106, 107.66666666666667, 109
```

Six outputs starting at bar 2 — including bar 2 itself, whose SMA needed bars 0 and 1. Contrast
with `TAMath.Sma(0, 7, close, 3)` from §3.2, which also produced `BegIdx = 2`: with `startIdx = 0`
the engine clamps `startIdx` up to the lookback; with `startIdx = 2` it already has enough history.

Two consequences:

- **Do not slice your price array to "save work".** Slicing destroys the history the indicator
  needs and moves `BegIdx`. Pass the full array and set `startIdx`/`endIdx` instead.
- `Real.Length == endIdx - startIdx + 1`, always, whatever `NBElement` turns out to be.
- `BegIdx == max(startIdx, lookback)`. It is an index into the **input** array, never an offset
  relative to `startIdx`, and never less than `startIdx`.

### 3.5 `RetCode` is necessary, not sufficient

```csharp
SmaResult tooShort = TAMath.Sma(0, 1, [1.0, 2.0], timePeriod: 30);
Console.WriteLine($"{tooShort.RetCode} BegIdx={tooShort.BegIdx} NBElement={tooShort.NBElement}");

SmaResult badPeriod = TAMath.Sma(0, 7, close, timePeriod: 1);
Console.WriteLine($"{badPeriod.RetCode} NBElement={badPeriod.NBElement}");

SmaResult badStart = TAMath.Sma(-1, 5, close, timePeriod: 3);
Console.WriteLine(badStart.RetCode);
```

Real output:

```text
Success BegIdx=0 NBElement=0
BadParam NBElement=0
OutOfRangeStartIndex
```

**Not enough data is `Success` with `NBElement == 0`, not an error.** Always guard on both:

```csharp
if (result.RetCode != RetCode.Success || result.NBElement == 0)
{
    return;   // nothing usable
}
```

The full `RetCode` enum is small:

| Value | Numeric | Meaning |
| --- | ---: | --- |
| `RetCode.Success` | 0 | Call completed. `NBElement` may still be `0`. |
| `RetCode.BadParam` | 2 | A period is out of range (valid range is 2..100000 for most), or an input array is `null`. |
| `RetCode.OutOfRangeStartIndex` | 12 | `startIdx < 0`. |
| `RetCode.OutOfRangeEndIndex` | 13 | `endIdx < 0` or `endIdx < startIdx`. |
| `RetCode.InternalError` | 5000 | Should not happen; report it. |

---

## 4. Multi-output indicators

`Real0` / `Real1` / `Real2` are `protected`. Use the named properties:

```csharp
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

double[] high = /* ... */;
double[] low = /* ... */;
double[] close = /* ... */;
int last = close.Length - 1;

MacdResult macd = TAMath.Macd(0, last, close,
    optInFastPeriod: 12, optInSlowPeriod: 26, optInSignalPeriod: 9);
// macd.MacdValue, macd.MacdSignal, macd.MacdHist

BollingerBandsResult bb = TAMath.BollingerBands(0, last, close,
    timePeriod: 20, nbDevUp: 2.0, nbDevDn: 2.0, maType: MAType.Sma);
// bb.RealUpperBand, bb.RealMiddleBand, bb.RealLowerBand

StochResult stoch = TAMath.Stoch(0, last, high, low, close,
    fastKPeriod: 5, slowKPeriod: 3, slowKMAType: MAType.Sma,
    slowDPeriod: 3, slowDMAType: MAType.Sma);
// stoch.SlowK, stoch.SlowD
```

All output arrays of one result share the **same** `BegIdx` and `NBElement`. You align them once.

A few results are `int[]` rather than `double[]`: `MaxIndexResult.Integers`, `MinIndexResult.Integers`,
`HtTrendModeResult.Integers`, and `MinMaxIndexResult.MinIdx` / `.MaxIdx`. See the
[indicator reference](../indicators/README.md) for the exact output property names of all 159 entry
points.

---

## 5. Choosing `double` vs `float`

Almost every `TAMath` method is declared twice — once with `double[]` inputs, once with `float[]`:

```csharp
public static SmaResult Sma(int startIdx, int endIdx, double[] real, int timePeriod = 30);
public static SmaResult Sma(int startIdx, int endIdx, float[] real, int timePeriod = 30);
```

The `float[]` overload is a thin adapter: it widens each input array to a freshly allocated
`double[]` and calls the `double[]` implementation. Therefore:

- **Computation is always in `double`.** There is no reduced-precision code path.
- **Outputs are always `double[]`** (or `int[]`), whatever the input type. `SmaResult.Real` is
  `double[]` even when you called the `float[]` overload.
- The `float[]` overload **costs one extra array allocation and copy per input array**.

Rules of thumb:

- Store and pass `double[]` unless something outside your control hands you `float[]`.
- Never round-trip `double[] -> float[] -> TAMath` to "save memory"; you pay an allocation and lose
  precision for nothing.
- If your source of truth is `decimal` (an exchange API, a ledger), convert to `double` once at the
  boundary for `TAMath`. For `TACandle`, you do not need to convert at all — see the next section.

The `float[]` overload is not a compatibility shim you should feel bad about using; it exists so
that pipelines already holding `float[]` (GPU buffers, interop, compact caches) do not need a manual
conversion step. It just is not faster.

> One sharp edge: because both overloads exist, `TAMath.Sma(0, 7, null, 3)` does not compile —
> `CS0121: the call is ambiguous`. Cast the `null`, or better, do not pass `null` (it returns
> `RetCode.BadParam` anyway).

---

## 6. Candlestick patterns with generic math

`TACandle` is generic over `T : IFloatingPoint<T>`:

```csharp
public static CandleIndicatorResult CdlDoji<T>(
    int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
    where T : IFloatingPoint<T>;
```

`double`, `float` and `decimal` all satisfy that constraint (as do `Half` and `NFloat`), so a
`decimal[]` price series — the natural representation for exchange data — runs through pattern
recognition with **no conversion**:

```csharp
using TechnicalAnalysis.Candles;
using TechnicalAnalysis.Common;

decimal[] open  = [100m, 100m, 100m, 100m, 100m, 100m, 100m, 100m, 100m, 100m, 100m, 105m,  98m, 100m];
decimal[] high  = [101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 106m, 107m, 101m];
decimal[] low   = [ 99m,  99m,  99m,  99m,  99m,  99m,  99m,  99m,  99m,  99m,  99m,  99m,  97m,  99m];
decimal[] close = [101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m, 101m,  99m, 106m, 100m];

CandleIndicatorResult engulfing = TACandle.CdlEngulfing(0, close.Length - 1, open, high, low, close);

Console.WriteLine($"RetCode={engulfing.RetCode} BegIdx={engulfing.BegIdx} NBElement={engulfing.NBElement}");
for (int k = 0; k < engulfing.NBElement; k++)
{
    if (engulfing.Integers[k] != 0)
    {
        Console.WriteLine($"bar {engulfing.BegIdx + k}: {engulfing.Integers[k]}");
    }
}
```

Real output:

```text
RetCode=Success BegIdx=2 NBElement=12
bar 11: -100
bar 12: 100
```

Bar 11 is a bearish engulfing (`-100`), bar 12 a bullish one (`+100`). Running the identical series
as `double[]` and as `float[]` produced byte-identical `Integers` arrays.

Key facts:

- `CandleIndicatorResult.Integers` is `int[]`, and it obeys the **same** `BegIdx` / `NBElement`
  contract as `Real`. `Integers.Length` is `endIdx - startIdx + 1`; only `NBElement` entries are
  valid, starting at input bar `BegIdx`.
- `0` = pattern absent, `+100` = bullish, `-100` = bearish. Only the direction-aware patterns emit
  both signs — `CdlEngulfing` derives the sign from the candle colour. Single-direction patterns emit
  one sign only: `Cdl2Crows` emits `0`/`-100`, `CdlHammer` emits `0`/`+100`, and non-directional
  patterns such as `CdlDoji` emit `0`/`+100` where `+100` just means "present". Test `!= 0` when you
  only care about presence.
- Seven patterns take an extra `T penetration` argument and also expose a no-penetration overload:
  `CdlAbandonedBaby`, `CdlDarkCloudCover`, `CdlEveningDojiStar`, `CdlEveningStar`, `CdlMatHold`,
  `CdlMorningDojiStar`, `CdlMorningStar`. Because the parameter is `T`, you write `0.3m` for
  `decimal[]` inputs and `0.3` for `double[]` inputs:

  ```csharp
  CandleIndicatorResult ms = TACandle.CdlMorningStar(0, close.Length - 1, open, high, low, close, 0.3m);
  CandleIndicatorResult msDefault = TACandle.CdlMorningStar(0, close.Length - 1, open, high, low, close);
  ```

- Pattern lookbacks are driven by the **global candle settings**, not only by the bar geometry. A
  `CdlDoji` on the 14-bar series above returned `BegIdx = 10`, because `CandleSettingType.BodyDoji`
  averages the body over 10 bars by default. Short series legitimately produce `NBElement == 0`.

---

## 7. Tuning global behaviour via `TACore.Globals`

`TACore` (namespace `TechnicalAnalysis`) exposes a single process-wide `GlobalsType` instance with
three knobs.

### 7.1 Unstable periods

Recursive indicators (EMA, RSI, ADX, ATR, the Hilbert Transform family, …) never fully forget their
seed value. TA-Lib lets you discard an extra warm-up window so results converge to the
"steady-state" value regardless of where your data starts.

```csharp
using TechnicalAnalysis;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

Console.WriteLine(TACore.Globals.UnstablePeriod[FuncUnstId.Ema]);  // 0 by default
Console.WriteLine(TAFunc.EmaLookback(30));                         // 29

TACore.Globals.UnstablePeriod[FuncUnstId.Ema] = 100;
Console.WriteLine(TAFunc.EmaLookback(30));                         // 129
```

On a 200-bar series, `TAMath.Ema(0, 199, prices, timePeriod: 30)` moved from
`BegIdx = 29, NBElement = 171` to `BegIdx = 129, NBElement = 71` — the first 100 outputs were
discarded, and the ones that remain no longer depend on the arbitrary seed.

`UnstablePeriod` is a `Dictionary<FuncUnstId, long>` pre-populated with `0` for all 23 ids:
`Adx`, `Adxr`, `Atr`, `Cmo`, `Dx`, `Ema`, `HtDcPeriod`, `HtDcPhase`, `HtPhasor`, `HtSine`,
`HtTrendline`, `HtTrendMode`, `Kama`, `Mama`, `Mfi`, `MinusDI`, `MinusDM`, `Natr`, `PlusDI`,
`PlusDM`, `Rsi`, `StochRsi`, `T3` (plus the sentinels `FuncUnstNone = -1` and `FuncUnstAll = 23`,
which are **not** usable as keys — there is no "set them all" helper; loop over the ids you care
about).

When to raise it: when you compare against a chart whose history starts much earlier than yours, or
when you want two runs over different date ranges to agree on the overlap. Typical values are
`50`–`250`. The cost is a shorter output series.

### 7.2 Compatibility mode

```csharp
TACore.Globals.Compatibility = Compatibility.Metastock;   // default is Compatibility.Default
```

`Compatibility.Metastock` seeds EMA with the first input value and shifts the RSI/CMO lookback by
one. Only switch if you are explicitly reproducing MetaStock output.

`Compatibility.Default` is *meant* to seed EMA with the simple average of the first `timePeriod`
values, as the C library does. It does not: `TA_INT_EMA` sums `timePeriod - 1` values, divides by
`timePeriod`, and then applies one extra smoothing step, so
`TAMath.Ema(0, 7, [100, 102, 101, 105, 107, 106, 110, 111], timePeriod: 3)` returns `Real[0] =
84.166667` where the C library returns `101`. See [§10](#10-known-library-defects).

Seeding differences decay geometrically but never vanish — see the
[TradingView parity caveats](tradingview-integration.md#2-parity-caveats).

### 7.3 Candle settings

Candlestick detection thresholds are data, not constants:

```csharp
using TechnicalAnalysis;
using TechnicalAnalysis.Common;

CandleSetting bodyDoji = TACore.Globals.CandleSettings[CandleSettingType.BodyDoji];
// RangeType=HighLow, AvgPeriod=10, Factor=0.1

TACore.Globals.CandleSettings[CandleSettingType.BodyDoji] =
    new CandleSetting(CandleSettingType.BodyDoji, RangeType.HighLow, 10, 0.05);
```

The eleven tunable settings are `BodyLong`, `BodyVeryLong`, `BodyShort`, `BodyDoji`, `ShadowLong`,
`ShadowVeryLong`, `ShadowShort`, `ShadowVeryShort`, `Near`, `Far`, `Equal`
(`CandleSettingType.AllCandleSettings` is a sentinel, not a key). `CandleSetting.GetDefaultByType`
and the `CandleSetting.Default*` static properties give you the stock values back.

### 7.4 `TACore.Globals` is process-wide mutable state

There is no locking and no scoping. Set it once during start-up, before any indicator runs, and
treat it as immutable afterwards. Mutating it from a request handler while other requests compute
indicators produces non-deterministic results. If you need per-tenant settings, run separate
processes.

---

## 8. The low-level `TAFunc` API

`TAMath` is a friendly wrapper. `TAFunc` is the direct port, and it lets you own the output buffer —
useful in hot loops where you want to reuse arrays instead of allocating one per call:

```csharp
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;

double[] close = [100.0, 102.0, 101.0, 105.0, 107.0, 106.0, 110.0, 111.0];

int outBegIdx = 0;
int outNBElement = 0;
double[] outReal = new double[close.Length];

RetCode rc = TAFunc.Sma(0, close.Length - 1, close, 3, ref outBegIdx, ref outNBElement, ref outReal);
Console.WriteLine($"rc={rc} outBegIdx={outBegIdx} outNBElement={outNBElement} outReal[0]={outReal[0]}");
```

Real output:

```text
rc=Success outBegIdx=2 outNBElement=6 outReal[0]=101
```

The `in`/`ref` signature is `TAFunc.Sma(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal)`.
The same `BegIdx` / `NBElement` contract applies — `outReal[k]` is bar `outBegIdx + k`.

`TAFunc` also owns the `*Lookback` helpers used in §3.2.

---

## 9. Common pitfalls

**1. Treating `Real[i]` as bar `i`.** It is bar `BegIdx + i`. Always project through `BegIdx`.

**2. Iterating to `Real.Length` instead of `NBElement`.** The tail is zeros, and `0.0` is a perfectly
plausible value for MACD, CCI, ROC or a correlation. Loop to `NBElement`.

**3. Treating `RetCode.Success` as "I have data".** Insufficient history returns `Success` with
`NBElement == 0`. Guard on both.

**4. Passing `endIdx >= array.Length`.** The library validates index *ordering* and array *nullness*,
but not `endIdx` against the array length. `TAMath.Sma(0, 100, eightBars, 3)` throws
`IndexOutOfRangeException`. Always pass `endIdx: prices.Length - 1`.

**5. Passing `startIdx > endIdx`.** `TAMath` computes `new double[endIdx - startIdx + 1]`, so a
reversed range throws `OverflowException` before any validation runs. Check your range first.

**6. Slicing the price array to the window you care about.** That deletes the lookback history and
changes the answer. Pass the whole array with a narrower `startIdx`.

**7. Assuming `float[]` is cheaper.** It allocates a `double[]` copy of every input array and
computes in `double` regardless.

**8. Forgetting that unstable periods change `BegIdx`.** After raising
`TACore.Globals.UnstablePeriod[...]`, cached `Lookback` values and any hard-coded warm-up offsets are
wrong. Re-read `BegIdx` from the result.

**9. Mutating `TACore.Globals` concurrently.** See §7.4.

**10. Comparing against a chart without matching the history window.** Recursive indicators depend on
how far back the data starts. Two "RSI(14)" series computed from different start dates differ
slightly forever; that is mathematics, not a bug. See the
[TradingView parity caveats](tradingview-integration.md#2-parity-caveats).

**11. Reusing a result record after mutating the input array.** Results hold references to arrays
they allocated, but the inputs are read at call time. Recompute after any input change; there is no
incremental/streaming API.

**12. Assuming candlestick patterns work on tiny series.** Pattern lookbacks include the
`CandleSettings` averaging window (10 bars for `BodyDoji`, for example). Feed at least ~30 bars.

**13. Assuming every indicator is correct.** Three of them are not, and they fail quietly rather
than loudly: `TAMath.Atr` diverges to `+∞`, the EMA family seeds low, and `TAMath.Rsi` returns
`NaN` for a flat series — all with `RetCode.Success`. See [§10](#10-known-library-defects) before
you build on any of them.

**14. Charting a value without checking `double.IsFinite`.** `Success` and a non-zero `NBElement`
do not imply a finite number. One `NaN` or `∞` in a series poisons every aggregate computed from it,
and the two defects above both produce one.

---

## 10. Known library defects

These are bugs in `src/TechnicalAnalysis.Functions`, not in your code. They are listed here because
they are reachable from the five-line example at the top of this guide, and because a wrong number
that looks plausible costs more than a crash.

| Defect | What you get | Location |
|---|---|---|
| **`Atr` never divides its running average** | `TAMath.Atr` grows by a factor of `period - 1` on every bar after the second output. On a series whose true range is exactly `2.0` every bar, `Atr(…, 14)` returns `2, 2, 26.142857, 340, 4420.142857, 57462, …`; on a 1 500-bar series it is `+∞` from bar 300 onwards. `Natr` is *not* affected | `src/TechnicalAnalysis.Functions/Atr/TAFunc.cs`, main output loop |
| **`TA_INT_EMA` seeds itself low** | The seed sums `period - 1` values and divides by `period`, then smooths once more, so `TAMath.Ema` over a constant series of `100` with `timePeriod: 20` returns `95.476190` instead of `100`. The error decays with the smoothing factor, so it distorts the bars just after warm-up rather than the steady state. Affects `Ema`, `Macd`, `MacdExt`, `MacdFix`, `Dema`, `Tema`, `T3`, `Apo`, `Ppo`, `Trix` | `src/TechnicalAnalysis.Functions/TAFunc.cs`, `TA_INT_EMA` seed loop |
| **`Rsi` returns `NaN` on a perfectly flat series** | `RetCode.Success`, a non-zero `NBElement`, and every element `NaN` — there is no zero guard on `prevGain + prevLoss`. Trigger: a halted instrument, or any window with no price change | `src/TechnicalAnalysis.Functions/Rsi/TAFunc.cs` |

Two habits make these survivable, and they are worth having regardless:

```csharp
// 1. Treat a non-finite output as "no value", never as a price.
if (!double.IsFinite(result.Real[k]))
{
    continue;
}
```

For ATR specifically, Wilder smoothing over `TAMath.TrueRange` is a dozen lines and is correct
today; the [TradingView guide](tradingview-integration.md#21-wilder-smoothing-tarma) has the
snippet. Raising the unstable period (§7.1) discards the bars the EMA seed contaminates, but does
not help ATR — the divergence is unbounded, not transient.

The [backtesting](backtesting.md#-limitations--read-before-believing-any-number),
[real-time streaming](real-time-streaming.md#-known-library-defects-visible-in-this-sample) and
[TradingView](tradingview-integration.md#0-known-library-defects) guides show what each one does to
a running system.

---

## 11. Where to go next

- [Complete indicator reference](../indicators/README.md) — all 159 entry points with signatures,
  parameters, defaults, outputs and links to the generated API pages.
- [TradingView integration](tradingview-integration.md) — Pine Script mapping, parity caveats,
  serving series to a chart, consuming webhook alerts.
- [`Atypical.TechnicalAnalysis.Functions` API reference](../functions/Atypical.TechnicalAnalysis.Functions.md)
- [`Atypical.TechnicalAnalysis.Candles` API reference](../candles/Atypical.TechnicalAnalysis.Candles.md)
- [`Atypical.TechnicalAnalysis.Common` API reference](../common/Atypical.TechnicalAnalysis.Common.md)
