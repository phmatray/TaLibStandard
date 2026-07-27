// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The policy used to convert a signal into a traded quantity.
/// </summary>
public enum PositionSizing
{
    /// <summary>
    /// Allocate a fixed fraction of the current account equity to every new position.
    /// The fraction is <see cref="BacktestOptions.PositionFraction"/>.
    /// </summary>
    FixedFraction = 0,

    /// <summary>
    /// Allocate a fixed cash notional to every new position, capped by the current account equity.
    /// The notional is <see cref="BacktestOptions.PositionCash"/>.
    /// </summary>
    FixedCash = 1
}
