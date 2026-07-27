// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using System.Runtime.CompilerServices;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// An immutable price series — the entry point to the fluent indicator API.
/// </summary>
/// <remarks>
/// <para>
/// Build one with the factory that matches the data you actually have, then call an indicator on
/// it. Every position on this type is a BAR index with domain <c>[0, BarCount)</c>.
/// </para>
/// <para>
/// <b>The factories copy.</b> Immutability is unconditional rather than dependent on caller
/// discipline, so a <see cref="PriceSeries"/> and every <see cref="IndicatorSeries"/> derived from
/// it are safe for unrestricted concurrent use with no caveat. Because the factories take
/// <see cref="ReadOnlySpan{T}"/>, a caller with an oversized scratch buffer pays only for the valid
/// region: <c>PriceSeries.FromHlc(high.AsSpan(0, count), low.AsSpan(0, count), close.AsSpan(0, count))</c>.
/// </para>
/// <para>
/// <b>The factories reject non-finite prices.</b> A <see cref="double.NaN"/> close — a gapped tick,
/// a provider sentinel, a bad CSV parse — is refused at the boundary with an
/// <see cref="ArgumentException"/> naming the component and the first offending bar. It has to be:
/// the running sums inside TA-Lib's simple moving average, and the recursions inside the
/// exponential moving average, the average true range and the relative strength index, all
/// propagate a single <see cref="double.NaN"/> to every later bar. One bad tick would otherwise
/// poison the whole series while every status flag still read success, and
/// <c>if (sma[bar] is { } value)</c> would keep succeeding with a value that compares
/// <c>false</c> against every threshold. The factories already walk the data to copy it, so the
/// check costs nothing.
/// </para>
/// <para>
/// <b>There is no <c>startIdx</c> or <c>endIdx</c> anywhere on this surface.</b> Indicators always
/// analyse the full series, so the first bar of a result is always the indicator's true lookback,
/// and a caller can never trigger the unguarded end-index buffer overrun that a raw
/// <c>TAMath</c> call permits. Windowing is expressed by <see cref="AsOf"/>, which keeps bar
/// indices absolute instead of rebasing them.
/// </para>
/// <para>
/// <b>Missing components are never fabricated.</b> A close-only series does not pretend that open,
/// high and low equal the close; asking for them throws. Otherwise an ATR would silently compute
/// the absolute change in close and call it a true range.
/// </para>
/// <para>
/// <b>There is no caching.</b> Calling <c>prices.Sma(20)</c> twice computes twice. Because this is
/// a value type with no lazy state, caching is one field at the composition root when it is wanted,
/// and there is no shared mutable state and no locking when it is not.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// PriceSeries prices = PriceSeries.FromHlc(highs, lows, closes);
/// double? rsi = prices.Rsi(14).Latest;
/// double? atr = prices.Atr(14).Latest;
/// </code>
/// </example>
public readonly struct PriceSeries : IEquatable<PriceSeries>
{
    /// <summary>The opening prices, or <c>null</c> when the series carries none.</summary>
    private readonly double[]? _open;

    /// <summary>The high prices, or <c>null</c> when the series carries none.</summary>
    private readonly double[]? _high;

    /// <summary>The low prices, or <c>null</c> when the series carries none.</summary>
    private readonly double[]? _low;

    /// <summary>The closing prices, or <c>null</c> when the series is empty.</summary>
    private readonly double[]? _close;

    /// <summary>The volumes, or <c>null</c> when the series carries none.</summary>
    private readonly double[]? _volume;

    /// <summary>
    /// Initializes a new instance of the <see cref="PriceSeries"/> struct.
    /// </summary>
    /// <param name="open">The opening prices, or <c>null</c>.</param>
    /// <param name="high">The high prices, or <c>null</c>.</param>
    /// <param name="low">The low prices, or <c>null</c>.</param>
    /// <param name="close">The closing prices, or <c>null</c>.</param>
    /// <param name="volume">The volumes, or <c>null</c>.</param>
    /// <param name="barCount">The number of bars the series exposes, which may be fewer than the arrays hold.</param>
    private PriceSeries(double[]? open, double[]? high, double[]? low, double[]? close, double[]? volume, int barCount)
    {
        _open = open;
        _high = high;
        _low = low;
        _close = close;
        _volume = volume;
        BarCount = barCount;
    }

    /// <summary>
    /// Gets the empty price series.
    /// </summary>
    /// <value>
    /// <para>
    /// A series of zero bars carrying no components at all. Equivalent to
    /// <c>default(PriceSeries)</c>, which is what makes it a usable pre-roll state for a field that
    /// is filled in later.
    /// </para>
    /// <para>
    /// <b>It carries no high, low or volume, so the indicators that need them throw.</b>
    /// <see cref="OverlapStudyIndicators.Sma"/>, <see cref="OverlapStudyIndicators.Ema"/>,
    /// <see cref="OverlapStudyIndicators.BollingerBands"/>, <see cref="MomentumIndicators.Rsi"/>
    /// and <see cref="MomentumIndicators.Macd"/> need only closes and return an empty result;
    /// <see cref="VolatilityIndicators.Atr"/>, <see cref="MomentumIndicators.Adx"/> and
    /// <see cref="MomentumIndicators.Stoch"/> raise <see cref="InvalidOperationException"/> because
    /// component availability is checked before emptiness, and
    /// <see cref="VolumeIndicators.Obv"/> raises it for the missing volumes. A feed that must
    /// answer every indicator while it has no bars yet is
    /// <c>PriceSeries.FromOhlcv([], [], [], [], [])</c> — the components are then present and
    /// merely empty.
    /// </para>
    /// </value>
    public static PriceSeries Empty => default;

    /// <summary>
    /// Gets the number of bars in the series.
    /// </summary>
    /// <value>
    /// A count, not an index. Every BAR index on this type and on the indicator series derived from
    /// it has domain <c>[0, BarCount)</c>.
    /// </value>
    public int BarCount { get; }

    /// <summary>
    /// Gets a value indicating whether the series holds no bars.
    /// </summary>
    /// <value><c>true</c> when <see cref="BarCount"/> is zero.</value>
    public bool IsEmpty => BarCount == 0;

    /// <summary>
    /// Gets a value indicating whether the series carries opening prices.
    /// </summary>
    /// <value><c>true</c> when the series was built by <see cref="FromOhlc"/> or <see cref="FromOhlcv"/>.</value>
    public bool HasOpen => _open is not null;

    /// <summary>
    /// Gets a value indicating whether the series carries high and low prices.
    /// </summary>
    /// <value>
    /// <c>true</c> when the series was built by <see cref="FromHlc"/>, <see cref="FromOhlc"/> or
    /// <see cref="FromOhlcv"/>. Indicators that need a bar's range, such as ATR and the stochastic
    /// oscillator, require this.
    /// </value>
    public bool HasHighLow => _high is not null && _low is not null;

    /// <summary>
    /// Gets a value indicating whether the series carries volumes.
    /// </summary>
    /// <value><c>true</c> when the series was built by <see cref="FromOhlcv"/>.</value>
    public bool HasVolume => _volume is not null;

    /// <summary>
    /// Gets the closing prices.
    /// </summary>
    /// <value>
    /// A read-only span of exactly <see cref="BarCount"/> elements indexed by BAR index; an empty
    /// span when the series holds no bars. Every factory requires closes, so this never throws.
    /// </value>
    public ReadOnlySpan<double> Close => Span(_close);

    /// <summary>
    /// Gets the opening prices.
    /// </summary>
    /// <value>A read-only span of exactly <see cref="BarCount"/> elements indexed by BAR index.</value>
    /// <exception cref="InvalidOperationException">
    /// The series carries no opening prices; see <see cref="HasOpen"/>.
    /// </exception>
    public ReadOnlySpan<double> Open
    {
        get
        {
            RequireComponent(HasOpen, "Open prices", nameof(FromOhlc));
            return Span(_open);
        }
    }

    /// <summary>
    /// Gets the high prices.
    /// </summary>
    /// <value>A read-only span of exactly <see cref="BarCount"/> elements indexed by BAR index.</value>
    /// <exception cref="InvalidOperationException">
    /// The series carries no high prices; see <see cref="HasHighLow"/>.
    /// </exception>
    public ReadOnlySpan<double> High
    {
        get
        {
            RequireComponent(HasHighLow, "High prices", nameof(FromHlc));
            return Span(_high);
        }
    }

    /// <summary>
    /// Gets the low prices.
    /// </summary>
    /// <value>A read-only span of exactly <see cref="BarCount"/> elements indexed by BAR index.</value>
    /// <exception cref="InvalidOperationException">
    /// The series carries no low prices; see <see cref="HasHighLow"/>.
    /// </exception>
    public ReadOnlySpan<double> Low
    {
        get
        {
            RequireComponent(HasHighLow, "Low prices", nameof(FromHlc));
            return Span(_low);
        }
    }

    /// <summary>
    /// Gets the volumes.
    /// </summary>
    /// <value>A read-only span of exactly <see cref="BarCount"/> elements indexed by BAR index.</value>
    /// <exception cref="InvalidOperationException">
    /// The series carries no volumes; see <see cref="HasVolume"/>.
    /// </exception>
    public ReadOnlySpan<double> Volume
    {
        get
        {
            RequireComponent(HasVolume, "Volumes", nameof(FromOhlcv));
            return Span(_volume);
        }
    }

    /// <summary>
    /// Gets the backing array of closing prices for the indicator extensions in this assembly.
    /// </summary>
    /// <value>
    /// The full backing array, which may be longer than <see cref="BarCount"/> after
    /// <see cref="AsOf"/>. Never <c>null</c>. Callers must pass <c>BarCount - 1</c> as the end index
    /// so that only the bars this series exposes are analysed.
    /// </value>
    internal double[] CloseArray => _close ?? [];

    /// <summary>
    /// Gets the backing array of high prices for the indicator extensions in this assembly.
    /// </summary>
    /// <value>The full backing array, or an empty array when the component is absent.</value>
    internal double[] HighArray => _high ?? [];

    /// <summary>
    /// Gets the backing array of low prices for the indicator extensions in this assembly.
    /// </summary>
    /// <value>The full backing array, or an empty array when the component is absent.</value>
    internal double[] LowArray => _low ?? [];

    /// <summary>
    /// Gets the backing array of volumes for the indicator extensions in this assembly.
    /// </summary>
    /// <value>The full backing array, or an empty array when the component is absent.</value>
    internal double[] VolumeArray => _volume ?? [];

    /// <summary>
    /// Creates a price series from closing prices alone.
    /// </summary>
    /// <param name="close">The closing prices, copied into the new series. May be empty.</param>
    /// <returns>A series with <see cref="BarCount"/> equal to the length of <paramref name="close"/>.</returns>
    /// <remarks>
    /// The resulting series carries no open, high, low or volume, and does not fabricate them.
    /// Indicators that need a bar's range throw rather than silently computing something else.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// <paramref name="close"/> holds a value that is not finite.
    /// </exception>
    public static PriceSeries FromClose(ReadOnlySpan<double> close)
    {
        ValidateFinite(close, nameof(close));

        return new PriceSeries(null, null, null, close.ToArray(), null, close.Length);
    }

    /// <summary>
    /// Creates a price series from high, low and closing prices.
    /// </summary>
    /// <param name="high">The high prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="low">The low prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="close">The closing prices, which define the number of bars. May be empty.</param>
    /// <returns>A series with <see cref="BarCount"/> equal to the length of <paramref name="close"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="high"/> or <paramref name="low"/> has a different length from
    /// <paramref name="close"/>, or any component holds a value that is not finite.
    /// </exception>
    public static PriceSeries FromHlc(ReadOnlySpan<double> high, ReadOnlySpan<double> low, ReadOnlySpan<double> close)
    {
        int barCount = close.Length;
        ValidateLength(high, barCount, nameof(high));
        ValidateLength(low, barCount, nameof(low));
        ValidateFinite(high, nameof(high));
        ValidateFinite(low, nameof(low));
        ValidateFinite(close, nameof(close));

        return new PriceSeries(null, high.ToArray(), low.ToArray(), close.ToArray(), null, barCount);
    }

    /// <summary>
    /// Creates a price series from open, high, low and closing prices.
    /// </summary>
    /// <param name="open">The opening prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="high">The high prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="low">The low prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="close">The closing prices, which define the number of bars. May be empty.</param>
    /// <returns>A series with <see cref="BarCount"/> equal to the length of <paramref name="close"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="open"/>, <paramref name="high"/> or <paramref name="low"/> has a different
    /// length from <paramref name="close"/>, or any component holds a value that is not finite.
    /// Components are checked in the order open, high, low.
    /// </exception>
    public static PriceSeries FromOhlc(
        ReadOnlySpan<double> open,
        ReadOnlySpan<double> high,
        ReadOnlySpan<double> low,
        ReadOnlySpan<double> close)
    {
        int barCount = close.Length;
        ValidateLength(open, barCount, nameof(open));
        ValidateLength(high, barCount, nameof(high));
        ValidateLength(low, barCount, nameof(low));
        ValidateFinite(open, nameof(open));
        ValidateFinite(high, nameof(high));
        ValidateFinite(low, nameof(low));
        ValidateFinite(close, nameof(close));

        return new PriceSeries(open.ToArray(), high.ToArray(), low.ToArray(), close.ToArray(), null, barCount);
    }

    /// <summary>
    /// Creates a price series from open, high, low and closing prices together with volumes.
    /// </summary>
    /// <param name="open">The opening prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="high">The high prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="low">The low prices. Must be the same length as <paramref name="close"/>.</param>
    /// <param name="close">The closing prices, which define the number of bars. May be empty.</param>
    /// <param name="volume">The volumes. Must be the same length as <paramref name="close"/>.</param>
    /// <returns>A series with <see cref="BarCount"/> equal to the length of <paramref name="close"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="open"/>, <paramref name="high"/>, <paramref name="low"/> or
    /// <paramref name="volume"/> has a different length from <paramref name="close"/>, or any
    /// component holds a value that is not finite. Components are checked in the order open, high,
    /// low, volume.
    /// </exception>
    public static PriceSeries FromOhlcv(
        ReadOnlySpan<double> open,
        ReadOnlySpan<double> high,
        ReadOnlySpan<double> low,
        ReadOnlySpan<double> close,
        ReadOnlySpan<double> volume)
    {
        int barCount = close.Length;
        ValidateLength(open, barCount, nameof(open));
        ValidateLength(high, barCount, nameof(high));
        ValidateLength(low, barCount, nameof(low));
        ValidateLength(volume, barCount, nameof(volume));
        ValidateFinite(open, nameof(open));
        ValidateFinite(high, nameof(high));
        ValidateFinite(low, nameof(low));
        ValidateFinite(close, nameof(close));
        ValidateFinite(volume, nameof(volume));

        return new PriceSeries(
            open.ToArray(),
            high.ToArray(),
            low.ToArray(),
            close.ToArray(),
            volume.ToArray(),
            barCount);
    }

    /// <summary>
    /// Determines whether two price series are equal.
    /// </summary>
    /// <param name="left">The first series.</param>
    /// <param name="right">The second series.</param>
    /// <returns><c>true</c> when the two series are equal; otherwise <c>false</c>.</returns>
    public static bool operator ==(PriceSeries left, PriceSeries right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two price series are not equal.
    /// </summary>
    /// <param name="left">The first series.</param>
    /// <param name="right">The second series.</param>
    /// <returns><c>true</c> when the two series are not equal; otherwise <c>false</c>.</returns>
    public static bool operator !=(PriceSeries left, PriceSeries right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Returns the same price series truncated so that it ends at the given BAR index.
    /// </summary>
    /// <param name="bar">
    /// The last BAR index the narrowed series is allowed to know about, with domain
    /// <c>[0, BarCount)</c>.
    /// </param>
    /// <returns>
    /// A series with <see cref="BarCount"/> equal to <c>bar + 1</c>, sharing the same underlying
    /// data. Every span truncates accordingly, and bar indices are not rebased.
    /// </returns>
    /// <remarks>
    /// This is how a backtest hands a strategy the prices without handing it the future: the later
    /// bars are not part of the value at all, so no discipline is required to avoid reading them.
    /// It is allocation-free, which is what makes it usable as the default idiom inside a per-bar
    /// loop.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="bar"/> is negative or greater than or equal to <see cref="BarCount"/>.
    /// </exception>
    public PriceSeries AsOf(int bar)
    {
        ValidateBar(bar);

        return new PriceSeries(_open, _high, _low, _close, _volume, bar + 1);
    }

    /// <summary>
    /// Bar-aligns the result of any single-output <c>TAMath</c> call made over this price series.
    /// </summary>
    /// <param name="result">
    /// The raw result. It must have been computed over this series with a start index of <c>0</c>
    /// and an end index of <c>BarCount - 1</c>, otherwise its alignment metadata does not describe
    /// these bars.
    /// </param>
    /// <returns>An <see cref="IndicatorSeries"/> addressed by BAR index.</returns>
    /// <remarks>
    /// <para>
    /// This is the escape hatch to the roughly eighty single-output indicators that have no fluent
    /// wrapper yet, and it is the same primitive the shipped wrappers use, so an indicator reached
    /// this way is aligned exactly as carefully as one that ships. The bar count is supplied by this
    /// series, so it can never be mismatched.
    /// </para>
    /// <para>
    /// <b>The values are copied.</b> <c>result.Real</c> stays the caller's array and may be
    /// post-processed in place afterwards without disturbing the series handed back, which is what
    /// makes <see cref="IndicatorSeries"/> unconditionally immutable rather than immutable by
    /// convention. The copy is O(<c>NBElement</c>) against an O(n) indicator computation.
    /// </para>
    /// <para>
    /// <b>Naming your own extension methods.</b> The fluent indicators are extension methods on
    /// this type declared in this namespace, and the set of them will grow towards the full TA-Lib
    /// surface. A user-authored <c>public static IndicatorSeries Cci(this PriceSeries, int)</c>
    /// therefore becomes ambiguous (CS0121) the day the library ships its own <c>Cci</c>. Give your
    /// own extensions names the library will never take — a prefix such as <c>MyCci</c>, or a
    /// receiver type of your own — and treat the arrival of new indicators as potentially
    /// source-breaking for code that does otherwise.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="result"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">
    /// The result's alignment metadata is inconsistent with this series — its
    /// <c>BegIdx + NBElement</c> does not fit inside <see cref="BarCount"/>, or its
    /// <c>NBElement</c> exceeds its own output array. That is a defect in the indicator rather than
    /// in this call, and it is surfaced rather than clamped because clamping would hand back a
    /// silently shifted series. The parameter named by the exception is
    /// <paramref name="result"/>.
    /// </exception>
    public IndicatorSeries Align(SingleOutputResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return Align(result, static r => r.Real);
    }

    /// <summary>
    /// Bar-aligns one output of any multi-output <c>TAMath</c> call made over this price series.
    /// </summary>
    /// <typeparam name="TResult">The concrete result type.</typeparam>
    /// <param name="result">
    /// The raw result. It must have been computed over this series with a start index of <c>0</c>
    /// and an end index of <c>BarCount - 1</c>.
    /// </param>
    /// <param name="output">
    /// Selects the output array to align, from the same result whose metadata is used. Taking a
    /// selector rather than a separate array is what prevents one result's metadata being paired
    /// with another result's values, which would be a brand new way to misalign a series.
    /// </param>
    /// <returns>An <see cref="IndicatorSeries"/> addressed by BAR index.</returns>
    /// <remarks>
    /// The selected values are copied, so the result's own array remains the caller's to mutate.
    /// The naming guidance on <see cref="Align(SingleOutputResult)"/> applies here too.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="result"/> or <paramref name="output"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The result's alignment metadata is inconsistent with this series; see
    /// <see cref="Align(SingleOutputResult)"/>. The parameter named by the exception is
    /// <paramref name="result"/>.
    /// </exception>
    public IndicatorSeries Align<TResult>(TResult result, Func<TResult, double[]> output)
        where TResult : IndicatorResult
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(output);

        try
        {
            return IndicatorSeries.Create(result.RetCode, result.BegIdx, result.NBElement, output(result), BarCount);
        }
        catch (ArgumentException inconsistent) when (inconsistent is not ArgumentNullException)
        {
            // Create blames its own parameters -- nbElement, values -- which name nothing the
            // caller of Align passed, and which read as "your argument is bad" when the fault is
            // the indicator's metadata. Re-blame the argument the caller can actually see.
            throw new ArgumentException(
                $"The indicator result cannot be placed on this price series. {inconsistent.Message}",
                nameof(result),
                inconsistent);
        }
    }

    /// <summary>
    /// Bar-aligns one output of a <c>TAMath</c> call whose output array this assembly owns.
    /// </summary>
    /// <typeparam name="TResult">The concrete result type.</typeparam>
    /// <param name="result">The raw result, computed over this series from bar <c>0</c> to <c>BarCount - 1</c>.</param>
    /// <param name="output">Selects the output array to align.</param>
    /// <returns>An <see cref="IndicatorSeries"/> addressed by BAR index.</returns>
    /// <remarks>
    /// The shipped fluent indicators call this rather than the public <c>Align</c>: they made
    /// the <c>TAMath</c> call themselves, the result never escapes, and so the output array is
    /// reachable from nothing else and need not be copied. It performs exactly the same validation.
    /// </remarks>
    internal IndicatorSeries AlignOwning<TResult>(TResult result, Func<TResult, double[]> output)
        where TResult : IndicatorResult
    {
        return IndicatorSeries.CreateOwning(result.RetCode, result.BegIdx, result.NBElement, output(result), BarCount);
    }

    /// <summary>
    /// Determines whether this price series equals another.
    /// </summary>
    /// <param name="other">The series to compare with.</param>
    /// <returns>
    /// <c>true</c> when both series share every component array <i>by reference</i> and expose the
    /// same number of bars.
    /// </returns>
    /// <remarks>
    /// This does not compare prices. Two series built from identical inputs are not equal, because
    /// the factories copy and therefore hold different arrays. Equality exists so that this value
    /// type satisfies CA1815.
    /// </remarks>
    public bool Equals(PriceSeries other)
    {
        return ReferenceEquals(_open, other._open)
               && ReferenceEquals(_high, other._high)
               && ReferenceEquals(_low, other._low)
               && ReferenceEquals(_close, other._close)
               && ReferenceEquals(_volume, other._volume)
               && BarCount == other.BarCount;
    }

    /// <summary>
    /// Determines whether this price series equals the given object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>
    /// <c>true</c> when <paramref name="obj"/> is a <see cref="PriceSeries"/> equal to this one
    /// under <see cref="Equals(PriceSeries)"/>; otherwise <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is PriceSeries other && Equals(other);
    }

    /// <summary>
    /// Returns a hash code consistent with <see cref="Equals(PriceSeries)"/>.
    /// </summary>
    /// <returns>A hash code derived from the identity of the component arrays and the bar count.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(
            RuntimeHelpers.GetHashCode(_open),
            RuntimeHelpers.GetHashCode(_high),
            RuntimeHelpers.GetHashCode(_low),
            RuntimeHelpers.GetHashCode(_close),
            RuntimeHelpers.GetHashCode(_volume),
            BarCount);
    }

    /// <summary>
    /// Throws when a component span does not have the expected length.
    /// </summary>
    /// <param name="component">The component being validated.</param>
    /// <param name="expected">The number of bars the closing prices define.</param>
    /// <param name="parameterName">The name of the parameter carrying <paramref name="component"/>.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="component"/> has a different length from the closing prices.
    /// </exception>
    private static void ValidateLength(ReadOnlySpan<double> component, int expected, string parameterName)
    {
        if (component.Length != expected)
        {
            throw new ArgumentException(
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"'{parameterName}' holds {component.Length} bar(s) but 'close' holds {expected}. Every component " +
                    $"of a price series must describe the same bars."),
                parameterName);
        }
    }

    /// <summary>
    /// Throws when a component holds a value that is not finite.
    /// </summary>
    /// <param name="component">The component being validated.</param>
    /// <param name="parameterName">The name of the parameter carrying <paramref name="component"/>.</param>
    /// <remarks>
    /// One <see cref="double.NaN"/> or infinity does not spoil only the bars it touches. TA-Lib's
    /// simple moving average keeps a running sum, and <c>NaN - finite</c> is <c>NaN</c> for ever
    /// after; the exponential moving average, the average true range and the relative strength
    /// index are recursive and behave the same way. Refusing at the boundary converts a silent
    /// whole-series corruption into one diagnosable exception that names the first bad bar.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// <paramref name="component"/> holds a value that is not finite.
    /// </exception>
    private static void ValidateFinite(ReadOnlySpan<double> component, string parameterName)
    {
        for (int bar = 0; bar < component.Length; bar++)
        {
            if (!double.IsFinite(component[bar]))
            {
                throw new ArgumentException(
                    string.Create(
                        CultureInfo.InvariantCulture,
                        $"'{parameterName}' holds {component[bar]} at bar {bar}. A price series must be finite " +
                        $"throughout: a single non-finite bar propagates through every running sum and every " +
                        $"recursion in TA-Lib and silently corrupts the whole indicator. Clean or drop the bar " +
                        $"before building the series."),
                    parameterName);
            }
        }
    }

    /// <summary>
    /// Throws when a component the caller asked for is absent.
    /// </summary>
    /// <param name="available">Whether the component is present.</param>
    /// <param name="component">A human-readable name for the component.</param>
    /// <param name="factory">The name of the factory that would have supplied it.</param>
    /// <exception cref="InvalidOperationException">The component is absent.</exception>
    private static void RequireComponent(bool available, string component, string factory)
    {
        if (!available)
        {
            throw new InvalidOperationException(
                $"{component} are not available on this price series. Build it with PriceSeries.{factory} " +
                $"instead; a close-only series never fabricates the missing components.");
        }
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
                string.Create(CultureInfo.InvariantCulture, $"The bar index must lie in [0, {BarCount})."));
        }
    }

    /// <summary>
    /// Returns the first <see cref="BarCount"/> elements of a component array.
    /// </summary>
    /// <param name="component">The component array, which may be longer than <see cref="BarCount"/> after <see cref="AsOf"/>.</param>
    /// <returns>A read-only span of exactly <see cref="BarCount"/> elements, indexed by BAR index.</returns>
    private ReadOnlySpan<double> Span(double[]? component)
    {
        return component is null ? default : new ReadOnlySpan<double>(component, 0, BarCount);
    }
}
