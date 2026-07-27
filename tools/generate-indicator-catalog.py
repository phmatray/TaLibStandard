#!/usr/bin/env python3
"""Generate docs/indicators/README.md, the complete TaLibStandard indicator catalog.

WHAT IT DOES
    Parses every ``src/TechnicalAnalysis.Functions/*/TAMath.cs`` and
    ``src/TechnicalAnalysis.Candles/*/TACandle.cs`` file, extracts every ``public static``
    method (name, generic arity, full parameter list including default values, return type
    and the XML ``<summary>`` text), resolves the named output properties of each
    ``*Result`` record, groups the entry points into the canonical TA-Lib categories using
    the CATEGORIES table below, verifies that the DefaultDocumentation page for each entry
    point really exists under ``docs/functions`` / ``docs/candles``, and writes
    ``docs/indicators/README.md``.

HOW TO RE-RUN IT
    From anywhere (the script locates the repository root relative to its own path):

        python3 tools/generate-indicator-catalog.py

    Useful flags:
        --check     do not write; exit 1 if docs/indicators/README.md is out of date
        --output P  write to P instead of docs/indicators/README.md
        --quiet     suppress the progress report on stdout

    Requires python3 only - no third-party imports.

WHEN IT FAILS
    The script exits non-zero and names the offending entry points when a discovered
    indicator is missing from the CATEGORIES mapping table, or when the same indicator is
    listed in two categories, or when a category references an indicator that no longer
    exists in the source tree. That is deliberate: adding a new indicator to the library
    forces a conscious edit here, so the catalog can never silently go stale.
"""

from __future__ import annotations

import argparse
import os
import re
import sys
from dataclasses import dataclass, field

# ---------------------------------------------------------------------------
# Category mapping table - the single source of truth for how entry points are
# grouped. Names are the C# method names on TAMath / TACandle, NOT the TA-Lib C
# names. Keep the categories in canonical TA-Lib order.
# ---------------------------------------------------------------------------

# ---------------------------------------------------------------------------
# Known defects. Entry points whose output is currently wrong, keyed by the C#
# method name on TAMath. Each row of the catalog for one of these names carries
# a marker pointing at the "Known defects" section, so a reader who arrives at a
# single row from a search engine still sees the warning.
#
# The values are the short form shown in the section's table. Keep them factual
# and measured; remove an entry the moment the underlying defect is fixed.
# ---------------------------------------------------------------------------

DEFECT_ATR = "atr-diverges"
DEFECT_EMA = "ema-seed"
DEFECT_RSI = "rsi-nan"

KNOWN_DEFECTS: dict[str, str] = {
    "Atr": DEFECT_ATR,
    "Ema": DEFECT_EMA,
    "Macd": DEFECT_EMA,
    "MacdExt": DEFECT_EMA,
    "MacdFix": DEFECT_EMA,
    "Dema": DEFECT_EMA,
    "Tema": DEFECT_EMA,
    "T3": DEFECT_EMA,
    "Apo": DEFECT_EMA,
    "Ppo": DEFECT_EMA,
    "Trix": DEFECT_EMA,
    "Rsi": DEFECT_RSI,
}

DEFECT_ROWS: list[tuple[str, str, str, str]] = [
    (
        DEFECT_ATR,
        "`Atr` never divides its running average",
        "`Atr`",
        "The main output loop divides the emitted value by `period` but never the accumulator, so the running "
        "average is multiplied by `period - 1` on every bar. Measured on a series whose true range is exactly "
        "`2.0` every bar, `Atr(..., 14)` returns `2, 2, 26.142857, 340, 4420.142857, 57462, 747006.142857, "
        "9711080, ...`; on a 1500-bar series it reaches `+inf` by bar 300. Only the first two outputs are "
        "usable. `Natr` is **not** affected. Workaround: Wilder-smooth `TrueRange` yourself. "
        "Source: `src/TechnicalAnalysis.Functions/Atr/TAFunc.cs`",
    ),
    (
        DEFECT_EMA,
        "`TA_INT_EMA` seeds itself low",
        "`Ema`, `Macd`, `MacdExt`, `MacdFix`, `Dema`, `Tema`, `T3`, `Apo`, `Ppo`, `Trix`",
        "The seed loop sums `period - 1` inputs and divides by `period` (upstream TA-Lib sums `period` of "
        "them), and the loop that follows applies one extra smoothing step. `Ema` over a constant series of "
        "`100` with `timePeriod: 20` returns `95.476190` instead of `100`. The error decays with the smoothing "
        "factor, so it distorts the bars just after warm-up rather than the steady state; raising "
        "`TACore.Globals.UnstablePeriod[FuncUnstId.Ema]` discards them. "
        "Source: `src/TechnicalAnalysis.Functions/TAFunc.cs`, `TA_INT_EMA`",
    ),
    (
        DEFECT_RSI,
        "`Rsi` returns `NaN` on a perfectly flat series",
        "`Rsi`",
        "There is no zero guard on `prevGain + prevLoss`, so a window with no price change divides by zero. "
        "The call still reports `RetCode.Success` with a non-zero `NBElement`, and every element is `NaN`. "
        "Trigger: a halted instrument, or a synthetic constant series. Guard consumers with "
        "`double.IsFinite`. Source: `src/TechnicalAnalysis.Functions/Rsi/TAFunc.cs`",
    ),
]

