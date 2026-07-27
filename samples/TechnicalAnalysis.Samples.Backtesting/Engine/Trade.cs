// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// A completed round trip: one opening fill and one closing fill of the same quantity.
/// </summary>
/// <remarks>
/// Both prices are realised fill prices, so slippage is already baked into them. Commission is <em>not</em>;
/// <see cref="Commission"/> carries the sum of the entry and the exit commission and is subtracted by
/// <see cref="NetProfit"/>.
/// </remarks>
/// <param name="Side">
/// The side of the opening order. <see cref="OrderSide.Buy"/> is a long round trip,
/// <see cref="OrderSide.Sell"/> a short one.
/// </param>
/// <param name="Quantity">The absolute number of units traded.</param>
/// <param name="EntryIndex">The index of the bar whose open filled the entry.</param>
/// <param name="EntryTime">The timestamp of the bar whose open filled the entry.</param>
/// <param name="EntryPrice">The realised entry fill price, slippage already applied.</param>
/// <param name="ExitIndex">The index of the bar that filled the exit.</param>
/// <param name="ExitTime">The timestamp of the bar that filled the exit.</param>
/// <param name="ExitPrice">The realised exit fill price, slippage already applied.</param>
/// <param name="Commission">The total commission of the round trip: entry commission plus exit commission.</param>
public sealed record Trade(
    OrderSide Side,
    double Quantity,
    int EntryIndex,
    DateTime EntryTime,
    double EntryPrice,
    int ExitIndex,
    DateTime ExitTime,
    double ExitPrice,
    double Commission)
{
    /// <summary>
    /// Gets a value indicating whether the round trip was long.
    /// </summary>
    public bool IsLong => Side == OrderSide.Buy;

    /// <summary>
    /// Gets the profit and loss before commission, defined as
    /// <c>(ExitPrice - EntryPrice) * Quantity</c> for a long and
    /// <c>(EntryPrice - ExitPrice) * Quantity</c> for a short.
    /// </summary>
    public double GrossProfit => (IsLong ? ExitPrice - EntryPrice : EntryPrice - ExitPrice) * Quantity;

    /// <summary>
    /// Gets the profit and loss after commission, defined as <c>GrossProfit - Commission</c>.
    /// This is the value used by every trade-based performance metric.
    /// </summary>
    public double NetProfit => GrossProfit - Commission;

    /// <summary>
    /// Gets the net return on the entry notional, defined as <c>NetProfit / (EntryPrice * Quantity)</c>.
    /// Returns <c>0</c> when the entry notional is zero.
    /// </summary>
    public double ReturnOnNotional
    {
        get
        {
            double notional = EntryPrice * Quantity;
            return notional > 0.0 ? NetProfit / notional : 0.0;
        }
    }

    /// <summary>
    /// Gets the holding period in bars, defined as <c>ExitIndex - EntryIndex</c>.
    /// </summary>
    public int BarsHeld => ExitIndex - EntryIndex;

    /// <summary>
    /// Gets a value indicating whether the round trip was profitable after commission
    /// (strictly positive <see cref="NetProfit"/>).
    /// </summary>
    public bool IsWin => NetProfit > 0.0;

    /// <summary>
    /// Gets a value indicating whether the round trip lost money after commission
    /// (strictly negative <see cref="NetProfit"/>).
    /// </summary>
    public bool IsLoss => NetProfit < 0.0;
}
