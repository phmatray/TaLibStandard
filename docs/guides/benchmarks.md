# ⚡ Performance benchmarks

TaLibStandard ships a BenchmarkDotNet suite at
[`benchmarks/TechnicalAnalysis.Benchmarks`](../../benchmarks/TechnicalAnalysis.Benchmarks). It exists to
answer four questions with numbers instead of intuition:

1. How long does an indicator take, and how does that scale with series length?
2. What does the ergonomic `TAMath` API cost compared with the allocation-free `TAFunc` API?
3. What does the generic-math candlestick design cost on `float` and `decimal` versus `double`?
4. How does the managed port compare with the original TA-Lib C library?

Only the fourth needs anything installed. The other three run on a clean clone, offline, against
deterministic synthetic data.

> **Results policy.** This page publishes only measurements that were actually taken, each labelled with
> the machine, the OS, the .NET version and the exact command that produced it. Everything else is a
> command you can run yourself. See [Measured results](#-measured-results) and
> [What has *not* been measured](#what-has-not-been-measured).

---

## 📝 Table of contents

<!-- TOC -->
* [⚡ Performance benchmarks](#-performance-benchmarks)
  * [📝 Table of contents](#-table-of-contents)
  * [🏁 Quick start](#-quick-start)
  * [🔬 What is measured](#-what-is-measured)
    * [The two API paths](#the-two-api-paths)
    * [The suites](#the-suites)
    * [The synthetic data](#the-synthetic-data)
  * [▶️ Running the suite](#-running-the-suite)
    * [Everything](#everything)
    * [One category](#one-category)
    * [One filter](#one-filter)
    * [Switch reference](#switch-reference)
    * [Correctness gate: `--selfcheck`](#correctness-gate---selfcheck)
  * [🔌 Enabling the native TA-Lib C comparison](#-enabling-the-native-ta-lib-c-comparison)
    * [Install the native library](#install-the-native-library)
    * [How discovery works](#how-discovery-works)
    * [Correctness before speed](#correctness-before-speed)
  * [📖 Reading BenchmarkDotNet output](#-reading-benchmarkdotnet-output)
    * [The columns](#the-columns)
    * [Exported files](#exported-files)
  * [📊 Measured results](#-measured-results)
    * [SMA — `TAFunc` versus `TAMath`](#sma--tafunc-versus-tamath)
    * [RSI — `TAFunc` versus `TAMath`](#rsi--tafunc-versus-tamath)
    * [What these two tables do and do not say](#what-these-two-tables-do-and-do-not-say)
    * [What has *not* been measured](#what-has-not-been-measured)
  * [⚠️ Methodology caveats](#-methodology-caveats)
<!-- TOC -->

---

## 🏁 Quick start

From the repository root:

```shell
# list every benchmark without running anything
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- --list flat

# prove every benchmark computes something valid (fast, not a measurement)
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- --selfcheck

# one real measurement, roughly 40 seconds
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --filter "*OverlapStudiesBenchmarks.Sma*" --job Short
```

`-c Release` is not optional. BenchmarkDotNet refuses to run a Debug build, and it is right to.

The suite prints a banner before it does anything, naming the runtime, the OS, whether Server GC is on,
and whether the native TA-Lib C library was found. Keep that banner with any numbers you quote.

---

## 🔬 What is measured

There are **119 benchmark methods** in five always-runnable classes, each parameterised over three series
lengths (`1_000`, `10_000`, `100_000`) and each carrying `[MemoryDiagnoser]`. A sixth class,
`NativeComparisonBenchmarks`, adds 16 more but is offered only when the native library is present.

### The two API paths

Every indicator in the three indicator suites appears **twice**, and the suffix is the whole point:

| Suffix | API | Output buffers | What the number means |
|--------|-----|----------------|-----------------------|
| `_TAFunc` | `TAFunc.Sma(…, ref outReal)` | Supplied by the caller, allocated in `[GlobalSetup]` | The algorithm alone. Allocates ~0 B per call. |
| `_TAMath` | `TAMath.Sma(…) -> SmaResult` | Allocated per call by the library | The algorithm **plus** one output array and one result record per call. |

That is not a fair fight and is not meant to be. It is a price tag: it tells you what the convenient API
costs when you call it in a loop, so you can decide whether the low-level API is worth the ceremony in
your hot path. For a once-per-bar recompute it never is.

### The suites

| Class | Benchmarks | Category tag | Contents |
|-------|-----------:|--------------|----------|
| `OverlapStudiesBenchmarks` | 22 | `OverlapStudies` | Sma, Ema, Wma, Dema, Tema, Trima, Kama, T3, BollingerBands, MidPoint, Sar |
| `MomentumBenchmarks` | 24 | `Momentum` | Rsi, Macd, Stoch, StochRsi, Adx, Cci, Mfi, WillR, Ppo, Roc, UltOsc, Aroon |
| `VolatilityVolumeBenchmarks` | 20 | `VolatilityVolume` | Atr, Natr, TrueRange, Obv, Ad, AdOsc, StdDev, Variance, Correl, Beta |
| `CandlePatternBenchmarks` | 39 | `CandlePatterns` | 13 patterns × `double` / `float` / `decimal` |
| `PrecisionBenchmarks` | 14 | `Precision` | Sma, Ema, Rsi, Macd, BollingerBands, Atr, Correl on `double` versus `float` |
| `NativeComparisonBenchmarks` | 16 | `NativeComparison` | Managed versus C for Sma, Ema, Rsi, Macd, Bbands, Atr, Adx, Stoch |

Cross-cutting tags let you slice differently: `TAFunc`, `TAMath`, `double`, `float`, `decimal`,
`Managed`, `Native`. Every name is a constant in
[`Benchmarks/BenchmarkCategories.cs`](../../benchmarks/TechnicalAnalysis.Benchmarks/Benchmarks/BenchmarkCategories.cs),
so you never have to guess at spelling.

**What the precision suite actually shows.** `TAMath`'s `float[]` overloads widen their input into a
freshly allocated `double[]` and then call the same `double` kernel; outputs are always `double[]`. So
`*_Float` measures *the widening copy plus the identical algorithm* — it is a cost comparison, not an
accuracy comparison, and it should come out slower, not faster. The candlestick suite is different:
`TACandle` is generic over `IFloatingPoint<T>`, so `Doji_Decimal` really does run decimal arithmetic
through the same source.

### The synthetic data

Generated by
[`Data/MarketDataGenerator.cs`](../../benchmarks/TechnicalAnalysis.Benchmarks/Data/MarketDataGenerator.cs)
with a fixed default seed of **20240217**, using a discretised geometric Brownian motion: 8% annual
drift, 25% annual volatility, `dt = 1/252`. Opens carry an overnight gap, highs and lows get independent
exponential wicks, volume is log-normal and correlated with `|return|`. A second instrument, correlated
at ρ = 0.65, feeds `Correl` and `Beta`.

Two details matter for interpreting results:

* Prices are rounded to **4 decimals at generation**, so the `decimal[]` projection is an exact
  representation of the `double[]` one. Only the `float[]` projection loses information. Precision
  comparisons are therefore pure cost comparisons, with no accuracy confound.
* Random numbers come from an in-project xoshiro256\*\* seeded through SplitMix64, not `System.Random`,
  because the BCL does not guarantee seed-to-sequence stability across runtime versions. Same seed, same
  series, forever.

Generation happens only inside `[GlobalSetup]`, never inside a measured method, and results are cached
per `(length, seed)`.

---

## ▶️ Running the suite

### Everything

```shell
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- --filter "*"
```

**Budget for this.** 119 methods × 3 lengths with the default job is on the order of an hour on a fast
laptop. Prefer a category or a filter, and add `--job Short` when you want a quick read rather than a
publishable one.

### One category

```shell
# one suite
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --anyCategories VolatilityVolume

# only the allocation-free kernels, across every suite
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --anyCategories TAFunc

# the decimal candlestick benchmarks only — both tags must match
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --allCategories CandlePatterns decimal
```

Verified selection sizes (from `--list flat` with the same filters, so no measurement time was spent):

| Filter | Benchmarks selected |
|--------|--------------------:|
| *(none)* | 119 |
| `--anyCategories VolatilityVolume` | 20 |
| `--anyCategories TAFunc` | 33 |
| `--allCategories CandlePatterns decimal` | 13 |

### One filter

`--filter` takes glob patterns against the fully-qualified benchmark name, and accepts several at once:

```shell
# every RSI benchmark anywhere in the suite
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- --filter "*Rsi*"

# one class
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --filter "*PrecisionBenchmarks*"

# two specific pairs, quickly
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --filter "*OverlapStudiesBenchmarks.Sma*" "*MomentumBenchmarks.Rsi*" --job Short
```

### Switch reference

Everything BenchmarkDotNet understands is passed straight through. The ones that matter here:

| Switch | Effect |
|--------|--------|
| `--list flat` | Print benchmark names and exit. Free; use it to check a filter before spending an hour. |
| `--filter <glob>…` | Select by fully-qualified name. Several globs allowed. |
| `--anyCategories <tag>…` | Select benchmarks carrying **any** of the tags. |
| `--allCategories <tag>…` | Select benchmarks carrying **all** of the tags. |
| `--job Short` | 3 warmup + 3 target iterations. A real but low-confidence measurement. |
| `--job Dry` | One cold iteration. **Not a measurement** — a smoke test. Allocation numbers are still meaningful. |
| `--runtimes …` | Run the same code on several runtimes. |
| `--artifacts <path>` | Redirect exported reports. |
| `--selfcheck` | Project-specific. Correctness gate, described below. |

The shared config declares **no job** on purpose, so `--job Short` adds exactly one job rather than
multiplying an already-declared one. See
[`Configuration/TaLibBenchmarkConfig.cs`](../../benchmarks/TechnicalAnalysis.Benchmarks/Configuration/TaLibBenchmarkConfig.cs).

### Correctness gate: `--selfcheck`

```shell
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- --selfcheck
```

This invokes every benchmark once at `Length = 1000`, outside BenchmarkDotNet, and asserts that each one
reports `RetCode.Success` (or a successful `IndicatorResult` with `NBElement > 0`, or native code `0`).

It exists because a benchmark that quietly measures a validation-failure path is worse than no benchmark
at all: the fast path out of an argument check is *very* fast. **It is a correctness gate, not a
measurement**, and it prints no timings.

Real output on this machine:

```text
Self check: invoking every benchmark once with Length = 1000.

  CandlePatternBenchmarks          OK
  MomentumBenchmarks               OK
  OverlapStudiesBenchmarks         OK
  PrecisionBenchmarks              OK
  VolatilityVolumeBenchmarks       OK

Self check passed: 119 benchmark method(s) all reported success.
```

---

## 🔌 Enabling the native TA-Lib C comparison

`NativeComparisonBenchmarks` runs the managed `TAFunc` path head to head against the original TA-Lib C
library through P/Invoke. The suite has **no** native dependency: when the library is missing, the class
is removed from the type set handed to `BenchmarkSwitcher`, so `--list` and `--filter "*"` never offer
something that cannot work, and every other suite runs normally.

If it is missing, the banner says so loudly:

```text
 NATIVE TA-LIB: NOT AVAILABLE - the managed-versus-C comparison is DISABLED.
 Probe result : probed 19 candidate name(s)/path(s), none loaded.
 Everything else runs normally; the suite has no native dependency by design.
```

### Install the native library

| Platform | Command |
|----------|---------|
| macOS (Homebrew) | `brew install ta-lib` — installs `/opt/homebrew/lib/libta-lib.dylib` on Apple silicon, `/usr/local/lib/…` on Intel |
| Debian / Ubuntu | `sudo apt-get install libta-lib0 libta-lib-dev` when packaged, otherwise build from source |
| Linux (source) | `./configure --prefix=/usr && make && sudo make install`, then `sudo ldconfig` |
| Windows | Put `ta-lib.dll` (or `ta_libc_cdr.dll`) on `PATH` or next to the built executable |
| Any OS | `export TALIB_NATIVE_LIBRARY=/full/path/to/libta-lib.dylib` |

### How discovery works

[`Interop/NativeTaLib.cs`](../../benchmarks/TechnicalAnalysis.Benchmarks/Interop/NativeTaLib.cs) registers
a `DllImportResolver` in a static constructor and probes, in order:

1. `TALIB_NATIVE_LIBRARY`, if set — this always wins, and is the escape hatch for an unusual install.
2. Eight bare names, letting the platform loader apply its own `lib` prefix and `.so` / `.dylib` / `.dll`
   suffix rules: `ta-lib`, `ta_lib`, `libta-lib`, `libta_lib`, `ta_libc`, `ta_libc_cdr`,
   `libta-lib.so.0`, `libta_lib.so.0`.
3. Eleven absolute paths covering the default Homebrew, MacPorts and autotools prefixes.

Nineteen candidates in total — which is the `probed 19 candidate name(s)/path(s)` in the banner above. A
candidate that loads but exports no `TA_Initialize` is rejected rather than trusted. `TA_Initialize` runs
once on first use and `TA_Shutdown` is registered on `ProcessExit`. Every probe failure is caught:
`IsAvailable`, `ResolvedName` and `Diagnostics` never throw.

Only ten C entry points are bound — `TA_Initialize`, `TA_Shutdown`, `TA_SMA`, `TA_EMA`, `TA_RSI`,
`TA_MACD`, `TA_BBANDS`, `TA_ATR`, `TA_ADX`, `TA_STOCH` — because those are the signatures the author was
confident about from upstream `ta_func.h`. Binding a signature wrongly does not fail to compile; it
corrupts memory at runtime, so the conservative choice is deliberate.

### Correctness before speed

`[GlobalSetup]` runs both implementations once and asserts they agree — identical `outBegIdx` and
`outNBElement`, and every value within a `1e-9` relative tolerance, with explicit NaN handling — **before
anything is timed**. All three MACD series, all three Bollinger series and both Stochastic series are
checked. A "faster" result therefore cannot come from computing the wrong thing.

Once you have the library:

```shell
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks -c Release -- \
  --anyCategories NativeComparison --job Short
```

The class is grouped by indicator with the managed method as the baseline, so the `Ratio` column reads as
native ÷ managed.

---

## 📖 Reading BenchmarkDotNet output

### The columns

| Column | Meaning | How to use it |
|--------|---------|---------------|
| **Mean** | Arithmetic mean of all measured iterations, per operation. | The headline number. Compare within one table, never across machines. |
| **Error** | Half of the 99.9% confidence interval of the mean. | If two means differ by less than the sum of their errors, you have not measured a difference. |
| **StdDev** | Standard deviation of the iteration times. | Large relative to the mean means a noisy machine: close things, re-run. |
| **Op/s** | Operations per second, i.e. `1 / Mean`. | Easier to reason about for throughput sizing ("how many series per second?"). |
| **Ratio** | Mean of the ratio distribution against the `Baseline = true` method of the same *logical group*. Rendered as *trend* text: `1.48x slower`. | **Only `NativeComparisonBenchmarks` emits it**, and there it is a genuine like-for-like comparison. See the note below. |
| **RatioSD** | Standard deviation of that ratio distribution. | A ratio with a large SD is not a finding. |
| **Gen0 / Gen1 / Gen2** | GC collections per 1000 operations. | A non-zero `Gen2` on a per-call path is a design smell, not a rounding error. |
| **Allocated** | Managed bytes allocated per single operation. | Stable, machine-independent, and the most portable thing in the table. |
| **Alloc Ratio** | Allocation against the baseline of the same logical group. | Reads as `202.60x more`, and is exact — allocation is not sampled. Same scope as `Ratio`. |

`Length` is the `[Params]` value: the number of bars fed to the indicator.

> **Why most suites have no `Ratio` column.** BenchmarkDotNet's default logical group is (Job, Params), so
> a single `[Benchmark(Baseline = true)]` in a class ratios *every* method in that class against that one
> method. In `OverlapStudiesBenchmarks` that would print `Ema_TAMath … 3.73x slower` — against `Sma_TAFunc`,
> not against `Ema_TAFunc`, which is the comparison the row looks like it is making. (The real
> `TAMath`/`TAFunc` delta for EMA at `Length = 1000` was `0.82x` in the same run.) Grouping per indicator
> does not fix it either: `BenchmarkLogicalGroupRule.ByCategory` keys on the *whole* category set, and the
> `TAFunc` / `TAMath` categories put the two halves of each pair in different groups.
>
> Rather than publish a column that is wrong for 21 rows out of 22, those suites declare no baseline at
> all. **Read the two rows of the same indicator and divide `Mean` yourself.**
> `NativeComparisonBenchmarks` is the one suite whose categories are per-indicator and mutually exclusive,
> so it carries `[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]` and eight baselines, and its
> `Ratio` column means exactly what it says.

Expect timings to scale roughly linearly in `Length` for the simple kernels and allocation to scale
exactly linearly: an output array is `8 × Length` bytes, plus a fixed record header.

### Exported files

Two exporters are configured, and both land in `BenchmarkDotNet.Artifacts/results` **next to the built
executable** (not in the repository root — the artifacts path is anchored to `AppContext.BaseDirectory`
precisely so a run from the repo root does not litter it):

* `*-report-github.md` — GitHub-flavoured markdown, paste-ready into an issue or a release note.
* `*-report-full.json` — machine readable, for tracking regressions between releases.

Override with `--artifacts <path>`.

---

## 📊 Measured results

Everything in this section was produced by a command that was actually run. Nothing is extrapolated.

**Environment** (printed by BenchmarkDotNet itself):

```text
BenchmarkDotNet v0.15.8, macOS Tahoe 26.5.2 (25F84) [Darwin 25.5.0]
Apple M1 Max, 1 CPU, 10 logical and 10 physical cores
.NET SDK 10.0.301
  [Host]   : .NET 10.0.9 (10.0.9, 10.0.926.27113), Arm64 RyuJIT armv8.0-a
  ShortRun : .NET 10.0.9 (10.0.9, 10.0.926.27113), Arm64 RyuJIT armv8.0-a

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3
```

**Exact command:**

```shell
dotnet run --project benchmarks/TechnicalAnalysis.Benchmarks/TechnicalAnalysis.Benchmarks.csproj \
  -c Release --no-build -- \
  --filter "*OverlapStudiesBenchmarks.Sma*" "*MomentumBenchmarks.Rsi*" --job Short
```

Total wall time: 94.37 s for 12 benchmarks.

> **One column has since been removed.** These tables are the verbatim output of that run, taken while
> `OverlapStudiesBenchmarks` and `MomentumBenchmarks` still declared a class-wide
> `[Benchmark(Baseline = true)]`. Because the filter reduced each class to a single indicator, the
> `Ratio` / `RatioSD` / `Alloc Ratio` columns below *are* `TAMath` against `TAFunc` for the same
> indicator, which is what they appear to be — the timings and the ratios are all real. Re-run the same
> command today and you will get the same rows without those three columns, because the misleading
> baselines were removed (see the note in [Reading BenchmarkDotNet output](#the-columns)). The ratio is
> then simply `Mean(TAMath) / Mean(TAFunc)` from the two adjacent rows.

### SMA — `TAFunc` versus `TAMath`

| Method     | Categories            | Length | Mean       | Error      | StdDev    | Op/s      | Ratio        | RatioSD | Gen0   | Gen1   | Gen2   | Allocated | Alloc Ratio     |
|----------- |---------------------- |------- |-----------:|-----------:|----------:|----------:|-------------:|--------:|-------:|-------:|-------:|----------:|----------------:|
| Sma_TAFunc | TAFunc,OverlapStudies | 1000   |   2.432 us |  0.2696 us | 0.0148 us | 411,113.3 |     baseline |         |      - |      - |      - |      40 B |                 |
| Sma_TAMath | TAMath,OverlapStudies | 1000   |   2.956 us |  0.1263 us | 0.0069 us | 338,278.3 | 1.22x slower |   0.01x | 0.1068 |      - |      - |    8104 B |    202.60x more |
| Sma_TAFunc | TAFunc,OverlapStudies | 10000  |  25.529 us |  4.8932 us | 0.2682 us |  39,170.7 |     baseline |         |      - |      - |      - |      40 B |                 |
| Sma_TAMath | TAMath,OverlapStudies | 10000  |  27.660 us |  7.3039 us | 0.4004 us |  36,153.1 | 1.08x slower |   0.02x | 1.0681 |      - |      - |   80104 B |  2,002.60x more |
| Sma_TAFunc | TAFunc,OverlapStudies | 100000 | 251.581 us |  4.0547 us | 0.2223 us |   3,974.9 |     baseline |         |      - |      - |      - |      40 B |                 |
| Sma_TAMath | TAMath,OverlapStudies | 100000 | 372.630 us | 60.8805 us | 3.3371 us |   2,683.6 | 1.48x slower |   0.01x | 8.7891 | 8.7891 | 8.7891 |  800118 B | 20,002.95x more |

### RSI — `TAFunc` versus `TAMath`

| Method     | Categories      | Length | Mean       | Error       | StdDev     | Op/s      | Ratio        | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio     |
|----------- |---------------- |------- |-----------:|------------:|-----------:|----------:|-------------:|--------:|--------:|--------:|--------:|----------:|----------------:|
| Rsi_TAFunc | TAFunc,Momentum | 1000   |   4.835 us |   0.6293 us |  0.0345 us | 206,810.4 |     baseline |         |       - |       - |       - |      40 B |                 |
| Rsi_TAMath | TAMath,Momentum | 1000   |   5.433 us |   0.7055 us |  0.0387 us | 184,059.2 | 1.12x slower |   0.01x |  0.1068 |       - |       - |    8104 B |    202.60x more |
| Rsi_TAFunc | TAFunc,Momentum | 10000  |  49.459 us |  10.2223 us |  0.5603 us |  20,218.8 |     baseline |         |       - |       - |       - |      40 B |                 |
| Rsi_TAMath | TAMath,Momentum | 10000  |  51.421 us |   4.6344 us |  0.2540 us |  19,447.5 | 1.04x slower |   0.01x |  1.0376 |       - |       - |   80104 B |  2,002.60x more |
| Rsi_TAFunc | TAFunc,Momentum | 100000 | 516.477 us |  58.3711 us |  3.1995 us |   1,936.2 |     baseline |         |       - |       - |       - |      40 B |                 |
| Rsi_TAMath | TAMath,Momentum | 100000 | 639.357 us | 207.9159 us | 11.3966 us |   1,564.1 | 1.24x slower |   0.02x | 11.7188 | 11.7188 | 11.7188 |  800157 B | 20,003.92x more |

### What these two tables do and do not say

**Do say:**

* Both kernels are linear in series length. SMA goes 2.4 → 25.5 → 251.6 µs across 1k → 10k → 100k;
  RSI goes 4.8 → 49.5 → 516.5 µs. Nothing quadratic is hiding in there.
* `TAFunc` with caller-supplied buffers allocates a flat **40 B per call at every length** — a constant,
  with nothing that scales with the data. This is the number to design around if you recompute in a
  tight loop.
* `TAMath` allocates `8 × Length` plus roughly 100–160 B per call, which is exactly one output
  `double[]` plus a record header. At `Length = 100000` that is ~800 KB per call — a Large Object Heap
  allocation, which is why the `Gen2` column is non-zero on those rows and zero everywhere else.
* On a per-call basis `TAMath` costs 4% to 48% more time here. At 100 000 bars the gap is widest,
  because that is where the 800 KB allocation and the LOH collection dominate.

**Do not say:**

* These are `--job Short` numbers: 3 warmup and 3 target iterations. They are genuine measurements, but
  the confidence intervals are wide — look at RSI at 100 000, where `Error` is 208 µs on a 639 µs mean.
  Do not quote the 1.04x / 1.08x ratios as findings; they are inside the noise. The 1.48x at
  `Sma`/100 000 sits well outside it, and the allocation columns are exact at every row.
* They say nothing about any indicator that was not run. Do not interpolate Ema or Macd from Sma.
* They say nothing about your machine. An M1 Max with Server GC on is not a container with one vCPU.

### What has *not* been measured

Stated plainly so nobody mistakes silence for a result:

* **Managed versus native TA-Lib C.** The C library is not installed on the machine used for this page,
  so `NativeComparisonBenchmarks` and its equivalence assertions have been compiled and reasoned about
  but never executed. **There is no managed-versus-native number anywhere in this repository, and none
  should be invented.** Install the library, run
  `-- --anyCategories NativeComparison --job Short`, and publish what you get.
* **Candlestick `double` / `float` / `decimal`.** Verified to run end to end via `--selfcheck`, not timed
  with a real job.
* **The precision suite.** Same: verified, not timed.
* **A full `--job Default` run of anything.** Every number above is `--job Short`.

If you produce a proper `--job Default` run, the GitHub-markdown exporter output is already in the right
shape to paste in here, under a heading naming your hardware, OS, .NET version and command.

---

## ⚠️ Methodology caveats

Read these before quoting anything from this suite.

1. **`--job Dry` numbers are not measurements.** One cold iteration, dominated by JIT. Use Dry to prove a
   benchmark runs; never to compare two of them. The *allocation* column of a Dry run is still valid.
2. **`--job Short` numbers are low-confidence measurements.** Three iterations catch an order of
   magnitude, not a 5% regression. Publish `--job Default` for anything that matters.
3. **Compare ratios, not absolutes.** Absolute microseconds are a property of the machine that produced
   them; a ratio of two means from the *same table* travels, the `Mean` column does not. Outside
   `NativeComparisonBenchmarks` there is no `Ratio` column to read — compute the ratio from the two rows of
   the same indicator, and never across indicators.
4. **The machine matters more than you think.** Thermal throttling, a browser in the background, a
   virtualised CPU, and battery-versus-mains all move these numbers by tens of percent. Re-run a
   surprising result before believing it.
5. **Server GC is on** in this project's configuration, and the banner prints it. Allocation-heavy
   benchmarks look better under Server GC than they will under Workstation GC in a small container.
6. **Synthetic data is not market data.** It is smooth, gap-free, always well-formed, and never halts.
   Indicators with data-dependent branches — SAR, the candlestick recognisers — may behave differently on
   a real series with limit moves and stale prints.
7. **P/Invoke overhead is inside the native numbers.** The native comparison runs in the same process, so
   the marshalling cost is charged to the native side. That is realistic for how you would actually call
   it, and it is not the same as measuring the C function in isolation.
8. **`--selfcheck` is a gate, not a benchmark.** It never produces a timing and must never be quoted as
   one.
9. **First run pays for a build.** Add `--no-build` (after building once) if you are timing the harness
   rather than the code.

---

## Related

* [`benchmarks/TechnicalAnalysis.Benchmarks/README.md`](../../benchmarks/TechnicalAnalysis.Benchmarks/README.md)
  — the project-local README, with the file-by-file layout.
* [Getting started](getting-started.md) — `RetCode`, `BegIdx`/`NBElement`, and the alignment rule the
  benchmarks assume you already understand.
* [Indicator catalog](../indicators/README.md) — every entry point, its signature and its outputs.