CATEGORIES: list[tuple[str, str, list[str]]] = [
    (
        "Overlap Studies",
        "Trend-following overlays plotted on the same scale as price.",
        [
            "BollingerBands",  # TA-Lib BBANDS
            "Dema",
            "Ema",
            "HtTrendline",  # TA-Lib HT_TRENDLINE
            "Kama",
            "Mama",
            "MovingAverage",  # TA-Lib MA
            "MovingAverageVariablePeriod",  # TA-Lib MAVP
            "MidPoint",
            "MidPrice",
            "Sar",
            "SarExt",
            "Sma",
            "T3",
            "Tema",
            "Trima",
            "Wma",
            "ZigZag",  # TaLibStandard extension, no TA-Lib C equivalent
        ],
    ),
    (
        "Momentum Indicators",
        "Oscillators and directional-movement measures derived from rate of change.",
        [
            "Adx",
            "Adxr",
            "Apo",
            "Aroon",
            "AroonOsc",
            "Bop",
            "Cci",
            "Cmo",
            "Dx",
            "Macd",
            "MacdExt",
            "MacdFix",
            "Mfi",
            "MinusDI",  # TA-Lib MINUS_DI
            "MinusDM",  # TA-Lib MINUS_DM
            "Mom",
            "PlusDI",  # TA-Lib PLUS_DI
            "PlusDM",  # TA-Lib PLUS_DM
            "Ppo",
            "Roc",
            "RocP",
            "RocR",
            "RocR100",
            "Rsi",
            "Stoch",
            "StochF",
            "StochRsi",
            "Trix",
            "UltOsc",
            "WillR",
        ],
    ),
    (
        "Volume Indicators",
        "Indicators that combine price with traded volume.",
        [
            "Ad",  # TA-Lib AD (Chaikin A/D Line)
            "AdOsc",  # TA-Lib ADOSC (Chaikin A/D Oscillator)
            "Obv",
        ],
    ),
    (
        "Volatility Indicators",
        "True-range based measures of dispersion.",
        [
            "Atr",
            "Natr",
            "TrueRange",  # TA-Lib TRANGE
        ],
    ),
    (
        "Price Transform",
        "Single-bar arithmetic combinations of open/high/low/close.",
        [
            "AvgPrice",
            "MedPrice",
            "TypPrice",
            "WclPrice",
        ],
    ),
    (
        "Cycle Indicators",
        "Hilbert Transform cycle analysis (Ehlers).",
        [
            "HtDcPeriod",  # TA-Lib HT_DCPERIOD
            "HtDcPhase",  # TA-Lib HT_DCPHASE
            "HtPhasor",  # TA-Lib HT_PHASOR
            "HtSine",  # TA-Lib HT_SINE
            "HtTrendMode",  # TA-Lib HT_TRENDMODE
        ],
    ),
    (
        "Pattern Recognition",
        "Candlestick pattern detection. Every entry point is generic over `T : IFloatingPoint<T>`.",
        [],  # populated automatically from src/TechnicalAnalysis.Candles - see CANDLE_CATEGORY
    ),
    (
        "Statistic Functions",
        "Regression and dispersion statistics over a rolling window.",
        [
            "Beta",
            "Correl",
            "LinearReg",
            "LinearRegAngle",  # TA-Lib LINEARREG_ANGLE
            "LinearRegIntercept",  # TA-Lib LINEARREG_INTERCEPT
            "LinearRegSlope",  # TA-Lib LINEARREG_SLOPE
            "StdDev",
            "Tsf",
            "Variance",  # TA-Lib VAR
        ],
    ),
    (
        "Math Transform",
        "Element-wise transcendental and rounding functions.",
        [
            "Acos",
            "Asin",
            "Atan",
            "Ceil",
            "Cos",
            "Cosh",
            "Exp",
            "Floor",
            "Ln",
            "Log10",
            "Sin",
            "Sinh",
            "Sqrt",
            "Tan",
            "Tanh",
        ],
    ),
    (
        "Math Operators",
        "Element-wise arithmetic and rolling min/max helpers.",
        [
            "Add",
            "Div",
            "Max",
            "MaxIndex",
            "Min",
            "MinIndex",
            "MinMax",
            "MinMaxIndex",
            "Mult",
            "Sub",
            "Sum",
        ],
    ),
]

