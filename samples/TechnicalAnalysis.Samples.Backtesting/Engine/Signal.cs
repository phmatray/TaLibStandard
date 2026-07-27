// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The desired target exposure emitted by a strategy after it has observed a bar.
/// </summary>
/// <remarks>
/// A signal expresses a <em>target state</em>, not a delta. Emitting <see cref="EnterLong"/> while already long
/// is a no-op; emitting it while short reverses the position in a single fill at the next open. Because a signal
/// is always produced from the close of bar <c>i</c>, the engine can only act on it at the open of bar
/// <c>i + 1</c>. See <see cref="BacktestEngine"/> for the full execution timeline.
/// </remarks>
public enum Signal
{
    /// <summary>
    /// Keep the current exposure unchanged. No order is sent.
    /// </summary>
    Hold = 0,

    /// <summary>
    /// Target a long position. Any open short is covered first, at the same fill.
    /// </summary>
    EnterLong = 1,

    /// <summary>
    /// Target a short position. Any open long is closed first, at the same fill.
    /// When <see cref="BacktestOptions.AllowShort"/> is <see langword="false"/> the engine downgrades this
    /// signal to <see cref="Exit"/>, so the strategy simply goes flat instead of short.
    /// </summary>
    EnterShort = 2,

    /// <summary>
    /// Target a flat position. Any open position is closed. No-op when already flat.
    /// </summary>
    Exit = 3
}
