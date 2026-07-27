// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// A TA-Lib indicator output re-indexed onto the bar timeline, and — when bound to a bar window — subject to
/// the same no-look-ahead rule as the prices themselves.
/// </summary>
/// <remarks>
/// <para>
/// <b>The alignment rule.</b> Every <c>TAMath</c> entry point allocates its output as
/// <c>new double[endIdx - startIdx + 1]</c> and fills it from element <c>0</c>, then reports where that
/// element belongs through <see cref="IndicatorResult.BegIdx"/>. The mapping is therefore
/// </para>
/// <code>
/// output[k]  describes  bar (BegIdx + k)      for k in [0, NBElement)
/// </code>
/// <para>
/// Elements at <c>k &gt;= NBElement</c> are uninitialised zeros and carry no meaning. Reading the output array
/// as if element <c>k</c> described bar <c>k</c> shifts every signal backwards in time by <c>BegIdx</c> bars,
/// which is the single most common — and most silent — bug when consuming the library. This class performs
/// that mapping exactly once, in one place, and every strategy in this sample goes through it.
/// </para>
/// <para>
/// <b>The causality rule.</b> When constructed with a bar window, reading a bar index greater than
/// <see cref="IBarWindow.CurrentIndex"/> throws <see cref="LookAheadException"/> — an indicator value computed
/// from tomorrow's close is exactly as fatal as reading tomorrow's close directly. Passing
/// <see langword="null"/> for the window disables the guard, which is intended for unit-testing the alignment
/// arithmetic in isolation; the engine always binds a window.
/// </para>
/// <para>
/// <b>The metadata rule.</b> Causality has to cover the metadata too, or it is only a convention. A bound
/// series reports <see cref="Count"/>, <see cref="BegIdx"/> and <see cref="NBElement"/> <em>as of the current
/// bar</em>: <c>Count</c> is <c>CurrentIndex + 1</c>, and <c>NBElement</c> counts only the values that have
/// already happened. Otherwise a strategy could read the total number of bars out of <c>Count</c> in
/// <c>Initialize</c> and size up near a known end date — a look-ahead that never touches a price. The full
/// length is kept privately for bounds checking and is never observable.
/// </para>
/// </remarks>
public sealed class IndicatorSeries
{
    private readonly double[] _values;
    private readonly bool[] _hasValue;
    private readonly IBarWindow? _window;
    private readonly int _barCount;
    private readonly int _begIdx;
    private readonly int _nbElement;

    /// <summary>
    /// Initializes a new instance of the <see cref="IndicatorSeries"/> class by mapping a raw TA-Lib output
    /// array onto the bar timeline.
    /// </summary>
    /// <param name="name">A short name used in diagnostics, for example <c>"SMA(50)"</c>.</param>
    /// <param name="barCount">The number of bars in the source series.</param>
    /// <param name="begIdx">The <c>BegIdx</c> reported by TA-Lib: the bar index that output element <c>0</c> describes.</param>
    /// <param name="nbElement">The <c>NBElement</c> reported by TA-Lib: the number of meaningful output elements.</param>
    /// <param name="output">The raw output array. Only its first <paramref name="nbElement"/> elements are read.</param>
    /// <param name="window">
    /// The bar window that enforces causality, or <see langword="null"/> to disable the guard.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="name"/> or <paramref name="output"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="barCount"/>, <paramref name="begIdx"/> or <paramref name="nbElement"/> is negative.
    /// </exception>
    public IndicatorSeries(string name, int barCount, int begIdx, int nbElement, IReadOnlyList<double> output, IBarWindow? window)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(output);
        ArgumentOutOfRangeException.ThrowIfNegative(barCount);
        ArgumentOutOfRangeException.ThrowIfNegative(begIdx);
        ArgumentOutOfRangeException.ThrowIfNegative(nbElement);

        Name = name;
        _barCount = barCount;
        _begIdx = begIdx;
        _nbElement = nbElement;
        _window = window;
        _values = new double[barCount];
        _hasValue = new bool[barCount];