# Every entry point discovered in src/TechnicalAnalysis.Candles belongs here.
CANDLE_CATEGORY = "Pattern Recognition"

# Parameters that describe the calculation range or the raw price/volume inputs. They are
# listed in the Signature column but excluded from the Parameters column, which is meant to
# show only the knobs a caller actually tunes.
INPUT_PARAMETER_NAMES = frozenset(
    {
        "startIdx",
        "endIdx",
        "real",
        "real0",
        "real1",
        "open",
        "high",
        "low",
        "close",
        "volume",
        "periods",
    }
)

# ---------------------------------------------------------------------------
# Source model
# ---------------------------------------------------------------------------


@dataclass
class Parameter:
    """A single C# parameter of a public static entry point."""

    type_name: str
    name: str
    default: str | None

    def declaration(self) -> str:
        text = f"{self.type_name} {self.name}"
        if self.default is not None:
            text += f" = {self.default}"
        return text


@dataclass
class Overload:
    """One `public static` method declaration."""

    name: str
    generic_arity: int
    return_type: str
    parameters: list[Parameter]
    summary: str

    @property
    def scalar_kind(self) -> str:
        """`double`, `float`, `generic` or `none`, based on the first array parameter."""
        for parameter in self.parameters:
            if parameter.type_name == "double[]":
                return "double"
            if parameter.type_name == "float[]":
                return "float"
            if parameter.type_name == "T[]":
                return "generic"
        return "none"

    def declaration(self, holder: str = "") -> str:
        params = ", ".join(parameter.declaration() for parameter in self.parameters)
        generics = "<T>" if self.generic_arity else ""
        qualifier = f"{holder}." if holder else ""
        return f"{self.return_type} {qualifier}{self.name}{generics}({params})"

    def parameter_type_list(self) -> str:
        return ",".join(parameter.type_name for parameter in self.parameters)


@dataclass
class EntryPoint:
    """All overloads that share one public method name."""

    name: str
    holder: str  # "TAMath" or "TACandle"
    source_folder: str
    overloads: list[Overload] = field(default_factory=list)
    outputs: list[str] = field(default_factory=list)
    summary_override: str = ""

    @property
    def primary(self) -> Overload:
        """The widest non-float overload - the one the docs describe."""
        candidates = [o for o in self.overloads if o.scalar_kind != "float"]
        if not candidates:
            candidates = list(self.overloads)
        return max(candidates, key=lambda o: len(o.parameters))

    @property
    def secondary(self) -> Overload | None:
        """A narrower non-float convenience overload, when one exists."""
        candidates = [
            o
            for o in self.overloads
            if o.scalar_kind != "float" and len(o.parameters) < len(self.primary.parameters)
        ]
        if not candidates:
            return None
        return max(candidates, key=lambda o: len(o.parameters))

    @property
    def has_float_overload(self) -> bool:
        return any(o.scalar_kind == "float" for o in self.overloads)

    @property
    def description(self) -> str:
        return self.primary.summary or self.summary_override


# ---------------------------------------------------------------------------
# Parsing
# ---------------------------------------------------------------------------

METHOD_RE = re.compile(
    r"^[ \t]*public\s+static\s+"
    r"(?P<return>[A-Za-z0-9_]+)\s+"
    r"(?P<name>[A-Za-z0-9_]+)"
    r"(?P<generics><[^()]*?>)?\s*"
    r"\(",
    re.MULTILINE,
)

SUMMARY_RE = re.compile(r"<summary>(.*?)</summary>", re.DOTALL)
SEE_CREF_RE = re.compile(r"<see\s+cref=\"[A-Za-z]:?([^\"]+)\"\s*/>")
XML_TAG_RE = re.compile(r"<[^>]+>")


