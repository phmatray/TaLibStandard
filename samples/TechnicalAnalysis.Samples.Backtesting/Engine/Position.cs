// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// An open position. Instances are immutable snapshots handed to a strategy; the engine replaces the
/// snapshot whenever the position changes.
/// </summary>
/// <param name="Side">
/// The side of the order that opened the position. <see cref="OrderSide.Buy"/> is long,
/// <see cref="OrderSide.Sell"/> is short.
/// </param>
/// <param name="Quantity">
/// The absolute number of units held. Always strictly positive; use <see cref="SignedQuantity"/> for the
/// signed exposure.
/// </param>
/// <param name="EntryPrice">The realised fill price of the opening order, slippage already applied.</param>
/// <param name="EntryIndex">The index of the bar whose open filled the position.</param>
/// <param name="EntryTime">The timestamp of the bar whose open filled the position.</param>
/// <param name="EntryCommission">The commission charged on the opening order, in account currency.</param>
public sealed record Position(
    OrderSide Side,
    double Quantity,
    double EntryPrice,
    int EntryIndex,
    DateTime EntryTime,
    double EntryCommission)
{
    /// <summary>
    /// Gets a value indicating whether the position is long.
    /// </summary>
    public bool IsLong => Side == OrderSide.Buy;

    /// <summary>
    /// Gets a value indicating whether the position is short.
    /// </summary>
    public bool IsShort => Side == OrderSide.Sell;

    /// <summary>
    /// Gets the signed exposure: <c>+Quantity</c> when long, <c>-Quantity</c> when short.
    /// </summary>
    public double SignedQuantity => IsLong ? Quantity : -Quantity;

    /// <summary>
    /// Gets the mark-to-market value of the position at the supplied price, defined as
    /// <c>SignedQuantity * price</c>.
    /// </summary>
    /// <param name="price">The price used to value the position.</param>
    /// <returns>The signed market value, negative for a short position.</returns>
    public double MarketValue(double price)
    {
        return SignedQuantity * price;
    }

    /// <summary>
    /// Gets the unrealised profit and loss of the position at the supplied price, before exit costs,
    /// defined as <c>SignedQuantity * (price - EntryPrice)</c>.
    /// </summary>
    /// <param name="price">The price used to value the position.</param>
    /// <returns>The unrealised profit (positive) or loss (negative) in account currency.</returns>
    public double UnrealizedProfit(double price)
    {
        return SignedQuantity * (price - EntryPrice);
    }
}
