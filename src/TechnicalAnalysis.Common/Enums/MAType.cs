// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Moving Average Type
/// </summary>
public enum MAType
{
    /// <summary>
    /// Simple Moving Average
    /// </summary>
    Sma,

    /// <summary>
    /// Exponential Moving Average
    /// </summary>
    Ema,
        
    /// <summary>
    /// Weight Moving Average
    /// </summary>
    Wma,
        
    /// <summary>
    /// Double Exponential Moving Average
    /// </summary>
    Dema,
        
    /// <summary>
    /// Triple Exponential Moving Average
    /// </summary>
    Tema,
        
    /// <summary>
    /// Triangular Moving Average
    /// </summary>
    Trima,
        
    /// <summary>
    /// Kaufman's Adaptive Moving Average
    /// </summary>
    Kama,
        
    /// <summary>
    /// MESA Adaptive Moving Average
    /// </summary>
    Mama,
        
    /// <summary>
    /// Tilson T3 Moving Average
    /// </summary>
    T3
}