def read_source(path: str) -> str:
    """Read a C# file, tolerating the UTF-8 BOM some files carry."""
    with open(path, encoding="utf-8-sig") as handle:
        return handle.read()


def collapse(text: str) -> str:
    return " ".join(text.split())


def clean_summary(raw: str) -> str:
    """Turn a raw XML doc <summary> body into a single line of plain prose."""
    text = "\n".join(line.strip().removeprefix("///").strip() for line in raw.splitlines())
    text = SEE_CREF_RE.sub(lambda m: m.group(1).split(".")[-1].replace("`1", ""), text)
    text = XML_TAG_RE.sub("", text)
    text = text.replace("&lt;", "<").replace("&gt;", ">").replace("&amp;", "&")
    return collapse(text)


def preceding_summary(text: str, method_start: int) -> str:
    """Collect the /// block immediately above `method_start` and return its <summary>."""
    lines = text[:method_start].splitlines()
    doc_lines: list[str] = []
    for line in reversed(lines):
        stripped = line.strip()
        if stripped.startswith("///"):
            doc_lines.append(stripped)
            continue
        if not stripped:
            continue
        break
    doc_lines.reverse()
    match = SUMMARY_RE.search("\n".join(doc_lines))
    return clean_summary(match.group(1)) if match else ""


def match_parenthesis(text: str, open_index: int) -> int:
    """Return the index of the ')' closing the '(' at `open_index`."""
    depth = 0
    index = open_index
    while index < len(text):
        char = text[index]
        if char == "(":
            depth += 1
        elif char == ")":
            depth -= 1
            if depth == 0:
                return index
        index += 1
    raise ValueError(f"unbalanced parentheses starting at offset {open_index}")


def split_parameters(raw: str) -> list[str]:
    """Split a parameter list on top-level commas (generic arguments may contain commas)."""
    parts: list[str] = []
    depth = 0
    current: list[str] = []
    for char in raw:
        if char in "<([":
            depth += 1
        elif char in ">)]":
            depth -= 1
        if char == "," and depth == 0:
            parts.append("".join(current))
            current = []
            continue
        current.append(char)
    if "".join(current).strip():
        parts.append("".join(current))
    return [collapse(part) for part in parts if collapse(part)]


def parse_parameter(raw: str) -> Parameter:
    default: str | None = None
    if "=" in raw:
        raw, _, default_text = raw.partition("=")
        raw = raw.strip()
        default = collapse(default_text)
    tokens = collapse(raw).split(" ")
    name = tokens[-1]
    type_name = " ".join(tokens[:-1])
    return Parameter(type_name=type_name, name=name, default=default)


def parse_overloads(path: str) -> list[Overload]:
    text = read_source(path)
    overloads: list[Overload] = []
    for match in METHOD_RE.finditer(text):
        open_index = match.end() - 1
        close_index = match_parenthesis(text, open_index)
        raw_params = text[open_index + 1 : close_index]
        generics = match.group("generics") or ""
        overloads.append(
            Overload(
                name=match.group("name"),
                generic_arity=generics.count(",") + 1 if generics else 0,
                return_type=match.group("return"),
                parameters=[parse_parameter(part) for part in split_parameters(raw_params)],
                summary=preceding_summary(text, match.start()),
            )
        )
    return overloads


RECORD_BASE_RE = re.compile(r"public\s+record\s+[A-Za-z0-9_]+\s*:\s*([A-Za-z0-9_]+)")
EXPRESSION_PROPERTY_RE = re.compile(
    r"public\s+(?:double|int)\[\]\s+([A-Za-z0-9_]+)\s*=>\s*Real([0-9])\s*;"
)
AUTO_PROPERTY_RE = re.compile(r"public\s+(?:double|int)\[\]\s+([A-Za-z0-9_]+)\s*\{\s*get;")

IMPLICIT_OUTPUTS = {
    "SingleOutputResult": ["Real"],
    "CandleIndicatorResult": ["Integers"],
}


def parse_outputs(result_path: str) -> list[str]:
    """Return the public array properties a *Result record exposes, in output-slot order."""
    text = read_source(result_path)
    slotted = sorted(
        ((int(slot), name) for name, slot in EXPRESSION_PROPERTY_RE.findall(text)),
    )
    outputs = [name for _, name in slotted]
    for name in AUTO_PROPERTY_RE.findall(text):
        if name not in outputs:
            outputs.append(name)
    if outputs:
        return outputs
    base_match = RECORD_BASE_RE.search(text)
    base = base_match.group(1) if base_match else ""
    return list(IMPLICIT_OUTPUTS.get(base, []))


