// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Diagnostics.CodeAnalysis;

namespace TechnicalAnalysis.Functions;

/// <content>
/// Contains the allocation-free enumerator over the warm bars of an <see cref="IndicatorSeries"/>.
/// </content>
public readonly partial struct IndicatorSeries
{
    /// <summary>
    /// Enumerates the warm bars of an <see cref="IndicatorSeries"/> in ascending BAR order.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Each iteration yields a <c>(Bar, Value)</c> pair in which <c>Bar</c> is a BAR index into the
    /// source price series — an absolute position, never an index into the raw TA-Lib output array.
    /// Bars that have no value are skipped rather than yielded as <c>null</c>, so enumerating an
    /// empty series performs zero iterations.
    /// </para>
    /// <para>
    /// <see cref="System.Collections.Generic.IEnumerable{T}"/> is deliberately not implemented:
    /// <c>foreach</c> binds to this pattern directly and allocates nothing, whereas implementing the
    /// interface would box the enumerator on every loop. Adding the interface later is a
    /// non-breaking change; removing an allocating enumerator would not be.
    /// </para>
    /// </remarks>
    [SuppressMessage(
        "Design",
        "CA1034:Nested types should not be visible",
        Justification = "Standard BCL value-type enumerator pattern; enables allocation-free foreach.")]
    [SuppressMessage(
        "Performance",
        "CA1815:Override equals and operator equals on value types",
        Justification = "An enumerator is a cursor, not a value; equality is meaningless.")]
    public struct Enumerator
    {
        /// <summary>
        /// The series being enumerated.
        /// </summary>
        private readonly IndicatorSeries _series;

        /// <summary>
        /// The ARRAY index of the current element, or <c>-1</c> before the first
        /// <see cref="MoveNext"/>.
        /// </summary>
        private int _arrayIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerator"/> struct.
        /// </summary>
        /// <param name="series">The series to enumerate.</param>
        internal Enumerator(IndicatorSeries series)
        {
            _series = series;
            _arrayIndex = -1;
        }

        /// <summary>
        /// Gets the current bar and its value.
        /// </summary>
        /// <value>
        /// A pair whose <c>Bar</c> is a BAR index in <c>[FirstBar, LastBar]</c> and whose
        /// <c>Value</c> is the value at that bar. Valid only after <see cref="MoveNext"/> has
        /// returned <c>true</c>.
        /// </value>
        /// <exception cref="InvalidOperationException">
        /// <see cref="MoveNext"/> has not yet been called, or it has already returned
        /// <c>false</c>. <c>foreach</c> never reaches this state; hand-driving the enumerator can,
        /// and a <see cref="NullReferenceException"/> out of a public API would read as a library
        /// defect rather than as caller misuse.
        /// </exception>
        public readonly (int Bar, double Value) Current =>
            (uint)_arrayIndex < (uint)_series.WarmCount
                ? _series.PairAt(_arrayIndex)
                : throw new InvalidOperationException(
                    "Enumeration has either not started or has already finished; call MoveNext and check that it " +
                    "returned true before reading Current.");

        /// <summary>
        /// Advances to the next warm bar.
        /// </summary>
        /// <returns>
        /// <c>true</c> when another warm bar is available and <see cref="Current"/> has been
        /// positioned on it; <c>false</c> when the series is exhausted.
        /// </returns>
        public bool MoveNext()
        {
            // The cursor is advanced one position past the last value, so that Current reports
            // "already finished" rather than handing back the last pair a second time, and it then
            // stops moving so that repeated calls cannot run the index away.
            if (_arrayIndex < _series.WarmCount)
            {
                _arrayIndex++;
            }

            return _arrayIndex < _series.WarmCount;
        }
    }
}
