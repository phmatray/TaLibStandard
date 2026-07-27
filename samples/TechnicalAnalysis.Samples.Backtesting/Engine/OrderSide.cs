// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// Identifies the direction of an order. It is also used to describe the direction of a position or of a
/// completed round trip, in which case it refers to the side of the order that <em>opened</em> the position.
/// </summary>
public enum OrderSide
{
    /// <summary>
    /// A buy order. When it opens a position, the resulting position is long (positive quantity).
    /// </summary>
    Buy = 0,

    /// <summary>
    /// A sell order. When it opens a position, the resulting position is short (negative quantity).
    /// </summary>
    Sell = 1
}