def parse_class_summary(path: str) -> str:
    """Return the <summary> of the first public class/record declared in `path`."""
    text = read_source(path)
    match = SUMMARY_RE.search(text)
    return clean_summary(match.group(1)) if match else ""


# ---------------------------------------------------------------------------
# Discovery
# ---------------------------------------------------------------------------


def indicator_folders(container: str) -> list[str]:
    return sorted(
        entry
        for entry in os.listdir(container)
        if os.path.isdir(os.path.join(container, entry)) and entry not in {"bin", "obj", "Internal"}
    )


def discover_functions(repo_root: str) -> list[EntryPoint]:
    container = os.path.join(repo_root, "src", "TechnicalAnalysis.Functions")
    entry_points: list[EntryPoint] = []
    for folder in indicator_folders(container):
        math_path = os.path.join(container, folder, "TAMath.cs")
        if not os.path.isfile(math_path):
            continue
        overloads = parse_overloads(math_path)
        if not overloads:
            continue
        names = {overload.name for overload in overloads}
        if len(names) != 1:
            raise SystemExit(f"{math_path}: expected one method name, found {sorted(names)}")
        entry = EntryPoint(name=names.pop(), holder="TAMath", source_folder=folder, overloads=overloads)
        result_path = os.path.join(container, folder, f"{entry.primary.return_type}.cs")
        if os.path.isfile(result_path):
            entry.outputs = parse_outputs(result_path)
        entry_points.append(entry)
    return entry_points


def discover_candles(repo_root: str) -> list[EntryPoint]:
    container = os.path.join(repo_root, "src", "TechnicalAnalysis.Candles")
    entry_points: list[EntryPoint] = []
    for folder in indicator_folders(container):
        candle_path = os.path.join(container, folder, "TACandle.cs")
        if not os.path.isfile(candle_path):
            continue
        overloads = parse_overloads(candle_path)
        if not overloads:
            continue
        names = {overload.name for overload in overloads}
        if len(names) != 1:
            raise SystemExit(f"{candle_path}: expected one method name, found {sorted(names)}")
        entry = EntryPoint(name=names.pop(), holder="TACandle", source_folder=folder, overloads=overloads)
        entry.outputs = ["Integers"]
        class_path = os.path.join(container, folder, f"{folder}.cs")
        if os.path.isfile(class_path):
            entry.summary_override = parse_class_summary(class_path)
        entry_points.append(entry)
    return entry_points


# ---------------------------------------------------------------------------
# Documentation links
# ---------------------------------------------------------------------------


def url_encode(path: str) -> str:
    """Percent-encode the characters that break inline Markdown link targets."""
    return path.replace("(", "%28").replace(")", "%29").replace(" ", "%20")


def resolve_doc_link(repo_root: str, entry: EntryPoint) -> tuple[str, str] | None:
    """Return (relative_link, label) for the generated page, or None when there is none.

    DefaultDocumentation names a page `Holder.Method.md` when the method has a single
    overload group and `Holder.Method_T_(paramTypes).md` when it must disambiguate.
    Both shapes are probed and the file must exist on disk before a link is emitted.
    """
    folder = "functions" if entry.holder == "TAMath" else "candles"
    docs_dir = os.path.join(repo_root, "docs", folder)
    generics = "_T_" if entry.primary.generic_arity else ""
    candidates = [
        f"{entry.holder}.{entry.name}.md",
        f"{entry.holder}.{entry.name}{generics}({entry.primary.parameter_type_list()}).md",
    ]
    for candidate in candidates:
        if os.path.isfile(os.path.join(docs_dir, candidate)):
            return f"../{folder}/{url_encode(candidate)}", f"{entry.holder}.{entry.name}"
    return None


# ---------------------------------------------------------------------------
# Validation
# ---------------------------------------------------------------------------


