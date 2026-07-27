// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// Thrown when strategy code attempts to read data that would not have been available at the moment the
/// decision is being taken — the defining bug of a broken backtest.
/// </summary>
/// <remarks>
/// This exception is the enforcement mechanism behind the no-look-ahead guarantee of
/// <see cref="BacktestEngine"/>. It is raised by <see cref="IBarWindow"/> and by
/// <see cref="IndicatorSeries"/> when an index strictly greater than the current bar index is requested.
/// It is deliberately <em>not</em> caught by the engine: a strategy that peeks into the future must fail
/// loudly rather than silently produce impossible returns.
/// </remarks>
public sealed class LookAheadException : InvalidOperationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LookAheadException"/> class.
    /// </summary>
    public LookAheadException()
        : base("Look-ahead bias detected: strategy code attempted to read data from the future.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LookAheadException"/> class with a specified message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public LookAheadException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LookAheadException"/> class with a specified message
    /// and a reference to the inner exception that caused it.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public LookAheadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Creates an exception describing an attempt to read bar <paramref name="requestedIndex"/> while the
    /// backtest is positioned on bar <paramref name="currentIndex"/>.
    /// </summary>
    /// <param name="source">A short description of the series being read, for example <c>"bars"</c> or an indicator name.</param>
    /// <param name="requestedIndex">The bar index the caller tried to read.</param>
    /// <param name="currentIndex">The index of the most recent bar the caller is allowed to read.</param>
    /// <returns>A <see cref="LookAheadException"/> carrying a diagnostic message.</returns>
    public static LookAheadException ForIndex(string source, int requestedIndex, int currentIndex)
    {
        string message = string.Format(
            CultureInfo.InvariantCulture,
            "Look-ahead bias detected while reading '{0}': index {1} lies in the future; the backtest is positioned on bar {2}. "
            + "A decision taken on bar {2} may only use data from bars 0..{2}.",
            source,
            requestedIndex,
            currentIndex);

        return new LookAheadException(message);
    }
}
