# 📄 TaLibStandard Documentation

Everything written about TaLibStandard lives here. There are three kinds of page, and it helps to know
which one you want:

| I want to… | Go to |
|------------|-------|
| Learn the library from scratch | [Guides](#-guides) — hand-written, worked examples, prose |
| Find an indicator and its signature | [Indicator catalog](#-indicator-catalog) — generated from the source, one table per category |
| Look up one type or member in detail | [API reference](#-api-reference) — generated from the XML docs |
| Never do `BegIdx` / `NBElement` arithmetic by hand | [Fluent API](guides/fluent-api.md) — `PriceSeries` in, bar-indexed `IndicatorSeries` out |

---

## 📚 Guides

Hand-written and kept in `docs/guides/`. Start at the top.

| Guide | What it covers |
|-------|----------------|
| [**Getting started**](guides/getting-started.md) | Installation, your first indicator, and the three things that trip everyone up: `RetCode`, `BegIdx`/`NBElement` output alignment, and the `double` / `float` / `decimal` story. Includes a hand-checkable worked SMA example, a lookback table, `TACore.Globals`, the low-level `TAFunc` API and thirteen common pitfalls. **Read this one first.** |
| [**Fluent API**](guides/fluent-api.md) | The bar-indexed layer over `TAMath`: `PriceSeries` factories, `IndicatorSeries` and its warm-up-is-`null` contract, crossings, `AsOf`, the nine shipped indicators with a worked example each, the `Align` escape hatch to the other 89, and error handling. |
| [**Indicator catalog**](indicators/README.md) | Every public entry point in one place — see below. |
| [**Real-time streaming**](guides/real-time-streaming.md) | Turning a tick feed into bars and indicators: architecture, both transports (SignalR hub and raw WebSocket), the message contracts, warm-up and null semantics, and production notes on Redis scale-out, backpressure, cancellation and when to abandon window-recompute for incremental state. |
| [**Backtesting**](guides/backtesting.md) | The engine model and its execution timeline, the structurally enforced no-look-ahead guarantee, the commission/slippage cost model, every performance metric with its formula and annualisation assumption, a complete worked `IStrategy`, CSV input, and an honest limitations section. |
| [**TradingView integration**](guides/tradingview-integration.md) | Mapping ~50 Pine `ta.*` functions to `TAMath`/`TACandle`, the three library defects that make some outputs impossible to reconcile at any tolerance, nine parity caveats (Wilder smoothing, EMA seeding, repainting, session alignment, dividend adjustment, …), UDF datafeed and Lightweight Charts wiring, and alert-webhook security. |
| [**Benchmarks**](guides/benchmarks.md) | What the BenchmarkDotNet suite measures and why, how to run one category or one filter, how to enable the native TA-Lib C comparison per platform, how to read every output column, the measured results, and the methodology caveats. |

---

## 📋 Indicator catalog

[**docs/indicators/README.md**](indicators/README.md) lists every public entry point grouped into ten
categories, with its full signature, parameters and defaults, output property names, a one-line
description and a link to its generated API page.

It is **generated** by [`tools/generate-indicator-catalog.py`](../tools/generate-indicator-catalog.py)
directly from `src/`. Do not hand-edit it. To regenerate:

```shell
python3 tools/generate-indicator-catalog.py

# or, to fail if the committed file is stale (suitable for CI)
python3 tools/generate-indicator-catalog.py --check
```

The generator exits non-zero — with a named list — if an indicator exists in the source but is missing
from its category table, or vice versa, so a newly added indicator cannot silently escape the catalog.

---

## 🔎 API reference

Generated from the XML documentation comments by
[Doraku/DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation) every time the solution is
built. One page per public type and member.

### …on GitHub (recommended)

- **Functions**: [Atypical.TechnicalAnalysis.Functions](https://github.com/phmatray/TaLibStandard/blob/main/docs/functions/Atypical.TechnicalAnalysis.Functions.md)
- **Candles**: [Atypical.TechnicalAnalysis.Candles](https://github.com/phmatray/TaLibStandard/blob/main/docs/candles/Atypical.TechnicalAnalysis.Candles.md)
- **Common**: [Atypical.TechnicalAnalysis.Common](https://github.com/phmatray/TaLibStandard/blob/main/docs/common/Atypical.TechnicalAnalysis.Common.md)

### …in your IDE

- **Functions**: [./functions/Atypical.TechnicalAnalysis.Functions.md](./functions/Atypical.TechnicalAnalysis.Functions.md)
- **Candles**: [./candles/Atypical.TechnicalAnalysis.Candles.md](./candles/Atypical.TechnicalAnalysis.Candles.md)
- **Common**: [./common/Atypical.TechnicalAnalysis.Common.md](./common/Atypical.TechnicalAnalysis.Common.md)

There is also a flat [function list](./functions.md) if you only need the names.

---

## 🧪 Runnable code

The guides above describe these; the code itself is in the repository.

| Project | Guide |
|---------|-------|
| [`samples/TechnicalAnalysis.Samples.RealTime`](../samples/TechnicalAnalysis.Samples.RealTime) + [`.Client`](../samples/TechnicalAnalysis.Samples.RealTime.Client) | [Real-time streaming](guides/real-time-streaming.md) |
| [`samples/TechnicalAnalysis.Samples.Backtesting`](../samples/TechnicalAnalysis.Samples.Backtesting) | [Backtesting](guides/backtesting.md) |
| [`benchmarks/TechnicalAnalysis.Benchmarks`](../benchmarks/TechnicalAnalysis.Benchmarks) | [Benchmarks](guides/benchmarks.md) |
| [`Demo.BlazorWasm`](../Demo.BlazorWasm) | — charts indicators in the browser |

---

## 🤝 Contributing to the docs

* **API reference** (`docs/functions/`, `docs/candles/`, `docs/common/`, `docs/links`): edit the XML
  summaries in the source and build the solution. These folders are regenerated on every build; hand
  edits are lost.
* **Indicator catalog** (`docs/indicators/README.md`): edit the `CATEGORIES` table in
  `tools/generate-indicator-catalog.py`, then re-run the script.
* **Guides** (`docs/guides/*.md`): ordinary hand-written Markdown — edit directly.

All summaries are written in English. If you would like to help translate the documentation, please open
an issue to discuss it.
