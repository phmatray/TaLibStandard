// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The default <see cref="IBarWindow"/>: a movable cursor over a full bar series that refuses every read
/// beyond its current position.
/// </summary>
/// <remarks>
/// The cursor is advanced by <see cref="BacktestEngine"/> only — <see cref="MoveTo"/> is internal, and the
/// backing series is private with no accessor, so strategy code holding an <see cref="IBarWindow"/> can
/// neither move the cursor forward nor reach around it. The public constructor exists so that the guard
/// itself can be unit tested at an arbitrary position.
/// </remarks>
public sealed class BarWindow : IBarWindow
{
    private readonly IReadOnlyList<Bar> _bars;

    /// <summary>
    /// Initializes a new instance of the <see cref="BarWindow"/> class positioned before the first bar,
    /// with <see cref="CurrentIndex"/> equal to <c>-1</c>.
    /// </summary>
    /// <param name="bars">The full bar series. Never exposed to callers.</param>
    /// <exception cref="ArgumentNullException"><paramref name="bars"/> is <see langword="null"/>.</exception>
    public BarWindow(IReadOnlyList<Bar> bars)
        : this(bars, -1)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BarWindow"/> class positioned on a specific bar.
    /// </summary>
    /// <param name="bars">The full bar series. Never exposed to callers.</param>
    /// <param name="currentIndex">The initial cursor position. Use <c>-1</c> for "before the first bar".</param>
    /// <exception cref="ArgumentNullException"><paramref name="bars"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="currentIndex"/> is below <c>-1</c> or past the last bar.</exception>
    public BarWindow(IReadOnlyList<Bar> bars, int currentIndex)
    {
        ArgumentNullException.ThrowIfNull(bars);
        ArgumentOutOfRangeException.ThrowIfLessThan(currentIndex, -1);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(currentIndex, bars.Count);

        _bars = bars;
        CurrentIndex = currentIndex;
    }

    /// <inheritdoc />
    public int CurrentIndex { get; private set; }

    /// <inheritdoc />
    public int Count => CurrentIndex + 1;

    /// <inheritdoc />
    public Bar Current
    {
        get
        {
            if (CurrentIndex < 0)
            {
                throw new InvalidOperationException("The bar window is not positioned on a bar yet.");
            }

            return _bars[CurrentIndex];
        }
    }

    /// <inheritdoc />
    public Bar this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);

            if (index > CurrentIndex)
            {
                throw LookAheadException.ForIndex("bars", index, CurrentIndex);
            }

            return _bars[index];
        }
    }

    /// <inheritdoc />
    public Bar Ago(int offset)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(offset);

        int index = CurrentIndex - offset;
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(offset),
                offset,
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Stepping back {0} bars from bar {1} lands before the start of the series.",
                    offset,
                    CurrentIndex));
        }

        return _bars[index];
    }

    /// <summary>
    /// Moves the cursor to a new bar. Only the engine may call this, and only forward, one bar at a time.
    /// </summary>
    /// <param name="index">The bar index to move to.</param>
    internal void MoveTo(int index)
    {
        CurrentIndex = index;
    }
}
