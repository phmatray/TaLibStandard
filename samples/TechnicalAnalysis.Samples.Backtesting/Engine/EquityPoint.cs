// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// One sample of the equity curve, taken at the close of every bar, after any order scheduled for that bar
/// has been filled.
/// </summary>
/// <param name="BarIndex">The index of the bar in the source series.</param>
/// <param name="Timestamp">The timestamp of the bar.</param>
/// <param name="Price">The close price of the bar, used for the mark-to-market valuation.</param>
/// <param name="Cash">The cash balance of the account after all fills of the bar.</param>
/// <param name="SignedQuantity">The signed exposure held at the close of the bar: positive long, negative short, zero flat.</param>
/// <param name="Equity">The account equity, defined as <c>Cash + SignedQuantity * Price</c>.</param>
public sealed record EquityPoint(
    int BarIndex,
    DateTime Timestamp,
    double Price,
    double Cash,
    double SignedQuantity,
    double Equity)
{
    /// <summary>
    /// Gets a value indicating whether a position was open at the close of the bar. Used to compute exposure.
    /// </summary>
    public bool IsInPosition => SignedQuantity != 0.0;
}
