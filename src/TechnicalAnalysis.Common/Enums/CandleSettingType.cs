// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.
namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an enumeration of candlestick pattern settings.
/// </summary>
public enum CandleSettingType
{
    /// <summary>
    /// Long body setting.
    /// </summary>
    BodyLong = 0,

    /// <summary>
    /// Very long body setting.
    /// </summary>
    BodyVeryLong = 1,

    /// <summary>
    /// Short body setting.
    /// </summary>
    BodyShort = 2,

    /// <summary>
    /// Doji body setting.
    /// </summary>
    BodyDoji = 3,

    /// <summary>
    /// Long shadow setting.
    /// </summary>
    ShadowLong = 4,

    /// <summary>
    /// Very long shadow setting.
    /// </summary>
    ShadowVeryLong = 5,

    /// <summary>
    /// Short shadow setting.
    /// </summary>
    ShadowShort = 6,

    /// <summary>
    /// Very short shadow setting.
    /// </summary>
    ShadowVeryShort = 7,

    /// <summary>
    /// Near setting.
    /// </summary>
    Near = 8,

    /// <summary>
    /// Far setting.
    /// </summary>
    Far = 9,

    /// <summary>
    /// Equal setting.
    /// </summary>
    Equal = 10,

    /// <summary>
    /// All candle settings.
    /// </summary>
    AllCandleSettings = 11
}
