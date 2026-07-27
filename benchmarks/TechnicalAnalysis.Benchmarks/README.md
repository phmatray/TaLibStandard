# TaLibStandard performance benchmarks

A [BenchmarkDotNet](https://benchmarkdotnet.org) suite that measures the TaLibStandard indicator kernels and,
optionally, compares them head to head against the original TA-Lib C library.

The suite is **fully offline and deterministic**. It never touches the network, never reads a market data provider
and needs no API key: all inputs come from a seeded synthetic OHLCV generator, so a run on your machine and a run on
CI see byte-identical data.

Native TA-Lib is **entirely optional**. When it is not installed the suite prints a banner saying so and simply
drops the comparison benchmarks from the runnable set.

---

## Quick start

```bash
# from the repository root
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --list flat   # see what exists
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --selfcheck   # correctness gate, instant
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks                  # interactive menu
```

> Always run in `Release`. BenchmarkDotNet refuses to produce numbers from a `Debug` build, and rightly so.

### Run everything

```bash
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --filter '*'
```

This is a *long* run: 119 benchmark methods times three series lengths. Budget an hour or more. For day-to-day work,
filter.

### Run one category

Categories are `OverlapStudies`, `Momentum`, `VolatilityVolume`, `CandlePatterns`, `Precision`, `NativeComparison`,
plus the cross-cutting tags `TAFunc`, `TAMath`, `double`, `float` and `decimal`.

```bash
# one suite
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --anyCategories Momentum

# only the allocation-free kernels, across every suite
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --anyCategories TAFunc

# the decimal candlestick benchmarks only (both tags must match)
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --allCategories CandlePatterns decimal
```

### Run one filter

`--filter` takes glob patterns against the fully qualified method name.

```bash
# every RSI benchmark anywhere in the suite
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --filter '*Rsi*'

# one class
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --filter '*OverlapStudiesBenchmarks*'

# one method, one length, quickly
dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- \
    --filter '*OverlapStudiesBenchmarks.Sma*' --job Short
```

### Useful switches

Every standard BenchmarkDotNet argument is passed through.

| Switch | Effect |
| --- | --- |
| `--list flat` / `--list tree` | Enumerate benchmarks without running them |
| `--filter <glob>` | Select benchmarks by fully qualified name |
| `--anyCategories` / `--allCategories` | Select by `[BenchmarkCategory]` |
| `--job Dry` | One cold-start iteration. Smoke test only — **the timings are meaningless** |
| `--job Short` | Fewer iterations, roughly 5x faster, wider error bars |
| `--job Default` | The standard statistically rigorous job |
| `--runtimes net10.0` | Pick the target runtime explicitly |
| `--exporters github json` | Choose exporters at the command line |
| `--selfcheck` | Project-specific: invoke every benchmark once and assert it succeeds. No timing |

Results are written to `BenchmarkDotNet.Artifacts/results/` next to the executable, as GitHub-flavoured markdown
(paste straight into an issue or release note) and as full JSON (machine readable, for tracking regressions between
releases).

---

## What the suite measures

### The two API paths, benchmarked separately

Nearly every indicator appears **twice**, and the distinction is the single most important thing to understand when
reading the output.

| Suffix | API | Output buffers | What the number means |
| --- | --- | --- | --- |
| `_TAFunc` | `TAFunc.Sma(..., ref outReal)` | Allocated once in `[GlobalSetup]`, i.e. **outside** the measured method | Pure algorithm cost. Allocation shows as ~0 B (a few bytes of boxing noise from the benchmark harness itself) |
| `_TAMath` | `TAMath.Sma(...) -> SmaResult` | Allocated **inside** the call, one array per output series plus one result record | Algorithm cost **plus** the price of the ergonomic API |

The delta between the two is exactly what the convenience of `TAMath` costs, and the `Allocated` column quantifies
it: an `SmaResult` over 100 000 bars allocates ~800 KB per call while the `TAFunc` path allocates nothing.

Some kernels allocate internally regardless of which entry point you use (`Sar`, `Natr`, `StochRsi`, `Ppo`, `Macd`
and the other composites build scratch arrays). The memory columns make that visible rather than hiding it.

### The suites

| Class | Indicators | Notes |
| --- | --- | --- |
| `OverlapStudiesBenchmarks` | Sma, Ema, Wma, Dema, Tema, Trima, Kama, T3, BollingerBands, MidPoint, Sar | Both API paths |
| `MomentumBenchmarks` | Rsi, Macd, Stoch, StochRsi, Adx, Cci, Mfi, WillR, Ppo, Roc, UltOsc, Aroon | Both API paths |
| `VolatilityVolumeBenchmarks` | Atr, Natr, TrueRange, Obv, Ad, AdOsc, StdDev, Variance, Correl, Beta | Both API paths. Correl and Beta consume a second, correlated instrument |
| `CandlePatternBenchmarks` | Doji, Engulfing, Hammer, HangingMan, Harami, Marubozu, SpinningTop, ShootingStar, 3WhiteSoldiers, 3BlackCrows, Piercing, HighWave, MorningStar | Each over `double`, `float` **and** `decimal`, to price the generic-math design |
| `PrecisionBenchmarks` | Sma, Ema, Rsi, Macd, BollingerBands, Atr, Correl | `double` vs `float` on the ergonomic API |
| `NativeComparisonBenchmarks` | Sma, Ema, Rsi, Macd, BBands, Atr, Adx, Stoch | Managed vs TA-Lib C. Only runs when the native library is present |

Every class is a `[MemoryDiagnoser]` and parameterised over series length `1 000`, `10 000` and `100 000`.

### What the precision benchmarks actually show

`TAFunc` is written for `double` only. The `float` overloads on `TAMath` widen their inputs into freshly allocated
`double[]` arrays and then call the same kernel. A `float` benchmark therefore measures *the double kernel plus one
widening pass and one array allocation per input series*. It can never be faster than its `double` counterpart, and
`PrecisionBenchmarks` exists to put a number on the overhead rather than leave it to intuition.

The candlestick suite is different: `TACandle` is generic over `T : IFloatingPoint<T>`, so the JIT emits a dedicated
body per value type. `double` and `float` compile to hardware floating point; `decimal` falls back to the software
128-bit implementation. The three variants of each pattern price that choice directly.

### The synthetic data

`Data/MarketDataGenerator.cs` builds a discretised geometric Brownian motion,
`C[i] = C[i-1] * exp((mu - sigma^2/2) * dt + sigma * sqrt(dt) * Z)`, with `mu = 8%`, `sigma = 25%` and a trading-day
time step. On top of the close path it adds an overnight gap for the open and independent exponential wicks for the
high and low, so pattern recognisers see realistic bodies and shadows instead of degenerate bars. Volume is
log-normal and grows with the absolute return of the bar. A second, correlated instrument (rho = 0.65) feeds Correl
and Beta.

Randomness comes from `DeterministicRandom` (xoshiro256\*\* seeded through SplitMix64), implemented in this project
rather than taken from `System.Random`, because the BCL does not guarantee that a seed produces the same sequence
across runtime versions. The default seed is `20240217`; change it only if every published number is regenerated at
the same time.

Every price is rounded to four decimal places at generation time, which makes the `decimal` projection an **exact**
representation of the `double` projection. Only the `float` projection loses information. A precision comparison is
therefore a pure cost comparison, not a "different data" comparison.

---

## Enabling the native TA-Lib comparison

`NativeComparisonBenchmarks` runs the managed kernels against the original TA-Lib C library through P/Invoke. It is
skipped automatically when the library is missing, so nothing below is required to use the rest of the suite.

### Install the native library

**macOS**

```bash
brew install ta-lib
# installs /opt/homebrew/lib/libta-lib.dylib on Apple silicon, /usr/local/lib/... on Intel
```

**Linux (Debian / Ubuntu)**

```bash
# from the distribution, when packaged
sudo apt-get install libta-lib0 libta-lib-dev

# or from source
curl -L -O https://github.com/TA-Lib/ta-lib/releases/download/v0.6.4/ta-lib-0.6.4-src.tar.gz
tar xzf ta-lib-0.6.4-src.tar.gz && cd ta-lib-0.6.4
./configure --prefix=/usr/local && make && sudo make install && sudo ldconfig
```

**Windows**

Install the official MSI, or download the prebuilt `ta-lib` archive, then make sure `ta-lib.dll` (older builds:
`ta_libc_cdr.dll`) is on `PATH` or sits next to the benchmark executable.

### How discovery works

`Interop/NativeTaLib.cs` registers a `DllImportResolver` and probes, in order:

1. the path or name in the `TALIB_NATIVE_LIBRARY` environment variable, if set;
2. the plain names `ta-lib`, `ta_lib`, `libta-lib`, `libta_lib`, `ta_libc`, `ta_libc_cdr`, `libta-lib.so.0`,
   `libta_lib.so.0`, letting the platform loader apply its own `lib` prefix and `.dylib` / `.so` / `.dll` suffix
   conventions;
3. a list of absolute paths covering the Homebrew, MacPorts and autotools defaults.

A candidate that loads but exports no `TA_Initialize` is rejected as "not TA-Lib". `TA_Initialize` is called once on
the first successful load and `TA_Shutdown` is registered on process exit. **The probe never throws**: on any
failure `NativeTaLib.IsAvailable` is simply `false` and `NativeTaLib.Diagnostics` explains why.

If discovery fails for a library you know is installed:

```bash
TALIB_NATIVE_LIBRARY=/opt/homebrew/lib/libta-lib.dylib \
    dotnet run -c Release --project benchmarks/TechnicalAnalysis.Benchmarks -- --anyCategories NativeComparison
```

### Correctness before speed

A "faster" result that computes the wrong thing is worse than no result. `NativeComparisonBenchmarks.Setup()` runs
both implementations once and asserts, via `Interop/NativeEquivalence.cs`, that:

* `outBegIdx` matches exactly (a shifted series would silently misalign every signal in time);
* `outNBElement` matches exactly;
* every produced value agrees within a relative tolerance of `1e-9`.

A mismatch throws in `[GlobalSetup]`, which BenchmarkDotNet reports as a failed benchmark. No timing is ever
published for a pair that disagrees.

Both sides use caller-supplied output buffers, so the comparison is algorithm against algorithm with no allocation
noise on either side. The managed side deliberately uses `TAFunc`, not `TAMath`, for that reason. The managed
implementation is the baseline of each group, so the `Ratio` column reads directly as *native time / managed time*.

### Which C signatures are bound

Bound and verified against the upstream `ta_func.h` / `ta_libc.h`: `TA_Initialize`, `TA_Shutdown`, `TA_SMA`,
`TA_EMA`, `TA_RSI`, `TA_MACD`, `TA_BBANDS`, `TA_ATR`, `TA_ADX`, `TA_STOCH`. All of them share the same shape —
`startIdx`, `endIdx`, the `const double[]` inputs, the `optIn*` parameters, `int *outBegIdx`, `int *outNBElement`,
then the `double[]` output buffers — return the C enum `TA_RetCode` (marshalled as `int`, `TA_SUCCESS == 0`) and use
the cdecl calling convention. The `TA_MAType` enum has the same ordinal order as `TechnicalAnalysis.Common.MAType`
(SMA, EMA, WMA, DEMA, TEMA, TRIMA, KAMA, MAMA, T3), so a plain cast is correct.

Nothing else is bound. A wrong P/Invoke signature corrupts the stack and can produce plausible-looking but wrong
numbers, so the rule for this file is: bind only what is certain.

---

## Reading the output

```
| Method     | Categories            | Length | Mean       | Error    | Op/s   | Allocated |
|----------- |---------------------- |------- |-----------:|---------:|-------:|----------:|
| Sma_TAFunc | TAFunc,OverlapStudies | 100000 |   xxx.x us |   x.x us | xx,xxx |       0 B |
| Sma_TAMath | TAMath,OverlapStudies | 100000 |   xxx.x us |   x.x us | xx,xxx |  800,104 B|
```

* **Length** — the `[Params]` value: number of bars fed to the indicator.
* **Mean** — arithmetic mean per operation. One operation is one full pass over the whole series, not one bar.
  Divide by `Length` for a per-bar figure.
* **Error** — half of the 99.9% confidence interval. If two means differ by less than the sum of their errors, treat
  them as indistinguishable.
* **StdDev / Median** — appear when the distribution is noisy; a large `StdDev` relative to `Mean` means the
  measurement is unstable and should not be quoted.
* **Op/s** — full-series operations per second, the reciprocal of `Mean`.
* **Ratio / Alloc Ratio** — versus the baseline of the same logical group. **Only `NativeComparisonBenchmarks`
  declares baselines**, where `_Managed` is the baseline of each per-indicator group and the ratio reads as
  *native ÷ managed*. The indicator suites declare none, because BenchmarkDotNet's default logical group is
  (Job, Params): one baseline would ratio every row in the class against a single method, so `Ema_TAMath` would
  be compared against `Sma_TAFunc` rather than against `Ema_TAFunc`. Compare the two rows of the same indicator
  by hand instead.
* **Allocated** — managed bytes per operation, inclusive. This is the column that separates the two API paths.

Scaling is the other thing worth reading. A well-behaved O(n) kernel should show `Mean` growing roughly 10x when
`Length` grows 10x. A super-linear jump between `10 000` and `100 000` usually means the working set stopped fitting
in cache, not that the algorithm changed.

---

## Caveats

Read these before quoting a number anywhere.

* **`--job Dry` numbers are not measurements.** Dry runs a single cold-start iteration with no warmup, so it is
  dominated by JIT compilation and first-touch page faults. It exists to prove the plumbing works. Use `--job Short`
  at minimum and `--job Default` for anything you publish.
* **JIT warmup matters.** BenchmarkDotNet's default job includes a pilot phase, warmup iterations and overhead
  subtraction precisely because the first few calls into a freshly JIT-compiled method are not representative. Do not
  reduce the iteration counts to make a run finish faster and then quote the result.
* **ServerGC is on** (`<ServerGarbageCollection>true</ServerGarbageCollection>` in the csproj) with concurrent GC.
  That is a deliberate choice matching a server-side analytics workload, and it changes the allocation-heavy
  `_TAMath` numbers relative to a workstation-GC client. If your application runs workstation GC, re-run with
  `--runtimes` and an appropriate job, or expect the ergonomic-path figures to differ.
* **Machine variance is real.** Absolute timings depend on CPU model, core count, memory bandwidth, thermal state,
  power profile and what else is running. Laptops on battery throttle. CI runners are shared and noisy. Only compare
  numbers produced on the same machine in the same session; treat cross-machine comparisons as qualitative.
* **Compare ratios, not absolutes, across time.** When tracking regressions between releases, the stable signal is
  the ratio between two benchmarks measured together, not the microseconds.
* **The data is synthetic.** It is realistic enough to exercise the branches of every kernel and every candlestick
  recogniser, but real market data has different volatility clustering and gap statistics. Branch-heavy indicators
  such as the candlestick patterns may behave slightly differently on real series.
* **Native comparison is single-threaded, in-process P/Invoke.** The measured native time includes the managed to
  native transition and the array pinning, which is exactly what a .NET consumer of the C library would pay, but it
  is not the cost you would measure from a C program.
* **`--selfcheck` is a correctness gate, not a benchmark.** It invokes each method once at `Length = 1 000` and
  asserts a successful `RetCode`; it deliberately reports no timing at all.

---

## Project layout

```
benchmarks/TechnicalAnalysis.Benchmarks/
├── Benchmarks/
│   ├── BenchmarkCategories.cs         category name constants
│   ├── MarketDataBenchmarkBase.cs     [Params] length, generated data, pre-allocated output buffers
│   ├── OverlapStudiesBenchmarks.cs
│   ├── MomentumBenchmarks.cs
│   ├── VolatilityVolumeBenchmarks.cs
│   ├── CandlePatternBenchmarks.cs
│   ├── PrecisionBenchmarks.cs
│   └── NativeComparisonBenchmarks.cs  managed vs TA-Lib C, with equivalence assertion in [GlobalSetup]
├── Configuration/
│   └── TaLibBenchmarkConfig.cs        exporters, columns, ordering, summary style
├── Data/
│   ├── DeterministicRandom.cs         xoshiro256** + SplitMix64 + Box-Muller
│   ├── MarketDataGenerator.cs         seeded GBM OHLCV generator
│   ├── MarketSeries.cs                double / float / decimal projections + correlated reference series
│   └── OhlcvSeries.cs
├── Diagnostics/
│   └── BenchmarkSelfCheck.cs          --selfcheck correctness gate
├── Interop/
│   ├── NativeTaLib.cs                 opt-in P/Invoke bridge, never throws
│   └── NativeEquivalence.cs           managed vs native tolerance assertions
└── Program.cs                         banner, native detection, BenchmarkSwitcher
```