def validate_mapping(entry_points: list[EntryPoint]) -> dict[str, list[EntryPoint]]:
    """Bucket entry points by category, exiting non-zero on any mapping mismatch."""
    by_name = {entry.name: entry for entry in entry_points}

    mapped: dict[str, str] = {}
    duplicates: list[str] = []
    for category, _, names in CATEGORIES:
        for name in names:
            if name in mapped:
                duplicates.append(f"{name} (in '{mapped[name]}' and '{category}')")
            mapped[name] = category
    for entry in entry_points:
        if entry.holder == "TACandle":
            if entry.name in mapped:
                duplicates.append(f"{entry.name} (candlestick entry point also listed in '{mapped[entry.name]}')")
            mapped[entry.name] = CANDLE_CATEGORY

    unmapped = sorted(name for name in by_name if name not in mapped)
    unknown = sorted(name for name in mapped if name not in by_name)

    problems: list[str] = []
    if unmapped:
        problems.append(
            "The following indicators were discovered in the source tree but are missing from "
            f"the CATEGORIES table in {os.path.basename(__file__)}:\n  - " + "\n  - ".join(unmapped)
        )
    if unknown:
        problems.append(
            "The following indicators are listed in the CATEGORIES table but no longer exist in "
            "the source tree:\n  - " + "\n  - ".join(unknown)
        )
    if duplicates:
        problems.append("The following indicators are mapped to more than one category:\n  - " + "\n  - ".join(sorted(set(duplicates))))
    if problems:
        sys.stderr.write("ERROR: indicator catalog mapping is out of date.\n\n")
        sys.stderr.write("\n\n".join(problems))
        sys.stderr.write("\n\nFix the CATEGORIES table, then re-run this script.\n")
        raise SystemExit(1)

    buckets: dict[str, list[EntryPoint]] = {category: [] for category, _, _ in CATEGORIES}
    for entry in sorted(entry_points, key=lambda e: e.name):
        buckets[mapped[entry.name]].append(entry)
    return buckets


# ---------------------------------------------------------------------------
# Rendering
# ---------------------------------------------------------------------------


def escape_cell(text: str) -> str:
    return text.replace("|", "\\|")


def code(text: str) -> str:
    return f"`{escape_cell(text)}`" if text else ""


def tuning_parameters(overload: Overload) -> str:
    tunables = [p for p in overload.parameters if p.name not in INPUT_PARAMETER_NAMES]
    if not tunables:
        return "_none_"
    return "<br>".join(code(p.declaration()) for p in tunables)


def describe(entry: EntryPoint) -> str:
    """Render the Description cell, prefixed with a defect marker when one applies."""
    text = escape_cell(entry.description) or "_no summary in source_"
    if entry.name not in KNOWN_DEFECTS:
        return text

    return f"[**KNOWN DEFECT**](#known-defects) - {text}"


def signature_cell(entry: EntryPoint) -> str:
    lines = [code(entry.primary.declaration(entry.holder))]
    secondary = entry.secondary
    if secondary is not None:
        lines.append(code(secondary.declaration(entry.holder)))
    return "<br>".join(lines)


