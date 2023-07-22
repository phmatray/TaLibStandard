// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents the color of a candle.
/// </summary>
public enum CandleColor
{
    /// <summary>
    /// Green candle (bullish). 
    /// </summary>
    Green = 1,
    
    /// <summary>
    /// Red candle (bearish).
    /// </summary>
    Red = -1
}