        // The one and only place where TA-Lib's (BegIdx, NBElement) convention is translated into bar indices.
        int usable = Math.Min(nbElement, output.Count);
        for (int k = 0; k < usable; k++)
        {
            int barIndex = begIdx + k;
            if (barIndex >= barCount)
            {
                break;
            }

            _values[barIndex] = output[k];
            _hasValue[barIndex] = true;
        }
    }

    /// <summary>
    /// Gets the diagnostic name of the series, for example <c>"RSI(14)"</c>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the number of <em>visible</em> bars: <c>CurrentIndex + 1</c> while bound to a bar window, and the
    /// full bar count only for an unbound series. The total length of the series never leaks through it.
    /// </summary>
    public int Count => _window is null ? _barCount : _window.CurrentIndex + 1;

    /// <summary>
    /// Gets the bar index of the first bar carrying a value, as reported by TA-Lib. Bars before it are
    /// consumed by the indicator's lookback and hold no value. Reads as <c>-1</c> while bound to a window
    /// that has not yet reached the first valid bar, because until then even that index is a fact about the
    /// future.
    /// </summary>
    public int BegIdx
    {
        get
        {
            if (_nbElement == 0)
            {
                return -1;
            }

            return _window is null || _begIdx <= _window.CurrentIndex ? _begIdx : -1;
        }
    }

    /// <summary>
    /// Gets the number of meaningful values TA-Lib produced, clamped to the visible region while bound to a
    /// bar window. <c>BegIdx + NBElement</c> is therefore never a probe for the end of the series.
    /// </summary>
    public int NBElement
    {
        get
        {
            if (_window is null)
            {
                return _nbElement;
            }

            int visible = _window.CurrentIndex - _begIdx + 1;
            return Math.Clamp(visible, 0, _nbElement);
        }
    }

    /// <summary>
    /// Gets the value of the indicator on the bar the backtest is currently positioned on.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// The series is not bound to a bar window, or the window has no current bar, or the current bar carries
    /// no value.
    /// </exception>
    public double Current
    {
        get
        {
            if (_window is null)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "Indicator '{0}' is not bound to a bar window.", Name));
            }

            return this[_window.CurrentIndex];
        }
    }

    /// <summary>
    /// Gets a value indicating whether the bar the backtest is currently positioned on carries a value.
    /// Returns <see langword="false"/> while the indicator is still warming up.
    /// </summary>
    public bool HasCurrent => _window is not null && _window.CurrentIndex >= 0 && HasValueAt(_window.CurrentIndex);

    /// <summary>
    /// Gets the indicator value that belongs to a specific bar.
    /// </summary>
    /// <param name="barIndex">The absolute bar index.</param>
    /// <returns>The indicator value for that bar.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="barIndex"/> is outside the bar series.
    /// </exception>
    /// <exception cref="LookAheadException">
    /// The series is bound to a window and <paramref name="barIndex"/> is in the future.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The bar carries no value because the indicator is still warming up. Use <see cref="TryGetValue"/> to
    /// test first.
    /// </exception>
    public double this[int barIndex]
    {
        get
        {
            Guard(barIndex);

            if (!_hasValue[barIndex])
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Indicator '{0}' has no value on bar {1}; the first valid bar is {2}.",
                        Name,
                        barIndex,
                        _begIdx));
            }

            return _values[barIndex];
        }
    }

    /// <summary>
    /// Determines whether a specific bar carries a value, taking the look-ahead guard into account.
    /// </summary>
    /// <param name="barIndex">The absolute bar index.</param>
    /// <returns><see langword="true"/> when the bar carries a value; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="barIndex"/> is outside the bar series.
    /// </exception>
    /// <exception cref="LookAheadException">
    /// The series is bound to a window and <paramref name="barIndex"/> is in the future.
    /// </exception>
    public bool HasValueAt(int barIndex)
    {
        Guard(barIndex);
        return _hasValue[barIndex];
    }

    /// <summary>
    /// Attempts to read the indicator value of a specific bar. This is the preferred accessor for strategy
    /// code, because it reports the warm-up period without throwing.
    /// </summary>
    /// <param name="barIndex">The absolute bar index.</param>
    /// <param name="value">
    /// When this method returns <see langword="true"/>, the indicator value; otherwise <c>0</c>.
    /// </param>
    /// <returns><see langword="true"/> when the bar carries a value; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="barIndex"/> is outside the bar series.
    /// </exception>
    /// <exception cref="LookAheadException">
    /// The series is bound to a window and <paramref name="barIndex"/> is in the future.
    /// </exception>
    public bool TryGetValue(int barIndex, out double value)
    {
        Guard(barIndex);

        value = _hasValue[barIndex] ? _values[barIndex] : 0.0;
        return _hasValue[barIndex];
    }

    /// <summary>
    /// Attempts to read the indicator value of the current bar and of the bar before it, which is what a
    /// crossover test needs.
    /// </summary>
    /// <param name="barIndex">The absolute bar index of the newer of the two bars.</param>
    /// <param name="previous">
    /// When this method returns <see langword="true"/>, the value on bar <c>barIndex - 1</c>.
    /// </param>
    /// <param name="current">
    /// When this method returns <see langword="true"/>, the value on bar <c>barIndex</c>.
    /// </param>
    /// <returns><see langword="true"/> when both bars carry a value; otherwise <see langword="false"/>.</returns>
    /// <exception cref="LookAheadException">
    /// The series is bound to a window and <paramref name="barIndex"/> is in the future.
    /// </exception>
    public bool TryGetPair(int barIndex, out double previous, out double current)
    {
        previous = 0.0;
        current = 0.0;

        // Causality is tested before the range test on purpose. If a past-the-end index returned false while
        // a future index threw, the difference between the two answers would be an oracle for the total
        // length of the series, findable by binary search without ever reading a value.
        if (barIndex > 0 && _window is not null && barIndex > _window.CurrentIndex)
        {
            throw LookAheadException.ForIndex(Name, barIndex, _window.CurrentIndex);
        }

        if (barIndex < 1 || barIndex >= _barCount)
        {
            return false;
        }

        bool hasPrevious = TryGetValue(barIndex - 1, out previous);
        bool hasCurrent = TryGetValue(barIndex, out current);

        return hasPrevious && hasCurrent;
    }

    private void Guard(int barIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(barIndex);

        // Causality is checked before the upper-range test, and the range test uses the private full length
        // rather than the visible Count. A bound series therefore answers *every* forward index with
        // LookAheadException — if it answered "out of range" past the end and "look-ahead" before it, the
        // pair of answers would spell out the total length of the series.
        if (_window is not null && barIndex > _window.CurrentIndex)
        {
            throw LookAheadException.ForIndex(Name, barIndex, _window.CurrentIndex);
        }

        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(barIndex, _barCount);
    }
}
