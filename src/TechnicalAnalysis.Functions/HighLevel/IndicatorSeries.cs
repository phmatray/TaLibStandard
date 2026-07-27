// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using System.Runtime.CompilerServices;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// A bar-aligned view over a single output series produced by a TA-Lib indicator.
/// This is the one place in the library where TA-Lib's raw alignment metadata is interpreted.
/// </summary>
/// <remarks>
/// <para>
/// <b>There are two index spaces, and confusing them is the classic TA-Lib bug.</b>
/// </para>
/// <para>
/// An <i>array index</i> is a subscript into the raw <see cref="double"/><c>[]</c> that a
/// <c>TAMath</c> call returned. TA-Lib fills that array starting at array index <c>0</c>, and it
/// writes exactly <c>NBElement</c> elements, so the last valid array index is
/// <c>NBElement - 1</c>. Everything from <c>NBElement</c> to the end of the allocated array is
/// untouched zero padding and means nothing.
/// </para>
/// <para>
/// A <i>bar index</i> is a position in the source price series, with domain
/// <c>[0, BarCount)</c>. TA-Lib reports <c>BegIdx</c>, which is a <b>bar</b> index: output array
/// element <c>k</c> describes bar <c>BegIdx + k</c>. The last valid bar index is therefore
/// <c>BegIdx + NBElement - 1</c>.
/// </para>
/// <para>
/// <c>NBElement - 1</c> and <c>BegIdx + NBElement - 1</c> are two different numbers; they coincide
/// only when <c>BegIdx == 0</c>. Subscripting the output array with the bar index
/// <c>BegIdx + NBElement - 1</c> lands in the zero padding and silently yields <c>0.0</c>. That is
/// the mistake this type exists to make unsayable.
/// </para>
/// <para>
/// <b>The rule.</b> Every <see cref="int"/> on this type that names a position is a BAR index.
/// That covers the <c>bar</c> parameter of <see cref="this[int]"/>, <see cref="IsWarmAt"/>,
/// <see cref="AsOf"/> and all four crossing overloads; the values returned by
/// <see cref="FirstBar"/> and <see cref="LastBar"/>; the <c>Bar</c> component yielded by
/// <see cref="GetEnumerator"/>; and the index space of <see cref="ToBarAlignedArray"/>,
/// <see cref="ToBarAlignedNullableArray"/> and <see cref="CopyBarAligned"/>.
/// <see cref="WarmCount"/> and <see cref="BarCount"/> are counts, not indices, and neither is a
/// valid loop bound for the indexer — the indexer's domain is <c>[0, BarCount)</c>, so a loop over
/// it must be bounded by <see cref="BarCount"/>. No member of this type accepts or returns a raw
/// TA-Lib output-array index, with the single deliberate exception of <see cref="WarmValues"/>,
/// whose name and documentation state its index space explicitly. <see cref="Create"/> is the sole
/// point at which raw TA-Lib metadata enters the type system.
/// </para>
/// <para>
/// <b>Absence is <c>null</c>, uniformly.</b> A bar that is inside the series but before the
/// indicator has warmed up has no value, and that is reported as <c>null</c> — never <c>0.0</c>,
/// never <see cref="double.NaN"/>, and never an exception. There is no sentinel value anywhere on
/// this type: <see cref="this[int]"/> and <see cref="Latest"/> are <see cref="double"/><c>?</c>,
/// and <see cref="FirstBar"/> and <see cref="LastBar"/> are <see cref="int"/><c>?</c>. The single
/// exception is <see cref="ToBarAlignedArray"/> and <see cref="CopyBarAligned"/>, which pad with
/// <see cref="double.NaN"/> because a <see cref="double"/><c>[]</c> cannot hold <c>null</c>;
/// <see cref="ToBarAlignedNullableArray"/> is the projection that keeps the promise.
/// </para>
/// <para>
/// <b>A bar outside <c>[0, BarCount)</c> is a caller bug</b> and throws
/// <see cref="ArgumentOutOfRangeException"/>. "Bar 5 of a 30-period SMA" is a legitimate question
/// whose answer is "no value"; "bar 5000 of a 100-bar series" is not a question at all. That split
/// is what turns <see cref="AsOf"/> into a causality guarantee rather than a convention.
/// </para>
/// <para>
/// <b><see cref="RetCode"/> is not warmth.</b> A successful call over too little data reports
/// <see cref="Common.RetCode.Success"/> with <c>BegIdx == 0</c> and <c>NBElement == 0</c>, and in
/// that state <c>BegIdx</c> is a lie. <see cref="HasValues"/> (equivalently
/// <c>WarmCount &gt; 0</c>) is the only warmth test. <c>default(IndicatorSeries)</c> is a valid
/// series with no values that reports <see cref="Common.RetCode.Success"/>, because
/// <c>Success == 0</c>.
/// </para>
/// <para>
/// This is an immutable value type, and its immutability is unconditional: <see cref="Create"/>
/// copies the warm values out of the array it is handed, so no caller can reach inside a series
/// after handing it over. Every instance is therefore safe for unrestricted concurrent use.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// PriceSeries prices = PriceSeries.FromClose(closes);
/// IndicatorSeries sma = prices.Sma(30);
///
/// double? latest = sma.Latest;          // null until the indicator has warmed up
/// double? atBar50 = sma[50];            // 50 is a BAR index, not an array index
/// if (sma[50] is { } value)
/// {
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
public readonly partial struct IndicatorSeries : IEquatable<IndicatorSeries>
{
    /// <summary>
    /// The raw TA-Lib output array. Element <c>k</c> describes bar <c>_firstBar + k</c>, and only
    /// the first <see cref="WarmCount"/> elements are meaningful. Normalised to <c>null</c>
    /// whenever <see cref="WarmCount"/> is zero, so that every series with no values is
    /// indistinguishable from every other one with the same shape.
    /// </summary>
    private readonly double[]? _values;

    /// <summary>
    /// The BAR index described by array element <c>0</c> — TA-Lib's <c>BegIdx</c>. Meaningless
    /// when <see cref="WarmCount"/> is zero, and normalised to <c>0</c> in that case so that
    /// equality and hashing are stable.
    /// </summary>
    private readonly int _firstBar;

    /// <summary>
    /// Initializes a new instance of the <see cref="IndicatorSeries"/> struct.
    /// </summary>
    /// <param name="retCode">The return code reported by the underlying TA-Lib call.</param>
    /// <param name="firstBar">The BAR index of array element <c>0</c>; ignored when <paramref name="count"/> is zero.</param>
    /// <param name="count">The number of meaningful values in <paramref name="values"/>.</param>
    /// <param name="values">The raw TA-Lib output array, or <c>null</c> for a series with no values.</param>
    /// <param name="barCount">The number of bars in the source price series.</param>
    private IndicatorSeries(RetCode retCode, int firstBar, int count, double[]? values, int barCount)
    {
        bool noValues = count == 0;
        RetCode = retCode;
        BarCount = barCount;
        WarmCount = count;
        _firstBar = noValues ? 0 : firstBar;
        _values = noValues ? null : values;
    }

    /// <summary>
    /// Gets the return code reported by the underlying TA-Lib call.
    /// </summary>
    /// <value>
    /// The raw TA-Lib status. This answers only "were the parameters acceptable"; it never answers
    /// "are there values". A series can report <see cref="Common.RetCode.Success"/> and still hold
    /// nothing, because a period longer than the available data is a success that produces nothing.
    /// Use <see cref="HasValues"/> to test for warmth.
    /// </value>
    public RetCode RetCode { get; }

    /// <summary>
    /// Gets the number of bars in the source price series.
    /// </summary>
    /// <value>
    /// A count, not an index. The domain of every bar index on this type is
    /// <c>[0, BarCount)</c>, so this — not <see cref="WarmCount"/> — is the bound of a loop over
    /// <see cref="this[int]"/>.
    /// </value>
    public int BarCount { get; }

    /// <summary>
    /// Gets the number of bars that carry a value — TA-Lib's <c>NBElement</c>.
    /// </summary>
    /// <value>
    /// A count in the range <c>[0, BarCount]</c>, expressed in ARRAY space: it is the length of
    /// <see cref="WarmValues"/>. It is deliberately <b>not</b> called <c>Count</c>, because on a
    /// type with an indexer <c>Count</c> reads as "the number of valid indices" and this is not
    /// that: the indexer's domain is <c>[0, BarCount)</c>. Looping <c>for (int i = 0; i &lt;
    /// s.WarmCount; i++) s[i]</c> would read the wrong bars and silently drop the most recent
    /// ones. The last bar that carries a value is <see cref="LastBar"/>, which is
    /// <c>FirstBar + WarmCount - 1</c>.
    /// </value>
    public int WarmCount { get; }

    /// <summary>
    /// Gets a value indicating whether any bar of this series carries a value.
    /// </summary>
    /// <value>
    /// <c>true</c> when <see cref="WarmCount"/> is greater than zero. This is the only warmth test;
    /// a series can carry nothing and still report <see cref="Common.RetCode.Success"/>. It is
    /// deliberately not called <c>IsEmpty</c>: <see cref="PriceSeries.IsEmpty"/> means "no bars",
    /// and a series here can carry no values while covering a hundred bars.
    /// </value>
    public bool HasValues => WarmCount > 0;

    /// <summary>
    /// Gets the BAR index of the first bar that has a value, or <c>null</c> when no bar has one.
    /// </summary>
    /// <value>
    /// A bar index in <c>[0, BarCount)</c> — TA-Lib's <c>BegIdx</c>, reinterpreted as the true
    /// lookback of the indicator. <c>null</c> if and only if <see cref="HasValues"/> is
    /// <c>false</c>.
    /// </value>
    public int? FirstBar => WarmCount == 0 ? null : _firstBar;

    /// <summary>
    /// Gets the BAR index of the last bar that has a value, or <c>null</c> when no bar has one.
    /// </summary>
    /// <value>
    /// A bar index in <c>[0, BarCount)</c>, equal to <c>FirstBar + WarmCount - 1</c>. Note that
    /// this is a bar index and <c>WarmCount - 1</c> is an array index; they are different numbers.
    /// <c>null</c> if and only if <see cref="HasValues"/> is <c>false</c>.
    /// </value>
    public int? LastBar => WarmCount == 0 ? null : ToBarIndex(WarmCount - 1);

    /// <summary>
    /// Gets the value at the given BAR index, or <c>null</c> when that bar has no value.
    /// </summary>
    /// <param name="bar">
    /// A BAR index into the source price series, with domain <c>[0, BarCount)</c>. This is
    /// <b>not</b> an index into the raw TA-Lib output array.
    /// </param>
    /// <value>
    /// The value describing <paramref name="bar"/>, or <c>null</c> when <paramref name="bar"/> is
    /// inside the series but outside <c>[FirstBar, LastBar]</c> — typically a bar before the
    /// indicator warmed up. Never <c>0.0</c> and never <see cref="double.NaN"/> for a bar that has
    /// no value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// Asking about a bar the series does not cover is a caller bug, whereas asking about a bar
    /// that has not warmed up is a legitimate question answered with <c>null</c>.
    /// </exception>
    public double? this[int bar]
    {
        get
        {
            ValidateBar(bar);
            int arrayIndex = ToArrayIndex(bar);
            return IsWarmArrayIndex(arrayIndex) ? _values![arrayIndex] : null;
        }
    }

    /// <summary>
    /// Gets the most recent value in the series, or <c>null</c> when no bar has a value.
    /// </summary>
    /// <value>
    /// The value at <see cref="LastBar"/>. It is read from <b>array</b> index
    /// <c>WarmCount - 1</c>, never from bar index <c>FirstBar + WarmCount - 1</c>; the latter would
    /// index the array with a bar index, which is the historical alignment bug.
    /// </value>
    public double? Latest => WarmCount == 0 ? null : _values![WarmCount - 1];

    /// <summary>
    /// Gets the values as a span whose element <c>k</c> describes bar <c>FirstBar + k</c>.
    /// </summary>
    /// <value>
    /// A read-only span of exactly <see cref="WarmCount"/> elements — the single ARRAY-indexed view
    /// on this type, which is why it is named <c>WarmValues</c> rather than <c>Values</c>. It
    /// starts at array index <c>0</c> and is sliced to <see cref="WarmCount"/>, so TA-Lib's
    /// untouched zero padding is unreachable and the historical expression
    /// <c>Values[BegIdx + NBElement - 1]</c> throws <see cref="IndexOutOfRangeException"/> instead
    /// of silently returning a padding zero. A bar index is <b>not</b> a valid subscript here: use
    /// <see cref="this[int]"/> for that. A series with no values yields an empty span.
    /// </value>
    public ReadOnlySpan<double> WarmValues => _values is null ? default : new ReadOnlySpan<double>(_values, 0, WarmCount);

    /// <summary>
    /// Creates a series covering the given number of bars in which no bar has a value.
    /// </summary>
    /// <param name="barCount">The number of bars in the source price series. Must not be negative.</param>
    /// <returns>
    /// A series reporting <see cref="Common.RetCode.Success"/> with <see cref="WarmCount"/> zero,
    /// <see cref="BarCount"/> equal to <paramref name="barCount"/>, and <see cref="FirstBar"/>
    /// <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="barCount"/> is negative.</exception>
    public static IndicatorSeries Empty(int barCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(barCount);
        return new IndicatorSeries(Success, 0, 0, null, barCount);
    }

    /// <summary>
    /// Creates a bar-aligned series from the raw metadata of a TA-Lib call. This is the only point
    /// in the library at which raw TA-Lib alignment metadata enters the type system.
    /// </summary>
    /// <param name="retCode">The return code reported by the TA-Lib call.</param>
    /// <param name="begIdx">
    /// TA-Lib's <c>BegIdx</c>: the BAR index described by output array element <c>0</c>. It is not
    /// examined at all when <paramref name="nbElement"/> is zero, because TA-Lib reports
    /// <c>BegIdx == 0</c> in that state and the value is meaningless.
    /// </param>
    /// <param name="nbElement">
    /// TA-Lib's <c>NBElement</c>: the number of elements it actually wrote, starting at ARRAY index
    /// <c>0</c>. This is a count, not an index.
    /// </param>
    /// <param name="values">
    /// The raw output array. Its first <paramref name="nbElement"/> elements are <b>copied</b>, so
    /// the caller keeps sole ownership of the array it passed and may mutate it afterwards without
    /// affecting the series that was handed back. That is what makes the immutability of this type
    /// unconditional rather than a convention the caller has to honour.
    /// </param>
    /// <param name="barCount">The number of bars in the source price series.</param>
    /// <returns>A series in which every position is addressed by BAR index.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="begIdx"/>, <paramref name="nbElement"/> or <paramref name="barCount"/> is negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="nbElement"/> exceeds the length of <paramref name="values"/>, or
    /// <c>begIdx + nbElement</c> exceeds <paramref name="barCount"/>. The second check enforces
    /// TA-Lib's own invariant: the last described bar is <c>begIdx + nbElement - 1</c>, which must
    /// fall inside the source series. A result that violates it is misaligned at its source, and
    /// clamping it here would produce a silently shifted series — precisely the failure this type
    /// exists to prevent — so it is surfaced loudly instead.
    /// </exception>
    public static IndicatorSeries Create(RetCode retCode, int begIdx, int nbElement, double[] values, int barCount)
    {
        ArgumentNullException.ThrowIfNull(values);

        return CreateCore(retCode, begIdx, nbElement, values, barCount, copy: true);
    }

    /// <summary>
    /// Determines whether two series are equal.
    /// </summary>
    /// <param name="left">The first series.</param>
    /// <param name="right">The second series.</param>
    /// <returns><c>true</c> when the two series are equal; otherwise <c>false</c>.</returns>
    public static bool operator ==(IndicatorSeries left, IndicatorSeries right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two series are not equal.
    /// </summary>
    /// <param name="left">The first series.</param>
    /// <param name="right">The second series.</param>
    /// <returns><c>true</c> when the two series are not equal; otherwise <c>false</c>.</returns>
    public static bool operator !=(IndicatorSeries left, IndicatorSeries right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Creates a bar-aligned series that takes ownership of the output array instead of copying it.
    /// </summary>
    /// <param name="retCode">The return code reported by the TA-Lib call.</param>
    /// <param name="begIdx">TA-Lib's <c>BegIdx</c>: the BAR index described by array element <c>0</c>.</param>
    /// <param name="nbElement">TA-Lib's <c>NBElement</c>: the number of elements written.</param>
    /// <param name="values">
    /// The output array, which becomes the property of the series. It must have been allocated by
    /// the <c>TAMath</c> call being wrapped and must not be reachable from anywhere else, otherwise
    /// the immutability this type promises is broken.
    /// </param>
    /// <param name="barCount">The number of bars in the source price series.</param>
    /// <returns>A series in which every position is addressed by BAR index.</returns>
    /// <remarks>
    /// Internal on purpose. The shipped fluent indicators know that the array they pass was
    /// freshly allocated inside the call they just made and is held by nothing else, so they can
    /// skip the copy; a caller outside the assembly cannot make that promise about
    /// <c>result.Real</c>, which is why <see cref="Create"/> copies.
    /// </remarks>
    internal static IndicatorSeries CreateOwning(RetCode retCode, int begIdx, int nbElement, double[] values, int barCount)
    {
        ArgumentNullException.ThrowIfNull(values);

        return CreateCore(retCode, begIdx, nbElement, values, barCount, copy: false);
    }

    /// <summary>
    /// Determines whether the given BAR index has a value.
    /// </summary>
    /// <param name="bar">
    /// A BAR index into the source price series, with domain <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> when <paramref name="bar"/> lies in <c>[FirstBar, LastBar]</c>; otherwise
    /// <c>false</c>. Equivalent to <c>this[bar] is not null</c>, without the nullable value.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public bool IsWarmAt(int bar)
    {
        ValidateBar(bar);
        return IsWarmArrayIndex(ToArrayIndex(bar));
    }

    /// <summary>
    /// Returns the same series truncated so that it ends at the given BAR index, making look-ahead
    /// unrepresentable rather than merely detectable.
    /// </summary>
    /// <param name="bar">
    /// The last BAR index the narrowed series is allowed to know about, with domain
    /// <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// A series with <see cref="BarCount"/> equal to <c>bar + 1</c> and the same
    /// <see cref="FirstBar"/>, holding only the values at bars up to and including
    /// <paramref name="bar"/>. If no value survives, the result carries none at all. Bar indices
    /// are <b>not</b> rebased: they remain absolute positions in the original price series.
    /// </returns>
    /// <remarks>
    /// <para>
    /// Asking the narrowed series about a later bar throws, because that bar is outside its domain:
    /// <c>series.AsOf(50)[51]</c> is an <see cref="ArgumentOutOfRangeException"/>, not a value and
    /// not <c>null</c>. The future is simply not part of the value handed over.
    /// </para>
    /// <para>
    /// All shipped indicators are causal, so narrowing the end never changes an earlier value:
    /// <c>prices.AsOf(bar).Sma(30).Latest</c> equals <c>prices.Sma(30).AsOf(bar).Latest</c>
    /// exactly. This is the reason to prefer computing once and narrowing per bar — which is
    /// allocation-free and O(1) — over recomputing the indicator inside a per-bar loop, which is
    /// O(n²).
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public IndicatorSeries AsOf(int bar)
    {
        ValidateBar(bar);

        int survivingCount = WarmCount == 0 ? 0 : Math.Clamp(ToArrayIndex(bar) + 1, 0, WarmCount);

        return new IndicatorSeries(RetCode, _firstBar, survivingCount, _values, bar + 1);
    }

    /// <summary>
    /// Determines whether this series crossed above a fixed level at the given BAR index.
    /// </summary>
    /// <param name="level">The level to test against.</param>
    /// <param name="bar">
    /// The BAR index at which the crossing is tested, with domain <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> when the value at <paramref name="bar"/> is strictly above
    /// <paramref name="level"/> and the value at <c>bar - 1</c> was at or below it. A crossing is a
    /// transition between two bars, not a state: a series that is already above the level does not
    /// keep reporting a crossing. Returns <c>false</c> when <paramref name="bar"/> is <c>0</c>, or
    /// when either bar has no value.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public bool CrossedAbove(double level, int bar)
    {
        ValidateBar(bar);

        return bar > 0
               && this[bar] is { } current
               && this[bar - 1] is { } previous
               && current > level
               && previous <= level;
    }

    /// <summary>
    /// Determines whether this series crossed below a fixed level at the given BAR index.
    /// </summary>
    /// <param name="level">The level to test against.</param>
    /// <param name="bar">
    /// The BAR index at which the crossing is tested, with domain <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> when the value at <paramref name="bar"/> is strictly below
    /// <paramref name="level"/> and the value at <c>bar - 1</c> was at or above it. Returns
    /// <c>false</c> when <paramref name="bar"/> is <c>0</c>, or when either bar has no value.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public bool CrossedBelow(double level, int bar)
    {
        ValidateBar(bar);

        return bar > 0
               && this[bar] is { } current
               && this[bar - 1] is { } previous
               && current < level
               && previous >= level;
    }

    /// <summary>
    /// Determines whether this series crossed above another series at the given BAR index.
    /// </summary>
    /// <param name="other">
    /// The series to cross against. It must cover the same number of bars as this one, so that a
    /// bar index means the same thing in both.
    /// </param>
    /// <param name="bar">
    /// The BAR index at which the crossing is tested, with domain <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> when this series is strictly above <paramref name="other"/> at
    /// <paramref name="bar"/> and was at or below it at <c>bar - 1</c>. Returns <c>false</c> when
    /// <paramref name="bar"/> is <c>0</c>, or when any of the four values involved is missing —
    /// which is what makes a fast/slow crossing with different warm-ups work without any reasoning
    /// at the call site.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="other"/> covers a different number of bars than this series. Crossing two
    /// series computed over different price series is a caller bug.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public bool CrossedAbove(IndicatorSeries other, int bar)
    {
        ValidateComparable(other);
        ValidateBar(bar);

        return bar > 0
               && this[bar] is { } current
               && this[bar - 1] is { } previous
               && other[bar] is { } otherCurrent
               && other[bar - 1] is { } otherPrevious
               && current > otherCurrent
               && previous <= otherPrevious;
    }

    /// <summary>
    /// Determines whether this series crossed below another series at the given BAR index.
    /// </summary>
    /// <param name="other">
    /// The series to cross against. It must cover the same number of bars as this one.
    /// </param>
    /// <param name="bar">
    /// The BAR index at which the crossing is tested, with domain <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> when this series is strictly below <paramref name="other"/> at
    /// <paramref name="bar"/> and was at or above it at <c>bar - 1</c>. Returns <c>false</c> when
    /// <paramref name="bar"/> is <c>0</c>, or when any of the four values involved is missing.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="other"/> covers a different number of bars than this series.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public bool CrossedBelow(IndicatorSeries other, int bar)
    {
        ValidateComparable(other);
        ValidateBar(bar);

        return bar > 0
               && this[bar] is { } current
               && this[bar - 1] is { } previous
               && other[bar] is { } otherCurrent
               && other[bar - 1] is { } otherPrevious
               && current < otherCurrent
               && previous >= otherPrevious;
    }

    /// <summary>
    /// Projects the series onto a new array indexed by BAR index, padding bars that have no value
    /// with <see cref="double.NaN"/>.
    /// </summary>
    /// <returns>
    /// A new array of exactly <see cref="BarCount"/> elements in which element <c>i</c> describes
    /// bar <c>i</c>. The padding value is <see cref="double.NaN"/> and is deliberately not
    /// configurable, because padding with <c>0.0</c> reinstates exactly the silent corruption this
    /// type exists to prevent.
    /// </returns>
    /// <remarks>
    /// <para>
    /// <b><see cref="double.NaN"/> is a sentinel here, and it is the one place on this type where
    /// absence is not <c>null</c>.</b> A <see cref="double"/><c>[]</c> cannot hold <c>null</c>, so
    /// this projection collapses "this bar has no value" and "this bar has a value and the value is
    /// not finite" onto the same bit pattern. The fluent factories reject non-finite prices, so a
    /// series produced through this API cannot contain a computed <see cref="double.NaN"/>; a
    /// series built through <see cref="Create"/> from a hand-rolled call can. When the two states
    /// must be told apart, use <see cref="IsWarmAt"/>, <see cref="this[int]"/> or
    /// <see cref="ToBarAlignedNullableArray"/>, none of which have a sentinel.
    /// </para>
    /// <para>
    /// Because every indicator has a warm-up, the result of this method almost always contains
    /// <see cref="double.NaN"/>: <c>ToBarAlignedArray().Max()</c> and <c>.Average()</c> are
    /// <see cref="double.NaN"/> for a typical series, and a chart fed the raw array must be told
    /// how to skip them.
    /// </para>
    /// </remarks>
    public double[] ToBarAlignedArray()
    {
        double[] result = new double[BarCount];
        WriteBarAligned(result);
        return result;
    }

    /// <summary>
    /// Projects the series onto a new array indexed by BAR index, with <c>null</c> for bars that
    /// have no value.
    /// </summary>
    /// <returns>
    /// A new array of exactly <see cref="BarCount"/> elements in which element <c>i</c> describes
    /// bar <c>i</c>, and a bar with no value is <c>null</c> rather than a sentinel.
    /// </returns>
    /// <remarks>
    /// This is the projection that keeps the type's central promise — absence is <c>null</c> — at
    /// the cost of a boxed-free but larger <see cref="Nullable{T}"/> array. Prefer
    /// <see cref="ToBarAlignedArray"/> only when the consumer needs a contiguous
    /// <see cref="double"/><c>[]</c> and already understands the
    /// <see cref="double.NaN"/> convention.
    /// </remarks>
    public double?[] ToBarAlignedNullableArray()
    {
        double?[] result = new double?[BarCount];

        for (int arrayIndex = 0; arrayIndex < WarmCount; arrayIndex++)
        {
            result[ToBarIndex(arrayIndex)] = _values![arrayIndex];
        }

        return result;
    }

    /// <summary>
    /// Copies the values into a new array whose element <c>k</c> describes bar
    /// <c>FirstBar + k</c>.
    /// </summary>
    /// <returns>
    /// A new array of exactly <see cref="WarmCount"/> elements, ARRAY-indexed exactly as
    /// <see cref="WarmValues"/> is. It exists because <see cref="WarmValues"/> is a
    /// <see cref="ReadOnlySpan{T}"/> and therefore cannot escape into a LINQ query, an
    /// <c>async</c> method or a field.
    /// </returns>
    public double[] WarmValuesToArray()
    {
        return WarmCount == 0 ? [] : _values![..WarmCount];
    }

    /// <summary>
    /// Writes the series into the given span in which the index is the BAR index.
    /// </summary>
    /// <param name="destination">
    /// The span to write into. Its first <see cref="BarCount"/> elements are overwritten, so that
    /// element <c>i</c> describes bar <c>i</c>; bars that have no value are written as
    /// <see cref="double.NaN"/>. Any elements beyond <see cref="BarCount"/> are left untouched.
    /// </param>
    /// <remarks>
    /// The <see cref="double.NaN"/> padding carries the same caveat as
    /// <see cref="ToBarAlignedArray"/>: it is a sentinel, and it cannot be told apart from a
    /// computed non-finite value by inspecting the destination alone.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// <paramref name="destination"/> is shorter than <see cref="BarCount"/>.
    /// </exception>
    public void CopyBarAligned(Span<double> destination)
    {
        if (destination.Length < BarCount)
        {
            throw new ArgumentException(
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"The destination holds {destination.Length} element(s) but {BarCount} are needed, one per bar."),
                nameof(destination));
        }

        WriteBarAligned(destination);
    }

    /// <summary>
    /// Returns an allocation-free enumerator over the bars of this series that carry a value.
    /// </summary>
    /// <returns>
    /// An enumerator yielding <c>(Bar, Value)</c> pairs in ascending BAR order, one per bar with a
    /// value, where <c>Bar</c> is a BAR index in <c>[FirstBar, LastBar]</c>. Bars with no value are
    /// skipped entirely, so enumerating a series with no values performs zero iterations.
    /// </returns>
    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    /// <summary>
    /// Determines whether this series equals another.
    /// </summary>
    /// <param name="other">The series to compare with.</param>
    /// <returns>
    /// <c>true</c> when both series share the same backing array <i>by reference</i> and agree on
    /// their first bar, value count, bar count and return code.
    /// </returns>
    /// <remarks>
    /// This does <b>not</b> compare values. Two series computed separately from identical inputs
    /// are not equal, because they wrap different arrays. Equality exists so that this value type
    /// satisfies CA1815 and so that <see cref="AsOf"/> can be recognised as the identity when it
    /// narrows nothing; it is not a numeric comparison.
    /// </remarks>
    public bool Equals(IndicatorSeries other)
    {
        return ReferenceEquals(_values, other._values)
               && _firstBar == other._firstBar
               && WarmCount == other.WarmCount
               && BarCount == other.BarCount
               && RetCode == other.RetCode;
    }

    /// <summary>
    /// Determines whether this series equals the given object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>
    /// <c>true</c> when <paramref name="obj"/> is an <see cref="IndicatorSeries"/> equal to this
    /// one under <see cref="Equals(IndicatorSeries)"/>; otherwise <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is IndicatorSeries other && Equals(other);
    }

    /// <summary>
    /// Returns a hash code consistent with <see cref="Equals(IndicatorSeries)"/>.
    /// </summary>
    /// <returns>
    /// A hash code derived from the identity of the backing array together with the first bar,
    /// value count, bar count and return code.
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(
            RuntimeHelpers.GetHashCode(_values),
            _firstBar,
            WarmCount,
            BarCount,
            (int)RetCode);
    }

    /// <summary>
    /// Validates raw TA-Lib metadata and builds the series, optionally copying the values out of
    /// the array it was handed.
    /// </summary>
    /// <param name="retCode">The return code reported by the TA-Lib call.</param>
    /// <param name="begIdx">TA-Lib's <c>BegIdx</c>.</param>
    /// <param name="nbElement">TA-Lib's <c>NBElement</c>.</param>
    /// <param name="values">The output array, already checked for <c>null</c>.</param>
    /// <param name="barCount">The number of bars in the source price series.</param>
    /// <param name="copy">
    /// <c>true</c> to copy the first <paramref name="nbElement"/> elements, which is what makes the
    /// public entry points immune to later mutation of the caller's array.
    /// </param>
    /// <returns>A series in which every position is addressed by BAR index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="begIdx"/>, <paramref name="nbElement"/> or <paramref name="barCount"/> is negative.
    /// </exception>
    /// <exception cref="ArgumentException">The metadata is inconsistent; see <see cref="Create"/>.</exception>
    private static IndicatorSeries CreateCore(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] values,
        int barCount,
        bool copy)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(begIdx);
        ArgumentOutOfRangeException.ThrowIfNegative(nbElement);
        ArgumentOutOfRangeException.ThrowIfNegative(barCount);

        ValidateOutputLength(nbElement, values.Length);

        // A successful call over too little data reports Success with BegIdx == 0 and NBElement == 0.
        // BegIdx is meaningless in that state, so it is deliberately not examined.
        if (nbElement == 0)
        {
            return new IndicatorSeries(retCode, 0, 0, null, barCount);
        }

        ValidateFitsInSeries(begIdx, nbElement, barCount);

        double[] owned = copy ? values[..nbElement] : values;

        return new IndicatorSeries(retCode, begIdx, nbElement, owned, barCount);
    }

    /// <summary>
    /// Throws when a result claims more values than its output array can hold.
    /// </summary>
    /// <param name="nbElement">The number of values the result claims.</param>
    /// <param name="valuesLength">The length of the output array.</param>
    /// <exception cref="ArgumentException">The claim exceeds the array.</exception>
    private static void ValidateOutputLength(int nbElement, int valuesLength)
    {
        if (nbElement > valuesLength)
        {
            throw new ArgumentException(
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"The result claims {nbElement} value(s) but its output array holds only {valuesLength}."),
                nameof(nbElement));
        }
    }

    /// <summary>
    /// Throws when the bars a result describes do not fit inside the source price series.
    /// </summary>
    /// <param name="begIdx">The BAR index described by output array element <c>0</c>.</param>
    /// <param name="nbElement">The number of values the result claims.</param>
    /// <param name="barCount">The number of bars in the source price series.</param>
    /// <exception cref="ArgumentException">
    /// The last described bar, <c>begIdx + nbElement - 1</c>, lies outside the price series. The
    /// result is misaligned at its source; clamping it here would hide that behind a silently
    /// shifted series.
    /// </exception>
    private static void ValidateFitsInSeries(int begIdx, int nbElement, int barCount)
    {
        if ((long)begIdx + nbElement > barCount)
        {
            throw new ArgumentException(
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"The result describes bars {begIdx}..{begIdx + nbElement - 1} but the price series holds only " +
                    $"{barCount} bar(s). The indicator's alignment metadata is inconsistent and the values cannot be " +
                    $"placed on the price series."),
                nameof(nbElement));
        }
    }

    /// <summary>
    /// Converts a BAR index into an index into the raw TA-Lib output array.
    /// </summary>
    /// <param name="bar">A BAR index into the source price series.</param>
    /// <returns>
    /// The corresponding ARRAY index, which is meaningful only when it lies in
    /// <c>[0, WarmCount)</c> — see <see cref="IsWarmArrayIndex"/>. It is negative for a bar before
    /// the indicator warmed up.
    /// </returns>
    /// <remarks>
    /// This expression is the <b>only</b> bar-to-array conversion in the library. Every member that
    /// needs one delegates here, so there is exactly one place where the alignment can be got
    /// wrong, and it is covered by the regression suite.
    /// </remarks>
    private int ToArrayIndex(int bar)
    {
        return bar - _firstBar;
    }

    /// <summary>
    /// Converts an index into the raw TA-Lib output array into a BAR index.
    /// </summary>
    /// <param name="arrayIndex">An ARRAY index in <c>[0, WarmCount)</c>.</param>
    /// <returns>The BAR index that array element <paramref name="arrayIndex"/> describes.</returns>
    /// <remarks>
    /// The inverse of <see cref="ToArrayIndex"/>, and likewise the only array-to-bar conversion in
    /// the library. Used by <see cref="LastBar"/>, the projections and the enumerator.
    /// </remarks>
    private int ToBarIndex(int arrayIndex)
    {
        return _firstBar + arrayIndex;
    }

    /// <summary>
    /// Determines whether the given ARRAY index addresses a value that TA-Lib actually wrote.
    /// </summary>
    /// <param name="arrayIndex">An ARRAY index, possibly out of range or negative.</param>
    /// <returns><c>true</c> when the index lies in <c>[0, WarmCount)</c>; otherwise <c>false</c>.</returns>
    private bool IsWarmArrayIndex(int arrayIndex)
    {
        return (uint)arrayIndex < (uint)WarmCount;
    }

    /// <summary>
    /// Returns the pair yielded by the enumerator for the given ARRAY index.
    /// </summary>
    /// <param name="arrayIndex">An ARRAY index in <c>[0, WarmCount)</c>.</param>
    /// <returns>The BAR index that element describes, together with its value.</returns>
    private (int Bar, double Value) PairAt(int arrayIndex)
    {
        return (ToBarIndex(arrayIndex), _values![arrayIndex]);
    }

    /// <summary>
    /// Throws when the given BAR index is outside the bars this series covers.
    /// </summary>
    /// <param name="bar">A BAR index, expected to lie in <c>[0, BarCount)</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    private void ValidateBar(int bar)
    {
        if ((uint)bar >= (uint)BarCount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(bar),
                bar,
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"The bar index must lie in [0, {BarCount}). A bar inside that range that has no value is reported " +
                    $"as null rather than as an exception."));
        }
    }

    /// <summary>
    /// Throws when the given series does not cover the same bars as this one.
    /// </summary>
    /// <param name="other">The series being crossed against this one.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="other"/> covers a different number of bars.
    /// </exception>
    private void ValidateComparable(IndicatorSeries other)
    {
        if (other.BarCount != BarCount)
        {
            throw new ArgumentException(
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"The other series covers {other.BarCount} bar(s) but this one covers {BarCount}. Two series can " +
                    $"only be crossed when a bar index means the same thing in both."),
                nameof(other));
        }
    }

    /// <summary>
    /// Writes the bar-aligned projection into the first <see cref="BarCount"/> elements of a span.
    /// </summary>
    /// <param name="destination">
    /// A span of at least <see cref="BarCount"/> elements; only that prefix is written.
    /// </param>
    private void WriteBarAligned(Span<double> destination)
    {
        Span<double> bars = destination[..BarCount];
        bars.Fill(double.NaN);

        if (WarmCount > 0)
        {
            WarmValues.CopyTo(bars.Slice(ToBarIndex(0), WarmCount));
        }
    }
}