def render(repo_root: str, entry_points: list[EntryPoint], buckets: dict[str, list[EntryPoint]]) -> tuple[str, list[str]]:
    functions = [e for e in entry_points if e.holder == "TAMath"]
    candles = [e for e in entry_points if e.holder == "TACandle"]
    function_overloads = sum(len(e.overloads) for e in functions)
    candle_overloads = sum(len(e.overloads) for e in candles)
    float_overloads = sum(1 for e in entry_points for o in e.overloads if o.scalar_kind == "float")

    missing_links: list[str] = []
    out: list[str] = []
    add = out.append

    add("# TaLibStandard Indicator Reference")
    add("")
    add(
        "Complete, machine-generated catalog of every public entry point in TaLibStandard. "
        "**Do not edit this file by hand** - regenerate it with:"
    )
    add("")
    add("```bash")
    add("python3 tools/generate-indicator-catalog.py")
    add("```")
    add("")
    add(
        "The generator parses `src/TechnicalAnalysis.Functions/*/TAMath.cs` and "
        "`src/TechnicalAnalysis.Candles/*/TACandle.cs` directly, so this page cannot drift from the "
        "source. It fails loudly if a newly added indicator is not classified in its mapping table."
    )
    add("")

    add("## What is counted here")
    add("")
    add(f"| Surface | Entry points | Public `static` overloads |")
    add("| --- | ---: | ---: |")
    add(f"| `TAMath` (technical indicators, `TechnicalAnalysis.Functions`) | {len(functions)} | {function_overloads} |")
    add(f"| `TACandle` (candlestick patterns, `TechnicalAnalysis.Candles`) | {len(candles)} | {candle_overloads} |")
    add(f"| **Total** | **{len(entry_points)}** | **{function_overloads + candle_overloads}** |")
    add("")
    add(
        f"An *entry point* is a distinct public method name. There are **{len(functions)} indicator entry points** "
        f"and **{len(candles)} candlestick pattern entry points**, i.e. **{len(entry_points)} distinct methods**. "
        f"Counting every callable `public static` overload (the `double[]` and `float[]` pairs, plus the "
        f"default-argument convenience overloads) gives **{function_overloads + candle_overloads}** methods, "
        f"of which **{float_overloads}** are `float[]` overloads. When you see \"200+ indicators\" advertised for "
        "TA-Lib ports, that figure is the overload count, not the entry-point count - the honest numbers for "
        f"TaLibStandard are {len(functions)} / {len(candles)} / {function_overloads + candle_overloads}."
    )
    add("")

    add("### Per category")
    add("")
    add("| Category | Entry points |")
    add("| --- | ---: |")
    for category, _, _ in CATEGORIES:
        add(f"| [{category}](#{slug(category)}) | {len(buckets[category])} |")
    add(f"| **Total** | **{len(entry_points)}** |")
    add("")

    add("### Overloads, precision and generic math")
    add("")
    add(
        "- **`double[]` and `float[]` overloads.** Almost every `TAMath` method is declared twice: once "
        "taking `double[]` inputs and once taking `float[]`. The `float[]` overload widens its inputs to "
        "`double[]` and calls the `double[]` implementation, so it costs one extra allocation and copy per "
        "input array and returns exactly the same `*Result` type. All computation is performed in `double`, "
        "and every output array is `double[]` (or `int[]`) regardless of the input type."
    )
    add(
        "- **Convenience overloads.** A handful of entry points expose a shorter overload that hard-codes the "
        "TA-Lib default instead of declaring an optional parameter. Both shapes are listed in the *Signature* "
        "column below."
    )
    add(
        "- **Generic-math candlesticks.** `TACandle` methods are generic: "
        "`TACandle.CdlDoji<T>(int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)` where "
        "`T : IFloatingPoint<T>`. That constraint is satisfied by `double`, `float`, `decimal`, `Half` and "
        "`System.Runtime.InteropServices.NFloat`, so candlestick detection runs directly on `decimal[]` price "
        "arrays with no conversion. All candlestick entry points return "
        "`CandleIndicatorResult`, whose `int[] Integers` array holds `0` (no pattern), `+100` (bullish) or "
        "`-100` (bearish)."
    )
    add("")

    add("### Reading the result objects")
    add("")
    add(
        "Every result record derives from `TechnicalAnalysis.Common.IndicatorResult` and carries three "
        "metadata members: `RetCode RetCode`, `int BegIdx` and `int NBElement` (note the capital `B`). "
        "**Output element `k` corresponds to input bar `BegIdx + k`, for `k` in `[0, NBElement)`.** Elements "
        "at index `>= NBElement` are meaningless zeros. See "
        "[the getting-started guide](../guides/getting-started.md) for a fully worked alignment example."
    )
    add("")
    add(
        "The *Outputs* column names the properties that expose the result arrays. `Real` comes from "
        "`SingleOutputResult`; multi-output records expose named properties (`RealUpperBand`, `SlowK`, "
        "`MacdSignal`, ...) that project the protected `Real0`/`Real1`/`Real2` slots in output order."
    )
    add("")

    add("## Known defects")
    add("")
    add(
        "Three entry points below currently return wrong numbers. They fail quietly - `RetCode.Success`, a "
        "plausible `NBElement`, and a value you would chart - so they are called out here and marked in the "
        "tables that follow. Everything not listed here was checked against the same inputs and behaves."
    )
    add("")
    add("| Defect | Affected entry points | Detail |")
    add("| --- | --- | --- |")
    for _, title, affected, detail in DEFECT_ROWS:
        add(f"| **{title}** | {affected} | {detail} |")
    add("")
    add(
        "See [Getting started](../guides/getting-started.md#10-known-library-defects) for the two habits that "
        "make these survivable, [Backtesting]"
        "(../guides/backtesting.md#-limitations--read-before-believing-any-number) and "
        "[Real-time streaming](../guides/real-time-streaming.md#-known-library-defects-visible-in-this-sample) "
        "for what they do to a running system, and "
        "[TradingView integration](../guides/tradingview-integration.md#0-known-library-defects) for what they "
        "mean when you are reconciling against a chart."
    )
    add("")

    for category, blurb, _ in CATEGORIES:
        entries = buckets[category]
        add(f"## {category}")
        add("")
        add(f"{blurb} **{len(entries)} entry points.**")
        add("")
        add("| Indicator | Signature | Parameters (with defaults) | Outputs | Description | Docs |")
        add("| --- | --- | --- | --- | --- | --- |")
        for entry in entries:
            link = resolve_doc_link(repo_root, entry)
            if link is None:
                missing_links.append(f"{entry.holder}.{entry.name}")
                docs_cell = "_not generated_"
            else:
                target, label = link
                docs_cell = f"[{escape_cell(label)}]({target})"
            add(
                "| {name} | {signature} | {params} | {outputs} | {description} | {docs} |".format(
                    name=code(entry.name),
                    signature=signature_cell(entry),
                    params=tuning_parameters(entry.primary),
                    outputs=", ".join(code(o) for o in entry.outputs) or "_none_",
                    description=describe(entry),
                    docs=docs_cell,
                )
            )
        add("")

    add("## See also")
    add("")
    add("- [Getting started](../guides/getting-started.md) - installation, `RetCode`/`BegIdx`/`NBElement`, alignment, pitfalls.")
    add("- [TradingView integration](../guides/tradingview-integration.md) - Pine Script mapping, parity caveats, UDF feed, webhooks.")
    add("- [`Atypical.TechnicalAnalysis.Functions` API reference](../functions/Atypical.TechnicalAnalysis.Functions.md)")
    add("- [`Atypical.TechnicalAnalysis.Candles` API reference](../candles/Atypical.TechnicalAnalysis.Candles.md)")
    add("- [`Atypical.TechnicalAnalysis.Common` API reference](../common/Atypical.TechnicalAnalysis.Common.md)")
    add("")

    return "\n".join(out), missing_links


def slug(heading: str) -> str:
    return re.sub(r"[^a-z0-9 -]", "", heading.lower()).replace(" ", "-")


# ---------------------------------------------------------------------------
# Entry point
# ---------------------------------------------------------------------------


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--check", action="store_true", help="verify the catalog is up to date without writing")
    parser.add_argument("--output", default=None, help="override the output path")
    parser.add_argument("--quiet", action="store_true", help="suppress the progress report")
    args = parser.parse_args(argv)

    repo_root = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
    output_path = args.output or os.path.join(repo_root, "docs", "indicators", "README.md")

    entry_points = discover_functions(repo_root) + discover_candles(repo_root)
    buckets = validate_mapping(entry_points)
    content, missing_links = render(repo_root, entry_points, buckets)

    if not content.endswith("\n"):
        content += "\n"

    if args.check:
        try:
            with open(output_path, encoding="utf-8", newline="") as handle:
                current = handle.read()
        except FileNotFoundError:
            sys.stderr.write(f"ERROR: {output_path} does not exist. Run this script without --check.\n")
            return 1
        if current != content:
            sys.stderr.write(f"ERROR: {output_path} is out of date. Re-run this script without --check.\n")
            return 1
        if not args.quiet:
            sys.stdout.write(f"{os.path.relpath(output_path, repo_root)} is up to date.\n")
        return 0

    os.makedirs(os.path.dirname(output_path), exist_ok=True)
    with open(output_path, "w", encoding="utf-8", newline="\n") as handle:
        handle.write(content)

    if not args.quiet:
        functions = [e for e in entry_points if e.holder == "TAMath"]
        candles = [e for e in entry_points if e.holder == "TACandle"]
        overloads = sum(len(e.overloads) for e in entry_points)
        sys.stdout.write(f"TAMath entry points   : {len(functions)}\n")
        sys.stdout.write(f"TACandle entry points : {len(candles)}\n")
        sys.stdout.write(f"Total entry points    : {len(entry_points)}\n")
        sys.stdout.write(f"Total public overloads: {overloads}\n")
        for category, _, _ in CATEGORIES:
            sys.stdout.write(f"  {category:<24}: {len(buckets[category])}\n")
        if missing_links:
            sys.stdout.write(
                f"WARNING: no generated documentation page found for {len(missing_links)} entry point(s): "
                + ", ".join(missing_links)
                + "\n"
            )
        else:
            sys.stdout.write(f"All {len(entry_points)} documentation links resolve to files on disk.\n")
        sys.stdout.write(f"Wrote {os.path.relpath(output_path, repo_root)}\n")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
